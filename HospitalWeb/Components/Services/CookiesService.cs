using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;

namespace HospitalWeb.Components.Services
{
    public class CookiesService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private HttpContext httpContext => httpContextAccessor.HttpContext;

        public CookiesService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public enum Keys
        {
            /// <summary>
            /// Отвечают за отображение колонок в Patients.razor
            /// </summary>
            dateOfBirthColumnVisible,
            telephoneColumnVisible,
            mailColumnVisible,
            passportColumnVisible,
            adressColumnVisible,
            workAdressColumnVisible,
            genreColumnVisible,
            insuranceNumberVisible,
            insuranceEndVisible,
            medCardCreateVisible,
        }
        public void SetCookie(Keys key, string value, uint Days = 1)
        {
            //TODO: Разобраться с куками
//            4.Используйте IResponseCookies для более точного управления куками
//Вместо прямого использования HttpResponse.Cookies, вы можете
//                использовать IResponseCookies, который предоставляет более точный контроль над установкой кук.
            var options = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(Days)
            };
            httpContextAccessor.HttpContext.Response.OnStarting(() =>
            {
                httpContextAccessor.HttpContext.Response.Cookies.Append(key.ToString(), value, options);
                return Task.CompletedTask;
            });
            //Debug.WriteLine($"Не установились куки: [{key.ToString()}] = {value}");

        }

        public enum Types
        {
            @string,
            @bool
        }
        public object GetCookie(Keys keys, Types type)
        {
            switch (type)
            {
                case Types.@string:
                    return httpContext.Request.Cookies[keys.ToString()];
                case Types.@bool:
                    var response = httpContext.Request.Cookies[keys.ToString()];
                    if (response == "false") return false;
                    if (response == "true") return true;
                    break;
                default:
                    return httpContext.Request.Cookies[keys.ToString()];
            }
            return httpContext.Request.Cookies[keys.ToString()];

        }

    }
}
