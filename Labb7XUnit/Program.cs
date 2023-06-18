namespace Labb7XUnit
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Vad vill du göra?");
                Console.WriteLine("1. Använd kalkylatorn\n2. Visa tidigare beräkningar\n3. Avsluta programmet");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        RunCalculator();
                        break;
                    case "2":
                        ViewPreviousCalculations();
                        Console.ReadKey();
                        break;
                    case "3":
                        return;
                    default:
                        Console.Clear();
                        break;
                }
            }

            static void RunCalculator()
            {
                Console.Clear();
                Console.WriteLine("Vilket räknesätt vill du använda?");
                Console.WriteLine("1. Addition\n2. Subtraktion\n3. Division\n4. Multiplikation");
                string choice = SelectMethod();
                Console.Clear();
                Console.WriteLine("Skriv in din första siffra");
                double n1 = SelectNumber();
                Console.Clear();
                Console.WriteLine("Skriv in din andra siffra");
                double n2 = SelectNumber();
                Console.Clear();
                double result = RunMethod(choice, n1, n2);
                Calculator.CreateResult(choice, n1, n2, result);
                if (Calculator.CheckDivideZero(choice, n2))
                {
                    Console.WriteLine("Du kan inte dividera med 0. Försök igen.");
                }
                else
                {
                    Console.WriteLine(Calculator.calculations.Last());
                }
                Console.ReadKey();
                Console.Clear();
            }

            static void ViewPreviousCalculations()
            {
                if (Calculator.calculations.Count == 0)
                {
                    Console.WriteLine("Inga beräkningar har utförts än");
                }
                else
                {
                    foreach (string s in Calculator.calculations)
                    {
                        Console.WriteLine(s);
                    }
                }
            }

            static string SelectMethod()
            {
                string choice;
                do
                {
                    choice = Console.ReadLine();
                } while (choice != "1" && choice != "2" && choice != "3" && choice != "4");
                return choice;
            }

            static double RunMethod(string choice, double n1, double n2)
            {
                double result = 0;
                switch (choice)
                {
                    case "1":
                        result = Calculator.Addition(n1, n2);
                        break;
                    case "2":
                        result = Calculator.Subtraction(n1, n2);
                        break;
                    case "3":
                        result = Calculator.Division(n1, n2);
                        break;
                    case "4":
                        result = Calculator.Multiplication(n1, n2);
                        break;
                    default: break;
                }
                return result;
            }

            static double SelectNumber()
            {
                double num;
                bool success;
                do
                {
                    success = double.TryParse(Console.ReadLine(), out num);
                } while (!success);
                return num;
            }

        }
    }
}