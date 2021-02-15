using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BugTrackingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBugManagementService" in both code and config file together.
    [ServiceContract]
    public interface IBugManagementService
    {
        [OperationContract]
        void DoWork();

        [OperationContract]
        string AddBugAlertRecord(BugAlert bugAlert);

        [OperationContract]
        DataSet GetBugCategories();

        [OperationContract]
        BugAlert GetBugAlertRecord(int bugId);

        [OperationContract]
        DataSet GetAllBugAlertRecords(BugAlertFilter filter);

        [OperationContract]
        string UpdateBugAlert(BugAlert bugAlert);

        [OperationContract]
        string DeleteBugAlertRecord(int bugAlertId);

        [OperationContract]
        string ClaimBugAlertResolution(int bugId,int developerId,int assignedBy=0);

        [OperationContract]
        string RetreatBugAlertResolution(int bugId, int developerId);

        [OperationContract]
        string ResolveBugAlert(BugAlert bugAlert);
    }

    [DataContract]
    public enum BugAlertFilter
    {
        [EnumMember]
        All,
        [EnumMember]
        AllByTester,
        [EnumMember]
        AllByDeveloper,
        [EnumMember]
        UnresolvedByTester,
        [EnumMember]
        UnresolvedByDeveloper
    }

    [DataContract]
    public class BugCategory
    {
        int _categoryId = 0;
        string _title = "";
        string _description = "";
        int _createdBy = 0;
        int _alertCount = 0;
        int _alertCountUnresolved = 0;

        [DataMember]
        public int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

        [DataMember]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        [DataMember]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        [DataMember]
        public int CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }

        [DataMember]
        public int AlertCount
        {
            get { return _alertCount; }
            set { _alertCount = value; }
        }

        [DataMember]
        public int AlertCountUnresolved
        {
            get { return _alertCountUnresolved; }
            set { _alertCountUnresolved = value; }
        }
    }

    [DataContract]
    public class BugAlert
    {
        int _bugId = 0;
        string _title = "bug alert";
        string _description = "";
        int _createdBy = 0;
        int _categoryId = 0;
        string _status = "New";
        string _resolutionDescription = "";
        string _reportPath = "";
        DateTime _createdOn = DateTime.Now;
        DateTime _assignedOn = DateTime.MinValue;
        DateTime _resolvedOn = DateTime.MinValue;

        [DataMember]
        public int BugId
        {
            get { return _bugId; }
            set { _bugId = value; }
        }

        [DataMember]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        [DataMember]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        [DataMember]
        public int CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }

        [DataMember]
        public int CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

        [DataMember]
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        [DataMember]
        public string ResolutionDescription
        {
            get { return _resolutionDescription; }
            set { _resolutionDescription = value; }
        }

        [DataMember]
        public string ReportPath
        {
            get { return _reportPath; }
            set { _reportPath = value; }
        }

        [DataMember]
        public DateTime CreatedOn
        {
            get { return _createdOn; }
            set { _createdOn = value; }
        }

        [DataMember]
        public DateTime AssignedOn
        {
            get { return _assignedOn; }
            set { _assignedOn = value; }
        }

        [DataMember]
        public DateTime ResolvedOn
        {
            get { return _resolvedOn; }
            set { _resolvedOn = value; }
        }
    }
}
