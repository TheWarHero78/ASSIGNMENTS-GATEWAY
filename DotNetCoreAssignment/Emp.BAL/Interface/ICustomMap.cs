using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emp.BAL.Interface
{
    public interface ICustomMap
    {
        void CustomMap(IMapperConfigurationExpression configuration);
    }
}
