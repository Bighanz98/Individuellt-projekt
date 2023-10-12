using System.Reflection.Metadata.Ecma335;

namespace Individuellt_projekt
{
    internal class Program
    {
        //Anton Hansson SUT23

        static string[] userAccounts = { "Anton", "Adam", "Simon", "Petter", "Linus" }; // Array till användare.
        static string[] userPinCodes = { "1111", "2222", "3333", "4444", "5555" }; // Array för PIN-koder.
        static string[][] userSavingsAcc = { // Jagged Array, eller "array of arrays" för sparkonton.
            new string [] {"Sparkonto", "Semesterkonto", "Spelkonto", "Bensinkonto", "Oförutsägbara utgifter"},
            new string [] {"Sparkonto", "Semesterkonto", "Spelkonto", "Bensinkonto"},
            new string [] {"Sparkonto", "Semesterkonto", "Spelkonto"},
            new string [] {"Sparkonto", "Semesterkonto"},
            new string [] {"Sparkonto"}
        };
        static double[][] userBalance = { //Jagged array för pengarna som finns på alla konton.
            new double [] {50000, 10000, 2000, 3000, 5000},
            new double [] {20000, 3000, 500, 1000},
            new double [] {1000, 7000, 15000},
            new double [] {100000, 30000},
            new double [] {25000}
        };
        
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Yellow; //Kod som välkomnar avändaren till banken.
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("------------------------");
            Console.WriteLine("                        ");
            Console.WriteLine(" Välkommen till banken! ");
            Console.WriteLine("                        ");
            Console.WriteLine("------------------------");
            Console.ResetColor();

            LogIn(); //Inloggningsmetod.

            Console.ReadKey();
        }
        static void LogIn() //Inloggningsmetod.
        {          
            int maxLogAttempts = 3;
           
            while (maxLogAttempts > 0)
            {
                Console.Write("\nLogga in med din PIN-kod:");
                string userPIN = Console.ReadLine();

                for (int i = 0; i < userPinCodes.Length; i++)
                {
                    if (userPinCodes[i] == userPIN)
                    {
                        Console.Clear();
                        Console.WriteLine($"Hej, {userAccounts[i]}!");                      
                        BankMenu(i);
                        return;                       
                    }
                }
              maxLogAttempts--;

                if (maxLogAttempts > 0) 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nFelaktig PIN-kod! Försök igen, du har {maxLogAttempts} försök kvar");
                    Console.ResetColor();                    
                    
                }
                else
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("\nAjdå! Det verkar som att du har skrivit in fel PIN-kod för många gånger.");
                    Console.WriteLine("Klicka på valfri tangent för att avsluta.");
                    Console.ResetColor();               
                    
                }
               
            }
            
            static void BankMenu(int userRegister)
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
                            AccAndBalance(userRegister);
                            break;
                        case 2:
                            TransferMoney(userRegister);
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

                static void AccAndBalance(int userRegister)
                {
                    Console.Clear();
                    Console.WriteLine($"Konto och saldo för {userAccounts[userRegister]} ");
                    for (int i = 0; i < userSavingsAcc[userRegister].Length; i++)
                    {                                               
                        Console.WriteLine($"{userSavingsAcc[userRegister][i]}: {userBalance[userRegister][i]} kr ");                        
                    }
                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.WriteLine("\nKlicka enter för att komma till huvudmenyn.");
                    Console.ResetColor();
                    Console.ReadKey();                    
                }
                Console.Clear();
                BankMenu(userRegister);

                static void TransferMoney(int userRegister)
                {
                    Console.WriteLine("Välj ett konto att överföra pengar från: ");

                    for (int i = 0; i < ; i++)
                    {

                    }

                }
                static void WithdrawMoney()
                {

                }
                static void LogOut()
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("Loggar ut...");
                    Console.ResetColor();
                    Thread.Sleep(3000);
                    Console.Clear();                    
                    LogIn();
                }
            }
        }
    }
}