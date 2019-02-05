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
        public Message msg;

        public bool Bool(string name)
        {
            if (msg == null) return false;
            return msg.Bool(name);
        }

        public int Int(string name)
        {
            if (msg == null) return 0;
            return msg.Int(name);
        }

        public decimal Decimal(string name)
        {
            if (msg == null) return 0;
            return msg.Decimal(name);
        }

        public string String(string name)
        {
            if (msg == null) return "";
            return msg.String(name);
        }
    }
}
