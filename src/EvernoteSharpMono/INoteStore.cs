using System;
using System.Collections.Generic;
using Evernote.EDAM.NoteStore;
using Evernote.EDAM.Type;
using Evernote.EDAM.UserStore;

namespace EvernoteSharp
{
    public interface INoteStore
    {
        IList<Notebook> ListNotebooks();
        Notebook GetNotebook(string guid);
        Notebook GetDefaultNotebook();
        Notebook CreateNotebook(Notebook nb);
        int UpdateNotebook(Notebook nb);
        int ExpungeNotebook(string guid);
        IList<Tag> ListTags();
        IList<Tag> ListTagsByNotebook(string notebookGuid);
        Tag GetTag(string guid);
        Tag CreateTag(Tag tag);
        int UpdateTag(Tag tag);
        void UntagAll(string guid);
        int ExpungeTag(string guid);
        IList<SavedSearch> ListSearches();
        SavedSearch GetSearch(string guid);
        SavedSearch CreateSearch(SavedSearch s);
        int UpdateSearch(SavedSearch s);
        int ExpungeSearch(string guid);
        NoteList FindNotes(NoteFilter filter, int offset, int maxNotes);
        NoteCollectionCounts FindNoteCounts(NoteFilter filter);
        Note GetNote(string guid, bool withContent);
        string GetNoteContent(string guid);
        IList<string> GetNoteTagNames(string guid);
        Note CreateNote(Note n);
        Note UpdateNote(Note n);
        int ExpungeNote(string guid);
        int ExpungeNotes(IList<string> noteGuids);
        int ExpungeInactiveNotes();
        Note CopyNote(string noteGuid, string toNotebookGuid);
        Resource GetResource(string guid, bool withData, bool withRecognition, bool withAttributes);
        int UpdateResource(Resource r);
        byte[] GetResourceData(string guid);
        Resource GetResourceByHash(string noteGuid, byte[] contentHash, bool withData, bool withRecognition);
        byte[] GetResourceRecognition(string guid);
        ResourceAttributes GetResourceAttributes(string guid);
        Notebook GetPublicNotebook(int userId, string publicUri);
        SyncState GetSyncState();
        SyncChunk GetSyncChunk(int afterUSN, int maxEntries);
        long GetAccountSize();
        IList<Ad> GetAds(AdParameters adParameters);
        Ad GetRandomAd(AdParameters adParameters);
        LinkedNotebook CreateLinkedNotebook(LinkedNotebook linkedNotebook);
        int ExpungeLinkedNotebook(long id);
        IList<LinkedNotebook> ListLinkedNotebooks();
        LinkedNotebook UpdateLinkedNotebook(LinkedNotebook ln);
        SharedNotebook CreateSharedNotebook(SharedNotebook sn);
        int ExpungeSharedNotebook(IList<long> ids);
        IList<SharedNotebook> ListSharedNotebooks();
        AuthenticationResult AuthenticateToSharedNotebook(string shareKey);
        SharedNotebook GetSharedNotebookByAuth();
    }
}
