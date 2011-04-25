using System;

namespace EverGTD
{
    public class AgendaAppendCommand : BaseAppendCommand, IAgendaAppend
    {
        public AgendaAppendCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base("a=", gConfig.AgendaTagName, console, note, gConfig)
        {
        }
    }
}
