
// 이진 트리(BinaryTree) 예제 클래스.
public class Program
{
    static void Main(string[] args)
    {
        // 트리 생성.
        BinaryTree<string> tree = new BinaryTree<string>("1");

        // 1의 왼쪽 자손으로 2추가.
        tree.AddLeftChild("2");

        // 2의 왼쪽 자손으로 4추가.
        tree.Left.AddLeftChild("4");
        
        // 2의 오른쪽 자손으로 5추가.
        tree.Left.AddRightChild("5"); 

        // 1의 오른쪽 자손으로 3추가.
        tree.AddRightChild("3");

        // 3의 왼쪽 자손으로 6추가.
        tree.Right.AddLeftChild("6");
        
        // 3의 오른쪽 자손으로 7추가.
        tree.Right.AddRightChild("7");

        // 순회.
        tree.PreorderTraverse();

        Console.WriteLine();
        tree.InorderTraverse();

        Console.WriteLine();
        tree.PostorderTraverse();

        // 검색.
        if (tree.Find("0", out Node<string> node))
        {
            Console.WriteLine($"검색 성공. ParentData: {node.Parent?.Data}, Data: {node.Data}");
        }
        else
        {
            Console.WriteLine("검색에 실패했습니다.");
        }

        // 삭제.
        tree.DeleteNode("1");

        // 순회.
        tree.PreorderTraverse();


        Console.ReadKey();
    }
}