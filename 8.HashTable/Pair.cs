using System;

// 키 값을 쌍으로 데이터를 저장할 때 사용할 Pair 클래스
public class Pair<TKey, TValue>
{
    private TKey key;
    private TValue value;

    public TKey Key { get { return key; } }
    public TValue Value { get { return value; } }

    public Pair()
    {
        key = default(TKey);
        value = default(TValue);
    }

    public Pair(TKey key, TValue value)
    {
        this.key = key;
        this.value = value;
    }
}
