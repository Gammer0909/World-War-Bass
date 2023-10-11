// This code is a LEGACY version of the game, and is not used in the current version.
// Version: L0.0.1 (Not Working)

using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

//This game idea and the code are (c) Gammer0909 2022 / 2023

/*
 * This program was used to teach myself Object-Oriented Design principles, or SOLID
 * (https://en.wikipedia.org/wiki/SOLID) as well as how to properly make a functioning program/application with
 * with OOP principles.
 * If you wish to use this as an example or teach with it, contact me on GitHub @Gammer0909
 *
 */

//This is a refactor (MAJOR REFACTOR) of a project for my 5th hour

class Game
{   
    public string countryPicked;
    public bool defended = false;
    public int countryNumber;
    public static int troopCount = 0;
    public int hateFactor = 0;
    public int money = 10;
    public int taxPercentage = 0;
    public int domesticHateFactor = 0;
    public string[] otherCountriesOwned = {}; 
    public static string[] countryArray = {"United States", "United Kingdom", "Russia", "France"};
    public static int[] countryTroopArray = {10, 10, 15, 5};
    public List<string> countryList = new List<string>(countryArray);
    public List<int> countryTroopList = new List<int>(countryTroopArray);
    
    public void Initialize(string country)
    {
        
        countryPicked = country;
        switch(country)
        {
            
            case "united states":
            case "United States":
                countryList.Remove("United States");
                countryTroopList.RemoveAt(0);
                break;
            case "united kingdom":
            case "United Kingdom":
                countryList.Remove("United Kingdom");
                countryTroopList.RemoveAt(1);
                break;
            case "russia":
            case "Russia":
                countryList.Remove("Russia");
                countryTroopList.RemoveAt(2);
                break;
            case "france":
            case "France":
                countryList.Remove("France");
                countryTroopList.RemoveAt(4);
                break;
            
        }
        
    }

    public void AttackPrompt(Game game)
    {

        Console.WriteLine("It is now your attacking turn, you can:");
        Console.WriteLine("ATTACK\nDEFEND\n[PICK ACTION]: ");
        string input = Console.ReadLine();
        switch (input)
        {
            case "attack":
            case "ATTACK":
                Attack(game);
                break;
            case "defend":
            case "DEFEND":
                Defend();
                break;
            default:
                Console.WriteLine("Invalid input, try again.");
                Thread.Sleep(2000);
                Console.Clear();
                AttackPrompt(game);
                break;


        }

    }


    public void Attack(Game game)
    {
        Console.WriteLine("Pick the country you are attacking: ");
        foreach (string country in countryList)
        {
            Console.WriteLine(country);
        }
        string input = Console.ReadLine();
        int troopsToSend;
        string attackee;
        switch(input)
        {
            case "United States":
            case "united states":
                if (!otherCountriesOwned.Contains("United States")) {
                    Console.WriteLine("You are attacking " + input + "! How many troops do you want to send? You have " + troopCount + " troops available.");
                    troopsToSend = Convert.ToInt32(Console.ReadLine());
                    troopCount -= troopsToSend;
                    attackee = "United States";
                    AttackEnemy(attackee, troopsToSend, game);
                    break;
                } else {
                    
                    Console.WriteLine("You already own that country, try again!");
                    Attack(game);
                    
                }
                break;
            case "United Kingdom":
            case "united kingdom":
                if (!otherCountriesOwned.Contains("United Kingdom")) {
                    Console.WriteLine("You are attacking " + input + "! How many troops do you want to send? You have " + troopCount + " troops available.");
                    troopsToSend = Convert.ToInt32(Console.ReadLine());
                    troopCount -= troopsToSend;
                    attackee = "United Kingdom";
                    AttackEnemy(attackee, troopsToSend, game);
                    break;
                } else {
                    
                    Console.WriteLine("You already own that country, try again!");
                    Attack(game);
                    
                }
                break;
            case "Russia":
            case "russia":
                if (!otherCountriesOwned.Contains("Russia")) {
                    Console.WriteLine("You are attacking " + input + "! How many troops do you want to send? You have " + troopCount + " troops available.");
                    troopsToSend = Convert.ToInt32(Console.ReadLine());
                    troopCount -= troopsToSend;
                    attackee = "Russia";
                    AttackEnemy(attackee, troopsToSend, game);
                    break;
                } else {
                    
                    Console.WriteLine("You already own that country, try again!");
                    Attack(game);
                    
                }
                break;
            case "France":
            case "france":
                if (!otherCountriesOwned.Contains("France")) {
                    Console.WriteLine("You are attacking " + input + "! How many troops do you want to send? You have " + troopCount + " troops available.");
                    troopsToSend = Convert.ToInt32(Console.ReadLine());
                    troopCount -= troopsToSend;
                    attackee = "France";
                    AttackEnemy(attackee, troopsToSend, game);
                    break;
                } else {
                    
                    Console.WriteLine("You already own that country, try again!");
                    Attack(game);
                    
                }
                break;
            default:
                Console.WriteLine("Invalid input, try again.");
                Thread.Sleep(1500);
                Console.Clear();
                Attack(game);
                break;
        }
    }
    
