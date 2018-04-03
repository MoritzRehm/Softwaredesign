using System;

namespace Aufgabe_1
{
    class Program
    {
        static void Main(string[] args)
        {   
            
            Console.WriteLine("Würfel (w),  Kugel (k) oder Oktaeder (o)?");
            string eingabe = (Console.ReadLine());

            Console.WriteLine("Durchmesser d =");
            double d = Console.Read();

            switch(eingabe){
                case "w":
                Console.WriteLine("Oberfläche:" + getCubeSurface(d));
                Console.WriteLine("Volumen:" + getCubeVolume(d));
                break;

                case "k":
                Console.WriteLine("Oberfläche:" + getSphereSurface(d));
                Console.WriteLine("Volumen:" + getSphereVolume(d));
                break;

                case "o":
                Console.WriteLine("Oberfläche:" + getOktaSurface(d));
                Console.WriteLine("Volumen:" + getOktaVolume(d));
                break;
                

            }

            /*if (eingabe == "w"){
                Console.WriteLine("Test");

            }*/

        }


            public static double getCubeSurface(double d) {
                double ow = 6*d*d;
                return ow;
    
            }
            public static double getCubeVolume(double d){
                double vw = d*d*d;
                return vw;
            }
        


            public static double getSphereSurface(double d) {
                double ok = 3.14 *d*d;
                return ok; 
            }
            public static double getSphereVolume(double d){
                double vk = 3.14*d*d*d/6;
                return vk;
            }


            public static double getOktaSurface(double d)  {
                double oo = 2 * Math.Sqrt(3) * d * d;
                return oo;
        
            }
            public static double getOktaVolume(double d){
                double vo = Math.Sqrt(2)*d*d*d/3;
                return vo;
            }
    }
}
