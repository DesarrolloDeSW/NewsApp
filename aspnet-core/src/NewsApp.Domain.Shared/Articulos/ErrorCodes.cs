using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Articulos
{
    public enum ErrorCodes
    {
        ApiKeyExhausted,
        ApiKeyMissing,
        ApiKeyInvalid,
        ApiKeyDisabled,
        ParametersMissing,
        ParametersIncompatible,
        ParameterInvalid,
        RateLimited,
        RequestTimeout,
        SourcesTooMany,
        SourceDoesNotExist,
        SourceUnavailableSortedBy,
        SourceTemporarilyUnavailable,
        UnexpectedError,
        UnknownError,
        TodoBien
    }
}
