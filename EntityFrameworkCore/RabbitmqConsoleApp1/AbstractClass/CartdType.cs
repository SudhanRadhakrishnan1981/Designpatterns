using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningConsoleApp.AbstractClass
{
    public enum CartdType
    {
        [Description("Travel rewards credit card")]
        Rewardscard,
        [Description("TBalance transfer credit card")]
        Balancetransfercard,
        [Description("Cash back credit card.")]
        Cashbackcredit,
        [Description("Credit card with an annual fee")]
        Creditannualfee,
        [Description("Store credit card.")]
        StoreCreditcard,
        [Description("Low-interest credit card")]
        LowIntrestCreditcard,
        [Description("Secured credit card")]
        SecuredCreditcard
    }
}
