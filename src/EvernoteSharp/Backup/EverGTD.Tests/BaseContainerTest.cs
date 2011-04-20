
using System;
using NUnit.Framework;
using Castle.Windsor;
using Rhino.Mocks;
using Castle.MicroKernel.Registration;
namespace EverGTD.Tests
{
	[TestFixture]
	public class BaseContainerTest : BaseTest
	{
		protected IWindsorContainer container;
		
		public override void BeforeEachTest ()
		{
			container = new WindsorContainer();
			
			base.BeforeEachTest ();
		}
		
		protected T MockAndIoC<T>() where T : class
		{
			var mock = MockRepository.GenerateMock<T>();
			container.Register(Component.For<T>().Instance(mock));
			return mock;
		}
	}
}
