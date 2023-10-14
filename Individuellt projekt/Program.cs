using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Xml;

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
            Console.BackgroundColor = ConsoleColor.DarkRed; //Kod som välkomnar avändaren till banken.
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("           $            ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("                        ");
            Console.WriteLine(" VÄLKOMMEN TILL BANKEN! ");
            Console.WriteLine("                        ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("           $            ");
            Console.ForegroundColor= ConsoleColor.Black;
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
                Console.Write("\nLogga in med din PIN-kod: ");
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
            
            static void BankMenu(int userRegister) //Metod för menyn som användaren ser efter inloggning.
            {
                Console.WriteLine("\n1. Se dina konton och saldo ");
                Console.WriteLine("2. Överföring mellan konton");
                Console.WriteLine("3. Ta ut pengar ");
                Console.WriteLine("4. Logga ut ");
                Console.Write("\nVälj ett alternativ: ");


                try //Felhantering ifall användaren skriver in något annat än de 4 alternativen som finns i menyn.
                {
                    int userChoice = Convert.ToInt32(Console.ReadLine());

                    switch (userChoice)//Switch som möjliggör menyn.
                    {
                        case 1:
                            AccAndBalance(userRegister);
                            break;
                        case 2:
                            TransferMoney(userRegister);
                            break;
                        case 3:
                            WithdrawMoney(userRegister);
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

                static void AccAndBalance(int userRegister) //Metod som skriver ut användarens konton saldo.
                {
                    Console.Clear();                    
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Konton och saldo för: {userAccounts[userRegister]} ");
                    Console.ResetColor();
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
                BankMenu(userRegister); //Återgår till menyn.

                static void TransferMoney(int userRegister) //Metod för att överföra pengar från ett konto till ett annat.
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Välj den siffra på det konto som du vill överföra pengar ifrån. ");
                    Console.ResetColor();

                    for (int i = 0; i < userSavingsAcc[userRegister].Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {userSavingsAcc[userRegister][i]} - Saldo: {userBalance[userRegister][i]} kr");//+1 för att göra programmet mer användarvänligt.
                    }                                                                                                               //Om jag inte hade haft + 1, så hade användaren behövt skriva 0 om den vill välja det första alternativet.
                                                                                                                                    //Det är för att arrays första element alltid har startvärdet 0.
                    Console.Write("\n: ");
                    int fromAccountRegister = Convert.ToInt32(Console.ReadLine()) - 1; //-1 för att konvertera tillbaka för att programmet ska funka som det ska.

                   
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nVälj den siffra på det konto som du vill överföra pengar till.");
                    Console.ResetColor();

                    for (int i = 0; i < userSavingsAcc[userRegister].Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {userSavingsAcc[userRegister][i]} - Saldo: {userBalance[userRegister][i]} kr");
                    }

                    Console.Write("\n: ");
                    int toAccountRegister = Convert.ToInt32(Console.ReadLine()) - 1;

                    Console.Write("\nAnge hur mycket pengar du vill överföra: ");
                    double transferMoney = Convert.ToDouble(Console.ReadLine()); //double för att avändaren ska kunna skriva in mer än heltal.

                    userBalance[userRegister][fromAccountRegister] -= transferMoney; //Här genomförs överföringen. Jag tar bort pengar från det första kontot.
                    userBalance[userRegister][toAccountRegister] += transferMoney;//Och lägger till pengar i det andra kontot.
                    
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green; //Visar att överföringen har lyckats, visar hur mycket pengar som nu finns på dessa konton. Ändrar till grön färg för att förtydliga.
                    Console.WriteLine($"Överföringen av {transferMoney} kr från {userSavingsAcc[userRegister][fromAccountRegister]} till {userSavingsAcc[userRegister][toAccountRegister]} är fullbordad!");
                    Console.ResetColor(); 
                    
                    Console.WriteLine($"\nNytt saldo för {userSavingsAcc[userRegister][fromAccountRegister]} : {userBalance[userRegister][fromAccountRegister]} kr");
                    Console.WriteLine($"\nNytt saldo för {userSavingsAcc[userRegister][toAccountRegister]} : {userBalance[userRegister][toAccountRegister]} kr");
                    
                    BankMenu(userRegister); //Skickar tillbaka användaren till menyn.
                    
                }
                static void WithdrawMoney(int userRegister) //Metod för att ta ut pengar från ett konto.
                {
                    Console.Clear();          //Koden för att ta ut pengar ser ungefär likadan ut som TrasferMoney koden gör, skillnaden är att här behöver avändaren endast välja ett konto och belopp att ta ut.
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Välj ett konto att ta ut pengar från: ");
                    Console.ResetColor();

                    for (int i = 0; i < userSavingsAcc[userRegister].Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {userSavingsAcc[userRegister][i]} - Saldo: {userBalance[userRegister][i]} kr");
                    }

                    Console.Write("\n: ");
                    int withdrawAccount = Convert.ToInt32(Console.ReadLine()) - 1;

                    Console.Write("\nAnge hur mycket pengar du vill ta ut: ");
                    double withdrawMoney = Convert.ToDouble(Console.ReadLine()); 

                    userBalance[userRegister][withdrawAccount] -= withdrawMoney;


                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green; 
                    Console.WriteLine($"Uttag av {withdrawMoney} kr från {userSavingsAcc[userRegister][withdrawAccount]} är fullbordad!");
                    Console.ResetColor();

                    Console.WriteLine($"\nNytt saldo för {userSavingsAcc[userRegister][withdrawAccount]} : {userBalance[userRegister][withdrawAccount]} kr");

                    BankMenu(userRegister);
                }

                    static void LogOut() //Utloggningsmetod.
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine("\nLoggar ut...");
                    Console.ResetColor();
                    Thread.Sleep(2500);
                    Console.Clear();                    
                    LogIn();
                }
            }
        }
    }
}