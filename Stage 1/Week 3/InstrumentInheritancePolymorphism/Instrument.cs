using System;

namespace InstrumentInheritancePolymorphism
{
    public class Instrument
    {
        // Automatic Properties
        public string Name { get; set; }
        public string Classification { get; set; }

        // Default constructor for an empty Restaurant object
        public Instrument()
        {
            Name = " ";
            Classification = " ";
        }

        // Constructor with 2 parameters provided
        public Instrument(string name, string classification)
        {
            Name = name;
            Classification = classification;
        }

        public virtual void PlayInstrument() 
        {
            Console.WriteLine("The instrument makes a sound");
        }

        // Override ToString method for easy file writing
        public override string ToString()
        {
            return(Name + ", " + Classification);
        }

    } // end of class Instrument
} // end of namespace InstrumentInheritancePolymorphism