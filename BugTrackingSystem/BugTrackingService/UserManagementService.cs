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
            throw new NotImplementedException();
        }

        DataSet IUserManagementService.GetAllUserRecordsByRole(UserRole _role)
        {
            throw new NotImplementedException();
        }

        DataSet IUserManagementService.GetUserRecord(int _id, UserRole _role)
        {
            throw new NotImplementedException();
        }

        DataSet IUserManagementService.GetUserRecordByPersonId(int _personId, UserRole _role)
        {
            throw new NotImplementedException();
        }

        string IUserManagementService.UpdateUserRecord(Person _person)
        {
            throw new NotImplementedException();
        }
    }
}
