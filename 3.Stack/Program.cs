// 진입점을 제공하는 프로그램 클래스.
// Entry Point.
using System;
using System.Security.Cryptography;

class Program
{
    // 랜덤 발생기 변수.
    static Random random;

    // 범위를 지정해 난수를 발생시키는 함수.
    static float GetRandomInRange(float min, float max)
    {
        // 난수 생성을 위한 Random 객체 생성.
        if (random == null)
        {
            random = new Random();
        }

        // 0.0 - 1.0 사이의 난수를 생성한 뒤, 전달 받은 min ~ max 범위로 난수 범위를 조정.
        float randomNumber = (float)random.NextDouble();
        randomNumber *= (max - min);
        randomNumber += min;

        // 난수 반환.
        return randomNumber;
    }

    static void Main(string[] args)
    {
        // 경험치 삽입.
        ExpStack<float> stack = new ExpStack<float>();

        //Console.WriteLine("첫번째 게임 종료 - 현재 경험치 145.5f");
        //stack.Push(145.5f);

        //Console.WriteLine("두번째 게임 종료 - 현재 경험치 183.25f");
        //stack.Push(183.25f);

        //Console.WriteLine("세번째 게임 종료 - 현재 경험치 162.3f");
        //stack.Push(162.3f);

        for (int ix = 0; ix < 10; ++ix)
        {
            // 범위를 지정해 난수 생성.
            float exp = GetRandomInRange(100.0f, 150.0f);

            Console.WriteLine($"{ix + 1}번째 게임 종료 - 현재 경험치 {exp}");
            stack.Push(exp);
        }

        // 값 추출 및 출력.
        int count = stack.Count;
        for (int ix = 0; ix < count; ++ix)
        {
            // 값 추출.
            if (stack.Pop(out float value))
            {
                Console.WriteLine($"현재 경험치: {value}");
            }
        }

        Console.ReadKey();
    }
}