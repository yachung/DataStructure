public class Program
{
    static void Main(string[] args)
    {
        CustomList<int> list = new CustomList<int>();
        for (int ix = 0; ix < 10; ++ix)
        {
            list.Add(ix + 1);
        }

        // 삭제
        list.Remove(4);
        list.Remove(8);
        list.RemoveAt(1);

        // 출력
        for (int ix = 0; ix < list.Count; ++ix)
        {
            Console.WriteLine($"[{ix}]={list[ix]}");
        }

        foreach (var item in list)
        {
            Console.WriteLine($"{item}");
        }

        foreach (var item in list)
        {
            Console.WriteLine($"{item}");
        }

        Console.WriteLine($"Size: {list.Count}");
        Console.WriteLine();
    }

}