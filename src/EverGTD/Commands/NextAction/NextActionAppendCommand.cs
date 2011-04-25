using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

namespace EverGTD
{
    public class NextActionAppendCommand : BaseAppendCommand, INextActionAppend
    {
        public NextActionAppendCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base("na=", gConfig.NextActionTagName, console, note, gConfig)
        {
        }
    }
}
