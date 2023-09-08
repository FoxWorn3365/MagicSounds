using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSounds.Structures
{
    public interface IAudio
    {
        string Path { get; set; }
        bool Loop { get; set; }
        int Volume { get; set; }
        VoiceChat.VoiceChatChannel Channel { get; set; }
        int Bot { get; set; }

    }
}
