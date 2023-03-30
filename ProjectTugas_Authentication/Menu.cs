using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Authentication
{
    public class Menu
    {
        public List<Person> people;
        Person person;
        public Menu() { 
        people = new List<Person>();
        printMenu();
        }

        public void printMenu()
        {
            Console.WriteLine("Selamat Datang Di Management Supplier"+Environment.NewLine);
            Console.WriteLine("1.Add   ");
            Console.WriteLine("2.Edit    ");
            Console.WriteLine("3.Search  ");
            Console.WriteLine("4.Remove   ");
            Console.WriteLine("5.Print ");
            Console.WriteLine("6.Login ");
            Console.WriteLine("Pilih Menu Anda !!");

            bool menuError = int.TryParse(Console.ReadLine(), out int pilihMenu);

            if (menuError == true) {
                if (pilihMenu == 1) {
                    Console.Clear();
                    addUser();
                }
                else if (pilihMenu == 2)
                {
                    Console.Clear();
                    EditUser();
                }
                else if(pilihMenu == 3)
                {
                    Console.Clear();
                    SearchUser();
                }
                else if (pilihMenu == 4){
                    Console.Clear();
                    DeleteUser();
                }
                else if(pilihMenu == 5)
                {
                    Console.Clear();
                    Print();
                    
                }
                else if(pilihMenu == 6)
                {
                    Console.Clear();
                    Login();
                }
                else
                {
                    Console.WriteLine("Menu Yang anda Pilih Tidak ada");
                    printMenu();
                }

                printMenu();

            }
            else
            {
                Console.WriteLine(" Mohon Masukan Angka");
                Console.WriteLine("Klik Enter to menu");
                Console.ReadLine();
                Console.Clear();
                printMenu();
            }
        }

        public void addUser()
        {
            JudulOption("Add Menu");
            try
            {
                Person person = returnPerson();

                if (person != null)
                {
                    if (people.Any(u => u.Username.Contains(person.Username)))
                    {
                        person.Username = person.firstName.Substring(0,2)+person.lastName.Substring(0,2)+people.Count(p=>p.Username.ToLower().Contains(person.Username.ToLower()));
                        
                    }
                    people.Add(person);
                    Console.WriteLine("berhasil input.");


                }
                else
                {
                    OutputMessage("Something has went wrong.");
                    addUser();
                }
            }
            catch (Exception)
            {
                OutputMessage("Something has went wrong.");
                addUser();  
            }
            
            ClearOption();
            Console.Clear();

        }
        
        public void EditUser()
        {
            JudulOption("EDIT MENU");
            if (!isSystemEmpty())
            {
                Console.WriteLine("==========================================");
                PrintAllUsers();
                Console.WriteLine("==========================================");

                try
                {
                    Console.Write("Enter an index: ");
                    int indexSelection = Convert.ToInt32(Console.ReadLine());
                 
                    indexSelection--;

                

                    if (indexSelection >= 0 && indexSelection <= people.Count - 1)
                    {
                        try
                        {
                            Person person = returnPerson();

                            if (person != null)
                            {
                                people[indexSelection] = person;
                                Console.WriteLine("berhasil edit");
                                ClearOption();
                                Console.Clear();
                            }
                            else
                            {
                                OutputMessage("edit gagal.");
                                EditUser();
                            }
                        }
                        catch (Exception)
                        {
                            OutputMessage("edit gagal.");
                            EditUser();
                        }
                    }
                    else
                    {
                        OutputMessage("range index tidak ditemukan.");
                        EditUser();
                    }
                }
                catch (Exception)
                {
                    OutputMessage("Gagal Edit.");
                    EditUser();
                }
            }
            else
            {
                OutputMessage("");
            }
        }
        public void SearchUser()
        {
            JudulOption("Search Menu");
            var id = 0;
            if (!isSystemEmpty())
            {
                Console.Write("Enter a Username: ");
                string nameInput = Console.ReadLine();

                var cari = people.Where(p=>p.firstName.ToLower().Contains(nameInput)||p.lastName.ToLower().Contains(nameInput));
                

                if (!string.IsNullOrEmpty(nameInput)) // "" null
                {

                    foreach (var person in cari)
                    {
                        Console.WriteLine("==========================================");
                        id++;
                        Console.WriteLine("ID" + " " + "FirstName" + " " + "Lastname" + " " + "Username");
                        Console.WriteLine(id +" "+person.returnDetail());
                        Console.WriteLine("==========================================");
                    }
                    

                    ClearOption();
                }
                else
                {
                    OutputMessage(" enter a name.");
                    SearchUser();
                }
            }
            else
            {
                OutputMessage("");
            }
        }
        public void DeleteUser()
        {
            if (!isSystemEmpty())
            {
                PrintAllUsers();

                Console.Write("Enter an index: ");
                int index = Convert.ToInt32(Console.ReadLine());
                index--;


                if (index >= 0 && index <= people.Count - 1)
                {
                    people.RemoveAt(index);
                    Console.WriteLine("Berhasil Delete.");

                   ClearOption();
                }
                else
                {
                    OutputMessage("Range tidak ditemukan.");
                    DeleteUser();
                }
            }
            else
            {
                OutputMessage("");
            }
        }
        public void Login()
        {
            JudulOption("Login Menu");
            bool bFound = false;
           
            
            if (!isSystemEmpty())
            {
                Console.Write("Enter a Username: ");
                string Username = Console.ReadLine();
                Console.Write("Enter a Password: ");
                string Password = Console.ReadLine();
                var login = people.SingleOrDefault(p => p.Username == Username && p.Password == Password );
                if (Username != null && Password != null)
                {
                    if (login != null)
                    {
                        Console.WriteLine("Login Berhasil");
                    }
                    else
                    {
                        Console.WriteLine("Login Gagal");
                    }
                    
                    
                }
            }

        }

        public void Print()
        {
            if (!isSystemEmpty())
            {
                Console.WriteLine("==========================================");
                PrintAllUsers();
                Console.WriteLine("==========================================");
            }

            ClearOption();
            
        }

        public void ClearOption()
        {
            Console.WriteLine("Kembali ke Menu klik Enter");
            Console.ReadLine();
        }

        public void JudulOption(string option)
        {
            Console.WriteLine(option + Environment.NewLine);
        }

        public void OutputMessage(string message)
        {
            if (message.Equals(string.Empty)) 
            {
                Console.Write("Press <Enter> to return to the menu.");
            }
            else
            {
                Console.WriteLine(message + " Press <Enter> to try again.");
            }
            Console.ReadLine();
            Console.Clear();
        }
        public void PrintAllUsers()
        {
            Console.WriteLine("ID" + " " + "FirstName"+" "+"Lastname"+" "+"Username"+" "+"Pasword");
            var id = 1;
            foreach (var user in people)
            {
                    Console.WriteLine(id++ +" " + user.returnDetail());
                
               
            }
        }
        public Person returnPerson()
        {
           

            Console.Write("Masukan FirstName: ");
            String firstname = Console.ReadLine();

            Console.Write("Masukan LastnameName: ");
            String lastname = Console.ReadLine();

            Console.Write("Masukan Password: ");
            String password = Console.ReadLine();

            


         
                if (!string.IsNullOrEmpty(firstname)) //-1
                {
                    if (!string.IsNullOrEmpty(lastname))
                    {
                    
                        
                        return new Person(firstname, lastname, password);
                    }

                    else
                    {
                        OutputMessage("Masukan LastName");
                    }
                        
                }
                else
                {
                    OutputMessage("Masukan firstName");
                }
            
         

            return null;
        }
        public bool isSystemEmpty()
        {
            if (people.Count == 0)
            {
                Console.WriteLine("User Kosong");
                return true;
            }
            else
            {
                return false;
            }
        }
    }


}

