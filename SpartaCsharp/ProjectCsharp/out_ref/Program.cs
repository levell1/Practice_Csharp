using System;

namespace out_ref
{
    internal class Program
    {
        class Stack<T>
        {
            private T[] elements;
            private int top;

            public Stack() {
                elements = new T[100];
                top = 0;
            }
            public void Push(T item)
            {
                elements[top++] = item; //top 0 에 item 추가 후 ++
            }
            public T Pop()
            {
                return elements[--top];
            }

            public T[] Elements
            {
                get{
                    Console.WriteLine("get");
                    return elements; }
                set
                {
                    Console.WriteLine("Set");
                    elements = value; 
                }
            }

        }
        static void Main(string[] args)
        {
            /*Stack<int> intStack = new Stack<int>();
            Stack<string> stringStack = new Stack<string>();
            intStack.Push(1);
            intStack.Push(2);
            intStack.Push(3);
            stringStack.Push("1");
            stringStack.Elements[1] = "2";
            Console.WriteLine(stringStack.Elements[1]);
            Console.WriteLine(intStack);*/

            // out 키워드 사용 예시
            static void Divide(int a, int b, out int quotient, out int remainder)
            {
                quotient = a / b;
                remainder = a % b;
            }

            // ref 키워드 사용 예시
            static void Swap(ref int a, ref int b)
            {
                int temp = 0;
                temp = a;
                a = b;
                b = temp;
            }

            int quotient, remainder;
            Divide(7,3,out quotient,out remainder);

            int x = 1;
            int y = 2;
            Swap(ref x, ref y);
            Console.WriteLine($"{x},{y}");
        }
    }
}