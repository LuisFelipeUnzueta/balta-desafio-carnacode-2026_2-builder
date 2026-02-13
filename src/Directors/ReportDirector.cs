using System;
using DesignPatternChallenge.Models;
using DesignPatternChallenge.Builders;

namespace DesignPatternChallenge.Directors
{
    /// <summary>
    /// Director: Encapsula lógica de construção para relatórios comuns
    /// </summary>
    public class ReportDirector
    {
        /// <summary>
        /// Cria um relatório mensal padrão
        /// </summary>
        public SalesReport CreateMonthlyReport(string title, DateTime month)
        {
            var startDate = new DateTime(month.Year, month.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);

            return new SalesReportBuilder()
                .SetTitle(title)
                .SetFormat("PDF")
                .SetDateRange(startDate, endDate)
                .WithHeader("Relatório Mensal de Vendas")
                .WithFooter("Documento Confidencial")
                .WithColumns("Produto", "Quantidade", "Valor")
                .WithCharts("Bar")
                .WithTotals()
                .WithPageSettings("Portrait", "A4")
                .WithPageNumbers()
                .Build();
        }

        /// <summary>
        /// Cria um relatório trimestral padrão
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
                .WithHeader("Relatório Trimestral")
                .WithColumns("Vendedor", "Região", "Total")
                .WithCharts("Line")
                .WithGrouping("Região")
                .WithTotals()
                .Build();
        }

        /// <summary>
        /// Cria um relatório anual padrão
        /// </summary>
        public SalesReport CreateAnnualReport(string title, int year)
        {
            var startDate = new DateTime(year, 1, 1);
            var endDate = new DateTime(year, 12, 31);

            return new PdfReportBuilder()
                .SetTitle(title)
                .SetDateRange(startDate, endDate)
                .WithHeader("Relatório Anual de Vendas")
                .WithFooter($"© {year} - Todos os direitos reservados")
                .WithColumns("Mês", "Vendas", "Crescimento")
                .WithCharts("Pie")
                .WithSummary()
                .WithTotals()
                .WithPageSettings("Landscape", "A4")
                .WithPageNumbers()
                .WithBranding("logo.png", "Confidencial")
                .Build();
        }

        /// <summary>
        /// Cria um resumo executivo
        /// </summary>
        public SalesReport CreateExecutiveSummary(string title, DateTime startDate, DateTime endDate)
        {
            return new PdfReportBuilder()
                .SetTitle(title)
                .SetDateRange(startDate, endDate)
                .WithHeader("Resumo Executivo")
                .WithColumns("Indicador", "Valor", "Meta")
                .WithCharts("Bar")
                .WithSummary()
                .WithPageSettings("Portrait", "A4")
                .WithBranding("logo.png", "Confidencial")
                .Build();
        }
    }
}
