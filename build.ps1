properties {
  $configuration = "Release"
  $gitPath = "C:\Program Files (x86)\Git\bin\git.exe"
  $outputDir = "build"
  $apiKey = $null
  $nugetPackageSource = $null
}

$version = $null

Task Default -depends NuGetPack, NuGetPublish

Task Clean {
  Get-ChildItem "src\*\bin" | Remove-Item -force -recurse -ErrorAction Stop
  Get-ChildItem "src\*\obj" | Remove-Item -force -recurse -ErrorAction Stop
  Get-ChildItem "tests\*\bin" | Remove-Item -force -recurse -ErrorAction Stop
  Get-ChildItem "tests\*\obj" | Remove-Item -force -recurse -ErrorAction Stop
  if (Test-Path $outputDir) {
    Remove-Item $outputDir -force -recurse -ErrorAction Stop
  }
}

Task Build -depends Clean {
  $env:path = "C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\MSBuild\15.0\Bin\;$env:path"
  $env:path = "C:\Program Files (x86)\Microsoft Visual Studio\2017\BuildTools\MSBuild\15.0\Bin\;$env:path"
  Exec { tools\NuGet\NuGet.exe restore }
  Exec { msbuild /t:Restore }
  Exec { msbuild /m:4 /p:Configuration=$configuration /p:Platform="Any CPU" PortableContrib.sln }
}

Task Test -depends Build {
  md "build\tests"
  Copy "tests\Faithlife.PortableContrib.Tests\bin\$configuration\*.dll" "build\tests"
  Copy "src\Faithlife.PortableContrib\bin\$configuration\Net45\Faithlife.PortableContrib.dll" "build\tests"
  Exec { packages\xunit.runner.console.2.0.0\tools\xunit.console.exe "build\tests\Faithlife.PortableContrib.Tests.dll" -xml "build\testresults.xml" }
}

Task SourceIndex -depends Test {
  $headSha = & $gitPath rev-parse HEAD
  foreach ($framework in @("Portable", "Net45", "MonoAndroid", "Xamarin.iOS")) {
    Exec { tools\SourceIndex\github-sourceindexer.ps1 -symbolsFolder src\Faithlife.PortableContrib\bin\$configuration\$framework -userId Faithlife -repository PortableContrib -branch $headSha -sourcesRoot ${pwd} -dbgToolsPath "C:\Program Files (x86)\Windows Kits\8.1\Debuggers\x86" -gitHubUrl "https://raw.github.com" -serverIsRaw -ignoreUnknown -verbose }
  }
}

Task NuGetPack -depends SourceIndex {
  mkdir $outputDir -force
  $script:version = [System.Diagnostics.FileVersionInfo]::GetVersionInfo("src\Faithlife.PortableContrib\bin\$configuration\Portable\Faithlife.PortableContrib.dll").FileVersion
  $script:version = $script:version.Substring(0, $script:version.LastIndexOf('.'))
  Exec { tools\NuGet\NuGet pack Faithlife.PortableContrib.nuspec -Version $script:version -Prop Configuration=$configuration -OutputDirectory $outputDir }
}

Task NuGetPublish -depends NuGetPack -precondition { return $apiKey -and $nugetPackageSource } {
  Exec { tools\NuGet\NuGet push $outputDir\Faithlife.PortableContrib.$script:version.nupkg -ApiKey $apiKey -Source $nugetPackageSource }
}
