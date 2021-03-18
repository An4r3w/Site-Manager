using System;
using Exiled.API.Features;
using PlayerEvent = Exiled.Events.Handlers.Player;
using ServerEvent = Exiled.Events.Handlers.Server;

namespace Site_Manager
{
	internal class Plugin : Plugin<Config>
	{
		public override string Author { get; } = "An4r3w";

		public override string Name { get; } = "Site Manager";

		public override string Prefix { get; } = "Site Manager";

		public override Version Version { get; } = new Version(1, 0, 0);

		public override Version RequiredExiledVersion { get; } = new Version(2, 8, 0);

		internal EventHandlers EventHandlers { get; set; }

		public override void OnEnabled()
		{
			Plugin.Singleton = this;
			this.EventHandlers = new EventHandlers();
			PlayerEvent.ChangingRole += EventHandlers.onRoleChange;
			PlayerEvent.Died += EventHandlers.onDeath;
			PlayerEvent.Left += EventHandlers.onLeave;
			ServerEvent.RoundEnded += EventHandlers.onRoundEnd;
		}

		public override void OnDisabled()
		{
			PlayerEvent.ChangingRole -= EventHandlers.onRoleChange;
			PlayerEvent.Died -= EventHandlers.onDeath;
			PlayerEvent.Left -= EventHandlers.onLeave;
			ServerEvent.RoundEnded -= EventHandlers.onRoundEnd;
			this.EventHandlers = null;
		}

		public static Plugin Singleton;
	}
}
