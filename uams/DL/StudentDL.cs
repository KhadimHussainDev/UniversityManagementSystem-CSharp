using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;
using System.IO;

namespace uams.DL
{
    class StudentDL
    {
        public static List<Student> studentList = new List<Student>();

        public static void addIntoStudentList(Student s)
        {
            studentList.Add(s);
        }

        public static Student StudentPresent(string name)
        {
            foreach (Student s in studentList)
            {
                if (name == s.getName() && s.getRegDegree()!= null)
                {
                    return s;
                }
            }
            return null;
        }

        public static List<Student> sortStudentsByMerit()
        {
            List<Student> sortedStudentList = new List<Student>();
            foreach (Student s in studentList)
            {
                s.calculateMerit();
            }
            sortedStudentList = studentList.OrderByDescending(o => o.getMerit()).ToList();
            return sortedStudentList;
        }

        public static void giveAdmission(List<Student> sortedStudentList)
        {
            foreach (Student s in sortedStudentList)
            {
                foreach (DegreeProgram d in s.getPreferences())
                {
                    if (d.getSeats() > 0 && s.getRegDegree() == null)
                    {
                       int seat= d.getSeats() - 1;
                        s.setRegDegree(d);
                        d.setSeats(seat);
                        break;
                    }
                }
            }
        }
        public static void storeintoFile(string path, Student s)
        {
            StreamWriter f = new StreamWriter(path, true);
            string degreeNames = "";
            for(int x = 0; x < s.getPreferences().Count - 1; x++)
            {
                degreeNames = degreeNames + s.getPreferences()[x].getDegreeName() + ";";
            }
            degreeNames = degreeNames + s.getPreferences()[s.getPreferences().Count - 1].getDegreeName();
            f.WriteLine(s.getName() + "," + s.getAge() + "," + s.getFscMarks() + "," + s.getEcatMarks() + "," + degreeNames);
            f.Flush();
            f.Close();
        }

        public static bool readFromFile(string path)
        {
            StreamReader f = new StreamReader(path); 
            string record;
            if (File.Exists(path))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string name = splittedRecord[0];
                    int age = int.Parse(splittedRecord[1]);
                    double fscMarks = double.Parse(splittedRecord[2]);
                    double ecatMarks = double.Parse(splittedRecord[3]);
                    string[] splittedRecordForPreference = splittedRecord[4].Split(';');
                    List<DegreeProgram> preferences = new List<DegreeProgram>();

                    for (int x = 0; x < splittedRecordForPreference.Length; x++)
                    {
                        DegreeProgram d = DegreeProgramDL.isDegreeExists(splittedRecordForPreference[x]);
                        if (d != null)
                        {
                            if (!(preferences.Contains(d)))
                            {
                                preferences.Add(d);
                            }
                        }
                     }
                    Student s = new Student(name, age, fscMarks, ecatMarks, preferences);
                    studentList.Add(s);
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
