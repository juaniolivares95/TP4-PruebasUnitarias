using ProductModule.Helpers;

namespace ProductModule.Services
{
    public class BaseService
    {
        public GenericResponse<T> Ok<T> (T data, string message)
        {
            return new GenericResponse<T>()
            {
                Success = true,
                Data = data,
                Messsage = message
            };
        }

        public GenericResponse<T> Error<T>(string message)
        {
            return new GenericResponse<T>()
            {
                Success = false,
                Data = default,
                Messsage = message
            };
        }
    }
}
