using System;
using System.Linq;
using EvernoteSharp;
using Evernote.EDAM.Type;

namespace EverGTD
{
    public class GTD : IGTD
    {
        private IStoreFactory factory;
        private IEvernoteConfiguration eConfig;
        private IGTDConfiguration gConfig;

        public GTD(IStoreFactory factory, IEvernoteConfiguration eConfig, IGTDConfiguration gConfig)
        {
            this.factory = factory;
            this.eConfig = eConfig;
            this.gConfig = gConfig;
        }

        public void Execute(string[] args)
        {
            var user = factory.CreateUserStore();
            user.Authenticate(eConfig.UserName, eConfig.Password);

            var note = factory.CreateNoteStore();
            var gtd = note.ListNotebooks().FirstOrDefault(m => m.Name == gConfig.NotebookName);

            if (gtd == null)
            {
                note.CreateNotebook(new Notebook
                    {
                        Name = gConfig.NotebookName
                    });
            }
        }
    }
}
