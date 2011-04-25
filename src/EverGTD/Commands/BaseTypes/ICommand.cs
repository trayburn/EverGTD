using System;
using System.Collections.Generic;

namespace EverGTD
{
    public interface ICommand
    {
        string Name { get; }
        void Execute(IEnumerable<string> parameters);
    }
}
