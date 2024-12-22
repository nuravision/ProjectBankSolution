using ConsoleLibrary.Users;
using UserServices.Business.user.services;
bool isContinue = true;
UserService userService=new UserService();
Console.WriteLine("Website-ye xos gelmisiniz.");
while (isContinue)
{

    Console.WriteLine("1.Giris edin.");
    Console.WriteLine("2.Hesab yaradin.");
    Console.WriteLine("3.Cixis.");
    int choice;
    Int32.TryParse(Console.ReadLine(), out choice);
    switch (choice)
    {
        case 1:
            userService.AccessElectronBank();
            break;
        case 2:
            userService.AddUser();
            userService.AccessElectronBank();
            break;
        case 3:
            isContinue = false;
            Console.WriteLine("Programdan razi qaldinizmi?");
            Console.WriteLine("1-Beli,razi qaldim     2-Xeyr,razi qalmadim.");
            int YesNo;
            Int32.TryParse(Console.ReadLine(), out YesNo);
            if (YesNo==1)
            {
                Console.WriteLine("Tesekkur edirik.");
            }
            else
            {
                Console.WriteLine("Isteklerinizi qarsilaya bilmediyimiz ucun teesuf edirik.");
            }
            break;
        default:
            Console.WriteLine("Bele bir secim movcud deyil.Zehmet olmasa seciminizi duzgun daxil edin.");
            break;
    }

}