using System;
using System.Linq;
using System.Collections.Generic;

namespace EverGTD
{
    public abstract class BaseBrokerCommand<TList, TCreate, TAppend, TTag, TDone, TDelete> : BaseCommand
        where TList : ICommand
        where TCreate : ICommand
        where TAppend : ICommand
        where TTag : ICommand
        where TDone : ICommand
        where TDelete : ICommand
    {
        protected TList list;
        protected TCreate create;
        protected TAppend append;
        protected TTag tag;
        protected TDone done;
        protected TDelete delete;

        public BaseBrokerCommand(string cmdName, string tagName, TList list, TCreate create, TAppend append, TTag tag, TDone done, TDelete delete, IConsoleFacade console, ICachedNoteStore note, IGTDConfiguration gConfig)
            : base(cmdName, tagName, console, note, gConfig)
        {
            this.list = list;
            this.create = create;
            this.append = append;
            this.tag = tag;
            this.done = done;
            this.delete = delete;
        }

        public override void Execute(IEnumerable<string> parameters)
        {
            switch (parameters.Count())
            {
                case 0:
                    list.Execute(parameters);
                    break;
                default:
                    var firstParam = parameters.First().Trim().ToLower();
                    switch (firstParam)
                    {
                        case "+":
                        case "create":
                            create.Execute(parameters.Skip(1));
                            return;
                        case "=":
                        case "append":
                            append.Execute(parameters.Skip(1));
                            return;
                        case "==":
                        case "tag":
                            tag.Execute(parameters.Skip(1));
                            return;
                        case "-":
                        case "done":
                            done.Execute(parameters.Skip(1));
                            return;
                        case "--":
                        case "del":
                            delete.Execute(parameters.Skip(1));
                            return;
                        case "?":
                        case "list":
                            list.Execute(parameters.Skip(1));
                            return;
                        default:
                            console.WriteLine("Unknown sub command for {0}.", tagName);
                            return;
                    }
            }
        }

    }
}
