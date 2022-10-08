using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uams.BL;
using uams.DL;

namespace uams.UI
{
    class DegreeProgramUI
    {
        public static DegreeProgram takeInputForDegree()
        {
            string degreeName;
            float degreeDuration;
            int seats;
            Console.Write("Enter Degree Name: ");
            degreeName = Console.ReadLine();
            Console.Write("Enter Degree Duration: ");
            degreeDuration = float.Parse(Console.ReadLine());
            Console.Write("Enter Seats for Degree: ");
            seats = int.Parse(Console.ReadLine());

            DegreeProgram degProg = new DegreeProgram(degreeName, degreeDuration, seats);
            Console.Write("Enter How many Subjects to Enter: ");
            int count = int.Parse(Console.ReadLine());
            for (int x = 0; x < count; x++)
            {
                Subject s = SubjectUI.takeInputForSubject();
                if (degProg.AddSubject(s))
                {
                    // These are done here because we did not add a separate option to add only the Subjects.
                    if (!(SubjectDL.subjectList.Contains(s)))
                    {
                        SubjectDL.addSubjectIntoList(s);
                        SubjectDL.storeintoFile("subject.txt", s);
                    }

                    Console.WriteLine("Subject Added");
                }
                else
                {
                    Console.WriteLine("Subject Not Added");
                    Console.WriteLine("20 credit hour limit exceeded");
                    x--;
                }
            }
            return degProg;

        }

        public static void viewDegreePrograms()
        {
            foreach (DegreeProgram dp in DegreeProgramDL.programList)
            {
                Console.WriteLine(dp.getDegreeName());
            }
        }
    }
}
