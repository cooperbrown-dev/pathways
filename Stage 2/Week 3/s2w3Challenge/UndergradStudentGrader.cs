using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s2w3Challenge
{
    public class UndergradStudentGrader : IGrader
    {
        double finalGrade = 0;
        public void CalculateGrade(double grade1, double grade2, double grade3)
        {
            Console.WriteLine("Inside Grade method of UndergradStudentGrader.");
            GradeUndergradStudent(grade1, grade2, grade3);
        }
        private void GradeUndergradStudent(double grade1, double grade2, double grade3)
        {
            double finalGrade = (grade1 + grade2 + grade3) / 3;

            Console.WriteLine($"Final grade for undergrad student is: {finalGrade}.");
        }
    }
}
