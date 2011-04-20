
using System;
using Evernote;
using EvernoteSharp;
namespace EverGTD
{
	public interface IEvernoteConfiguration 
	{
		Uri Server {get;}
		string ConsumerKey {get;}
		string ConsumerSecret {get;}
		string UserName {get;}
		string Password {get;}
	}
	

}
