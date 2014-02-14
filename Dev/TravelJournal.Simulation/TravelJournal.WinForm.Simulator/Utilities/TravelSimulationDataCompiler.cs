using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TravelJournal.WinForm.Simulator.Forms;

namespace TravelJournal.WinForm.Simulator
{
    [DataContract]
    [KnownType(typeof(SimulationModelPoint))]
    public class SimulationModelPoint
    {
        [DataMember()]
        public PointLatLng Gps { get; set; }
        [DataMember()]
        public int PhotoGenNumber { get; set; }
        [DataMember()]
        public long CustomTimeInterval { get; set; }
    }

    public class TravelSimulationDataCompiler
    {
        private const double RATIO_KM_TO_GEO_DISTANCE = 100.0*60.0;
        private GaussianRandom gaussianRandom = new GaussianRandom();
        private Random uniformRandom = new Random();
        private double radius;

        public TravelSimulationDataCompiler(double radiusInKm)
        {
            this.radius = radiusInKm / RATIO_KM_TO_GEO_DISTANCE;
        }

        public TravelItineraryData Compile(TravelItineraryData rawData)
        {
            TravelItineraryData compiledData = new TravelItineraryData() { CameraRadius = rawData.CameraRadius, TimeIntervalPerAnchor = rawData.TimeIntervalPerAnchor };
            foreach (SimulationModelPoint anchor in rawData.Anchors)
            {
                int photoGenNumber=anchor.PhotoGenNumber;
                if (photoGenNumber > 1)
                {
                    long customTimeInterval = compiledData.TimeIntervalPerAnchor / photoGenNumber;
                    for (int i = 0; i < photoGenNumber; i++)
                    {
                        // Generate a random (centered) radius with sigma equals to the camera radius
                        double randomRadius = gaussianRandom.Random(radius);
                        // Generate a random angle (in radians) between 0 and pi  
                        double randomAngle = uniformRandom.NextDouble() * Math.PI;
                        // Create an offset point from the center point and the polar biais
                        SimulationModelPoint offsetPoint = CreateOffsetPoint(anchor, randomRadius, randomAngle);
                        offsetPoint.CustomTimeInterval = customTimeInterval;
                        // Add to compiled data
                        compiledData.Anchors.Add(offsetPoint);
                    }
                }
                else
                    compiledData.Anchors.Add(anchor);
            }
            return compiledData;
        }

        private SimulationModelPoint CreateOffsetPoint(SimulationModelPoint centerPoint, double r, double theta)
        {
            SimulationModelPoint offsetPoint = new SimulationModelPoint(){Gps=centerPoint.Gps};
            SimulationModelPoint testPoint = new SimulationModelPoint() { Gps = centerPoint.Gps };
            SizeLatLng deltaPoint = new SizeLatLng(r * Math.Cos(theta), r * Math.Sin(theta));
            offsetPoint.Gps = offsetPoint.Gps + deltaPoint;
            return offsetPoint;
        }


    }
}
