using System;
using System.Linq;
using Evernote.EDAM.Type;
using System.Collections.Generic;

namespace EverGTD
{
    public class NextActionCreateCommand : BaseCreateCommand
    {
        public NextActionCreateCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base("na+", gConfig.NextActionTagName, console, note, gConfig)
        {
        }
    }
}
