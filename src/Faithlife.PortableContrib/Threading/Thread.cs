using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace System.Threading
{
	/// <summary>
	/// Represents the method that executes on a <see cref="Thread"/>.
	/// </summary>
	public delegate void ThreadStart();

	/// <summary>
	/// Thread abstraction using a long running task to simulate a System.Threading.Thread
	/// </summary>
	public sealed class Thread
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="Thread" /> class.
		/// </summary>
		/// <param name="start">The thread proc.</param>
		public Thread(ThreadStart start)
		{
			m_start = start;
		}

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>
		/// The name.
		/// </value>
		public string Name { get; set; }

		/// <summary>
		/// Starts the thread by running the specified thread proc.
		/// </summary>
		public void Start()
		{
			m_task = Task.Factory.StartNew(new Action(m_start), TaskCreationOptions.LongRunning);
		}

		/// <summary>
		/// Blocks the calling thread until this thread terminates.
		/// </summary>
		public void Join()
		{
			m_task.Wait();
		}

		/// <summary>
		/// Reads the value of a field. See .NET Framework 4.5.
		/// </summary>
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static int VolatileRead(ref int address)
		{
			int value = address;
			Interlocked.MemoryBarrier();
			return value;
		}

		/// <summary>
		/// Blocks the current thread for the specified time.
		/// </summary>
		public static void Sleep(int millisecondsTimeout)
		{
			Sleep(TimeSpan.FromMilliseconds(millisecondsTimeout));
		}

		/// <summary>
		/// Blocks the current thread for the specified time.
		/// </summary>
		public static void Sleep(TimeSpan timeout)
		{
			// Set is never called, so we wait always until the timeout occurs
			using (EventWaitHandle tmpEvent = new ManualResetEvent(false))
			{
				tmpEvent.WaitOne(timeout);
			}
		}

		readonly ThreadStart m_start;
		Task m_task;
	}
}
