using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TravelJournal.PCL.DataService;

namespace TravelJournal.PCL.BusinessLogic
{
   public class Transition
    {
       
      public Transition() { }


        
        public async void Transform(Processor processor)
        {
            if (processor.State == null)
            {
                return;
            }
            string stateType = processor.GetType().Name;
            processor.UserPosition = await processor.WebService.GetUserPosition();
            bool haveNewPhoto = processor.PhotoManager.FoundRawPhoto(processor.Album.TimeTag, processor.PhotoHandler);
            if (processor.UserPosition.City == processor.DataManager.UserInfo.OriginalPosition.City)
            {
                if (stateType.ToUpper() == "PILOTSTATE")
                {
                    if(haveNewPhoto == false){
                    processor.State.ChangeState(processor,
                                new OriginalState());}
                    else{processor.State.ChangeState(processor,new PhotoHandlerState());}
                }
                if (stateType.ToUpper() == "PHOTOHANDLERSTATE"&& (!haveNewPhoto))
                {
                    processor.State.ChangeState(processor, new AlbumGeneratorState());
                }
                if(stateType.ToUpper() == "ALBUMGENERATORSTATE"&&processor.AlbumCompleted)
                {
                    processor.State.ChangeState(processor, new OriginalState());
                }
                
            }
            else
            {
                if (stateType.ToUpper() == "ORIGINALSTATE")
                {
                    processor.State.ChangeState(processor, new PilotState());
                }
                if (stateType.ToUpper() == "PILOTSTATE")
                {
                    if (haveNewPhoto == true)
                    {
                        processor.State.ChangeState(processor, new PhotoHandlerState());
                    }     
                }
               
            }
        }
    }
}
