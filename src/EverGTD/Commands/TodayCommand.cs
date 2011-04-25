using System;
using System.Linq;
using Evernote.EDAM.Type;
using System.Collections.Generic;
using System.Xml.Linq;

namespace EverGTD
{
    public class TodayCommand : BaseCommand, ICommand
    {
        public TodayCommand(IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base("today", "", console, note, gConfig)
        {
        }

        public override void Execute(IEnumerable<string> parameters)
        {
            var todayNotes = note.AllNotesForToday;
            if (todayNotes.Count > 0)
            {
                OutputTodayNotes(todayNotes);
                console.WriteLine();
            }

            var naNotes = note.GetNotesByTags(gConfig.NextActionTagName);
            if (naNotes.Count > 0) OutputNextActions(naNotes);
        }

        private void OutputTodayNotes(IList<Note> notes)
        {
            console.WriteLine("Today");
            console.WriteLine("-----");
            foreach (var lNote in notes)
            {
                if (note.AllImportantNotes.Any(m => m.Guid == lNote.Guid))
                    console.ForegroundColor = ConsoleColor.Yellow;
                console.WriteLine(lNote.Title);
                console.ResetColor();
            }
        }

        private void OutputNextActions(IList<Note> notes)
        {
            console.WriteLine("Next Actions");
            console.WriteLine("------------");
            int count = 0;
            foreach (var lNote in notes)
            {
                count++;
                if (note.AllImportantNotes.Any(m => m.Guid == lNote.Guid))
                    console.ForegroundColor = ConsoleColor.Yellow;
                console.WriteLine("{0}> {1}", count, lNote.Title);
                console.ResetColor();
            }
        }
    }
}
