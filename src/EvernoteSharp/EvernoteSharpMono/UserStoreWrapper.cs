using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Thrift.Protocol;
using Evernote.EDAM.UserStore;
using EvernoteSharp.Util;
using EvernoteSharp.Events;

namespace EvernoteSharp
{
    /// <summary>
    /// wrapper around the thrift UserStore object. This wrapper closes the 
    /// http connection for you, which is nice, because otherwise, on a 
    /// Compact Framework environment, you could only do three requests.
    /// </summary>
    public class UserStoreWrapper : AbstractStoreWrapper
    {
        private string consumerKey;
        private string consumerSecret;
        private ServiceBus servicebus;

        internal UserStoreWrapper(Uri evernoteUri, string consumerKey, string consumerSecret, ServiceBus servicebus)
            : base(new Uri(evernoteUri, "/edam/user"))
        {
            this.consumerKey = consumerKey;
            this.consumerSecret = consumerSecret;
            this.servicebus = servicebus;
        }

        /// <summary>
        /// create a EDAM UserStore client.
        /// </summary>
        internal UserStore.Client GetUserStoreClient(ThriftHttpClient httpClient)
        {
            return new UserStore.Client(httpClient.Protocol);
        }

        /// <summary>
        /// check the Evernote protocol version to see if our implementation is still up-to-date.
        /// </summary>
        public bool CheckVersion()
        {
            lock (this)
                using (var client = GetHttpClient())
                {
                    return GetUserStoreClient(client).checkVersion("EvernoteSharp v1.0", Constants.EDAM_VERSION_MAJOR, Constants.EDAM_VERSION_MINOR);
                }
        }

        private string authenticationToken;

        /// <summary>
        /// Authenticate an evernote user agains the evernote authentication service.
        /// </summary>
        public AuthenticationResult Authenticate(string userName, string password)
        {
            ParamCheck.NullNorEmpty("userName", userName);

            lock (this)
                using (var client = GetHttpClient())
                {
                    var authResult = GetUserStoreClient(client).authenticate(userName, password, this.consumerKey, this.consumerSecret);

                    saveAndPublishAuthResult(authResult);

                    return authResult;
                }
        }

        private void saveAndPublishAuthResult(AuthenticationResult authResult)
        {
            //save and publish results for future reference
            this.authenticationToken = authResult.AuthenticationToken;
            servicebus.Publish<AuthenticationEvent>(new AuthenticationEvent() { AuthenticationResult = authResult, Sender = this });
        }

        /// <summary>
        /// refresh the authentication that was already performed.
        /// </summary>
        /// <returns></returns>
        public AuthenticationResult RefreshAuthentication()
        {
            lock (this)
                using (var client = GetHttpClient())
                {
                    var authResult = GetUserStoreClient(client).refreshAuthentication(this.authenticationToken);

                    saveAndPublishAuthResult(authResult);

                    return authResult;
                }
        }

    }
}
