
using System;
using Evernote;
using EvernoteSharp;
namespace EverGTD
{
    public interface IGTDConfiguration
    {
        string NotebookName { get; }
        string NextActionTagName { get; }
        string WaitingOnTagName { get; }
        string SomedayTagName { get; }
        string TicklerTagName { get; }
        string TicklerDaysSubTagName { get; }
        string TicklerMonthsSubTagName { get; }
        string ImportantTagName { get; }
        //string TicklerDayTagNameFormat {get;}
        //string TicklerMonthTagNameFormat {get;}
    }

}
