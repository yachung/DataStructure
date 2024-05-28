public class Program
{
    static void Main(string[] args)
    {
        // 큐 생성.
        Queue<float> queue = new Queue<float>();

        // 큐에 데이터 삽입.
        for (int ix = 0; ix < 10; ++ix)
        {
            queue.Enqueue(ix + 1);
        }

        // 큐 데이터 출력.
        queue.Print();

        // 큐 데이터 추출 및 출력.
        Console.Write("Dequeue: ");
        for (int ix = 0; ix < 3; ++ix)
        {
            if (queue.Dequeue(out float value))
            {
                Console.Write($"{value} ");
            }
        }

        Console.WriteLine();

        queue.Print();

        Console.ReadKey();
    }
}