using System;
using NUnit.Framework;
using Castle.Windsor;
using Castle.MicroKernel.Registration;

namespace EverGTD.Tests
{
	[TestFixture]
	public class GTDScenarios : BaseContainerTest
	{
		private IGTD gtd;
		
		public override void BeforeEachTest ()
		{
			base.BeforeEachTest ();
			
			container.Register(
				Component.For<IGTD>().ImplementedBy<GTD>()
			);
			
			gtd = container.Resolve<IGTD>();
		}
		
		[Test]
		public void Setup_Should_Create_Notebook_When_It_Does_Not_Exist()
		{
			// Arrange
			string[] args = { "setup" };
			
			// Act
			gtd.Execute(args);
			
			// Assert
			Assert.Fail();
		}
	}
}
