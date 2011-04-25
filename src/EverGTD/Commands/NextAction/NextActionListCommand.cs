using System;

namespace EverGTD
{
    public class NextActionListCommand : BaseListCommand, INextActionList
    {
        public NextActionListCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base("na?", gConfig.NextActionTagName, console, note, gConfig)
        {
        }

        public override void Execute(System.Collections.Generic.IEnumerable<string> parameters)
        {
            console.WriteLine("Next Actions");
            console.WriteLine("------------");
            base.Execute(parameters);
        }
    }
}
