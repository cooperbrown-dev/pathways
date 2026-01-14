using System;
using System.Numerics;

class Week1Challenge
{
 static void Main(string[] args)
    {
        /*Problem description: Given a two-dimensional array of scores (a column contains the scores for a student),
        find the average score for each student, and the minimum, maximum and average for the class. 

        Algorithim:

        Loop through first column.
            Get sum of 3 scores to calculate average.
            Compare each score to eachother to find the max
            Comapre each score to eachother to find the min

        Loop through second column.
            Get sum of 3 scores to calculate average.
            Compare each score to eachother to find the max
            Comapre each score to eachother to find the min

        Loop through third column.
            Get sum of 3 scores to calculate average.
            Compare each score to eachother to find the max
            Comapre each score to eachother to find the min

        Do loops above for students 2 and 3.

        Calculate the average of the three averages.
            

        //:1.30, 1.15
        
        */
        int[,] scores = { {90, 83, 70}, {95, 89, 78}, {98, 88, 79} };

        Console.WriteLine();
        
        double student1Average = CalcAverage(scores);
        Console.WriteLine($"Student 1 average score is: {student1Average}");

        int student1Min = CalcMin(scores);
        Console.WriteLine($"Student 1 minimum score is: {student1Min}");

        int student1Max = CalcMax(scores);
        Console.WriteLine($"Student 1 maximum is: {student1Max}");

        Console.WriteLine();

        double student2Average = CalcAverage2(scores);
        Console.WriteLine($"Student 2 average score is: {student2Average}");

        int student2Min = CalcMin2(scores);
        Console.WriteLine($"Student 2 minimum score is: {student2Min}");

        int student2Max = CalcMax2(scores);
        Console.WriteLine($"Student 2 maximum is: {student2Max}");

        Console.WriteLine();

        double student3Average = CalcAverage3(scores);
        Console.WriteLine($"Student 3 average score is: {student3Average}");

        int student3Min = CalcMin3(scores);
        Console.WriteLine($"Student 3 minimum score is: {student3Min}");

        int student3Max = CalcMax3(scores);
        Console.WriteLine($"Student 3 maximum is: {student3Max}");

        Console.WriteLine();

        double classAverage = CalcClassAverage(scores);
        Console.WriteLine($"The class average score is: {classAverage}");


    } //end Main method
    
    static double CalcAverage(int[,] nums)
    {
        double total = 0.0;
        double average = 0.0;
        
        for (int i = 0; i < nums.GetLength(0); i++) 
        { 
            for (int j = 0; j < 1; j++) 
            { 
                total += nums[i, j];
            } 
        }  //end for loop

        average = total / 3;
        return Math.Truncate(average * 100) /100;

    } //end of CalcAverage Method

    static int CalcMin(int[,] nums)
    {
        int min = int.MaxValue; //use this to compare and find the min.
        
        for (int i = 0; i < nums.GetLength(0); i++) 
        { 
            for (int j = 0; j < 1; j++) 
            { 
                if(nums[i,j] < min)
                {
                    min = nums[i,j];
                }
            } 
        }  //end for loop
        
        return min;

    } //end of CalcMin Method

    static int CalcMax(int[,] nums)
    {
        int max = int.MinValue; //use this to compare and find the min.
        
        for (int i = 0; i < nums.GetLength(0); i++) 
        { 
            for (int j = 0; j < 1; j++) 
            { 
                if(nums[i,j] > max)
                {
                    max = nums[i,j];
                }
            } 
        }  //end for loop
        
        return max;

    } //end of CalcMin Method

    //second student methods begin here

    static double CalcAverage2(int[,] nums)
    {
        double total = 0.0;
        double average = 0.0;
        
        for (int i = 0; i < nums.GetLength(0); i++) 
        { 
            total += nums[i, 1];
        }  //end for loop

        average = total / 3;
        return Math.Truncate(average * 100) /100;

    } //end of CalcAverage Method

    static int CalcMin2(int[,] nums)
    {
        int min = int.MaxValue; //use this to compare and find the min.
        
        for (int i = 0; i < nums.GetLength(0); i++) 
        { 
            if(min > nums[i, 1])
            {
                min = nums[i, 1];
            }
        }  //end for loop
        
        return min;

    } //end of CalcMin Method

    static int CalcMax2(int[,] nums)
    {
        int max = int.MinValue; //use this to compare and find the min.
        
        for (int i = 0; i < nums.GetLength(0); i++) 
        { 
            if(max < nums[i, 1])
            {
                max = nums[i, 1];
            }
        }  //end for loop
        
        return max;

    } //end of CalcMin Method*/

    //Second students methods end here
    //3rd students methods begin here

    static double CalcAverage3(int[,] nums)
    {
        double total = 0.0;
        double average = 0.0;
        
        for (int i = 0; i < nums.GetLength(0); i++) 
        { 
            total += nums[i, 2];
        }  //end for loop

        average = total / 3;
        return Math.Truncate(average * 100) /100;

    } //end of CalcAverage Method

    static int CalcMin3(int[,] nums)
    {
        int min = int.MaxValue; //use this to compare and find the min.
        
        for (int i = 0; i < nums.GetLength(0); i++) 
        { 
            if(min > nums[i, 2])
            {
                min = nums[i, 2];
            }
        }  //end for loop
        
        return min;

    } //end of CalcMin Method

    static int CalcMax3(int[,] nums)
    {
        int max = int.MinValue; //use this to compare and find the min.
        
        for (int i = 0; i < nums.GetLength(0); i++) 
        { 
            if(max < nums[i, 2])
            {
                max = nums[i, 2];
            }
        }  //end for loop
        
        return max;

    } //end of CalcMin Method*/

    //end of third students methods
    //beginning of class average method

    static double CalcClassAverage(int[,] nums)
    {
        double total1 = 0.0;
        double average1 = 0.0;
        double total2 = 0.0;
        double average2 = 0.0;
        double total3 = 0.0;
        double average3 = 0.0;
        double classAverage = 0.0;
        
        
        for (int i = 0; i < nums.GetLength(0); i++) 
        { 
            total1 += nums[i, 0];
        }  //end for loop

        average1 = total1 / 3;

        for (int i = 0; i < nums.GetLength(0); i++) 
        { 
            total2 += nums[i, 1];
        }  //end for loop

        average2 = total2 / 3;

        for (int i = 0; i < nums.GetLength(0); i++) 
        { 
            total3 += nums[i, 2];
        }  //end for loop

        average3 = total3 / 3;

        classAverage = (average1 + average2 + average3) / 3;
        
        return Math.Truncate(classAverage * 100) / 100;
    }

}