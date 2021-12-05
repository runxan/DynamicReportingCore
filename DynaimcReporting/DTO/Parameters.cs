using DynaimcReporting.ENUM;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynaimcReporting.DTO
{
    public class ParametersDTO
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string DisplayName { get; set; }
        public string Query { get; set; }
        public ParameterDataType ParameterDataType { get; set; }
        public int ReportMasterId { get; set; }
        public string QueryOfMasterReport { get; set; }
        public string SearchValue { get; set; }
        public SelectList DDL { get; set; }
    }
}
