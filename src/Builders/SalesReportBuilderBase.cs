using System;
using System.Collections.Generic;
using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Builders
{
    /// <summary>
    /// Base Builder usando Recursive Generics para manter o tipo concreto no encadeamento
    /// </summary>
    public abstract class SalesReportBuilderBase<T> : SalesReportBuilderInternal, IReportBuilder 
        where T : SalesReportBuilderBase<T>
    {
        // Implementação explícita da Interface para compatibilidade
        IReportBuilder IReportBuilder.SetTitle(string title) => SetTitle(title);
        IReportBuilder IReportBuilder.SetFormat(string format) => SetFormat(format);
        IReportBuilder IReportBuilder.SetDateRange(DateTime start, DateTime end) => SetDateRange(start, end);
        IReportBuilder IReportBuilder.WithHeader(string text) => WithHeader(text);
        IReportBuilder IReportBuilder.WithFooter(string text) => WithFooter(text);
        IReportBuilder IReportBuilder.WithCharts(string type) => WithCharts(type);
        IReportBuilder IReportBuilder.WithSummary() => WithSummary();
        IReportBuilder IReportBuilder.WithColumns(params string[] cols) => WithColumns(cols);
        IReportBuilder IReportBuilder.WithFilters(params string[] filters) => WithFilters(filters);
        IReportBuilder IReportBuilder.WithSorting(string sort) => WithSorting(sort);
        IReportBuilder IReportBuilder.WithGrouping(string group) => WithGrouping(group);
        IReportBuilder IReportBuilder.WithTotals() => WithTotals();
        IReportBuilder IReportBuilder.WithPageSettings(string orient, string size) => WithPageSettings(orient, size);
        IReportBuilder IReportBuilder.WithPageNumbers() => WithPageNumbers();
        IReportBuilder IReportBuilder.WithBranding(string logo, string mark) => WithBranding(logo, mark);

        // Métodos Tipados (Retornam T)
        public T SetTitle(string title)
        {
            _title = title;
            return (T)this;
        }

        public T SetFormat(string format)
        {
            _format = format;
            return (T)this;
        }

        public T SetDateRange(DateTime startDate, DateTime endDate)
        {
            _startDate = startDate;
            _endDate = endDate;
            return (T)this;
        }

        public T WithHeader(string headerText)
        {
            _includeHeader = true;
            _headerText = headerText;
            return (T)this;
        }

        public T WithFooter(string footerText)
        {
            _includeFooter = true;
            _footerText = footerText;
            return (T)this;
        }

        public T WithCharts(string chartType)
        {
            _includeCharts = true;
            _chartType = chartType;
            return (T)this;
        }

        public T WithSummary()
        {
            _includeSummary = true;
            return (T)this;
        }

        public T WithColumns(params string[] columns)
        {
            _columns.AddRange(columns);
            return (T)this;
        }

        public T WithFilters(params string[] filters)
        {
            _filters.AddRange(filters);
            return (T)this;
        }

        public T WithSorting(string sortBy)
        {
            _sortBy = sortBy;
            return (T)this;
        }

        public T WithGrouping(string groupBy)
        {
            _groupBy = groupBy;
            return (T)this;
        }

        public T WithTotals()
        {
            _includeTotals = true;
            return (T)this;
        }

        public T WithPageSettings(string orientation, string pageSize)
        {
            _orientation = orientation;
            _pageSize = pageSize;
            return (T)this;
        }

        public T WithPageNumbers()
        {
            _includePageNumbers = true;
            return (T)this;
        }

        public T WithBranding(string companyLogo, string waterMark)
        {
            _companyLogo = companyLogo;
            _waterMark = waterMark;
            return (T)this;
        }

        public SalesReport Build()
        {
            return new SalesReport(this); 
        }
    }
}
