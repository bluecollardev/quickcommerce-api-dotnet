using System;
namespace inventoryapi.Domain.Services.Communication
{
    public abstract class BaseResponse<T>
    {
        public bool Success { get; protected set; }
        public string Message { get; protected set; }

        // C# supports multiple constructors, we simplified the response creation without
        // defining different methods to handle this, just by using different constructors
        public BaseResponse()
        {
        }

        public BaseResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public T Model { get; private set; }

        protected BaseResponse(bool success, string message, T model) : this(success, message)
        {
            Model = model;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="model">Saved model.</param>
        /// <returns>Response.</returns>
        public BaseResponse(T model) : this(true, string.Empty, model)
        {
        }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public BaseResponse(string message) : this(false, message)
        {
        }
    }
}
