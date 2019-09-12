using System;
using System.ComponentModel;

namespace inventoryapi.Domain.Enums
{
    /* TODO: This is temporary */
    public enum EUnitOfMeasurement
    {
        [Description("UN")]
        Unit = 1,

        [Description("MG")]
        Milligram = 2,

        [Description("G")]
        Gram = 3,

        [Description("KG")]
        Kilogram = 4,

        [Description("L")]
        Liter = 5,

        [Description("ML")]
        Milliliter = 6
    }
}
