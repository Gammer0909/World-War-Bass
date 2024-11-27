using System;
using System.ComponentModel;
using Gammer0909.WorldWarBass.Enums;

namespace Gammer0909.WorldWarBass.Data;

public class Country {
    string name { get; set; }
    Nationality nationality { get; set; }
    int troopCount = 100;
    int countryFunds = 100;
    int taxRate = 1;

    public Country(string name, Nationality nation) {

        this.name = name;
        this.nationality = nation;
        (int troop, int funds) boost = GetBoost();
        this.troopCount += boost.troop;
        this.countryFunds += boost.funds;

    }

    private (int, int) GetBoost() {
        switch(this.nationality) {
            case Nationality.Britain:
                return (-15, 15);
            case Nationality.Russia:
                return (25, -10);
            case Nationality.France:
                return (10, -5);
            case Nationality.Italy:
                return (10, 0);
            case Nationality.Germany:
                return (15, 10);
            case Nationality.UnitedStates:
                return (5, 5);
        }
        return (0, 0);
    }

    public int GetTroopCount() {
        return this.troopCount;
    }

    public void AddTroops(int amount) {
        this.troopCount += amount;
    }

    public int GetTaxRate() {
        return this.taxRate;
    }

    public void IncreaseTax() {
        this.taxRate += 2;
    }

    public int GetFunds() {
        return this.countryFunds;
    }

    public void AddFunds() {
        this.countryFunds += taxRate;
    }
}