using Sandbox;
using System;

namespace CombineControl
{
	partial class CCPlayer
	{
		DamageInfo LastDamage;

		public override void OnKilled()
		{
			base.OnKilled();

			Camera = new SpectateRagdollCamera();
			Controller = null;

			EnableAllCollisions = false;
			EnableDrawing = false;
		}

		public override void TakeDamage( DamageInfo info )
		{
			LastDamage = info;

			base.TakeDamage( info );
		}
	}
}
