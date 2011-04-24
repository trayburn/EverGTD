using System;
using Evernote.EDAM.Type;
using System.Collections.Generic;

namespace EverGTD
{
    public interface ICachedNoteStore
    {
        Tag CreateTagIfNeeded(string name, string parent = null);
        Notebook CreateNotebook(Notebook n);
        Note CreateNote(Note n);
        Note UpdateNote(Note n);
        Note GetNote(string guid, bool withContent);
        void DeleteNote(Note n);
        IList<string> GetNoteTagNames(string guid);
        IList<Note> GetNotesByTags(params string[] args);
        IList<Notebook> AllNotebooks { get; }
        IList<Tag> AllTags { get; }
        IList<Note> AllNotesForToday { get; }
        IList<Note> AllImportantNotes { get; }
    }
}
