using System;
using System.Collections.Generic;
using System.IO;


//this code is (C) Kyle Garzon 2022
//For Mr. Bass' class 5th Hour


/****************************************************************************************************************************************************************************************************************************************************************************************************************************

1: stands for: shouldTheyBeAlerted. This variable tells the system weather contries are already alerted or not.

2: Stands for peaceOrWar. This indexes to see if we are in peace or war.

3: This Method may seem like all it does is get the new number of troops, which could be done either in main or in the previous method used. But, you cannot return more than one value from a method, and I needed the value of troops that are being sent, so that way I could use it in attacking calculation and logic.

****************************************************************************************************************************************************************************************************************************************************************************************************************************/


namespace WWB //World War Bass
{
    class source
    {
        public int yearPicked; //the year that the user picks
        public static void Main(string[] args)
        {

            int sTBA = 0; //see note 1
            int incomeBonus = 0;
            Console.Write("What year is this battle taking place?\n(1938-1945, 1990-2015, 2030-2050, somewhere in between those years.): ");
            int yearPicked = Convert.ToInt32(Console.ReadLine());
            if (yearPicked >= 1938 && yearPicked <= 1945) //is yearPicked bigger than 1938 but smaller than 1945?
            {

                Console.Write("\nThe battle will be set in WWII (World War Two)");
                sTBA = 0;

            }
            else if (yearPicked >= 1990 && yearPicked <= 2015) //is yearPicked bigger than 1990, but smaller than 2015?
            {

                Console.Write("\nThe battle will be set in during the US' war on terrorism.");
                sTBA = 0;

            }
            else if (yearPicked >= 2030 && yearPicked <= 2050) //is yearPicked bigger than 2030, but smaller than 2050?
            {

                Console.Write("\nThe battle will be set in the future.");
                Console.Write("\nIs there currently a battle going on in this future? [Yes/No]: ");
                string yesNo = Console.ReadLine();
                if (yesNo == "yes" || yesNo == "Yes")
                {

                    Console.Write("It is the year " + yearPicked + ". War is raging, and people are dying everywhere.");
                    sTBA = 0;

                }
                else if (yesNo == "no" || yesNo == "No")
                {

                    Console.Write("It is the year " + yearPicked + " and times are very peaceful. Natural Resources are able to be synthesised. Automatic +5 Resources per round.");
                    sTBA = 1;
                    incomeBonus = 5;
                }




            }
            else
            {

                Console.Write("No major wars were fought then, so it will be a time of peace.");
                sTBA = 1;
            }


            //end of the if nest haha

            string[] pW = { "war", "peace" }; //note 2
            if (sTBA == 0) //war 
            {

                string warOrPeace = pW[0];
                Console.Write("\nBecause it's a time of war, contries are prepared. If you wish to invade someone, you can do so, you do not have to declare war or prepare.");
                Console.Write("\n\nPress any key when you are ready.");
                Console.ReadKey();
            }
            else if (sTBA == 1) //peace
            {

                string warOrPeace = pW[1];
                Console.Write("\nBecause it's a time of peace, no contries are prepared, and neither are you. You must declare war and prep before you attack, as do all the other contries.");
                Console.Write("\n\nPress any key when you are ready.");
                Console.ReadKey();
            }

            string whichCountry;
            int resources = 0;
            int troops = 0;
            string countryPicked = "temp";
            Console.Write("\nNow, let's pick your country.\nYou can pick from 5 Different countries-\nThe U.S.A\nThe U.K\nGermany\nFrance\nRussia\nWhich country do you want: ");
            whichCountry = Console.ReadLine();
            if (whichCountry == "The U.S.A" || whichCountry == "us" || whichCountry == "the us" || whichCountry == "u.s.a" || whichCountry == "the u.s.a" || whichCountry == "the U.S.A") //what does the user input?
            {

                Console.Write("\nThe U.S.A has a big army, and a good economy.\nYou start with more resources and troops. +100 Troops and +20 Resources.");
                resources = 20;
                troops = 100;
                countryPicked = "U.S";
            }
            else if (whichCountry == "The U.K" || whichCountry == "the uk" || whichCountry == "britain" || whichCountry == "the uk" || whichCountry == "uk" || whichCountry == "no queen") //what does the user input?
            {

                Console.Write("\nThe U.K has a large army, and a decent economy.\nYou start with +50 troops and +15 Resources.");
                resources = 15;
                troops = 50;
                countryPicked = "U.K";
            }
            else if (whichCountry == "Germany" || whichCountry == "germany" || whichCountry == "nazis" || whichCountry == "Nazi germany" || whichCountry == "nazi germany") //what does the user input?
            {

                Console.Write("\nGermany has a very small army, but the economy is bustling along.\nYou start with +10 troops and +50 resources.");
                resources = 50;
                troops = 10;
                countryPicked = "Germany";


            }
            else if (whichCountry == "France" || whichCountry == "france" || whichCountry == "baguette" || whichCountry == "useless" || whichCountry == "white flag" || whichCountry == "losers" || whichCountry == "lmao imagine losing to germany") //what does the user input?
            {

                Console.Write("\nFrance has a medium sized army, and a good economy.\nYou start with +15 Troops and +30 resources.");
                troops = 15;
                resources = 30;
                countryPicked = "France";
                
            }
            else if (whichCountry == "Russia" || whichCountry == "russia" || whichCountry == "thicc place") //what does the user input?
            {

                Console.Write("\nRussia has a very, very large army and a decent economy.\n+You start with +150 troops and +25 resources.");
                troops = 150;
                resources = 25;
                countryPicked = "Russia"; 
            }
            else
            {

                Console.WriteLine("That country was not a part of the list.");
                Console.WriteLine("Press any key to close the console.");
                Console.ReadKey();
                System.Environment.Exit(0);


            }

            Console.Write("\n\nYou have " + troops + " troops and " + resources + " resources.\nTroops keep your country safe, and also help you attack others.\nIf you have more than half your troops in your country at once, then you have a higher chance of beating off an enemy attack.\n\nResources can get you more troops, for varing cost for how well trained they are.\n");
            Console.Write("Here's the run-down of the World War Bass-\nYou have troops and resources, which you can use to defend yourself, and also buy troops.\nEvery turn you have the option to move troops, buy troops, or attack someone.\n\nAlso, after you are done with your turn, other countries do random things. This can mean drafting lots of troops, moving them to a front, etc.\nIf you are in a time of war, then all countries are on edge, and the slightest thing can set them off, so be careful.");

            Console.Write("Now, what would you like to do?\nDRAFT\nBUY TROOPS\nRAISE TAXES\n");

            string input;
            int taxDoubler = 1;
            input = Console.ReadLine();
            if (input == "DRAFT" || input == "draft" || input == "dRaFt" || input == "DrAfT" || input == "dRAFT") //what does the user input?
            {

                int draftTroops = Draft(troops); //see note 3
                troops = troops + draftTroops;
                Console.Write("Drafting Troops....\n\n" + "because of the draft, you now have " + troops + " troops!\n");
                taxDoubler = 1;


            }
            else if (input == "BUY TROOPS" || input == "buy troops" || input == "Buy Troops") //checking user input
            {
                Console.Write("\nHow many troops would you like to buy? (Each Troop is 4 resources)\nYou have " + resources + " resources" + "\nPurchase amount-");
                int purchaseTroops = Convert.ToInt32(Console.ReadLine());
                if (resources >= 4 * purchaseTroops)
                {

                    resources -= purchaseTroops * 4;
                    Console.WriteLine("\nYou have " + resources + " resources left.\nYou also now have " + troops + " troops.\n");

                }
                else
                {

                    Console.Write("Not enough Money. Try again next turn.\n");

                }


            }
            else if (input == "raise taxes" || input == "Raise Taxes" || input == "RAISE TAXES" || input == "sudo raise-taxes") //user input again
            {

                Console.Write("You will gain double your income at the end of the pre-turn.\n");
                taxDoubler = 2;


            } else
            {


                Console.Write("The president of <your country here> sat on their butt and did nothing.\n");
                
            }

            Console.Write("\nThe pre-turn is over!\nNow, time to collect your taxes.");
            int tax = TaxCollection(resources, taxDoubler, incomeBonus); //calling TaxCollection method and giving it the values for resources, taxDoubler, and incomeBonus
            resources = resources + tax;
            Console.Write("\nYou now have " + resources + " resources because of taxes!");
            String[] usethis = { "U.S", "U.K", "Germany", "France", "Russia", "None"}; //called usethis because it is the values used in countryList
            List<string> countryList = new List<string>(usethis); //making a new list named countryList and giving it all the values from usethis
            countryList.Remove(countryPicked);
            Console.WriteLine(string.Join("\n", countryList));
            Console.Write("\nNow, for the attacking turn. There are four other countries to attack, they are-\n" + string.Join("\n", countryList)); //displaying attackable countries
            var whosGettingAttacked = GetAttack(countryList, troops);
            bool areAttacking;
            if (whosGettingAttacked == "None")
            {
                
                Console.Write("The country " + countryPicked + " is staying neutral");
                areAttacking = false;
                
            } else
            {
                
                Console.Write("The country " + countryPicked + " is now attacking " + whosGettingAttacked + "!");
                areAttacking = true;
            }
            if (areAttacking)
            {
                
                var Main_amountOfTroopsBeingSent = SendTroops(troops, whosGettingAttacked);
                GetTroopsRemaning(troops, Main_amountOfTroopsBeingSent);
                Console.Write("You have " + troops + " troops remaning.\n");
                AttackLogic(troops, whosGettingAttacked, Main_amountOfTroopsBeingSent, countryList);
                
            } else if (!areAttacking)
            {

                Console.Write("Because " + countryPicked + " is not attacking anyone, they get a turn to rally their troops, and get +5 troops from drafts.\n");
                troops += 5;

            }
            
            
        }
        
