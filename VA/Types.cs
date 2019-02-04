using System.Collections.Generic;

namespace AVA.VA
{
    abstract class Type
    {
        protected string Name { get => Name.ToLower(); set => Name = value; }
        public Type(string name) { Name = name; }
        public abstract void Handle(Message msg);
    }

    class Bool : Type
    {
        public bool Value;
        public Bool(string name) : base(name) { }
        public override void Handle(Message msg) { Value = msg.Bool(Name); }
    }

    class Int : Type
    {
        public int Value;
        public Int(string name) : base(name) { }
        public override void Handle(Message msg) { Value = msg.Int(Name); }
    }

    class Decimal : Type
    {
        public decimal Value;
        public Decimal(string name) : base(name) { }
        public override void Handle(Message msg) { Value = msg.Decimal(Name); }
    }

    class String : Type
    {
        public string Value;
        public String(string name) : base(name) { }
        public override void Handle(Message msg) { Value = msg.String(Name); }
    }

    class Value
    {
        private readonly IDictionary<string, Type> registered = new Dictionary<string, Type>();

        public bool Get(bool _, string name)
        {
            if (!registered.ContainsKey(name)) registered[name] = new Bool(name);
            return ((Bool)registered[name]).Value;
        }

        public int Get(int _, string name)
        {
            if (!registered.ContainsKey(name)) registered[name] = new Int(name);
            return ((Int)registered[name]).Value;
        }

        public decimal Get(decimal _, string name)
        {
            if (!registered.ContainsKey(name)) registered[name] = new Decimal(name);
            return ((Decimal)registered[name]).Value;
        }

        public string Get(string _, string name)
        {
            if (!registered.ContainsKey(name)) registered[name] = new String(name);
            return ((String)registered[name]).Value;
        }

        public void Set(Message msg)
        {
            foreach (Type value in registered.Values) value.Handle(msg);
        }
    }
}
