using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QingYuan.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CodeAttribute(int code) : Attribute
    {
        public int Code { get; } = code;

        public bool HasAuthority(int code) => code == Code;
    }
}
