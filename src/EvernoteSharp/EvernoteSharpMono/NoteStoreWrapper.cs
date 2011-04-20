using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Evernote.EDAM.NoteStore;
using Evernote.EDAM.Type;
using EvernoteSharp.Events;
using Evernote.EDAM.UserStore;

namespace EvernoteSharp
{
    public class NoteStoreWrapper : AbstractStoreWrapper, INoteStore
    {
        private string authToken;

        internal NoteStoreWrapper(Uri evernoteUri, string authToken, string shardId, ServiceBus servicebus)
            : base(new Uri(evernoteUri, "/edam/note/" + shardId))
        {
            this.authToken = authToken;
            servicebus.AddSubscriber<AuthenticationEvent>(this.authenticationHandler);
        }

        /// <summary>
        /// someone (probably the UserStoreWrapper) provides authentication info, most
        /// likely after refreshing the autentication token.
        /// </summary>
        private void authenticationHandler(AuthenticationEvent eventInfo)
        {
            this.authToken = eventInfo.AuthenticationResult.AuthenticationToken;
        }

        internal NoteStore.Client GetNoteStoreClient(ThriftHttpClient httpClient)
        {
            if (string.IsNullOrEmpty(this.authToken))
                throw new InvalidOperationException("Log in to Evernote first");

            return new NoteStore.Client(httpClient.Protocol);
        }

