using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;
using uams.DL;
using uams.UI;

namespace uams
{
    public class Program
    {
        static void Main(string[] args)
        {
            string subjectPath = "subject.txt";
            string degreePath = "degree.txt";
            string studentPath = "student.txt";
            if (SubjectDL.readFromFile(subjectPath))
            {
                Console.WriteLine("Subject Data Loaded Successfully");
            }
            if (DegreeProgramDL.readFromFile(degreePath))
            {
                Console.WriteLine("DegreeProgram Data Loaded Successfully");
            }
            if (StudentDL.readFromFile(studentPath))
            {
                Console.WriteLine("Student Data Loaded Successfully");
            }
            int option;
            do
            {
                option = MenuUI.Menu();
                MenuUI.clearScreen();
                if (option == 1)
                {
                    if (DegreeProgramDL.programList.Count > 0)
                    {
                        Student s = StudentUI.takeInputForStudent();
                        StudentDL.addIntoStudentList(s);
                        StudentDL.storeintoFile(studentPath, s);
                    }

                }
                else if (option == 2)
                {
                    DegreeProgram d = DegreeProgramUI.takeInputForDegree();
                    DegreeProgramDL.addIntoDegreeList(d);
                    DegreeProgramDL.storeintoFile(degreePath, d);
                }
                else if (option == 3)
                {
                    List<Student> sortedStudentList = new List<Student>();
                    sortedStudentList = StudentDL.sortStudentsByMerit();
                    StudentDL.giveAdmission(sortedStudentList);
                    StudentUI.printStudents();
                }
                else if (option == 4)
                {
                    StudentUI.viewRegisteredStudents();
                }
                else if (option == 5)
                {
                    string degName;
                    Console.Write("Enter Degree Name: ");
                    degName = Console.ReadLine();
                    StudentUI.viewStudentInDegree(degName);
                }
                else if (option == 6)
                {
                    Console.Write("Enter the Student Name: ");
                    string name = Console.ReadLine();
                    Student s = StudentDL.StudentPresent(name);
                    if (s != null)
                    {
                        SubjectUI.viewSubjects(s);
                        SubjectUI.registerSubjects(s);
                    }
                 
                }
                else if (option == 7)
                {
                    StudentUI.calculateFeeForAll();
                }
                MenuUI.clearScreen();
            }
            while (option != 8);
        }
    }
}
