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
            using (var container = new WindsorContainer())
            {
                container.Register(
                    Component.For<IGtd>().ImplementedBy<Gtd>(), 
                    Component.For<IConsoleFacade>().ImplementedBy<ConsoleFacade>(), 
                    Component.For<IEvernoteConfiguration>().ImplementedBy<EvernoteConfiguration>(), 
                    Component.For<IGTDConfiguration>().ImplementedBy<GTDConfiguration>(), 
                    Component.For<IStoreFactory>().UsingFactoryMethod(k =>
                {
                    var config = k.Resolve<IEvernoteConfiguration>();
                    return new StoreFactory(config.Server, config.ConsumerKey, config.ConsumerSecret);
                }));
                var gtd = container.Resolve<IGtd>();
                gtd.Execute(args);
            }
		}
	}
}
