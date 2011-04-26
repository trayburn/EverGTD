using System;
using System.Linq;
using System.Collections.Generic;

namespace EverGTD
{
    public class DayCommand : BaseListCommand
    {
        public DayCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base("day", gConfig.GetTagForToday(), console, note, gConfig)
        {
        }

        public override void Execute(IEnumerable<string> parameters)
        {
            string msg = String.Format("Items for {0}", gConfig.GetTagForToday());
            console.WriteLine(msg);
            console.WriteLine(new string(Enumerable.Repeat('-', msg.Length).ToArray()));
            base.Execute(parameters);
        }
    }
}