    public static void AttackEnemy(string atk, int sentTroops, Game game)
    {
        int enemyTroopCount = 0;
        //First get the current troop count of the country you are attacking
        switch(atk)
        {
            case "United States":
            case "united states":
                enemyTroopCount = game.countryTroopList[0];
                break;
            case "United Kingdom":
            case "united kingdom":
                enemyTroopCount = game.countryTroopList[1];
                break;
            case "Russia":
            case "russia":
                enemyTroopCount = game.countryTroopList[2];
                break;
            case "France":
            case "frace":
                enemyTroopCount = game.countryTroopList[3];
                break;
        }
        //attacking Logic
        if (sentTroops > enemyTroopCount)
        {
            
            Console.WriteLine("Your massive numbers destroy " + atk + "'s puny troop numbers, and you take the country!");
            game.otherCountriesOwned[game.otherCountriesOwned.Length - 1] = atk;
            
            
        } else if (sentTroops <= enemyTroopCount)
        {
            
            Console.WriteLine("You've fought them to a standstill! They Will easily crumble if you send more troops next turn.");
            enemyTroopCount -= sentTroops;
        }
        
    }
    
    public void Defend()
    {
        defended = true;
        Console.WriteLine("You defended your country!");
        
    }

    public void TurnPrompt()
    {
        
        Console.WriteLine("It is your pre-attack turn, you can:");
        Console.WriteLine("DRAFT\nRAISE taxes\nBUY troops\nLOWER taxes");
        Console.WriteLine("Pick action [The capital word]: ");
        string input = Console.ReadLine();
        switch (input)
        {
            
            case "draft":
            case "DRAFT":
                DraftTroops();
                break;
            case "raise":
            case "RAISE":
                RaiseTaxes(); 
                break;
            case "buy":
            case "BUY":
                BuyTroops();
                break;
            case "lower":                    
                LowerTaxes();
                break;
            default:
                Console.WriteLine("Invalid input, try again.");
                Thread.Sleep(2000);
                Console.Clear();
                TurnPrompt();
                break;
            
            
        }
    }

    public void LowerTaxes()
    {

        taxPercentage--;
        Console.WriteLine("You lowered taxes by 1%!");

    }


    public void BuyTroops()
    {

        Console.WriteLine("You can buy troops for 1 money each, how many would you like to buy? You have " + money + " money available.\n[TROOPS TO BE BOUGHT]: ");
        int troopsToBuy = Convert.ToInt32(Console.ReadLine());
        if (troopsToBuy > money)
        {
            Console.WriteLine("You don't have enough money to buy that many troops!");
            Thread.Sleep(2000);
            Console.Clear();
            BuyTroops();
        }
        else
        {
            money -= troopsToBuy;
            troopCount += troopsToBuy;
            Console.WriteLine("You bought " + troopsToBuy + " troops!");
        }

    }
    
    public void DraftTroops()
    {
        
        Random rngTroops = new Random();
        int addTroops = rngTroops.Next(2, 7);
        troopCount += addTroops;
        Console.WriteLine("You drafted " + addTroops + " troops!");
        
    }

