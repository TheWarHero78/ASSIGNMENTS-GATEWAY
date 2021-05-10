using System;
using System.Collections.Generic;
using System.Text;
using static Assignment9.Test.DoubleConstraint;

namespace Assignment9.Test
{
    public class Is : NUnit.Framework.Is
    {
        public static DoubleConstraint Approx(double expected)
        {
            return new DoubleConstraint(expected);
        }

        public static DoubleVerification2 Approx2(double expected)
        {
            return new DoubleVerification2(expected);
        }
    }
}
