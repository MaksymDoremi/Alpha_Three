using Alpha_Three.src.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alpha_Three.src.Objects
{
    public class Track : IBaseClass
    {
        private int _id;
        private int _stationOriginID;
        private int _stationDestinationID;
        private int _trackLengthKm;

        public Track(int id, int stationOriginID, int stationDestinationID, int trackLengthKm)
        {
            ID = id;
            StationOriginID = stationOriginID;
            StationDestinationID = stationDestinationID;
            TrackLengthKm = trackLengthKm;
        }

        public int ID
        {
            get => _id;
            set => _id = value;
        }

        public int StationOriginID
        {
            get => _stationOriginID;
            set => _stationOriginID = value;
        }

        public int StationDestinationID
        {
            get => _stationDestinationID;
            set => _stationDestinationID = value;
        }

        public int TrackLengthKm
        {
            get => _trackLengthKm;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Track length must be greater than 0.");
                }
                _trackLengthKm = value;
            }
        }

        public override string ToString()
        {
            return $"ID: {ID}, Station Origin ID: {StationOriginID}, Station Destination ID: {StationDestinationID}, Track Length (km): {TrackLengthKm}";
        }
    }
}
