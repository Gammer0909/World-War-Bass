using System;
using System.Collections.Generic;

namespace WorldWarBass.Game.CountryAbstractions;

/// <summary>
///  The country class, a data abstraction to represent the countries in the game.
/// </summary>
public class Country {

    /// <summary>
    /// The name of the country.
    /// </summary>
    private CountryName _name { get; set; }

    /// <summary>
    /// The amount of troops the country has.
    /// </summary>
    private int _troopCount = 0;

    /// <summary>
    /// The amount of money the country has.
    /// </summary>
    private int _money = 0;

    public Country(CountryName name) {
        this._name = name;
        switch (this._name) {
            case CountryName.UnitedStates:
                this._troopCount = 100;
                this._money = 100;
                break;
            case CountryName.UnitedKingdom:
                this._troopCount = 50;
                this._money = 125;
                break;
            case CountryName.France:
                this._troopCount = 75;
                this._money = 75;
                break;
            case CountryName.Germany:
                this._troopCount = 75;
                this._money = 150;
                break;
            case CountryName.Russia:
                this._troopCount = 200;
                this._money = 50;
                break;

            
        }
    }

    /// <summary>
    ///  The method to get the amount of troops the country has.
    /// </summary>
    /// <returns>The CountryName of this</returns>
    public CountryName GetName() {
        return this._name;
    }

}


/// <summary>
/// The country enum, a data abstraction to represent the countries in the game.
/// </summary>
public enum CountryName {
    UnitedStates,
    UnitedKingdom,
    France,
    Germany,
    Russia
};