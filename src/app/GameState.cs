using System;
using System.Collections.Generic;
using System.Linq;
using WorldWarBass.CountryAbstractions;
using WorldWarBass.State;

namespace WorldWarBass.State;

/// <summary>
///  The game state class, a data abstraction to represent the state of the game.
/// </summary>
public class GameState {

    public bool hasLost = false;
    public bool hasWon = false;


    private PlayerCountry _playerCountry;

    public GameState(CountryName playerCountryName) {
        this._playerCountry = new PlayerCountry(playerCountryName);
    }

    public PlayerCountry GetPlayerCountry() {
        return this._playerCountry;
    }
}