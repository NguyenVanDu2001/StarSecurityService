using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarSecurityService.Application.Commons.Dto
{
    public class ComboboxCommonDto
    {
        public string Lable { get; set; }
        public int Value { get; set; }
        public bool Selected { get; set; } = false;

    }
}
