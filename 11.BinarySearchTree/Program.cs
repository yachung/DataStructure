﻿public class Program
{
    static void Main(string[] args)
    {
        // 트리 생성.
        BinarySearchTree tree = new BinarySearchTree();

        tree.Insert(10);
        tree.Insert(7);
        tree.Insert(11);
        tree.Insert(13);
        tree.Insert(15);
        tree.Insert(20);
        tree.Insert(5);
        tree.Insert(5);
        tree.Insert(7);
        tree.Insert(3);
        tree.Insert(6);
        tree.Insert(1);

        int searchValue = 15;
        if (tree.Find(searchValue))
        {
            Console.WriteLine($"값 {searchValue} 검색에 성공했습니다.");
        }
        else
        {
            Console.WriteLine($"값 {searchValue} 검색에 실패했습니다.");
        }

        // 순회.
        tree.InorderTraverse();

        Console.ReadKey();
    }
}