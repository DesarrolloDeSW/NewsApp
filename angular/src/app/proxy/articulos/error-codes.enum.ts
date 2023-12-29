import { mapEnumToOptions } from '@abp/ng.core';

export enum ErrorCodes {
  ApiKeyExhausted = 0,
  ApiKeyMissing = 1,
  ApiKeyInvalid = 2,
  ApiKeyDisabled = 3,
  ParametersMissing = 4,
  ParametersIncompatible = 5,
  ParameterInvalid = 6,
  RateLimited = 7,
  RequestTimeout = 8,
  SourcesTooMany = 9,
  SourceDoesNotExist = 10,
  SourceUnavailableSortedBy = 11,
  SourceTemporarilyUnavailable = 12,
  UnexpectedError = 13,
  UnknownError = 14,
  TodoBien = 15,
}

export const errorCodesOptions = mapEnumToOptions(ErrorCodes);
