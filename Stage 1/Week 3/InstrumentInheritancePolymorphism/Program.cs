using System;

namespace InstrumentInheritancePolymorphism
{
  class Program
  {
    static void Main(string[] args)
    {

        //Declare and instantiate an array of Instrument objects
        Instrument[] instrumentArray = new Instrument[10];

        //Loop through each array element and instantiate a new blank Instrument object
        for (int i = 0; i < instrumentArray.Length; i++)
        {
            instrumentArray[i] = new Instrument();
        }

        // load some sample data into the array

        instrumentArray[1].Name = "Piano";
        instrumentArray[1].Classification = "Percussives/strings";
        instrumentArray[2].Name = "Violin";
        instrumentArray[2].Classification = "Strings";
        instrumentArray[3].Name = "Drums";
        instrumentArray[3].Classification = "Percussions";

        // Print the instrument data to the console

        for (int i = 0; i < instrumentArray.Length; i++)
        {
            if(instrumentArray[i].Name != " ")
            {
                Console.WriteLine(instrumentArray[i].ToString());
            }
        }

        Console.WriteLine(); //space between tests

        // test the inheritance with default constructor and parameterized constructor

        Instrument instrument1 = new Instrument();
        Console.WriteLine(instrument1.ToString());
        Instrument instrument2 = new Instrument("Generic Instrument", "Unknown Classification");
        Console.WriteLine(instrument2.ToString());


        Instrument piano1 = new Piano();
        Console.WriteLine(piano1.ToString());
        Instrument piano2 = new Piano("Great Piano", "Percussives/strings", 88, 3);
        Console.WriteLine(piano2.ToString());

        Instrument violin1 = new Violin();
        Console.WriteLine(violin1.ToString());
        Instrument violin2 = new Violin("Acoustic", "Strings", "Maple", "Horsehair");
        Console.WriteLine(violin2.ToString());

        Instrument drums1 = new Drums();
        Console.WriteLine(drums1.ToString());
        Instrument drums2 = new Drums("Yamaha Drum Set", "Percussions", "5", "3");
        Console.WriteLine(drums2.ToString());

        Console.WriteLine(); //space between tests

        // test adding Piano objects to the Instrument array

        instrumentArray[4] = piano2;
        instrumentArray[5] = violin2;
        instrumentArray[6] = drums2;
        
        // Print the instrument data to the console

        for (int i = 0; i < instrumentArray.Length; i++)
        {
            if(instrumentArray[i].Name != " ")
            {
                Console.WriteLine(instrumentArray[i].ToString());
            }
        }

        Console.WriteLine(); //space between tests

        // Test the playInstrument method
        Console.WriteLine("Testing playInstrument method:");

        instrument2.PlayInstrument();
        piano2.PlayInstrument();
        violin2.PlayInstrument();
        drums2.PlayInstrument();

    } // end of Main
  } // end of class Program
} // end of namespace InstrumentInheritancePolymorphism