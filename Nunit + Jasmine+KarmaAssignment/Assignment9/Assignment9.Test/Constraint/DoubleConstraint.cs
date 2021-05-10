using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework.Constraints;
namespace Assignment9.Test
{

    /// <summary>
    /// Generic way of extending by using the inherent constraints
    /// </summary>
    public class DoubleConstraint : Constraint
    {
        private const double DefaultPrecision = 0.0001;
        public DoubleConstraint(double expected) : base(expected)
        {
        }

        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            return NUnit.Framework.Is.EqualTo(Arguments[0])
                  .Within(DefaultPrecision).ApplyTo(actual);
        }
        /// <summary>
        /// Option 2, which matches this case and similar
        /// </summary>
        public class DoubleVerification2 : EqualConstraint
        {
            private const double DefaultPrecision = 0.0001;
            public DoubleVerification2(double expected) : base(expected)
            {
                Within(DefaultPrecision);
            }
        }

    }
}