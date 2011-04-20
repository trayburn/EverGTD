using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace EvernoteSharp
{
    public abstract class AbstractStoreWrapper
    {
        private Uri storeUri;

        internal AbstractStoreWrapper(Uri storeUri)
        {
            this.storeUri = storeUri;
        }

        /// <summary>
        /// create a disposable Thrift http client. And you'd better dispose it.
        /// </summary>
        internal ThriftHttpClient GetHttpClient()
        {
            return new ThriftHttpClient(this.storeUri.AbsoluteUri);
        }


    }
}
