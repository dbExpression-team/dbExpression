using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace HatTrick.DbEx.Sql
{
    public static partial class Throw
    {
        public static T ArgumentNullException<T>(
            [NotNull] T? argument, 
            [CallerArgumentExpression("argument")] string? paramName = null
        )
        {
            if (argument is null)
            {
                ThrowArgumentNullException(paramName);
            }
            return argument!;
        }

        [DoesNotReturn]
        private static void ThrowArgumentNullException(string? paramName)
            => throw new ArgumentNullException(paramName);
    }
}

