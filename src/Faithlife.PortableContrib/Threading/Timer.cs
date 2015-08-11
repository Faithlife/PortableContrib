using System.Diagnostics.Contracts;
using System.Threading.Tasks;

namespace System.Threading
{
	/// <summary>
	/// Timer callback.
	/// </summary>
	public delegate void TimerCallback(object state);

	/// <summary>
	/// Simulates a System.Threading.Timer using Task.Delay().
	/// </summary>
	public sealed class Timer : IDisposable
	{
		/// <summary>
		/// Instantiates a new timer.
		/// </summary>
		public Timer(TimerCallback callback, object state, TimeSpan dueTime, TimeSpan period)
		{
			Contract.Assert(period.TotalMilliseconds == -1, "This stub implementation only supports dueTime.");
			m_cts = new CancellationTokenSource();
			Task.Delay(dueTime, m_cts.Token).ContinueWith((t, s) =>
				{
					var tuple = (Tuple<TimerCallback, object>) s;
					tuple.Item1(tuple.Item2);
				}, Tuple.Create(callback, state), CancellationToken.None,
				TaskContinuationOptions.ExecuteSynchronously | TaskContinuationOptions.OnlyOnRanToCompletion,
				TaskScheduler.Default);
		}

		/// <summary>
		/// Disposes the timer.
		/// </summary>
		public void Dispose()
		{
			m_cts.Cancel();
		}

		readonly CancellationTokenSource m_cts;
	}
}
