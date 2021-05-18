using CombineControl.Items;
using Sandbox;

namespace CombineControl.Entities
{
	[Library( "cc_item" )]
	public partial class ItemEntity : ModelEntity, IUse
	{
		[Net]
		public BaseItem Item { get; set; }

		public ItemEntity()
		{
			//SetModel( "models/dev/error.vmdl" );
			SetupPhysicsFromModel( PhysicsMotionType.Dynamic, false );
		}

		public void SetItem( BaseItem newItem )
		{
			Item = newItem;
		}

		public bool OnUse( Entity user )
		{
			// Todo: Remove this when possible, only added for debug purposes
			Delete();

			return true;
		}

		public bool IsUsable( Entity user )
		{
			return true;
		}
	}
}
