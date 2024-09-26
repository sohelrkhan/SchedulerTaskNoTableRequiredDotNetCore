using Microsoft.Extensions.Hosting;

namespace SchedulerTask.Models
{
    public class ExcelDataModel
    {
        public string? PARENTPART { get; set; }
        public string? PARENTDESCRIPTION { get; set; }
        public string? COMPONENT { get; set; }
        public string? COMPONENTDESCRIPTION { get; set; }
        public string? USAGE { get; set; }
        public string? UNITCOSTUSD { get; set; }
        public string? PARENTUNITOFMEASURE { get; set; }
        public string? COMPONENTUNITOFMEASURE { get; set; }
        public string? COUNTRYOFORIGIN { get; set; }
        public string? HTSUSCODE { get; set; }
        public string? DIVISION { get; set; }
        public string? IMPORTPARENT { get; set; }
        public string? TOPPART { get; set; }
        public string? LABORHOURS { get; set; }
        public string? PARENTSTOCKCODE { get; set; }
        public string? COMPONENTSTOCKCODE { get; set; }
        public string? PARENTFACILITY { get; set; }
        public string? COMPONENTFACILITY { get; set; }
        public string? PHANTOM { get; set; }
        public string? PARENTBUYER { get; set; }
        public string? COMPONENTBUYER { get; set; }
    }
}
