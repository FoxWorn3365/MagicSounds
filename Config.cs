using Exiled.API.Interfaces;
using MagicSounds.Structures;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicSounds
{
    public class Config : IConfig
    {
        [Description("Il plugin è abilitato?")]
        public bool IsEnabled { get; set; } = true;
        [Description("Modalità debug")]
        public bool Debug { get; set; } = false;
        [Description("Tempo minimo in secondi tra un audio random ed un altro")]
        public int MinimumRandomTime { get; set; } = 500;
        [Description("Tempo massimo in secondi tra un audio random ed un altro")]
        public int MaximumRandomTime { get; set; } = 10;
        [Description("Lista di audio randomici, ne verrà scelto uno a caso tra questi nell'intervallo sopra specificato")]
        public List<IAudio> RandomRepeatAudio { get; set; } = new()
        {
            new Audio()
        };
        [Description("Lista di audio che vengono riprodotti ogni n secondi")]
        public Dictionary<int, IAudio> RepeatAudio { get; set; } = new()
        {
            { 10, new Audio() }
        };
        [Description("Lista di audio che vengono riprodotti dopo n secondi dall'inizio")]
        public Dictionary<int, IAudio> TimeAudio { get; set; } = new()
        {
            {25, new Audio() }
        };
    }
}
