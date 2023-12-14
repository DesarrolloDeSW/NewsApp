import { mapEnumToOptions } from '@abp/ng.core';

export enum CodigosIdiomas {
  AR = 0,
  DE = 1,
  EN = 2,
  ES = 3,
  FR = 4,
  HE = 5,
  IT = 6,
  NL = 7,
  NO = 8,
  PT = 9,
  RU = 10,
  SV = 11,
  UD = 12,
  ZH = 13,
}

export const codigosIdiomasOptions = mapEnumToOptions(CodigosIdiomas);
