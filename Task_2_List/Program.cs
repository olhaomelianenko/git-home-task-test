using System;
using System.Collections.Generic;

namespace Task_2_List
{
    internal class Program
    {
        static void Main()
        {
            SuperHero superHero1 = new SuperHero()
            {
                Name = "Stephen Strange",
                Alias = "Doctor Strange"
            };
            SuperHero superHero2 = new SuperHero()
            {
                Name = "Wanda Maximoff",
                Alias = "Scarlet Witch"
            };
            SuperHero superHero3 = new SuperHero()
            {
                Name = "Peter Parker",
                Alias = "Spider-Man"
            };

            SuperHeroList<SuperHero> superHeroes = new SuperHeroList<SuperHero>();

            /* Add functionality */
            superHeroes.Add(superHero1);
            superHeroes.Add(superHero2);
            superHeroes.Add(superHero2);
            superHeroes.Add(superHero2);
            superHeroes.Add(superHero3);

            /* Remove functionality */
            superHeroes.Remove(superHero2);
            superHeroes.Remove(new SuperHero { Name = "Wanda Maximoff", Alias = "Scarlet Witch" }) ;
            
            /* Iterating through the collection */
            foreach (SuperHero sh in superHeroes)
            {
                Console.WriteLine(sh);
            }

            /* To explicitly invoke generic methods */
            /*Console.WriteLine();
            IEnumerable<SuperHero> superHeroesGeneric = superHeroes;
            foreach (SuperHero shg in superHeroesGeneric)
            {
                Console.WriteLine(shg);
            }*/

            /* Access by index */
            Console.WriteLine();
            for (int i = 0; i < superHeroes.Length; i++)
            {
                Console.WriteLine(superHeroes[i]);
            }

            int outOfRangeIndex = -1;
            //int outOfRangeIndex = 3;
            try
            {
                Console.WriteLine($"\n{superHeroes[outOfRangeIndex]}");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"Index {outOfRangeIndex} is out of range, exception!");
            }
        }
    }
}
