/*
Create a class Smoothie and do the following:

Create a property called Ingredients.
Create a GetCost method which calculates the total cost of the ingredients used to make the smoothie.
Create a GetPrice method which returns the number from GetCost plus the number from GetCost multiplied by 2.5. Round to two decimal places.
Create a GetName method which gets the ingredients and puts them in alphabetical order into a nice descriptive sentence. If there are multiple ingredients, add the word "Fusion" to the end but otherwise, add "Smoothie". Remember to change "-berries" to "-berry". See the examples below.
Ingredient Price
Strawberries $1.50
Banana $0.50
Mango $2.50
Blueberries $1.00
Raspberries $1.00
Apple $1.75
Pineapple $3.50

Examples
s1 = Smoothie(new string[] { "Banana" })

s1.Ingredients --> { "Banana" }

s1.GetCost() --> "$0.50"

s1.GetPrice() --> "$1.25"

s1.GetName() --> "Banana Smoothie"
s2 = Smoothie(new string[] { "Raspberries", "Strawberries", "Blueberries" })
s2.ingredients --> { "Raspberries", "Strawberries", "Blueberries" }

s2.GetCost() --> "$3.50"

s2.GetPrice() --> "$8.75"

s2.GetName() --> "Blueberry Raspberry Strawberry Fusion"
*/

using System;
using System.Collections.Generic;
using System.Globalization;

namespace _9_20_2021
{
    class Smoothie
    {
        public static Dictionary<string, double> _priceTable = new Dictionary<string, double>()
        {
            {"Strawberries", 1.50},
            {"Banana", 0.50},
            {"Mango", 2.50},
            {"Blueberries", 1.00},
            {"Raspberries", 1.00},
            {"Apple", 1.75},
            {"Pineapple", 3.50}
        };
        private string[] _ingredients;
        public Smoothie() {}
        public Smoothie(string[] p_ingredients)
        {
            this._ingredients = p_ingredients;
        }
        public string[] Ingredients
        {
            get {return this._ingredients;}
            set {this._ingredients = value;}
        }

        public double GetCost()
        {
            double cost = 0;

            foreach (string ingredient in this._ingredients)
            {
                if (Smoothie._priceTable.ContainsKey(ingredient))
                {
                    cost += Smoothie._priceTable[ingredient];
                }
            }

            return cost;
        }

        public string GetPrice()
        {
            return (this.GetCost()*2.5).ToString("C", CultureInfo.CurrentCulture); // displays 2 decimal places by default "C"
        }

