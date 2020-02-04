using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedProgramming
{
    class Lecture : Person
    {

        public string Departerment { get; set; }

        CheckInput checkInput = new CheckInput();

        public Lecture()
        { }
        public Lecture(string ID, string Name, string Address, DateTime DateOfBirth, string Email, string Departerment) : base(ID, Name, Address, DateOfBirth, Email)
        {
            this.Departerment = Departerment;
        }

        public void AddNew(List<Person> lecture)
        {
            base.AddNew();
            while (true)
            {
                Console.WriteLine("Please Enter Lecturer Department:");
                string takeDept = Console.ReadLine();
                if (checkInput.IsNotNull(takeDept) > 0)
                {
                    this.Departerment = takeDept;
                    break;
                }

            }

            if (!lecture.Exists(l => l.ID == this.ID))
            {
                lecture.Add(new Lecture(this.ID, this.Name, this.Address, this.DateOfBirth.Date, this.Email, this.Departerment));
            }
        }

        public new void ViewAll(List<Person> lecture)
        {
            if (lecture != null)
            {
                Console.WriteLine("******************************LIST LECTURER******************************");
                Console.WriteLine("ID   |   Name    |   Address |   Date of birth   |       Email     |   Departerment ");
                Console.WriteLine();
                foreach (Person p in lecture)
                {

                    Lecture l = p as Lecture;

                    Console.WriteLine(l.ID + "  |   " + l.Name + "  |    " +
                        l.Address + "  |    " + l.DateOfBirth.Date.ToShortDateString() + "  |    " + l.Email + "    |    " + l.Departerment);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("database is null");
                return;
            }
        }

        public new void Search(string searchName, List<Person> lecture)
        {
            foreach (Person p in lecture)
            {
                Lecture l = p as Lecture;
                if (l.Name.Contains(searchName))
                {

                    if (lecture.IndexOf(l) > -1)
                    {
                        Console.WriteLine("******************************LIST LECTURER******************************");
                        Console.WriteLine("ID   |   Name    |   Address |   Date of birth   |       Email     |   Department ");
                        Console.WriteLine(l.ID + "  |   " + l.Name + "  |   " + l.Address + "  |   " + l.DateOfBirth   + "  |   " + l.Email + "    |   " + l.Departerment);
                    }
                    else
                    {
                        Console.WriteLine("There is no student with that information!");
                        return;
                    }
                }
            }
        }

        public new void Delete(string delID, List<Person> lecture)
        {
            foreach (Person p in lecture)
            {
                Lecture l = p as Lecture;
                if (l.ID == delID)
                {
                    lecture.Remove(l);
                    if (lecture.IndexOf(l) < 0)
                    {
                        Console.WriteLine("This information (Lecture) has been deleted!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Something wrong has happen! (lec/del)");
                    }
                }
                else
                {
                    Console.WriteLine("Invailid ID (lec/del/noID)");
                    return;
                }
            }
        }

        public void EditInformation(string editID, List<Person> lecture)
        {
            base.EditInformation();
            base.EditInformation();
            while (true)
            {
                Console.WriteLine("_____________________");
                Console.Write("Enter new Lecturer Department");
                string editDept = Console.ReadLine();
                if (checkInput.IsNotNull(editDept) < 0)
                {
                    break;
                }
                else if (checkInput.IsNotNull(editDept) > -1)
                {
                    this.Departerment = editDept;
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
                        foreach (Person p in lecture)
                        {
                            Lecture l = p as Lecture;
                            if (lecture.Exists(l => l.ID == editID))
                            {
                                l.Name = this.Name;
                                l.Address = this.Address;
                                l.DateOfBirth = this.DateOfBirth;
                                l.Email = this.Email;
                                l.Departerment = this.Departerment;
                                if (lecture.IndexOf(l) > -1)
                                {
                                    Console.WriteLine("Saved");
                                }
                                else
                                {
                                    Console.WriteLine("Something has went wrong (lec/Edit/Save)");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Lecturer ID does not exist");
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
