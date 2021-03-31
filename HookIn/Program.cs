﻿using ICTPRG403_ICTPRG404_ICTPRG410.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HookIn
{
    class Program
    {
        static void Main(string[] args)
        {
            //Instanitate a new instance of Repository (ensure the connection string field has been initialised in the constructor as instructed in Task 1)
            var repo = new Repository();
            //Task 2A (get all existing people records from the database)
            var people = repo.GetPeople();
            foreach (var p in people)
            {
                Console.WriteLine($"Id: {p.Id}\tFirst name: {p.FirstName}\tLast name: {p.LastName}\tHeight: {p.Height}\tWeight: {p.Weight}");
            }

            //Task 3A (insert a new row in the dbo.People database table)
            var insert = new Person { FirstName = "John", LastName = "Grey", Height = 5.8, Weight = 71 };
            int rowsAffected = repo.InsertPerson(insert);
            Console.WriteLine($"{rowsAffected} row(s) affected");

            //Task 4A (update an existing record in the dbo.People database table)
            var update = repo.GetPeople().First(p => p.Id == 1);
            update.FirstName = "Joseph";
            update.LastName = "Green";
            update.Height = 6.1;
            update.Weight = 79;
            rowsAffected = repo.UpdatePerson(update);
            Console.WriteLine($"{rowsAffected} row(s) affected");

            //Task 5A (delete and existing record from the dbo.People database table)
            var delete = repo.GetPeople().First(p => p.Id == 3);
            rowsAffected = repo.DeletePerson(delete);
            Console.WriteLine($"{rowsAffected} row(s) affected");

            Console.ReadLine();
        }
    }
}
