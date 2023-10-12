using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorldWarBass.Abstraction;
using WorldWarBass.State;
using WorldWarBass.CountryAbstractions;

namespace WorldWarBass.Main;


/// <summary>
/// The main class, the entry point for the game.
/// </summary>
public class WorldWarBass : Game {

    public WorldWarBass(GameState gameState) : base(gameState) {}

    public override void Start() {
        this._isRunning = true;        

        while (this._isRunning) {
            this.Update();
        }
    }

    public override void Update() {
        // implement this later.
    }


}

public class Client {

        // Goal is to literally just make WorldWarBass obj and call start on it.
        public static void Main(string[] args) {
            
            

            new WorldWarBass(new GameState(CountryName.UnitedStates)).Start();

        }

}