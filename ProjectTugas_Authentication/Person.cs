using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Authentication
{
    public class Person
    {
       
        public string firstName { get; set; }
        public string lastName { get; set; }    

        public string Username { get; set; }
        public string Password { get; set; }

        public Person(String firsName, String lastName,string password)
        {
          
            this.firstName = firsName;
            this.lastName = lastName;
            Username = firstName.Substring(0, 2) + lastName.Substring(0, 2);
            Password = password;
        }
        public Person() { 
        
        }

        public String returnDetail()
        {
            return "  "+ firstName +"\t"+lastName +"\t"+Username+"\t"+Password;
        }

    }
}
