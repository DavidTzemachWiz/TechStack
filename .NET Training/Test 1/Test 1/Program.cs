using OpenQA.Selenium;
using System.Security.Cryptography.X509Certificates;

namespace Test_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Arrays 

            //Array of numbers 
            int[] myNum = { 10, 20, 30, 40 };
            string[] myNum2 = { "David", "Shalom"};

            //Array Lenght 
            Console.WriteLine(myNum.Length);
            //Access element 
            Console.WriteLine(myNum2[1]);

            //Loop through array 
            foreach (var name in myNum)
            {
                Console.WriteLine(name);
            }


        }

    }

    public class a
    {
        public static void MyMethod()
        {
            int i = 1;
            if (i == 0)
            {
                Console.WriteLine("Number is 0");
            }
            else
            {
                Console.WriteLine("Number is not 0");
            }
        }
    }

}