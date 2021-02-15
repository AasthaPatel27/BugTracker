using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BugTrackingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserManagementService" in both code and config file together.
    [ServiceContract]
    public interface IUserManagementService
    {
        [OperationContract]
        void DoWork();
    }

    [DataContract]
    public class Person
    {
        int _personId = 0;
        string _name = "";
        string _email = "";
        string _contact = "";
        string _password = "";
        int _createdBy = 1;

        [DataMember]
        public int PersonId
        {
            get { return _personId; }
            set { _personId = value; }
        }

        [DataMember]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [DataMember]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        [DataMember]
        public string Contact
        {
            get { return _contact; }
            set { _contact = value; }
        }

        [DataMember]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        [DataMember]
        public int CreaedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }
    }

    [DataContract]
    public class Admin : Person
    {
        private int _adminId = 0;
        private int _devsCreeated = 0;
        private int _testersCreated = 0;
        private int _categoriesCreated = 0;

        [DataMember]
        public int AdminId
        {
            get { return _adminId; }
            set { _adminId = value; }
        }

        [DataMember]
        public int DevelopersCreated
        {
            get { return _devsCreeated; }
            set { _devsCreeated = value; }
        }

        [DataMember]
        public int TestersCreated
        {
            get { return _testersCreated; }
            set { _testersCreated = value; }
        }

        [DataMember]
        public int CategoriesCreated
        {
            get { return _categoriesCreated; }
            set { _categoriesCreated = value; }
        }
    }

    [DataContract]
    public class Developer : Person
    {
        private int _devId = 0;
        private int _bugsAssigned = 0;
        private int _bugsClaimed = 0;
        private int _bugsResolved = 0;
        private int _bugsRetreated = 0;
        private int _managedBy = -1;

        [DataMember]
        public int DeveloperId
        {
            get { return _devId; }
            set { _devId = value; }
        }

        [DataMember]
        public int BugsAssigned
        {
            get { return _bugsAssigned; }
            set { _bugsAssigned = value; }
        }

        [DataMember]
        public int BugsClaimed
        {
            get { return _bugsClaimed; }
            set { _bugsClaimed = value; }
        }

        [DataMember]
        public int BugsRetreated
        {
            get { return _bugsRetreated; }
            set { _bugsRetreated = value; }
        }

        [DataMember]
        public int BugsResolved
        {
            get { return _bugsResolved; }
            set { _bugsResolved = value; }
        }

        [DataMember]
        public int ManagedBy
        {
            get { return _managedBy; }
            set { _managedBy = value; }
        }
    }

    [DataContract]
    public class Tester : Person
    {
        private int _testerId = 0;
        private int _bugAlertsCreated = 0;
        private int _bugAlertsResolved = 0;
        private int _managedBy = -1;

        [DataMember]
        public int TesterId
        {
            get { return _testerId; }
            set { _testerId = value; }
        }

        [DataMember]
        public int BugAlertsCreated
        {
            get { return _bugAlertsCreated; }
            set { _bugAlertsCreated = value; }
        }

        [DataMember]
        public int BugAlertsResolved
        {
            get { return _bugAlertsResolved; }
            set { _bugAlertsResolved = value; }
        }

        [DataMember]
        public int ManagedBy
        {
            get { return _managedBy; }
            set { _managedBy = value; }
        }
    }
}
