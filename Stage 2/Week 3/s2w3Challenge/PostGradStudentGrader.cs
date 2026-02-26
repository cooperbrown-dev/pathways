using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s2w3Challenge
{
    public class PostgradStudentGrader : IGrader
    {
        public void CalculateGrade(double grade1, double grade2, double grade3)
        {
            Console.WriteLine("Inside Grade method of PostgradStudentGrader.");
            GradePostgradStudent(grade1, grade2, grade3);
        }
        private void GradePostgradStudent(double grade1, double grade2, double grade3)
        {
            Console.WriteLine("Method: GradePostgradStudent, Grade: {0}", (grade1 + grade2 + grade3) / 3);
        }
    }
}
