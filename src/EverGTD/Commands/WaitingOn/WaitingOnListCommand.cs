using System;
using System.Collections.Generic;

namespace EverGTD
{
    public class WaitingOnListCommand : BaseListCommand, IWaitingOnList
    {
        public WaitingOnListCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base("w?", gConfig.WaitingOnTagName, console, note, gConfig)
        {
        }

        public override void Execute(IEnumerable<string> parameters)
        {
            console.WriteLine("Waiting On");
            console.WriteLine("----------");
            base.Execute(parameters);
        }
    }
}
