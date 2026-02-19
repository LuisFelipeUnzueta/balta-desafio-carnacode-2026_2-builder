using System;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Builders
{
    /// <summary>
    /// Builder interface with Fluent pattern for report construction
    /// </summary>
    public interface IReportBuilder
    {
        // Mandatory configurations
        IReportBuilder SetTitle(string title);
        IReportBuilder SetFormat(string format);
        IReportBuilder SetDateRange(DateTime startDate, DateTime endDate);

        // Optional configurations
        IReportBuilder WithHeader(string headerText);
        IReportBuilder WithFooter(string footerText);
        IReportBuilder WithCharts(string chartType);
        IReportBuilder WithSummary();
        IReportBuilder WithColumns(params string[] columns);
        IReportBuilder WithFilters(params string[] filters);
        IReportBuilder WithSorting(string sortBy);
        IReportBuilder WithGrouping(string groupBy);
        IReportBuilder WithTotals();
        IReportBuilder WithPageSettings(string orientation, string pageSize);
        IReportBuilder WithPageNumbers();
        IReportBuilder WithBranding(string companyLogo, string waterMark);

        // Final build method
        SalesReport Build();
    }
}
