public class Program
{
    static void Main(string[] args)
    {
        RecursiveFunction(0);
    }
    static void RecursiveFunction(int count)
    {
        if (count == 10)
            return;

        Console.WriteLine($"{count}");
        RecursiveFunction(++count);
    }

}
