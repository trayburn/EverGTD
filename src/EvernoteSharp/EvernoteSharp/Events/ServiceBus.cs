using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace EvernoteSharp.Events
{
    internal class ServiceBus
    {
        public delegate void callbackDelegate<T>(T eventInfo) where T : AbstractEvent;

        /// <summary>
        /// add a subscriber for events of type T.
        /// </summary>
        public void AddSubscriber<T>(callbackDelegate<T> handler) where T : AbstractEvent
        {
            getSubscribers<T>().Add(handler);
        }

        private IDictionary<Type, IList> subscribers = new Dictionary<Type, IList>();

        /// <summary>
        /// get the list of subscribers for a particular event
        /// </summary>
        private IList getSubscribers<T>() where T : AbstractEvent
        {
            if (!subscribers.ContainsKey(typeof(T)))
                subscribers.Add(typeof(T), new System.Collections.ArrayList());

            return subscribers[typeof(T)];
        }

        /// <summary>
        /// publish an event of type T to all subscribers of this type
        /// </summary>
        public void Publish<T>(T eventInfo) where T : AbstractEvent
        {
            foreach (var subscriber in (from object s in getSubscribers<T>() where s is callbackDelegate<T> select s as callbackDelegate<T>)) {
                subscriber.Invoke(eventInfo);
            }
        }
    }
}
