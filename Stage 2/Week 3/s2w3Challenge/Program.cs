namespace s2w3ChallengeNS
{
    class Program
    {
        static void Main(string[] args)
        {
            IGrader grader = new UndergradStudentGrader();
            IGrader grader2 = new PostgradStudentGrader();

            //double grade1 = 85;
            //double grade2 = 87;
            //double grade3 = 94;

            //ValidateGrades(grade1, grade2, grade3);

            GradingService gradingService = new GradingService(grader);
            gradingService.CalculateGrade(85, 87, 94);

            GradingService gradingService2 = new GradingService(grader2);
            gradingService2.CalculateGrade(90, 87, 94);
        }

        //public double ValidateGrades(double grade1, double grade2, double grade3)
        //{
        //    Console.WriteLine("Inside Grade Validator.");
        //    // validate grades are between 0 and 100
        //    if (grade1 < 0 || grade1 > 100 ||
        //        grade2 < 0 || grade2 > 100 ||
        //        grade3 < 0 || grade3 > 100)
        //    {
        //        throw new ArgumentOutOfRangeException("Grades entered must be between 0 and 100.");
        //    }
        //    return (grade1, grade2, grade3);
        //}
    }
}