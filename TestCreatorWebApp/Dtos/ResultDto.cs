using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestCreatorWebApp.Db.Models;

namespace TestCreatorWebApp.Dtos
{
    public class ResultDto
    {
        public Quiz Quiz { get; set; }
        public string Text { get; set; }
        public int? MinValue { get; set; }
        public int? MaxValue { get; set; }
        public string Notes { get; set; }
        [DefaultValue(0)]
        public int Type { get; set; }
        [DefaultValue(0)]
        public int Flags { get; set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
