using System;

namespace EverGTD
{
    public class NextActionBrokerCommand : BaseBrokerCommand<INextActionList,INextActionCreate,INextActionAppend,INextActionTag,INextActionDone,INextActionDelete>
    {
        public NextActionBrokerCommand(INextActionList list, INextActionCreate create, INextActionAppend append, INextActionTag tag, INextActionDone done, INextActionDelete delete, IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base("na", gConfig.NextActionTagName, list, create, append, tag, done, delete, console, note, gConfig)
        {
        }
    }
}
