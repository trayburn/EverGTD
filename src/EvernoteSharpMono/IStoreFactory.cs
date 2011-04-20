using System;

namespace EvernoteSharp
{
    public interface IStoreFactory
    {
        IUserStore CreateUserStore();
        INoteStore CreateNoteStore();
    }
}
