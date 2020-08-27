using System;

namespace Ovning2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool run= true;
            while (run)
            {
                Console.WriteLine("Du har kommit till huvudmenyn. Vänligen välj ett alternativ: " + 
                "\n0: Stäng programmet" + 
                "\n1: Ange din ålder för att bestämma priset för en person" +
                "\n2: Bestäm priset för ett helt sällskap" +
                "\n3: Skriv text som ska upprepas tio gånger" +
                "\n4: Returnera tredje ordet från text med tre ord");
                int choice = AskForInt("Gör ditt val");
                // Utför olika funktioner beroende på användarens val
                switch (choice)
                {
                    case 0:
                        run = false;
                        break;
                    case 1:
                        PricePerson();
                        break;
                    case 2:
                        PriceCompany();
                        break;
                    case 3:
                        Repeat();
                        break;
                    case 4:
                        GiveThirdWord();
                        break;
                default:
                    Console.WriteLine("Du har angett felaktig input! Prova igen...");
                    Console.WriteLine();
                    break;
                }
            }
            
        }
        // Delar upp tre ord och returnerar tredje ordet
        private static void GiveThirdWord()
        {
            string text = AskForString("Skriv tre ord med mellanslag emellan");
            string [] array = text.Split(' ');
            Console.WriteLine($"Det tredje ordet är: {array[2]}");
            Console.WriteLine();
        }

        // Upprepa inmatade texten 10 ggr
        private static void Repeat()
        {
            string text = AskForString("Ange text: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{i + 1}.{text} ");
            }
            // För att få lite space efter upprepade texten
            Console.WriteLine();
            Console.WriteLine();
        }
        // Metod för att bestämma totalpriset för flera personer
        private static void PriceCompany()
        {

            int numberOfPersons = AskForInt("Ange hur många som ska på bio");
            int sumPrice = 0;
            for (int i = 0; i < numberOfPersons; i++)
            {
                int age = AskForInt($"Ange ålder för person {i + 1}");
                // Visar priset beroende på angiven ålder
                int price;
                if (age < 20) price = 80;
                else if (age > 64) price = 90;
                else price = 120;
                sumPrice += price;
            }
            Console.WriteLine($"Antal personer: {numberOfPersons}");
            Console.WriteLine($"Samt totalkostnaden för hela sällskapet: {sumPrice}");
            Console.WriteLine();
        }
        // Visar priset beroende på angiven ålder
        private static void PricePerson()
        {
            int age = AskForInt("Ange ålder för pesonen");
            if (age<20)
                Console.WriteLine("Ungdomspris: 80 kr");
            else if (age>64)
                Console.WriteLine("Pensionärspris: 80 kr");
            else
                Console.WriteLine("Standardpris 120kr");
        }       

        private static string AskForString(string prompt)
        {
            bool success = false;
            string answer; 

            do 
            {
                Console.WriteLine(prompt);
                answer = Console.ReadLine();

                if (!string.IsNullOrEmpty(answer))
                {
                    success = true;
                }

            } while (!success); 

            return answer;
        }

        private static int AskForInt(string prompt)
        {
            bool success = false;
            int answer;
            do
            {
                string input = AskForString(prompt);
                success = int.TryParse(input, out answer);

                if(!success)
                    Console.WriteLine("Fel format, mata in siffra");
                
            } while (!success);
            return answer;
        }
    }
}
