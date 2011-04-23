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
        private IGTDConfiguration gConfig;
        private IConsoleFacade console;

        public Gtd(IStoreFactory factory, IConsoleFacade console, IEvernoteConfiguration eConfig, IGTDConfiguration gConfig)
        {
            this.factory = factory;
            this.eConfig = eConfig;
            this.gConfig = gConfig;
            this.console = console;
        }

        public void Execute(string[] args)
        {
            var user = factory.CreateUserStore();
            user.Authenticate(eConfig.UserName, eConfig.Password);

            var note = factory.CreateNoteStore();

            string cmd;
            if ((args.Count() > 0) == false) cmd = "today";
            else cmd = args[0].Trim().ToLower();

            switch (cmd)
            {
                case "setup":
                    Setup(note);
                    break;
                case "today":
                    Today(note);
                    break;
                case "na":
                    NextAction(note, args.Skip(1));
                    break;
                case "import":
                    Import(note);
                    break;
            }
        }

        private void Import(INoteStore note)
        {
            var notes = AllNotesForToday(note);
            var tagName = string.Format("Day {0:00}", DateTime.Now.Day);
            var naGuid = AllTags(note).First(m => m.Name == gConfig.NextActionTagName).Guid;
            var importantGuid = AllTags(note).First(m => m.Name == gConfig.ImportantTagName).Guid;
            var tagGuid = AllTags(note).First(m => m.Name == tagName).Guid;

            foreach (var lNote in notes)
            {
                lNote.TagGuids.Remove(tagGuid);
                lNote.TagGuids.Add(naGuid);
                lNote.TagGuids.Add(importantGuid);
                lNote.Title = "@" + tagName + " > " + lNote.Title;
                note.UpdateNote(lNote);
            }

        }
        private void NextAction(INoteStore note, IEnumerable<string> args)
        {
            var title = args.First();
            var tags = args.Skip(1).ToList();
            tags.Add(gConfig.NextActionTagName);

            note.CreateNote(new Note() { Title = title, TagNames = tags });
        }
        private void Today(INoteStore note)
        {
            var todayNotes = AllNotesForToday(note);
            if (todayNotes.Count > 0) OutputTodayNotes(note, todayNotes);

            var nextAct = AllTags(note).FirstOrDefault(m => m.Name == gConfig.NextActionTagName);

            var filter = new NoteFilter()
            {
                TagGuids = new List<string>() { nextAct.Guid }
            };

            var nextActionNotes = note.FindNotes(filter, 0, Evernote.EDAM.Limits.Constants.EDAM_USER_NOTES_MAX);
            if (nextActionNotes.Notes.Count > 0) OutputNextActions(note, nextActionNotes);
        }

        private void OutputTodayNotes(INoteStore note, IList<Note> notes)
        {
            console.WriteLine("Today");
            console.WriteLine("-----");
            int count = 0;
            foreach (var lNote in notes.OrderBy(m => m.Title))
            {
                count++;
                var tags = note.GetNoteTagNames(lNote.Guid);
                if (tags != null && tags.Contains(gConfig.ImportantTagName))
                    console.ForegroundColor = ConsoleColor.Yellow;
                console.WriteLine("{0}> {1}", count, lNote.Title);
                console.WriteLine();
                console.ResetColor();
            }
        }

        private void OutputNextActions(INoteStore note, NoteList notes)
        {
            console.WriteLine("Next Actions");
            console.WriteLine("------------");
            int count = 0;
            foreach (var lNote in notes.Notes.OrderBy(m => m.Title))
            {
                count++;
                var tags = note.GetNoteTagNames(lNote.Guid);
                if (tags != null && tags.Contains(gConfig.ImportantTagName))
                    console.ForegroundColor = ConsoleColor.Yellow;
                console.WriteLine("{0}> {1}", count, lNote.Title);
                console.ResetColor();
            }
        }

        private void Setup(INoteStore note)
        {
            var gtd = note.ListNotebooks().FirstOrDefault(m => m.Name == gConfig.NotebookName);

            if (gtd == null)
            {
                console.WriteLine("Creating Notebook");
                note.CreateNotebook(new Notebook
                    {
                        Name = gConfig.NotebookName
                    });
            }

            var nextAct = CreateTagIfNeeded(note, gConfig.NextActionTagName);
            var waitingOn = CreateTagIfNeeded(note, gConfig.WaitingOnTagName);
            var someday = CreateTagIfNeeded(note, gConfig.SomedayTagName);
            var tickler = CreateTagIfNeeded(note, gConfig.TicklerTagName);
            var days = CreateTagIfNeeded(note, gConfig.TicklerDaysSubTagName, tickler.Guid);
            var months = CreateTagIfNeeded(note, gConfig.TicklerMonthsSubTagName, tickler.Guid);

            for (int day = 1; day < 32; day++)
            {
                CreateTagIfNeeded(note, string.Format("Day {0:00}", day), days.Guid);
            }

            var jan1 = DateTime.Parse("1/1/2000");
            for (int month = 0; month < 12; month++)
            {
                var dt = jan1.AddMonths(month);
                CreateTagIfNeeded(note, string.Format("{0:00}-{1:MMM}", month + 1, dt), months.Guid);
            }
        }

        private IList<Note> AllNotesForToday(INoteStore note)
        {
            var todayTag = AllTags(note).FirstOrDefault(m => m.Name == string.Format("Day {0:00}", DateTime.Now.Day));
            var todayFilter = new NoteFilter()
            {
                TagGuids = new List<string>() { todayTag.Guid }
            };
            var todayNotes = note.FindNotes(todayFilter, 0, Evernote.EDAM.Limits.Constants.EDAM_USER_NOTES_MAX);
            return todayNotes.Notes;
        }
        private Tag CreateTagIfNeeded(INoteStore note, string name, string parent = null)
        {
            if (AllTags(note).Any(m => m.Name == name) == false)
            {
                console.WriteLine("Creating Tag : {0}", name);
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
