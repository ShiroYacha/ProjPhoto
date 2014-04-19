using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using TravelJournal.PCL.DataService;

namespace TravelJournal.PCL.BusinessLogic
{
    [DataContract]
    [KnownType(typeof(OriginalState))]
    [KnownType(typeof(PilotState))]
    [KnownType(typeof(PhotoHandlerState))]
    [KnownType(typeof(AlbumGeneratorState))]
    public abstract class State
    {
        public abstract void Execute(Processor processor);
    }
    public class OriginalState : State
    {
        public override void Execute(Processor processor)
        {

        }
    }
    public class PilotState : State
    {
        public override void Execute(Processor processor)
        {
            processor.TourRoutePoints.Add(processor.UserPosition);
        }
    }
    public class PhotoHandlerState : State
    {
        public override void Execute(Processor processor)
        {
            processor.TourRoutePoints.Add(processor.UserPosition);
            if(processor.PhotoManager.CheckRawPhoto(processor.Album.TimeTag)) 
                processor.PhotoManager.ProceedRawPhoto(processor.Album.TimeTag, processor.PhotoHandler);
        }
    }
    public class AlbumGeneratorState : State
    {
        public override async void Execute(Processor processor)
        {
            foreach (Photo p in processor.Album.PhotoList)
            {
                if (!processor.TouristCity.Contains(p.Position.City))
                    processor.TouristCity.Add(p.Position.City);
            }
            foreach (GpsPosition p in new List<GpsPosition>(processor.TourRoutePoints))
            {
                if (!processor.TouristCity.Contains(p.City))
                    processor.TourRoutePoints.Remove(p);
            }
            processor.AlbumCompleted = true;
        }
    }
}
