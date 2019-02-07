using System;
using System.Collections.Generic;

namespace AVA.EDDI
{
    class ClearedSaveEvent : VA.Event
    {
        public override string Type { get => "((EDDI cleared save))"; }

        public string Name => value.String("name");
    }

    class CommanderContinuedEvent : VA.Event
    {
        public override string Type { get => "((EDDI commander continued))"; }

        public static readonly string ModeOpen = "Open";
        public static readonly string ModeGroup = "Group";
        public static readonly string ModeSolo = "Solo";

        public string Commander => value.String(nameof(Commander));
        public decimal Credits => value.Decimal(nameof(Credits));
        public decimal Fuel => value.Decimal(nameof(Fuel));
        public decimal FuelCapacity => value.Decimal(nameof(FuelCapacity));
        public string Group => value.String(nameof(Group));
        public decimal Loan => value.Decimal(nameof(Loan));
        public string Mode => value.String(nameof(Mode));
        public string Ship => value.String(nameof(Ship));
        public int ShipID => value.Int(nameof(ShipID));
    }

    class EnteredNormalSpaceEvent: VA.Event
    {
        public override string Type { get => "((EDDI entered normal space))"; }

        public string Body => value.String(nameof(Body));
        public string BodyType => value.String(nameof(BodyType));
        public string System => value.String(nameof(System));
    }

    class EnteredSupercruiseEvent : VA.Event
    {
        public override string Type { get => "((EDDI entered supercruise))"; }

        public string System => value.String(nameof(System));
    }

    class FileHeaderEvent : VA.Event
    {
        public override string Type { get => "((EDDI file header))"; }

        public string Build => value.String(nameof(Build));
        public string Version => value.String(nameof(Version));
    }

    class FSDEngagedEvent : VA.Event
    {
        public override string Type { get => "((EDDI fsd engaged))"; }

        public static readonly string Supercruise = "Supercruise";
        public static readonly string Hyperspace = "Hyperspace";

        public string StellarClass => value.String(nameof(StellarClass));
        public string System => value.String(nameof(System));
        public string Target => value.String(nameof(Target));
    }

    class InitialisedEvent : VA.Event
    {
        public override string Type { get => "((EDDI va initialized))"; }
    }

    class JumpedEvent : VA.Event
    {
        public override string Type { get => "((EDDI jumped))"; }


        public string Allegiance => value.String(nameof(Allegiance));
        public decimal Distance => value.Decimal(nameof(Distance));
        public string Economy => value.String(nameof(Economy));
        public string SecondaryEconomy => value.String("economy2");
        public string Faction => value.String(nameof(Faction));
        public string FactionState => value.String(nameof(FactionState));
        public decimal FuelRemaining => value.Decimal(nameof(FuelRemaining));
        public decimal FuelUsed => value.Decimal(nameof(FuelUsed));
        public string Government => value.String(nameof(Government));
        public decimal Population => value.Decimal(nameof(Population));
        public string Security => value.String(nameof(Security));
        public string Star => value.String(nameof(Star));
        public string System => value.String(nameof(System));
        public string SystemFaction => value.String(nameof(SystemFaction));
        public decimal X => value.Decimal(nameof(X));
        public decimal Y => value.Decimal(nameof(Y));
        public decimal Z => value.Decimal(nameof(Z));
    }

    class LandingGear : VA.Event
    {
        public override string Type { get => "((EDDI landing gear))"; }

        public bool Deployed => value.Bool(nameof(Deployed));
    }

    class LocationEvent : VA.Event
    {
        public override string Type { get => "((EDDI location))"; }
        
