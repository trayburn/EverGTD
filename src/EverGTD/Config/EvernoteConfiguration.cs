
using System;
using Evernote;
using EvernoteSharp;
using System.Configuration;
namespace EverGTD
{
    public class EvernoteConfiguration : IEvernoteConfiguration
    {
        public Uri Server
        {
            get
            {
                return new Uri("https://www.evernote.com/");
            }
        }

        public string ConsumerKey
        {
            get
            {
                return "trayburn";
            }
        }

        public string ConsumerSecret
        {
            get
            {
                return "e8deaf77eaaa74c4";
            }
        }

        public string UserName
        {
            get
            {
                return ConfigurationManager.AppSettings["Username"];
            }
        }

        public string Password
        {
            get
            {
                return ConfigurationManager.AppSettings["Password"];
            }
        }
    }
}