        public string GetName()
        {
            List<string> names = new List<string>();

            foreach (string name in this._ingredients)
            {
                if (name.Length > 9) 
                {
                    if (name.Substring(name.Length - 7) == "berries")
                    {
                        names.Add(string.Concat(name.Substring(0, name.Length - 3), "y"));
                    } else
                    {
                        names.Add(name);
                    }
                } else
                {
                    names.Add(name);
                }
            }

            if (names.Count < 2)
            {
                names.Add("Smoothie");
            } else 
            {
                names.Sort();
                names.Add("Fusion");
            }
            
            return string.Join(" ", names);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Smoothie s1 = new Smoothie(new string[] { "Banana" });
            Console.WriteLine("Smoothie #1");
            Console.Write("Smoothie Ingredients: ");
            Console.WriteLine("{{ {0} }}", string.Join(", ", s1.Ingredients));
            Console.Write("Smoothie Cost: ");
            Console.WriteLine("{0}", s1.GetCost().ToString("C", CultureInfo.CurrentCulture));
            Console.Write("Smoothie Price: ");
            Console.WriteLine(s1.GetPrice());
            Console.Write("Smoothie Name: ");
            Console.WriteLine(s1.GetName());
            
            Console.WriteLine("--------------------------");
            Smoothie s2 = new Smoothie(new string[] { "Raspberries", "Strawberries", "Blueberries" });
            Console.WriteLine("Smoothie #2");
            Console.Write("Smoothie Ingredients: ");
            Console.WriteLine("{{ {0} }}", string.Join(", ", s2.Ingredients));
            Console.Write("Smoothie Cost: ");
            Console.WriteLine("{0}", s2.GetCost().ToString("C", CultureInfo.CurrentCulture));
            Console.Write("Smoothie Price: ");
            Console.WriteLine(s2.GetPrice());
            Console.Write("Smoothie Name: ");
            Console.WriteLine(s2.GetName());
            
            Console.WriteLine("--------------------------\nMake your own Smoothie:");
            string userInput = "";
            bool loop = true;
            Smoothie s3 = new Smoothie();
            List<string> cart = new List<string>();
            
            while (loop)
            {
                Console.WriteLine("0. Done; Show Smoothie order.");
                Console.WriteLine("1. {0}: ${1}","Strawberries", Smoothie._priceTable["Strawberries"]);
                Console.WriteLine("2. {0}: ${1}","Banana", Smoothie._priceTable["Banana"]);
                Console.WriteLine("3. {0}: ${1}","Mango", Smoothie._priceTable["Mango"]);
                Console.WriteLine("4. {0}: ${1}","Blueberries", Smoothie._priceTable["Blueberries"]);
                Console.WriteLine("5. {0}: ${1}","Raspberries", Smoothie._priceTable["Raspberries"]);
                Console.WriteLine("6. {0}: ${1}","Apple", Smoothie._priceTable["Apple"]);
                Console.WriteLine("7. {0}: ${1}","Pineapple", Smoothie._priceTable["Pineapple"]);
                Console.WriteLine("8. Exit.");
                Console.Write("\nEnter integer option: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "0":
                        if (cart.Count > 0) {
                            s3.Ingredients = cart.ToArray();
                            Console.WriteLine("--------------------------\nHere is your Smoothie!");
                            Console.Write("Smoothie Ingredients: ");
                            Console.WriteLine("{{ {0} }}", string.Join(", ", s3.Ingredients));
                            Console.Write("Smoothie Cost: ");
                            Console.WriteLine("{0}", s3.GetCost().ToString("C", CultureInfo.CurrentCulture));
                            Console.Write("Smoothie Price: ");
                            Console.WriteLine(s3.GetPrice());
                            Console.Write("Smoothie Name: ");
                            Console.WriteLine(s3.GetName());
                            cart.Clear();
                            Console.WriteLine("Hit Enter to continue");
                            Console.ReadLine();
                            Console.Clear();
                        } else {
                            Console.WriteLine("\nNo Ingredients have been added!");
                            Console.WriteLine("Hit Enter to continue");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                    case "1":
                        if (cart.Contains("Strawberries"))
                        {
                            Console.WriteLine("Strawberries have already been added!");
                        } else
                        {
                            cart.Add("Strawberries");
                        }
                        break;
                    case "2":
                        if (cart.Contains("Banana"))
                        {
                            Console.WriteLine("Banana have already been added!");
                        } else
                        {
                            cart.Add("Banana");
                        }
                        break;
                    case "3":
                        if (cart.Contains("Mango"))
                        {
                            Console.WriteLine("Mango have already been added!");
                        } else
                        {
                            cart.Add("Mango");
                        }
                        break;
                    case "4":
                        if (cart.Contains("Blueberries"))
                        {
                            Console.WriteLine("Blueberries have already been added!");
                        } else
                        {
                            cart.Add("Blueberries");
                        }
                        break;
                    case "5":
                        if (cart.Contains("Raspberries"))
                        {
                            Console.WriteLine("Raspberries have already been added!");
                        } else
                        {
                            cart.Add("Raspberries");
                        }
                        break;
                    case "6":
                        if (cart.Contains("Apple"))
                        {
                            Console.WriteLine("Apple have already been added!");
                        } else
                        {
                            cart.Add("Apple");
                        }
                        break;
                    case "7":
                        if (cart.Contains("Pineapple"))
                        {
                            Console.WriteLine("Pineapple have already been added!");
                        } else
                        {
                            cart.Add("Pineapple");
                        }
                        break;
                    case "8":
                        loop = false;
                        Console.WriteLine("Have a good day! =)");
                        break;
                    default:
                        Console.WriteLine("Invalid input! Please enter an integer (ex: 1)");
                        break;
                }
            }
            
        }
    }
}
