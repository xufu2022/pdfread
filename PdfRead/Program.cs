// See https://aka.ms/new-console-template for more information
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;
using UglyToad.PdfPig;
using UglyToad.PdfPig.DocumentLayoutAnalysis.WordExtractor;

Console.WriteLine("Hello, World!");
string filePath = @"annotations_01.pdf";
string keyword = "Fillable Fields";

List<string> pagesWithKeyword = FindKeywordInPdf(filePath, keyword);


foreach (var page in pagesWithKeyword)
{
    Console.WriteLine(page);
}
static List<string> FindKeywordInPdf(string filePath, string keyword)
{
    List<string> pagesWithKeyword = new List<string>();

    using (PdfDocument document = PdfDocument.Open(filePath))
    {
        for (int i = 0; i < document.NumberOfPages; i++)
        {
            var page = document.GetPage(i + 1);
            string pageText = string.Join(" ", page.GetWords().Select(w => w.Text));

            if (pageText.Contains(keyword))
            {
                pagesWithKeyword.Add($"Keyword found on page {i + 1}");
            }
        }
    }

    return pagesWithKeyword;
}