using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using EvernoteSharp.Util;
using EvernoteSharp.Events;

namespace EvernoteSharp
{
    /// <summary>
    /// factory to create UserStore and NoteStore instances.
    /// Factory holds settings like the evernote url and application key.
    /// </summary>
    public class StoreFactory : IStoreFactory
    {
        private Uri evernoteUri;
        private string consumerKey;
        private string consumerSecret;
        private ServiceBus servicebus;

        /// <summary>
        /// create this factory. all parameters are mandatory.
        /// </summary>
        /// <param name="evernoteUri">evernote base url, like http://sandbox.evernote.com/</param>
        /// <param name="consumerKey">your personal consumer key that you got from Evernote</param>
        /// <param name="consumerSecret">your secret key that you got from Evernote</param>
        public StoreFactory(Uri evernoteUri, string consumerKey, string consumerSecret)
        {
            ParamCheck.NotNull("evernoteUri", evernoteUri);
            ParamCheck.NullNorEmpty("consumerKey", consumerKey);
            ParamCheck.NullNorEmpty("consumerSecret", consumerSecret);

            this.evernoteUri = evernoteUri;
            this.consumerKey = consumerKey;
            this.consumerSecret = consumerSecret;
            this.servicebus = new ServiceBus();

            //we are interested in auth event
            this.servicebus.AddSubscriber<AuthenticationEvent>(authenticationEventHandler);
        }

        public IUserStore CreateUserStore()
        {
            return new UserStoreWrapper(this.evernoteUri, this.consumerKey, this.consumerSecret, servicebus);
        }

        internal string AuthenticationToken;
        internal string ShardId;

        /// <summary>
        /// (probably) UserStoreWrapper sends Authentication info to interested parties like ourselves.
        /// </summary>
        private void authenticationEventHandler(AuthenticationEvent eventInfo)
        {
            this.AuthenticationToken = eventInfo.AuthenticationResult.AuthenticationToken;
            this.ShardId = eventInfo.AuthenticationResult.User.ShardId;
        }

        public INoteStore CreateNoteStore()
        {
            if (this.AuthenticationToken == null || this.ShardId == null)
                throw new InvalidOperationException("You should log in to Evernote first");

            return new NoteStoreWrapper(this.evernoteUri, this.AuthenticationToken, this.ShardId, this.servicebus);
        }

    }
}