        public string Allegiance => value.String(nameof(Allegiance));
        public string Body => value.String(nameof(Body));
        public string BodyType => value.String(nameof(BodyType));
        public bool Docked => value.Bool(nameof(Docked));
        public string Economy => value.String(nameof(Economy));
        public string SecondaryEconomy => value.String("economy2");
        public string Faction => value.String(nameof(Faction));
        public string FactionState => value.String(nameof(FactionState));
        public string Government => value.String(nameof(Government));
        public decimal Latitude => value.Decimal(nameof(Latitude));
        public decimal Longitude => value.Decimal(nameof(Longitude));
        public decimal MarketID => value.Decimal(nameof(MarketID));
        public decimal Population => value.Decimal(nameof(Population));
        public string Security => value.String(nameof(Security));
        public string Station => value.String(nameof(Station));
        public string StationFaction => value.String(nameof(StationFaction));
        public string StationGovernment => value.String(nameof(StationGovernment));
        public string StationState => value.String(nameof(StationState));
        public string StationType => value.String(nameof(StationType));
        public string System => value.String(nameof(System));
        public string SystemFaction => value.String(nameof(SystemFaction));
        public string SystemGovernment => value.String(nameof(SystemGovernment));
        public string SystemState => value.String(nameof(SystemState));
        public decimal X => value.Decimal(nameof(X));
        public decimal Y => value.Decimal(nameof(Y));
        public decimal Z => value.Decimal(nameof(Z));
    }

    class ShipFSDEvent : VA.Event
    {
        public override string Type { get => "((EDDI ship fsd))"; }

        public static readonly string Cooldown = "cooldown";
        public static readonly string CooldownComplete = "cooldown complete";
        public static readonly string Charging = "charging";
        public static readonly string ChargingCancelled = "charging cancelled";
        public static readonly string ChargingComplete = "charging complete";
        public static readonly string Masslock = "masslock";
        public static readonly string MasslockCleared = "masslock cleared";

        public string FSDStatus => value.String("fsd_status");
    }

    class ShipLoadoutEvent : VA.Event
    {
        public override string Type { get => "((EDDI ship loadout)))"; }

        public bool Hot => value.Bool(nameof(Hot));
        public decimal HullHealth => value.Decimal(nameof(HullHealth));
        public decimal HullValue => value.Decimal(nameof(HullValue));
        public decimal ModulesValue => value.Decimal(nameof(ModulesValue));
        public string PaintJob => value.String(nameof(PaintJob));
        public decimal Rebuy => value.Decimal(nameof(Rebuy));
        public string Ship => value.String(nameof(Ship));
        public int ShipID => value.Int(nameof(ShipID));
        public string ShipIdent => value.String(nameof(ShipIdent));
        public string ShipName => value.String(nameof(ShipName));
        public decimal Value => value.Decimal(nameof(Value));
    }

    class ShipRebootedEvent : VA.Event
    {
        public override string Type { get => "((EDDI ship rebooted))"; }
    }

    class ShipRefuelledEvent : VA.Event
    {
        public override string Type { get => "((EDDI ship refuelled))"; }

        public static readonly string Market = "Market";
        public static readonly string Scoop = "Scoop";

        public decimal Amount => value.Decimal(nameof(Amount));
        public bool Full => value.Bool(nameof(Full));
        public decimal Price => value.Decimal(nameof(Price));
        public string Source => value.String(nameof(Source));
        public decimal Total => value.Decimal(nameof(Total));
    }

    class ShutdownEvent : VA.Event
    {
        public override string Type { get => "((EDDI shutdown))"; }
    }

    class UnhandledEvent : VA.Event
    {
        public override string Type { get => "((EDDI unhandled event))"; }
    }

    static class Events
    {
        public readonly static List<Action> Monitors = new List<Action>
        {
            () => { new VA.Listener<ClearedSaveEvent>(); },
            () => { new VA.Listener<CommanderContinuedEvent>(); },
            () => { new VA.Listener<EnteredNormalSpaceEvent>(); },
            () => { new VA.Listener<EnteredSupercruiseEvent>(); },
            () => { new VA.Listener<FileHeaderEvent>(); },
            () => { new VA.Listener<FSDEngagedEvent>(); },
            () => { new VA.Listener<InitialisedEvent>(); },
            () => { new VA.Listener<JumpedEvent>(); },
            () => { new VA.Listener<LandingGear>(); },
            () => { new VA.Listener<LocationEvent>(); },
            () => { new VA.Listener<ShipFSDEvent>(); },
            () => { new VA.Listener<ShipLoadoutEvent>(); },
            () => { new VA.Listener<ShipRebootedEvent>(); },
            () => { new VA.Listener<ShipRefuelledEvent>(); },
            () => { new VA.Listener<ShutdownEvent>(); },
            () => { new VA.Listener<UnhandledEvent>(); },
        };
    }
}
