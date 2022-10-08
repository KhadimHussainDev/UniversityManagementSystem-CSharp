using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uams.BL
{
    class DegreeProgram
    {
        private string degreeName;
        private float degreeDuration;
        private List<Subject> subjects;
        private int seats;
        public string getDegreeName() { return degreeName; }
        public void setDegreeName(string degreeName) { this.degreeName = degreeName; }
        public float getDegreeDuration() { return degreeDuration; }
        public void setDegreeDuration(float degreeDuration) { this.degreeDuration = degreeDuration; }
        public List<Subject> getSubjects() { return subjects; }
        public void setSubjects(List<Subject> subjects) { this.subjects = subjects; }
        public int getSeats() { return seats; }
        public void setSeats(int seats) { this.seats = seats; }
        public DegreeProgram(string degreeName, float degreeDuration, int seats)
        {
            this.degreeName = degreeName;
            this.degreeDuration = degreeDuration;
            this.seats = seats;
            subjects = new List<Subject>();
        }

        public bool isSubjectExists(Subject sub)
        {
            foreach (Subject s in subjects)
            {
                if (s.getCode() == sub.getCode())
                {
                    return true;
                }
            }
            return false;
        }

        public bool AddSubject(Subject s)
        {
            int creditHours = calculateCreditHours();
            if(creditHours + s.getCreditHours() <= 20)
            {
                subjects.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }

        public int calculateCreditHours()
        {
            int count = 0;
            for (int x = 0; x < subjects.Count; x++)
            {
                count = count + subjects[x].getCreditHours();
            }
            return count;
        }

    }
}
