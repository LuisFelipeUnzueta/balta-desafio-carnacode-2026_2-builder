using System;
using DesignPatternChallenge.Models;
using DesignPatternChallenge.Builders;
using DesignPatternChallenge.Directors;

namespace DesignPatternChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║   Report System - Builder Pattern        ║");
            Console.WriteLine("╚══════════════════════════════════════════╝\n");

            // ========== EXAMPLE 1: Basic Fluent Builder ==========
            Console.WriteLine(">>> EXAMPLE 1: Fluent Builder - Customized Report");
            var report1 = new SalesReportBuilder()
                .SetTitle("Monthly Sales - January 2024")
                .SetFormat("PDF")
                .SetDateRange(new DateTime(2024, 1, 1), new DateTime(2024, 1, 31))
                .WithHeader("Sales Report")
                .WithFooter("Confidential")
                .WithCharts("Bar")
                .WithColumns("Product", "Quantity", "Value")
                .WithFilters("Status=Active")
                .WithSorting("Value")
                .WithGrouping("Category")
                .WithTotals()
                .WithPageSettings("Portrait", "A4")
                .WithPageNumbers()
                .WithBranding("logo.png", "Confidential")
                .Build();

            report1.Generate();

            // ========== EXAMPLE 2: Director Pattern ==========
            Console.WriteLine("\n>>> EXAMPLE 2: Director - Pre-configured Monthly Report");
            var director = new ReportDirector();
            var report2 = director.CreateMonthlyReport(
                "Monthly Report - February 2024",
                new DateTime(2024, 2, 1)
            );
            report2.Generate();

            Console.WriteLine("\n>>> EXAMPLE 3: Director - Quarterly Report");
            var report3 = director.CreateQuarterlyReport(
                "Q1 2024 Report",
                2024,
                1
            );
            report3.Generate();

            // ========== EXAMPLE 4: Specialized Builders ==========
            Console.WriteLine("\n>>> EXAMPLE 4: Specialized Builder - PDF");
            var report4 = new PdfReportBuilder()
                .SetTitle("Annual Report 2024")
                .SetDateRange(new DateTime(2024, 1, 1), new DateTime(2024, 12, 31))
                .WithHeader("Annual Report")
                .WithColumns("Quarter", "Sales", "Profit")
                .WithCharts("Line")
                .WithTotals()
                .WithCompression()
                .WithEncryption()
                .Build();
            report4.Generate();

            Console.WriteLine("\n>>> EXAMPLE 5: Specialized Builder - Excel");
            var report5 = new ExcelReportBuilder()
                .SetTitle("Salesperson Analysis")
                .SetDateRange(new DateTime(2024, 1, 1), new DateTime(2024, 3, 31))
                .WithColumns("Salesperson", "Target", "Achieved", "Commission")
                .WithFilters("Region=South", "Status=Active")
                .WithGrouping("Region")
                .WithAutoFilter()
                .WithMultipleSheets(3)
                .Build();
            report5.Generate();

            Console.WriteLine("\n>>> EXAMPLE 6: Specialized Builder - HTML");
            var report6 = new HtmlReportBuilder()
                .SetTitle("Interactive Dashboard")
                .SetDateRange(new DateTime(2024, 1, 1), new DateTime(2024, 12, 31))
                .WithCharts("Pie")
                .WithColumns("Product", "Sales", "Share")
                .WithResponsiveDesign()
                .WithTheme("Dark")
                .Build();
            report6.Generate();

            // ========== EXAMPLE 7: Executive Summary ==========
            Console.WriteLine("\n>>> EXAMPLE 7: Director - Executive Summary");
            var report7 = director.CreateExecutiveSummary(
                "Executive Summary Q4 2024",
                new DateTime(2024, 10, 1),
                new DateTime(2024, 12, 31)
            );
            report7.Generate();

            Console.WriteLine("\n╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║  ✓ All reports generated successfully!        ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝");
        }
    }
}
