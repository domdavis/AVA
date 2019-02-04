using System;

namespace AVA
{
    public class Plugin
    {
        public static string VA_DisplayName() { return $"{Properties.Name} - {Properties.Version}"; }
        public static string VA_DisplayInfo() { return Properties.Info; }
        public static Guid VA_Id() { return new Guid("{247F22F1-CCFC-4A2A-A91B-631A82D7F4DF}"); }

        public static void VA_StopCommand()
        {
            new StopCommandEvent();
        }

        public static void VA_Init1(dynamic vaProxy)
        {
            VA.Proxy.Global = new VA.Proxy(vaProxy);
            VA.Log.Debug($"Registering {EDDI.Events.Monitors.Count} EDDI Monitors");
            foreach (Action register in EDDI.Events.Monitors) register();
            foreach (Func<IModule> register in Properties.modules) VA.Log.Debug($"Loading {register().GetType()}");
            new InitPluginEvent();
            VA.Log.Success($"{Properties.Info} ({Properties.Version}) online...");
        }

        public static void VA_Exit1(dynamic vaProxy)
        {
            new ExitPluginEvent();
            VA.Log.Error($"{Properties.Name} Terminated");
        }

        public static void VA_Invoke1(dynamic vaProxy)
        {
            VA.Proxy proxy = new VA.Proxy(vaProxy);
            VA.Dispatcher.Instance.Dispatch(new VA.Message(proxy));
        }
    }

    class InitPluginEvent : Dispatchable<InitPluginEvent> { public InitPluginEvent() { Dispatch(this); } }
    class StopCommandEvent : Dispatchable<StopCommandEvent> { public StopCommandEvent() { Dispatch(this); } }
    class ExitPluginEvent : Dispatchable<ExitPluginEvent> { public ExitPluginEvent() { Dispatch(this); } }
}
