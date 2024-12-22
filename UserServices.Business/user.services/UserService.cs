using ConsoleLibrary.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using User.DataAccess.Context;
namespace UserServices.Business.user.services
{
    public class UserService
    {
        public void AddUser() {
        gotoUsername:
            Console.Write("Username daxil edin:");
            string? username = Console.ReadLine();
            foreach(Userss u in UserDbContext.Users)
            {
                if (u.UserName==username)
                {
                    Console.WriteLine("Bu username istifadedir.Zehmet olmasa basqa username daxil edin.");
                    goto gotoUsername;
                }
            }
            if (string.IsNullOrEmpty(username))
            {
                Console.WriteLine("Duzgun giris edin.");
                goto gotoUsername;
            }
        gotoFullname:
            Console.Write("Fullname daxil edin:");
            string? fullName = Console.ReadLine();
            if (string.IsNullOrEmpty(fullName))
            {
                Console.WriteLine("Duzgun giris edin.");
                goto gotoFullname;
            }
        gotoEmail:
            Console.Write("Email daxil edin:");
            string? email = Console.ReadLine();
            Regex checkemail = new Regex("^\\S+@\\S+\\.\\S+$");
            bool yoxlama = checkemail.IsMatch(email);
            if (yoxlama == true);
            else
            {
                Console.WriteLine("Email uygun deyil.Uygun email daxil edin \n Example:assdj.skss228@gmail.com");
                goto gotoEmail;
            }
            foreach (Userss u in UserDbContext.Users)
            {
                if (u.Email == email)
                {
                    Console.WriteLine("Bu email istifadedir.Zehmet olmasa basqa email daxil edin.");
                    goto gotoEmail;
                }
            }
            if (string.IsNullOrEmpty(email))
            {
                Console.WriteLine("Duzgun giris edin.");
                goto gotoEmail;
            }
        gotoPassword:
            Console.Write("Password daxil edin:");
            string? password = Console.ReadLine();
            Regex checkpassword =new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            bool yoxla = checkpassword.IsMatch(password);
            if (yoxla == true) ;
            else
            {
                Console.WriteLine("Password uygun deyil.Uygun password daxil edin.\n Example:jKowow$so2");
                goto gotoPassword;
            }
            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Duzgun giris edin.");
                goto gotoPassword;
            }
            Userss user = new Userss(username, password, email,fullName);
            Array.Resize(ref UserDbContext.Users, UserDbContext.Users.Length + 1);
            UserDbContext.Users[UserDbContext.Users.Length-1]=user;
            Console.WriteLine("Yeni user yaradildi.");
            user.PrintPersonInfo();
        }
        public void AccessElectronBank()
        {
            bool isContiniuee = true;
            Console.WriteLine("Elektron Bank uygulamasina xos gelmisiniz.");
            while (isContiniuee)
            {
                gotoChoice:
                Console.WriteLine("1.Giris edin.");
                Console.WriteLine("2.Hesab yaradin.");
                Console.WriteLine("3.Cixis");
                Console.Write("Seciminizi daxil edin:");
                int choice1;
                Int32.TryParse(Console.ReadLine(), out choice1);
                switch (choice1)
                {
                    case 1:
                        AccountUsername();
                        break;
                    case 2:
                        AddUser();
                        break;
                    case 3:
                        isContiniuee = false;
                        Console.WriteLine("Program bitdi.Sagolun");
                        Console.WriteLine("Programdan razi qaldinizmi?");
                        Console.WriteLine("1-Beli,razi qaldim     2-Xeyr,razi qalmadim.");
                        int YesNo;
                        Int32.TryParse(Console.ReadLine(), out YesNo);
                        if (YesNo == 1)
                        {
                            Console.WriteLine("Tesekkur edirik.");
                        }
                        else
                        {
                            Console.WriteLine("Isteklerinizi qarsilaya bilmediyimiz ucun teesuf edirik.");
                        }
                        break;
                    default:
                        Console.WriteLine("Bele bir secim movcud deyil.Seciminizi duzgun daxil edin.");
                        break;
                }
            }   
        }
        public void AccountUsername()
        {
            int security = 3;
            bool ischeck=true;
            while (ischeck)
            {
                NewUsernameEmail:
                Console.Write("Username ve ya emailinizi daxil edin:");
                string? newusernameoremail = Console.ReadLine();
                foreach (Userss u1 in UserDbContext.Users)
                {
                    if (u1.UserName == newusernameoremail || u1.Email == newusernameoremail)
                    {
                        gotoNewPassword:
                        Console.Write("Passwordunuzu daxil edin:");
                        string? newpassword = Console.ReadLine();
                        if (u1.Password == newpassword)
                        {
                            giris:
                            Console.WriteLine("Giris edilen hesab isleri");
                            Console.WriteLine("1.Bilgileri goster");
                            Console.WriteLine("2.Bilgileri guncelle");
                            Console.WriteLine("3.Cixis");
                            Console.Write("Seciminizi daxil edin:");
                            int secim;
                            Int32.TryParse(Console.ReadLine(), out secim);
                            switch (secim)
                            {
                                case 1:
                                    u1.PrintPersonInfo();
                                    break;
                                case 2:
                                    NewwSecim:
                                    Console.WriteLine("Guncellemek istediyiniz bilgini secin.");
                                    Console.WriteLine("1.Email \n 2.Username \n 3.Password \n 4.Fullname");
                                    int secimm;
                                    Int32.TryParse(Console.ReadLine(), out secimm);
                                    if (secimm == 1)
                                    {
                                    newemaill:
                                        Console.Write("Yeni emailinizi daxil edin:");
                                        string? newemail = Console.ReadLine();
                                        Regex checkkemail = new Regex("^\\S+@\\S+\\.\\S+$");
                                        bool yoxxlama = checkkemail.IsMatch(newemail);
                                        if (yoxxlama == true) ;
                                        else
                                        {
                                            Console.WriteLine("Email uygun deyil.Uygun email daxil edin. \n Example:assdj.skss228@gmail.com");
                                            goto newemaill;
                                        }
                                        foreach (Userss u in UserDbContext.Users)
                                        {
                                            if (u.Email == newemail)
                                            {
                                                Console.WriteLine("Bu email istifadedir.Zehmet olmasa basqa email daxil edin.");
                                                goto newemaill;
                                            }
                                        }
                                        if (string.IsNullOrEmpty(newemail))
                                        {
                                            Console.WriteLine("Duzgun giris edin.");
                                            goto newemaill;
                                        }
                                        u1.Email1 = newemail;
                                    }
                                    else if (secimm==2)
                                    {
                                    gotoUsernAme:
                                        Console.Write("Yeni username daxil edin:");
                                        string? newwusername = Console.ReadLine();
                                        foreach (Userss u in UserDbContext.Users)
                                        {
                                            if (u.UserName == newwusername)
                                            {
                                                Console.WriteLine("Bu username istifadedir.Zehmet olmasa basqa username daxil edin.");
                                                goto gotoUsernAme;
                                            }
                                        }
                                        if (string.IsNullOrEmpty(newwusername))
                                        {
                                            Console.WriteLine("Duzgun giris edin.");
                                            goto gotoUsernAme;
                                        }
                                        u1.UserName = newwusername;
                                    }
                                    else if (secimm == 3)
                                    {
                                    gotoNewwPassword:
                                        Console.Write("Yeni password daxil edin:");
                                        string? Newwpassword = Console.ReadLine();
                                        Regex newcheckpassword = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
                                        bool newcheckk = newcheckpassword.IsMatch(Newwpassword);
                                        if ( newcheckk == true) ;
                                        else
                                        {
                                            Console.WriteLine("Password uygun deyil.Uygun email daxil edin.\n jKowow$so2");
                                            goto gotoNewwPassword;
                                        }
                                        if (string.IsNullOrEmpty(Newwpassword))
                                        {
                                            Console.WriteLine("Duzgun giris edin.");
                                            goto gotoNewwPassword;
                                        }
                                        u1.Password = Newwpassword;
                                    }
                                    else if (secimm == 4) 
                                    {
                                    gotoFullName:
                                        Console.Write("Yeni fullname daxil edin:");
                                        string? newfullnamee = Console.ReadLine();
                                        if (string.IsNullOrEmpty(newfullnamee))
                                        {
                                            Console.WriteLine("Duzgun giris edin.");
                                            goto gotoFullName;
                                        }
                                        u1.FullName = newfullnamee;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Bele bir secim movcud deyil.Seciminizi duzgun daxil edin.");
                                        goto NewwSecim;
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine("Program sona catdi.Sagolun");
                                    ischeck = false;
                                    Console.WriteLine("Programdan razi qaldinizmi?");
                                    Console.WriteLine("1-Beli,razi qaldim     2-Xeyr,razi qalmadim.");
                                    int NoYes;
                                    Int32.TryParse(Console.ReadLine(), out NoYes);
                                    if (NoYes == 1)
                                    {
                                        Console.WriteLine("Tesekkur edirik.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Isteklerinizi qarsilaya bilmediyimiz ucun teesuf edirik.");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Bele bir secim movcud deyil.Seciminizi duzgun daxil edin.");
                                    goto giris;
                                    break;
                            }
                        }
                        else
                        {
                            if (security>0)
                            {
                                Console.WriteLine("Password duzgun deyil.Passwordunuzu duzgun daxil edin.");
                                security -= 1;
                                goto gotoNewPassword;
                            }
                            else
                            {
                                Console.WriteLine("Hesab bloklandi.");
                                break;
                            }
                        }
                    }
                    else {
                        Console.WriteLine("Bele bir username ve ya password movcud deyil.Duzgun daxil edin.");
                        goto NewUsernameEmail;
                    }
                }

            }
        }
    }
}
