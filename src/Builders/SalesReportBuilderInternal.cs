using System;
using System.Collections.Generic;

namespace DesignPatternChallenge.Builders
{
    /// <summary>
    /// Classe base não-genérica para conter o estado e permitir acesso pelo SalesReport
    /// </summary>
    public abstract class SalesReportBuilderInternal
    {
        // Estado interno do builder (todos nullable pois começam não inicializados)
        protected string? _title;
        protected string? _format;
        protected DateTime _startDate;
        protected DateTime _endDate;
        protected bool _includeHeader;
        protected bool _includeFooter;
        protected string? _headerText;
        protected string? _footerText;
        protected bool _includeCharts;
        protected string? _chartType;
        protected bool _includeSummary;
        protected List<string> _columns = new List<string>();
        protected List<string> _filters = new List<string>();
        protected string? _sortBy;
        protected string? _groupBy;
        protected bool _includeTotals;
        protected string _orientation = "Portrait";
        protected string _pageSize = "A4";
        protected bool _includePageNumbers;
        protected string? _companyLogo;
        protected string? _waterMark;

        // Propriedades internas para acesso pelo Product
        internal string? GetTitle() => _title;
        internal string? GetFormat() => _format;
        internal DateTime GetStartDate() => _startDate;
        internal DateTime GetEndDate() => _endDate;
        internal bool GetIncludeHeader() => _includeHeader;
        internal bool GetIncludeFooter() => _includeFooter;
        internal string? GetHeaderText() => _headerText;
        internal string? GetFooterText() => _footerText;
        internal bool GetIncludeCharts() => _includeCharts;
        internal string? GetChartType() => _chartType;
        internal bool GetIncludeSummary() => _includeSummary;
        internal List<string> GetColumns() => _columns;
        internal List<string> GetFilters() => _filters;
        internal string? GetSortBy() => _sortBy;
        internal string? GetGroupBy() => _groupBy;
        internal bool GetIncludeTotals() => _includeTotals;
        internal string GetOrientation() => _orientation;
        internal string GetPageSize() => _pageSize;
        internal bool GetIncludePageNumbers() => _includePageNumbers;
        internal string? GetCompanyLogo() => _companyLogo;
        internal string? GetWaterMark() => _waterMark;
    }
}
