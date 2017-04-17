using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.CUI
{
    /// <summary>
    /// Listener of event
    /// </summary>
    class FirstListener
    {
        /// <summary>
        /// Blank constructor
        /// </summary>
        public FirstListener() { }
        
        /// <summary>
        /// Subscribes the listener to the event
        /// </summary>
        /// <param name="timer">The object for subscribing</param>
        public void Register(Timer timer)
        {
            timer.StopTimer += PersonMsg;
        }
        /// <summary>
        /// Unsubscribes the listener to the event
        /// </summary>
        /// <param name="timer">The object for unsubscribing</param>
        public void Unregister(Timer timer)
        {
            timer.StopTimer -= PersonMsg;
        }

        /// <summary>
        /// Function for invoking when event occurs 
        /// </summary>
        /// <param name="sender">Source of event</param>
        /// <param name="eventArgs">Event data</param>
        private void PersonMsg(object sender, StopTimerEventArgs eventArgs)
        {
            Console.WriteLine($"{this.GetType().Name} says \"Hello\" after {eventArgs.Time} seconds");
        }
    }
}
