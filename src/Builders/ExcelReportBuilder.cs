using System;

namespace DesignPatternChallenge.Builders
{
    /// <summary>
    /// Builder especializado para relatórios em Excel
    /// </summary>
    public class ExcelReportBuilder : SalesReportBuilderBase<ExcelReportBuilder>
    {
        public ExcelReportBuilder()
        {
            SetFormat("Excel");
        }

        public ExcelReportBuilder WithAutoFilter()
        {
            Console.WriteLine("[Excel] Auto-filtro habilitado");
            return this;
        }

        public ExcelReportBuilder WithMultipleSheets(int sheetCount)
        {
            Console.WriteLine($"[Excel] {sheetCount} planilhas configuradas");
            return this;
        }
    }
}
