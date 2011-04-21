using System;
using System.Linq;
using EvernoteSharp;
using Evernote.EDAM.Type;
using System.Collections.Generic;

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

            Setup(note);
        }

        private void Setup(INoteStore note)
        {
            var gtd = note.ListNotebooks().FirstOrDefault(m => m.Name == gConfig.NotebookName);

            if (gtd == null)
            {
                Console.WriteLine("Creating Notebook");
                note.CreateNotebook(new Notebook
                    {
                        Name = gConfig.NotebookName
                    });
            }

            var nextAct = CreateTagIfNonExistant(note, gConfig.NextActionTagName);
            var waitingOn = CreateTagIfNonExistant(note, gConfig.WaitingOnTagName);
            var tickler = CreateTagIfNonExistant(note, gConfig.TicklerTagName);
            var days = CreateTagIfNonExistant(note, gConfig.TicklerDaysSubTagName, tickler.Guid);
            var months = CreateTagIfNonExistant(note, gConfig.TicklerMonthsSubTagName, tickler.Guid);

            for (int day = 1; day < 32; day++)
            {
                CreateTagIfNonExistant(note, string.Format("Day {0:00}", day), days.Guid);
            }

            var jan1 = DateTime.Parse("1/1/2000");
            for (int month = 0; month < 12; month++)
            {
                var dt = jan1.AddMonths(month);
                CreateTagIfNonExistant(note, string.Format("{0:00}-{1:MMM}", month + 1, dt), months.Guid);
            }
        }

        private Tag CreateTagIfNonExistant(INoteStore note, string name, string parent = null)
        {
            if (AllTags(note).Any(m => m.Name == name) == false)
            {
                Console.WriteLine("Creating Tag : {0}", name);
                Tag newTag = new Tag { Name = name };
                if (parent != null) newTag.ParentGuid = parent;
                newTag = note.CreateTag(newTag);
                allTags.Add(newTag);
                return newTag;
            }
            return AllTags(note).First(m => m.Name == name);
        }

        private IList<Tag> allTags;
        private IList<Tag> AllTags(INoteStore note)
        {
            if (allTags == null)
                allTags = note.ListTags();
            return allTags;
        }
    }
}