        public static bool AttackLogic(int troops, string attackee, int troopsBeingSent)
        {
            Random howManyTroopsAttackeeHas = new Random();
            int defenderTroopCount = howManyTroopsAttackeeHas.Next(6, 16);
            Console.Write("The country " + attackee + " has " + defenderTroopCount + " troops.");
            if (troopsBeingSent > defenderTroopCount)
            {
                troopsBeingSent -= defenderTroopCount - 5; //sets the amount of troops being sent to the defender troop count -5.
                bool win;
                Console.Write("You had more troops than " + attackee + "! They saw your mass amounts of numbers comapared to theirs, and lost because their morale was so low.\n");
                if (troopsBeingSent > 5)
                {

                    Console.Write("You had so many troops, that the rest of " + attackee + "'s ragged army fell like a house of cards. You have taken over " + attackee + "!\n");
                    win = true;
                    return win;
                } else
                {

                    Console.Write("You may have won the battle, but " + attackee + " has more troops, so you had to pull out.");
                    return false;
                }

            }



        }


        public static int GetTroopsRemaning(int troops, int _troopsBeingSent) //Don't worry. This Method isn't useless. See note 3.
        {

            troops -= troopsBeingSent;
            return troops;

        }

        public static int SendTroops(int troops, string attackee)
        {
            
            Console.Write("\nHow many troops do you want to send? [You have " + troops + " troops]\nAmount of troops You are sending-");
            int troopsToBeSent = Convert.ToInt32(Console.ReadLine());
            if (troops > troopsToBeSent)
            {
            Console.Write("You will send " + troopsToBeSent + " to attack " + attackee + ".");
            return troopsToBeSent;
            } else 
            {
                
                Console.Write("You do not have enough troops. Please try again next turn.");
                return 0;
            }
        }
        
