using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TextAdventure
{
    class Character : Gameobject
    {
        public Room Location;
        public bool Isalive;
        public int HealthPoints;
        public int AttackDamage;
        public bool IsAgressive;
        public List<Item> Characterinventory;

        public int Dialougeline = 0;

        public List<String> Dialouge = new List<String>();


        public Item EquippedItem;
        

        public static void getCharacterLocation(Character c)
        {
            Console.WriteLine("You are in the " + c.Location.Name + ". You see ");
        }
     


        public static void attack(Character c, string choosedcharacter)
        {
            for (int i = c.Location.CharacterList.Count -1; i >= 0; i--)
            {
                if (choosedcharacter == c.Location.CharacterList[i].Name.ToLower())
                {
                    Character npc = c.Location.CharacterList[i];
                    Console.WriteLine(c.Location.CharacterList[i].Name + " has been attacked with " + c.AttackDamage + " attackdamage.");
                    c.Location.CharacterList[i].HealthPoints -= c.AttackDamage;
                    if (c.Location.CharacterList[i].HealthPoints <= 0)
                    {
                        Console.WriteLine(c.Location.CharacterList[i].Name + " has been killed.");
                        if (c.Location.CharacterList[i].Characterinventory.Count > 0)
                        {
                            foreach (var item in c.Location.CharacterList[i].Characterinventory)
                            {
                                Console.WriteLine(c.Location.CharacterList[i].Name + " dropped " + item.Value + " " + item.Name + ".");
                                c.Location.RoomInventory.Add(item);
                            }
                        }
                        c.Location.CharacterList[i].Isalive = false;
                        c.Location.CharacterList.Remove(c.Location.CharacterList[i]);
                        return;
                    }
                    Console.WriteLine(c.Location.CharacterList[i].Name + " has " + c.Location.CharacterList[i].HealthPoints + " Health Points left.");
                    
                    getattack(c, npc);
                }
            }
        }

        public static void getattack (Character c, Character npc)
        {
            c.HealthPoints -= npc.AttackDamage;
            Console.WriteLine(npc.Name + " attacked you with " + npc.AttackDamage + " attackdamage. Your healthpoints decreased to " + c.HealthPoints + ".");
            if (c.HealthPoints <= 0)
            {
                c.Isalive = false;
                
            }
        }

        public static void use(Character c, string chooseditem)
        {
            for (int l = c.Characterinventory.Count -1; l >= 0; l--)
            {
                if (chooseditem == c.Characterinventory[l].Name.ToLower())
                {
                    if (c.Characterinventory[l].Carryable == true)
                    {
                        Character.equip(c, chooseditem, l);
                      
                    }
                }
            }

        }

        public static void equip(Character c, string chooseditem, int i)
        {
            if (c.EquippedItem != null)
            {
                Console.WriteLine(c.EquippedItem.Name + " has been dropped.");
                c.Location.RoomInventory.Add(c.EquippedItem);
            }
            c.EquippedItem = c.Characterinventory[i] ;
            Console.WriteLine(c.Characterinventory[i].Name + " has been equipped.");
            c.AttackDamage = 20 + c.EquippedItem.Attackdamage;
            Console.WriteLine("Your attackdamage is " + c.AttackDamage + " now.");
            c.Characterinventory.Remove(c.Characterinventory[i]);
            
        }

        public static void take(Room r, Character c, string chooseditem)
        {
            for (int i = r.RoomInventory.Count -1; i >= 0; i--)
            {
                if (chooseditem == r.RoomInventory[i].Name.ToLower())
                {
                    Console.WriteLine(r.RoomInventory[i].Name + " has been added to your inventory.");
                    Console.WriteLine(r.RoomInventory[i].Describtion);
                    c.Characterinventory.Add(r.RoomInventory[i]);
                    r.RoomInventory.Remove(r.RoomInventory[i]);    
                }

            }
        }
        public static void drop(Room r, Character c, string chooseditem)
        {
            for (int i = c.Characterinventory.Count -1; i >= 0; i--)
            {
                if (chooseditem == c.Characterinventory[i].Name.ToLower())
                {
                    Console.WriteLine(c.Characterinventory[i].Name + " has been removed from your inventory.");
                    r.RoomInventory.Add(c.Characterinventory[i]);
                    c.Characterinventory.Remove(c.Characterinventory[i]);
                }
            }
        }


        public static void talkto(Character c,string choosedcharacter)
        {
            for (int i = c.Location.CharacterList.Count -1; i >= 0; i--)
            {
                if (choosedcharacter == c.Location.CharacterList[i].Name.ToLower())
                {
                    Console.WriteLine(c.Location.CharacterList[i].Name + " says: '" + c.Location.CharacterList[i].Dialouge[c.Location.CharacterList[i].Dialougeline] + "'");
                    if (c.Location.CharacterList[i].Dialougeline < c.Location.CharacterList[i].Dialouge.Count -1)
                    {
                        c.Location.CharacterList[i].Dialougeline += 1;
                    }
                    return;
                }
            }
            Console.WriteLine("The choosed character '" + choosedcharacter + "' doesn't exist in this room.");
            
        }

        public static void lookat(Character c, string choosedcharacter)
        {
            for (int i = c.Location.CharacterList.Count -1; i >= 0; i--)
            {
                if (choosedcharacter == c.Location.CharacterList[i].Name.ToLower())
                {
                    Console.WriteLine(getdescribtion(c.Location.CharacterList[i]));
                    
                }     
            }
        }

        public static void getCharacterinventory(Character c)
        {
            foreach (var item in c.Characterinventory)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
