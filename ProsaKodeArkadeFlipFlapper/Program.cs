using System;
using System.Collections.Generic;
using System.Linq;

namespace ProsaKodeArkadeFlipFlapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FlipFlapper flipFlapper = new FlipFlapper();

            Console.WriteLine("Velkommen til Flip Flapper\n Vælg ved at skrive nummeret på din valgmulighed");

            flipFlapper.Game();
        }

        
    }
}
 