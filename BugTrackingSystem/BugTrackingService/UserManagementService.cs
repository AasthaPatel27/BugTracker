using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BugTrackingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserManagementService" in both code and config file together.
    public class UserManagementService : IUserManagementService
    {
        string IUserManagementService.AddUserRecord(Person _person)
        {
            throw new NotImplementedException();
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
