using System.ComponentModel;
using Exiled.API.Interfaces;

namespace Site_Manager
{
    internal class Config : IConfig
    {
		[Description("Enable or Disable the manager Plugin.")]
		public bool IsEnabled { get; set; } = true;


		[Description("The chance that the manager spawns in a round.")]
		public int spawnChance { get; set; } = 33;

		[Description("The manager's health")]
		public int healthPercent { get; set; } = 120;


		[Description("Customize the broadcast when the manager spawns")]
		public string spawnBroadcast { get; set; } = "<b>You are the <color=yellow>Site Manager!</color></b>\n<i>Escape from the facility and don't get killed!</i>";


		[Description("How long should Broadcast be? (in seconds)")]
		public ushort broadcastLength { get; set; } = 10;


		[Description("The inventory of the manager")]
		public ItemType[] spawnInventory { get; set; } = new ItemType[] { ItemType.Medkit, ItemType.KeycardFacilityManager };
	}
}
