namespace AVA.VA
{
    class Log
    {
        public enum Level { Debug, Info, Warn, Error }
        public static Level Output = Level.Debug;

        public static void Debug(string msg)
        {
            if (Proxy.Global == null) return;
            if (Output <= Level.Debug) Proxy.Global.WriteToLog(msg, "grey");
        }

        public static void Info(string msg)
        {
            if (Proxy.Global == null) return;
            if (Output <= Level.Info) Proxy.Global.WriteToLog(msg, "blue");
        }

        public static void Warn(string msg)
        {
            if (Proxy.Global == null) return;
            if (Output <= Level.Warn) Proxy.Global.WriteToLog(msg, "yellow");
        }

        public static void Error(string msg)
        {
            if (Proxy.Global == null) return;
            Proxy.Global.WriteToLog(msg, "red");
        }

        public static void Success(string msg)
        {
            if (Proxy.Global == null) return;
            Proxy.Global.WriteToLog(msg, "green");
        }
    }
}
