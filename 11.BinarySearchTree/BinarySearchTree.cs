
// 이진 탐색 트리.

public class BinarySearchTree
{
    // 루트 노트.
    private Node root;

    // 메시지 (공개 메소드) - 인터페이스(명세-약속).
    // 생성.
    public BinarySearchTree()
    {
        // 루트 노드 생성.
        root = null;
    }

    // 삽입.
    // 규칙 - 중복된 값은 허용하지 않는다.
    // 삽입을 하기 위해서는 어느 자리에 추가해야하는지를 찾아야 함.
    // 1. 루트에서부터 검색 시작 - 루트가 null이면 루트에 지정.
    // 2. 비교하는 노드보다 추가하려는 값이 작으면 왼쪽 하위트리로 비교를 진행.
    // 3. 비교하는 노드보다 추가하려는 값이 크면 오른쪽 하위트리로 비교를 진행.
    public bool Insert(int data)
    {
        // 중복된 값이 있는지 확인.
        if (Find(data))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("오류: 이미 중복된 값이 있어 데이터를 추가하지 못했습니다.");
            Console.ForegroundColor = ConsoleColor.White;
            return false;
        }

        // 루트가 null이면 루트로 지정.
        if (root == null)
        {
            root = new Node(data);
            return true;
        }

        // 2와 3의 경우를 위해 재귀적으로 확인하면서 노드 추가.
        root = InsertRecursive(root, null, data);
        return true;
    }

    // 재귀적으로 삽입을 처리하는 함수.
    // node: 현재 비교를 진행할 노드.
    // parent: node의 부모 노드.
    // data: 삽입하려는 데이터.
    private Node InsertRecursive(Node node, Node parent, int data)
    {
        // 종료(탈출) 조건 확인.
        if (node == null)
        {
            // 새 노드 생성.
            Node newNode = new Node(data);

            // 새 노드의 부모 노드 지정.
            newNode.Parent = parent;

            // 생성한 노드 반환.
            return newNode;
        }

        // 추가하려는 값이 작으면 왼쪽 서브 트리로 탐색.
        if (node.Data > data)
        {
            node.Left = InsertRecursive(node.Left, node, data);
        }

        // 추가하려는 값이 크면 오른쪽 서브 트리로 탐색.
        else
        {
            node.Right = InsertRecursive(node.Right, node, data);
        }

        return node;
    }

    // 삭제.

    // 탐색(검색).
    public bool Find(int data)
    {
        // 재귀적으로 탐색 후 결과 반환.
        return FindRecursive(root, data);
    }

    // 검색 재귀 함수.
    // node: 현재 값을 비교할 노드.
    // data: 검색하는 값.
    private bool FindRecursive(Node node, int data)
    {
        // 종료(탈출) 조건.
        if (node == null)
        {
            // 비교할 노드가 null인 경우는 검색에 실패함.
            return false;
        }

        // 찾은 경우.
        if (node.Data.Equals(data))
        {
            return true;
        }
        
        // 작은 경우 - 왼쪽 하위 트리에서 검색을 더 진행.
        if (node.Data > data)
        {
            return FindRecursive(node.Left, data);
        }

        // 큰 경우 - 오른쪽 하위 트리에서 검색을 더 진행.
        else
        {
            return FindRecursive(node.Right, data);
        }
    }

    // 중위 순회.
    // 왼쪽 하위 트리 -> 루트 -> 오른쪽 하위 트리.
    public void InorderTraverse()
    {
        // 재귀 함수 호출.
        InorderTraverseRecursive(root);
    }

    // 중위 순회 재귀 함수.
    private void InorderTraverseRecursive(Node node)
    {
        // 탈출 조건 확인.
        if (node == null)
        {
            return;
        }

        // 방문 진행.
        // 왼쪽 서브 트리.
        InorderTraverseRecursive(node.Left);

        // 루트(부모).
        Console.Write($"{node.Data} ");

        // 오른쪽 서브 트리.
        InorderTraverseRecursive(node.Right);
    }
}