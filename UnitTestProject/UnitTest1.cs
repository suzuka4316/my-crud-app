using System;
using ICTPRG403_ICTPRG404_ICTPRG410.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private Repository _repo;

        /// <summary>
        /// Initialization test
        /// </summary>
        [TestInitialize]
        public void Init()
        {
            _repo = new Repository();
            _repo.ResetDatabase();
        }

        /// <summary>
        /// GetPeople method test.
        /// The test will pass when the returned collection is greater than one.
        /// </summary>
        [TestMethod]
        public void GetPeople()
        {
            //TODO: (Task 2B) 
            //add logic to test (Assert.IsTrue) the number of people instances returned 
            //from the GetPeople() method is greater than zero
            IEnumerable<Person> people = _repo.GetPeople();
            Assert.IsTrue(people.Count() >= 1);
        }

        /// <summary>
        /// InsertPerson method test.
        /// The test will pass when the returned integer value of rows affected is equal to one.
        /// </summary>
        [TestMethod]
        public void InsertPerson()
        {
            //TODO: (Task 3B) 
            //add the logic to test (Assert.AreEqual) the 
            //number of rows affected returned from the Repository InsertPerson method is equal to one (1)
            //Use the values provided below
            //FirstName: Sue, LastName: White, Height: 6.1, Weight: 65
            Person p = new Person { FirstName = "Sue", LastName = "White", Height = 6.1, Weight = 65 };
            int rowsAffected = _repo.InsertPerson(p);
            Assert.AreEqual(rowsAffected, 1);
        }

        /// <summary>
        /// UpdatePerson method test.
        /// The test will pass when the returned integer value of rows affected is equal to one.
        /// </summary>
        [TestMethod]
        public void UpdatePerson()
        {
            //TODO: (Task 4B) 
            //add the logic to test (Assert.AreEqual) the number of rows affected 
            //returned from UpdatePerson is equal to one (1).
            //Update the Person record with an Id of 2, i.e. GetPeople().First(p=>p.Id == 2), and update with the values provided below
            //Id: 2, FirstName: Sally, LastName: Blue, Height: 5.3, Weight: 51
            Person update = _repo.GetPeople().First(p => p.Id == 2);
            update.FirstName = "Sally";
            update.LastName = "Blue";
            update.Height = 5.3;
            update.Weight = 51;
            int rowsAffected = _repo.UpdatePerson(update);
            Assert.AreEqual(rowsAffected, 1);
        }

        /// <summary>
        /// DeletePerson method test.
        /// The test will pass when the returned integer value of rows affected is equal to one.
        /// </summary>
        [TestMethod]
        public void DeletePerson()
        {
            //TODO: (Task 5B) 
            //add the logic to test (Assert.AreEqual) the number of rows affected returned 
            //from DeletePerson is equal to one (1).
            //Delete the Person record with an Id of 4 i.e. GetPeople().First(p=>p.Id == 4).
            Person delete = _repo.GetPeople().First(p => p.Id == 4);
            int rowsAffected = _repo.DeletePerson(delete);
            Assert.AreEqual(rowsAffected, 1);
        }
    }
}