        #region Notebook methods
        /// <summary>
        /// Returns a list of all of the Notebooks in the account.
        /// </summary>
        public IList<Notebook> ListNotebooks()
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).listNotebooks(this.authToken);
                }
        }

        /// <summary>
        /// Retrieves the state of a single Notebook.
        /// </summary>
        public Notebook GetNotebook(string guid)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).getNotebook(this.authToken, guid);
                }
        }

        /// <summary>
        /// Retrieves the Notebook that should receive new Notes which do not specify a destination.
        /// </summary>
        public Notebook GetDefaultNotebook()
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).getDefaultNotebook(this.authToken);
                }

        }

        /// <summary>
        /// Makes a new Notebook in the account.
        /// </summary>
        public Notebook CreateNotebook(Notebook nb)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).createNotebook(this.authToken, nb);
                }

        }

        /// <summary>
        /// Changes an existing Notebook.
        /// </summary>
        public int UpdateNotebook(Notebook nb)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).updateNotebook(this.authToken, nb);
                }

        }

        /// <summary>
        /// Permanently removes an existing Notebook.
        /// </summary>
        public int ExpungeNotebook(string guid)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).expungeNotebook(this.authToken, guid);
                }
        }
        #endregion

        #region Tag methods
        /// <summary>
        /// Returns a list of all of the Tags in the account.
        /// </summary>
        public IList<Tag> ListTags()
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).listTags(this.authToken);
                }
        }

        public IList<Tag> ListTagsByNotebook(string notebookGuid)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).listTagsByNotebook(this.authToken, notebookGuid);
                }
        }

        /// <summary>
        /// Retrieves the state of a single Tag.
        /// </summary>
        public Tag GetTag(string guid)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).getTag(this.authToken, guid);
                }
        }

        /// <summary>
        /// Makes a new Tag in the account.
        /// </summary>
        public Tag CreateTag(Tag tag)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).createTag(this.authToken, tag);
                }
        }

        /// <summary>
        /// Changes an existing Tag.
        /// </summary>
        public int UpdateTag(Tag tag)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).updateTag(this.authToken, tag);
                }
        }

        /// <summary>
        /// Removes a Tag from any Notes.
        /// </summary>
        public void UntagAll(string guid)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    GetNoteStoreClient(httpClient).untagAll(this.authToken, guid);
                }
        }

        /// <summary>
        /// Permanently removes an existing Tag.
        /// </summary>
        public int ExpungeTag(string guid)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).expungeTag(this.authToken, guid);
                }
        }
        #endregion

        #region Search methods

        /// <summary>
        /// Returns a list of all of the SavedSearches in the account.
        /// </summary>
        public IList<SavedSearch> ListSearches()
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).listSearches(this.authToken);
                }
        }

        /// <summary>
        /// Retrieves the state of a single SavedSearch.
        /// </summary>
        public SavedSearch GetSearch(string guid)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).getSearch(this.authToken, guid);
                }
        }

        /// <summary>
        /// Makes a new SavedSearch in the account.
        /// </summary>
        public SavedSearch CreateSearch(SavedSearch s)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).createSearch(this.authToken, s);
                }
        }

        /// <summary>
        /// Changes an existing SavedSearch.
        /// </summary>
        public int UpdateSearch(SavedSearch s)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).updateSearch(this.authToken, s);
                }
        }

        /// <summary>
        /// Permanently removes an existing SavedSearch.
        /// </summary>
        public int ExpungeSearch(string guid)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).expungeSearch(this.authToken, guid);
                }
        }
        #endregion

        #region Notes methods
        /// <summary>
        /// Performs a search of the Notes in the User’s account based on a configurable filter, returning a paginated subset.
        /// </summary>
        public NoteList FindNotes(NoteFilter filter, int offset, int maxNotes)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).findNotes(this.authToken, filter, offset, maxNotes);
                }
        }

        /// <summary>
        /// Performs a search based on a configurable filter, returning the number of Notes that would match this filter for each Notebook and Tag.
        /// </summary>
        public NoteCollectionCounts FindNoteCounts(NoteFilter filter)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).findNoteCounts(this.authToken, filter);
                }
        }

        /// <summary>
        /// Retrieves the state of a single Note.
        /// </summary>
        public Note GetNote(string guid, bool withContent)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).getNote(this.authToken, guid, withContent);
                }
        }

        /// <summary>
        /// Retrieves just the ENML hypertext content of a Note.
        /// </summary>
        public string GetNoteContent(string guid)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).getNoteContent(this.authToken, guid);
                }
        }

        /// <summary>
        /// Retrieves the names of the Tags for a single Note.
        /// </summary>
        public IList<string> GetNoteTagNames(string guid)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).getNoteTagNames(this.authToken, guid);
                }
        }

        /// <summary>
        /// Makes a new Note in an existing Notebook.
        /// </summary>
        public Note CreateNote(Note n)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).createNote(this.authToken, n);
                }
        }

        /// <summary>
        /// Changes the content or metadata of a single existing Note.
        /// </summary>
        public Note UpdateNote(Note n)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).updateNote(this.authToken, n);
                }
        }

        /// <summary>
        /// Permanently removes an existing Note.
        /// </summary>
        public int ExpungeNote(string guid)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).expungeNote(this.authToken, guid);
                }
        }

        /// <summary>
        /// Permanently removes a set of existing Notes.
        /// </summary>
        public int ExpungeNotes(IList<string> noteGuids)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).expungeNotes(this.authToken, noteGuids.ToList<string>());
                }
        }

        /// <summary>
        /// Permanently removes all of the notes that are currently not active (i.e. notes in the “Trash”)
        /// </summary>
        public int ExpungeInactiveNotes()
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).expungeInactiveNotes(this.authToken);
                }
        }

        /// <summary>
        /// Copy a note to a notebook
        /// </summary>
        public Note CopyNote(string noteGuid, string toNotebookGuid)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).copyNote(this.authToken, noteGuid, toNotebookGuid);
                }
        }

        #endregion

        #region Resource methods
        /// <summary>
        /// Retrieves the state of a single Note attachment, optionally with its binary contents.
        /// </summary>
        public Resource GetResource(string guid, bool withData, bool withRecognition, bool withAttributes)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).getResource(this.authToken, guid, withData, withRecognition, withAttributes);
                }
        }

        /// <summary>
        /// Updates the metadata for a single Resource.  (Not its binary contents.)
        /// </summary>
        public int UpdateResource(Resource r)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).updateResource(this.authToken, r);
                }
        }

        /// <summary>
        /// Retrieves the binary contents of a single Resource.
        /// </summary>
        public byte[] GetResourceData(string guid)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).getResourceData(this.authToken, guid);
                }
        }

        /// <summary>
        /// Retrieves one of the resources from a Note, via the MD5 checksum of its contents, not its GUID.
        /// </summary>
        public Resource GetResourceByHash(string noteGuid, byte[] contentHash, bool withData, bool withRecognition)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).getResourceByHash(this.authToken, noteGuid, contentHash, withData, withRecognition);
                }
        }

        /// <summary>
        /// Returns the XML recognition index file for a single Resource, which can be used to find words in the image.
        /// </summary>
        public byte[] GetResourceRecognition(string guid)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).getResourceRecognition(this.authToken, guid);
                }
        }

        /// <summary>
        /// Returns the set of attributes for the Resource.
        /// </summary>
        public ResourceAttributes GetResourceAttributes(string guid)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).getResourceAttributes(this.authToken, guid);
                }
        }

        #endregion

        #region public note(book) methods
        /// <summary>
        /// Gets the information for one published Notebook from a user’s account, via its public URI.
        /// </summary>
        public Notebook GetPublicNotebook(int userId, string publicUri)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).getPublicNotebook(userId, publicUri);
                }
        }

        #endregion

        #region sync and account methods
        /// <summary>
        /// Light-weight call for caching clients to “ping” the service to see whether the account has changed.
        /// </summary>
        public SyncState GetSyncState()
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).getSyncState(this.authToken);
                }
        }

        /// <summary>
        /// Core routine for full, synchronizing clients to retrieve the set of changes in an account since the last checkpoint.
        /// </summary>
        public SyncChunk GetSyncChunk(int afterUSN, int maxEntries)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).getSyncChunk(this.authToken, afterUSN, maxEntries);
                }
        }

        public long GetAccountSize()
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).getAccountSize(this.authToken);
                }
        }

        public IList<Ad> GetAds(AdParameters adParameters)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).getAds(this.authToken, adParameters);
                }
        }

        public Ad GetRandomAd(AdParameters adParameters)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).getRandomAd(this.authToken, adParameters);
                }
        }

        #endregion

        #region Linked notebook methods

        public LinkedNotebook CreateLinkedNotebook(LinkedNotebook linkedNotebook)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).createLinkedNotebook(this.authToken, linkedNotebook);
                }
        }

        public int ExpungeLinkedNotebook(long id)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).expungeLinkedNotebook(this.authToken, id);
                }
        }


        public IList<LinkedNotebook> ListLinkedNotebooks()
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).listLinkedNotebooks(this.authToken);
                }
        }

        public LinkedNotebook UpdateLinkedNotebook(LinkedNotebook ln)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).updateLinkedNotebook(this.authToken, ln);
                }
        }

        #endregion

        #region Shared notebook methods

        public SharedNotebook CreateSharedNotebook(SharedNotebook sn)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).createSharedNotebook(this.authToken, sn);
                }
        }

        public int ExpungeSharedNotebook(IList<long> ids)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).expungeSharedNotebooks(this.authToken, ids.ToList());
                }
        }


        public IList<SharedNotebook> ListSharedNotebooks()
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).listSharedNotebooks(this.authToken);
                }
        }

        public AuthenticationResult AuthenticateToSharedNotebook(string shareKey)
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).authenticateToSharedNotebook(shareKey, this.authToken);
                }
        }

        public SharedNotebook GetSharedNotebookByAuth()
        {
            lock (this)
                using (var httpClient = GetHttpClient())
                {
                    return GetNoteStoreClient(httpClient).getSharedNotebookByAuth(this.authToken);
                }
        }

        #endregion
    }
}
