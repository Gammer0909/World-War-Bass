using System;
using Gammer0909.WorldWarBass.Abstractions;
using Gammer0909.WorldWarBass.Enums;
using Gammer0909.WorldWarBass.Data;


namespace Gammer0909.WorldWarBass.Control;

public class PlayerControl : Player
{
    protected override Country self { get; set; }
    protected override int defenseValue { get; set; }

    public PlayerControl(Country c) {
        this.self = c;
        this.defenseValue = 10;
    }

    public override BattleResult LaunchAttack(Player opp) {
        BattleResult result = BattleResult.Lost;
        if (opp.GetDefenseValue() > this.defenseValue) {
            result = BattleResult.Won;
        } else if (opp.GetDefenseValue() == this.defenseValue) {
            // Flip a coin, because i'm too lazy to find a better way to do this
            int coinResult = new Random().Next(0, 1);
            if (coinResult == 0) {
                result = BattleResult.CloseWin;
            } else if (coinResult == 1) {
                result = BattleResult.CloseLoss;
            }
        }
        return result;
    }

    public override void UpgradeDefense() {
        this.defenseValue += 5;
    }

    public override void DraftTroops() {
        int draftAmount = defenseValue / 2;
        this.defenseValue -= draftAmount / 2;
        this.self.AddTroops(draftAmount);
    }

    public override void RunTax() {
        this.self.AddFunds();
    }
}