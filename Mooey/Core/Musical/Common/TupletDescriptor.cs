using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooey.Core.Musical.Common
{
    public class TupletDescriptor
    {
        /// <summary>
        /// Number of notes to fit into BeatsPerNotes.
        /// </summary>
        public int NotesPerBeat { set; get; }
        /// <summary>
        /// Number of beats to fill.
        /// </summary>
        public int BeatsPerNotes { set; get; }

        public TupletDescriptor(int npb, int bpn)
        {
            NotesPerBeat = npb;
            NotesPerBeat = bpn;
        }
    }
}
