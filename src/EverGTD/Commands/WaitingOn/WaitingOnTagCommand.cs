using System;

namespace EverGTD
{
    public class WaitingOnTagCommand : BaseTagCommand, IWaitingOnTag
    {
        public WaitingOnTagCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base("w==", gConfig.WaitingOnTagName, console, note, gConfig)
        {
        }
    }
}
