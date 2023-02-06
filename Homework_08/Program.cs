using System.Collections;

myArrayBackward array_0 = new myArrayBackward();
foreach (var item in array_0)
{
    Console.WriteLine(item);
}
Console.WriteLine();

myArrayOddOrEven array_1 = new myArrayOddOrEven();
foreach (var item in array_1)
{
    Console.WriteLine(item);
}
Console.WriteLine();

MyEnumeratorOddOrEven.MoveWithEven = true;
foreach (var item in array_1)
{
    Console.WriteLine(item);
}
Console.WriteLine();

class myArrayBackward : IEnumerable
{
    private int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };


    public IEnumerator GetEnumerator()
    {
        return new MyEnumeratorBackward(array);
    }
}

class myArrayOddOrEven : IEnumerable
{
    private int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };


    public IEnumerator GetEnumerator()
    {
        return new MyEnumeratorOddOrEven(array);
    }
}
class MyEnumeratorBackward : IEnumerator
{
    private int[] array;
    private int position;


    public MyEnumeratorBackward(int[] array)
    {
        this.array = array;
        position = array.Length;
    }
    public object Current
    {
        get 
        {
            return array[position];
        }
    }
    public bool MoveNext()
    {
        position--;
        return (position >= 0);
    }
    public void Reset()
    {
        position = array.Length;
    }

}

class MyEnumeratorOddOrEven : IEnumerator
{
    private int[] array;
    private int position = -1;
    public static bool MoveWithEven;


    public MyEnumeratorOddOrEven(int[] array)
    {
        this.array = array;
    }
    public object Current
    {
        get
        {
            while (true)
            {
                if (MoveWithEven && array[position] % 2 == 0)
                {
                    return array[position];
                }
                else if (!MoveWithEven && array[position] % 2 != 0)
                    return array[position];
                else
                MoveNext();
            }
        }
    }
    public bool MoveNext()
    {
        position++;
        return (position < array.Length-1);
    }
    public void Reset()
    {
        position = -1;
    }

}

