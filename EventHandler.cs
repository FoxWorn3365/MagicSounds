using System;
using System.Collections.Generic;
using Exiled.API.Features;
using MagicSounds.Structures;
using MEC;
using AudioPlayer.API;
using static MagicSounds.CoroutinesHandler;

namespace MagicSounds
{
    internal class EventHandler
    {
        public void OnRoundStarted()
        {
            foreach (IAudio audio in Plugin.Instance.Config.RandomRepeatAudio)
            {
                CoroutineHandle coroutine = Timing.RunCoroutine(IntervalRandomAudio(Plugin.Instance.Config.MinimumRandomTime, Plugin.Instance.Config.MaximumRandomTime, audio));
                Coroutines?.Add(coroutine);
            }

            foreach (KeyValuePair<int, IAudio> audio in Plugin.Instance.Config.TimeAudio)
            {
                Timing.CallDelayed((float)audio.Key, () =>
                {
                    if (Round.IsStarted)
                    {
                        IAudio Audio = audio.Value;
                        AudioController.PlayAudioFromFile(Audio.Path, Audio.Loop, Audio.Volume, Audio.Channel, false, false, true, Audio.Bot);
                    }
                });
            }

            foreach (KeyValuePair<int, IAudio> audio in Plugin.Instance.Config.RepeatAudio)
            {
                CoroutineHandle coroutine = Timing.RunCoroutine(IntervalRegularAudio(audio.Key, audio.Value));
                Coroutines?.Add(coroutine);
            }
        }
        public void OnWaiting()
        {
            KillCoroutines();
        }
        public IEnumerator<float> IntervalRegularAudio(int Interval, IAudio Audio)
        {
            while (Round.IsStarted)
            {
                yield return Timing.WaitForSeconds(Interval);
                AudioController.PlayAudioFromFile(Audio.Path, Audio.Loop, Audio.Volume, Audio.Channel, false, false, true, Audio.Bot);
            }
        }
        public IEnumerator<float> IntervalRandomAudio(int From, int To, IAudio Audio)
        {
            while (Round.IsStarted)
            {
                yield return Timing.WaitForSeconds(new Random().Next(From, To));
                AudioController.PlayAudioFromFile(Audio.Path, Audio.Loop, Audio.Volume, Audio.Channel, false, false, true, Audio.Bot);
            }
        }
    }
}
