using System;

namespace s2w3Challenge
{
    public class GradingService : IGrader
    {
        private readonly IGrader _grader;
        public GradingService(IGrader grader)
        {
            _grader = grader;
        }
        public void CalculateGrade(double grade1, double grade2, double grade3)
        {
            _grader.CalculateGrade(grade1, grade2, grade3);
        }
    }
}
