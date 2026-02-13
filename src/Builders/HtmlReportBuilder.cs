using System;

namespace DesignPatternChallenge.Builders
{
    /// <summary>
    /// Builder especializado para relatórios em HTML
    /// </summary>
    public class HtmlReportBuilder : SalesReportBuilderBase<HtmlReportBuilder>
    {
        public HtmlReportBuilder()
        {
            SetFormat("HTML");
        }

        public HtmlReportBuilder WithResponsiveDesign()
        {
            Console.WriteLine("[HTML] Design responsivo habilitado");
            return this;
        }

        public HtmlReportBuilder WithTheme(string themeName)
        {
            Console.WriteLine($"[HTML] Tema '{themeName}' aplicado");
            return this;
        }
    }
}
