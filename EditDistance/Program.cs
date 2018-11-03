using System;

namespace EditDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Edit Distance!");
            Console.WriteLine("--------------");

            Console.WriteLine("Enter the first string");
            String firstString = Console.ReadLine();

            Console.WriteLine("Enter the second string");
            String secondString = Console.ReadLine();

            int[,] editDistance = new int[firstString.Length+1, secondString.Length+1];

            for (int i = 1; i <= firstString.Length; i++) {
                for (int j = 1; j <= secondString.Length; j++) {
                    if (i == 0)
                    {
                        editDistance[i, j] = j;
                    }
                    else if (j == 0)
                    {
                        editDistance[i, j] = i;
                    }
                    else {
                        if (firstString[i - 1] == secondString[j - 1])
                        {
                            editDistance[i, j] = editDistance[i - 1, j - 1];
                        }
                        else {
                            editDistance[i, j] = 1 + Math.Min(
                                editDistance[i - 1, j - 1],
                                Math.Min(editDistance[i - 1, j], editDistance[i, j - 1])
                                );
                        }
                    }
                }
            }

            Console.WriteLine("---------------------The Result----------------------------------------");

            Console.WriteLine("The mimum number of steps required to convert " +
                "the First String to the Second string is "+editDistance[firstString.Length, secondString.Length]);

            Console.ReadLine();
        }
    }
}
