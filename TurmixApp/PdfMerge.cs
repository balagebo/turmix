using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace TurmixLog
{
	public class PdfMerge
	{
		private BaseFont baseFont;
		private bool enablePagination = false;
		private readonly List<PdfReader> documents;
		private int totalPages;

		public BaseFont BaseFont
		{
			get { return baseFont; }
			set { baseFont = value; }
		}

		public bool EnablePagination
		{
			get { return enablePagination; }
			set
			{
				enablePagination = value;
				if (value && baseFont == null)
					baseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
			}
		}

		public List<PdfReader> Documents
		{
			get { return documents; }
		}

		public void AddDocument(string filename)
		{
			documents.Add(new PdfReader(filename));
		}
		public void AddDocument(Stream pdfStream)
		{
			documents.Add(new PdfReader(pdfStream));
		}
		public void AddDocument(byte[] pdfContents)
		{
			documents.Add(new PdfReader(pdfContents));
		}
		public void AddDocument(PdfReader pdfDocument)
		{
			documents.Add(pdfDocument);
		}

		public void Merge(string outputFilename)
		{
			Merge(new FileStream(outputFilename, FileMode.Create));
		}
		public void Merge(Stream outputStream)
		{
			if (outputStream == null || !outputStream.CanWrite)
				throw new Exception("OutputStream es nulo o no se puede escribir en éste.");

			Document newDocument = null;
			int rotation;

			try
			{
				newDocument = new Document();
				PdfWriter pdfWriter = PdfWriter.GetInstance(newDocument, outputStream);

				newDocument.Open();
				PdfContentByte pdfContentByte = pdfWriter.DirectContent;

				if (EnablePagination)
					documents.ForEach(delegate(PdfReader doc)
					{
						totalPages += doc.NumberOfPages;
					});

				int currentPage = 1;
				foreach (PdfReader pdfReader in documents)
				{

					for (int page = 1; page <= Math.Min(pdfReader.NumberOfPages, 2); page++)
					{
						newDocument.SetPageSize(pdfReader.GetPageSizeWithRotation(page));
						newDocument.NewPage();
						PdfImportedPage importedPage = pdfWriter.GetImportedPage(pdfReader, page);
						rotation = pdfReader.GetPageRotation(page);
						if (rotation == 90 || rotation == 270)
						{
							pdfContentByte.AddTemplate(importedPage, 0, -1f, 1f, 0, 0, pdfReader.GetPageSizeWithRotation(page).Height);
						}
						else
						{
							pdfContentByte.AddTemplate(importedPage, 1f, 0, 0, 1f, 0, 0);
						}

						if (EnablePagination)
						{
							pdfContentByte.BeginText();
							pdfContentByte.SetFontAndSize(baseFont, 9);
							pdfContentByte.ShowTextAligned(PdfContentByte.ALIGN_CENTER,
								string.Format("{0} de {1}", currentPage++, totalPages), 520, 5, 0);
							pdfContentByte.EndText();
						}
					}
				}
			}
			finally
			{
				outputStream.Flush();
				if (newDocument != null)
					newDocument.Close();
				outputStream.Close();
			}
		}

		public PdfMerge()
		{
			documents = new List<PdfReader>();
		}
	}
}
