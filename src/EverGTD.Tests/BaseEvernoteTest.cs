using System;
using EvernoteSharp;
using Rhino.Mocks;
using Evernote.EDAM.Type;
using System.Collections.Generic;

namespace EverGTD.Tests
{
    public abstract class BaseEvernoteTest : BaseContainerTest
    {
        protected List<Notebook> allNotebooks;
        protected List<Tag> allTags;
        protected IGtd gtd;
        protected IStoreFactory factory;
        protected INoteStore note;
        protected IUserStore user;
        protected IEvernoteConfiguration eConfig;
        protected IGTDConfiguration gConfig;
        protected IConsoleFacade console;

        public override void BeforeEachTest()
        {
            base.BeforeEachTest();

            SetupIStoreFactory();
            SetupIEvernoteConfiguration();
            SetupIGTDConfiguration();

            console = MockAndIoC<IConsoleFacade>();
            gtd = RegisterAndResolve<IGtd, Gtd>();
        }

        public override void AfterEachTest()
        {
            user.AssertWasCalled(m => m.Authenticate("foo", "bar"));
        }

        private void SetupIGTDConfiguration()
        {
            gConfig = MockAndIoC<IGTDConfiguration>();
            gConfig.Stub(m => m.NotebookName).Return("GTD");
            gConfig.Stub(m => m.NextActionTagName).Return(".Next Action");
            gConfig.Stub(m => m.WaitingOnTagName).Return(".Waiting On");
            gConfig.Stub(m => m.TicklerTagName).Return(".Tickler");
            gConfig.Stub(m => m.TicklerDaysSubTagName).Return("Days");
            gConfig.Stub(m => m.TicklerMonthsSubTagName).Return("Months");
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

            note.Stub(m => m.CreateTag(Arg<Tag>.Is.Anything))
                .WhenCalled(mi =>
                {
                    mi.ReturnValue = mi.Arguments[0];
                });

            allTags = new List<Tag>();
            allNotebooks = new List<Notebook>();
            note.Stub(m => m.ListNotebooks())
                .Return(allNotebooks);
            note.Stub(m => m.ListTags())
                .Return(allTags);

        }
    }
}
