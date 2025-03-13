using Microsoft.AspNetCore.Mvc.ApplicationModels;
using QingYuan.Attributes;
using QingYuan.Attributes.Enums;
using System.Reflection;

namespace QingYuan.Gateway.ModelConvention
{
    public class ControllerAffixAttributeConvention : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                if (controller == null)
                {
                    continue;
                }
                if (!controller.ControllerType.IsDefined(typeof(ControllerAffixAttribute), true))
                {
                    continue;
                }
                var controllerName = NormalizeControllerName(controller);
                controller.ControllerName = controllerName;
                foreach (var selector in controller.Selectors)
                {
                    selector.AttributeRouteModel!.Template = selector.AttributeRouteModel!.Template!.Replace("[controller]", controllerName);
                }
            }

            #region normalize controller name
            static string NormalizeControllerName(ControllerModel controller)
            {
                var attribute = controller.ControllerType.GetCustomAttribute<ControllerAffixAttribute>(true)!;
                var controllerName = controller.ControllerName.Replace("Controller", "");
                switch (attribute.Effect)
                {
                    case EnumControllerAffixEffect.Add:
                        if (attribute.Prefix != null)
                        {
                            controllerName = attribute.Prefix + controllerName;
                        }
                        if (attribute.Suffix != null)
                        {
                            controllerName += attribute.Suffix;
                        }
                        break;
                    case EnumControllerAffixEffect.Remove:
                        if (attribute.Prefix != null && controllerName.StartsWith(attribute.Prefix))
                        {
                            controllerName = controllerName[attribute.Prefix.Length..];
                        }
                        if (attribute.Suffix != null && controllerName.EndsWith(attribute.Suffix))
                        {
                            controllerName = controllerName[attribute.Suffix.Length..];
                        }
                        break;
                    default:
                        throw new ArgumentNullException(nameof(application), $"{controllerName}标记了{nameof(ControllerAffixAttribute)}但未指定到底是添加还是删除，请于第三个参数指定");
                }
                return controllerName;
            }
            #endregion

        }
    }
}
