using System;
using System.Linq;
using Evernote.EDAM.Type;
using System.Collections.Generic;

namespace EverGTD
{
    public class AgendaCreateCommand : BaseCreateCommand, ICommand, IAgendaCreate
    {
        public AgendaCreateCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base("a+", gConfig.AgendaTagName, console, note, gConfig)
        {
        }
    }
}
