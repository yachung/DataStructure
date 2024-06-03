
// 이진 트리의 기본 요소가 될 노드 클래스.
public class Node
{
    // 필드.
    // 데이터 필드.
    public int Data { get; set; }

    // 부모 노드.
    public Node Parent { get; set; }

    // 왼쪽 자손.
    public Node Left { get; set; }

    // 오른쪽 자손.
    public Node Right { get; set; }

    // 메시지 (공개 메소드) - 인터페이스(명세-약속).
    // 생성 - 생성자.
    public Node(int data = 0)
    {
        // 데이터 초기화.
        this.Data = data;
        Parent = null;
        Left = null;
        Right = null;
    }

    // 왼쪽 자손 추가.
    public void AddLeftChild(int data)
    {
        AddLeftChild(new Node(data));
    }

    public void AddLeftChild(Node child)
    {
        // 새로 추가할 노드의 부모를 이 노드로 지정.
        child.Parent = this;

        // 나의 왼쪽 자손으로 새 노드를 등록.
        Left = child;
    }

    // 오른쪽 자손 추가.
    public void AddRightChild(int data)
    {
        AddRightChild(new Node(data));
    }

    public void AddRightChild(Node child)
    {
        // 새로 추가할 노드의 부모를 이 노드로 지정.
        child.Parent = this;

        // 나의 오른쪽 자손으로 새 노드를 등록.
        Right = child;
    }

    // 삭제.
    public void Destroy()
    {
        // 노드의 부모가 있는 경우 삭제를 진행.
        if (Parent != null)
        {
            // 내가 부모의 왼쪽 자손인 경우.
            if (Parent.Left == this)
            {
                Parent.Left = null;
            }

            // 내가 부모의 오른쪽 자손인 경우.
            if (Parent.Right == this)
            {
                Parent.Right = null;
            }
        }

        // 루트 노드 -> 부모 노드가 null.
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("루트 노드는 삭제가 불가능합니다.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}