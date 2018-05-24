using System;
using System.Collections.Generic;

namespace AeroGear.Mobile.Security
{
    /// <summary>
    /// Factory for iOS security checks.
    /// </summary>
    internal class IOSSecurityCheckFactory : ISecurityCheckFactory
    {
        private Dictionary<string, Type> types = new Dictionary<string, Type>();

        /// <summary>
        /// Create the security check identified by the passed in security check type.
        /// </summary>
        /// <returns>The security check.</returns>
        /// <param name="type">The type of the security check to be instantiated.</param>
        public ISecurityCheck create(ISecurityCheckType type)
        {
            SecurityChecks checkType = type as SecurityChecks;

            if (checkType == null) {
                throw new Exception("Passed in security check type is not supported");
            }

            return Activator.CreateInstance(checkType.CheckType) as ISecurityCheck;
        }

        public ISecurityCheck create(string typeName)
        {
            Type checkType = types[typeName];

            if (checkType == null)
            {
                throw new Exception("Passed in security check type is not supported");
            }

            return Activator.CreateInstance(checkType) as ISecurityCheck;
        }

        public void Register(string name, Type checkType)
        {
            types[name] = checkType;
        }
    }
}
