using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Evernote.EDAM.UserStore;

namespace EvernoteSharp.Events
{
    internal class AuthenticationEvent : AbstractEvent
    {
        public AuthenticationResult AuthenticationResult { get; set; }
    }
}
