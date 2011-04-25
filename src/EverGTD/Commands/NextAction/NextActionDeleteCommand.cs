using System;

namespace EverGTD
{
    public class NextActionDeleteCommand : BaseDeleteCommand, INextActionDelete
    {
        public NextActionDeleteCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base("na--", gConfig.NextActionTagName, console, note, gConfig)
        {
        }
    }
}
