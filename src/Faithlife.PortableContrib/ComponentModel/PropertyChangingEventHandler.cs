namespace System.ComponentModel
{
	/// <summary>
	/// Represents the method that will handle the PropertyChanging event of an INotifyPropertyChanging interface. 
	/// </summary>
	/// <param name="sender">The source of the event.</param>
	/// <param name="e">The <see cref="PropertyChangingEventArgs" /> instance containing the event data.</param>
	public delegate void PropertyChangingEventHandler(object sender, PropertyChangingEventArgs e);
}
