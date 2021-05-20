using Sandbox;

namespace CombineControl.Util
{
	public static class PlayerUtil
	{
		///
		/// Debug Console Commands
		///

		/// <summary>
		/// Damages the player with a specified amount of damage
		/// From: https://github.com/ampersoftware/Team-Fortress-Source-2/blob/master/code/player/CTFPlayer.cs#L77-L84
		/// </summary>
		[ServerCmd( "rp_dev_damageme" )]
		public static void DamageMeCmd( int damage )
		{
			if ( ConsoleSystem.Caller.Pawn is CCPlayer player )
			{
				int oldHealth = player.Health;
				player.TakeDamage( DamageInfo.FromBullet( player.Position, Vector3.Zero, damage ) );

				Log.Info( $"Old health: {oldHealth}, new health: {player.Health}" );
			}
		}
	}
}
