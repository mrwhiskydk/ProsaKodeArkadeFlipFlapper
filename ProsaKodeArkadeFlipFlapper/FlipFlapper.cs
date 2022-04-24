using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsaKodeArkadeFlipFlapper
{
    internal class FlipFlapper
    {
        int level = 1;
        int layerDepth = 3;

        //Level 1
        Dictionary<int, string> level1 = new Dictionary<int, string>()
        {
            {1, "rød" },
            {2, "grøn" },
            {3, "lyserød" },
            {4, "lilla" }
        };

        Dictionary<int, string> level2 = new Dictionary<int, string>()
        { 
            { 1, "1" }, 
            { 2, "2" }, 
            { 3, "3" }, 
            { 4, "4" }, 
            { 5, "5" }, 
            { 6, "6" }, 
            { 7, "7" }, 
            { 8, "8" } 
        }; //lol?

        Dictionary<int, string> level3 = new Dictionary<int, string>()
        {
            {1, "Hop 10 gange" },
            {2, "Lav 5 sprællemænd" },
            {3, "tag 10 armbøjninger" },
            {4, "Hvad er 5 x 7?" },
            {5, "Hvad vejer mest: 1kg fjer eller 1kg stål" },
            {6, "Hvad er din yndlingsfarve?" },
            {7, "Hav en god dag" },
            {8, "Aglet på dansk er: Snørebåndsdup, Plastikdup, Metaldup eller Snørebandsdup" },
        };

        Dictionary<int, string> currentOptions;

        public void Game()
        {
            currentOptions = level1;
            for (int i = 0; i < layerDepth - 1; i++)
            {
                GetInput();
            }
        }

        public Dictionary<int, string> GetLevelOptions(int level)
        {
            switch (level)
            {
                case 1:
                    return level1;
                case 2:
                    return level2;
                case 3:
                    return level3;
                default:
                    return level1;
            }
        }

        public void GetInput()
        {
            int nrInput = -1;
            bool validInput = false;
            bool success = false;

            PrintOptions();

            while (success == false)
            {
                Console.Write("Valg: ");
                string input = Console.ReadLine();
                validInput = int.TryParse(input, out nrInput);

                if (validInput)
                {
                    foreach (var item in currentOptions)
                    {
                        if (item.Key == nrInput)
                        {
                            level++;
                            Console.WriteLine(item.Value);

                            GetNewOptions(nrInput);
                            success = true;

                            if (level == 3)//lazy but im too tired
                            {
                                Console.WriteLine(level3[nrInput]);
                            }

                            return;
                        }
                    }
                }
                if (!success)
                {
                    Console.WriteLine("Dit valg var ugyldigt. Skriv tallet på dit valg");
                }
            }
        }

        public void PrintOptions()
        {
            Console.WriteLine("Valgmuligheder:");

            foreach (var item in currentOptions)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

        public Dictionary<int, string> GetNewOptions(int flips)
        {
            int decider = 0;
            if (flips % 2 == 0)
            {
                decider = 1;
            }
            //var hh = GetLevelOptions(level).ToDictionary(x => x.Key, x => x.Value);
            currentOptions = GetLevelOptions(level).Where(x => x.Key % 2 == decider).ToDictionary(pair => pair.Key, pair => pair.Value);
            return currentOptions;
        }
    }
}
