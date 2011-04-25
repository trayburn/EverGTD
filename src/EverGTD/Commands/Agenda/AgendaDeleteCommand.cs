using System;

namespace EverGTD
{
    public class AgendaDeleteCommand : BaseDeleteCommand, IAgendaDelete
    {
        public AgendaDeleteCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base("a--", gConfig.AgendaTagName, console, note, gConfig)
        {
        }
    }
}
