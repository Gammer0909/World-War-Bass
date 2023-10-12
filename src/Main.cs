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

    Dictionary<string, string> commandNames;

    public WorldWarBass(GameState gameState) : base(gameState) {

        commandNames = new Dictionary<string, string>();

        commandNames.Add("ATTACK", "Attacks a country of your choosing.");
        commandNames.Add("INVITE", "Invites a country of your choosing to join your alliance.");
        commandNames.Add("RULES", "Displays the rules of the game.");
        commandNames.Add("HELP", "Displays the commands you can use.");
        commandNames.Add("QUIT", "Quits the game.");

    }

    public override void Start() {
        this._isRunning = true;        

        while (this._isRunning) {
            this.Update();
        }
    }

    public override void Update() {
        
        
    }

    private void DisplayUI() {
        Console.Write("Commands are as follows:\n");
        foreach (KeyValuePair<string, string> commandName in commandNames) {
            Console.WriteLine(commandName.Key + ": " + commandName.Value);
        }

        Console.Write("What would you like to do? ");

        
    }

    private string? GetCommand() {
        string? command = Console.ReadLine();
        if (command == null) {
            Console.WriteLine("Invalid command. Please try again.");
            GetCommand();
        }
        return command.ToUpper();
    }


}

public class Client {

        // Goal is to literally just make WorldWarBass obj and call start on it.
        public static void Main(string[] args) {
            
            Console.WriteLine("Welcome to World War Bass!");
            Console.Write("Before we get started, what country are you playing as?\nUnited States\nUnited Kingdom\nFrance\nGermany\nRussia\nType the name of the country you want to play as: ");
            PickCountryName();

            Console.Write("One last thing before getting started, if you want to see the rules, type \"RULES\", otherwise, type \"START\" to start the game.\n[START or RULES]:");
            // I should pull this into a method, however I want the actual prompt method to be all purpose, not just start and rules.
            string? startOrRules = Console.ReadLine();
            while (startOrRules != "START") {
                Console.Write("Invalid Input, please try again.\n[START or RULES]:");
                startOrRules = Console.ReadLine();
                if (startOrRules == "START") {
                    break;
                }
                if (startOrRules.ToUpper() == "RULES") {
                    Console.WriteLine("RULES:\n\nThe goal of the game is to conquer the world. You do this by conquering other countries.\nYou can conquer other countries by invading them, or by having them surrender to you.\nYou can invade a country by attacking it, and then invading it.\nYou can attack a country by sending troops to attack it.\nYou can send troops to attack a country by sending troops to the border of the country you want to attack.\nYou can send troops to the border of a country by sending troops to the border of the country you want to attack.\nYou can send troops to the border of a country by sending troops to the border of the country you want to attack.\nYou can send troops to the border of a country by sending troops to the border of the country you want to attack.\nYou can send troops to the border of a country by sending troops to the border of the country you want to attack.\n\n");
                }
            }
            Console.WriteLine("Starting game, good luck conquerer!");


            new WorldWarBass(new GameState(CountryName.UnitedStates)).Start();

        }


        /// <summary>
        /// Recursively asks the user for a country name until they give a valid one.
        /// </summary>
        /// <returns>the CountryName based off of what they typed in as a string.</returns>
        public static CountryName PickCountryName() {
            string? countryNameStr = Console.ReadLine();
            if (countryNameStr == null) {
                Console.WriteLine("Invalid country name. Please try again.");
                PickCountryName();
            }
            CountryName countryName = ConvertStringToCountryName(countryNameStr);
            if (countryName == CountryName.NULL) {
                Console.WriteLine("Invalid country name. Please try again.");
                PickCountryName();
            }
            return countryName;
        }
            
        /// <summary>
        /// Converts a string to a CountryName.
        /// </summary>
        /// <param name="countryNameStr"></param>
        /// <returns>the CountryName from the string</returns>
        private static CountryName ConvertStringToCountryName(string? countryNameStr) {
            if (countryNameStr == null) {
                return CountryName.NULL;
            }
            switch (countryNameStr) {
                case "united states":
                case "United States":
                    return CountryName.UnitedStates;
                case "United Kingdom":
                case "united kingdom":
                    return CountryName.UnitedKingdom;
                case "France":
                case "france":
                    return CountryName.France;
                case "Germany":
                case "germany":
                    return CountryName.Germany;
                case "Russia":
                case "russia":
                    return CountryName.Russia;
                default:
                    return CountryName.NULL;
                    
            }
        }
}