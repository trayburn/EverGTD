using System;

namespace EverGTD
{
    public class NextActionDoneCommand : BaseDoneCommand, INextActionDoneCommand
    {
        public NextActionDoneCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base("na-", gConfig.NextActionTagName, console, note, gConfig)
        {
        }
    }
}
