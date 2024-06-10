using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Entities.Models
{
    public class ProjectSetting
    {
        public int ProjectId { get; set; }
        public int SettingId { get; set; }
        public virtual Project Project { get; set; }
        public virtual Setting Setting { get; set; }
    }


}
