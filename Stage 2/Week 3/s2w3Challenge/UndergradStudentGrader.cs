using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s2w3Challenge
{
    public class UndergradStudentGrader : IGrader
    {
        public double CalculateGrade(double grade1, double grade2, double grade3)
        {
            Console.WriteLine("Inside Grade method of UndergradStudentGrader.");
            // validate grades are between 0 and 100
            if (grade1 < 0 || grade1 > 100 ||
                grade2 < 0 || grade2 > 100 ||
                grade3 < 0 || grade3 > 100)
            {
                throw new ArgumentOutOfRangeException("Grades entered must be between 0 and 100.");
            }
            return GradeUndergradStudent(grade1, grade2, grade3);
        }
        public double GradeUndergradStudent(double grade1, double grade2, double grade3)
        {
            double finalGrade = (grade1 + grade2 + grade3) / 3;

            Console.WriteLine($"Final grade for undergrad student is: {finalGrade}.");

            return finalGrade;
        }
    }
}
