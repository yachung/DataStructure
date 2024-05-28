using System;

public class Program
{
    static void Main(string[] args)
    {
        LinkedList<int> list = new LinkedList<int>();

        string? data;

        while (true)
        {
            Console.WriteLine("추가할 데이터를 입력해주세요(종료는 q)");

            data = Console.ReadLine();

            if (data == "q" || data == "Q")
            {
                break;
            }

            if (int.TryParse(data, out int outValue))
            {
                list.AddToLast(outValue);
                list.Print();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("데이터 입력을 잘못하셨습니다. 숫자만 입력이 가능합니다.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        while (true)
        {
            Console.WriteLine("삭제할 데이터를 입력해주세요(종료는 q)");

            data = Console.ReadLine();

            if (data == "q" || data == "Q")
            {
                break;
            }

            if (int.TryParse(data, out int outValue))
            {
                list.DeleteNode(int.Parse(data));
                list.Print();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("데이터 입력을 잘못하셨습니다. 숫자만 입력이 가능합니다.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        list.Print();

        Console.ReadKey();
    }
}