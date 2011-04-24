using System;
using System.Linq;
using EvernoteSharp;
using Evernote.EDAM.Type;
using System.Collections.Generic;
using Evernote.EDAM.NoteStore;

namespace EverGTD
{
    public class CachedNoteStore : ICachedNoteStore
    {
        private IStoreFactory factory;
        private INoteStore note;
        private IGTDConfiguration gConfig;

        public CachedNoteStore(IStoreFactory factory, IGTDConfiguration gConfig)
        {
            this.factory = factory;
            this.gConfig = gConfig;
        }

        private INoteStore Note
        {
            get
            {
                if (note == null)
                    note = factory.CreateNoteStore();
                return note;
            }
        }

        private IList<Notebook> allNotesbooks;
        public IList<Notebook> AllNotebooks
        {
            get
            {
                if (allNotesbooks == null)
                    allNotesbooks = Note.ListNotebooks();
                return allNotesbooks;
            }
        }

        public Notebook CreateNotebook(Notebook n)
        {
            return Note.CreateNotebook(n);
        }

        public IList<string> GetNoteTagNames(string guid)
        {
            return Note.GetNoteTagNames(guid);
        }

        public Tag CreateTagIfNeeded(string name, string parent = null)
        {
            return CreateTagIfNeeded(Note, name, parent);
        }

        public Note UpdateNote(Note n)
        {
            return Note.UpdateNote(n);
        }

        public Note CreateNote(Note n)
        {
            return Note.CreateNote(n);
        }

        public Note GetNote(string guid, bool withContent)
        {
            return Note.GetNote(guid, withContent);
        }

        public void DeleteNote(Note n)
        {
            n.Active = false;
            note.UpdateNote(n);
        }

        private Tag CreateTagIfNeeded(INoteStore note, string name, string parent = null)
        {
            if (AllTags.Any(m => m.Name == name) == false)
            {
                Tag newTag = new Tag { Name = name };
                if (parent != null) newTag.ParentGuid = parent;
                newTag = note.CreateTag(newTag);
                allTags.Add(newTag);
                return newTag;
            }
            return AllTags.First(m => m.Name == name);
        }

        private IList<Tag> allTags;
        public IList<Tag> AllTags
        {
            get
            {
                if (allTags == null)
                    allTags = Note.ListTags();
                return allTags;
            }
        }

        private IList<Note> allImportantNotes;
        public IList<Note> AllImportantNotes
        {
            get
            {
                if (allImportantNotes == null)
                    allImportantNotes = GetNotesByTags(gConfig.ImportantTagName);
                return allImportantNotes;
            }
        }

        public IList<Note> AllNotesForToday
        {
            get
            {
                var todayTag = AllTags.FirstOrDefault(m => m.Name == string.Format("Day {0:00}", DateTime.Now.Day));
                var todayFilter = new NoteFilter()
                {
                    TagGuids = new List<string>() { todayTag.Guid }
                };
                var todayNotes = Note.FindNotes(todayFilter, 0, Evernote.EDAM.Limits.Constants.EDAM_USER_NOTES_MAX);
                return todayNotes.Notes;
            }
        }

        public IList<Note> GetNotesByTags(params string[] args)
        {
            var tags = AllTags.Where(m => args.Contains(m.Name)).Select(m => m.Guid).ToList();
            var filter = new NoteFilter { TagGuids = tags };
            var notes = Note.FindNotes(filter, 0, Evernote.EDAM.Limits.Constants.EDAM_USER_NOTES_MAX);
            return notes.Notes.OrderBy(m => m.Title).ToList();
        }
    }
}
