using QingYuan.Attributes.Enums;

namespace QingYuan.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ControllerSuffixAttribute(string suffix, EnumControllerAffixEffect effect = EnumControllerAffixEffect.Add) : Attribute
    {
        public string Suffix { get; set; } = suffix;

        public EnumControllerAffixEffect Effect { get; set; } = effect;
    }
}
