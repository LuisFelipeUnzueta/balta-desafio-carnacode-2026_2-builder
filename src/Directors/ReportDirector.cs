using System;
using DesignPatternChallenge.Models;
using DesignPatternChallenge.Builders;

namespace DesignPatternChallenge.Directors
{
    /// <summary>
    /// Director: Encapsulates construction logic for common reports
    /// </summary>
    public class ReportDirector
    {
        /// <summary>
        /// Creates a standard monthly report
        /// </summary>
        public SalesReport CreateMonthlyReport(string title, DateTime month)
        {
            var startDate = new DateTime(month.Year, month.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            return new SalesReportBuilder()
                .SetTitle(title)
                .SetFormat("PDF")
                .SetDateRange(startDate, endDate)
                .WithHeader("Monthly Sales Report")
                .WithFooter("Confidential Document")
                .WithColumns("Product", "Quantity", "Value")
                .WithCharts("Bar")
                .WithTotals()
                .WithPageSettings("Portrait", "A4")
                .WithPageNumbers()
                .Build();
        }

        /// <summary>
        /// Creates a standard quarterly report
        /// </summary>
        public SalesReport CreateQuarterlyReport(string title, int year, int quarter)
        {
            var startMonth = (quarter - 1) * 3 + 1;
            var startDate = new DateTime(year, startMonth, 1);
            var endDate = startDate.AddMonths(3).AddDays(-1);

            return new SalesReportBuilder()
                .SetTitle(title)
                .SetFormat("Excel")
                .SetDateRange(startDate, endDate)
                .WithHeader("Quarterly Report")
                .WithColumns("Salesperson", "Region", "Total")
                .WithCharts("Line")
                .WithGrouping("Região")
                .WithTotals()
                .Build();
        }

        /// <summary>
        /// Creates a standard annual report
        /// </summary>
        public SalesReport CreateAnnualReport(string title, int year)
        {
            var startDate = new DateTime(year, 1, 1);
            var endDate = new DateTime(year, 12, 31);

            return new PdfReportBuilder()
                .SetTitle(title)
                .SetDateRange(startDate, endDate)
                .WithHeader("Annual Sales Report")
                .WithFooter($"© {year} - All rights reserved")
                .WithColumns("Month", "Sales", "Growth")
                .WithCharts("Pie")
                .WithSummary()
                .WithTotals()
                .WithPageSettings("Landscape", "A4")
                .WithPageNumbers()
                .WithBranding("logo.png", "Confidential")
                .Build();
        }

        /// <summary>
        /// Creates an executive summary
        /// </summary>
        public SalesReport CreateExecutiveSummary(string title, DateTime startDate, DateTime endDate)
        {
            return new PdfReportBuilder()
                .SetTitle(title)
                .SetDateRange(startDate, endDate)
                .WithHeader("Executive Summary")
                .WithColumns("Indicator", "Value", "Target")
                .WithCharts("Bar")
                .WithSummary()
                .WithPageSettings("Portrait", "A4")
                .WithBranding("logo.png", "Confidential")
                .Build();
        }
    }
}
