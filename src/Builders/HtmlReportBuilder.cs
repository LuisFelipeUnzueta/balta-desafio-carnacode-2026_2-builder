using System;

namespace DesignPatternChallenge.Builders
{
    /// <summary>
    /// Specialized builder for HTML reports
    /// </summary>
    public class HtmlReportBuilder : SalesReportBuilderBase<HtmlReportBuilder>
    {
        public HtmlReportBuilder()
        {
            SetFormat("HTML");
        }

        public HtmlReportBuilder WithResponsiveDesign()
        {
            Console.WriteLine("[HTML] Responsive design enabled");
            return this;
        }

        public HtmlReportBuilder WithTheme(string themeName)
        {
            Console.WriteLine($"[HTML] Theme '{themeName}' applied");
            return this;
        }
    }
}
