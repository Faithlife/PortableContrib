namespace System.ComponentModel
{
	/// <summary>
	/// Notifies clients that a property value is changing.
	/// </summary>
	public interface INotifyPropertyChanging
	{
		/// <summary>
		/// Occurs when property changing.
		/// </summary>
		event PropertyChangingEventHandler PropertyChanging;
	}
}
