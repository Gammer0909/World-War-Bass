using WorldWarBass.CountryAbstractions;
using WorldWarBass.State;

namespace WorldWarBass.Abstraction;

/// <summary>
/// An abstraction to hold the data for the attack.
/// </summary>
public struct AttackInfo {
    /// <summary>
    /// The country that is attacking.
    /// </summary>
    public Country _countryToAttack;
    /// <summary>
    /// The country that is being attacked.
    /// </summary>
    public PlayerCountry _playerCountry;
    /// <summary>
    /// Does the attack succeed?
    /// </summary>
    public bool _isSuccessful;

    /// <summary>
    /// Creates a new attack info struct.
    /// </summary>
    /// <param name="countryToAttack">The country that is attacking.</param>
    /// <param name="playerCountry">The country that is being attacked.</param>
    /// <param name="isSuccessful">Does the attack succeed?</param>);
    public AttackInfo(Country countryToAttack, PlayerCountry playerCountry, bool isSuccessful) {
        this._countryToAttack = countryToAttack;
        this._playerCountry = playerCountry;
        this._isSuccessful = isSuccessful;
    }

}