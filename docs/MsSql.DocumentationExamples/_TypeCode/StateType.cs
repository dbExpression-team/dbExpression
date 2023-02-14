using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MsSql.DocumentationExamples
{
    public enum StateType
    {
        [Display(Name = "AL", Description = "Alabama")]
        AL = 1,
        [Display(Name = "AK", Description = "Alaska")]
        AK = 2,
        [Display(Name = "AZ", Description = "Arizona")]
        AZ = 3,
        [Display(Name = "AR", Description = "Arkansas")]
        AR = 4,
        [Display(Name = "CA", Description = "California")]
        CA = 5,
        [Display(Name = "CO", Description = "Colorado")]
        CO = 6,
        [Display(Name = "CT", Description = "Connecticut")]
        CT = 7,
        [Display(Name = "DE", Description = "Delaware")]
        DE = 8,
        [Display(Name = "FL", Description = "Florida")]
        FL = 9,
        [Display(Name = "GA", Description = "Georgia")]
        GA = 10,
        [Display(Name = "HI", Description = "Hawaii")]
        HI = 11,
        [Display(Name = "ED", Description = "Idaho")]
        ID = 12,
        [Display(Name = "IL", Description = "Illinois")]
        IL = 13,
        [Display(Name = "IN", Description = "Indiana")]
        IN = 14,
        [Display(Name = "IA", Description = "Iowa")]
        IA = 15,
        [Display(Name = "KS", Description = "Kansas")]
        KS = 16,
        [Display(Name = "KY", Description = "Kentucky")]
        KY = 17,
        [Display(Name = "LA", Description = "Louisiana")]
        LA = 18,
        [Display(Name = "ME", Description = "Maine")]
        ME = 19,
        [Display(Name = "MD", Description = "Maryland")]
        MD = 20,
        [Display(Name = "MA", Description = "Massachusetts")]
        MA = 21,
        [Display(Name = "MI", Description = "Michigan")]
        MI = 22,
        [Display(Name = "MN", Description = "Minnesota")]
        MN = 23,
        [Display(Name = "MS", Description = "Mississippi")]
        MS = 24,
        [Display(Name = "MO", Description = "Missouri")]
        MO = 25,
        [Display(Name = "MT", Description = "Montana")]
        MT = 26,
        [Display(Name = "NE", Description = "Nebraska")]
        NE = 27,
        [Display(Name = "NV", Description = "Nevada")]
        NV = 28,
        [Display(Name = "NH", Description = "New Hampshire")]
        NH = 29,
        [Display(Name = "NJ", Description = "New Jersey")]
        NJ = 30,
        [Display(Name = "NM", Description = "New Mexico")]
        NM = 31,
        [Display(Name = "NY", Description = "New York")]
        NY = 32,
        [Display(Name = "NC", Description = "North Carolina")]
        NC = 33,
        [Display(Name = "ND", Description = "North Dakota")]
        ND = 34,
        [Display(Name = "OH", Description = "Ohio")]
        OH = 35,
        [Display(Name = "OK", Description = "Oklahoma")]
        OK = 36,
        [Display(Name = "OR", Description = "Oregon")]
        OR = 37,
        [Display(Name = "PA", Description = "Pennsylvania")]
        PA = 38,
        [Display(Name = "RI", Description = "Rhode Island")]
        RI = 39,
        [Display(Name = "SC", Description = "South Carolina")]
        SC = 40,
        [Display(Name = "SD", Description = "South Dakota")]
        SD = 41,
        [Display(Name = "TN", Description = "Tennessee")]
        TN = 42,
        [Display(Name = "TX", Description = "Texas")]
        TX = 43,
        [Display(Name = "UT", Description = "Utah")]
        UT = 44,
        [Display(Name = "VT", Description = "Vermont")]
        VT = 45,
        [Display(Name = "VA", Description = "Virginia")]
        VA = 46,
        [Display(Name = "WA", Description = "Washington")]
        WA = 47,
        [Display(Name = "WV", Description = "West Virginia")]
        WV = 48,
        [Display(Name = "WI", Description = "Wisconsin")]
        WI = 49,
        [Display(Name = "WY", Description = "Wyoming")]
        WY = 50
    }
}
