using System;
using System.Collections.Generic;
using System.Text;

namespace Bash_Soft
{
    public static class StudentsRepository
    {
        public static bool isDataInitialized = false;
        private static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;
        public static void InitializeData()
        {
            if (isDataInitialized == false)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData();
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataAlreadyInitializedException);
            }
        }

        private static void ReadData()
        {
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input) == false)
            {
                string[] args = input.Split(' ');
                string course = args[0];
                string student = args[1];
                int mark = int.Parse(args[2]);
                if (studentsByCourse.ContainsKey(course) == false)
                {
                    studentsByCourse.Add(course, new Dictionary<string, List<int>>());
                }
                if (studentsByCourse[course].ContainsKey(student) == false)
                {
                    studentsByCourse[course][student] = new List<int>();
                }
                studentsByCourse[course][student].Add(mark);
                input = Console.ReadLine();
            }
            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data Read!");
        }
        private static bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                if (studentsByCourse.ContainsKey(courseName))
                {
                    return true;
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }
            return false;
        }
        private static bool IsQueryforStudentPossible(string courseName , string studentName)
        {
            if (IsQueryForCoursePossible(courseName) && studentsByCourse[courseName].ContainsKey(studentName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingStudentInDataBase);
            }
            return false;
        }
        public static void GetStudentsScoresFromCourse(string coureseName , string studentName)
        {
            if (IsQueryforStudentPossible(coureseName, studentName)) 
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, List<int>>(studentName, studentsByCourse[coureseName][studentName]));
            }
        }
        public static void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}...");
                foreach (var studentMarks in studentsByCourse[courseName])
                {
                    OutputWriter.PrintStudent(studentMarks);
                }
            }
        }
    }
}
