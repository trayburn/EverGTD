using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Thrift.Transport;
using Thrift.Protocol;

namespace EvernoteSharp
{
    /// <summary>
    /// wrapper around THttpClient and TBinaryProtocol. The THttpClient /has/ to be closed
    /// after use, because in a Compact Framework environment, you can only make three 
    /// connections simultaneously. After that you application hangs. This wrapper implements
    /// the IDisposable pattern which manages the closing of the client. 
    /// </summary>
    internal class ThriftHttpClient : IDisposable
    {
        THttpClient httpClient;
        TBinaryProtocol protocol;

        public ThriftHttpClient(string uri)
        {
            this.httpClient = new THttpClient(uri);
            this.protocol= new TBinaryProtocol(httpClient);
        }

        public TBinaryProtocol Protocol
        {
            get
            {
                return this.protocol;
            }
        }

        #region IDisposable Members
        protected void Dispose(bool disposing) {
            if (!disposed)
            {
                disposed = true;
                if (disposing)
                {
                    //dispose managed state
                    httpClient.Close();
                }
                else
                {
                    System.Diagnostics.Debug.Assert(false); // you MUST dispose this object explicitely or be doomed.
                }

                httpClient = null;
                protocol = null;

                GC.SuppressFinalize(this);
            }
        }

        protected bool disposed;
        public void Dispose()
        {
            Dispose(true);
        }

        ~ThriftHttpClient()
        {
            Dispose(false);
        }

        #endregion
    }
}
