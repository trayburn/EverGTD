using System;

namespace EverGTD
{
    public interface IConsoleFacade
    {
        ConsoleColor ForegroundColor { get; set; }
        void ResetColor();
        void WriteLine(string format, params object[] arg);
        void WriteLine(string output);
        void WriteLine();
        void Write(string format, params object[] arg);
        string ReadLine();
    }
}
