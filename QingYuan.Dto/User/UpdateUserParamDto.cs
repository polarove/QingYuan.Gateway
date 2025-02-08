using QingYuan.Dto.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QingYuan.Dto.User
{
    public class UpdateUserParamDto : BaseUpdateDto
    {
        public string? Name { get; set; }
    }
}
