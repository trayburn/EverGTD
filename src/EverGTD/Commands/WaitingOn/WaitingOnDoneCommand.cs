using System;

namespace EverGTD
{
    public class WaitingOnDoneCommand : BaseDoneCommand, IWaitingOnDone
    {
        public WaitingOnDoneCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base("w-", gConfig.WaitingOnTagName, console, note, gConfig)
        {
        }
    }
}
