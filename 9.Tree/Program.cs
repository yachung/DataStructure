public class Program
{
    static void PrintNode<T>(Node<T> node)
    {
        Console.WriteLine($"{node.Data}");
    }

    static void Main(string[] args)
    {
        Tree<string> tree = new Tree<string>("A");
        tree.AddChild("B");
        tree.AddChild("B", "E");
        tree.AddChild("B", "F");
        tree.AddChild("B", "G");
        //tree.Children[0].AddChild("E");
        //tree.Children[0].AddChild("F");
        //tree.Children[0].AddChild("G");

        tree.AddChild("C");
        tree.AddChild("C", "H");
        tree.AddChild("C", "I");
        //tree.Children[1].AddChild("H");
        //tree.Children[1].AddChild("I");

        tree.AddChild("D");
        tree.AddChild("D", "J");
        tree.AddChild("Z", "B");
        //tree.Children[2].AddChild("J");

        // 전위 순회
        tree.PreorderTraverse(node =>
        {
            Console.WriteLine($"{(node.Data)}");
        });

        // 검색.
        if (tree.Find("A", out Node<string> outNode))
        {
            Console.WriteLine($"검색 성공. 부모: {outNode.Parent?.Data}, 값: {outNode.Data}");
        }
        else
        {
            Console.WriteLine("검색 실패");
        }

        if (tree.Delete("B"))
        {
            Console.WriteLine("삭제 성공");
            tree.PreorderTraverse(node =>
            {
                Console.WriteLine($"{(node.Data)}");
            });
        }
        else
        {
            Console.WriteLine("삭제 실패");
        }
    }
}
