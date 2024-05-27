using Array = Container.Array<int>;

// 진입점(Entry Point)를 갖는 프로그램 클래스
class Program
{
    static void Main(string[] args)
    {
        Container.Array<int> array = new Container.Array<int>(10); 

        for (int ix = 0; ix < array.Length; ++ix)
        {
            array[ix] = ix + 1;
            //array.SetData(ix, ix + 1);
        }

        for (int ix = 0; ix < array.Length; ++ix)
        {
            //Console.WriteLine($"[{ix}] = {array.At(ix)}");
            Console.WriteLine($"[{ix}] = {array[ix]}");
        }

        Console.WriteLine();
    }
}