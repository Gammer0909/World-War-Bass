using System;
using System.Collections.Generic;
using WorldWarBass.Game.State;

namespace WorldWarBass.Abstraction;

// The Whole idea behind this is that the client extends it, puts some things in there and can run it.
public class Game {

    GameState _gameState;
    bool _isRunning = false;

    /// <summary>
    /// The constructor for the game, takes a game state as a parameter.
    /// </summary>
    /// <param name="gameState"></param>
    public Game(GameState gameState) {
        this._gameState = gameState;
    }
        

    /// <summary>
    /// The start method, called when the game starts, used to initialize the game state.
    /// </summary>
    public virtual void Start() {

        // Nothing to do currently
        while (this._isRunning) {

            // Update the game state
            this.Update();

        }

    }

    public virtual void Update() {

        // Nothing to do currently

    }

}