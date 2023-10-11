namespace Individuellt_projekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string[] userAccounts = { "Anton", "Adam", "Simon", "Petter", "Linus" };
            
            Console.WriteLine("----------------------");
            Console.WriteLine("Välkommen till banken!");
            Console.WriteLine("----------------------");

            BankMenu();

            Console.ReadKey();
        }
        static void BankMenu()
        {                                  
            Console.WriteLine("1. Se dina konton och saldo ");
            Console.WriteLine("2. Överföring mellan konton");
            Console.WriteLine("3. Ta ut pengar ");
            Console.WriteLine("4. Logga ut ");
            Console.Write("Välj ett alternativ:  ");
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
                    break;

            }
            
        }
        static void AccAndBalance()
        {

        }
        static void TransferMoney()
        {

        }
        static void WithdrawMoney()
        {

        }
        static void LogOut()
        {

        }
    }
}