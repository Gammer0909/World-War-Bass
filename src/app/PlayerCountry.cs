using System;
using System.Collections.Generic;
using WorldWarBass.Game.CountryAbstractions;

namespace WorldWarBass.Game.CountryAbstractions;
// Woohoo for abstraction!
/// <summary>
/// An Abstraction for the Player's country, to easier manage the player's country, like allies and enemies, etc.
/// </summary>
public class PlayerCountry : Country {

    /// <summary>
    /// The list of countries that are opposing the player's country.
    /// </summary>
    private List<Country> _opposingCountries;
    
    /// <summary>
    /// The list of countries that are allied with the player's country.
    /// </summary>
    private List<Country> _alliedCountries;

    public PlayerCountry(CountryName name) : base(name) {

        if (this._opposingCountries == null) {
            this._opposingCountries = new List<Country>();
        }

        // Other things as I need them
        for (int i = 0; i < 5; i++) {
            this._opposingCountries.Add(new Country((CountryName)i));
        }

        for (int i = 0; i < 5; i++) {
            if (this._opposingCountries[i].GetName() == this.GetName()) {
                this._opposingCountries.RemoveAt(i); // Remove the player's country from the opposing countries list
            }
        }

        if (this._alliedCountries == null) {
            this._alliedCountries = new List<Country>();
        }
    }
}