using System;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Builders
{
    /// <summary>
    /// Interface Builder com padrão Fluent para construção de relatórios
    /// </summary>
    public interface IReportBuilder
    {
        // Configurações obrigatórias
        IReportBuilder SetTitle(string title);
        IReportBuilder SetFormat(string format);
        IReportBuilder SetDateRange(DateTime startDate, DateTime endDate);
        
        // Configurações opcionais
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
        
        // Método de construção final
        SalesReport Build();
    }
}
