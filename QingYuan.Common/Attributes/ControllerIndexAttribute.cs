using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QingYuan.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ControllerIndexAttribute(int index) : Attribute
    {
        public bool HasAuthority(int order)
        {
            return order == index;
        }
    }
}
