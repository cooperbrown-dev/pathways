// https://www.exercisescsharp.com/oop/first-class-method-tostring

/* Create a C# program that requests three names of people from the user and stores them in an array of objects of type Person. To do this, first create a Person class that has a Name property of type string and override the ToString() method.

End the program by reading people and executing the ToString() method on the screen. */

public class FirstClass
{
    public static void Main(string[] args)
    {
        int total = 3;
        Person[] persons = new Person[total];

        for (int i = 0; i < total; i++)
        {
            persons[i] = new Person()
            {
                Name = Console.ReadLine()
            };
        } // end for loop

        foreach (Person person in persons)
        {
            Console.WriteLine(person.ToString());
        } // end for each

        Console.ReadLine();
    }
    
    
    public class Person
    {
    public string Name  {get; set;}

    public override string ToString()
        {
            return $"Hello! My name is: " + Name;
        }
    } // end of Person class
} // end of FirstClass
