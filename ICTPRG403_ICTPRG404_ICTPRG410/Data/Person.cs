using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICTPRG403_ICTPRG404_ICTPRG410.Data
{
    public class Person
    {
        /// <summary>
        /// Auto property to set and get the id value.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Auto property to set and get the first name value.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Auto property to set and get the last name value.
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Auto property to set and get the height value.
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// Auto property to set and get the weight value.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Null constructor.
        /// </summary>
        public Person(){}
        /// <summary>
        /// Constructor that initializes the fields values.
        /// </summary>
        /// <param name="id">id value of an instantiated object</param>
        /// <param name="firstName">first name value of an instantiated object</param>
        /// <param name="lastName">last name value of an instantiated object</param>
        /// <param name="height">height value of an instantiated object</param>
        /// <param name="weight">weight value of an instantiated object</param>
        public Person(int id, string firstName, string lastName, double height, double weight)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Height = height;
            Weight = weight;
        }
    }
}
