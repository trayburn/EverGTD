using System;

namespace EverGTD
{
    public class AgendaTagCommand : BaseTagCommand, IAgendaTag
    {
        public AgendaTagCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base("a==", gConfig.AgendaTagName, console, note, gConfig)
        {
        }
    }
}
