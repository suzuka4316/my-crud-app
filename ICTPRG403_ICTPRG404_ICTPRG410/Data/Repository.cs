using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ICTPRG403_ICTPRG404_ICTPRG410.Data
{
 
    public class Repository
    {
        private string _connectionString; 

        /// <summary>
        /// Constructor that initializes the value of the connection string for the database.
        /// </summary>
        public Repository()
        {
            //TODO: (Task 1) 
            //initialise and assign the correct value for the _connectionString field here using ConfigurationManager. 
            _connectionString = ConfigurationManager.ConnectionStrings["ICTPRG403_ICTPRG404_ICTPRG410"].ConnectionString;
        }

        /// <summary>
        /// Method for getting all information of People table from ICTPRG403_ICTPRG404_ICTPRG410 database.
        /// Each record will be instantiated as a Person class object.
        /// </summary>
        /// <returns>Person data type list</returns>
        public IEnumerable<Person> GetPeople()
        {
            var people = new List<Person>();
            //TODO: (Task 2A) 
            //add the logic for retrieving all People records from the database and populatinng the list with the retrieved data so it can be returned
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand("sp_People_GetPeople", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string fName = reader.GetString(1);
                    string lName = reader.GetString(2);
                    double height = reader.GetDouble(3);
                    double weight = reader.GetDouble(4);
                    people.Add(new Person(id, fName, lName, height, weight));
                }
            }

            connection.Close();
            return people; 
        }

        /// <summary>
        /// Method to add a new record to the People table of ICTPRG403_ICTPRG404_ICTPRG410 database.
        /// </summary>
        /// <param name="p">Person class object</param>
        /// <returns>The number of rows that is affected</returns>
        public int InsertPerson(Person p)
        {
            int result = 0;
            //TODO: (Task 3A) 
            //add the logic for inserting a person record in the database and returning the number of rows affected
            //NOTE: ensure all disposable objects are properly disposed and parameters are used for any SQL commands executed
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand("sp_People_InsertPerson", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@FName", p.FirstName));
            command.Parameters.Add(new SqlParameter("@LName", p.LastName));
            command.Parameters.Add(new SqlParameter("@Height", p.Height));
            command.Parameters.Add(new SqlParameter("@Weight", p.Weight));

            result = command.ExecuteNonQuery();

            connection.Close();

            return result;
        }

        /// <summary>
        /// Method to update a existing record of the People table of ICTPRG403_ICTPRG404_ICTPRG410 database.
        /// </summary>
        /// <param name="p">Person class object</param>
        /// <returns>The number of rows that is affected</returns>
        public int UpdatePerson(Person p)
        {
            int result = 0;
            //TODO: (Task 4A) 
            //add the logic for updating a person record in the database and returning the number of rows affected
            //NOTE: ensure all disposable objects are properly disposed and parameters are used for any SQL commands executed
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand("sp_People_UpdatePerson", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Id", p.Id));
            command.Parameters.Add(new SqlParameter("@FName", p.FirstName));
            command.Parameters.Add(new SqlParameter("@LName", p.LastName));
            command.Parameters.Add(new SqlParameter("@Height", p.Height));
            command.Parameters.Add(new SqlParameter("@Weight", p.Weight));

            result = command.ExecuteNonQuery();

            connection.Close();

            return result;
        }

        /// <summary>
        /// Method to delete a existing record of the People table of ICTPRG403_ICTPRG404_ICTPRG410 database.
        /// </summary>
        /// <param name="p">Person class object</param>
        /// <returns>The number of rows that is affected</returns>
        public int DeletePerson(Person p)
        {
            int result = 0;
            //TODO: (Task 5A) 
            //add the logic for deleting a person record in the database and returning the number of rows affected
            //NOTE: ensure all disposable objects are properly disposed and parameters are used for any SQL commands executed
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();

            SqlCommand command = new SqlCommand("sp_People_DeletePerson", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@Id", p.Id));

            result = command.ExecuteNonQuery();

            connection.Close();

            return result;
        }

        /// <summary>
        /// Method to reset the ICTPRG403_ICTPRG404_ICTPRG410 database to the original data.
        /// </summary>
        public void ResetDatabase()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("RESET_DB", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
