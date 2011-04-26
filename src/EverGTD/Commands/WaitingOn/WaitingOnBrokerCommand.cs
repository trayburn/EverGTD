using System;

namespace EverGTD
{
    public class WaitingOnBrokerCommand : BaseBrokerCommand<IWaitingOnList, IWaitingOnCreate, IWaitingOnAppend, IWaitingOnTag, IWaitingOnDone, IWaitingOnDelete>
    {
        public WaitingOnBrokerCommand(IWaitingOnList list, IWaitingOnCreate create, IWaitingOnAppend append, IWaitingOnTag tag, IWaitingOnDone done, IWaitingOnDelete delete, IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base("wait", gConfig.WaitingOnTagName, list, create, append, tag, done, delete, console, note, gConfig)
        {
        }
    }
}
