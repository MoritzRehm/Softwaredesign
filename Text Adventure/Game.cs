using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TextAdventure
{
    public class Gameobject    
    {
        public string Name;
        public string Describtion;
        public static string getname (Gameobject name)
        {
            return name.Name;
        }
        public static string getdescribtion(Gameobject describtion)
        {
            return describtion.Describtion;
        }
    }

    class Game 
    {
        private List<Item> Inventory;
        public string Startuptext = "Hello Stranger. Welcome to the dangerous Clublife. Your mission is to become the most Badass person in this club, Let´s Go!";
        public string Endtext = "Congratulation. You found the key to become the most Badass dude in the club! \n Now nobody wants beef with you anymore, you can enjoy the rest of the night :)";
        public bool isRunning = true;
        private bool _gameOver = false;
        public Room CurrentLocation = new Room
        {
            
        };
        Room Foyer = new Room
        {
            Name="Foyer",
            Describtion= "You are now in the Foyer, let´s get the Party started",
            Available=true,
        };   
        Room Toilet = new Room
        {
            Name="Toilet",
            Describtion="You reached the Toilet, everything smells horrible in here",
            Available=true,
            CharacterList = new List<Character>(),
        };
        Room Bar = new Room
        {
            Name="Bar",
            Describtion="Time for some refreshments at the Bar, but be carefull who you bumping into...",
            Available=true,
        };
        Room Dancefloor = new Room
        {
            Name="Dancefloor",
            Describtion="You reached the Dancefloor, way too noisy and warm in here",
            Available=true,
        };
        Room OutdoorArea = new Room
        {
            Name="Outdoor Area",
            Describtion="You currently are at the Outdoor Area, perfect place to take a short break from the noisy crowd inside",
            Available=true,
        };
        Room DJDesk = new Room
        {
            Name = "DJ Desk",
            Describtion = "You reached the VIP-Section behind the DJ-Desk, you are now officialy a badass",
            Available=true,
        };


        Item BeerBottle = new Item 
        {
            Name = "BeerBottle",
            Describtion = "This Bottle can be usefull in a fight",
            Attackdamage = 20,
            Carryable=true,
            Value = 1,
        };
        Item Cellphone = new Item 
        {
            Name = "lost IPhone",
            Describtion = "This Iphone is locked, but maybe somebody in here knows the code..",
            Carryable=false,
            Value = 1,
        };
        Item Gun = new Item
        {
            Name = "Gun", 
            Describtion = "This club has a new Sheriff",
            Attackdamage = 70,
            Carryable = true,
            Value = 1,
            
        };
        Item Glass = new Item
        {
            Name = "broken Glass",
            Describtion = "It´s just Glass, but it could be usefull in an emergency",
            Attackdamage = 15,
            Carryable = true,
            Value = 1,
        };
        Item Rolex = new Item
        {
            Name ="shiny Rolex",
            Describtion="With this thing you are the spotlight in here",
            Carryable = true,
            Value = 1,
        };
        Item CarKeys = new Item
        {
            Name="fancy CarKeys",
            Describtion="Now you have no worries how to get home!",
            Value = 1,

        };

        Character Player = new Character
        {
            Isalive = true,
            HealthPoints = 100,
            AttackDamage = 20,
            Characterinventory = new List<Item>(),
        
        };
        Character Security = new Character
        {
            Name = "The Security Guy",
            Describtion ="He is big, strong, agressive and not amused if you cause any trouble...",
            HealthPoints = 120,
            AttackDamage = 40,
            IsAgressive = true,
            Characterinventory = new List<Item>(),
            Dialouge = {"What´s up with you? Don´t get on my nerves", "I won´t say it again boy", "That´s it! If I see you one more Time, I´ll beat your ass!"},

        };
        Character CleaningLady = new Character
        {
            Name = "The Cleaning Lady",
            Describtion ="She may seem a little slow but she has mob which can really hurt",
            HealthPoints = 30,
            AttackDamage = 20,
            Characterinventory = new List<Item>(),
            Dialouge = {"Just let me do my work please", "It´s surprising what some people loose on the Toilet..."},
        };
        Character Bodybuilder = new Character
        {
            Name="The Bodybuilder",
            Describtion="Just like the Security Guy, he will fuck you up if you start beef with him!",
            HealthPoints = 100,
            AttackDamage = 35,
            Characterinventory = new List<Item>(),
            Dialouge = {"Hey man what´s up?", "You´re checking out my muscles don´t you?", "Seen this Chick in the Outside Area? I will try my luck.."},

        };
        Character Barkeeper = new Character
        {
            Name="Barkeeper",
            Describtion="He is your friend, he delivers the Alkohol!",
            HealthPoints= 30,
            AttackDamage = 10,
            Isalive = true,
            Characterinventory = new List<Item>(),
            Dialouge = {"You look way too drunk, no more alkohol for you my friend!", "Don´t make a scene boy or i will call the Security Guy"},
        };
        Character DJ = new Character
        {
            Name="DJ",
            Describtion="Just a Guy who thinks he is the Boss because unfortunately he has the power over the music..",
            HealthPoints= 40,
            AttackDamage = 10,
            Characterinventory = new List<Item>(),
            Dialouge = {"No I won´t play your favourite Song!",}
         
        };

        Character Lady = new Character
        {
            Name="The beautiful Lady",
            Describtion="The sun is cold compared to her",
            HealthPoints = 50,
            AttackDamage = 5,
            Isalive = true,
            Characterinventory = new List<Item>(),
            Dialouge = {"Hey there!", "You look kinda cute to be honest...", "I need a drink right now!"}
        };
        public void initialize()
        {
            Room.addExitNorth(Foyer, Dancefloor);
            Room.addExitEast(Foyer, Toilet);
            Room.addExitWest(Dancefloor, OutdoorArea);
            Room.addExitNorth(Dancefloor, DJDesk);
            Room.addExitEast(Dancefloor, Bar);
            Player.Location = Foyer;

            
            Foyer.RoomInventory.Add(Cellphone);
            Foyer.CharacterList.Add(Security);

            Toilet.CharacterList.Add(CleaningLady);
            Toilet.RoomInventory.Add(CarKeys);

            Dancefloor.CharacterList.Add(Bodybuilder);

            OutdoorArea.CharacterList.Add(Lady);
            OutdoorArea.RoomInventory.Add(Gun);

            DJDesk.CharacterList.Add(DJ);
            DJDesk.RoomInventory.Add(Glass);

            Bar.CharacterList.Add(Barkeeper);
            Bar.RoomInventory.Add(BeerBottle);

            CleaningLady.Characterinventory.Add(Rolex);
            Barkeeper.Characterinventory.Add(BeerBottle);

            Console.WriteLine(Startuptext);
           
            Console.WriteLine("Type 'l' or 'look' to get a describtion of your location and its exits.");
            Console.WriteLine("To navigate between the different Spots type e.g. 'n' or 'north'.");
            Console.WriteLine("Type 'h' or 'help' to get the command list.");
            Console.WriteLine("\nType any command to continue... ");
            Console.WriteLine("You are in the " + Player.Location.Name);
        }

        
        public void doAction(string input)
        {   
            Console.WriteLine();
            try
            {
                if (Barkeeper.Isalive == false)
                {
                    OutdoorArea.Available = true ;
                }
                if (input == "n" || input == "north")
                {
                    if (Player.Location.Northexit != null && (Player.Location.Northexit.Available == true))
                    {
                        Player.Location = Player.Location.Northexit;
                        Character.getCharacterLocation(Player);
                        Room.getCharacterlist(Player.Location);
                        Room.getRoominventory(Player.Location);
                    } 
                    else 
                    {
                        Console.WriteLine("There is no way! Choose another one!");
                    }
                }
                if (input == "e" || input == "east")
                {
                    if (Player.Location.Eastexit != null  && (Player.Location.Eastexit.Available == true))
                    {
                        Player.Location = Player.Location.Eastexit;
                        Character.getCharacterLocation(Player);
                        Room.getCharacterlist(Player.Location);
                        Room.getRoominventory(Player.Location);
                    } 
                    else 
                    {
                        Console.WriteLine("There is no way! Choose another one!");
                    }
                }
                if (input == "s" || input == "south")
                {
                    if (Player.Location.Southexit != null && (Player.Location.Southexit.Available = true))
                    {
                        Player.Location = Player.Location.Southexit;
                        Character.getCharacterLocation(Player);
                        Room.getCharacterlist(Player.Location);
                        Room.getRoominventory(Player.Location);
                    } 
                    else 
                    {
                        Console.WriteLine("There is no way! Choose another one!");
                    }
                }

                if (input == "w" || input == "west")
                {
                    if (Player.Location.Westexit != null  && (Player.Location.Westexit.Available == true))
                    {
                        Player.Location = Player.Location.Westexit;
                        Character.getCharacterLocation(Player);
                        Room.getCharacterlist(Player.Location);
                        Room.getRoominventory(Player.Location);
                    } 
                    else
                    {
                        Console.WriteLine("There is no way! Choose another one!");
                    }
                } 

                if (input == "help" || input == "h")
                {
                    Console.WriteLine("'l' or 'look':       Shows you the room and its exits");
                    Console.WriteLine("'lookat X':         Gives you information about a specific Character");
                    Console.WriteLine("'t' or 'take' <item>:    Attempts to pick up an item.");
                    Console.WriteLine("'d' or 'drop':       Attemps to drop an item.");
                    Console.WriteLine("'use '<item>:             Attempts to use an item.");
                    Console.WriteLine("'i' or 'inventory':      Allows you to see the items in your inventory.");
                    Console.WriteLine("'q' or 'quit':       Quits the game.");
                    Console.WriteLine();
                    Console.WriteLine("Directions can be input as either the full word, or the abbriviation, e.g. 'north or n'");
                    return;
                }

                if (input == "i" || input == "inventory")
                {
                    if (Player.Characterinventory.Count() > 0)
                    {
                        Console.WriteLine("Your inventory contains the following Items: ");
                        Character.getCharacterinventory(Player);
                        Console.WriteLine();
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Your inventory contains no Items.");
                    }
                }
                
                if (input.StartsWith("t "))
                {   
                    string chooseditem = input.Substring(2, input.Length-2);
                    Character.take(Player.Location, Player, chooseditem);
                }
                if (input.StartsWith("take "))
                {
                    string chooseditem = input.Substring(5, input.Length-5);
                    Character.take(Player.Location, Player, chooseditem);
                }
                if (input.StartsWith("d "))
                {
                    string chooseditem = input.Substring(2, input.Length-2);
                    Character.drop(Player.Location, Player, chooseditem);
                }
                if (input.StartsWith("drop "))
                {
                    string chooseditem = input.Substring(5, input.Length-5);
                    Character.drop(Player.Location, Player, chooseditem);
                }
                if (input == "t" || input == "take")
                {
                    Console.Write("Choose the Item you want to pick up : 't' or 'take' <item>");
                }
                
                if (input == "l" || input == "look")
                {
                    Console.WriteLine(Player.Location.Describtion);
                    Console.WriteLine("You see:");
                    Room.getCharacterlist(Player.Location);
                    Room.getRoominventory(Player.Location);
                    Room.getExitDescribtion(Player);
                }
                if (input.StartsWith( "use "))
                {
                    string chooseditem = input.Substring(4, input.Length - 4);
                    Character.use(Player, chooseditem);
                    
                }

                if (input.StartsWith("attack "))
                {
                    string choosedcharacter = input.Substring(7, input.Length - 7);
                    Character.attack(Player, choosedcharacter);
                }

                if (input.StartsWith("talkto "))
                {
                    string choosedcharacter = input.Substring(7, input.Length - 7);
                    Character.talkto(Player, choosedcharacter);
                }

                if (input.StartsWith("lookat "))
                {
                    string choosedcharacter = input.Substring(7, input.Length - 7);
                    Character.lookat(Player, choosedcharacter); 
                }
                
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Invalid command. Type 'h' or 'help to get the command list.");
                
            }
        }
        
        public void Update()
        {

            if (Player.Isalive == false)
            {
                Console.WriteLine("You died. Game Over!");
                isRunning = false;
            }

            if (Player.EquippedItem == Rolex)
            {
                Console.WriteLine(Endtext);
                isRunning = false;
            }

            Console.Write("\n  -> Command: ");
            string input = Console.ReadLine().ToLower();

            if (input == "quit" || input == "q")
            {
                isRunning = false;
                return;
            }
            if (!_gameOver)
            {
               doAction(input);
            }
            else
            {
                Console.WriteLine("\nNope. Time to quit. \n");
            }
        }
    }
}
