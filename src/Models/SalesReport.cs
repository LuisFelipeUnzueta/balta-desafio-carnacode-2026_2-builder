using System;
using System.Collections.Generic;
using DesignPatternChallenge.Builders;

namespace DesignPatternChallenge.Models
{
    /// <summary>
    /// Produto final: Relatório de vendas com configurações imutáveis
    /// </summary>
    public class SalesReport
    {
        // Propriedades somente leitura (imutabilidade)
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

        // Construtor interno - só pode ser chamado pelo Builder
        internal SalesReport(SalesReportBuilderInternal builder)
        {
            // Validações de campos obrigatórios
            if (string.IsNullOrWhiteSpace(builder.GetTitle()))
                throw new InvalidOperationException("Título é obrigatório");
            
            if (string.IsNullOrWhiteSpace(builder.GetFormat()))
                throw new InvalidOperationException("Formato é obrigatório");
            
            if (builder.GetStartDate() == default)
                throw new InvalidOperationException("Data inicial é obrigatória");
            
            if (builder.GetEndDate() == default)
                throw new InvalidOperationException("Data final é obrigatória");
            
            if (builder.GetStartDate() > builder.GetEndDate())
                throw new InvalidOperationException("Data inicial não pode ser maior que data final");

            // Atribuição de valores
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
            Console.WriteLine($"\n=== Gerando Relatório: {Title} ===");
            Console.WriteLine($"Formato: {Format}");
            Console.WriteLine($"Período: {StartDate:dd/MM/yyyy} a {EndDate:dd/MM/yyyy}");
            
            if (IncludeHeader)
                Console.WriteLine($"Cabeçalho: {HeaderText}");
            
            if (IncludeCharts)
                Console.WriteLine($"Gráfico: {ChartType}");
            
            if (Columns.Count > 0)
                Console.WriteLine($"Colunas: {string.Join(", ", Columns)}");
            
            if (Filters.Count > 0)
                Console.WriteLine($"Filtros: {string.Join(", ", Filters)}");
            
            if (!string.IsNullOrEmpty(SortBy))
                Console.WriteLine($"Ordenado por: {SortBy}");
            
            if (!string.IsNullOrEmpty(GroupBy))
                Console.WriteLine($"Agrupado por: {GroupBy}");
            
            if (IncludeTotals)
                Console.WriteLine("Incluindo totais");
            
            if (!string.IsNullOrEmpty(Orientation))
                Console.WriteLine($"Orientação: {Orientation} ({PageSize})");
            
            if (IncludeFooter)
                Console.WriteLine($"Rodapé: {FooterText}");
            
            Console.WriteLine("✓ Relatório gerado com sucesso!");
        }
    }
}
