using TestProject.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace TestProject.Domain.Helpers
{
    public class Response<T> : ControllerBase
    {
        public IActionResult ResponseSending(ApiResponse<T> response) => 
            (HttpStatusCodeEnum)response.Status switch
            {
                HttpStatusCodeEnum.Success => Ok(response),
                HttpStatusCodeEnum.BadRequest => BadRequest(response),
                HttpStatusCodeEnum.NotFound => NotFound(response),
                HttpStatusCodeEnum.Forbidden => Forbid(),
                _ => BadRequest(response)
            };
    }
}
