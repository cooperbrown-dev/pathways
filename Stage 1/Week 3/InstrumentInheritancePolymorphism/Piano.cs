using System;

namespace InstrumentInheritancePolymorphism
{
    public class Piano: Instrument
    {
        // Automatic Properties
        public int NumberOfKeys { get; set; }
        public int PedalCount { get; set; }

        // Default constructor for an empty FineDining object
        public Piano() : base()
        {
            NumberOfKeys = 0;
            PedalCount = 0;
        }

        // Constructor when 4 parameters are provided
        public Piano(string name, string classification, int numberOfKeys, int pedalCount) : base(name, classification)
        {
            NumberOfKeys = numberOfKeys;
            PedalCount = pedalCount;
        }

        // Override ToString method for easy file writing
        public override string ToString()
        {
            return base.ToString() + ", " + "Number of Keys: " + NumberOfKeys + ", " + "Pedal Count: " + PedalCount;
        }

        // Override playInstrument method to test polymorphism
        public override void PlayInstrument() 
        {
            Console.WriteLine("The piano keys are being played melodiously");
        }

    } // end of class Piano
} // end of namespace InstrumentInheritancePolymorphism