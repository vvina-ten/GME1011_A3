﻿using System.Collections.Generic;

namespace GME1011A3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Epic battle goes here :)
            Random rng = new Random();



            Console.WriteLine("About your hero ");
            
            Console.Write("Hero's name: ");
            String heroname = Console.ReadLine();

            Console.Write("Hero's haelth: ");
            int herohealth = int.Parse(Console.ReadLine());
            if (herohealth <= 0)
            {
                Console.WriteLine("Your hero should be alive.");
                Console.Write("Hero's haelth: ");
                herohealth = int.Parse(Console.ReadLine());
            }

            Console.Write("Hero's strength (max 10): ");
            int herostrength = int.Parse(Console.ReadLine());
            if (herostrength <= 0)
            {
                Console.WriteLine("Your hero should be powerful.");
                Console.Write("Hero's strength (max 10): ");
                herostrength = int.Parse(Console.ReadLine());
            }
            
            Fighter hero = new Fighter(herohealth, heroname, herostrength);
                                                    //TODO: Get these arguments from the user - health, name, strength
            Console.WriteLine("Here is our heroic hero: " + hero + "\n\n");

            Console.Write("Baddie's number: ");
            int numBaddies = int.Parse(Console.ReadLine());
            if (numBaddies <= 0)
            {
                Console.WriteLine("Your hero should has enemy.");
                Console.Write("Baddie's number: ");
                numBaddies = int.Parse(Console.ReadLine());
            }
                                                    //TODO: Get number of baddies from the user
            int numAliveBaddies = numBaddies;

            

                                                    //TODO: change this so that it can contain goblins and skellies! Just change the type of the list!!
            List<Minion> baddies = new List<Minion>();

            for (int i = 0; i < numBaddies; i++)
            {
               


                int j = rng.Next(0,3);

                if (j == 0)
                {
                    baddies.Add(new Goblin(rng.Next(30, 35), rng.Next(1, 5), rng.Next(1, 10)));
                    //(int health, int armour, int dexterity)
                }

                else if (j == 1)
                {
                    baddies.Add(new Skellie(rng.Next(25, 31), 0));
                    //(int health, int armour)
                }

                else 
                {
                    baddies.Add(new Asir(rng.Next(30, 35), 5));
                }


                                                 //TODO: each baddie should have 50% chance of being a goblin, 50% chance of
                                                 //being a skellie. A skellie should have random health between 25 and 30, and 0 armour (remember
                                                 //skellie armour is 0 anyway)

            }

            //this should work even after you make the changes above
            Console.WriteLine("Here are the baddies!!!");
            for(int i = 0; i < baddies.Count; i++)
            {
                Console.WriteLine(baddies[i]);
            }
            Console.WriteLine("\n\n");
            Console.WriteLine("Let the EPIC battle begin!!!");
            Console.WriteLine("----------------------------");


            //loop runs as long as there are baddies still alive and the hero is still alive!!
            while (numAliveBaddies > 0 && !hero.isDead())
            {
                //figure out which enemy we are going to battle - the first one that isn't dead
                int indexOfEnemy = 0;
                while (baddies[indexOfEnemy].isDead())
                {
                    indexOfEnemy++;
                }

                //hero deals damage first
                Console.WriteLine(hero.GetName() + " is attacking enemy #" + (indexOfEnemy+1) + " of " 
                    + numBaddies + ". Eek, it's a " + baddies[indexOfEnemy].GetType().Name);
                int heroDamage = hero.DealDamage();  //how much damage?



                Console.WriteLine("Now " + heroname + "has strength: " + hero.GetStrength());      //update!!

                int percent= rng.Next(1,101);

                if (percent <= 33) 
                {
                   heroDamage = hero.Berserk();

                    if (heroDamage > 0)
                    {
                        Console.WriteLine("Hero deals " + heroDamage + " special heroic damage.");
                        Console.WriteLine("Now " + heroname + "has strength: " + hero.GetStrength());         //update!!
                    }
                    else
                    {
                        Console.WriteLine("No STRENGTH !!!");
                        heroDamage = hero.DealDamage();
                        Console.WriteLine("Hero deals " + heroDamage + " regular heroic damage.");
                    }

                }

                else
                {
                    heroDamage = hero.DealDamage();
                    Console.WriteLine("Hero deals " + heroDamage + " regular heroic damage.");
                }





                baddies[indexOfEnemy].TakeDamage(heroDamage); //baddie takes the damage


                                                       //TODO: The hero doesn't ever use their special attack - but they should. Change the above to 
                //have a 33% chance that the hero uses their special, and 67% that they use their regular attack.
                //If the hero doesn't have enough special power to use their special attack, they do their regular 
                //attack instead - but make a note of it in the output. There's no way for the hero to get more special
                //power points, but if you want to craft a way for that to happen, that's fine.




                //NOTE to coders - armour affects how much damage goblins take, and skellies take
                //half damage - remember that when reviewing the output








                //did we vanquish the baddie we were battling?
                if (baddies[indexOfEnemy].isDead())
                {
                    numAliveBaddies--; //one less baddie to worry about.
                    Console.WriteLine("Enemy #" + (indexOfEnemy+1) + " has been dispatched to void.");
                }
                else //baddie survived, now attacks the hero
                {
                    //      int baddieDamage = baddies[indexOfEnemy].DealDamage();  //how much damage?
                    //      Console.WriteLine("Enemy #" + (indexOfEnemy+1) + " deals " + baddieDamage + " damage!");
                    //      hero.TakeDamage(baddieDamage); //hero takes damage

                    int polyenemy = rng.Next(1,101);
                    int baddieDamage = 0 ;

                    if (polyenemy <= 33) 
                    {
                        if (baddies[indexOfEnemy].GetType() == typeof(Goblin))
                        {
                            baddieDamage = ((Goblin)baddies[indexOfEnemy]).GoblinBite();
                            Console.WriteLine("Enemy #" + (indexOfEnemy + 1) + " deals " + baddieDamage + " damage!");
                        }

                        else if (baddies[indexOfEnemy].GetType() == typeof(Skellie))
                        {
                            baddieDamage = ((Skellie)baddies[indexOfEnemy]).SkellieRattle();
                            Console.WriteLine("Enemy #" + (indexOfEnemy + 1) + " deals " + baddieDamage + " damage!");
                        }

                        else if (baddies[indexOfEnemy].GetType() == typeof(Asir))
                        {
                            baddieDamage = ((Asir)baddies[indexOfEnemy]).AsirMeow();
                            Console.WriteLine("Enemy #" + (indexOfEnemy + 1) + " deals " + baddieDamage + " damage!");
                        }
                    }
                    else
                    {
                        baddieDamage = baddies[indexOfEnemy].DealDamage(); 
                        Console.WriteLine("Enemy #" + (indexOfEnemy + 1) + " deals " + baddieDamage + " damage!");
                    }

                    hero.TakeDamage(baddieDamage);





                    //TODO: The baddie doesn't ever use their special attack - but they should. Change the above to 
                    //have a 33% chance that the baddie uses their special, and 67% that they use their regular attack.



                    //let's look in on our hero.
                    Console.WriteLine(hero.GetName() + " has " + hero.GetHealth() + " health remaining.");
                    if (hero.isDead()) //did the hero die
                    {
                        Console.WriteLine(hero.GetName() + " has died. All hope is lost.");
                    }

                }









                Console.WriteLine("-----------------------------------------");
            }
            //if we made it this far, the hero is victorious! (that's what the message says.
            if(!hero.isDead())
                Console.WriteLine("\nAll enemies have been dispatched!! " + hero.GetName() + " is victorious!");
        }

    }
}