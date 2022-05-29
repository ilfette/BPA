using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Domain.Core;
using University.Infrastructure.Data;

namespace UniversityWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Добавление
            using (UniversityContext db = new UniversityContext())
            {
                if (!db.Students.Any() && !db.Lections.Any() && !db.Lectors.Any())
                {
                    var stud1 = new Student
                    {
                        Id = 1,
                        Name = "Харлов Иван Иванович",
                        Recordbook = "123456",
                        Group = "001",
                        Email = "XarlovIv@mail.ru",
                        Tel = "89134567819"
                    };
                    var stud2 = new Student
                    {
                        Id = 2,
                        Name = "Важенина Ирина Сергеевна",
                        Recordbook = "123455",
                        Group = "001",
                        Email = "VaIr@mail.ru",
                        Tel = "89138991963"
                    };
                    var lec1 = new Lection
                    {
                        Id = 1,
                        NameSubj = "Информатика"
                    };


                    
                    var lect1 = new Lector
                    {
                        Id = 2,
                        Name = "Иванов Иван Иванович",
                        Degree = "001",
                        Email = "Ivan@mail.ru",
                        Tel = "8912345678"
                    }; db.Lectors.Add(lect1);


                    db.Students.Add(stud1);
                    db.Students.Add(stud2);
                    db.Lections.Add(lec1);
                }
                db.SaveChanges();
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

