using System;
using System.Runtime.Serialization;

namespace Interceptors
{
    /// <summary>
    /// *** MADE FOR GITHUB ***
    /// WRITTEN BY ROMULO MEIRELLES.
    /// UPWORK: https://www.upwork.com/freelancers/~01fcbc5039ac5766b4
    /// CONTACT WHATSAPP: https://wa.me/message/KWIS3BYO6K24N1
    /// CONTACT TELEGRAM: https://t.me/Romulo_Meirelles
    /// GITHUB: https://github.com/Romulo-Meirelles
    /// DISCORD: đąяķňέs§¢øďε#2786
    /// </summary>
    /// <remarks></remarks>
    public partial class InterceptorFailException : Exception
    {
        public Type InterceptorType { get; private set; }
        public InterceptorResult Result { get; private set; }

        public InterceptorFailException()
        {
        }

        protected InterceptorFailException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public InterceptorFailException(string message) : base(message)
        {
        }
        public InterceptorFailException(string message, InterceptorResult result, Type interceptorType = null) : base(message)
        {
            InterceptorType = interceptorType;
            Result = result;
        }
        public InterceptorFailException(InterceptorResult result, Type interceptorType = null) : base(result.Message)
        {
            InterceptorType = interceptorType;
            Result = result;
        }
        public InterceptorFailException(string message, Exception innerException, Type interceptorType = null) : base(message, innerException)
        {
            InterceptorType = interceptorType;
        }
        public InterceptorFailException(string message, InterceptorResult result, Exception innerException, Type interceptorType = null) : base(message, innerException)
        {
            InterceptorType = interceptorType;
            Result = result;
        }
    }
}