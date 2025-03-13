using Microsoft.AspNetCore.Mvc.ApplicationModels;
using QingYuan.Attributes;
using QingYuan.Attributes.Enums;
using System.Reflection;

namespace QingYuan.Gateway.ModelConvention
{
    public class ControllerAffixAttributeConvention(string placeholder = "[controller]") : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                var controllerName = controller.ControllerName.Replace("Controller", "");
                if (controller == null)
                {
                    continue;
                }
                if (controller.ControllerType.IsDefined(typeof(ControllerPrefixAttribute), true))
                {
                    var attribute = controller.ControllerType.GetCustomAttribute<ControllerPrefixAttribute>(true)!;
                    controllerName = PrependPrefix(controllerName, attribute);
                }
                if (controller.ControllerType.IsDefined(typeof(ControllerSuffixAttribute), true))
                {
                    var attribute = controller.ControllerType.GetCustomAttribute<ControllerSuffixAttribute>(true)!;
                    controllerName = AppendSuffix(controllerName, attribute);
                }
                controller.ControllerName = controllerName;
                foreach (var selector in controller.Selectors)
                {
                    selector.AttributeRouteModel!.Template = selector.AttributeRouteModel!.Template!.Replace(placeholder, controllerName);
                }
            }

            #region normalize controller name
            static string PrependPrefix(string controllerName, ControllerPrefixAttribute attribute)
            {
                switch (attribute.Effect)
                {
                    case EnumControllerAffixEffect.Add:
                        if (attribute.Prefix != null)
                        {
                            controllerName = attribute.Prefix + controllerName;
                        }
                        break;
                    case EnumControllerAffixEffect.Remove:
                        if (attribute.Prefix != null && controllerName.StartsWith(attribute.Prefix))
                        {
                            controllerName = controllerName[attribute.Prefix.Length..];
                        }
                        break;
                    default:
                        throw new ArgumentNullException(nameof(controllerName), $"{controllerName}标记了{nameof(ControllerPrefixAttribute)}但未指定到底是添加还是删除，请于第二个参数指定");
                }
                return controllerName;
            }
            #endregion


            #region normalize controller name
            static string AppendSuffix(string controllerName, ControllerSuffixAttribute attribute)
            {
                switch (attribute.Effect)
                {
                    case EnumControllerAffixEffect.Add:
                        if (attribute.Suffix != null)
                        {
                            controllerName += attribute.Suffix;
                        }
                        break;
                    case EnumControllerAffixEffect.Remove:
                        if (attribute.Suffix != null && controllerName.EndsWith(attribute.Suffix))
                        {
                            controllerName = controllerName[attribute.Suffix.Length..];
                        }
                        break;
                    default:
                        throw new ArgumentNullException(nameof(controllerName), $"{controllerName}标记了{nameof(ControllerSuffixAttribute)}但未指定到底是添加还是删除，请于第二个参数指定");
                }
                return controllerName;
            }
            #endregion

        }
    }
}
