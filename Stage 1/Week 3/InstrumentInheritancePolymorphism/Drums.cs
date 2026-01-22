using System;

namespace InstrumentInheritancePolymorphism
{
    public class Drums : Instrument
    {
        // Automatic Properties
        public string DrumCount { get; set; }
        public string CymbalCount { get; set; }


        // Default constructor for an empty FastFood object
        // use parent constructor for name, cuisine, rating
        public Drums() : base()
        {
            DrumCount = " ";
            CymbalCount = " ";
        }

        // Constructor when 5 parameters are provided
        public Drums(string name, string classification, string drumCount, string cymbalCount) : base(name, classification)
        {
            DrumCount = drumCount;
            CymbalCount = cymbalCount;
        }

        // Override ToString method for easy file writing
        public override string ToString()
        {
            return base.ToString() + ", " + "Number of Drums: " + DrumCount + ", " + "Number of Cymbals: " + CymbalCount;
        }

        // Override playInstrument method to test polymorphism
        public override void PlayInstrument() 
        {
            Console.WriteLine("The drums are being banged loudly");
        }

        /* Non shorthand version
        private bool driveThru;
        private bool valueMenu;

        public bool DriveThru
        {
         get { return DriveThru; }
         set { DriveThru = value; }
        }

        public bool ValueMenu
        {
         get { return ValueMenu; }
         set { ValueMenu = value; }
        }
        */

    } // end of class Drums
} // end of namespace InstrumentInheritancePolymorphism