using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1
{
    #region StopTimerEventArgs
    /// <summary>
    /// Class that contains event data
    /// </summary>
    public sealed class StopTimerEventArgs : EventArgs
    {
        /// <summary>
        /// Waiting time
        /// </summary>
        private int time;

        /// <summary>
        /// Property for time variable
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Time is negative value</exception>
        public int Time
        {
            get { return time; }
            private set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Time is negative");
                time = value;
            }
        }


        /// <summary>
        /// Initializes StopTimerEventArgs instance with specified time
        /// </summary>
        /// <param name="seconds">Waiting time</param>
        public StopTimerEventArgs(int seconds)
        {
            this.time = seconds;
        }

        
    }
    #endregion


    #region Timer
    /// <summary>
    /// Provides timer functionality
    /// </summary>
    public sealed class Timer
    {
        /// <summary>
        /// Contains listeners' methods to invoke
        /// </summary>
        public event EventHandler<StopTimerEventArgs> StopTimer = delegate { };

        /// <summary>
        /// Invokes listeners' methods
        /// </summary>
        /// <param name="e">Contains event data</param>
        private void OnStopTime(StopTimerEventArgs e)
        {
            EventHandler<StopTimerEventArgs> temp = StopTimer;
            temp?.Invoke(this, e);
        }

        /// <summary>
        /// Runs timer
        /// </summary>
        /// <param name="seconds">Waiting number of seconds</param>
        public void StartTimer(int seconds)
        {
            Thread.Sleep(1000 * seconds);
            OnStopTime(new StopTimerEventArgs(seconds));
        }

    }
}
#endregion
