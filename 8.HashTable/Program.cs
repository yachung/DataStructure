public class Program
{
    // 간단한 해시 함수 예시
    // 문자열을 입력 받아서 int키를 생성하는 함수
    static int GetSimpleStringHash(string keyInput)
    {
        int hash = 0;
        foreach (char c in keyInput)
        {
            // 문자열 내부 각 문자의 ASCII 값을 더하기
            hash += c;
        }

        return hash;
    }

    static void Main(string[] args)
    {
        // 해시함수 테스트.
        //string input = "Hello, World!~";
        //int hash = GetSimpleStringHash(input);

        //Console.WriteLine($"{input}에 대한 해시: {hash}");

        // 해시테이블 객체 생성.
        HashTable<string, string> table = new HashTable<string, string>();

        // 데이터 추가.
        table.Add("Ronnie", "010-12345678");
        table.Add("Ronnie", "010-37610942");
        table.Add("Kevin", "010-32979287");
        table.Add("Baker", "010-29871982");
        table.Add("Taejun", "010-39487298");

        // 출력.
        table.Print();

        // 검색.
        if (table.Find("Ronnie", out Pair<string, string> pair))
        {
            Console.WriteLine($"검색결과: {pair.Key}, {pair.Value}");
        }

        // 삭제.
        table.Delete("Ronnie");
        table.Delete("Kevin");

        // 출력.
        table.Print();

        Console.ReadKey();
    }
}
