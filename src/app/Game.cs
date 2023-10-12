using System;
using System.Collections.Generic;
using WorldWarBass.State;

namespace WorldWarBass.Abstraction;

// The Whole idea behind this is that the client extends it, puts some things in there and can run it.
public abstract class Game {

    protected GameState _gameState;
    protected bool _isRunning = false;

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
    public abstract void Start();

    /// <summary>
    /// Called inbetween every action, updates the game state
    /// </summary>
    public abstract void Update(); 

}