using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uams.BL
{
    class Student
    {

        private string name;
        private int age;
        private double fscMarks;
        private double ecatMarks;
        private double merit;
        private List<DegreeProgram> preferences;
        private List<Subject> regSubject;
        private DegreeProgram regDegree;
        public string getName() { return name; }
        public void setName(string name) { this.name = name; }
        public int getAge() { return age; }
        public void setAge(int age) { this.age = age; }
        public double getFscMarks() { return fscMarks; }
        public void setFscMarks(double fscMarks) { this.fscMarks = fscMarks; }
        public double getEcatMarks() { return ecatMarks; }
        public void setEcatMarks(double ecatMarks) { this.ecatMarks = ecatMarks; }
        public double getMerit() { return merit; }
        public void setMerit(double merit) { this.merit = merit; }
        public List<DegreeProgram> getPreferences() { return preferences; }
        public void setPreferences(List<DegreeProgram> preferences) { this.preferences = preferences; }
        public List<Subject> getRegSubject() { return regSubject; }
        public void setRegSubject(List<Subject> regSubject) { this.regSubject = regSubject; }
        public DegreeProgram getRegDegree() { return regDegree; }   
        public void setRegDegree(DegreeProgram regDegree) { this.regDegree = regDegree;}

        public Student(string name, int age, double fscMarks, double ecatMarks, List<DegreeProgram> preferences)
        {
            this.name = name;
            this.age = age;
            this.fscMarks = fscMarks;
            this.ecatMarks = ecatMarks;
            this.preferences = preferences;
            regSubject = new List<Subject>();
            
        }

        public void calculateMerit()
        {
            this.merit = (((fscMarks / 1100) * 0.45F) + ((ecatMarks / 400) * 0.55F)) * 100;
         
        }

        
        public bool regStudentSubject(Subject s)
        {
            int stCH = getCreditHours();
            if (regDegree != null && regDegree.isSubjectExists(s) && stCH + s.getCreditHours() <= 9)
            {
                regSubject.Add(s);
                return true;
            }
            else
            {
                return false;
                
            }
        }

        public int getCreditHours()
        {
            int count = 0;
            foreach (Subject sub in regSubject)
            {
                count = count + sub.getCreditHours();
            }
            return count;
        }

        public float calculateFee()
        {
            float fee = 0;
            if (regDegree != null)
            {
                foreach (Subject sub in regSubject)
                {
                    fee = fee + sub.getSubjectFees();
                }
            }
            return fee;
        }

        
    }
}
