using System;

namespace EverGTD
{
    public class WaitingOnDeleteCommand : BaseDeleteCommand, IWaitingOnDelete
    {
        public WaitingOnDeleteCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base("w--", gConfig.WaitingOnTagName, console, note, gConfig)
        {
        }

    }
}
