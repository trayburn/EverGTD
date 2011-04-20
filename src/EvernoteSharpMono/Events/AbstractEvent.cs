using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace EvernoteSharp.Events
{
    internal abstract class AbstractEvent
    {
        public object Sender { get; set;}
    }
}
