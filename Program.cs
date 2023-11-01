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

    /// <summary>
    /// The Command Names and their descriptions.
    /// </summary>
    Dictionary<string, string> commandNames;

    /// <summary>
    /// A constructor to make a new WorldWarBass object.
    /// </summary>
    /// <param name="gameState">The GameState for the new game.</param>
    public WorldWarBass(GameState gameState) : base(gameState) {

        commandNames = new Dictionary<string, string>
        {
            { "ATTACK", "Attacks a country of your choosing." },
            { "INVITE", "Invites a country of your choosing to join your alliance." },
            { "RULES", "Displays the rules of the game." },
            { "HELP", "Displays the commands you can use." },
            { "QUIT", "Quits the game." }
        };

    }

    /// <summary>
    /// Starts the game.
    /// </summary>
    public override void Start() {
        this._isRunning = true;        

        while(this._isRunning) {
            this.Update();
        }
    }

    /// <summary>
    /// Updates the game.
    /// </summary>
    public override void Update() {
        // Displays the Commands to the user, then gets the command from the user as a string.
        DisplayUI();
        string? command = GetCommand();
        // Switches on the command, and does the appropriate action.
        switch (command.ToUpper()) {
            case "ATTACK":
                AttackInfo at = this.GetAttackInfo();
                if (at._isSuccessful) {
                    this._gameState.GetPlayerCountry().Attack(at._countryToAttack);
                } else {
                    Console.WriteLine("You failed to attack " + at._countryToAttack.GetName() + "!");
                }
                break;
            case "INVITE":
                Console.WriteLine("You chose to invite a country to join your alliance.");
                break;
            case "RULES":
                Console.WriteLine("You chose to see the rules.");
                break;
            case "HELP":
                Console.WriteLine("You chose to see the commands.");
                break;
            case "QUIT":
                Console.WriteLine("You chose to quit the game.");
                this._isRunning = false;
                break;
            default:
                Console.WriteLine("Invalid command. Please try again.");
                break;
        }
        
    }

    /// <summary>
    /// Displays the UI for entering commmands for the game.
    /// </summary>
    private void DisplayUI() {
        Console.Write("Commands are as follows:\n");
        foreach (KeyValuePair<string, string> commandName in commandNames) {
            Console.WriteLine(commandName.Key + ": " + commandName.Value);
        }

        Console.Write("What would you like to do? ");

        
    }

    /// <summary>
    /// Gets the command from the user.
    /// </summary>
    /// <returns>the command that the user entered as a string.</returns>
    private string? GetCommand() {
        string? command = Console.ReadLine();
        if (command == null) {
            Console.WriteLine("Invalid command. Please try again.");
            GetCommand();
        }
        if (commandNames.ContainsKey(command.ToUpper())) {
            return command.ToUpper();
        }
        return "";
    }

    // Gosh this is a terrible way to do this, I realized it halfway through implementing it but idk it's cool so im leaving it, very oop
    // TODO: Make this not terrible
    /// <summary>
    /// Gets the attack info from the user.
    /// </summary>
    /// <returns>A new AttackInfo struct with the Country the player wishes to attack, and if the attack is successful.</returns>
    private AttackInfo GetAttackInfo() {
        Console.WriteLine($"Which apposing country would you like to attack?");
        string? countryToAttack = Console.ReadLine();
        if (countryToAttack == null) {
            Console.WriteLine("Null country name. Please try again.");
            GetAttackInfo();
        }
        return new AttackInfo(new Country(this.ConvertStringToCountryName(countryToAttack)), this._gameState.GetPlayerCountry(), this._gameState.GetPlayerCountry().CanAttack(new Country(this.ConvertStringToCountryName(countryToAttack))));
    }

    /// <summary>
    /// Converts a string to a CountryName.
    /// </summary>
    /// <param name="input">a string input of a name of a country.</param>
    /// <returns>a new CountryName enum based on the string input.</returns>
    private CountryName ConvertStringToCountryName(string? input) {
        if (input == null) {
            return CountryName.NULL;
        }

        switch (input.ToUpper()) {
            case "UNITED STATES":
                return CountryName.UnitedStates;
            case "UNITED KINGDOM":
                return CountryName.UnitedKingdom;
            case "FRANCE":
                return CountryName.France;
            case "GERMANY":
                return CountryName.Germany;
            case "RUSSIA":
                return CountryName.Russia;
            default:
                return CountryName.NULL;
        }
    }



}

public static class Client {

        // Goal is to literally just make WorldWarBass obj and call start on it.
        public static void Main(string[] args) {
            
            Console.WriteLine("Welcome to World War Bass!");
            Console.Write("Before we get started, what country are you playing as?\nUnited States\nUnited Kingdom\nFrance\nGermany\nRussia\nType the name of the country you want to play as: ");
            CountryName picked = PickCountryName();

            Console.Write("One last thing before getting started, if you want to see the rules, type \"RULES\", otherwise, type \"START\" to start the game.\n[START or RULES]:");
            // I should pull this into a method, however I want the actual prompt method to be all purpose, not just start and rules.
            string? startOrRules = Console.ReadLine();
            while (startOrRules != "START") {
                if (startOrRules == "START") {
                    break;
                }
                if (startOrRules.ToUpper() == "RULES") {
                    Console.WriteLine("RULES:\n\nThe goal of the game is to conquer the world. You do this by conquering other countries.\nYou can conquer other countries by invading them, and removing all of their troops.");
                }
                if (startOrRules == null) {
                    Console.WriteLine("Invalid input. Please try again.");
                }
                Console.Write("[START or RULES] :");
                startOrRules = Console.ReadLine();
                
            }
            Console.WriteLine("Starting game, good luck conquerer!");

            Console.Clear();
            new WorldWarBass(new GameState(picked)).Start();

        }


        /// <summary>
        /// Recursively asks the user for a country name until they give a valid one.
        /// </summary>
        /// <returns>the CountryName based off of what the player typed in as a string.</returns>
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