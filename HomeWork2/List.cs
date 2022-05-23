using System;
using System.Linq;
using System.Text;
using System.Collections;


class List<T>
{
    T[] array;
    /// <summary>
    /// Контруктор
    /// </summary>
    public List()
    {
        array = new T[0];
    }
    /// <summary>
    /// Контруктор
    /// </summary>
    /// <param name="count">Количество элементов.</param>
    public List(int count)
    {
        array = new T[count];
    }
    /// <summary>
    /// Поместить новый элемент в конец списка.
    /// </summary>
    /// <param name="value">Новый элемент</param>
    public void PushBack(T value)
    {
        Array.Resize(ref array, array.Length + 1);
        array[array.Length - 1] = value;
    }
    /// <summary>
    /// Поменстить новый элемент в начало списка.
    /// </summary>
    /// <param name="value">Новый элемент.</param>
    public void PushFront(T value)
    {
        Array.Resize(ref array, array.Length + 1);
        for (int i = array.Length - 1; i >= 1; i--)
            array[i] = array[i - 1];
        array[0] = value;
    }
    /// <summary>
    /// Получить последний элемент в списке.
    /// </summary>
    /// <returns>Возвращает последний элемент</returns>
    public T PopBack()
    {
        T value = array[array.Length - 1];
        Array.Resize(ref array, array.Length - 1);
        return value;
    }
    /// <summary>
    /// Получить первый элемент списка.
    /// </summary>
    /// <returns>Возвращает первый элемент списка.</returns>
    public T PopFront()
    {
        T value = array[0];
        for (int i = 0; i < array.Length - 1; i++)
            array[i] = array[i + 1];
        Array.Resize(ref array, array.Length - 1);
        return value;
    }
    /// <summary>
    /// Количество элементов в списке.
    /// </summary>
    public int Count
    {
        get
        {
            return array.Length;
        }
    }
    /// <summary>
    /// Очистить списокю
    /// </summary>
    public void Clear()
    {
        array = new T[0];
    }
    /// <summary>
    /// Является ли список пустым.
    /// </summary>
    public bool IsEmpty
    {
        get
        {
            return array.Length == 0;
        }
    }
    /// <summary>
    /// Отсортировать список.
    /// </summary>
    public void Sort()
    {
        Array.Sort(array);
    }
    /// <summary>
    /// Удалить элемент из списка.
    /// </summary>
    /// <param name="index">Номер элемента.</param>
    public void Erase(uint index)
    {
        if (index >= array.Length)
            throw new Exception("Индекс вне границ массива");
        for (uint i = index; i < array.Length - 1; i++)
            array[i] = array[i + 1];
        Array.Resize(ref array, array.Length - 1);
    }
    /// <summary>
    /// Элемент списка.
    /// </summary>
    /// <param name="index">Индекс элемента</param>
    /// <returns>Возвращает элемент списка</returns>
    public T this[int index]
    {
        get
        {
            return array[index];
        }
        set
        {
            array[index] = value;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<int> list = new List<int>();
        Random random = new Random();
        for (int i = 0; i < 10; i++)
        {
            int v = random.Next() % 100;
            Console.Write(v + " ");
            list.PushBack(v);
        }
        Console.WriteLine();
        list.PushFront(1);
        list.PushFront(2);
        for (int i = 0; i < list.Count; i++)
            Console.Write(list[i] + " ");
        Console.WriteLine();
        list.Erase(3);
        for (int i = 0; i < list.Count; i++)
            Console.Write(list[i] + " ");
        Console.WriteLine();
        list.Sort();
        for (int i = 0; i < list.Count; i++)
            Console.Write(list[i] + " ");
        Console.WriteLine();
        while (!list.IsEmpty)
        {
            int v = list.PopBack();
            Console.Write(v + " ");
        }
        Console.ReadKey(true);
    }
}
