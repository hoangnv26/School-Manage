using System;
using System.Collections.Generic;
using System.Text;

namespace AdvancedProgramming
{
    public class Person
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        CheckInput checkInput = new CheckInput();
        public Person()
        { }
        public Person(string ID, string Name, string Address, DateTime DoB, string Email)
        {
            this.ID = ID;
            this.Name = Name;
            this.Address = Address;
            this.DateOfBirth = DoB;
            this.Email = Email;
        }
        public virtual void AddNew()
        {
            while (true)
            {
                Console.Write("Enter ID: ");
                string takeID = Console.ReadLine();
                if (checkInput.isDigitOnly(takeID) == true)
                {
                    this.ID = takeID;
                    break;
                }
                else
                {
                    Console.WriteLine("Swrong ID format!'");
                }
            }

            while (true)
            {
                Console.WriteLine("****************");
                Console.Write("Enter Name: ");
                string takeName = Console.ReadLine();
                if (checkInput.IsNotNullNorSpecialCharacter(takeName) > -1)
                {
                    this.Name = takeName;
                    break;
                }
                else
                {
                    Console.WriteLine("Name can not be null or contain special character");
                }
            }

            while (true)
            {
                Console.WriteLine("****************");
                Console.Write("Enter Address: ");
                string takeAddress = Console.ReadLine();
                if (checkInput.IsNotNull(takeAddress) > -1)
                {
                    this.Address = takeAddress;
                    break;
                }
                else
                {
                    Console.WriteLine("Address can not be null");
                }
            }

            while (true)
            {
                Console.WriteLine("****************");
                Console.Write("Enter Date of birth: ");
                string takeDate = Console.ReadLine();
                if (checkInput.IsDateTime(takeDate) == true)
                {
                    this.DateOfBirth = DateTime.ParseExact(takeDate, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("****************");
                Console.Write("Enter Email: ");
                string takeEmail = Console.ReadLine();
                if ((checkInput.IsGmail(takeEmail)) > -1)
                {
                    this.Email = takeEmail;
                    break;
                }
                else
                {
                    Console.WriteLine("Wrorg Email format!!!!");
                }
            }
        }

        public virtual void ViewAll(List<Person> person)
        {
            if (person != null)
            {
                foreach (Person p in person)
                {
                    Console.WriteLine(p.ID + "| " + p.Name + "| " + p.Address + "| " + p.DateOfBirth + "| " + p.Email + "| ");
                }
            }
            else
            {
                Console.WriteLine("database is null");
                return;
            }
        }

        public virtual void Search(string keyword, List<Person> person)
        {
            int searchResult = 0;
            foreach (Person p in person)
            {
                if (p.ID == keyword)
                {
                    Student s = p as Student;
                    searchResult = person.IndexOf(p);
                    if (searchResult > -1)
                    {
                        Console.WriteLine(person[searchResult].ID + " " + person[searchResult].Name + " " + person[searchResult].Address + " " + person[searchResult].DateOfBirth
                            + " " + person[searchResult].Email);
                    }
                    else
                    {
                        Console.WriteLine("There is no student with that information!");
                        return;
                    }
                }
            }
        }

        public virtual void Delete(string delName, List<Person> person)
        {
            foreach (Person p in person)
            {
                if (p.Name.Contains(delName))
                {
                    person.RemoveAt(person.IndexOf(p));
                    if (person.IndexOf(p) < 0)
                    {
                        Console.WriteLine("This information has been deleted succesfully!");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Some thing has went wrong while trying to delete this information");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid ID");
                    return;
                }
            }
        }

        public virtual void EditInformation()
        {
            while (true)
            {
                Console.WriteLine("_____________________");
                Console.Write("Enter new Name: ");
                string editName = Console.ReadLine();
                if (checkInput.IsNotNull(editName) < 0)
                {
                    break;
                }
                else if (checkInput.IsNotNullNorSpecialCharacter(editName) > -1)
                {
                    this.Name = editName;
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("_____________________");
                Console.Write("Enter new address: ");
                string editAddress = Console.ReadLine();
                if (checkInput.IsNotNull(editAddress) < 0)
                {
                    break;
                }
                else
                {
                    this.Address = editAddress;
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("_____________________");
                Console.Write("Enter new date of birth: ");
                string editDOB = Console.ReadLine();
                if (checkInput.IsNotNull(editDOB) < 0)
                {
                    break;
                }
                else if (checkInput.IsDateTime(editDOB) == true)
                {
                    this.DateOfBirth = DateTime.ParseExact(editDOB, "dd/MM/yyyy", System.Globalization.CultureInfo.CurrentUICulture.DateTimeFormat);
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("_____________________");
                Console.Write("Enter new email:");
                string editEmail = Console.ReadLine();
                if (checkInput.IsNotNull(editEmail) < 0)
                {
                    break;
                }
                else if (checkInput.IsGmail(editEmail) > -1)
                {
                    this.Email = editEmail;
                    break;
                }
            }
        }
    }
}
