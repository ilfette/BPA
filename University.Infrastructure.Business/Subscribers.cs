//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using University.Domain.Core;
//using University.Infrastructure.Data;
//using Microsoft.EntityFrameworkCore;

//namespace University.Infrastructure.Business
//{


//    public class Customer
//    {
       
//        public readonly string reaction;

//        public Customer(string name)
//        {
            
//        }
//        public abstract string display(string message);
//        public void print(string reaction)
//        {
//            Console.WriteLine( ": " + reaction);
//        }

//    }

//    //internal class StudentMail : Customer
//    //{
//    //    public override string display(string message)
//    //    {
//    //        string reaction = "";
//    //        if (message.Equals("Новый товар!"))
//    //        {
//    //            reaction = "Опять что-то";
//    //        }
//    //        else if (message.Equals("Скидки"))
//    //        {
//    //            reaction = "Надо бы отписаться...";
//    //        }
//    //        else
//    //        {
//    //            reaction = " Да, пора отписаться.";
//    //        }
//    //        print(reaction);
//    //        return reaction;
//    //    }
//    //}
//    //class LectorMail : Customer
//    //{

//    //    public override string display(string message)
//    //    {
//    //        string reaction = "";
//    //        if (message.Equals("Новый товар!"))
//    //        {
//    //            reaction = "Опять что-то";
//    //        }
//    //        else if (message.Equals("Скидки"))
//    //        {
//    //            reaction = "Надо бы отписаться...";
//    //        }
//    //        else
//    //        {
//    //            reaction = " Да, пора отписаться.";
//    //        }
//    //        print(reaction);
//    //        return reaction;
//    //    }
//    //}




//}
