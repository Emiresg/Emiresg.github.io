using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemYonetimi.Models
{
    public class Log
    {
        [Key]
        public int LogID { get; set; }
        public string UserIP { get; set; }
        public DateTime UserLoginTime { get; set; }
    }
}
