namespace AVA.EDDI
{
    class Variables
    {
        private readonly string scope;

        public Variables() { scope = ""; }
        public Variables(string scope) { this.scope = $"{scope} "; }

        public bool Bool(string name) { return VA.Proxy.Latest.GetBoolean($"{scope}{name}") ?? false; }
        public int Int(string name) { return VA.Proxy.Latest.GetInt($"{scope}{name}") ?? 0; }
        public decimal Decimal(string name) { return VA.Proxy.Latest.GetDecimal($"{scope}{name}") ?? 0; }
        public string String(string name) { return VA.Proxy.Latest.GetText($"{scope}{name}") ?? ""; }

        public static readonly Commander Commander = new Commander(new Variables());
        public static readonly Status Status = new Status(new Variables("Status"));
    }

    class Commander
    {
        public string Name => variables.String("Name");
        public string HomeSystem => variables.String("Home system");

        private readonly Variables variables;
        public Commander(Variables variables) { this.variables = variables; }
    }

    class Status
    {
        public decimal Fuel => variables.Decimal("fuel");

        private readonly Variables variables;
        public Status(Variables variables) { this.variables = variables; }
    }
}
