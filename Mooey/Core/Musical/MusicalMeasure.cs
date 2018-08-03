using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooey.Core.Musical
{
    public class MusicalMeasure
    {
        /*
        
            [0000 0000] ... [0000 0000] ... [0000 0000] ... [0000 0000]             
            
        */

        public int ID { set; get; }
        public string TextCommands { set; get; }
        public List<MusicalNote> Notes { set; get; }
        public MusicalMeasure(int id) { Notes = new List<MusicalNote>(); ID = id; }


    }

}
