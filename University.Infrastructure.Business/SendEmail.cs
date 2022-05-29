//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using University.Domain.Core;
//using University.Infrastructure.Data;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.SqlServer;

//namespace University.Infrastructure.Business
//{
//    class CheckMarks
//    {
//       // SELECT avarage(mark)
//      //  FROM attendance join student on (att.studentId=student.id)
//       // GROUP BY student.id






//        private UniversityContext db;
       
//        public CheckMarks(UniversityContext university)
//        {
//            db = university;
//        }
//        public void check()
//        {
//            var books = db.Students.Include(a => a.Attendances).ToList();            
//           var phones = from p in db.Attendances
//                        join c in db.Students on p.StudentId equals c.Id
//                        group p by p.StudentId into g
//                        select new { Name = g.Key ,Avarage = g.Average(p => p.Mark)};
//            Console.WriteLine(phones);
//            //Dictionary<string, int> gen_count =
//            //new Dictionary<string, int>();
//            //foreach (var genre in genres)
//            //{
//            //    gen_count.Add(genre.Name, genre.Count);
//            //}
//            // Передаем управление "Представлению"
          
//        }

//    }
//    class SendEmail
//    {
//        List<Customer> observers = new List<Customer>();

//        public void subscribe(Customer observer)
//        {
//            observers.Add(observer);
//        }
//        public void unsubscribe(Customer observer)
//        {
//            observers.Remove(observer);
//        }
//        public void notify(int delay, string message)
//        {
//            Console.WriteLine(message);
//            foreach (var observer in observers)
//            {
//                observer.display(message);
//            }
//            Console.WriteLine();
//        }

//    }
//}
