using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MEC;
using Exiled.API.Features;

namespace MagicSounds
{
    public static class CoroutinesHandler
    {
        public static List<CoroutineHandle> Coroutines;
        public static void KillCoroutines()
        {
            Log.Debug("Killing coroutines");
            if (Coroutines == null) return;
            foreach (CoroutineHandle coroutine in Coroutines)
            {
                if (coroutine.IsRunning) Timing.KillCoroutines(coroutine);
                Log.Debug("Killed a coroutine successfully!");
            }
            Coroutines.Clear();
            Log.Debug("Killed all coroutines");
        }
    }
}
