namespace FinantialCalculator.Domain.Common.Enums
{
    using System;

    [Flags]
    public enum MethodTypeEnum
    {
        None = 0, 
        French = 1,
        Germany = 2,
        Mexican = 3,
        Peru = 4
    }
}
