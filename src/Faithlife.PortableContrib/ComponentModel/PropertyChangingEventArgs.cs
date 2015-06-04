namespace System.ComponentModel
{
	/// <summary>
	/// Provides data for the PropertyChanging event. 
	/// </summary>
	public class PropertyChangingEventArgs : EventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PropertyChangingEventArgs" /> class.
		/// </summary>
		/// <param name="propertyName">The name of the property whose value is changing.</param>
		public PropertyChangingEventArgs(string propertyName)
		{
			m_propertyName = propertyName;
		}

		/// <summary>
		/// Gets the name of the property whose value is changing.
		/// </summary>
		/// <value>
		/// The name of the property whose value is changing.
		/// </value>
		public virtual string PropertyName
		{
			get { return m_propertyName; }
		}

		readonly string m_propertyName;
	}
}
