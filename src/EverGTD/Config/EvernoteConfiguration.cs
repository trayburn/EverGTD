
using System;
using Evernote;
using EvernoteSharp;
namespace EverGTD
{
	public class EvernoteConfiguration : IEvernoteConfiguration
	{
		public Uri Server {
			get {
				return new Uri("https://www.evernote.com/");
			}
		}

		public string ConsumerKey {
			get {
				return "trayburn";
			}
		}

		public string ConsumerSecret {
			get {
				return "e8deaf77eaaa74c4";
			}
		}

		public string UserName {
			get {
				return "trayburn";
			}
		}

		public string Password {
			get {
				return "Vamp2nd!";
			}
		}
	}
}
