using System;
using Gammer0909.WorldWarBass.Data;
using Gammer0909.WorldWarBass.Enums;

namespace Gammer0909.WorldWarBass.Abstractions;

public abstract class Player {
    protected abstract Country self { get; set; }
    protected abstract int defenseValue { get; set; }

    public abstract BattleResult LaunchAttack(Player opp);

    public abstract void UpgradeDefense();

    public abstract void DraftTroops();

    public abstract void RunTax();

    public int GetDefenseValue() {
        return this.defenseValue;
    }
}