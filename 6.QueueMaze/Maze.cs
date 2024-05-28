using System;

public class Maze
{
    // 필드
    private char[,] maze;

    // 인덱서
    public char this[int row, int column]
    {
        get
        {
            return maze[row, column];
        }
        set
        {
            maze[row, column] = value;
        }
    }

    public Maze()
    {
        LoadMap("Map.txt");
    }

    // 메시지
    // 이동하려는 위치가 이동 가능한지 판단
    public bool IsValidLocation(int row, int column)
    {
        if (row < 0 || column < 0 || row >= maze.GetLength(0) || column >= maze.GetLength(1))
        {
            return false;
        }

        return maze[row, column] == '0' || maze[row, column] == 'x';
    }

    // 미로의 크기를 반환해주는 기능.
    public int GetSize()
    {
        return maze.GetLength(0);
    }

    // 맵정보 출력
    public void Print()
    {
        // 미로 출력.
        for (int y = 0; y < maze.GetLength(0); ++y)
        {
            for (int x = 0; x < maze.GetLength(1); ++x)
            {
                Console.Write($"{maze[x, y]} ");
            }

            Console.WriteLine();
        }
    }

    // 맵파일 읽어서 미로 정보로 변환해 저장하는 기능
    private void LoadMap(string fileName)
    {
        // 파일 읽어오기
        string[] lines = File.ReadAllLines(fileName);

        // 미로 배열 객체 초기화
        maze = new char[lines.Length, lines.Length];

        // 라인별로 루프를 순회하면서 맵 데이터 파싱
        for (int y = 0; y < lines.Length; ++y)
        {
            string[] row = lines[y].Split(',');
            for (int x = 0; x < row.Length; ++x)
            {
                maze[x, y] = row[x][0];
            }
        }
    }
}
