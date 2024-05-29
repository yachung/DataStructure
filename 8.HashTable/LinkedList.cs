using System;
using System.Collections;

public class LinkedList<T> : IEnumerator, IEnumerable
{
    // 연결 리스트의 첫 부분을 나타내는 head 변수.
    private Node? head = null;

    // 연결 리스트에 저장된 요소의 개수를 추적하는 변수.
    private int count = 0;

    // GetEnumerator 구현에 필요한 변수 추가
    private Node current = null;
    private Node next = null;

    public int Count {  get { return count; } }

    public object Current { get { return current; } }

    public LinkedList()
    {
        head = null;
        count = 0;
    }


    public class Node
    {
        private int count;

        public T Data { get; set; }

        public Node Next { get; set; }

        public Node()
        {
            Data = default(T);
            Next = null;
        }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    // 연결 리스트 첫 부분에 데이터를 삽입하는 함수.
    public void AddToHead(T data)
    {
        // 새 노드 생성.
        Node newNode = new Node(data);

        // 생성한 노드 삽입.
        // 경우의 수1 - head가 없는 경우(null인 경우).
        if (head == null)
        {
            head = newNode;
        }

        // 경우의 수2 - head가 있는 경우(null이 아닌 경우).
        else
        {
            // 새 노드의 다음 노드를 기존의 head로 지정.
            newNode.Next = head;

            // head를 새로운 노드로 업데이트.
            head = newNode;
        }

        count++;
    }

    public void AddToLast(T data)
    {
        Node newNode = new Node(data);

        if (head == null)
        {
            head = newNode;
        }
        // 경우의 수2- head가 있는 경우(null이 아닌경우)
        else
        {
            // 삽입할 위치 검색
            Node current = head;

            while (current.Next != null)
            {
                current = current.Next;
            }

            // 데이터 삽입
            current.Next = newNode;
        }

        count++;
    }

    // 값을 검색해서 노드를 삭제하는 함수.
    public bool DeleteNode(T data)
    {
        // 경우의 수1 - 리스트가 빈 경우.
        if (head == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("오류: 리스트가 비어있어 삭제가 불가능합니다.");
            Console.ForegroundColor = ConsoleColor.White;
            return false;
        }

        // 검색.
        Node current = head;
        Node trail = null;

        while (current != null)
        {
            // 삭제할 데이터와 노드의 데이터를 비교.
            if (current.Data.Equals(data))
            {
                break;
            }

            // 삭제할 데이터를 가진 노드를 검색 못했으면 그 다음 위치의 노드로 이동.
            trail = current;
            current = current.Next;
        }

        // 경우의 수2 - 리스트가 비어있지 않은데, 값을 찾은 경우.
        // 경우의 수2-1 - 리스트가 비어있고, 값을 찾았는 데 찾은 노드가 head인 경우.
        if (current != null && current == head)
        {
            head = head.Next;
        }
        // 경우의 수2-2 - 리스트가 비어있고, 값을 찾았는 데 찾은 노드가 head가 아닌 경우.
        else if (current != null && current != head)
        {
            trail.Next = current.Next;
            current.Next = null;
        }

        // 경우의 수3 - 리스트가 비어있지 않은데, 값을 못찾은 경우.
        else if (current == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"오류: 값 {data}를 찾지 못했습니다.");
            Console.ForegroundColor = ConsoleColor.White;
            return false;
        }

        count--;
        return true;
    }

    // 데이터 출력 함수.
    public void Print()
    {
        // 예외 처리.
        if (head == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("오류: 리스트가 비어 있어 출력할 데이터가 없습니다.");
            Console.ForegroundColor = ConsoleColor.White;
            return;
        }

        // 그 다음 노드로 한칸씩 이동하면서 노드의 값 출력.
        Node current = head;
        while (current != null)
        {
            Console.Write($"{current.Data} ");
            current = current.Next;
        }

        Console.WriteLine();
    }

    // 특정 값이 존재하는지 검색을 하는 함수.
    public bool Find(T data)
    {
        // 리스트가 빈 경우에는 검색할 필요가 없음.
        if (head == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("오류: 리스트가 비어 있어 검색에 실패했습니다.");
            Console.ForegroundColor = ConsoleColor.White;
            return false;
        }

        // 검색 - 순차검색.
        Node current = head;
        Node trail = null;

        while (current != null)
        {
            // 데이터를 확인.
            if (current.Data.Equals(data))
            {
                return true;
            }

            // 다음 위치로 이동하면서 검색을 반복.
            trail = current;
            current = current.Next;
        }

        return false;
    }

    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }

    // current 변수가 null이 아니면, 그 다음 값으로 이동
    public bool MoveNext()
    {
        if (current != null)
        {
            current = next;
            if (current != null)
            {
                next = current.Next;
                return true;
            }

            return false;
        }

        return true;
    }

    public void Reset()
    {
        current = head;
        next = current;
    }
}
