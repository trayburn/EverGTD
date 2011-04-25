using System;

namespace EverGTD
{
    public class NextActionTagCommand : BaseTagCommand, INextActionTag
    {
        public NextActionTagCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base("na==", gConfig.NextActionTagName, console, note, gConfig)
        {
        }
    }
}
