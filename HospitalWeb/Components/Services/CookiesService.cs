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
            patDateOfBirthColumnVisible,
            patTelephoneColumnVisible,
            patMailColumnVisible,
            patPassportColumnVisible,
            patAdressColumnVisible,
            patWorkAdressColumnVisible,
            patGenreColumnVisible,
            patInsuranceNumberVisible,
            patInsuranceEndVisible,
            patMedCardCreateVisible,
            hospReason,
            hospRejection,
            hospCancel,
        }
        private async void SetCookie(Keys key, string value, int Days = 1)
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
        public void SaveParametrInCookie(Services.CookiesService.Keys keys, bool parametr, int Days = 31)
        {
            string parametrInCookie = parametr ? "1" : "0";
            SetCookie(keys, parametrInCookie, Days);
        }

        public async Task<Dictionary<Keys, bool>> LoadCookieVisibleColumn(Dictionary<Keys, bool> _columnVisibility)
        {
            Dictionary<Keys, bool> dictionary = new();
            foreach (var column in _columnVisibility.Keys)
            {
                dictionary.Add(column, await GetCookie(column) == "0" ? false : true);
            }
            return dictionary;
        }

    }
}
