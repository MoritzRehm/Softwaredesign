using System;

public class Auto <PLATZHALTER>
{
    public double PS;

    public int Zylinder;

    public double Hubraum;

    public PLATZHALTER Farbe;
}





namespace L01_Source_Control
{
    class Program
    {
        static void Main(string[] args)
        {   
            // BESTELLVORGANG
            Auto <string> meinAuto = new Auto<string>();
            meinAuto.Farbe = "grau";

            // VERKAUF
            Auto <int> einanderesAuto = new Auto <int>();
            einanderesAuto.Farbe = 65;
        }
    }
}
