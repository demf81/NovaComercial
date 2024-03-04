using System;
using System.IO;
using System.Web.Mvc;


namespace SACC.Client.Controllers
{
    public class PdfController : Controller
    {
        private MemoryStream HtmlToPdf(string htmlText)
        {
            MemoryStream workStream = new MemoryStream();
            try
            {
                var htmlCompleto = string.Empty;
                htmlCompleto = string.Format("{0}", htmlText);

                //ConverterProperties properties = new ConverterProperties();
                //FontProvider dfp = new DefaultFontProvider(true, false, false);

                //properties.SetFontProvider(dfp);

                //var x = Path.Combine(_hostingEnvironment.WebRootPath);
                //properties.SetBaseUri(x);

                //using (var pdfWriter = new PdfWriter(workStream))
                //{
                //    MediaDeviceDescription mediaDeviceDescription = new MediaDeviceDescription(MediaType.PRINT);
                //    mediaDeviceDescription.SetWidth(iText.Kernel.Geom.PageSize.LETTER.Rotate().GetWidth());
                //    mediaDeviceDescription.SetHeight(iText.Kernel.Geom.PageSize.LETTER.Rotate().GetHeight());
                //    properties.SetMediaDeviceDescription(mediaDeviceDescription);

                //    pdfWriter.SetCloseStream(false);

                //    var document = HtmlConverter.ConvertToDocument(htmlCompleto, pdfWriter, properties);

                //    pdfWriter.Close();
                //    //document.Close();

                //}

                workStream.Position = 0;
                System.GC.Collect();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return workStream;
        }
    }
}