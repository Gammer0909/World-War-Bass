using System;
using System.Collections.Generic;

namespace WorldWarBass.CountryAbstractions;

/// <summary>
///  The country class, a data abstraction to represent the countries in the game.
/// </summary>
public class Country {

    /// <summary>
    /// The list of countries that are allied with this country.
    /// </summary>
    public List<Country> _alliedCountries { get; set; }

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

    /// <summary>
    /// Creates a new country with the given name.
    /// </summary>
    /// <param name="name">The countryname of the country.</param>
    public Country(CountryName name) {
        if (this._alliedCountries == null) {
            this._alliedCountries = new List<Country>();
        }
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
    /// Adds an ally to the ally list.
    /// </summary>
    /// <param name="countryToAdd">the country to add to the ally list</param>
    public void AddAlly(Country countryToAdd) {
        this._alliedCountries.Add(countryToAdd);
    }

    /// <summary>
    /// Checks if an attack can happen on the given country.
    /// </summary>
    /// <param name="countryToAttack">the country that we should see if we can attack</param>
    public bool CanAttack(Country countryToAttack) {

        if (this._troopCount >= countryToAttack.GetTroopCount()) {
            return true;
        } else {
            return false;
        }

    }

    public void Attack(Country countryToAttack) {
        if (this.CanAttack(countryToAttack)) {
            int previousTroopCount = this._troopCount;
            this._troopCount -= countryToAttack.GetTroopCount();
            countryToAttack.RemoveTroops(previousTroopCount);
            // Also substract the opponents troops
            
        }
    }

    /// <summary>
    /// Checks if the country is allied with the given country.
    /// </summary>
    /// <param name="countryToCheck">the country to check if it is allied with this country</param>
    public bool IsAlliedWith(Country countryToCheck) {
        if (this._alliedCountries.Contains(countryToCheck)) {
            return true;
        } else {
            return false;
        }
    }

    /// <summary>
    /// Checks if the country is destroyed.
    /// </summary>
    public bool IsDestroyed() {
        if (this._troopCount <= 0) {
            return true;
        } else {
            return false;
        }
    }

    /// <summary>
    /// A method to add money to the money count.
    /// </summary>
    /// <param name="amount">the amount to add to the money count</param>
    public void AddMoney(int amount) {
        this._money += amount;
    }

    /// <summary>
    /// Removes money from the money count.
    /// </summary>
    /// <param name="amount"></param>
    public void RemoveMoney(int amount) {
        this._money -= amount;
    }

    /// <summary>
    /// Adds troops to the troopcount.
    /// </summary>
    /// <param name="amount">the amount of troops to add to the troopcount</param>
    public void AddTroops(int amount) {
        this._troopCount += amount;
    }

    /// <summary>
    /// Removes troops from the troopcount.
    /// </summary>
    /// <param name="amount"></param>
    public void RemoveTroops(int amount) {
        this._money -= amount;
    }

    /// <summary>
    /// A method to get the amount of money the country has.
    /// </summary>
    /// <returns>The amount of money the country has.</returns>
    public int GetMoney() {
        return this._money;
    }

    /// <summary>
    /// Gets the amount of troops the country has.
    /// </summary>
    /// <returns>The amount of troops the country has.</returns>
    public int GetTroopCount() {
        return this._troopCount;
    }

    /// <summary>
    /// Gets the CountryName of this.
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
    Russia,
    NULL
};