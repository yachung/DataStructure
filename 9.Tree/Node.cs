using System;
public class Node<T>
{
    // 필드
    public T Data { get; set; }
    public Node<T> Parent { get; set; }
    public List<Node<T>> Children { get; set; }

    public int Count
    {
        get
        {
            int count = 1;
            foreach (Node<T> child in Children)
            {
                count += child.Count;
            }

            return count;
        }
    }

    public Node()
    {
        Data = default(T);
        Parent = null;
        Children = new List<Node<T>>();
    }

    public Node(T data)
    {
        Data = data;
        Parent = null;
        Children = new List<Node<T>>();
    }

    public void AddChild(T data)
    {
        AddChild(new Node<T>(data));
    }

    public void AddChild(Node<T> child)
    {
        child.Parent = this;
        Children.Add(child);
    }

    public void Destroy()
    {
        if (Parent != null)
        {
            Parent.Children.Remove(this);
        }
    }
    // 메세지
    // 생성
    // 자손 노드 추가
    // 트리에서 노드 제거
}