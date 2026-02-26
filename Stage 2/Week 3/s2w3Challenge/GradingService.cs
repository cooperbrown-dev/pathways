namespace s2w3ChallengeNS
{
    public class GradingService : IGrader
    {
        private readonly IGrader _grader;
        public GradingService(IGrader grader)
        {
            _grader = grader;
        }
        public double CalculateGrade(double grade1, double grade2, double grade3)
        {
            return _grader.CalculateGrade(grade1, grade2, grade3);
        }
    }
}
