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
        void IBugManagementService.DoWork()
        {
            return;
        }

        string IBugManagementService.AddBugAlertRecord(BugAlert bugAlert)
        {
            string result = "";
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["BugTrackingDatabase"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);

                bugAlert.CreatedOn = DateTime.Now;
                bugAlert.Status = BugAlertStatus.New;
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
            string result = "";
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["BugTrackingDatabase"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = "INSERT INTO BugAlertAssignmentTable(BugAlertId,DeveloperId,AssignedBy) Values (@bugAlertId, @developerId, @assignedBy)";
                sqlCmd.Parameters.AddWithValue("@bugAlertId", bugId);
                sqlCmd.Parameters.AddWithValue("@developerId", developerId);
                sqlCmd.Parameters.AddWithValue("@assignedBy", assignedBy);

                SqlCommand sqlCmd2 = new SqlCommand();
                sqlCmd2.Connection = conn;
                sqlCmd2.CommandText = "UPDATE BugAlert SET status=@status where Id=@id";
                sqlCmd2.Parameters.AddWithValue("@status", BugAlertStatus.UnderResolution);
                sqlCmd2.Parameters.AddWithValue("@id", bugId);
                

                conn.Open();
                sqlCmd.ExecuteNonQuery();

                sqlCmd2.ExecuteNonQuery();
                conn.Close();
                result = "Bug Alert Assignment Record added Successfully.";

            }
            catch (FaultException fex)
            {
                result = "Error occured while creating Bug Alert Assignment Record :=> " + fex.ToString();
            }
            return result;
        }

        string IBugManagementService.RetreatBugAlertResolution(int bugId, int developerId)
        {
            string msg = "";
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["BugTrackingDatabase"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = "DELETE from BugAlertAssignmentTable where BugAlertId=@bugAlertId and DeveloperId=@developerId";
                sqlCmd.Parameters.AddWithValue("@bugAlertId", bugId);
                sqlCmd.Parameters.AddWithValue("@developerId", developerId);

                SqlCommand sqlCmd2 = new SqlCommand();
                sqlCmd2.Connection = conn;
                sqlCmd2.CommandText = "UPDATE BugAlert SET status=@status where Id=@id";
                sqlCmd2.Parameters.AddWithValue("@status", BugAlertStatus.Abandoned);
                sqlCmd2.Parameters.AddWithValue("@id", bugId);

                conn.Open();
                sqlCmd.ExecuteNonQuery();
                sqlCmd2.ExecuteNonQuery();
                conn.Close();
                msg = "Bug Alert Assignment Record Deleted Successfully.";
            }
            catch (FaultException fex)
            {
                msg = "Error occured while deleting Bug Alert Assignment Record :=> " + fex.ToString();
            }
            return msg;
        }

        string IBugManagementService.DeleteBugAlertRecord(int bugAlertId)
        {
            string msg = "";
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["BugTrackingDatabase"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = "DELETE from BugAlert where Id=@id";
                sqlCmd.Parameters.AddWithValue("@id", bugAlertId);
                conn.Open();
                sqlCmd.ExecuteNonQuery();
                conn.Close();
                msg = "Bug Alert Record Deleted Successfully.";
            }
            catch (FaultException fex)
            {
                msg = "Error occured while deleting Bug Alert Record :=> " + fex.ToString();
            }
            return msg;
        }

        

        DataSet IBugManagementService.GetAllBugAlertRecords(BugAlertFilter filter,int personId)
        {
            DataSet bugCategories = new DataSet();
            var connectionString = ConfigurationManager.ConnectionStrings["BugTrackingDatabase"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conn;
            var cmdText = "";
            if (filter == BugAlertFilter.All)
            {
                 cmdText= "SELECT * from BugAlert";
                sqlCmd.CommandText = cmdText;
            }
            else if(filter == BugAlertFilter.AllByTester)
            {
                cmdText = "SELECT BA.Id,BA.Title,BC.Title as CategoryName,BA.Description,BA.CreatedBy,BA.Status,BA.ResolutionDescription from BugAlert as BA,BugCategory as BC where BA.CreatedBy=@createdBy and BA.CategoryId=BC.Id";
                sqlCmd.CommandText = cmdText;
                sqlCmd.Parameters.AddWithValue("@createdBy", personId);
            }
            else if (filter == BugAlertFilter.AllByDeveloper)
            {
                cmdText = "SELECT BA.Id,BA.Title,BC.Title as CategoryName,BA.Description,BA.CreatedBy,BA.Status,BA.ResolutionDescription from BugAlert as BA,BugAlertAssignmentTable as AT,BugCategory as BC where BA.Id = AT.BugAlertId and AT.DeveloperId=@developerId and BA.CategoryId=BC.Id";
                sqlCmd.CommandText = cmdText;
                sqlCmd.Parameters.AddWithValue("@developerId", personId);
            }
            else if (filter == BugAlertFilter.UnresolvedByDeveloper)
            {
                cmdText = "SELECT BA.Id,BA.Title,BA.Description,BA.ResolutionDescription,BC.Title as CategoryName,BA.CreatedBy,BA.Status from BugAlert as BA,BugAlertAssignmentTable as AT,BugCategory as BC where BA.Id = AT.BugAlertId and AT.DeveloperId=@developerId and BA.status!=@status and BA.CategoryId=BC.Id";
                sqlCmd.CommandText = cmdText;
                sqlCmd.Parameters.AddWithValue("@developerId", personId);
                sqlCmd.Parameters.AddWithValue("@status", BugAlertStatus.Resolved);
            }
            else if (filter == BugAlertFilter.ResolvedByDeveloper)
            {
                cmdText = "SELECT BA.Id,BA.Title,BA.Description,BA.ResolutionDescription,BC.Title as CategoryName,BA.CreatedBy,BA.Status from BugAlert as BA,BugAlertAssignmentTable as AT,BugCategory as BC where BA.Id = AT.BugAlertId and AT.DeveloperId=@developerId and BA.status=@status and BA.CategoryId=BC.Id";
                sqlCmd.CommandText = cmdText;
                sqlCmd.Parameters.AddWithValue("@developerId", personId);
                sqlCmd.Parameters.AddWithValue("@status", BugAlertStatus.Resolved);
            }
            else if (filter == BugAlertFilter.UnresolvedByTester)
            {
                cmdText = "SELECT * from BugAlert where CreatedBy=@createdBy and Status!=@status";
                sqlCmd.CommandText = cmdText;
                sqlCmd.Parameters.AddWithValue("@createdBy", personId);
                sqlCmd.Parameters.AddWithValue("@status", BugAlertStatus.Resolved);
            }
            else if (filter == BugAlertFilter.AllUnresolved)
            {
                cmdText = "SELECT * from BugAlert where Status!=@status1 and Status!=@status2";
                sqlCmd.CommandText = cmdText;
                sqlCmd.Parameters.AddWithValue("@status1", BugAlertStatus.Resolved);
                sqlCmd.Parameters.AddWithValue("@status2", BugAlertStatus.UnderResolution);
            }

            try
            {
                conn.Open();
                SqlDataAdapter categorySqlDataAdapter = new SqlDataAdapter(sqlCmd);
                categorySqlDataAdapter.Fill(bugCategories);
                bugCategories.Tables[0].TableName = "BugAlert";
                conn.Close();
            }
            catch (FaultException fex)
            {
                Console.WriteLine("Error occured while retriving Bug Alert Record :=> " + fex.ToString());
            }
            return bugCategories;
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
            DataSet bugCategories = new DataSet();
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["BugTrackingDatabase"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = "SELECT * from BugCategory";
                conn.Open();
                SqlDataAdapter categorySqlDataAdapter = new SqlDataAdapter(sqlCmd);
                categorySqlDataAdapter.Fill(bugCategories);
                bugCategories.Tables[0].TableName = "BugCategory";
                conn.Close();
            }
            catch (FaultException fex)
            {
                Console.WriteLine("Error occured while retriving Bug Category Record :=> " + fex.ToString());
            }
            return bugCategories;
        }

        string IBugManagementService.ResolveBugAlert(int bugAlertId,string bugAlertResolutionDescription)
        {
            string result = "";
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["BugTrackingDatabase"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = "UPDATE BugAlert SET ResolutionDescription=@resolutiondescription,Status=@status where Id=@id";
                sqlCmd.Parameters.AddWithValue("@resolutiondescription", bugAlertResolutionDescription);
                sqlCmd.Parameters.AddWithValue("@status", BugAlertStatus.Resolved);
                sqlCmd.Parameters.AddWithValue("@id", bugAlertId);

                /*SqlCommand sqlCmd2 = new SqlCommand();
                sqlCmd2.Connection = conn;
                sqlCmd2.CommandText = "DELETE from BugAlertAssignmentTable where BugAlertId=@bugId";
                sqlCmd2.Parameters.AddWithValue("@status", BugAlertStatus.Abandoned);
                sqlCmd2.Parameters.AddWithValue("@bugId", bugAlertId);*/
                
                conn.Open();
                sqlCmd.ExecuteNonQuery();
                //sqlCmd2.ExecuteNonQuery();
                conn.Close();
                result = "Bug Alert status set to Resolved Successfully.";

            }
            catch (FaultException fex)
            {
                result = "Error occured while Setting Bug Alert state as Resolved :=> " + fex.ToString();
            }
            return result;
        }

        

        string IBugManagementService.UpdateBugAlert(BugAlert bugAlert)
        {
            string result = "";
            bugAlert.Status = BugAlertStatus.New;
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["BugTrackingDatabase"].ConnectionString;
                SqlConnection conn = new SqlConnection(connectionString);
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conn;
                sqlCmd.CommandText = "UPDATE BugAlert SET Title=@title, Description=@description, CreatedBy=@createdBy, CategoryId=@categoryId, Status= @status,CreatedOn=@createdOn where Id=@id";
                sqlCmd.Parameters.AddWithValue("@title", bugAlert.Title);
                sqlCmd.Parameters.AddWithValue("@description", bugAlert.Description);
                sqlCmd.Parameters.AddWithValue("@createdBy", bugAlert.CreatedBy);
                sqlCmd.Parameters.AddWithValue("@categoryId", bugAlert.CategoryId);
                sqlCmd.Parameters.AddWithValue("@status", bugAlert.Status);
                sqlCmd.Parameters.AddWithValue("@createdOn", bugAlert.CreatedOn);
                sqlCmd.Parameters.AddWithValue("@id", bugAlert.BugId);
                conn.Open();
                sqlCmd.ExecuteNonQuery();
                conn.Close();
                result = "Bug Alert Record Updated Successfully.";

            }
            catch (FaultException fex)
            {
                result = "Error occured while updating Bug Alert Record :=> " + fex.ToString();
            }
            return result;
        }
    }
    
}
