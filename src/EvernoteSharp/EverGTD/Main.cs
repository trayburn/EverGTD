using System;
using Evernote;
using EvernoteSharp;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace EverGTD
{
	class MainClass
	{
		public static void Main (string[] args)
		{
            var container = new WindsorContainer();

            container.Register(
                Component.For<IGTD>().ImplementedBy<GTD>(),
                Component.For<IEvernoteConfiguration>().ImplementedBy<EvernoteConfiguration>(),
                Component.For<IGTDConfiguration>().ImplementedBy<GTDConfiguration>()
                );

            var gtd = container.Resolve<IGTD>();
            gtd.Execute(args);
		}
		
		public static void EvernoteSharpDemo()
		{
			var config = new EvernoteConfiguration();
			StoreFactory sf = new StoreFactory (config.Server,config.ConsumerKey,config.ConsumerSecret);
			var userStore = sf.CreateUserStore ();

			if (!userStore.CheckVersion ()) 
				throw new Exception ("Invalid API version");
			userStore.Authenticate (config.UserName, config.Password);

			var noteStore = sf.CreateNoteStore ();
			var tags = noteStore.ListTags ();
			foreach (var item in tags) 
			{
				Console.WriteLine(item.Name);
			}
			var defaultNotebook = noteStore.GetDefaultNotebook ();
		}
	}

	

	
}
