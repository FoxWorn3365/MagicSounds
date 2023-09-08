using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSounds.Structures
{
    public class Audio : IAudio
    {
        public int Volume { get; set; } = 100;
        public VoiceChat.VoiceChatChannel Channel { get; set; } = VoiceChat.VoiceChatChannel.Intercom;
        public int Bot { get; set; } = 99;
        public string Path { get; set; } = "/path/to/dir/audoo.ogg";
        public bool Loop { get; set; } = false;
    }
}
