using System;

// 트리 클래스.
public class Tree<T>
{
    // 필드(상태/스테이트).
    // 루트(Root).
    private Node<T> root;

    // 자손(Children).
    public List<Node<T>> Children
    {
        get
        {
            return root.Children;
        }
    }

    // 메시지.
    // 생성.
    public Tree(T data)
    {
        root = new Node<T>(data);
    }

    // 자손 추가 - 부모를 지정할 때 부모의 값으로 지정하는 함수
    public void AddChild(T parentData, T childData)
    {
        // 부모를 검색
        bool result = FindRecursive(parentData, root, out Node<T> outParent);

        // 검색 성공 시, 찾은 노드를 부모로 지정해서 새로운 자손 추가
        if (result)
            outParent.AddChild(childData);
        else
            // 검색 실패시 자손 추가 실패
            Console.WriteLine("부모가 없어서 자손 추가에 실패");
    }

    // 자손 추가 (부모 지정-옵션).
    public void AddChild(T data, Node<T> parent = null)
    {
        // 아래 함수를 호출.
        AddChild(new Node<T>(data), parent);
    }

    public void AddChild(Node<T> child, Node<T> parent = null)
    {
        // 자손으로 추가할 노드의 부모 지정.
        // 전달 받은 parent 정보가 null이면 루트 노드의 자손으로 추가.
        child.Parent = parent == null ? root : parent;

        // 자손 추가.
        child.Parent.AddChild(child);
    }

    public bool Find(T data, out Node<T> outNode)
    {
        return FindRecursive(data, root, out outNode);
    }

    private bool FindRecursive(T data, Node<T> node, out Node<T> outNode)
    {
        // 종료 조건
        if (node == null)
        {
            outNode = null;
            return false;
        }

        // 값을 찾았는지 확인 -> 찾았으면 노드 출력 후 true 반환
        if (node.Data.Equals(data))
        {
            outNode = node;
            return true;
        }

        // 값을 못찾았다면, 자손 노드를 루프로 재귀 호출 진행
        foreach (Node<T> child in node.Children)
        {
            // 자손 노드에서 검색을 성공 했으면, outNode 반환 및 검색 성공 반환
            bool result = FindRecursive(data, child, out outNode);
            if (result == true)
                return true;
        }

        outNode = null;
        return false;
    }

    // 노드 삭제 - 인터페이스.
    public bool Delete(T data)
    {
        // 값을 검색해서 삭제해달라는 요청이 오면,
        // 트리를 순회하면서 노드를 재귀적으로 찾고 삭제 시도.
        return DeleteRecursive(data, root, out Node<T> outNode);
    }

    // 노드 삭제 재귀 함수.
    private bool DeleteRecursive(T data, Node<T> node, out Node<T> outNode)
    {
        // 검색 - 삭제할 노드 검색.
        bool result = FindRecursive(data, node, out outNode);

        // 검색 성공하면, 해당 노드 삭제.
        if (result == true)
        {
            outNode.Destroy();
            return true;
        }

        // 검색 실패했으면 실패 반환.
        return false;
    }

    // 전위 순회 (재귀).
    // 부모 -> 자손.
    // 메시지 - 인터페이스.
    public void PreorderTraverse(Action<Node<T>> action, int depth = 0)
    {
        // 트리에 전위 순회하도록 호출하면, 내부적으로는 재귀 함수를 호출.
        PreorderTraverseRecursive(root, action, depth);
    }

    // 전위 순회 재귀함수.
    private void PreorderTraverseRecursive(Node<T> node, Action<Node<T>> action, int depth = 0)
    {
        // 종료(탈출) 조건.
        if (node == null)
        {
            return;
        }

        // 계층을 보여주기 위한 깊이 출력.
        for (int ix = 0; ix < depth; ++ix)
        {
            Console.Write("  ");
        }

        // 부모 함수 처리 - 전달 받은 딜리게이트(Action) 호출.
        action(node);

        // 자손 처리.
        foreach (Node<T> child in node.Children)
        {
            PreorderTraverseRecursive(child, action, depth + 1);
        }
    }

    // 후위 순회.
    public void PostorderTraverse(Action<Node<T>> action, int depth = 0)
    {
        // 트리에 전위 순회하도록 호출하면, 내부적으로는 재귀 함수를 호출.
        PostorderTraverseRecursive(root, action, depth);
    }

    // 전위 순회 재귀함수.
    private void PostorderTraverseRecursive(Node<T> node, Action<Node<T>> action, int depth = 0)
    {
        // 종료(탈출) 조건.
        if (node == null)
        {
            return;
        }

        // 자손 처리.
        foreach (Node<T> child in node.Children)
        {
            PostorderTraverseRecursive(child, action, depth + 1);
        }

        // 계층을 보여주기 위한 깊이 출력.
        for (int ix = 0; ix < depth; ++ix)
        {
            Console.Write("  ");
        }

        // 부모 함수 처리 - 전달 받은 딜리게이트(Action) 호출.
        action(node);
    }
}