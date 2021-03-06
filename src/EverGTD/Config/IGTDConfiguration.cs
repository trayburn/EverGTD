
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
        string AgendaTagName { get; }
        string GetTagForDay(int day);
        string GetTagForToday();
        //string TicklerDayTagNameFormat {get;}
        //string TicklerMonthTagNameFormat {get;}
    }

}
