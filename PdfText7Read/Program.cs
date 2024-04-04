using iText.Forms;
using iText.Forms.Fields;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using iText.Kernel.Pdf.Canvas.Parser;

var pdfDoc = new PdfDocument(new PdfReader("annotations_01.pdf"));
string searchText = "Tick Boxes (multiple options can be selected)";
for (int page = 1; page <= pdfDoc.GetNumberOfPages(); page++)
{
    ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
    String pageContent = PdfTextExtractor.GetTextFromPage(pdfDoc.GetPage(page), strategy);

    if (pageContent.Contains(searchText))
    {
        Console.WriteLine($"Text found on page {page}");
    }
}



var form = PdfAcroForm.GetAcroForm(pdfDoc, true);
var fields = form.GetAllFormFields();

foreach (var fieldName in fields.Keys)
{
    var field = fields[fieldName];
    Console.WriteLine(fieldName + ": " + field.GetValueAsString());
}

PdfFormField nameField = fields["Name"]; // Use the exact field name as defined in the PDF
PdfFormField addressField = fields["Address"]; // Use the exact field name as defined in the PDF
//PdfFormField dateField = fields["Date"]; // Use the exact field name as defined in the PDF

Console.WriteLine("Name: " + nameField.GetValueAsString());
Console.WriteLine("Address: " + addressField.GetValueAsString());
//Console.WriteLine("Date: " + dateField.GetValueAsString());
pdfDoc.Close();

Console.Read();