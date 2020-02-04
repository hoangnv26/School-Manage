using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedProgramming
{
    public class Student : Person
    {

        public string Class_ { get; set; }

        public Student() : base()
        { }
        public Student(string ID, string Name, string Address, DateTime DateOfBirth, string Email, string stdclass) : base(ID, Name, Address, DateOfBirth, Email)
        {
            this.Class_ = stdclass;
        }

        CheckInput checkInput = new CheckInput();

        public void AddNew(List<Person> student)
        {
            base.AddNew();

            Console.WriteLine("Please Enter Student Batch :");
            this.Class_ = "BHAF";

            if (!student.Exists(s => s.ID == this.ID))
            {
                student.Add(new Student(this.ID, this.Name, this.Address, this.DateOfBirth.Date, this.Email, this.Class_));
            }
        }

        public new void ViewAll(List<Person> student)
        {
            if (student != null)
            {
                Console.WriteLine("******************************LIST LECTURER******************************");
                Console.WriteLine("ID   |   NAME     |   ADDRESS  |   DoB                 |       EMAIL                 |   CLASS        ");
                Console.WriteLine();
                foreach (Person p in student)
                {
                    Student s = p as Student;

                    Console.WriteLine(s.ID + "     " + s.Name + "      " + s.Address + "      " + s.DateOfBirth.Date.ToShortDateString() + "      " + s.Email + "        " + s.Class_);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("database is null");
                return;
            }
        }

        public override void Search(String searchName, List<Person> student)
        {
            foreach (Person p in student)
            {
                Student s = p as Student;
                if (s.Name.Contains(searchName))
                {

                    if (student.IndexOf(s) > -1)
                    {
                        Console.WriteLine("****************************LIST STUDENT******************************");
                        Console.WriteLine("ID     |   NAME          |   ADDRESS           |   DoB             |       EMAIL     |   CLASS ");
                        Console.WriteLine(s.ID + "  |   " + s.Name + "  |   " + s.Address + "  |   " + s.DateOfBirth  + "  |   " + s.Email + "    |   " + s.Class_);
                    }
                    else
                    {
                        Console.WriteLine("There is no student with that information!");
                        return;
                    }
                }
            }
        }

        public new void Delete(string delID, List<Person> student)
        {
            foreach (Person p in student)
            {
                Student s = p as Student;
                if (s.ID == delID)
                {
                    student.Remove(s);
                    if (student.IndexOf(s) < 0)
                    {
                        Console.WriteLine("This information (Student) has been deleted!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Something wrong has happen! (Std/del)");
                    }
                }
                else
                {
                    Console.WriteLine("It does not exit");
                    return;
                }
            }
        }

        public void EditInformation(string editID, List<Person> student)
        {
            base.EditInformation();
            while (true)
            {
                Console.WriteLine("_____________________");
                Console.Write("Enter new Student Batch :  ");
                string editBatch = Console.ReadLine();
                if (checkInput.IsNotNull(editBatch) < 0)
                {
                    break;
                }
                else if (checkInput.IsNotNull(editBatch) > -1)
                {
                    this.Class_ = editBatch;
                    break;
                }
            }
            Console.WriteLine("This is the new information!");
            Console.WriteLine("______________________________________________________________________");
            Console.WriteLine("Do you want to save it?");
            Console.WriteLine("Press 1 to save the information!");
            Console.WriteLine("Press any other key to cancel this operation!");
            int n = int.Parse(Console.ReadLine());
            if (checkInput.IsValidationSwitch(n.ToString()) == true)
            {
                switch (n)
                {
                    case 1:
                        foreach (Person p in student)
                        {
                            Student s = p as Student;
                            if (student.Exists(s => s.ID == editID))
                            {
                                s.Name = this.Name;
                                s.Address = this.Address;
                                s.DateOfBirth = this.DateOfBirth;
                                s.Email = this.Email;
                                s.Class_ = this.Class_;
                                if (student.IndexOf(s) > -1)
                                {
                                    Console.WriteLine("Saved");
                                }
                                else
                                {
                                    Console.WriteLine("Something has went wrong (Std/Edit/Save)");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invailid ID!");
                                return;
                            }
                            break;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}