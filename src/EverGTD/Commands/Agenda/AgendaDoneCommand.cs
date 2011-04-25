using System;

namespace EverGTD
{
    public class AgendaDoneCommand : BaseDoneCommand, IAgendaDone
    {
        public AgendaDoneCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base("a-", gConfig.AgendaTagName, console, note, gConfig)
        {
        }
    }
}
