
using System;
using Evernote;
using EvernoteSharp;
namespace EverGTD
{
	public interface IGTDConfiguration
	{
		string NotebookName {get;}
		string NextActionTagName {get;}
		string WaitingOnTagName {get;}
		string TicklerTagName {get;}
		string TicklerDaysSubTagName {get;}
		string TicklerMonthsSubTagName {get;}
		string TicklerDayTagNameFormat {get;}
		string TicklerMonthTagNameFormat {get;}
	}

}
