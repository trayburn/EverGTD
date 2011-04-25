using System;
using System.Linq;
using Evernote.EDAM.Type;
using System.Collections.Generic;
using System.Xml.Linq;

namespace EverGTD
{
    public class AgendaBrokerCommand : BaseBrokerCommand<IAgendaList, IAgendaCreate, IAgendaAppend, IAgendaDone, IAgendaDelete>
    {
        public AgendaBrokerCommand(IAgendaList list, IAgendaCreate create, IAgendaAppend append, IAgendaDone done, IAgendaDelete delete, IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base("agenda", gConfig.AgendaTagName, list, create, append, done, delete, console, note, gConfig)
        {
            
        }
    }
}