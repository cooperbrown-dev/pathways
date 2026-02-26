using System;
using System.Collections.Generic;
using System.Text;

namespace s2w3Challenge
{
    public interface IGrader
    {
        double CalculateGrade(double grade1, double grade2, double grade3);
    }
}