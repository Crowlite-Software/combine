using CombineControl.Items;
using Sandbox;

namespace CombineControl.Entities
{
	[Library( "cc_item" )]
	public partial class ItemEntity : ModelEntity
	{
		[Net]
		public BaseItem Item { get; set; }

		public ItemEntity()
		{
			//SetModel( "models/dev/error.vmdl" );
			SetupPhysicsFromModel( PhysicsMotionType.Dynamic, false );
		}

		public void SetItem(BaseItem newItem)
		{
			Item = newItem;
		}
	}
}
