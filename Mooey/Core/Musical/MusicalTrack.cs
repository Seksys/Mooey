using Mooey.Core.Musical.Common;
using System.Collections.Generic;

namespace Mooey.Core.Musical
{
    public class MusicalTrack
    {
        public List<MusicalMeasure> Measures { set; get; }
        /*
            The idea here is:
                at loading populate the all the Maps using [Measure.ID] as a key.
                then in the playback loop, check if a key exists at any measure change, 
                if so apply the correct entries data to the playback descriptor.
                by using this fashion, if you start mid-playback, we can back scan for the current state of events.
                and now scores can be started from any point inside and will have the correct event information.
            
        */
        /// <summary>
        /// Measure.ID == key
        /// </summary>
        public IDictionary<int,TimeSignature> TimeSigMap { set; get; }
        /// <summary>
        /// Measure.ID == key
        /// </summary>
        public IDictionary<int,double> TempoMap { set; get; }
        /// <summary>
        /// Measure.ID == key
        /// </summary>
        public IDictionary<int, RepeatDescriptor> RepeatMap { set; get; }
        /// <summary>
        /// Measure.ID == key
        /// </summary>
        public IDictionary<int, int> OctaveMap { set; get; }
        public string TrackName { set; get; }
        public double TempoMultiplier { set; get; }
        public int OctaveOffset { set; get; }
        //public bool HasTempoMap { get { if (RepeatMap.Count != 0) { return true; } else { return false; } } }
        public bool HasRepeatMap { get { if (RepeatMap.Count != 0) { return true; } else { return false; } } }
        public bool HasOctaveMap { get { if (OctaveMap.Count != 0) { return true; } else { return false; } } }


        public MusicalTrack(string trackName) {

            TrackName = trackName;
            TempoMultiplier = 1.0;
            OctaveOffset = 0;

            Measures = new List<MusicalMeasure>();

            TimeSigMap = new Dictionary<int, TimeSignature>();
            TempoMap = new Dictionary<int, double>();
            RepeatMap = new Dictionary<int, RepeatDescriptor>();
            OctaveMap = new Dictionary<int, int>();

        }

    }

}
