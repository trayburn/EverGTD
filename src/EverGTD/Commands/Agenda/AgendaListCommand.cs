using System;
using Evernote.EDAM.Type;
using System.Collections.Generic;

namespace EverGTD
{
    public class AgendaListCommand : BaseListCommand, IAgendaList
    {
        public AgendaListCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base("a?", gConfig.AgendaTagName, console, note, gConfig)
        {
        }

        public override void Execute(IEnumerable<string> parameters)
        {
            console.WriteLine("Agendas");
            console.WriteLine("-------");
            base.Execute(parameters);
        }
    }
}
