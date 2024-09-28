using HospitalWeb.Components.Interfaces;

namespace HospitalWeb.Components.Services
{
    public class PhotoService : IPhotoService
    {
        public string GetBase64Photo(byte[] bytes)
        {
            var imageSrc = Convert.ToBase64String(bytes);
            return string.Format("data:image/jpeg;base64,{0}", imageSrc);
        }
    }
}
