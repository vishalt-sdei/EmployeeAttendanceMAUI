using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendanceMAUI.Services
{
    public class PunchService : IPunchService
    {
        // Retrieves employee site coordinates asynchronously
        public Task<List<Models.EmployeeSiteCoordinateResponse>> GetEmpSiteCoordinate(int EmployeeId, string token)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Get<List<Models.EmployeeSiteCoordinateResponse>>(HttpWebRequest.Create(EndPoints.GetEmpSiteCoordinate + EmployeeId), token);
                return res;
            });
        }
        // Asynchronously saves punch data to the server and returns a task.
        // Accepts a punch request and an authentication token.
        public Task<Task<string>> LocSavePunch(Models.LocSavePunchRequest request, string token)
        {
            return Task.Factory.StartNew(async () =>
            {
                var res = RestClient.Post<string>(HttpWebRequest.Create(EndPoints.LocSavePunch), token, request.ToJson());
                return res;
            });
        }
        // Retrieves the employee profile asynchronously for the given approverID using the specified token.
        public Task<List<Models.EmployeeProfileResponse>> GetEmployeeProfileAsync(int approverID, string token)
        {
            return Task.Factory.StartNew(() =>
            {
                var res = RestClient.Get<Models.EmployeeProfileResponse>(HttpWebRequest.Create().Create(string.Format(EndPoints.GetEmployeeProfileUrl, approverID), token));


                return res;
            });
        }
    }
}
