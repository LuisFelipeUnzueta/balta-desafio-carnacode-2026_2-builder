using System;

namespace DesignPatternChallenge.Builders
{
    /// <summary>
    /// Builder especializado para relatórios em PDF
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
            Console.WriteLine("[PDF] Compressão habilitada");
            return this;
        }

        public PdfReportBuilder WithEncryption()
        {
            Console.WriteLine("[PDF] Criptografia habilitada");
            return this;
        }
    }
}
