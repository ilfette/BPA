using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using University.Domain.Core;

namespace University.Domain.Interfaces
{
    public interface CRUDRepository<T>:IDisposable
        where T : class
    {       
            IEnumerable<T> GetList(); // получение всех объектов
            T GetItem(int id); // получение одного объекта по id
            void Create(T item); // создание объекта
            void Update(T item); // обновление объекта
            void Delete(int id); // удаление объекта по id
            void Save();  // сохранение изменений        
    }
}
