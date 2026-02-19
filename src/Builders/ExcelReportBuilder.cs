using System;

namespace DesignPatternChallenge.Builders
{
    /// <summary>
    /// Specialized builder for Excel reports
    /// </summary>
    public class ExcelReportBuilder : SalesReportBuilderBase<ExcelReportBuilder>
    {
        public ExcelReportBuilder()
        {
            SetFormat("Excel");
        }

        public ExcelReportBuilder WithAutoFilter()
        {
            Console.WriteLine("[Excel] Auto-filter enabled");
            return this;
        }

        public ExcelReportBuilder WithMultipleSheets(int sheetCount)
        {
            Console.WriteLine($"[Excel] {sheetCount} sheets configured");
            return this;
        }
    }
}
