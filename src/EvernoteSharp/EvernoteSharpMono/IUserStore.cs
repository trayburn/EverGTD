using System;
using Evernote.EDAM.UserStore;

namespace EvernoteSharp
{
    public interface IUserStore
    {
        bool CheckVersion();
        AuthenticationResult Authenticate(string userName, string password);
        AuthenticationResult RefreshAuthentication();
    }
}
