using System;
using System.Collections.Generic;
using WorldWarBass.CountryAbstractions;

namespace WorldWarBass.CountryAbstractions;

// Woohoo for abstraction!
/// <summary>
/// An Abstraction for the Player's country, to easier manage the player's country, like allies and enemies, etc.
/// </summary>
public class PlayerCountry : Country {

    /// <summary>
    /// The list of countries that are opposing the player's country.
    /// </summary>
    private List<Country> _opposingCountries;

    public PlayerCountry(CountryName name) : base(name) {

        // Initialize the opposing countries list.
        if (this._opposingCountries == null) {
            this._opposingCountries = new List<Country>();
        }

        // Other things as I need them
        for (int i = 0; i < 5; i++) {
            this._opposingCountries.Add(new Country((CountryName)i));
        }

        // Make sure the player's country isn't in the opposing countries list
        for (int i = 0; i < _opposingCountries.Count; i++) {
            if (this._opposingCountries[i].GetName() == this.GetName()) {
                this._opposingCountries.RemoveAt(i); // Remove the player's country from the opposing countries list
            }
        }

        // Initialize the allied countries list.
        if (this._alliedCountries == null) {
            this._alliedCountries = new List<Country>();
        }
        
    }
}