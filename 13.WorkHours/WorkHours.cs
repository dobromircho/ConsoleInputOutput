using System;

class WorkHours
{
    static void Main()
    {
        long hours = long.Parse(Console.ReadLine());
        int days = int.Parse(Console.ReadLine());
        byte percent = byte.Parse(Console.ReadLine());
        decimal workingHours = days * 0.9m * 12 * percent / 100;
        decimal result = (int)workingHours - hours;

        if (result >= 0 )
        {
            Console.WriteLine("Yes");
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("No");
            Console.WriteLine(result);
        }

    }
}

