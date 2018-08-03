using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooey.Core.Musical
{
    public class MusicalScore
    {
        public List<MusicalTrack> Tracks { set; get; }

        public string Title { set; get; }
        public string Artist { set; get; }
        public string Composer { set; get; }
        public double TempoMultiplier { set; get; }
        public int OctaveOffset { set; get; }

        public MusicalScore(string title = "No Title", string artist = "Unknown", string composer = "Unknown Composer") {

            Title = title;
            Artist = artist;
            Composer = composer;

            TempoMultiplier = 1.0;
            OctaveOffset = 0;

            Tracks = new List<MusicalTrack>();

        }
    }
}
