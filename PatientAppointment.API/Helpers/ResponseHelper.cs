using Microsoft.AspNetCore.Mvc;

namespace PatientAppointment.API.Helpers
{
    public class ResponseHelper
    {
        public static JsonResult GetActionResponse(bool status, string message, dynamic data = null)
        {
            var response = new
            {
                status,
                message,
                data
            };

            return new JsonResult(response);
        }
    }
}
