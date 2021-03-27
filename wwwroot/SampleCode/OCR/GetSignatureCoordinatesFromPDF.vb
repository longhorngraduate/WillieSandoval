//1.  Main Class - call the helper function per borrower:
Dim PDF_doc_SpireDot_Signature_Coordinates As List(Of SpireDotPDF_SignatureLines.PDFMatchCoordinates) = PDF_doc_SpireDot.GetSignatureLinesCoordinates(strName) 'get this borrower's signature line and date coordinates


//2.  Class that holds the final responses:
Class PDFMatchCoordinates
	Public page_number As Integer
	Public borrower_signature_X As Integer
	Public borrower_signature_Y As Integer
	Public date_X As Integer
	Public date_Y As Integer

	Public Sub New()
		page_number = 0
		borrower_signature_X = 0
		borrower_signature_Y = 0
		date_X = 0
		date_Y = 0
	End Sub


	Public Sub SetPage(ByVal pageNumber As Integer)
		page_number = pageNumber
	End Sub

	Public Sub SetBorrowerSignatureCoordinates(ByVal x As Integer, ByVal y As Integer)
		borrower_signature_X = x
		borrower_signature_Y = y
	End Sub

	Public Sub SetDateCoordinates(ByVal x As Integer, ByVal y As Integer)
		date_X = x
		date_Y = y
	End Sub
End Class


