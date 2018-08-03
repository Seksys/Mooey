using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mooey.Core.Musical.Common
{
    public class RepeatDescriptor
    {
        public bool IsStart { set; get; }
        public bool IsEnd { set; get; }
        public bool IsAltEnding { set; get; }

        /*
        
            Idea here:
            We mark the IsStart and prep the state for loading in the rest of the repeat info
            if we pass an IsAltEnding, increment endingspassed
            We read total count and set the inrepeat flag in the playback
            firstly decrement the running repeatsleft
            if repeatsleft <= 0 do not jump else jump back to the last IsStart descriptor 
            if we encounter an AltEndingID >= endingspassed, 
                if altending is complex set flags to activate altPassesLeft, set it, else jump to next AltEnding
            if we encounter
            
        */

        /// <summary>
        /// Number of times to repeat.
        /// </summary>
        public int TotalCount { set; get; }
        /// <summary>
        /// The lowest id of the alternate ending. Lowest due to complex endings, such as: 1,2,3,4. ID == 1, AltEndingsTotal == 4
        /// </summary>
        public int AltEndingID { set; get; }
        /// <summary>
        /// Total number of alt endings in this segment
        /// </summary>
        public int AltEndingsTotal { set; get; }
    }
}
