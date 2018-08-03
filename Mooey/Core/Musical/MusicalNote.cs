using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooey.Core.Musical
{
    public class MusicalNote
    {
        /*

            Measure == Time Sig Long Rest
            0   Whole
            1   Half
            2   Quarter
            3   Eighth
            4   Sixteenth
            5   Thirtysecondth
            6   Sixtyfourth
            7   One-hundred-twenty-eighth

        */

        /*

        Note <Int> Map:
         Reserved   ...   Tuplet    ...   Duration  ... Note Pitch
        [0000 0000] ... [0000 0000] ... [0000 0000] ... [0000 0000]
                         |||| ||||  ...  |||| ||||  ...  |||| ^^^^--Pitch        [0 - F] == [R C C# D D# E F F# G G# A A# B]
                         |||| ||||  ...  |||| ||||  ...  ^^^^-------Octave       [0 - F] == [-2 to 13]
                         |||| ||||  ...  |||| ||||              
                         |||| ||||  ...  |||| ^^^^------------------Duration
                         |||| ||||  ...  |||^-----------------------Is Dotted 
                         |||| ||||  ...  ||^------------------------Is Carry
                         |||| ||||  ...  |^-------------------------Is Grace
                         |||| ||||  ...  ^--------------------------Is Tuplet
                         |||| ||||  
                         |||| ^^^^----------------------------------X notes in the time of
                         ^^^^---------------------------------------Y notes
        */

        /// <summary>
        /// Represents the real binary encoded Note data.
        /// </summary>
        public uint Binary { private set; get; }
        public string Pitch {
            get {
                uint mPitch = 255;
                uint result = Binary & mPitch;
                uint p = result & 0x0F;
                uint o = (result & 0xF0) >> 4;

                string so = (o - 2).ToString();

                return string.Format("{0}{1}|", ConvertPitchToString(p), so.PadLeft(2,' '));
            }
        }
        public string Duration {
            get
            {
                uint mask = 255 << 8;
                uint result = (Binary & mask) >> 8;
                uint d = result & 0x0F; //0000 1111
                uint o = result & 0x10; //0001 0000
                uint c = result & 0x20; //0010 0000
                uint g = result & 0x40; //0100 0000
                uint t = result & 0x80; //1000 0000

                uint tmask = 255 << 16;
                uint tresult = (Binary & tmask) >> 16;
                uint x = result & 0x0F; //0000 1111
                uint y = (result & 0xF0) >> 4; //1111 0000

                string sd = ConvertDurationToString(d);
                string so = (o > 0) ? "." : "-";
                string sc = (c > 0) ? "u" : "-";
                string sg = (g > 0) ? "g" : "-";
                string st = (t > 0) ? "t" : "-";

                if (t > 0) { return string.Format("{0}{1}|{2}{3}{4}|{5}:{6}|", so, sd, sc, sg, st, x, y); }
                else { return string.Format("{0}{1}|{2}{3}{4}|", so, sd, sc, sg, st); }


            }
        }

        public string AsBinStr() { return Convert.ToString(Binary, 2).PadLeft(32, '0'); }
        public string AsEncoded() { return Pitch + Duration; }

        public MusicalNote()
        {
            ImportToBinary(0, 0, 0, false, false, false, false, 0, 0);
        }

        public MusicalNote(int pitch, int octave, int duration, bool dotted, bool carry, bool grace, bool tuplet, int tupX, int tupY)
        {
            ImportToBinary(pitch, octave, duration, dotted, carry, grace, tuplet, tupX, tupY);
        }

        public bool ImportToBinary(int pitch, int octave, int duration, bool dotted, bool carry, bool grace, bool tuplet, int tupX, int tupY) {

            uint mPitch = 255;
            uint mDuration = mPitch << 8;
            uint mTuplet = mDuration << 8;
            uint mReserved = mTuplet << 8;

            uint vPitch     = BuildPitch(pitch, octave);
            uint vDuration  = BuildDuration(duration, dotted, carry, grace, tuplet);
            uint vTuplet    = BuildTuplet(tupX, tupY);
            uint vReserved  = 0;

            uint result = vPitch | vDuration | vTuplet | vReserved;

            string binary = Convert.ToString(result, 2).PadLeft(32, '0');

            Binary = result;
            return true;
        }

        private uint BuildPitch(int pitch, int octave) {
            uint result = (uint)pitch;
            result |= ((uint)octave << 4);

            return result;
        }
        private uint BuildDuration(int duration, bool dotted, bool carry, bool grace, bool tuplet)
        {
            uint result = (uint)duration;

            if (dotted) { result |= (0x1 << 4); }
            if (carry) { result |= (0x1 << 5); }
            if (grace) { result |= (0x1 << 6); }
            if (tuplet) { result |= (0x1 << 7); }

            return result << 8;
        }
        private uint BuildTuplet(int tupX, int tupY)
        {
            uint result = (uint)tupX;
            result |= ((uint)tupY << 4);

            return result << 16;
        }


        private string ConvertPitchToString(uint pitch)
        {
            string sp = "";
            switch (pitch)
            {
                case 12: sp = "B-"; break;
                case 11: sp = "A#"; break;
                case 10: sp = "A-"; break;
                case 9: sp = "G#"; break;
                case 8: sp = "G-"; break;
                case 7: sp = "F#"; break;
                case 6: sp = "F-"; break;
                case 5: sp = "E-"; break;
                case 4: sp = "D#"; break;
                case 3: sp = "D-"; break;
                case 2: sp = "C#"; break;
                case 1: sp = "C-"; break;
                default: sp = "R-"; break;
            }
            return sp;
        }
        private string ConvertDurationToString(uint duration)
        {
            string sp = "";
            switch (duration)
            {
                case 7:  sp = "128"; break;
                case 6:  sp = "064"; break;
                case 5:  sp = "032"; break;
                case 4:  sp = "016"; break;
                case 3:  sp = "008"; break;
                case 2:  sp = "004"; break;
                case 1:  sp = "002"; break;
                case 0:  sp = "001"; break;
                default: sp = "000"; break;
            }
            return sp;
        }
    }



}
