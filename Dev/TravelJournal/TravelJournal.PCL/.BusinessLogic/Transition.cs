using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelJournal.PCL.DataService;

namespace TravelJournal.PCL.BusinessLogic
{
    public class Transition
    {
        public async void Transform(Processor processor)
        {
            if (processor.State == null)
            {
                throw new MissingMemberException("State not loaded");
            }
            string stateType = processor.GetType().Name;
            processor.UserPosition = await processor.WebService.GetUserPosition();
            bool haveNewPhoto = processor.PhotoManager.CheckRawPhoto(processor.Album.TimeTag);
            if (processor.UserPosition.City == processor.DataManager.UserInfo.OriginalPosition.City)
            {
                if (stateType.ToUpper() == "PILOTSTATE")
                {
                    if (haveNewPhoto == false)
                    {
                        processor.State = new OriginalState();
                    }
                    else
                    {
                        processor.State = new PhotoHandlerState();
                    }
                }
                if (stateType.ToUpper() == "PHOTOHANDLERSTATE" && (!haveNewPhoto))
                {
                    processor.State = new AlbumGeneratorState();
                }
                if (stateType.ToUpper() == "ALBUMGENERATORSTATE" && processor.AlbumCompleted)
                {
                    processor.State = new OriginalState();
                }

            }
            else
            {
                if (stateType.ToUpper() == "ORIGINALSTATE")
                {
                    if (haveNewPhoto)
                    {
                        processor.State = new PhotoHandlerState();
                    }
                    else
                    {
                        processor.State = new PilotState();
                    }
                }
                if (stateType.ToUpper() == "PILOTSTATE")
                {
                    if (haveNewPhoto)
                    {
                        processor.State = new PhotoHandlerState();
                    }
                }

            }
        }
    }
}