    public void RaiseTaxes()
    {

        taxPercentage++;
        Console.WriteLine("You raised taxes by 1%!");

    }
    
    public static void DisplayRules()
    {
        
        Console.WriteLine("Welcome to World War Bass!\n");
        Console.WriteLine("The rules for World War Bass are simple:");
        Console.WriteLine("1. You are a country (of your choice) fighting in a war that may or may not happen, depending on what you do.");
        Console.WriteLine("2. You can pick an action to do, (these will be listed later)");
        Console.WriteLine("3. After 2, you can pick to attack or defend your country.");
        Console.WriteLine("4. Then it will be the enemy countries' turn");
        Console.WriteLine("5. You also have a Domestic hate factor, which decides if your troops will accept your orders or not.");
        Console.WriteLine("The goal of the game is to control all the world!");
        Console.WriteLine("Alright, let's begin! (If you need to review these rules, type RULES when prompted.)");
        
    }
    
    
}



class MainLogic
{
    
    
    
    public static void Main()
    {
       
       Game.DisplayRules();
       Console.WriteLine("\nPress Any key when you are ready to continue.");
       Console.ReadKey();
       Console.Clear();
       Game playerGame = new Game();
       GetCountry(playerGame);
       Game.troopCount = Game.countryTroopArray[playerGame.countryNumber];
       Console.WriteLine("You are the leader of the country " + playerGame.countryPicked + "! You currently have " + Game.troopCount + " troops!");
       Console.WriteLine("But, when your enemies are choosing who to attack, you have a " + playerGame.hateFactor + "/5 chance to get picked.");
       Console.WriteLine("Now, onto your first turn!");
       Console.WriteLine("\nPress any key to continue.");
       Console.ReadKey();
       Console.Clear();
       playerGame.TurnPrompt();
       playerGame.AttackPrompt(playerGame);
 
    }   
    
    
    public static void GetCountry(Game game)
    {
        foreach (string i in Game.countryArray)
       {
           
           Console.WriteLine(i);
           
       }
       Console.Write("Pick your country [Exactly as written above]: ");
       string pickedCountry = Console.ReadLine();
        
        switch (pickedCountry)
        {
           case "United States":
           case "united states":
            game.Initialize(pickedCountry);
            Game.troopCount = Game.countryTroopArray[0];
            Game.countryTroopArray = RemoveIndices(Game.countryTroopArray, 0);
            game.countryNumber = 0;
            game.hateFactor = 1;
            break;
           case "United Kingdom":
           case "united kingdom":
            game.Initialize(pickedCountry);
            Game.troopCount = Game.countryTroopArray[1];
            Game.countryTroopArray = RemoveIndices(Game.countryTroopArray, 1);
            game.countryNumber = 1;
            game.hateFactor = 1;
            break;
           case "Russia":
           case "russia":
            game.Initialize(pickedCountry);
            Game.troopCount = Game.countryTroopArray[2];
            Game.countryTroopArray = RemoveIndices(Game.countryTroopArray, 2);
            game.countryNumber = 2;
            game.hateFactor = 3;
            break;
           case "France":
           case "france":
            game.Initialize(pickedCountry);
            Game.troopCount = Game.countryTroopArray[3];
            Game.countryTroopArray = RemoveIndices(Game.countryTroopArray, 3);
            game.countryNumber = 3;
            game.hateFactor = 2;
            break;
           default:
            Console.WriteLine("Invalid country, try again.");
            Thread.Sleep(2000);
            Console.Clear();
            Console.Clear();
            GetCountry(game);
            break;
         
       }
       
        
    }
    
    public static int[] RemoveIndices(int[] IndicesArray, int RemoveAt) //thank you internet (i didnt write this method)
    {
        int[] newIndicesArray = new int[IndicesArray.Length - 1];
        
        int i = 0;
        int j = 0;
        while (i < IndicesArray.Length)
        {
            if (i != RemoveAt)
            {
                newIndicesArray[j] = IndicesArray[i];
                j++;
            } else if (i == RemoveAt)
            {
                
                
                
            }
            
            i++;
        }
            
        return newIndicesArray;
    }
}
