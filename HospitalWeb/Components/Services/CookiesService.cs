using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;

namespace HospitalWeb.Components.Services
{
    //TODO: Надо бы уменьшить длину название cookie, дабы уменьшите размер.
    public class CookiesService
    {
        private readonly IJSRuntime jsRuntime;

        public CookiesService(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
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
        public async void SetCookie(Keys key, string value, int Days = 1)
        {
            await jsRuntime.InvokeVoidAsync("setCookie", key.ToString(), value, Days);
        }

        public enum Types
        {
            @string,
            @bool
        }
        public async Task<string> GetCookie(Keys keys)
        {
            return await jsRuntime.InvokeAsync<string>("getCookie", keys.ToString());
            
        }

    }
}
