public delegate bool Filter(int number);
public class LambdaPractice
{
    public static void Main()
    {
        int[] array = new int[] { 1, 2, 3, 5, 6, 11, 12, 13, 14, 22, 23, 33, 44, 55 };
        int[] evenArray = GetFiltered(array, (number) => (number % 2 == 0));
        int[] notEvenArray = GetFiltered(array, (number) => !(number % 2 == 0));
        int[] has3Array = GetFiltered(array, (number) => number.ToString().Contains("3"));
        int[] hasSameNumberArray = GetFiltered(array, (number) =>
        {
            //string str = number.ToString();
            if (number.ToString().Length == 1)
                return true;
            else
                for (int i = 0; i < number.ToString().Length - 1; i++)
                {
                    if (!(number.ToString()[i] == number.ToString()[i + 1]))
                        return false;
                }
            return true;
        });
        //
        System.Console.WriteLine("Original array items:");
        Print(array);
        System.Console.WriteLine("\n********************");
        System.Console.WriteLine("Even array items:");
        Print(evenArray);
        System.Console.WriteLine("\n********************");
        System.Console.WriteLine("Not even array items:");
        Print(notEvenArray);
        System.Console.WriteLine("\n********************");
        System.Console.WriteLine("Has 3 array items:");
        Print(has3Array);
        System.Console.WriteLine("\n********************");
        System.Console.WriteLine("Has same number array items:");
        Print(hasSameNumberArray);
        System.Console.WriteLine("\n********************");

    }
    public static void Print(int[] arr)
    {
        foreach (int item in arr)
        {
            Console.Write(item + ", ");
        }
    }
    public static int[] GetFiltered(int[] arr, Filter filtFunc)
    {
        int[] newArr = new int[0];
        foreach (int number in arr)
        {
            if (filtFunc(number))
            {
                Array.Resize(ref newArr, newArr.Length + 1);
                newArr[(newArr.Length) - 1] = number;
            }
        }
        return newArr;
    }
}