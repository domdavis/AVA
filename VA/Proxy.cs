using System;
using System.Collections.Concurrent;

namespace AVA.VA
{
    public class Proxy
    {
        readonly dynamic vaProxy;

        static readonly byte data = 0;
        static ConcurrentDictionary<string, byte> warnings = new ConcurrentDictionary<string, byte>();

        public static Proxy Global;

        public Proxy(dynamic vaProxy) { this.vaProxy = vaProxy; }

        public string Context() { return vaProxy.Context; }

        public bool? GetBoolean(string name) { return vaProxy.GetBoolean(name); }
        public void SetBoolean(string name, bool? value) { vaProxy.SetBoolean(name, value); }

        public int? GetInt(string name) { return vaProxy.GetInt(name); }
        public void SetInt(string name, int? value) { vaProxy.SetInt(name, value); }

        public decimal? GetDecimal(string name) { return vaProxy.GetDecimal(name); }
        public void SetDecimal(string name, decimal? value) { vaProxy.SetDecimal(name, value); }

        public string GetText(string name) { return vaProxy.GetText(name); }
        public void SetText(string name, string value) { vaProxy.SetText(name, value); }
        public string ParseTokens(string value) { return vaProxy.ParseTokens(value); }

        public DateTime? GetDate(string name) { return vaProxy.GetDate(name); }
        public void SetDate(string name, DateTime? value) { vaProxy.SetDate(name); }

        public bool CommandExists(string cmd) { return vaProxy.CommandExists(cmd); }
        public bool CommandActive(string cmd) { return vaProxy.CommandActive(cmd); }
        public void ExecuteCommand(string cmd) { ExecuteCommand(cmd, true);}

        public void ExecuteCommand(string cmd, bool wait)
        {
            if (!CommandExists(cmd))
            {
                if (!warnings.ContainsKey(cmd))
                {
                    Log.Error($"Missing command: {cmd}");
                    warnings[cmd] = data;
                }
                return;
            }

            vaProxy.ExecuteCommand(cmd, wait);
        }

        public void WriteToLog(string msg, string colour)
        {
            vaProxy.WriteToLog($"[{DateTime.Now.ToString("HH:mm:ss")}] {Properties.Name}: {msg}", colour);
        }

    }
}
