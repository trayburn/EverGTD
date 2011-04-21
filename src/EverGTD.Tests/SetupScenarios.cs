using System;
using NUnit.Framework;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using EvernoteSharp;
using Rhino.Mocks;
using Evernote.EDAM.Type;
using System.Collections.Generic;
using Evernote.EDAM.NoteStore;

namespace EverGTD.Tests
{
    [TestFixture]
    public class TodayScenarios : BaseEvernoteTest
    {
        private string[] args;

        public override void BeforeEachTest()
        {
            base.BeforeEachTest();
            args = new[] { "today" };
        }

        [Test]
        public void Today_Should_List_All_Next_Actions()
        {
            // Arrange
            allTags.Add(new Tag { Guid = Guid.NewGuid().ToString(), Name = gConfig.NextActionTagName });
            note.Stub(m => m.FindNotes(null, 0, 0)).IgnoreArguments()
                .Return(new NoteList()
                {
                    Notes = new List<Note>()
                    {
                        new Note { Title = "Foo" },
                        new Note { Title = "Bar" },
                        new Note { Title = "Baz" }
                    }
                });

            // Act
            gtd.Execute(args);

            // Assert
            console.AssertWasCalled(m => m.WriteLine("Today"));
            console.AssertWasCalled(m => m.WriteLine("-----"));
            console.AssertWasCalled(m => m.WriteLine("",0,""),
                mo => mo.IgnoreArguments().Repeat.Times(3));
        }
    }
    [TestFixture]
    public class GTDScenarios : BaseEvernoteTest
    {
        [Test]
        public void Setup_Should_Create_All_Tags_When_They_Do_Not_Exist()
        {
            string[] args = { "setup" };

            // Act
            gtd.Execute(args);

            // Assert
            note.AssertWasCalled(m => m.CreateTag(Arg<Tag>.Is.Anything),
                mo => mo.Repeat.Times(49));
        }

        [Test]
        public void Setup_Should_Not_Create_Notebook_When_It_Exists()
        {
            // Arrange
            string[] args = { "setup" };
            allNotebooks.Add(new Notebook { Name = gConfig.NotebookName });

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

            // Act
            gtd.Execute(args);

            // Assert
            note.AssertWasCalled(m => m.ListNotebooks());
            note.AssertWasCalled(m => m.CreateNotebook(Arg<Notebook>.Is.Anything));
        }
    }
}
