
using System;
using Evernote;
using EvernoteSharp;
namespace EverGTD
{
	public class GTDConfiguration : IGTDConfiguration
	{
		public string NotebookName {
			get {
				return "GTD";
			}
		}

		//public string NextActionTagName {
		//	get {
		//		return ".Next Action";
		//	}
		//}

		//public string WaitingOnTagName {
		//	get {
		//		return ".Waiting On";
		//	}
		//}

		//public string TicklerTagName {
		//	get {
		//		return ".Tickler";
		//	}
		//}

		//public string TicklerDaysSubTagName {
		//	get {
		//		return "Days";
		//	}
		//}

		//public string TicklerMonthsSubTagName {
		//	get {
		//		return "Months";
		//	}
		//}

		//public string TicklerDayTagNameFormat {
		//	get {
		//		return "Day {0}";
		//	}
		//}

		//public string TicklerMonthTagNameFormat {
		//	get {
		//		return "{0}-{1}";
		//	}
		//}
	}
}