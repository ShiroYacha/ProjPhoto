using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelJournal.PCL.DataService;

namespace TravelJournal.PCL.BusinessLogic
{
    public abstract class State
    {
        public abstract void Execute(Processor processor);
    }

    public class OriginalState : State
    {
        public override async void Execute(Processor processor)
        {
            GpsPosition userPosition = await processor.WebService.GetUserPosition();

            if (userPosition.City == processor.DataManager.GetUserInfo().OriginalPosition.City)
            {
                processor.SetState(new OriginalState());
                //processor.Execute();
            }
            else
            {
                processor.TourRoutePoints.Add(userPosition.GpsPoint);
                processor.SetState(new PilotState());
            }

        }
    }
    public class PilotState : State
    {
        public override async void Execute(Processor processor)
        {
            GpsPosition userPosition = await processor.WebService.GetUserPosition();
            if ((processor.PhotoManager.FoundRawPhoto(processor.Album.TimeTag, processor.PhotoHandler)))
            {
                processor.SetState(new PhotoHandlerState());
            }
            else
            {
                if (userPosition.City == processor.DataManager.GetUserInfo().OriginalPosition.City)
                {
                    processor.SetState(new OriginalState());
                    //processor.Execute();
                }
                else
                {
                    processor.TourRoutePoints.Add(userPosition.GpsPoint);
                    processor.SetState(new PilotState());
                }
            }
        }

    }
    public class PhotoHandlerState : State
    {
        public override async void Execute(Processor processor)
        {
            GpsPosition userPosition = await processor.WebService.GetUserPosition();
            if (userPosition.City == processor.DataManager.GetUserInfo().OriginalPosition.City)
            {
                if ((processor.PhotoManager.FoundRawPhoto(processor.Album.TimeTag, processor.PhotoHandler)) == true)
                {
                    processor.Album = processor.DataManager.GetAlbum("test");
                    processor.PhotoManager.FoundRawPhoto(processor.Album.TimeTag, processor.PhotoHandler);
                }
                else
                {
                    processor.SetState(new AlbumGeneratorState());
                }
            }
            else
            {
                processor.TourRoutePoints.Add(userPosition.GpsPoint);
                if ((processor.PhotoManager.FoundRawPhoto(processor.Album.TimeTag, processor.PhotoHandler)) == true)
                {
                    processor.Album = processor.DataManager.GetAlbum("test");
                    processor.PhotoManager.FoundRawPhoto(processor.Album.TimeTag, processor.PhotoHandler);
                    processor.SetState(new PhotoHandlerState());
                }
                else
                {
                    processor.SetState(new PhotoHandlerState());
                }
            }
        }
    }
    public class AlbumGeneratorState : State
    {
        public override async void Execute(Processor processor)
        {
            foreach (Photo p in processor.Album.PhotoList)
            {
                if (processor.TouristCity.Contains(p.Position.City) == false)
                    processor.TouristCity.Add(p.Position.City);
            }
            foreach (GpsPoint p in processor.TourRoutePoints)
            {
               GpsPosition TourRoutePosition =  await processor.WebService.GetGeoposition(p);
               if (processor.TouristCity.Contains(TourRoutePosition.City) == false)
                   processor.TourRoutePoints.Remove(p);
            }
        }
    }

}
