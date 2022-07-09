using System;

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
    public partial class InterceptorResult
    {
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }

        private InterceptorResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
        public static InterceptorResult Success()
        {
            return new InterceptorResult(true, null);
        }

        public static InterceptorResult Fail(string message)
        {
            return new InterceptorResult(false, message);
        }

        public static InterceptorResult IfFailure(bool failed, string message)
        {
            if (failed)
                return Fail(message);
            return Success();
        }

        public static InterceptorResult IfFailure(bool failed, Func<string> message)
        {
            if (failed)
                return Fail(message());
            return Success();
        }
    }
}