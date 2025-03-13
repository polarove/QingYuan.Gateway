using QingYuan.Attributes.Enums;

namespace QingYuan.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ControllerPrefixAttribute(string prefix, EnumControllerAffixEffect effect = EnumControllerAffixEffect.Add) : Attribute
    {
        public string Prefix { get; set; } = prefix;

        public EnumControllerAffixEffect Effect { get; set; } = effect;
    }
}
