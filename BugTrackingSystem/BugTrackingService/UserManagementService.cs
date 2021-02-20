using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;

namespace BugTrackingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserManagementService" in both code and config file together.
    public class UserManagementService : IUserManagementService
    {
        string IUserManagementService.AddUserRecord(Person _person)
        {
            string result = "";
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["BugTrackingDatabase"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO Person (Name, Email, ContactNo, Password, CreatedBy, Role) Values (@name, @email, @cnt, @pwd, @create, @role)";
                cmd.Parameters.AddWithValue("@name",_person.Name);
                cmd.Parameters.AddWithValue("@email", _person.Email);
                cmd.Parameters.AddWithValue("@cnt", _person.Contact);
                cmd.Parameters.AddWithValue("@pwd", _person.Password);
                cmd.Parameters.AddWithValue("@create", _person.CreaedBy);
                cmd.Parameters.AddWithValue("@role", _person.Role);

                SqlCommand cmdRetrieve = new SqlCommand();
                cmdRetrieve.Connection = conn;
                cmdRetrieve.CommandText = "SELECT Id FROM Person WHERE Email = @email";
                cmdRetrieve.Parameters.AddWithValue("@email", _person.Email);

                SqlCommand cmdRolebasedEntry = new SqlCommand();
                cmdRolebasedEntry.Connection = conn;
                string roleTablePara = "";
                switch (_person.Role)
                {
                    case (UserRole.Developer):
                        roleTablePara = "Developer";
                        break;
                    case (UserRole.Tester):
                        roleTablePara = "Tester";
                        break;
                    default:
                        break;
                }
                cmdRolebasedEntry.CommandText = "INSERT INTO " + roleTablePara + "(PersonId) Values (@personId)";
                

                conn.Open();
                cmd.ExecuteNonQuery();
                _person.PersonId = (int)cmdRetrieve.ExecuteScalar();
                cmdRolebasedEntry.Parameters.AddWithValue("@personId", _person.PersonId);
                cmdRolebasedEntry.ExecuteNonQuery();
                conn.Close();
                result = "User added Successfully.";

            }
            catch(FaultException fex)
            {
                result = "Error occured while creating user :=> " + fex.ToString();
            }
            return result;
        }

        string IUserManagementService.DeleteUserRecord(int _personId, UserRole _role)
        {
            string result = "";
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["BugTrackingDatabase"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "DELETE Person WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", _personId);

                conn.Open();
                cmd.ExecuteReader();
                conn.Close();
                result = "User deleted Successfully.";

            }
            catch (FaultException fex)
            {
                result = "Error occured while deleting user :=> " + fex.ToString();
            }
            return result;
        }

        DataSet IUserManagementService.GetAllUserRecordsByRole(UserRole _role)
        {
            DataSet ds = new DataSet();
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["BugTrackingDatabase"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                if (_role == UserRole.Any)
                {
                    cmd.CommandText = "SELECT * FROM Person";
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM Person WHERE Role = @role";
                    cmd.Parameters.AddWithValue("@role", _role);
                }

                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                conn.Close();
            }
            catch (FaultException fex)
            {
                Console.WriteLine("Error occured while retreiving all users :=> " + fex.ToString());
            }
            return ds;
        }

        Person IUserManagementService.GetUserRecord(int _id, UserRole _role)
        {
            Person _per = null;
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["BugTrackingDatabase"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Person WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", _id);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    _per = new Person()
                    {
                        PersonId = (int)rdr[0],
                        Name = (string)rdr[1],
                        Email = (string)rdr[2],
                        Contact = (string)rdr[3],
                        Password = (string)rdr[4],
                        CreaedBy = (int)rdr[5],
                        Role = (UserRole)rdr[6]
                    };
                }
                conn.Close();

            }
            catch (FaultException fex)
            {
                Console.WriteLine("Error occured while retreiving user by id :=> " + fex.ToString());
            }
            return _per;
        }

        Person IUserManagementService.GetUserRecordByPersonId(int _personId, UserRole _role)
        {
            Person _per = null;
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["BugTrackingDatabase"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Person WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", _personId);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    _per = new Person() { 
                        PersonId = (int)rdr[0],
                        Name = (string)rdr[1],
                        Email = (string)rdr[2],
                        Contact = (string)rdr[3],
                        Password = (string)rdr[4],
                        CreaedBy = (int)rdr[5],
                        Role = (UserRole)rdr[6]
                    };
                }
                conn.Close();

            }
            catch (FaultException fex)
            {
                Console.WriteLine("Error occured while retreiving user by person id :=> " + fex.ToString());
            }
            return _per;
        }

        Person IUserManagementService.Login(string _email, string _password)
        {
            Person _per = null;
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["BugTrackingDatabase"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Person WHERE Email = @email AND Password = @pwd";
                cmd.Parameters.AddWithValue("@email", _email);
                cmd.Parameters.AddWithValue("@pwd", _password);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    _per = new Person()
                    {
                        PersonId = (int)rdr[0],
                        Name = (string)rdr[1],
                        Email = (string)rdr[2],
                        Contact = (string)rdr[3],
                        Password = (string)rdr[4],
                        CreaedBy = (int)rdr[5],
                        Role = (UserRole)rdr[6]
                    };
                }
                else
                {
                    _per = new Person()
                    {
                        PersonId = -1, 
                        Name = "",
                        Email = "",
                        Contact = "",
                        Password = "",
                        CreaedBy = -1,
                        Role = UserRole.Any
                    };
                }
                conn.Close();

            }
            catch (FaultException fex)
            {
                Console.WriteLine("Error occured while login :=> " + fex.ToString());
            }
            return _per;
        }

        string IUserManagementService.UpdateUserRecord(Person _person)
        {
            string result = "";
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["BugTrackingDatabase"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE Person SET Name = @name, Email = @email, ContactNo = @cnt, Password = @pwd, CreatedBy =@create, Role = @role WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", _person.PersonId);
                cmd.Parameters.AddWithValue("@name", _person.Name);
                cmd.Parameters.AddWithValue("@email", _person.Email);
                cmd.Parameters.AddWithValue("@cnt", _person.Contact);
                cmd.Parameters.AddWithValue("@pwd", _person.Password);
                cmd.Parameters.AddWithValue("@create", _person.CreaedBy);
                cmd.Parameters.AddWithValue("@role", _person.Role);

/*                SqlCommand cmdRetrieve = new SqlCommand();
                cmdRetrieve.Connection = conn;
                cmdRetrieve.CommandText = "SELECT Id FROM Person WHERE Email = @email";
                cmdRetrieve.Parameters.AddWithValue("@email", _person.Email);

                SqlCommand cmdRolebasedEntry = new SqlCommand();
                cmdRolebasedEntry.Connection = conn;
                string roleTablePara = "";
                switch (_person.Role)
                {
                    case (UserRole.Developer):
                        roleTablePara = "Developer";
                        break;
                    case (UserRole.Tester):
                        roleTablePara = "Tester";
                        break;
                    default:
                        break;
                }
                cmdRolebasedEntry.CommandText = "INSERT INTO " + roleTablePara + "(PersonId) Values (@personId)";*/


                conn.Open();
                cmd.ExecuteReader();
                //_person.PersonId = (int)cmdRetrieve.ExecuteScalar();
                //cmdRolebasedEntry.Parameters.AddWithValue("@personId", _person.PersonId);
                //cmdRolebasedEntry.ExecuteNonQuery();
                conn.Close();
                result = "User updated Successfully.";

            }
            catch (FaultException fex)
            {
                result = "Error occured while updating user :=> " + fex.ToString();
            }
            return result;
        }
    }
}