        public static string GetAttack(List<string> otherCountries, int troops)
        {
            
            Console.WriteLine("\nOut of the countries listed, which do you want to attack? (Type 'none' if you do not wish to attack this turn.)\n[TYPE IT EXACTLY AS IT IS WRITTEN!]\n\nCountry you are Attacking- ");
            string prompt = Console.ReadLine();
            if (otherCountries.Contains(prompt))
            {
                
                return prompt;
                
            } else if (otherCountries.Contains(prompt) && prompt == "None")
            {
                
                
                string _prompt = "none";
                return _prompt;
            }
            else 
            {
                
                Console.Write("That is not in the list, you lose your attacking turn trying to find the country " + prompt + "\n");
                return null;
                
            }
            
        }


        public static int Draft(int troops)
        {

            Random troopNum = new Random(); //creating a new instance of the RNG class named troopNum
            Console.Write("\nBecause you drafted, you pay no money but the number of troops you get are random.\n");
            int addTroops = troopNum.Next(0, 11); //picking a random number of 1-10
            troops = troops + addTroops; //setting the troops variable to the old amount plus the new draftees.
            return troops; //returning the new troops value to Main()

        }

        public static int TaxCollection(int resources, int doubled, int bonus)
        {

            Random tax = new Random(); //new rng class instance named tax
            int taxAdd = tax.Next(1, 21); //setting taxAdd to a random number from 2-20
            resources = taxAdd * doubled + resources + bonus - 10; //setting resources to the random taxAdd value * doubled (can be 1 or 2) + any income bounus + the current value - 10 (for balance)
            return resources;

        }
    }

}
