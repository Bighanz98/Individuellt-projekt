using System.Reflection.Metadata.Ecma335;

namespace Individuellt_projekt
{
    internal class Program
    {
        static string[] userAccounts = { "Anton", "Adam", "Simon", "Petter", "Linus" };
        static string[] userPinCodes = { "1111", "2222", "3333", "4444", "5555" };
        static string[] userAccAndBalance = { "Sparkonto", "Semsterkonto", "Spelkonto", "Sparkonto", "konto"};
        static void Main(string[] args)
        {

            Console.WriteLine("----------------------");
            Console.WriteLine("Välkommen till banken!");
            Console.WriteLine("----------------------");

            LogIn();


            Console.ReadKey();
        }
        static void LogIn()
        {
            bool loggedIn = false;
            int maxLogAttempts = 3;

            while (!loggedIn && maxLogAttempts > 0)
            {
                Console.Write("Logga in med din PIN-kod:");
                string userPIN = Console.ReadLine();

                for (int i = 0; i < userPinCodes.Length; i++)
                {
                    if (userPinCodes[i] == userPIN)
                    {
                        Console.Clear();
                        Console.WriteLine($"Hej, {userAccounts[i]}!");                      
                        loggedIn = true;
                        BankMenu();
                        break;                       
                    }
                }
                if (!loggedIn) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nFelaktig PIN-kod! Försök igen, du har {maxLogAttempts} försök kvar");
                    Console.ResetColor();
                    maxLogAttempts--;
                }
               
            }
            
            static void BankMenu()
            {
                Console.WriteLine("\n1. Se dina konton och saldo ");
                Console.WriteLine("2. Överföring mellan konton");
                Console.WriteLine("3. Ta ut pengar ");
                Console.WriteLine("4. Logga ut ");
                Console.Write("\nVälj ett alternativ: ");


                try
                {
                    int userChoice = Convert.ToInt32(Console.ReadLine());

                    switch (userChoice)
                    {
                        case 1:
                            AccAndBalance();
                            break;
                        case 2:
                            TransferMoney();
                            break;
                        case 3:
                            WithdrawMoney();
                            break;
                        case 4:
                            LogOut();
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ogiltigt val. Välj mellan 1-4. ");
                            Console.ResetColor();
                            break;

                    }

                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ogiltigt val. Du måste skriva en siffra mellan 1-4.");
                    Console.ResetColor();
                }

                static void AccAndBalance()
                {
                    for (int i = 0; i < userAccAndBalance.Length; i++)
                    {
                        
                        Console.Clear();
                        Console.WriteLine($"Konton: {userAccAndBalance[i]} ");
                    }
                }
                static void TransferMoney()
                {

                }
                static void WithdrawMoney()
                {

                }
                static void LogOut()
                {
                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.WriteLine("Loggar ut...");
                    Thread.Sleep(3000);
                    Console.Clear();
                    LogIn();
                }
            }
        }
    }
}