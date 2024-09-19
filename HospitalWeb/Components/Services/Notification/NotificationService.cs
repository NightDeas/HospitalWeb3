using MudBlazor;
using System.Diagnostics;

namespace HospitalWeb.Components.Services.Notification
{
    /// <summary>
    /// Сервис, который создает уведомления для пользователя
    /// </summary>
    public class NotificationService
    {
        public enum Type
        {
            Success,
            Warning,
            Error,
            Info
        }
        Action<SnackbarOptions> Options;
        public void Config()
        {
            Options = (options) =>
            {
                options.VisibleStateDuration = 10000;
                options.ShowTransitionDuration = 500;
                options.HideTransitionDuration = 500;
            };
        }
        private ISnackbar _snackbar;


        public void Create(Type type, string text)
        {
            Severity severity = Severity.Normal;
            switch (type)
            {
                case Type.Success:
                    severity = Severity.Success;
                    break;
                case Type.Warning:
                    severity = Severity.Warning;
                    break;
                case Type.Error:
                    severity = Severity.Error;
                    break;
                case Type.Info:
                    severity = Severity.Info;
                    break;
                default:
                    severity = Severity.Normal;
                    Debug.WriteLine("Присвоено значение severity в MudSnackbarElement > Create по умолчанию");
                    break;
            }
            _snackbar.Add(text, severity, Options);
        }
    }
}
