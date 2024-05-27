using System;

namespace Container
{
    // 직접 구현해보는 배열 클래스
    public class Array<T>
    {
        // 필드
        // 자료 저장 공간(Space, Container, Collection)
        private T[] data;

        // 기본 배열의 크기 값.
        private const int defaultLength = 5;

        // 인덱서 (Indexer) - 프로퍼티
        public T this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }

        // 생성자
        public Array(int size) 
        {
            // 전달 받은 size값을 기준으로 내부 저장소를 생성
            data = size == 0 ? new T [defaultLength] : new T[size];
        }

        // 접근 메소드
        public T At(int index)
        {
            return data[index];
        }

        // 데이터 설정 메소드
        public void SetData(int index, T value)
        {
            // 내부 저장소에서 index 위치에 value 값을 설정
            data[index] = value;
        }

        public int Length
        {
            get { return data.Length; }
        }

        // 배열의 크기 반환 메소드
        public int GetSize()
        {
            return data.Length;
        }
    }
}
