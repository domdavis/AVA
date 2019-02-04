using System;
using System.Collections.Generic;

namespace AVA.EDDI
{
    class CommanderContinuedEvent : VA.Event
    {
        public override string Name { get => "((EDDI commander continued))"; }

        public static readonly string ModeOpen = "Open";
        public static readonly string ModeGroup = "Group";
        public static readonly string ModeSolo = "Solo";

        public string Commander => value.Get(Commander, nameof(Commander));
        public decimal Credits => value.Get(Credits, nameof(Credits));
        public decimal Fuel => value.Get(Fuel, nameof(Fuel));
        public decimal FuelCapacity => value.Get(FuelCapacity, nameof(FuelCapacity));
        public string Group => value.Get(Group, nameof(Group));
        public decimal Loan => value.Get(Loan, nameof(Loan));
        public string Mode => value.Get(Mode, nameof(Mode));
        public string Ship => value.Get(Ship, nameof(Ship));
        public int ShipID => value.Get(ShipID, nameof(ShipID));
    }

    class FileHeaderEvent : VA.Event
    {
        public override string Name { get => "((EDDI file header))"; }

        public string Build => value.Get(Build, nameof(Build));
        public string Version => value.Get(Version, nameof(Version));
    }

    class FSDEngagedEvent : VA.Event
    {
        public override string Name { get => "((EDDI fsd engaged))"; }

        public static readonly string Supercruise = "Supercruise";
        public static readonly string Hyperspace = "Hyperspace";

        public string StellarClass => value.Get(StellarClass, nameof(StellarClass));
        public string System => value.Get(System, nameof(System));
        public string Target => value.Get(Target, nameof(Target));
    }

    class InitialisedEvent : VA.Event
    {
        public override string Name { get => "((EDDI va initialized))"; }
    }

    class LocationEvent : VA.Event
    {
        public override string Name { get => "((EDDI location))"; }

        public string Allegiance => value.Get(Allegiance, nameof(Allegiance));
        public string Body => value.Get(Body, nameof(Body));
        public string BodyType => value.Get(BodyType, nameof(BodyType));
        public bool Docked => value.Get(Docked, nameof(Docked));
        public string Economy => value.Get(Economy, nameof(Economy));
        public string SecondaryEconomy => value.Get(SecondaryEconomy, "economy2");
        public string Faction => value.Get(Faction, nameof(Faction));
        public string Government => value.Get(Government, nameof(Government));
        public decimal Latitude => value.Get(Latitude, nameof(Latitude));
        public decimal Longitude => value.Get(Longitude, nameof(Longitude));
        public decimal MarketID => value.Get(MarketID, nameof(MarketID));
        public decimal Population => value.Get(Population, nameof(Population));
        public string Security => value.Get(Security, nameof(Security));
        public string Station => value.Get(Station, nameof(Station));
        public string StationFaction => value.Get(StationFaction, nameof(StationFaction));
        public string StationGovernment => value.Get(StationGovernment, nameof(StationGovernment));
        public string StationState => value.Get(StationState, nameof(StationState));
        public string StationType => value.Get(StationType, nameof(StationType));
        public string System => value.Get(System, nameof(System));
        public string SystemFaction => value.Get(SystemFaction, nameof(SystemFaction));
        public string SystemGovernment => value.Get(SystemGovernment, nameof(SystemGovernment));
        public string SystemState => value.Get(SystemState, nameof(SystemState));
        public decimal X => value.Get(X, nameof(X));
        public decimal Y => value.Get(Y, nameof(Y));
        public decimal Z => value.Get(Z, nameof(Z));
    }

    class ShipLoadoutEvent : VA.Event
    {
        public override string Name { get => "((EDDI ship loadout)))"; }

        public bool Hot => value.Get(Hot, nameof(Hot));
        public decimal HullHealth => value.Get(HullHealth, nameof(HullHealth));
        public decimal HullValue => value.Get(HullValue, nameof(HullValue));
        public decimal ModulesValue => value.Get(ModulesValue, nameof(ModulesValue));
        public string PaintJob => value.Get(PaintJob, nameof(PaintJob));
        public decimal Rebuy => value.Get(Rebuy, nameof(Rebuy));
        public string Ship => value.Get(Ship, nameof(Ship));
        public int ShipID => value.Get(ShipID, nameof(ShipID));
        public string ShipIdent => value.Get(ShipIdent, nameof(ShipIdent));
        public string ShipName => value.Get(ShipName, nameof(ShipName));
        public decimal Value => value.Get(Value, nameof(Value));
    }

    class ShipRebootedEvent : VA.Event
    {
        public override string Name { get => "((EDDI ship rebooted))"; }
    }

    class ShutdownEvent : VA.Event
    {
        public override string Name { get => "((EDDI shutdown))"; }
    }

    class UnhandledEvent : VA.Event
    {
        public override string Name { get => "((EDDI unhandled event))"; }
    }

    static class Events
    {
        public readonly static List<Action> Monitors = new List<Action>
        {
            () => { new VA.Listener<CommanderContinuedEvent>(); },
            () => { new VA.Listener<FileHeaderEvent>(); },
            () => { new VA.Listener<FSDEngagedEvent>(); },
            () => { new VA.Listener<InitialisedEvent>(); },
            () => { new VA.Listener<LocationEvent>(); },
            () => { new VA.Listener<ShipLoadoutEvent>(); },
            () => { new VA.Listener<ShipRebootedEvent>(); },
            () => { new VA.Listener<ShutdownEvent>(); },
            () => { new VA.Listener<UnhandledEvent>(); },
        };
    }
}
