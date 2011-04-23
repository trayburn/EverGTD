using System;
using System.Linq;
using EvernoteSharp;
using Evernote.EDAM.Type;
using System.Collections.Generic;
using Evernote.EDAM.NoteStore;

namespace EverGTD
{
    public class Gtd : IGtd
    {
        private IStoreFactory factory;
        private IEvernoteConfiguration eConfig;
        private ICommand[] commands;

        public Gtd(IStoreFactory factory, IEvernoteConfiguration eConfig, ICommand[] commands)
        {
            this.factory = factory;
            this.eConfig = eConfig;
            this.commands = commands;
        }

        public void Execute(string[] args)
        {
            var user = factory.CreateUserStore();
            user.Authenticate(eConfig.UserName, eConfig.Password);

            var note = factory.CreateNoteStore();

            string cmdName;
            if ((args.Count() > 0) == false) cmdName = "today";
            else cmdName = args[0].Trim().ToLower();
            var rest = args.Skip(1);

            commands.First(m => m.Name == cmdName).Execute(rest);
        }
    }
}
