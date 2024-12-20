using System.Security.Claims;
using EvaluationBackend.Entities;
using EvaluationBackend.Utils;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace EvaluationBackend.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected virtual string GetClaim(string claimName)
        {
            var claims = (User.Identity as ClaimsIdentity)?.Claims;
            var claim = claims?.FirstOrDefault(c =>
            string.Equals(c.Type, claimName, StringComparison.CurrentCultureIgnoreCase) &&
            !string.Equals(c.Type, "null", StringComparison.CurrentCultureIgnoreCase));
            var rr = claim?.Value!.Replace("\"", "");

            return rr ?? "";
        }

        protected Guid Id => Guid.TryParse(GetClaim("Id"), out var id) ? id : Guid.Empty;

        protected UserRole Role => Enum.Parse<UserRole>(GetClaim("Role"));
<<<<<<< HEAD
=======
        protected string FullName => (GetClaim("FullName"));

>>>>>>> 6c75216 (Initial commit)
        protected DateTime? TokenExpier => DateTime.TryParse(GetClaim("ExpierDate"), out var date) ? date : null;

        protected Guid? ParentId
        {
            get
            {
                var idString = GetClaim("ParentId");
                Guid? re;
                if (!string.Equals(idString, null, StringComparison.Ordinal) &&
                    !string.Equals(idString, "null", StringComparison.Ordinal))
                    re = Guid.Parse(idString);
                else
                    re = null;
                return re;
            }
        }

        protected string MethodType => HttpContext.Request.Method;


        protected ObjectResult OkObject<T>((T? data, string? error) result) =>
        result.error != null
        ? base.BadRequest(new { Message = result.error })
        : base.Ok(result.data);

        protected ObjectResult Ok<T>((List<T>? data, int? totalCount, string? error) result,
        int pageNumber
        ) =>
        result.error != null
        ? base.BadRequest(new { Message = result.error })
        : base.Ok(new Respons<T>
        {
            Data = result.data,
            PagesCount = (result.totalCount - 1) / Util.PageSize + 1,
            CurrentPage = pageNumber,
        });

        protected ObjectResult Ok<T>((T obj, string? error) result) =>
        result.error == "ua" ? base.Unauthorized(new { }) :
        result.error != null
        ? base.BadRequest(new { Message = result.error })
        : base.Ok(result.obj);
    }
}