using Sandbox;
using System.Collections.Generic;

namespace CombineControl.Systems
{
	/// <summary>
	/// This is the base class for all our systems.
	/// All base systems are intitliased when the game class is constructed.
	/// </summary>
	public abstract class BaseSystem : NetworkComponent
	{
		public static List<BaseSystem> SystemsList = new List<BaseSystem>();

		/// <summary>
		/// Called when the game is constructed
		/// </summary>
		public abstract bool Init();
	}
}
