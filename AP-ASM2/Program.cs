using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedProgramming
{
    public class Program
    {
        CheckInput checkInput = new CheckInput();

        Student student = new Student();
        Lecture lecture = new Lecture();

        List<Person> p = new List<Person>();

        public void PrintMainMenu()
        {
            Console.WriteLine("============Chose Menu==============");
            Console.WriteLine("1. Student Manage");
            Console.WriteLine("2. Lecturer Manage");
            Console.WriteLine("3. Exit");
        }
        void PrintExit()
        {
            Console.WriteLine("****************************************");
        }
 

        void PrintSubmenu(string type)
        {
            Console.WriteLine("******Manage " + type + " ********");
            Console.WriteLine("***********************************");
            Console.WriteLine("1. Add new " + type + "");
            Console.WriteLine("2. View all " + type + "");
            Console.WriteLine("3. Search " + type + " ");
            Console.WriteLine("4. Delete " + type + " ");
            Console.WriteLine("5. Update " + type + "");
            Console.WriteLine("6. Back to main menu");
            Console.WriteLine("***********************************");
            Console.Write("");
        }
        void StudentOption()
        {
            string input = "";

            while (true)
            {
                Console.Clear();
                PrintSubmenu("Student");
                input = Console.ReadLine();
                if (checkInput.IsValidationSwitch(input) == true)
                {
                    switch (int.Parse(input))
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("");
                            Console.WriteLine("__________________________________");
                            student.AddNew(p);
                            break;
                        case 2:
                            Console.Clear();
                            student.ViewAll(p);
                            Console.ReadLine();
                            break;
                        case 3:
                            Console.Clear();
                            Console.Write("Enter search name:");
                            string searchName = Console.ReadLine();
                            Console.WriteLine("____________________________________");
                            Console.WriteLine("Search result: ");
                            Console.WriteLine("____________________________________");
                            if (checkInput.IsNotNull(searchName) > -1)
                            {
                                student.Search(searchName, p);
                            }
                            else
                            {
                                Console.WriteLine("Invailid name");
                            }
                            Console.ReadLine();
                            break;
                        case 4:
                            Console.Clear();
                            Console.Write("Enter delete ID");
                            Console.WriteLine("____________________________________");
                            string delID = Console.ReadLine();
                            student.Delete(delID, p);
                            Console.ReadLine();
                            break;
                        case 5:
                            Console.Clear();
                            Console.Write("Enter edit ID: ");
                            Console.WriteLine("____________________________________");
                            string editID = Console.ReadLine();
                            if (checkInput.IsID(editID) > -1)
                            {
                                student.EditInformation(editID, p);
                            }
                            else
                            {
                                Console.WriteLine("That was not a valid ID");
                                Console.WriteLine("Do you want to continue?");
                                Console.ReadLine();
                            }
                            break;
                        case 6:
                            return;
                        default:
                            return;
                    }
                }
            }
        }
        void LecturetOption()
        {
            string input = "";

            while (true)
            {
                Console.Clear();
                PrintSubmenu("Lecture");
                input = Console.ReadLine();
                if (checkInput.IsValidationSwitch(input) == true)
                {
                    switch (int.Parse(input))
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine("This is Add New Lecture Function!!");
                            Console.WriteLine("__________________________________");
                            lecture.AddNew(p);
                            break;
                        case 2:
                            Console.Clear();
                            student.ViewAll(p);
                            Console.ReadLine();
                            break;
                        case 3:
                            Console.Clear();
                            Console.Write("Enter Student ID");
                            string searchName = Console.ReadLine();
                            Console.WriteLine("____________________________________");
                            Console.WriteLine("Search result: ");
                            Console.WriteLine("____________________________________");
                            if (checkInput.IsNotNull(searchName) > -1)
                            {
                                lecture.Search(searchName, p);
                            }
                            else
                            {
                                Console.WriteLine("Invailid name");
                            }
                            Console.ReadLine();
                            break;
                        case 4:
                            Console.Clear();
                            Console.Write("Enter delete ID");
                            Console.WriteLine("____________________________________");
                            string delID = Console.ReadLine();
                            lecture.Delete(delID, p);
                            Console.ReadLine();
                            break;
                        case 5:
                            Console.Clear();
                            Console.Write("Enter edit ID: ");
                            Console.WriteLine("____________________________________");
                            string editID = Console.ReadLine();
                            if (checkInput.IsID(editID) > -1)
                            {
                                lecture.EditInformation(editID, p);
                            }
                            else
                            {
                                Console.WriteLine("That was not a valid ID");
                                Console.WriteLine("Do you want to continue?");
                                Console.ReadLine();
                            }
                            break;
                        case 6:
                            return;
                        default:
                            return;
                    }
                }
            }
        }
    }
}
