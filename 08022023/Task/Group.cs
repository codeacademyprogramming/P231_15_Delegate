using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    internal class Group
    {
        private string _no;
        public string No
        {
            get => _no;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && value.Length == 4)
                    _no = value;
            }
        }
        List<Student> _students = new List<Student>();

        public void AddStudent(Student student)
        {
            if (!HasStudentByNo(student.No))
                _students.Add(student);
        }   

        public bool HasStudentByNo(int no)
        {
            foreach (var item in _students)
            {
                if(item.No == no)
                    return true;
            }

            return false;
        }

        public void ShowAllStudents()
        {
            foreach (var item in _students)
            {
                Console.WriteLine($"No: {item.No} - FullName - {item.FullName}");
            }
        }
    }
}
