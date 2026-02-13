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
            Console.WriteLine("║  Sistema de Relatórios - Builder Pattern ║");
            Console.WriteLine("╚══════════════════════════════════════════╝\n");

            // ========== EXEMPLO 1: Builder Fluente Básico ==========
            Console.WriteLine(">>> EXEMPLO 1: Builder Fluente - Relatório Customizado");
            var report1 = new SalesReportBuilder()
                .SetTitle("Vendas Mensais - Janeiro 2024")
                .SetFormat("PDF")
                .SetDateRange(new DateTime(2024, 1, 1), new DateTime(2024, 1, 31))
                .WithHeader("Relatório de Vendas")
                .WithFooter("Confidencial")
                .WithCharts("Bar")
                .WithColumns("Produto", "Quantidade", "Valor")
                .WithFilters("Status=Ativo")
                .WithSorting("Valor")
                .WithGrouping("Categoria")
                .WithTotals()
                .WithPageSettings("Portrait", "A4")
                .WithPageNumbers()
                .WithBranding("logo.png", "Confidencial")
                .Build();

            report1.Generate();

            // ========== EXEMPLO 2: Director Pattern ==========
            Console.WriteLine("\n>>> EXEMPLO 2: Director - Relatório Mensal Pré-configurado");
            var director = new ReportDirector();
            var report2 = director.CreateMonthlyReport(
                "Relatório Mensal - Fevereiro 2024",
                new DateTime(2024, 2, 1)
            );
            report2.Generate();

            Console.WriteLine("\n>>> EXEMPLO 3: Director - Relatório Trimestral");
            var report3 = director.CreateQuarterlyReport(
                "Relatório Q1 2024",
                2024,
                1
            );
            report3.Generate();

            // ========== EXEMPLO 4: Builders Especializados ==========
            Console.WriteLine("\n>>> EXEMPLO 4: Builder Especializado - PDF");
            var report4 = new PdfReportBuilder()
                .SetTitle("Relatório Anual 2024")
                .SetDateRange(new DateTime(2024, 1, 1), new DateTime(2024, 12, 31))
                .WithHeader("Relatório Anual")
                .WithColumns("Trimestre", "Vendas", "Lucro")
                .WithCharts("Line")
                .WithTotals()
                .WithCompression()
                .WithEncryption()
                .Build();
            report4.Generate();

            Console.WriteLine("\n>>> EXEMPLO 5: Builder Especializado - Excel");
            var report5 = new ExcelReportBuilder()
                .SetTitle("Análise de Vendedores")
                .SetDateRange(new DateTime(2024, 1, 1), new DateTime(2024, 3, 31))
                .WithColumns("Vendedor", "Meta", "Realizado", "Comissão")
                .WithFilters("Região=Sul", "Status=Ativo")
                .WithGrouping("Região")
                .WithAutoFilter()
                .WithMultipleSheets(3)
                .Build();
            report5.Generate();

            Console.WriteLine("\n>>> EXEMPLO 6: Builder Especializado - HTML");
            var report6 = new HtmlReportBuilder()
                .SetTitle("Dashboard Interativo")
                .SetDateRange(new DateTime(2024, 1, 1), new DateTime(2024, 12, 31))
                .WithCharts("Pie")
                .WithColumns("Produto", "Vendas", "Participação")
                .WithResponsiveDesign()
                .WithTheme("Dark")
                .Build();
            report6.Generate();

            // ========== EXEMPLO 7: Resumo Executivo ==========
            Console.WriteLine("\n>>> EXEMPLO 7: Director - Resumo Executivo");
            var report7 = director.CreateExecutiveSummary(
                "Executive Summary Q4 2024",
                new DateTime(2024, 10, 1),
                new DateTime(2024, 12, 31)
            );
            report7.Generate();

            Console.WriteLine("\n╔═══════════════════════════════════════════════╗");
            Console.WriteLine("║  ✓ Todos os relatórios gerados com sucesso!  ║");
            Console.WriteLine("╚═══════════════════════════════════════════════╝");
        }
    }
}
