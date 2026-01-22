using System;

namespace InstrumentInheritancePolymorphism
{
    public class Violin : Instrument
    {
        // Automatic Properties
        public string WoodType { get; set; }
        public string BowMaterial { get; set; }

        // Default constructor for an empty Buffet object
        public Violin() : base()
        {
            WoodType = " ";
            BowMaterial = " ";
        }

        // Constructor when 4 parameters are provided
        public Violin(string name, string classification, string woodType, string bowMaterial) : base(name, classification)
        {
            WoodType = woodType;
            BowMaterial = bowMaterial;
        }

        // Override ToString method for easy file writing
        public override string ToString()
        {
            return base.ToString() + ", " + "Wood Type: " + WoodType + ", " + "Bow Material: " + BowMaterial;
        }

        // Override playInstrument method to test polymorphism
        public override void PlayInstrument() 
        {
            Console.WriteLine("The violin strings are being bowed beautifully");
        }

    } // end of class Violin
} // end of namespace InstrumentInheritancePolymorphism