using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        private int capacity;
        public List<Student> Students { get; set; }
        public int Capacity { get { return capacity; } set { capacity = value; } }
        public int Count { get { return Students.Count; } }
        public Classroom(int capacity)
        {
            Capacity = capacity;
            Students = new List<Student>();
        }
        public string RegisterStudent(Student student)
        {
            if (Students.Count+1 > Capacity)
            {
                return "No seats in the classroom";
            }
            else
            {
                Students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
        }
        public string DismissStudent(string firstName, string lastName)
        {
            bool isFound = false;
            foreach (var stud in Students)
            {
                if (stud.FirstName == firstName && stud.LastName == lastName)
                {
                    isFound = true;
                    Students.Remove(stud);
                    break;
                }
            }
            if (isFound)
            {
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }
        public string GetSubjectInfo(string subject)
        {
            List<Student> subjectStudents = Students.Where(s => s.Subject == subject).ToList();
            if (subjectStudents.Count == 0)
            {
                return $"No students enrolled for the subject";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"Subject: {subject}").Append(Environment.NewLine);
                sb.Append("Students:").Append(Environment.NewLine);
                foreach (var sub in subjectStudents)
                {
                 sb.Append($"{sub.FirstName} {sub.LastName}").Append(Environment.NewLine);
                }
                return sb.ToString().TrimEnd();
            }

        }
        public int GetStudentsCount()
        {
            return Count;
        }
        public Student GetStudent(string firstName, string lastName)
        {
            Student currentStudent = Students.Find(s => s.FirstName == firstName && s.LastName == lastName);
            return currentStudent;
        }
    }
}
