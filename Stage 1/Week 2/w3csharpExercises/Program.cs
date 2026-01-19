using System;
using System.IO;
using System.Text;
class fileexercise1
{
    static void Main(string[] args)
    {
    //  1. Write a program in C# Sharp to create a blank file on the disk.

        /*string fileName = @"mytest.txt"; //Initialize the string variable with the file name
        try
        {
            Console.WriteLine("Create a file named mytest.txt in the disk : ");
            using (FileStream fileStr = File.Create(fileName)) // Creating a FileStream to create the file
            {
                Console.WriteLine("File created successfully.");
            }
        }
        catch (Exception MyExcept)
        {
            Console.WriteLine(MyExcept.ToString()); //displays the exception details if any
        }*/

        Console.WriteLine("Enter a name for the file to be created: ");
        string fileName = Console.ReadLine();

        using (FileStream fileStr = File.Create(fileName))
        {
            Console.WriteLine($"{fileName} created successfully.");
        }
    } //end of main
} // end of class