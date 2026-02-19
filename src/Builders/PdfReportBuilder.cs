using System;

namespace DesignPatternChallenge.Builders
{
    /// <summary>
    /// Specialized builder for PDF reports
    /// </summary>
    public class PdfReportBuilder : SalesReportBuilderBase<PdfReportBuilder>
    {
        public PdfReportBuilder()
        {
            SetFormat("PDF");
            WithPageSettings("Portrait", "A4");
        }

        public PdfReportBuilder WithCompression()
        {
            Console.WriteLine("[PDF] Compression enabled");
            return this;
        }

        public PdfReportBuilder WithEncryption()
        {
            Console.WriteLine("[PDF] Encryption enabled");
            return this;
        }
    }
}
