using System;

namespace EverGTD
{
    public class NextActionDoneCommand : BaseDoneCommand, INextActionDone
    {
        public NextActionDoneCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base("na-", gConfig.NextActionTagName, console, note, gConfig)
        {
        }
    }
}
