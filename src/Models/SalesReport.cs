using System;
using System.Collections.Generic;
using DesignPatternChallenge.Builders;

namespace DesignPatternChallenge.Models
{
    /// <summary>
    /// Final product: Sales report with immutable configurations
    /// </summary>
    public class SalesReport
    {
        // Properties only read (immutability)
        public string Title { get; }
        public string Format { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public bool IncludeHeader { get; }
        public bool IncludeFooter { get; }
        public string HeaderText { get; }
        public string FooterText { get; }
        public bool IncludeCharts { get; }
        public string ChartType { get; }
        public bool IncludeSummary { get; }
        public IReadOnlyList<string> Columns { get; }
        public IReadOnlyList<string> Filters { get; }
        public string SortBy { get; }
        public string GroupBy { get; }
        public bool IncludeTotals { get; }
        public string Orientation { get; }
        public string PageSize { get; }
        public bool IncludePageNumbers { get; }
        public string CompanyLogo { get; }
        public string WaterMark { get; }

        // Internal constructor - can only be called by the Builder
        internal SalesReport(SalesReportBuilderInternal builder)
        {
            // Mandatory field validations
            if (string.IsNullOrWhiteSpace(builder.GetTitle()))
                throw new InvalidOperationException("Title is required");

            if (string.IsNullOrWhiteSpace(builder.GetFormat()))
                throw new InvalidOperationException("Format is required");

            if (builder.GetStartDate() == default)
                throw new InvalidOperationException("Start date is required");

            if (builder.GetEndDate() == default)
                throw new InvalidOperationException("End date is required");

            if (builder.GetStartDate() > builder.GetEndDate())
                throw new InvalidOperationException("Start date cannot be greater than end date");

            // Assignment of values
            Title = builder.GetTitle()!;
            Format = builder.GetFormat()!;
            StartDate = builder.GetStartDate();
            EndDate = builder.GetEndDate();
            IncludeHeader = builder.GetIncludeHeader();
            IncludeFooter = builder.GetIncludeFooter();
            HeaderText = builder.GetHeaderText() ?? string.Empty;
            FooterText = builder.GetFooterText() ?? string.Empty;
            IncludeCharts = builder.GetIncludeCharts();
            ChartType = builder.GetChartType() ?? string.Empty;
            IncludeSummary = builder.GetIncludeSummary();
            Columns = builder.GetColumns().AsReadOnly();
            Filters = builder.GetFilters().AsReadOnly();
            SortBy = builder.GetSortBy() ?? string.Empty;
            GroupBy = builder.GetGroupBy() ?? string.Empty;
            IncludeTotals = builder.GetIncludeTotals();
            Orientation = builder.GetOrientation();
            PageSize = builder.GetPageSize();
            IncludePageNumbers = builder.GetIncludePageNumbers();
            CompanyLogo = builder.GetCompanyLogo() ?? string.Empty;
            WaterMark = builder.GetWaterMark() ?? string.Empty;
        }

        public void Generate()
        {
            Console.WriteLine($"\n=== Generating Report: {Title} ===");
            Console.WriteLine($"Format: {Format}");
            Console.WriteLine($"Period: {StartDate:dd/MM/yyyy} to {EndDate:dd/MM/yyyy}");

            if (IncludeHeader)
                Console.WriteLine($"Header: {HeaderText}");

            if (IncludeCharts)
                Console.WriteLine($"Chart: {ChartType}");

            if (Columns.Count > 0)
                Console.WriteLine($"Columns: {string.Join(", ", Columns)}");

            if (Filters.Count > 0)
                Console.WriteLine($"Filters: {string.Join(", ", Filters)}");

            if (!string.IsNullOrEmpty(SortBy))
                Console.WriteLine($"Order by: {SortBy}");

            if (!string.IsNullOrEmpty(GroupBy))
                Console.WriteLine($"Grouped by: {GroupBy}");

            if (IncludeTotals)
                Console.WriteLine("Including totals");

            if (!string.IsNullOrEmpty(Orientation))
                Console.WriteLine($"Orientation: {Orientation} ({PageSize})");

            if (IncludeFooter)
                Console.WriteLine($"Footer: {FooterText}");

            Console.WriteLine("✓ Report generated successfully!");
        }
    }
}
