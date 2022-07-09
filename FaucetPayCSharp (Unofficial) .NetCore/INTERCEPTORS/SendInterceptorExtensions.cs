using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
    public static partial class SendInterceptorExtensions
    {
        public async static Task ThrowInterceptorErrorsAsync<T>(this IEnumerable<T> interceptors, Func<T, Task<InterceptorResult>> checker) where T : IInterceptor
        {
            foreach (var interceptor in interceptors)
            {
                var result = await checker(interceptor).ConfigureAwait(false);
                if (!result.IsSuccess)
                    throw new InterceptorFailException(result, interceptor.GetType());
            }
        }

        public static object ThrowInterceptorErrors<T>(this IEnumerable<T> interceptors, Func<T, InterceptorResult> checker) where T : IInterceptor
        {
            foreach (var interceptor in interceptors)
            {
                var result = checker(interceptor);
                if (!result.IsSuccess)
                    throw new InterceptorFailException(result, interceptor.GetType());
            }
            return null;
        }
    }
}