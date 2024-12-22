using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleLibrary.Users;

public class Userss:Useruse
{

    public string Password { get; set; }
    public static int Count { get; set; }
    public string FullName { get; set; }
    public string Email1 { get; set;}

    public Userss(string username, string password, string email,string fullname) : base(username, email)
    {
        FullName = fullname;
        Id = ++Count;
        Password = password;
        Email1=email;
    }

    public void PrintPersonInfo()
    {
        Console.WriteLine($"Id:{Id} Fullname:{FullName} Username:{UserName} Email:{Email} Password:{Password}");
    }

}
