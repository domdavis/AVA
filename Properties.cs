using System;
using System.Collections.Generic;

namespace AVA
{
    class Properties
    {
        public static readonly string Name = "A.V.A.";
        public static readonly string Version = "v0.1.0";
        public static readonly string Info = "A.V.A.: Auxilliary Voice Assistent";
        public static readonly string SpokenName = " (name) ";

        public static readonly List<Func<IModule>> modules = new List<Func<IModule>>
        {
           () => { return new Audio(); },
           () => { return new Module.EDDI(); },
           () => { return new Module.Navigation(); },
           () => { return new Module.Session(); },
        };

        public static readonly Dictionary<string, string> StandardReplacements = new Dictionary<string, string>()
        {
            { "0", " zero " },
            { "1", " one " },
            { "2", " two " },
            { "3", " three " },
            { "4", " four " },
            { "5", " five " },
            { "6", " six " },
            { "7", " seven " },
            { "8", " eight " },
            { "9", " nine " },
            { "-", " dash " },
            { "\\bCol\\b", " coll " },
            { "\\b[Ee][Nn]\\b", "on" },
            { "\\b(name)\\b", " ayva " },
        };
    }
}
