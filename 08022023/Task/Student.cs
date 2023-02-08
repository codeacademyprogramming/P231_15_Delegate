using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Task
{
    internal class Student
    {
        public int No;
        public string FullName;
        private Dictionary<string, byte> _exams = new Dictionary<string, byte>();


        public void AddExam(string examName,byte examPoint)
        {
            if (_exams.ContainsKey(examName))
                throw new Exception($"Exam already added with name {examName}");

            if(examPoint>100)
                throw new Exception($"ExamPoint must be greater than 0 and lower than 100");

            _exams.Add(examName, examPoint);
        }


        public void ShowExams()
        {
            foreach (var item in _exams)
            {
                Console.WriteLine(item.Key+"-"+item.Value);
            }
        }

        public double GetAvgPoint()
        {
            if(_exams.Count==0)
                return 0;

            double sum = 0;
            foreach (var item in _exams)
            {
                sum += item.Value;
            }

            return sum/ _exams.Count;
        }

    }

}
