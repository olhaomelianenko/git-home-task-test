using System;
using System.Linq;
using System.Collections;

namespace Task_4_LINQ
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("== Class task ==");
            Console.WriteLine(ClassTask(3));

            Console.WriteLine("== Home task 1 ==");
            Console.WriteLine(HomeTask1("Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert"));

            Console.WriteLine("== Home task 2 ==");
            IEnumerable players = HomeTask2("Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988");
            foreach(Player player in players)
            {
                Console.WriteLine(String.Format("{0}'s age is {1}", player.Name, player.Age));
            }

            Console.WriteLine("== Home task 3 ==");
            Console.WriteLine(HomeTask3("4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27"));
            
            Console.ReadKey();
        }

        /*
         * Зробіть linq вираз, який згенерує послідовність стрічок у форматі “x,y”, які б відповідали матриці 3Х3.
         * Тобто результат б мав бути “0,0”  “0,1”  “0,2”  “1,0”  “1,1”  “1,2”  “2,0”  “2,1”  “2,2”
         */
        static string ClassTask(int dimension)
        {
            return Enumerable.Range(0, dimension * dimension)
                .Select(num => String.Format("{0},{1}", num / dimension, num - dimension * (num / dimension)))
                .Aggregate((current, next) => current + " " + next);
        }

        /*
         * На вхід є стрічка  "Davis, Clyne, Fonte, Hooiveld, Shaw, Davis, Schneiderlin, Cork, Lallana, Rodriguez, Lambert"
         * Кожному гравцеві надайте номер, починаючи з 1, щоб вийшла стрічка подібна : "1. Davis, 2. Clyne, 3. Fonte" ...
         */
        static string HomeTask1(string players)
        {
            string[] playersArr = players.Split(", ");
            return Enumerable.Range(1, playersArr.Length)
                .Zip(playersArr, (first, second) => first + ". " + second).
                Aggregate((current, next) => current + ", " + next);
        }

        /*
         * Візьміть стрічку "Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988"
         * і перетворіть її на IEnumerable гравців в порядку віку (і ще бажано вивести вік)
         */
        internal class Player
        {
            public string Name { get; set; }
            public string BirthDate { get; set; }
            public int Age { get; set; }
        }
        static IEnumerable HomeTask2(string players)
        {
            string[] playersArr = players.Split("; ");
            return playersArr.Select(p => new Player()
                                            {
                                                Name = p.Split(", ")[0],
                                                BirthDate = p.Split(", ")[1],
                                                // TODO: improve age calculation logic
                                                Age = DateTime.Now.Year - Int32.Parse(p.Split(", ")[1].Split('/')[2])
                                            })
                                .ToList()
                                .OrderBy(p => p.Age)
                                .ToList();
        }

        /*
         * Візьміть стрічку "4:12,2:43,3:51,4:29,3:24,3:14,4:46,3:25,4:52,3:27",
         * яка відображає довжину пісень в хвилинах і секундах і обрахуйте загальну довжину всіх пісень.
         */
        static string HomeTask3(string songsLen)
        {
            string[] songsLenArr = songsLen.Split(",");
            var lenInSec = songsLenArr.Select(s => Int32.Parse(s.Split(':')[0]) * 60 + Int32.Parse(s.Split(':')[1])).Sum();
            TimeSpan interval = new TimeSpan(0, 0, lenInSec);
            return String.Format("{0}:{1}:{2}", interval.Hours, interval.Minutes, interval.Seconds);
        }
    }
}
