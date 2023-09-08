using Exiled.API.Features;
using ServerHandler = Exiled.Events.Handlers;
using System;
using Exiled.API.Enums;

namespace MagicSounds
{
    public class Plugin : Plugin<Config>
    {
        public override string Prefix => "MagicSounds";
        public override string Name => "MagicSounds";
        public override string Author => "FoxWorn3365";
        public override Version Version { get; } = new(0, 1, 2);
        public override Version RequiredExiledVersion => new(8, 2, 0);
        public override PluginPriority Priority => PluginPriority.Default;
        public static Plugin Instance;
        internal EventHandler Handler;
        public override void OnEnabled()
        {
            Instance = this;
            CoroutinesHandler.Coroutines = new();
            Handler = new EventHandler();

            ServerHandler.Server.RoundStarted += Handler.OnRoundStarted;
            ServerHandler.Server.WaitingForPlayers += Handler.OnWaiting;

            Log.Debug("Events have been registered!");

            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Log.Debug("Disabling plugin..");

            ServerHandler.Server.RoundStarted -= Handler.OnRoundStarted;
            ServerHandler.Server.WaitingForPlayers -= Handler.OnWaiting;

            CoroutinesHandler.KillCoroutines();
            Instance = null!;

            base.OnDisabled();
        }
    }
}
