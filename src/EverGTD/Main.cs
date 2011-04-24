using System;
using Evernote;
using EvernoteSharp;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;

namespace EverGTD
{
	class MainClass
	{
		public static void Main (string[] args)
		{
            using (var container = new WindsorContainer())
            {
                container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel));
                container.Register(
                    Component.For<IGtd>().ImplementedBy<Gtd>(), 
                    Component.For<IConsoleFacade>().ImplementedBy<ConsoleFacade>(), 
                    Component.For<IEvernoteConfiguration>().ImplementedBy<EvernoteConfiguration>(), 
                    Component.For<IGTDConfiguration>().ImplementedBy<GTDConfiguration>(), 
                    Component.For<ICachedNoteStore>().ImplementedBy<CachedNoteStore>(),
                    AllTypes.FromThisAssembly().BasedOn<ICommand>().WithService.AllInterfaces(),
                    Component.For<IStoreFactory>().UsingFactoryMethod(k =>
                    {
                        var config = k.Resolve<IEvernoteConfiguration>();
                        return new StoreFactory(config.Server, config.ConsumerKey, config.ConsumerSecret);
                    })
                );
                var gtd = container.Resolve<IGtd>();
                gtd.Execute(args);
            }
		}
	}
}