//3.  Main Class - helper function to help the main function; calls the OCR program to set the PDF/doc and then to return the results:
''' <summary>
''' Adds the SignHere and DateSigned lists using Coordinates.
''' </summary>
''' <param name="signer">By Ref</param>
''' <param name="fileBytes"></param>
''' <param name="strName"></param>
''' <param name="n"></param>
Private Sub Add_Signature_Coordinates_to_Signer(ByRef signer As Signer, ByVal fileBytes As Byte(), ByVal strName As String, ByVal n As String)
	Dim PDF_doc_SpireDot As SpireDotPDF_SignatureLines = New SpireDotPDF_SignatureLines(fileBytes)
	Dim PDF_doc_SpireDot_Signature_Coordinates As List(Of SpireDotPDF_SignatureLines.PDFMatchCoordinates) = PDF_doc_SpireDot.GetSignatureLinesCoordinates(strName) 'get this borrower's signature line and date coordinates
	...
	...
	...
	For Each oCoordinates As SpireDotPDF_SignatureLines.PDFMatchCoordinates In PDF_doc_SpireDot_Signature_Coordinates
		signHere = New SignHere()
		With signHere
			.RecipientId = n
			.PageNumber = oCoordinates.page_number.ToString()
			.DocumentId = "1"
			.XPosition = oCoordinates.borrower_signature_X.ToString()
			.YPosition = oCoordinates.borrower_signature_Y.ToString()
		End With


//4.  OCR Class
Imports Spire.Pdf
Imports Spire.Pdf.General.Find
Imports System.Collections.Generic


Public Class SpireDotPDF_SignatureLines
	Inherits System.Web.UI.Page


	Private _root_directory As String 'The directroy from C: all the way to where the PDF is stored.
	Private _strFullFileName As String 'The filename of the PDF, including the full path to reach it.

	Private _Doc As PdfDocument 'The main Doc
	Private _Doc_PDF_text As String 'The main Doc's PDF as TEXT

	Private _Doc_new As PdfDocument

    'If you edit this _searchString array, also update the "Notes" section below.

	Private _searchStrings As String() = { "GINESCSTMT", "GSGN", "GPMTA", "GWAI", "Doc Id 2936", "Doc Id 8998", "Doc Id 3137", "Doc Id 4628", "Doc Id 7150", "Doc Id 3139", "Doc Id 3514", "Doc Id 7559", "against the Happy State Bank should contact the Consumer Complaints Administrator of the Texas Department", "G1DEPS", "GRS4", "GNSV", "TXNOOR", "GFEDMIC", "GFEDMI1", "GPMTB", "GBCT", "TXCPIR", "GFACT", "GQCR", "GAMS", "GLOV", "GN13", "GHVCC", "GBCTAXRIJ"}
'Notes:

	'   These are the eClose docs:

	'       FILE NAME (or search txt)       DOC NAME

	'       GINESCSTMT                      

	'       GSGN

	'       GPMTA

	'       GWAI                            ESCROW WAIVER

	'       Doc Id 2936                     Flood Insurance Coverage Subject to Possible Change

	'       Doc Id 8998                     Lender’s Disbursement Statement Authorization

	'       Doc Id 3137                     Document Correction Agreement

	'       Doc Id 4628                     Fair Credit Reporting Act Notice

	'       Doc Id 7150                     No Attorney Representation Notice

	'       Doc Id 3139                     Notice of No Oral Agreements

	'       Doc Id 3514                     Quality Control Release

	'       Doc Id 7559                     Collateral Protection Insurance Notice (Texas)

	'       against the Happy State Bank should contact the Consumer Complaints Administrator of the Texas Department

	'       .....continued.....             Texas Consumer Complaint Process Notice State Chartered Bank & Trusts

	'       G1DEPS                          DATA ENTRY PROOF SHEET

	'       GRS4                            INITIAL ESCROW ACCOUNT DISCLOSURE STATEMENT

	'       GNSV                            NOTICE OF SERVICING TRANSFER

	'       TXNOOR                          NOTICE OF NO ORAL AGREEMENTS

	'       GFEDMIC                         PRIVATE MORTGAGE INSURANCE CANCELLATION/TERMINATION DATA SHEET

	'       GFEDMI1                         PRIVATE MORTGAGE INSURANCE DISCLOSURE FIXED RATE MORTGAGE

	'       GPMTB                           Welcome/Congratulations

	'       GBCT                            BORROWER’S CERTIFICATION & AUTHORIZATION

	'       TXCPIR                          Texas Collateral Protection Insurance Requirements

	'       GFACT                           NOTICE OF FURNISHING NEGATIVE INFORMATION

	'       GQCR                            QUALITY CONTROL RELEASE And AUTHORIZATION TO RE-VERIFY

	'       GAMS                            AMORTIZATION SCHEDULE

	'       GLOV                            Hazard insurance endorsement letter

	'       GN13                            ALLONGE TO NOTE

	'       GHVCC                           ACKNOWLEDGMENT OF RECEIPT OF APPRAISAL REPORT

	'       GBCTAXRIJ                       BORROWER CONSENT TO THE USE OF TAX RETURN INFORMATION

	'

	'   These are Wet docs:

	'       FILE NAME (or search txt)       DOC NAME

	'       F3200NOT                        Note

	'       TXEDEED                         DOT

	'       F3150RLU                        PUD Rider

	'       TXNTCPEN                        Notice of Penalties

	'       Form 4506                       4506

	'       Form 4506-T                     4506-T

	'       GSNATX                          SIGNATURE/NAME AFFIDAVIT

	'       GAOC                            AFFIDAVIT OF OCCUPANCY

	'       GCOMTX                          COMPLIANCE AGREEMENT

	'       Form W-9                        W-9

	'       TXCLO                           MASTER CLOSING INSTRUCTIONS

	'       MAILING ADDRESS CERTIFICATION   MAILING ADDRESS CERTIFICATION

	'       GTRIDCDWSS                      Closing Disclosure

	'       GRT2, GRT4                      Notice of Right to Cancel

	'       Doc Id 6743                     RENEWAL AND EXTENSION EXHIBIT




	'Public Property Doc_new() As PdfDocument

	'	Get

	'		Doc_new = _Doc_new

	'	End Get

	'	Set(ByVal value As PdfDocument)

	'		_Doc_new = value

	'	End Set

	'End Property



	'Public Sub New()

	'	_Doc = New PdfDocument()

	'	_Doc_new = New PdfDocument()

	'End Sub


	Public Sub New(ByVal root_directory As String, ByVal strFullFileName As String)
		_root_directory = root_directory
		_strFullFileName = strFullFileName

		_Doc = New PdfDocument()
		_Doc.LoadFromFile(_strFullFileName)
		_Doc_new = New PdfDocument()

		_Doc_PDF_text = GetTextFromPDF(_Doc)
	End Sub

	'
	' Summary:
	'     Sets the new Document to the byte array
	'
	' Parameters:
	'   byteArray:
	'     The new PDF document as a byte array.
	'
	' Exceptions:
	'   ?:
	'     ?
	Public Sub New(ByVal byteArray As Byte())
		_Doc = New PdfDocument()
		_Doc_new = New PdfDocument(byteArray)

		_Doc_PDF_text = GetTextFromPDF(_Doc_new)
	End Sub


	Public Sub RemovePages()
		Dim pages_removed As ArrayList = New ArrayList()

		pages_removed = CopyPDFPages()
		RemovePDFPages(pages_removed)
	End Sub

	'
	' Summary:
	'     If the file is a PDF file, then the new PDF and the old PDF, minus the pages removed, are saved.
	'
	' Parameters:
	'   tmpguid:
	'     Last directory where the PDF files will be saved.
	'
	' Exceptions:
	'   ?:
	'     ?
	Public Function SavePages() As String
		Dim filename As String = ""
		Dim indexOfPDF = _strFullFileName.ToLower().IndexOf(".pdf")

		If indexOfPDF > -1 Then
			SavePDF(_Doc, _strFullFileName)

			filename = _strFullFileName.Substring(0, indexOfPDF) & "_eSign.pdf"
			SavePDF(_Doc_new, filename)
		End If

		Return filename
	End Function

	'
	' Summary:
	'     Returns an arraylist with all the coordinates (X & Y axis) for each signature line and date where the
	'		user needs to sign.
	'
	' Parameters:
	'   borrName:
	'     The ith/nth borrower name we are searching for in the new PDF document.
	'
	' Exceptions:
	'   ?:
	'     ?
	Public Function GetSignatureLinesCoordinates(ByVal borrName As String) As List(Of PDFMatchCoordinates)
		Return GetCoordinates(borrName)
	End Function


	' -------------------------------------------------- HELPER FUNCTIONS --------------------------------------------------
	Private Function GetTextFromPDF(ByVal Doc As PdfDocument) As String
		Dim result As String = ""
		Dim i As Integer = 0

		For Each page As PdfPageBase In Doc.Pages
			i += 1
			result &= "Willie Page Start" & i & "Start" & page.ExtractText() &"Willie Page End" & i & "End"
		Next

		Return result
	End Function

	'
	' Summary:
	'     PDF pages are COPIED from Doc to Doc_new if the searchString[i] is found in PDF_text. 
	'     Matches are added to pages_removed.
	'
	' Parameters:
	'   ?:
	'     ?
	'
	' Exceptions:
	'   ?:
	'     ?
	Private Function CopyPDFPages() As ArrayList
		Dim pages_removed As ArrayList = New ArrayList()
		Dim pageIndex As Integer
		Dim locationOf_WilliePageEnd As Integer
		Dim locationOf_End As Integer
		Dim locationOf_searchStr As Integer

		For Each searchString As String In _searchStrings 'iterate all your search strings
			locationOf_searchStr = _Doc_PDF_text.IndexOf(searchString) 'look for the search string

			While locationOf_searchStr > -1 'Is the search string found?
				'---Get the page's index---
				locationOf_WilliePageEnd = _Doc_PDF_text.IndexOf("Willie Page End", locationOf_searchStr)
				locationOf_End = _Doc_PDF_text.IndexOf("End", locationOf_WilliePageEnd + 15)
				pageIndex = CInt(_Doc_PDF_text.Substring(locationOf_WilliePageEnd + 15, locationOf_End - (locationOf_WilliePageEnd + 15))) - 1 'Inbetween "WilliePageEnd" and "End".  We then subtract 1 to get the index, not the page number.
				'---end of Get the page's index---

				_Doc_new.InsertPage(_Doc, pageIndex) 'Insert the page into the new Doc.
				pages_removed.Add(pageIndex) 'Add the page index to the Arraylist so we can remove the page later in this program (not now!).
				_Doc_PDF_text = _Doc_PDF_text.Substring(0, _Doc_PDF_text.IndexOf("Willie Page Start" & (pageIndex + 1) & "Start")) & _Doc_PDF_text.Substring(locationOf_End + 3) 'Remove the current page from the local string variable so we won't have to copy/transfer this page to the new Doc multiple times if other matches are found.

				locationOf_searchStr = _Doc_PDF_text.IndexOf(searchString) 'look for the search string
			End While
		Next

		Return pages_removed
	End Function

	'
	' Summary:
	'     Removes pages from instance variable _Doc that are contained in pages_removed.
	'
	' Parameters:
	'   pages_removed:
	'     The ArrayList with the pages that shold be removed.
	'
	' Exceptions:
	'   ?:
	'     ?
	Private Sub RemovePDFPages(ByRef pages_removed As ArrayList)
		pages_removed.Sort()
		pages_removed.Reverse() 'the array should now be in descending order
		For Each ith_page As Integer In pages_removed
			_Doc.Pages.RemoveAt(ith_page)
		Next
	End Sub

	'
	' Summary:
	'     Creates the directory if necessary, then saves the PDFDocuent with the given file name.
	'
	' Parameters:
	'   Doc:
	'     The PDF Document.
	'   directory:
	'     Last directory where the PDF files will be saved.
	'   fileName:
	'     The file name of the PDF file.
	'
	' Exceptions:
	'   ?:
	'     ?
	Private Sub SavePDF(ByRef Doc As PdfDocument, ByVal fileName As String)
		If Not My.Computer.FileSystem.DirectoryExists(_root_directory) Then
			My.Computer.FileSystem.CreateDirectory(_root_directory)
		End If

		Doc.SaveToFile(fileName)
	End Sub

	Public Function GetCoordinates(ByVal searchString As String) As List(Of PDFMatchCoordinates)
		'----- VARIABLES -----
		Dim result As List(Of PDFMatchCoordinates) = New List(Of PDFMatchCoordinates)
		Dim oPDFMatchCoordinates As PDFMatchCoordinates
		Dim myRegexMatches As MatchCollection
		Dim myPageResults As PdfTextFindCollection 'represents MULTIPLE results of searching text in a PDF page
		Dim myPageResult As PdfTextFind() 'represents a SINGLE result of searching text in a PDF page


		Dim pattern As String = "\b(" & searchString & ")\b\s+\b(DATE)\b((?!\:).)*[\n\r]" '\s*\n
        'Dim testDelete As String
        '----- end of VARIABLES -----

        '----- LOGIC -----
        Dim i As Integer = 0
        Dim distance As Integer = 0
        Dim pageAlreadySearched As Boolean
        For Each page As PdfPageBase In _Doc_new.Pages
            i += 1
            pageAlreadySearched = False

            'NOTES:
            '	How to add IgnoreCase and Singleline:
            '		myRegexMatches = Regex.Matches(page.ExtractText, pattern, RegexOptions.Singleline Or RegexOptions.IgnoreCase)
            myRegexMatches = Regex.Matches(page.ExtractText(), pattern, RegexOptions.IgnoreCase)
            Dim tempStr = page.ExtractText()
            'testDelete = page.ExtractText() 'for testing purposes

            'NOTE:
            '		myMatch.Groups.Item(0).Value()		= contains the full regular expression match
            '		myMatch.Groups.Item(1 - x).Value()	= contains individual group matches (the text results between parenthesis)
            For Each myMatch As Match In myRegexMatches
                If Not pageAlreadySearched Then 'We already found all the xy coordinates for this page inside the inner For Loop below.
                    'testDelete = myMatch.Groups.Item(0).Value() 'for testing purposes
                    'testDelete = myMatch.Groups.Item(0).Index() 'for testing purposes
                    'testDelete = myMatch.Groups.Item(1).Value() 'for testing purposes
                    'testDelete = myMatch.Groups.Item(1).Index() 'for testing purposes
                    'testDelete = myMatch.Groups.Item(2).Value() 'for testing purposes
                    'testDelete = myMatch.Groups.Item(2).Index() 'for testing purposes

                    distance = myMatch.Groups.Item(2).Index() - myMatch.Groups.Item(1).Index() 'Distance between the borr's name and "Date".
                    tempStr = Regex.Replace(myMatch.Groups.Item(0).Value(), " {2,}", " ")

                    myPageResults = page.FindText(tempStr, False, True)

					myPageResult = myPageResults.Finds


					For Each text As PdfTextFind In myPageResult
                        oPDFMatchCoordinates = New PDFMatchCoordinates()
                        oPDFMatchCoordinates.SetPage(i)

						oPDFMatchCoordinates.SetBorrowerSignatureCoordinates(text.Position.X - 5, text.Position.Y - 50)

						oPDFMatchCoordinates.SetDateCoordinates(text.Position.X - 5 + (4 * distance), text.Position.Y - 12)


						result.Add(oPDFMatchCoordinates)

						pageAlreadySearched = True

					Next
				End If
            Next
        Next

		Return result
	End Function

	Public Function NumberOfMatchesFound() As Integer
		Return _Doc_new.Pages.Count()
	End Function
	' -------------------------------------------------- end of HELPER FUNCTIONS --------------------------------------------------


	Class PDFMatchCoordinates
		Public page_number As Integer
		Public borrower_signature_X As Integer
		Public borrower_signature_Y As Integer
		Public date_X As Integer
		Public date_Y As Integer

		Public Sub New()
			page_number = 0
			borrower_signature_X = 0
			borrower_signature_Y = 0
			date_X = 0
			date_Y = 0
		End Sub


		Public Sub SetPage(ByVal pageNumber As Integer)
			page_number = pageNumber
		End Sub

		Public Sub SetBorrowerSignatureCoordinates(ByVal x As Integer, ByVal y As Integer)
			borrower_signature_X = x
			borrower_signature_Y = y
		End Sub

		Public Sub SetDateCoordinates(ByVal x As Integer, ByVal y As Integer)
			date_X = x
			date_Y = y
		End Sub
	End Class

End Class
