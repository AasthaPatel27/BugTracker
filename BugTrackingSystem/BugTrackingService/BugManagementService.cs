using System;
using System.Collections.Generic;
using System.Data;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
