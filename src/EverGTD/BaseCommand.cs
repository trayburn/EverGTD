using System;

namespace EverGTD
{
    public abstract class BaseCommand
    {
        protected IConsoleFacade console;
        protected IGTDConfiguration gConfig;
        protected ICachedNoteStore note;

        public BaseCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
        {
            this.console = console;
            this.gConfig = gConfig;
            this.note = note;
        }
    }
}
