﻿using ATL.Logging;

namespace ATL.test
{
    public class ConsoleLogger : ILogDevice
    {
        Log theLog = new Log();
        long previousTimestamp = 0;

        public ConsoleLogger()
        {
            LogDelegator.SetLog(ref theLog);
            theLog.Register(this);
        }

        public void DoLog(Log.LogItem anItem)
        {
            long delta_ms = (anItem.When.Ticks - previousTimestamp) / 10000; // Difference between last logging message, in ms
            System.Console.WriteLine(anItem.Message + " ["+delta_ms+"]");

            previousTimestamp = anItem.When.Ticks;
        }
    }
}