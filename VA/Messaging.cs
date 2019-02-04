using System;
using System.Collections.Generic;

namespace AVA.VA
{
    interface IMonitor
    {
        void Handle(Message msg);
    }

    class Message
    {
        public readonly string Name;

        private readonly string scope;
        private readonly Proxy voiceAttack;

        private static readonly IDictionary<string, string> replacements = new Dictionary<string, string>
        {
            {"eddi", "EDDI" },
            {"ava", "AVA" },
        };

        public Message(Proxy voiceAttack)
        {
            this.voiceAttack = voiceAttack;
            string name = voiceAttack.Context();

            foreach (KeyValuePair<string, string> replacement in replacements)
            {
                name = name.Replace(replacement.Key, replacement.Value);
            }

            Name = name;
            scope = name.Replace("((", "").Replace("))", "");
            
        }

        public bool Bool(string name) { return voiceAttack.GetBoolean($"{scope} {name}") ?? false; }
        public int Int(string name) { return voiceAttack.GetInt($"{scope} {name}") ?? 0; }
        public decimal Decimal(string name) { return voiceAttack.GetDecimal($"{scope} {name}") ?? 0; }
        public string String(string name) { return voiceAttack.GetText($"{scope} {name}") ?? ""; }
    }

    class Dispatcher
    {
        public static readonly Dispatcher Instance = new Dispatcher();

        private IDictionary<string, IMonitor> handlers = new Dictionary<string, IMonitor> { };

        public void Register(string msg, IMonitor handler) { handlers[msg] = handler; }
 
        public bool Dispatch(Message msg)
        {
            if (handlers.ContainsKey(msg.Name)) handlers[msg.Name].Handle(msg);
            return handlers.ContainsKey(msg.Name);
        }
    }

    class Listener<T> : IMonitor where T : Event, new()
    {
        public Listener() { Dispatcher.Instance.Register(new T().Name, this); }

        public void Handle(Message msg) {
            T e = new T();
            e.Handle(msg);
            Dispatcher<T>.Instance.Dispatch(e);
        }
    }

    abstract class Event
    {
        public abstract string Name { get; }
        protected Value value = new Value();
        public void Handle(Message msg) { value.Set(msg); }
    }
    
}
