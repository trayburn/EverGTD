using System;

namespace EverGTD
{
    public class WaitingOnAppendCommand : BaseAppendCommand, IWaitingOnAppend
    {
        public WaitingOnAppendCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base("w=", gConfig.WaitingOnTagName, console, note, gConfig)
        {
        }
    }
}
