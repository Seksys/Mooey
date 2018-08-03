using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooey.Core.Musical.Common
{
    public class TimeSignature
    {
        /// <summary>
        /// How many "beats" constitutes a bar. Time Signature: [X : Y] == [BeatsPerBar : BeatNoteValue]
        /// </summary>
        public int BeatsPerBar { set; get; }
        /// <summary>
        /// Note value that represents one "beat", typically a power of 2. Time Signature: [X : Y] == [BeatsPerBar : BeatNoteValue]
        /// </summary>
        public int BeatNoteValue { set; get; }
        /// <summary>
        /// Detected Time Signature Meter Type
        /// </summary>
        public TimeSignatureMeter MeterType
        {
            get
            {
                if (BeatsPerBar % 2 == 0) { if (BeatNoteValue % 2 == 0) { return TimeSignatureMeter.Simple; } }
                else if (BeatsPerBar % 3 == 0) { if (BeatNoteValue == 8) { return TimeSignatureMeter.Compound; } }
                return TimeSignatureMeter.Complex;
            }
        }

        public TimeSignature()
        {
            BeatsPerBar = 4;
            BeatNoteValue = 4;
        }
        public TimeSignature(int bpb, int bnv) : this()
        {
            BeatsPerBar = bpb;
            BeatNoteValue = bnv;
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}", BeatsPerBar, BeatNoteValue);
            //return base.ToString();
        }
    }
    public enum TimeSignatureMeter
    {
        Simple = 0, Compound = 1, Complex = 2
    }
}
