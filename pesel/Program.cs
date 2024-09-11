internal class Program
{
    private static void Main(string[] args)
    {

        //zmienne
        int[] pesel = { 5, 5, 0, 3, 0, 1, 0, 1, 1, 9, 3 };
        int[] weights = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3, 0 };
        int S = 0;
        int R = 0;
        int M = 0;
        bool isValid;

        //komunikat do użytkownika
        Console.WriteLine("Witaj w programie do sprawdzania numerów PESEL\nPodaj numer PESEL do sprawdzenia: ");
        string peselTemp = Console.ReadLine();

        //zmiana string na int[]
        pesel = peselTemp.Select(o => Convert.ToInt32(o) - 48).ToArray();

        //sprawdzanie płci
        if (pesel[9] % 2 == 0)
        {
            Console.WriteLine("Płeć: K");
        }
        else
        {
            Console.WriteLine("Płeć: M");
        }

        //mnożenie numeru PESEL przez wagę
        for (int i = 0; i < pesel.Length; i++)
        {
            int tempP = pesel[i];
            int tempW = weights[i];
            int TempR = tempP * tempW;
            S += TempR;
        }

        //modulo z M
        M = S % 10;

        //wykonywanie działań sprawdzających PESEL
        if (M == 0)
        {
            R = 0;
        }
        else
        {
            R = 10 - M;
        }

        //sprawdzenie czy PESEL jest zgodny (suma kontrolna)
        if (R == pesel[10])
        {
            isValid = true;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("PESEL jest prawidłowy.");
            Console.ResetColor();
        }
        else
        {
            isValid = false;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("PESEL nie jest prawidłowy");
            Console.ResetColor();
        }
    }
}