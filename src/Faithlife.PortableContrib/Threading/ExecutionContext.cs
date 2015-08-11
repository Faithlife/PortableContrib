using System.Runtime.InteropServices;

namespace System.Threading
{
	/// <summary>
	/// Callback for use with ExecutionContext.Run.
	/// </summary>
	[ComVisible(true)]
	public delegate void ContextCallback(object state);

	/// <summary>
	/// Manages the execution context for the current thread.
	/// </summary>
	public sealed class ExecutionContext : IDisposable
	{
		/// <summary>
		/// Captures the execution context from the current thread.
		/// </summary>
		public static ExecutionContext Capture()
		{
			return new ExecutionContext(SynchronizationContext.Current);
		}

		/// <summary>
		/// Runs a method in a specified execution context on the current thread.
		/// </summary>
		public static void Run(ExecutionContext context, ContextCallback callback, object state)
		{
			var syncContext = SynchronizationContext.Current;
			try
			{
				SynchronizationContext.SetSynchronizationContext(context.m_synchronizationContext);
				callback(state);
			}
			finally
			{
				SynchronizationContext.SetSynchronizationContext(syncContext);
			}
		}

		/// <summary>
		/// Releases resources for this execution context.
		/// </summary>
		public void Dispose()
		{
			m_synchronizationContext = null;
		}

		ExecutionContext(SynchronizationContext synchronizationContext)
		{
			m_synchronizationContext = synchronizationContext;
		}

		SynchronizationContext m_synchronizationContext;
	}
}
