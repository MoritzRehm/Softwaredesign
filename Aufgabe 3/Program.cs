﻿using System;

namespace Aufgabe3
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine(ConvertNumberToBaseFromBase(255,2,10));
        }

        public static int ConvertDecimalToHexal(int dec){
            
            int actual = dec;
            int integer = 0;
            int modulo = 0;
            int result = 0;
            int i=1;

            while(actual != 0)
            {
                integer = actual / 6;
                modulo = actual % 6;
                actual = integer; 
                result += modulo*i;
                i *= 10; 
            }
            

            return result ;
        }

        public static int ConvertHexalToDezimal(int hexal){

            
            int actual = hexal;
            int integer = 0;
            int modulo = 0;
            int result = 0;
            int i=1;

            while(actual != 0)
            {
                integer = actual / 10;
                modulo = actual % 10;
                actual = integer; 
                result += modulo*i;
                i *= 6; 
            }
            

            return result ;        
        
        
        }
       public static int ConvertToBaseFromDecimal(int toBase, int dec){
            int actual = dec;
            int integer = 0;
            int modulo = 0;
            int result = 0;
            int i=1;

            while(actual != 0)
            {
                integer = actual / toBase;
                modulo = actual % toBase;
                actual = integer; 
                result += modulo*i;
                i *= 10; 
            }
            return result ;            
        }
          public static int ConvertToDecimalFromBase(int toBase, int dec){
            int actual = dec;
            int integer = 0;
            int modulo = 0;
            int result = 0;
            int i=1;
            int exponent = 1;

            while(actual != 0)
            {
                integer = actual / 10;
                modulo = actual % 10;
                actual = integer; 
                result += modulo*exponent;
                exponent *= toBase;
                i *= 10; 
            }
            return result ;            
        }

          public static int ConvertNumberToBaseFromBase(int number, int toBase, int fromBase){
            int result = number;
            result = ConvertToDecimalFromBase(fromBase,result);
            Console.WriteLine(result);
            result = ConvertToBaseFromDecimal(toBase,result);
            Console.WriteLine(result);
            return result ;            
        }
        

    }
}