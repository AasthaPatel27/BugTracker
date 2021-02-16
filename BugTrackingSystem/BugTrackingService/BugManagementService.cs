using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BugTrackingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BugManagementService" in both code and config file together.
    public class BugManagementService : IBugManagementService
    {
        public void DoWork()
        {

        }

        string IBugManagementService.AddBugAlertRecord(BugAlert bugAlert)
        {
            string result = "";
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["BugTrackingDatabase"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);


                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = "INSERT INTO BugAlert(Title, Description, CreatedBy, CategoryId, Status,CreatedOn) Values (@title, @description, @createdBy, @categoryId, @status,@createdOn)";
                sqlCmd.Parameters.AddWithValue("@title", bugAlert.Title);
                sqlCmd.Parameters.AddWithValue("@description", bugAlert.Description);
                sqlCmd.Parameters.AddWithValue("@createdBy", bugAlert.CreatedBy);
                sqlCmd.Parameters.AddWithValue("@categoryId", bugAlert.CategoryId);
                sqlCmd.Parameters.AddWithValue("@status", bugAlert.Status);
                sqlCmd.Parameters.AddWithValue("@createdOn", bugAlert.CreatedOn);
                conn.Open();
                sqlCmd.ExecuteNonQuery();
                conn.Close();
                result = "Bug Alert Record added Successfully.";

            }
            catch (FaultException fex)
            {
                result = "Error occured while creating Bug Alert Record :=> " + fex.ToString();
            }
            return result;
        }

        string IBugManagementService.ClaimBugAlertResolution(int bugId, int developerId, int assignedBy)
        {
            throw new NotImplementedException();
        }

        string IBugManagementService.DeleteBugAlertRecord(int bugAlertId)
        {
            throw new NotImplementedException();
        }

        void IBugManagementService.DoWork()
        {
            throw new NotImplementedException();
        }

        DataSet IBugManagementService.GetAllBugAlertRecords(BugAlertFilter filter)
        {
            throw new NotImplementedException();
        }

        BugAlert IBugManagementService.GetBugAlertRecord(int bugId)
        {
            BugAlert bugAlert = null;
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["BugTrackingDatabase"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = "SELECT * from BugAlert where Id = @Id";
                sqlCmd.Parameters.AddWithValue("@Id", bugId);
                conn.Open();
                SqlDataReader reader = sqlCmd.ExecuteReader();
                if (reader.Read())
                {
                    bugAlert = new BugAlert()
                    {
                        BugId = (int)reader[0],
                        Title = (string)reader[1],
                        Description = (string)reader[2],
                        CreatedBy = (int)reader[3] ,
                        CategoryId = (int)reader[4],
                        Status = (BugAlertStatus)reader[5],
                        ResolutionDescription = !DBNull.Value.Equals(reader[6])?(string)reader[6]:" ",
                        ReportPath = !DBNull.Value.Equals(reader[7])?(string)reader[7] : " ",
                        CreatedOn = (DateTime)reader[8],
                        AssignedOn = !DBNull.Value.Equals(reader[9])?(DateTime?)reader[9]:null,
                        ResolvedOn = !DBNull.Value.Equals(reader[10])?(DateTime?)reader[10]:null
                    };
                }
                conn.Close();
            }
            catch (FaultException fex)
            {
                Console.WriteLine("Error occured while creating Bug Alert Record :=> " + fex.ToString());
            }
            return bugAlert;
        }

        DataSet IBugManagementService.GetBugCategories()
        {
            throw new NotImplementedException();
        }

        string IBugManagementService.ResolveBugAlert(BugAlert bugAlert)
        {
            throw new NotImplementedException();
        }

        string IBugManagementService.RetreatBugAlertResolution(int bugId, int developerId)
        {
            throw new NotImplementedException();
        }

        string IBugManagementService.UpdateBugAlert(BugAlert bugAlert)
        {
            throw new NotImplementedException();
        }
    }
}
