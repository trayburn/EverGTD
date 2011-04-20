using System;
using NUnit.Framework;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using EvernoteSharp;
using Rhino.Mocks;
using Evernote.EDAM.Type;
using System.Collections.Generic;

namespace EverGTD.Tests
{
	[TestFixture]
	public class GTDScenarios : BaseContainerTest
	{
		private IGTD gtd;
        private IStoreFactory factory;
        private INoteStore note;
        private IUserStore user;
        private IEvernoteConfiguration eConfig;
        private IGTDConfiguration gConfig;
		
		public override void BeforeEachTest ()
		{
			base.BeforeEachTest ();
            SetupIStoreFactory();
            SetupIEvernoteConfiguration();

            gConfig = MockAndIoC<IGTDConfiguration>();
            gConfig.Stub(m => m.NotebookName).Return("GTD");

			gtd = RegisterAndResolve<IGTD,GTD>();
		}

        public override void AfterEachTest()
        {
            user.AssertWasCalled(m => m.Authenticate("foo", "bar"));
        }

        [Test]
        public void Setup_Should_Not_Create_Notebook_When_It_Exists()
        {
            // Arrange
            string[] args = { "setup" };
            note.Stub(m => m.ListNotebooks())
                .Return(new List<Notebook>()
                {
                    new Notebook { Name = gConfig.NotebookName }
                });

            // Act
            gtd.Execute(args);

            // Assert
            note.AssertWasNotCalled(m => m.CreateNotebook(Arg<Notebook>.Is.Anything));
        }

		[Test]
		public void Setup_Should_Create_Notebook_When_It_Does_Not_Exist()
		{
			// Arrange
			string[] args = { "setup" };
            note.Stub(m => m.ListNotebooks())
                .Return(new List<Notebook>());
			
			// Act
			gtd.Execute(args);
			
			// Assert
            note.AssertWasCalled(m => m.ListNotebooks());
            note.AssertWasCalled(m => m.CreateNotebook(Arg<Notebook>.Is.Anything));
		}

        private void SetupIEvernoteConfiguration()
        {
            eConfig = MockAndIoC<IEvernoteConfiguration>();
            eConfig.Stub(m => m.UserName).Return("foo");
            eConfig.Stub(m => m.Password).Return("bar");
        }

        private void SetupIStoreFactory()
        {
            note = MockAndIoC<INoteStore>();
            user = MockAndIoC<IUserStore>();
            factory = MockAndIoC<IStoreFactory>();
            factory.Stub(m => m.CreateNoteStore()).Return(note);
            factory.Stub(m => m.CreateUserStore()).Return(user);
        }
    }
}
