using QingYuan.Attributes.Enums;
using QingYuan.Extensions;
using System.Runtime.InteropServices;

namespace QingYuan.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ControllerAffixAttribute : Attribute
    {
        public ControllerAffixAttribute([Optional] string? prefix, [Optional] string? suffix, EnumControllerAffixEffect effect)
        {
            if (prefix.IsNullOrWhiteSpace() && suffix.IsNullOrWhiteSpace())
            {
                throw new ArgumentNullException(nameof(prefix), $"{nameof(ControllerAffixAttribute)}属性需要 prefix 或 suffix 任意一个有值。");
            }
            Prefix = prefix;
            Suffix = suffix;
            Effect = effect;
        }

        public string? Prefix { get; set; }

        public string? Suffix { get; set; }

        public EnumControllerAffixEffect Effect { get; set; }
    }
}
