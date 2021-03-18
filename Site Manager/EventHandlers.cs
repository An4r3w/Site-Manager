using System;
using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace Site_Manager
{
	internal class EventHandlers
	{


		public void onRoleChange(ChangingRoleEventArgs ev)
		{
			if (ev.Player.Role == RoleType.Scientist&& EventHandlers.manager.Count < 1)
			{
				if (new Random().Next(0, 101) <= Plugin.Singleton.Config.spawnChance)
				{
					EventHandlers.spawnmanager(ev.Player);
				}

			}
			if (EventHandlers.manager.Contains(ev.Player))
			{
				this.killmanager(ev.Player);
			}
		}

		public static void spawnmanager(Player p)
		{
			if (EventHandlers.manager.Count < 1)
			{
				EventHandlers.manager.Add(p);
				p.Broadcast(Plugin.Singleton.Config.broadcastLength, Plugin.Singleton.Config.spawnBroadcast, 0);

				foreach(ItemType item in Plugin.Singleton.Config.spawnInventory)
                {
					p.AddItem(item);
                }

				p.MaxHealth = Plugin.Singleton.Config.healthPercent;
				p.Health = Plugin.Singleton.Config.healthPercent;
			}
		}

		public void onLeave(LeftEventArgs ev)
		{
			if (EventHandlers.manager.Contains(ev.Player))
			{
				this.killmanager(ev.Player);
			}
		}

		public void onRoundEnd(RoundEndedEventArgs ev)
		{
			EventHandlers.manager.Clear();
		}

		public void onDeath(DiedEventArgs ev)
		{
			if (EventHandlers.manager.Contains(ev.Target))
			{
				this.killmanager(ev.Target);
			}
		}

		public void killmanager(Player p)
		{
			if (EventHandlers.manager.Contains(p))
			{
				EventHandlers.manager.Remove(p);
			}
			p.CustomInfo = null;
		}

		public static List<Player> manager = new List<Player>();
	}
}
