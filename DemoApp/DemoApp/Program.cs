// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

var fibonacciNumbers = new List<int> { 1, 1,2 };

while (fibonacciNumbers.Count < 20)
{
    var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
    var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];
    var previous3 = fibonacciNumbers[fibonacciNumbers.Count - 3];

    fibonacciNumbers.Add(previous + previous2 + previous3);
    Console.WriteLine($"fibonacciNumbers的长度为：{fibonacciNumbers.Count}");
}
foreach (var item in fibonacciNumbers)
{
    Console.WriteLine(item);
}






//using System.Runtime.CompilerServices;

//public class Program {
//    public static void Main(string[] args) {

//        int len = sizeof(int);
//        Console.WriteLine($"int类型的长度：{len}");
//        len = sizeof(double);
//        Console.WriteLine($"double类型的长度：{len}");
//        len = sizeof(decimal);
//        Console.WriteLine($"decimal类型的长度：{len}");
//        len = Unsafe.SizeOf<DateTime>();
//        Console.WriteLine($"DateTime类型的长度：{len}");
//        len = Unsafe.SizeOf<TimeOnly>();
//        Console.WriteLine($"TimeOnly类型的长度：{len}");
//        DateTime dateTime = DateTime.Now;
//        Console.WriteLine($"当前时间：{dateTime}");
//        len = Unsafe.SizeOf<string>();
//        Console.WriteLine($"string类型的长度：{len}");

//    }
//}