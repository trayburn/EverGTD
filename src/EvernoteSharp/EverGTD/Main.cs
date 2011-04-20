using System;
using Evernote;
using EvernoteSharp;

namespace EverGTD
{
	public interface IGTD 
	{
		void Execute(string[] args);
	}
	
	public class GTD : IGTD 
	{
		public void Execute(string[] args)
		{
			
		}
	}
	
	class MainClass
	{
		public static void Main (string[] args)
		{
			
		}
		
		public static void EvernoteSharpDemo()
		{
			var config = new EvernoteConfiguration();
			StoreFactory sf = new StoreFactory (config.Server,config.ConsumerKey,config.ConsumerSecret);
			UserStoreWrapper userStore = sf.CreateUserStore ();

			if (!userStore.CheckVersion ()) 
				throw new Exception ("Invalid API version");
			userStore.Authenticate (config.UserName, config.Password);

			NoteStoreWrapper noteStore = sf.CreateNoteStore ();
			var tags = noteStore.ListTags ();
			foreach (var item in tags) 
			{
				Console.WriteLine(item.Name);
			}
			var defaultNotebook = noteStore.GetDefaultNotebook ();
		}
	}

	

	
}
