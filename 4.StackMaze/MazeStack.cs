using System;

public class MazeStack<T>
{
    private int count = 0;
    private const int maxCapacity = 100;
    private T[] data = new T[maxCapacity];

    public MazeStack()
    {
        // initialize
        count = 0;
        data = new T[maxCapacity];
    }

    public int Count { get; }

    // IsFull
    public bool IsFull
    {
        get
        {
            return count == maxCapacity;
        }
    }
    // IsEmpty
    public bool IsEmpty
    {
        get
        {
            return count == 0;
        }
    }

    // Push
    public bool Push(T item)
    {
        if (IsFull)
        {
            Console.WriteLine("Error : Stack Is Full");
            return false;
        }

        data[count] = item;
        count++;

        return true;
    }

    // Pop
    public bool Pop(out T? outValue)
    {
        if (IsEmpty)
        {
            Console.WriteLine("Error : Stack Is Full");

            // C#의 out 키워드로 전달된 변수는 함수에서 꼭 값을 할당 해야함.
            outValue = default(T);

            return false;
        }

        // 반환할 데이터를 설정 후 count 감소 처리
        outValue = data[--count];

        return true;
    }
}
