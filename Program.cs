using System;

namespace ChangeCalc
{
    class Program
    {
        static double cost;
        static double paid;
        static double remainder;
        static double[] money = { 100, 50, 20, 10, 5, 2, 1, 0.5, 0.2, 0.1, 0.05 };
        static string type;
        static string currency;


        static void Main(string[] args)
        {
            Console.Write("Enter cost: ");
            cost = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter amount paid: ");
            paid = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\nItem cost: $" + String.Format("{0:0.00}", cost));
            Console.WriteLine("Amount paid: $" + String.Format("{0:0.00}", paid));

            GetChange();

            Console.ReadLine();
        }

        static void GetChange()
        {
            string note;
            string change = String.Format("{0:0.00}", paid - cost);
            Console.WriteLine("Change: $" + change);
            Console.WriteLine("\nChange given: ");

            remainder = paid - cost;
            int numnotes = 0;

            foreach (double i in money)
            {
                // Rounding if remaining change is less than 5c.
                // For some reason the program was displaying 0.049999 rather than 0.05.
                if (remainder > 0)
                {
                    if (remainder >= .03 && remainder <= .05)
                    {
                        remainder = .05;
                    } else if (remainder < .03)
                    {
                        remainder = 0;
                    }
                    for (numnotes = 0; remainder - i >= 0; numnotes++)
                    {
                        remainder -= i;
                    }
                }

                // Formatting of money type to be printed.
                if (i >= 1)
                {
                    note = i.ToString();
                }
                else if (i > .05)
                {
                    note = String.Format("{0:.00}", i).Substring(1, 2);
                }
                else
                {
                    note = String.Format("{0:.00}", i).Substring(2);
                }

                if (i >= 5 && numnotes > 1)
                {
                    type = "notes";
                } else if (i >= 5 && numnotes <= 1)
                {
                    type = "note";
                } else if (i < 5 && numnotes > 1)
                {
                    type = "coins";
                } else if (i < 5 && numnotes <= 1)
                {
                    type = "coin";
                }

                if (i >= 1)
                {
                    currency = "$";
                } else
                {
                    currency = "c";
                }

                if (numnotes != 0)
                {
                    if(i >= 1)
                    {
                        Console.WriteLine(numnotes.ToString() + " x " + currency + note + " " + type);
                    } else
                    {
                        Console.WriteLine(numnotes.ToString() + " x " + note + currency + " " + type);
                    }
                }
            }
        }
    }
}
