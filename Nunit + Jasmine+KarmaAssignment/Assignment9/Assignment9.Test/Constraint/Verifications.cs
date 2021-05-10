using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment9.Test
{
    /// <summary>
    /// This allows for chaining
    /// </summary>
    public static class Verifications
    {
        public static DoubleConstraint Approx(this ConstraintExpression expression, double expected)
        {
            var constraint = new DoubleConstraint(expected);
            expression.Append(constraint);
            return constraint;
        }
    }
}
