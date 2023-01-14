using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class KBSModel
    {
        public int Id { get; set; }
        public string? Status { get; set; }
        public string? Cooler { get; set; }
        public string? Action { get; set; }
        public string? UsageCpu { get; set; }
        public string? StatusMonitor { get; set; }
        public string? LastClean { get; set; }
        public string? SignalSata { get; set; }
        public string? Bios { get; set; }
        public string? BuildPc { get; set; }
        public string? Sound { get; set; }
        public int IdTreatment { get; set; }
    }
}
