using System;
using System.Runtime.CompilerServices;

class Week1Challenge
{
 static void Main(string[] args)
    {
        /* Problem description: Your instructor needs to calculate individual student grades for another class.

        Requirements/User stories:

        The instructor will provide the number of students for which grades need to be calculated.  This number must be at least one.
        For each student, the instructor will provide five homework grades, three quiz grades, and two exam grades. 
        All grades must be between 0 and 100 inclusively. A student's final grade average is calculated by adding together 50% 
        of the homework average, 30% of the quiz average and 20% of the exam average. A student's final grade is calculated  based on the 
        final grade average.  If it is 90% or greater, it is an A; 80% or better is a B; 70% or better is a C; 60% or better is a D; and 
        anything less than 60% is an F. Once calculated, the program will display the student's name, homework average, quiz average, 
        exam average, final average and final grade.

        Breakdown:
        Instructor provides number of students, must be at least one. //for loop
        For each student, instructor will provide five homework grades, three quiz grades and two exam grades, which all must be between
        0 and 100
        Students Final grade average is calculated by adding together 50% of HW average, 30% of quiz average, and 20% of exam average.
        A students final grade is calculated based on the final grade average.
        100-90 is an A, 89-80 is a B, 79-70 is a C, 69-60 is a D, else F.
        Afterwords display students name, homework average, quiz average, exam average and final average.

        Algorithim:

        Prompt for number of students.
        Obtain number of students.

            Do While Loop.
                Use method to validate input is an integer greater than 0.
                    If, number of students is validated, return number of students.
                    Else, provide "Error: Please enter a whole number between 0 and 100".

            For Loop
                Iterate through the number of students provided above and calculate their grades one at a time

                    For Loop
                        Prompt for 5 homework scores
                        Obtain 5 homework scores
                            Use Method to validate homework scores
                                Assign each score to an accumulator
                                    Break

                    Calcaulate and display total homework score
                    Calculate and display homework score average

                     For Loop
                     Prompt for 3 quiz scores
                        Obtain 3 quiz scores
                            Use Method to validate quiz scores
                                Assign each score to an accumulator
                                    Break

                    Calcaulate and display total quiz score
                    Calculate and display quiz score average

                     For Loop
                     Prompt for 2 exam scores
                        Obtain 2 exam scores
                            Use Method to validate exam scores
                                Assign each score to an accumulator
                                    Break

                    Calcaulate and display total exam score
                    Calculate and display exam score average

                    Calculate final grade average.

                    If final grade average >= 90, display A.
                        else if, grade >= 80, display B.
                            else if, grade >= 70, display C.
                                else if, grade >= 60, display D.
                    else, display F.
                    
                Loop back up to next student however many times we were prompted to.        

            End number of students for loop

        Display All students have been graded. 
        */

        //Declare variables
        int studentInput = 0;
        int homeworkGrades = 0;
        int numberOfHomeworkGrades = 5;
        int numberOfQuizGrades = 3;
        int numberOfExamGrades = 2;
        int homeworkAccumulator = 0;

        Console.Write("Please enter number of students to grade: ");

        string stringInput = Console.ReadLine();

        studentInput = ValidateStudentInput(stringInput);

            //For Loop to iterate through the number of students, will update after each students grades have posted.
            for(int studentCount = 1; studentCount <= studentInput; studentCount++)
            {
                /*Students Final grade average is calculated by adding together 50% of HW average, 30% of quiz average, 
                and 20% of exam average. A students final grade is calculated based on the final grade average.
                100-90 is an A, 89-80 is a B, 79-70 is a C, 69-60 is a D, else F.*/

                int homeworkTotalScore = 0;
                int homeworkAverage = 0;
                int quizTotalScore = 0;
                int quizAverage = 0;
                int examTotalScore = 0;
                int examAverage = 0;
                int finalGradeAverage = 0;
                char finalGrade;

                Console.WriteLine();
                Console.WriteLine($"Student {studentCount}:");

                //For each student, instructor will provide five homework grades, three quiz grades and two exam grades, 
                // which all must be between 0 and 100

                    //Start get math scores loop
                    for(int i = 1; i <= 5; i++)
                    {
                    Console.Write($"Please enter student {studentCount}'s homework grades {i} of 5: ");
                    string homeworkInput = Console.ReadLine();
                    int validHomeworkInput = ValidateInteger(homeworkInput);
                    homeworkTotalScore += validHomeworkInput;
                    homeworkAverage = homeworkTotalScore / 5;
                    } 
                    //end get math scores loop
                    
                    Console.WriteLine();
                    Console.WriteLine($"Student {studentCount}'s total homework score is: {homeworkTotalScore}");
                    Console.WriteLine($"Student {studentCount}'s average homework score is: {homeworkAverage}");
                    Console.WriteLine();


                    //Start get quiz scores loop
                    for(int k = 1; k <= 3; k++)
                    {
                    Console.Write($"Please enter student {studentCount}'s quiz grades {k} of 3: ");
                    string quizInput = Console.ReadLine();
                    int validQuizInput = ValidateInteger(quizInput);
                    quizTotalScore += validQuizInput;
                    quizAverage = quizTotalScore / 3;

                    //Console.WriteLine(homeworkTotalScore); test to see if accumulator is working
                    }
                    //End get quiz scores loop

                    Console.WriteLine();
                    Console.WriteLine($"Student {studentCount}'s total quiz score is: {quizTotalScore}");
                    Console.WriteLine($"Student {studentCount}'s average quiz score is: {quizAverage}");
                    Console.WriteLine();

                    //Start get exam scores loop
                    for(int l = 1; l <= 2; l++)
                    {
                    Console.Write($"Please enter student {studentCount}'s exam grades {l} of 2: ");
                    string examInput = Console.ReadLine();
                    int validExamInput = ValidateInteger(examInput);
                    examTotalScore += validExamInput;
                    examAverage = examTotalScore / 2;

                    //Console.WriteLine(homeworkTotalScore); test to see if accumulator is working
                    }
                    //End get quiz scores loop

                    Console.WriteLine();
                    Console.WriteLine($"Student {studentCount}'s total exam score is: {examTotalScore}");
                    Console.WriteLine($"Student {studentCount}'s average exam score is: {examAverage}");
                    Console.WriteLine();

                    /*Students Final grade average is calculated by adding together 50% of HW average, 30% of quiz average, 
                    and 20% of exam average. A students final grade is calculated based on the final grade average.
                    100-90 is an A, 89-80 is a B, 79-70 is a C, 69-60 is a D, else F.*/

                    finalGradeAverage = (int) ((homeworkAverage * .5) + (quizAverage * .3) + (examAverage * .2));
                    Console.WriteLine($"Student {studentCount}'s final grade average is: {finalGradeAverage}");
                    
                    if(finalGradeAverage >= 90)
                        {
                            Console.WriteLine($"Student {studentCount}'s final grade is: A");
                        }
                        else if(finalGradeAverage >= 80)
                        {
                            Console.WriteLine($"Student {studentCount}'s final grade is: B");
                        }
                        else if(finalGradeAverage >= 70)
                        {
                            Console.WriteLine($"Student {studentCount}'s final grade is: C");
                        }
                        else if(finalGradeAverage >= 60)
                        {
                            Console.WriteLine($"Student {studentCount}'s final grade is: D");
                        }
                        else
                        {
                            Console.WriteLine($"Student {studentCount}'s final grade is: F");
                        }

            } //End of student count loop

            Console.WriteLine();
            Console.WriteLine("All students grades have been calculated.");
        
    }   //End of main
    

//Method for validating number of student unput
static int ValidateStudentInput(string input)
    {
        //declare variables
        bool isValid = false;
        int studentInput = 0;

        //Start loop
        do
        {
            if(int.TryParse(input, out studentInput) && studentInput > 0)
            {
                isValid = true;
            }
            else
            {
                Console.Write("Please enter a whole number greater than 0: ");
                input = Console.ReadLine();
            }
        } while(!isValid); //End of do while loop

        return studentInput;
    }

    //Method for validating student grade input
    static int ValidateInteger(string input)
    {
        //declare variables
        bool isValid = false;
        int studentInput = 0;

        do
        {
            if(int.TryParse(input, out studentInput) && studentInput >= 0 && studentInput <= 100)
            {
                isValid = true;
            }
            else
            {
                Console.Write("Please enter a whole number between 0 and 100: ");
                input = Console.ReadLine();
            }
        } while(!isValid); //End of do while loop

        return studentInput;

    } //End of ValidateInteger method



} //End of class