Imports Leadtools.Ocr
Imports Leadtools
Imports Leadtools.Codecs
Imports System.Text.RegularExpressions
Imports System.Text
Imports System.IO

Public Class Gizmo

    '-------------------------------------------------- INSTANCE VARIABLES --------------------------------------------------
    Private Const MAXFILESIZE As Integer = 1073741824 '33554432

    Private _rasterImage_multiple As RasterImage
    Private docs_to_find As List(Of ClientDoc) = New List(Of ClientDoc)
    Private docs_found As List(Of ClientDoc) = New List(Of ClientDoc)

    Private PDF_root As String '= "C:\Upload\Fulfillment_SeparatePDF\"
    Private PDF_filename As String
    Private PDF_extension As String
    Private timestamp As String 'the result folder's timestamp
    Private save_directory As String
    Private save_directory_root As String = "\\serverName\fulfillment\SeparatePDFs\"
    Private imageFile As String
    '-------------------------------------------------- end of INSTANCE VARIABLES --------------------------------------------------


    '-------------------------------------------------- PROPERTIES --------------------------------------------------
    Private Property rasterImage_multiple() As RasterImage
        Get
            'If rasterImage_multiple Is Nothing Then
            '    _rasterImage_multiple = New RasterImage()
            'End If
            rasterImage_multiple = _rasterImage_multiple
        End Get
        Set(ByVal value As RasterImage)
            _rasterImage_multiple = value
        End Set
    End Property
    '-------------------------------------------------- end of PROPERTIES --------------------------------------------------


    '-------------------------------------------------- EVENTS --------------------------------------------------
    Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
        ResetASPControls()
    End Sub

    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click, textbox_file.Click
        ResetASPControls()

        Dim dialog As OpenFileDialog = New OpenFileDialog()
        dialog.Filter = "Pdf Files | *.pdf" 'file types, that will be allowed To upload
        dialog.Multiselect = False 'allow/deny user To upload more than one file at a time
        If dialog.ShowDialog() = DialogResult.OK Then 'If user clicked OK
            Dim Path As String = dialog.FileName 'get name of file
            SetFileVariables(Path)
            'Using reader As StreamReader = New StreamReader(New FileStream(Path, FileMode.Open), New UTF8Encoding()) 'do anything you want, e.g.read it
            'End Using

            textbox_file.Text = Path
        End If
    End Sub

    Private Sub btnExe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExe.Click
        ResetASPControls()

        Dim strErrorMessage As String = ""
        Dim strErrorSection As Byte = 1 'Used to identify where the program threw the exception.

        If textbox_file.Text = "...select a file..." Or Len(textbox_file.Text) = 0 Then
            txtResult.Text = "Please choose a PDF file first."

        Else
            strErrorSection = 2

            Try
                If Len(PDF_extension) = 0 Then ' no need to continue
                    txtResult.Text = strErrorMessage
                    strErrorSection = 3

                Else
                    strErrorSection = 4

                    Select Case PDF_extension.ToLower
                        Case ".pdf"
                        Case Else
                            strErrorMessage = PDF_extension & " files are not accepted. Please upload a PDF File."
                    End Select

                    If Len(strErrorMessage) <> 0 Then ' no need to continue
                        txtResult.Text = strErrorMessage
                        strErrorSection = 5

                    Else
                        strErrorSection = 6
                        'CreateLocalDirectoryAndFile()

                        txt_results.Text &= vbNewLine & vbNewLine & "...RUNNING...esperate..."
                        Run_Main_Program()

                        'DeleteLocalDirectoryAndFile()
                        strErrorSection = 7
                    End If
                End If

            Catch ex As Exception
                strErrorMessage = "Error: " & ex.Message & ", Section: " & strErrorSection
                txtResult.Text = strErrorMessage
            End Try

            If Len(strErrorMessage) = 0 Then ' SUCCESS!
                txtResult.ForeColor = Color.Green
                txtResult.Text = "Done!"
            End If
        End If
    End Sub
    '-------------------------------------------------- end of EVENTS --------------------------------------------------


    ' -------------------------------------------------- MAIN --------------------------------------------------
    Private Sub Run_Main_Program()
        Dim LeadToolsDirectoryPath As String = Directory.GetCurrentDirectory
        'Debugging:
        'txt_results.Text = LeadToolsDirectoryPath

        'LeadToolsDirectoryPath = LeadToolsDirectoryPath.Substring(0, LeadToolsDirectoryPath.LastIndexOf("\WizardGizmo\bin\") + 13)
        LeadToolsDirectoryPath = LeadToolsDirectoryPath.Substring(0, LeadToolsDirectoryPath.LastIndexOf("\bin\") + 1) & "LEADTOOLS\"
        'LeadToolsDirectoryPath = Application.ExecutablePath
        'LeadToolsDirectoryPath = Path.GetDirectoryName(Application.ExecutablePath).Replace("\bin\Debug", "") & "\LEADTOOLS\"
        'LeadToolsDirectoryPath = Application.path

        Dim startTime As DateTime = Now()
        timestamp = startTime.Month & "_" & startTime.Day & "_" & startTime.Year & "_" & startTime.Hour & "_" & startTime.Minute & "_" & startTime.Second

        save_directory = save_directory_root & "PPDocs_LeadTools_output\" & PDF_filename & "_" & timestamp & "\"
        If Not My.Computer.FileSystem.DirectoryExists(save_directory) Then
            My.Computer.FileSystem.CreateDirectory(save_directory)
        End If


        Set_DocsToFind_List()
        'Directory.GetCurrentDirectory ...OR... AppDomain.CurrentDomain.BaseDirectory
        'Leadtools.RasterSupport.SetLicense("C:\Users\Willie\Documents\Visual Studio 2017\Solutions\DocPrep\DocPrep-Main\Intranet\Bin\LEADTOOLS\eval-license-files.lic", "0cxOXpRTi5aabVDDTdFok4CRWsBLLm0Ivt383qJptTO9oJTYamPE132Yxnr4CmFEO5zFcuuaaSTXpOJGpuGal0kjTaEtnx3u")

        Leadtools.RasterSupport.SetLicense(LeadToolsDirectoryPath & "eval-license-files.lic", "1sxMXslTjJadbVLDTNE/k4CRUcBKLjAI6t383qJpsjO8oM7YamOe1yyYl3qkCmFEOpzHcryaaiSFpLVG8eGYl0wjSqEpnxzu")

        'Debugging:
        'txt_results.Text &= ", section 2"

        ' Create the engine instance 
        Using ocrEngine As IOcrEngine = OcrEngineManager.CreateEngine(OcrEngineType.LEAD, False)
            'Debugging:
            'txt_results.Text &= ", section 3"

            'ocrEngine.Startup(Nothing, Nothing, Nothing, "C:\Users\Willie\Documents\Visual Studio 2017\Solutions\DocPrep\DocPrep-Main\Intranet\Bin\LEADTOOLS\OcrLEADRuntime\")
            ocrEngine.Startup(Nothing, Nothing, Nothing, LeadToolsDirectoryPath & "OcrLEADRuntime\")
            'ocrEngine.SpellCheckManager.SpellCheckEngine = OcrSpellCheckEngine.Native

            'Debugging:
            'txt_results.Text &= ", section 4"

            imageFile = PDF_root & PDF_filename & PDF_extension
            Dim pageCount As Integer = ocrEngine.RasterCodecsInstance.GetTotalPages(imageFile) 'Get the number of pages in the document
            Dim page_text As String
            Dim prev_filename As String = ""

            '----- Loop All Pages -----
            For page As Integer = 1 To pageCount 'Create a page
                Dim rasterImage_single As RasterImage = ocrEngine.RasterCodecsInstance.Load(imageFile, page) 'Load a RasterImage 

                page_text = GetPageText(ocrEngine, rasterImage_single)
                Create_Add_andor_Save_Doc(rasterImage_single, page_text, prev_filename)

                rasterImage_single.Dispose()
            Next
            SaveThePrevDoc(rasterImage_multiple, prev_filename) 'Save the very last doc, whether it's a single - paged or multiple - paged PDF.
            '----- end of Loop All Pages -----


            '----- Clean -----
            ocrEngine.Shutdown()
            ocrEngine.Dispose()
            rasterImage_multiple = Nothing
            '----- end of Clean -----

        End Using


        '----- RESULTS -----
        Dim results As New StringBuilder
        results.AppendLine("Time to Execute: " & (DateDiff(DateInterval.Second, Now(), startTime) / 60) & " minutes")
        results.AppendLine()
        results.AppendLine("FOUND:")

        For Each doc As ClientDoc In docs_found
            results.AppendLine(doc.ToString())
        Next
        results.AppendLine()
        'results.AppendLine("NOT FOUND:")
        'For Each doc In docs_to_find
        '    results.AppendLine(doc.ToString())
        'Next

        txt_results.Text = results.ToString()

        My.Computer.FileSystem.WriteAllText(save_directory & "Results.txt", results.ToString(), False)
        '----- end of RESULTS -----


        '----- CLEAN -----
        docs_to_find.Clear()
        docs_found.Clear()
        '----- end of CLEAN -----
    End Sub
    ' -------------------------------------------------- end of MAIN --------------------------------------------------


    ' -------------------------------------------------- HELPER FUNCTIONS --------------------------------------------------
    Public Function ResetASPControls() As Boolean
        txtResult.Text = ""
        txtResult.ForeColor = Color.Red

        Dim txt_results_stringbuilder As StringBuilder = New StringBuilder()
        txt_results_stringbuilder.AppendLine("This program will separate PDFs into individual PDFs, each containing a predefined document.")
        txt_results_stringbuilder.AppendLine("")
        txt_results_stringbuilder.AppendLine("------------------------- NOTES -------------------------")
        txt_results_stringbuilder.AppendLine("- Once the program starts running, it is not interactive.  You will see a green ""DONE"" message when completed.")
        txt_results_stringbuilder.AppendLine("- Results will appear here after the whole PDF has been executed.")
        txt_results_stringbuilder.AppendLine("- Approximate wait time is 5-45 minutes, depending on the size and quality of the PDF and your computer's speed.")
        txt_results_stringbuilder.AppendLine("")
        txt_results_stringbuilder.AppendLine("- Here are sample files:  \\serverName\FULFILLMENT\SeparatePDFs\sample_PDF_input\")
        txt_results_stringbuilder.AppendLine("- Separated PDFs will appear here:  \\serverName\FULFILLMENT\SeparatePDFs\PPDocs_LeadTools_output\")
        txt_results_stringbuilder.AppendLine("")
        txt_results_stringbuilder.AppendLine("- Upload one PDF at a time.  Only predefined documents will be captured.")
        txt_results_stringbuilder.AppendLine("- Pages pertaining to a document must appear in sequential order inside the PDF.")
        txt_results_stringbuilder.AppendLine("- Pages must appear vertically, with the top of the document on the top of the page.")
        txt_results_stringbuilder.AppendLine("- Pages can be skewed by no more than 20 degrees.")
        txt_results_stringbuilder.AppendLine("")
        txt_results_stringbuilder.AppendLine("- The same document can appear multiple times inside the PDF, where each one will be saved with a number at the end of the filename.")
        txt_results_stringbuilder.AppendLine(vbTab & "E.g.")
        txt_results_stringbuilder.AppendLine(vbTab & "- Doc 1 will be named ""Schedule_A_1_31_2020""")
        txt_results_stringbuilder.AppendLine(vbTab & "- Doc 2 will be named ""Schedule_A_1_31_2020_2""")
        txt_results_stringbuilder.AppendLine("- The document WILL NOT be captured if:")
        txt_results_stringbuilder.AppendLine(vbTab & "- it is a new (unknown) document.")
        txt_results_stringbuilder.AppendLine("- The document MAY NOT be captured if:")
        txt_results_stringbuilder.AppendLine(vbTab & "- the 1st page of the document has too much writing on it,")
        txt_results_stringbuilder.AppendLine(vbTab & "- the 1st page of the document is of bad quality, or")
        txt_results_stringbuilder.AppendLine(vbTab & "- the 1st page of the document has changed its format.")
        txt_results_stringbuilder.AppendLine("- When a document isn't recognized for whatever reason, it will be added to the end of the previous document.")
        txt_results_stringbuilder.AppendLine(vbTab & "E.g.")
        txt_results_stringbuilder.AppendLine(vbTab & "If Schedule A appears right before Schedule B in the main PDF file and if Schedule B has been written on too much with a pen or pencil, then it will be added to the end of ""Schedule_A_1_31_2020.pdf"".")


        txt_results.Text = txt_results_stringbuilder.ToString()
    End Function

    Public Function GetPageText(ByVal ocrEngine As IOcrEngine, ByVal rasterImage_single As RasterImage) As String
        Dim result As String = ""

        Dim rasterImage_temp As RasterImage
        CopyRasterImages(rasterImage_single, rasterImage_temp)

        'Create an OCR page from this image, transferring ownership of the RasterImage object
        Using ocrPage As IOcrPage = ocrEngine.CreatePage(rasterImage_temp, OcrImageSharingMode.AutoDispose)
            'Auto-preprocess it (These 3 lines below cause the text retrieved to be incorrect (returns weird symbols and characters).)
            'ocrPage.AutoPreprocess(OcrAutoPreprocessPageCommand.Deskew, Nothing)
            'ocrPage.AutoPreprocess(OcrAutoPreprocessPageCommand.Invert, Nothing)
            'ocrPage.AutoPreprocess(OcrAutoPreprocessPageCommand.Rotate, Nothing)

            ocrPage.Recognize(Nothing)
            result = ocrPage.GetText(-1)

            'Page will be disposed here and its memory freed
        End Using

        rasterImage_temp.Dispose()

        Return result
    End Function


    Public Sub Create_Add_andor_Save_Doc(ByVal rasterImage_single As RasterImage, ByVal page_text As String, ByRef prev_filename As String)
        Dim FoundAMatch As Boolean = False
        Dim file_name As String = ""

        Dim myRegexMatches As MatchCollection

        '----- Iterate all the regular expressions -----
        For Each iDoc As ClientDoc In docs_to_find
            'Debugging:
            'SaveTextIfChosenForDebugging(iDoc._name, iDoc._file_name.Substring(0, iDoc._file_name.Length - 4) & ".txt", page_text) 'Save the 1st page of a doc if it's found in the function's if-statement
            'end of Debugging:

            If iDoc._name = "UW Terms And Conditions" Or iDoc._name = "Funding Suite" Or iDoc._name = "Privacy Notice" Or iDoc._name = "Uniform Residential Loan Application" Or iDoc._name = "Legal Description" Or iDoc._name = "Commitment For Title Insurance" Or iDoc._name = "Notice to the Home Loan Applicant" Or iDoc._name = "Credco Instant Merge LQ Credit Report" Or iDoc._name = "Credco Instant Merge Credit Report" Or iDoc._name = "Credit Score Disclosure" Or iDoc._name = "Credco ProScan OFAC Report" Or iDoc._name = "Schedule A" Or iDoc._name = "Schedule B" Or iDoc._name = "Schedule C" Or iDoc._name = "Schedule D" Or iDoc._name = "Title Residential Information Services" Or iDoc._name = "Invoice" Or iDoc._name = "Fax Server" Or iDoc._name = "Individual Condominium Unit Appraisal Report" Or iDoc._name = "Addendum" Or iDoc._name = "Market Conditions Addendum to the Appraisal Report" Or iDoc._name = "Factual Data Credit Score" Or iDoc._name = "Specialized Loan Servicing" Or iDoc._name = "Title Insurance Information" Or iDoc._name = "Evidence Of Insurance" Or iDoc._name = "Department Of Veterans Affairs" Or iDoc._name = "Direct Endorsement Approval for a HUD/FHA-Insured Mortgage" Or iDoc._name = "Borrower's Acknowledgement Of Disclosures" Or iDoc._name = "Disclosure Notices" Or iDoc._name = "Farmers Value Insurance Package" Or iDoc._name = "Policy Notices" Or iDoc._name = "Amendment" Or iDoc._name = "Special Warranty Deed" Or iDoc._name = "Flood Cert Order Summary" Or iDoc._name = "Underwriting Decision" Or iDoc._name = "Verification Services" Or iDoc._name = "TRN Financial Mail" Or iDoc._name = "Tax Certificate" Or iDoc._name = "Title Guaranty Company" Or iDoc._name = "Insured Closing Service" Or iDoc._name = "Survey" Or iDoc._name = "Deletion Of Arbitration Provision" Or iDoc._name = "Lock Confirmation" Then
                myRegexMatches = Regex.Matches(page_text, iDoc._pattern, RegexOptions.IgnoreCase Or RegexOptions.Singleline)
            Else
                myRegexMatches = Regex.Matches(page_text, iDoc._pattern, RegexOptions.IgnoreCase)
            End If


            If myRegexMatches.Count() > 0 Then 'Found a match!
                'Debugging:
                If iDoc._name = "Additional Details For Services You Can Shop For" Then 'iDoc._name = "Mortgage Credit Report" Or iDoc._name = "Consumer Explanation Letter" Then 'If iDoc._name = "Closing Disclosure" Or iDoc._name = "Schedule A" Or iDoc._name = "Schedule B" Or iDoc._name = "Schedule C" Or iDoc._name = "Schedule D" Or iDoc._name = "Commitment For Title Insurance" Or iDoc._name = "Notice to the Home Loan Applicant" Then
                    Dim tempstop = 1
                End If
                'end of Debugging:

                file_name = AddDocToFoundList(iDoc) 'This filename might have the postfix of "_<doc count>".pdf. For ex, filename might be Rebate_Agreement_<date>_<time>_2.pdf.

                'docs_to_find.Remove(iDoc) 'Do not remove in case there are duplicates.

                FoundAMatch = True
                Exit For
            End If
        Next
        '----- end of Iterate all the regular expressions -----

        If Not FoundAMatch Then 'This should happen when 1) NOT on the 1st page and 2) NOT when a new match is found.
            If Not rasterImage_multiple Is Nothing Then 'This is any subsequent page AFTER the doc has been created/started.
                rasterImage_multiple.InsertPage(-1, rasterImage_single)

            Else 'Error - The very first page of the PDF didn't match.
                StartTheNewDoc(rasterImage_multiple, rasterImage_single, prev_filename, "unknown" & ".pdf")

            End If

        Else 'This should happen when 1) the PDF's 1st page is loaded AND 2) a match is found for a new doc.
            If Not rasterImage_multiple Is Nothing Then 'This is the beginning of a doc but NOT the very 1st one.
                SaveThePrevDoc(rasterImage_multiple, prev_filename)
                StartTheNewDoc(rasterImage_multiple, rasterImage_single, prev_filename, file_name)

            Else 'This is the very 1st page of the PDF
                StartTheNewDoc(rasterImage_multiple, rasterImage_single, prev_filename, file_name)

            End If

        End If

    End Sub


    Public Sub StartTheNewDoc(ByRef rasterImage_multiple As RasterImage, ByVal rasterImage_single As RasterImage, ByRef prev_filename As String, ByVal file_name As String)
        CopyRasterImages(rasterImage_single, rasterImage_multiple)
        prev_filename = file_name
    End Sub

    Public Sub SaveThePrevDoc(ByVal rasterImage_multiple As RasterImage, ByVal prev_filename As String)
        Dim Codecs As RasterCodecs = New RasterCodecs()
        Codecs.Save(rasterImage_multiple, save_directory & prev_filename, RasterImageFormat.RasPdf, 24) '.PdfLeadMrc
        Codecs.Dispose()

        rasterImage_multiple.Dispose()
    End Sub

    Public Sub SaveText(ByVal filename As String, ByVal text As String)
        My.Computer.FileSystem.WriteAllText(save_directory & filename, text, False)

        'Dim file As System.IO.StreamWriter
        'file = My.Computer.FileSystem.OpenTextFileWriter(save_directory & filename, True)
        'file.WriteLine("Here is the first string.")
        'file.Close()
    End Sub

    'Debugging
    Public Sub SaveTextIfChosenForDebugging(ByVal name As String, ByVal filename As String, ByVal text As String)
        'If name = "SSA Verify Report" Or name = "CBR Authorization" Or name = "Demographic Information of Applicant(s)" Or name = "Authorization for the Social Security Administration (SSA)" Or name = "Envelope Originator" Or name = "Electronic Record and Signature Disclosure created on" Or name = "Disclosure Notices" Or name = "Private Mortgage Insurance Disclosure" Or name = "Earnest Money Delivery Details" Or name = "Legal Description" Or name = "Survey" Or name = "Closing Disclosure" Or name = "Form T-50: Insured Closing Service (Lender)" Or name = "Title Data" Or name = "Standard Flood Hazard Determination Form (SFHDF)" Then
        '    My.Computer.FileSystem.WriteAllText(save_directory & filename, text, False)
        'End If
    End Sub

    Public Sub CopyRasterImages(ByVal rasterImage_src As RasterImage, ByRef rasterImage_dest As RasterImage)
        'rasterImage_multiple = rasterImage_single.Clone()

        ' Creates a new image in memory with same dimensions as the source image
        'rasterImage_dest = New RasterImage(RasterMemoryFlags.Conventional, rasterImage_src.Width, rasterImage_src.Height, rasterImage_src.BitsPerPixel, rasterImage_src.Order, rasterImage_src.ViewPerspective, rasterImage_src.GetPalette(), IntPtr.Zero, 0)
        rasterImage_dest = New RasterImage(rasterImage_src) 'This line will fail if the document is too large.

        ' Copy the data from the source image to the destination image 
        rasterImage_src.Access()
        rasterImage_dest.Access()

        Dim buffer As Byte() = New Byte(rasterImage_src.BytesPerLine - 1) { }

Dim y As Integer = 0
        Do While y < rasterImage_src.Height
            rasterImage_src.GetRow(y, buffer, 0, buffer.Length)
            rasterImage_dest.SetRow(y, buffer, 0, buffer.Length)
            y += 1
        Loop

        rasterImage_dest.Release()
        rasterImage_src.Release()
    End Sub

    Public Function AddDocToFoundList(ByVal iDoc As ClientDoc) As String
        iDoc._number_of_matches += 1

        Dim iDoc2 As ClientDoc = New ClientDoc(iDoc._name, iDoc._pattern, iDoc._file_name, iDoc._number_of_matches) 'Create a copy because we don't want the iDoc's instance variables to change, specifically, "_filename".
        Dim filename As String = iDoc2._file_name

        If iDoc2._number_of_matches > 1 Then
            filename = filename.Substring(0, filename.LastIndexOf(".")) &"_" & iDoc2._number_of_matches & ".pdf" 'Add "_<file count>".pdf to the end of the filename.
            iDoc2._file_name = filename
        End If

        docs_found.Add(iDoc2)

        Return filename
    End Function

    Public Sub SetFileVariables(ByVal filename As String)
        PDF_filename = filename

        PDF_root = PDF_filename.Substring(0, InStrRev(PDF_filename, "\"))

        PDF_filename = Mid(PDF_filename, InStrRev(PDF_filename, "\") + 1)
        PDF_extension = Mid(PDF_filename, PDF_filename.LastIndexOf(".") + 1)

        PDF_filename = PDF_filename.Substring(InStrRev(PDF_filename, "\"), PDF_filename.LastIndexOf("."))
    End Sub

    'Public Sub CreateLocalDirectoryAndFile()
    '    If Not System.IO.Directory.Exists(PDF_root) Then
    '        System.IO.Directory.CreateDirectory(PDF_root)
    '    End If

    '    txtFileContents.SaveAs(PDF_root & PDF_filename & PDF_extension)
    'End Sub

    'Public Sub DeleteLocalDirectoryAndFile()
    '    My.Computer.FileSystem.DeleteFile(PDF_root & PDF_filename & PDF_extension)

    '    'If System.IO.Directory.Exists(PDF_root) Then
    '    '    System.IO.Directory.Delete(PDF_root)
    '    'End If
    'End Sub

    Public Sub Set_DocsToFind_List()
        '----- Each doc inside each group must appear in this order -----
        '--- GROUP ---
        docs_to_find.Add(New ClientDoc("Notice to the Home Loan Applicant", "^((?!Credit Score Disclosure).)*Notice to (the\s)*Home Loan Applicant[\n\r]", "Notice_to_the_Home_Loan_Applicant" & ".pdf", 0)) '1 page
        docs_to_find.Add(New ClientDoc("Credit Score Disclosure", "^.*[\n\r]*Credit Score Disclosure.*Prepared For\:\s*Prepared By\:", "Credit_Score_Disclosure" & ".pdf", 0))
        '--- end of GROUP ---

        '--- GROUP ---
        docs_to_find.Add(New ClientDoc("Certificate Of Completion", "Envelope Originator.[\n\r]", "Certificate_Of_Completion" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Electronic Record and Signature Disclosure", "^E[li]ectron[li]c Record and S[li]gnature D[li]sclosure created on\:|[\n\r]E[li]ectron[li]c Record and S[li]gnature D[li]sclosure[\n\r]", "Electronic_Record_and_Signature_Disclosure" & ".pdf", 0))
        '--- end of GROUP ---

        '--- GROUP ---
        docs_to_find.Add(New ClientDoc("Disclosure Notices", "^((?!BORROWER[']*S[']* ACKNOWLEDGEMENT OF DISCLOSURES|BORROWER ACKNOWLEDGEMENT OF.*FEDERAL DISCLOSURES).)*[\n\r]DISCLOSURE NOTICES[\n\r]", "Disclosure_Notices" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Seller's Disclosure Notice", "[\n\r][\sI]*SELLER\'*S DISCLOSURE NOTICE[\sI]*[\n\r]", "Sellers_Disclosure_Notice" & ".pdf", 0)) '8 pages
        docs_to_find.Add(New ClientDoc("Interest Rate And Discount Statement", "[\n\r]INTEREST RATE AND DISCOUNT STATEMENT[\n\r]", "Interest_Rate_And_Discount_Statement" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Uniform Residential Loan Application", "^((?!Demographic Information Addendum|DEPARTMENT OF[\n\r\s]*VETERANS AFFAIRS|INTEREST RATE AND DISCOUNT STATEMENT).)*Uniform Residential Loan Application.*Page\s*[1li]\s*[of]*[\s\n\r$]+", "Uniform_Residential_Loan_Application" & ".pdf", 0))
        '--- end of GROUP ---

        '--- GROUP ---
        '--- end of GROUP ---
        '----- end of Each doc inside each group must appear in this order -----


        docs_to_find.Add(New ClientDoc("Commitment For Title Insurance", "(THE\s*FOLLOWING\s*COMMITMENT\s*FOR\s*TITLE\s*INSURANCE\s*IS\s*NOT\s*VALID\s*UNLESS\s*YOUR\s*NAME.*COMMITMENT\s*FOR\s*TITLE\s*INSURANCE)|(COMMITMENT\s*FOR\s*TITLE\s*INSURANCE.*THE\s*FOLLOWING\s*COMMITMENT\s*FOR\s*TITLE\s*INSURANCE\s*IS\s*NOT\s*VALID\s*UNLESS\s*YOUR\s*NAME)|(Commitment\s*for\s*Title\s*Insurance.*THIS\s*COMMITMENT\s*IS\s*AN\s*OFFER\s*TO\s*ISSUE\s*ONE\s*OR\s*MORE)|(^.*[\n\r]COMMITMENT FOR TITLE INSURANCE[\n\r]((?!DELETION OF ARBITRATION PROVISION|[\n\r]Schedule A[\n\r]|[\n\r]Schedule B[\n\r]|[\n\r]Schedule C[\n\r]|[\n\r]Schedule D[\n\r]).)*$)", "Commitment_For_Title_Insurance" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Schedule A", "^((?!END OF\s|Uniform Residential Loan Application).)*SCHEDULE A[\n\r]((?!\(\s*Continued\s*\)).)*$", "Schedule_A" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Schedule B", "^((?!END OF\s|Uniform Residential Loan Application).)*SCHEDULE B[\n\r]((?!\(\s*Continued\s*\)).)*$", "Schedule_B" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Schedule B", "^((?!END OF\s|Uniform Residential Loan Application).)*SCHEDULE (B-1|B-I|B-L)[\n\r]((?!\(\s*Continued\s*\)).)*$", "Schedule_BI" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Schedule B", "^((?!END OF\s|Uniform Residential Loan Application).)*SCHEDULE (B-11|B-II|B-LL)[\n\r]((?!\(\s*Continued\s*\)).)*$", "Schedule_BII" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Schedule C", "^((?!END OF\s|Uniform Residential Loan Application).)*SCHEDULE C[\n\r]((?!\(\s*Continued\s*\)).)*$", "Schedule_C" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Schedule D", "^((?!END OF\s|Uniform Residential Loan Application).)*SCHEDULE D[\n\r]((?!\(\s*Continued\s*\)).)*$", "Schedule_D" & ".pdf", 0))
        'DELTE THIS IF EVERYTHING IS WORKING:   docs_to_find.Add(New ClientDoc("Acknowledgement Of Federal Disclosures Subject To TILA/RESPA", "\b(" & "FOR MORTGAGE TRANSACTIONS SUBJECT TO TILA/RESPA INTEGRATED" & ")\b", "Acknowledgement_Of_Federal_Disclosures_Subject_To_TILA_RESPA" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Borrower's Acknowledgement Of Disclosures", "^.*([\n\r]\s*BORROWER[']*S[']* ACKNOWLEDGEMENT OF DISCLOSURES\s*[\n\r]|BORROWER ACKNOWLEDGEMENT OF.*[\n\r]FEDERAL DISCLOSURES[\n\r])", "Borrowers_Acknowledgement_Of_Disclosures" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Credit Re-Verification Acknowledgement", "\b(" & "CREDIT RE-VERIFICATION ACKNOWLEDGMENT" & ")\b", "Credit_ReVerification_Acknowledgement" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Acknowledgement Of Customer Product Choice", "\b(" & "ACKNOWLEDGEMENT OF CUSTOMER PRODUCT CHOICE" & ")\b", "Acknowledgement_Of_Customer_Product_Choice" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Department Of Veterans Affairs", "^((?!DISCLOSURE NOTICES|INTEREST RATE AND DISCOUNT STATEMENT|INSTRUCTIONS FOR VA FORM|RIGHTS OF VA LOAN BORROWERS|PROPERTY APPROVAL:|Uniform Residential Loan Application|Notices to Borrowers).)*DEPARTMENT OF[\n\r\s]*VETERANS AFFAIRS((?!DISCLOSURE NOTICES|INTEREST RATE AND DISCOUNT STATEMENT|Interest Rate And Discount Statement|INSTRUCTIONS FOR VA FORM|RIGHTS OF VA LOAN BORROWERS).)*$", "Department_Of_Veterans_Affairs" & ".pdf", 0)) '5 pages
        docs_to_find.Add(New ClientDoc("Conditional Loan Approval Notice", "[\n\r]Conditional Loan Approval Notice[\n\r]", "Conditional_Loan_Approval_Notice" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Demographic Information Addendum", "\b(" & "Demographic Information Addendum" & ")\b", "Demographic_Information_Addendum" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Look Up a ZIP Code", "[\n\r]Look Up a ZIP Code", "Look_Up_a_ZIP_Code" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("SSA Verify Report", "[\n\r]Automation Research, Inc.[\n\r]", "SSA_Verify_Report" & ".pdf", 0)) '5th
        docs_to_find.Add(New ClientDoc("Driver License", "DRIVER (LICENSE|ucense)", "Driver_License" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("CoreLogic Credco", "[\n\r]Pricing Detail[\n\r]", "CoreLogic_Credco" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Credco Instant Merge LQ Credit Report", "Credco Instant Merge LQ Credit Re*port.*Prepared For\:\s*Prepared By\:", "Credco_Instant_Merge_LQ_Credit_Report" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("CBR Authorization", "\b(" & "CBR Authorization" & ")\b[\n\r]", "CBR_Authorization" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Demographic Information of Applicant(s)", "\b(" & "Demographic Information of Applicant" & ")\b", "Demographic_Information_of_Applicants" & ".pdf", 0)) '10th
        docs_to_find.Add(New ClientDoc("Credco Instant Merge Credit Report", "Credco Instant Merge Credit Report.*Prepared For\:\s*Prepared By\:", "Credco_Instant_Merge_Credit_Report" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Credco ProScan OFAC Report", "Credco ProScan OFAC R(e|cg)port.*Prepared\s*For\s*[\:\']\s*Prepared\s*By\s*[\:\']", "Credco_ProScan_OFAC_Report" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("One To Four Family Residential Contract", "[COQD]NE\s*[TIL1][COQD]\s*F[COQD]UR\s*FAM[LIR1][TIL1][YV]\s*RES[LIR1]DEN[TIL1][LIR1]A[TIL1]\s*[COQD][COQD]N[TIL1]", "One_To_Four_Fam_Resid_Cntrct" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Addendum For Property Subject To Mandatory Membership In A Property Owners Association", "[\n\r].*A[DOQ][DOQ]ENDUM F[DOQ]R PR[DOQ]PERTY SUBJECT T[DOQ][\sI\,]*[\n\r].*MANDAT[DOQ]RY MEMBERSH[IL]P [IL]N A PR[DOQ]PERTY[\sI\,]*[\n\r][\sI\,\.]*[DOQ]WNERS ASS[DOQ]C[IL]AT[IL][DOQ]N[\sI\,\.]*[\n\r].*\(N[DOQ]T", "Adnm_For_Propty_Subj_To_Mandatory_Memb_In_A_Propty_Owners_Assoc" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Third Party Financing Addendum", "([\n\r].*\b(PROMULGATED BY THE TEXAS REAL ESTATE COMMISSION)\b\s*\(TREC\)[\n\r])|([\n\r](TREC\s)*THIRD PARTY FINANCING ADDENDUM[\n\r])", "Third_Party_Financing_Adnm" & ".pdf", 0)) '2 pages
        docs_to_find.Add(New ClientDoc("Addendum Concerning Right To Terminate Due To Lender's Appraisal", "[\n\r]\b(" & "ADDENDUM CONCERNING RIGHT TO TERMINATE" & ")\b", "Addendum_Concerning_Right_To_Terminate" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Borrowers Certification", "Borrower[']*s[']* Certification[\:|\s*and Authorization]", "Borrowers_Certification" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Authorization for the Social Security Administration (SSA)", "\b(" & "Authorization for the Social Security Administration" & ")\b", "Authorization_for_the_Social_Security_Administration" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Request for Transcript of Tax Return", "\b(" & "Request for Transcript of Tax Return" & ")\b", "Request_for_Transcript_of_Tax_Return" & ".pdf", 0)) '20th
        docs_to_find.Add(New ClientDoc("Loan Estimate", "Save [tr]h[li1]s [li1]oan Es[tr][li1]ma[tr]e [tr]o compa[tr]e w[li1][tr]h you[tr] C[li1]os[li1]ng D[li1]sc[li1]osu[tr]e", "Loan_Estimate" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Additional Details For Services You Can Shop For", "\b(" & "Additional Details For Services You Can Shop For" & ")\b", "Additional_Details_For_Services_You_Can_Shop_For" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Intent To Proceed With Application", "\b(" & "INTENT TO PROCEED WITH APPLICATION" & ")\b", "Intent_To_Proceed_With_Application" & ".pdf", 0)) '25th
        docs_to_find.Add(New ClientDoc("Equal Credit Opportunity Act", "\b(" & "The Federal Equal Credit Opportunity Act prohibits creditors from discriminating against credit" & ")\b", "Equal_Credit_Opportunity_Act" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Patriot Act", "\b(" & "To help the government fight the funding of terrorism and money laundering activities, Federal law requires all financial" & ")\b", "Patriot_Act" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Receipt of Your Home Loan Toolkit", "\b(" & "Receipt of Your Home Loan Toolkit" & ")\b", "Receipt_of_Your_Home_Loan_Toolkit" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Homeownership Counseling Notice", "\b(" & "HOMEOWNERSHIP COUNSELING NOTICE" & ")\b", "Homeownership_Counseling_Notice" & ".pdf", 0)) '30th
        docs_to_find.Add(New ClientDoc("Your Credit Score and the Price You Pay for Credit", "\b(" & "Your Credit Score and the Price You Pay for Credit" & ")\b", "Your_Credit_Score_and_the_Price_You_Pay_for_Credit" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Private Mortgage Insurance Disclosure", "[\n\r]\b(You are obtaining a mortgage loan that requires private mortgage insurance)\b\s\(""PMI""\)\.", "Private_Mortgage_Insurance_Disclosure" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Rate Lock Agreement", "\b(" & "This is to confirm that the interest rate, discount points, and other terms set forth in your Loan Financing" & ")\b", "Rate_Lock_Agreement" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Privacy Notice", "(^((?!Privacy Policy).)*DO WITH YOUR PERSONAL INFORMATION?.*$)|([\n\r]PRIVACY NOTICE[\n\r])", "Privacy_Notice" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Privacy Policy", "Privacy Policy.*[\n\r].*The States Title Family of Companies.*[\n\r].*WHAT DOES THE STATES TITLE FAMILY OF COMPANIES DO WITH YOUR PERSONAL INFORMATION?", "Privacy_Policy" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Privacy Policy Notice", "Privacy Policy Notice[\n\r]", "Privacy_Policy_Notice" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Housing Counselors Near You", "\b(" & "Housing counselors near you" & ")\b", "Housing_Counselors_Near_You" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("HOEPA/HMDA/HPML Required Information", "\b(" & "HOEPA/HMDA/HPML REQUIRED INFORMATION" & ")\b", "HOEPA_HMDA_HPML_Required_Information" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Earnest Money Delivery Details", "\b(" & "Earnest Money Delivery Details" & ")\b", "Earnest_Money_Delivery_Details" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Legal Description", "^((?!TERMS and CONDITIONS overflow|Addendum).)*(LEGAL DESCRIPTION[\n\r]).*$", "Legal_Description" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Survey", "(^((?!Schedule\s*B).)*SURVEY PLAT)|([TRLI1!]H[E8] SU[RT][YV][E8][YV] [TRLI1!]S H[E8][RT][E8][B38][YV] ACC[E8]P[TRLI1!][E8][DO])", "Survey" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Tax Certificate", "^(PAGE 1 OF .*[\n\r].*[\n\r]TAX CERTIFICATE)|(Tax Certificate[\n\r].*(Customer\s*:|Certificate\s*Number\s*:))|(.*TAX CERTIFICATE\s*Page\s*[1li]\s*[of]*[\s\n\r$]+)", "Tax_Certificate" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Tax Certificate Update", "(^|[\n\r])Tax Certificate Update", "Tax_Certificate_Update" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Certified Tax Certificate", "Page 1[\s\,].*[\n\r]Certified Tax Certificate[\n\r]", "Certified_Tax_Certificate" & ".pdf", 0)) '3 pages
        docs_to_find.Add(New ClientDoc("Closing Disclosure", "[\n\r]Clos[li]ng [li]nformat[li]on\s*Transact[li]on [li]nformation", "Closing_Disclosure" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Title Data", "[\n\r]Title Data\s*,\s*Inc.*001", "Title_Data" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Deletion Of Arbitration Provision", "(^|[\n\r])Deletion Of Arbitration Provision[\n\r]", "Deletion_Of_Arbitration_Provision" & ".pdf", 0)) '1 page
        docs_to_find.Add(New ClientDoc("Policy Description", "[\n\r]POLICY DESCRIPTION[\n\r]", "Policy_Description" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Mortgagee Statement", "[\n\r]Review Your Mortgagee Statement[\n\r]", "Mortgagee_Statement" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("USAA Casualty Insurance Company", "[\n\r]USAA CASUALTY INSURANCE COMPANY[\n\r]", "USAA_Casualty_Insurance_Company" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Commitment/Certificate - MGIC", "[\n\r]COMMITMENT/CERTIFICATE[\n\r]", "MGIC_Commitment_Certificate" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("MiQ - MGIC", "\b(" & "This is a premium rate quote and not a commitment of insurance. A commitment of insurance is subject to approval according to the applicable MGIC" & ")\b", "MGIC_MiQ" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Standard Flood Hazard Determination Form (SFHDF)", "[\n\r]\b(STANDARD FLOOD HAZARD DETERMINATION FORM)\b\s*\(SFHDF\)", "Standard_Flood_Hazard_Determination_Form_SFHDF" & ".pdf", 0)) '1 page
        docs_to_find.Add(New ClientDoc("Notice To Borrower Not In Special Flood Hazard Area", "^.*N[ODCQ][TI1][TI1][ODCQ]E\s*[TI1][ODCQ]\s*[B3][ODCQ]RR[ODCQ]WER\s*(?:[ODCQ]F\s*PR[ODCQ]PER[TI1][YV]\s*)*No[TI1]\s*[TI1]N\s*SPEC[TI1]AL FLOOD HAZARD AREA[\sI\.]*[\n\r]", "Notice_To_Borrower_Not_In_Special_Flood_Hazard_Area" & ".pdf", 0)) '1 page
        docs_to_find.Add(New ClientDoc("Lock Confirmation", "^Lock Confirmation((?!\s*Page\s*[2-9]\s*[of]*[\s\n\r$]+).)*$|[\n\r]Rate Lock Confirmation[\n\r]|[\n\r]Lock Confirmation[\n\r]", "Lock_Confirmation" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Home Mortgage Disclosure Act", "\b(Home Mortgage Disclosure Act)\b[\n\r]", "Home_Mortgage_Disclosure_Act" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("QM Findings", "^QM Findings[\n\r]", "QM_Findings" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Evidence Of Property Insurance", "EVIDENCE OF PROPERTY INSURANCE.*[\n\r]THIS IS EVIDENCE THAT INSURANCE AS IDENTIFIED BELOW HAS BEEN ISSUED, IN IN FORCE, AND CONVEYS ALL THE RIGHTS AND[\n\r]", "Evidence_Of_Property_Insurance" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Evidence Of Insurance", "[\n\r]EV[LI1]DENCE OF [LI1]NSUR.*ANCE[\n\r]+(PA[Y\/]MENT NOT[LI1]CE|Po[LI1][LI1]c[Y\/] Number).*Page\s*[1li]\s*[of]*[\s\n\r$]+", "Evidence_Of_Insurance" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Funding Suite", "^.*Funding Suite[\n\r].*BILL TO\:", "Funding_Suite" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Flood Cert Order Summary", "^.*FloodCe.*(Page\s*[1li]\s*[oftl]*\s*[0-9]*[\n\r]+Core Logic.*|[1li]\/[0-9]\s*)$", "FloodCert_Order_Summary" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Invoice", "([\n\r]INVO[IL1]CE[\n\r]+.*(Agency Code\:|Bill To\:))|(Invoice.*Client:.*Ordered By:)|(^Invoice.*Ordered\s*By\s*Deliver\s*To)", "Invoice" & ".pdf", 0))
        'docs_to_find.Add(New ClientDoc("Survey Ver #2", "^SURVEY", "Survey_Ver2" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("UW Terms And Conditions", "^.*[\n\r]UNDERWRITING TERMS AND CONDITIONS.*Page 1[\s\,].*", "UW_Terms_Conditions" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Underwriting Submission Checklist", "[\n\r]Underwr[tli][tli][tli]ng Subm[tli]ss[tli]on Check[tli][tli]s[tli][\n\r]", "Underwriting_Submission_Checklist" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Underwriting Decision", "([\n\r]Underwriting Decision[\n\r])|(U[nrls]*d[ea][nrls]*w[nrls]*[tié]+ng De[ca][tié]s[tié][oc][nrls]*.*(?:Prior to Doc condition|Prior to Funding condition))", "Underwriting_Decision" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Policy Notices", "[\n\r]Policy Notices((?!\(Continued\)).)*$", "Policy_Notices" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Nearest Living Relative Not Living With You", "[\n\r]NEAREST LIVING RELATIVE[\n\r]", "Nearest_Living_Relative_Not_Living_With_You" & ".pdf", 0)) '1 page
        docs_to_find.Add(New ClientDoc("Special Warranty Deed", "([\n\r]SPECIAL WARRANTY DEED WITH VENDOR'S LIEN[\n\r].*Page\s*[1li]\s*[of]*[\s\n\r$]+)|((SPECIAL WARRANTY|WARRANTY DEED).*[\n\r].*(WITH THIRD PARTY|THIRD PARTY VENDER|VENDER\'S LIEN))", "Special_Warranty_Deed" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("General Warranty Deed", "[\n\r]GENERAL WARRANTY DEED[\n\r]", "General_Warranty_Deed" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Warranty Deed with Vendor's Lien", "[\n\r]Warranty Deed with Vendor's Lien[\n\r]", "Warranty_Deed_with_Vendors_Lien" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Deed Of Trust", "[\n\r]DEED OF TRUST[\n\r]", "Deed Of Trust" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Mortgage Credit Report", "^[\sI]*By\s*Covius\s*Mortgage\s*Solutions\,\s*LLC\s*Mortgage\s*Credit\s*Report[\sI]*[\n\r]", "Mortgage_Credit_Report" & ".pdf", 0)) '9 pages
        docs_to_find.Add(New ClientDoc("Risk Based Pricing Disclosure", "^Risk Based Pricing Disclosure[\n\r]", "Risk_Based_Pricing_Disclosure" & ".pdf", 0)) '1 page
        docs_to_find.Add(New ClientDoc("Customer Identification Form", "Customer [li]dent[li]f[li]cat[li]on Form", "Customer_Identification_Form" & ".pdf", 0)) '2 pages
        docs_to_find.Add(New ClientDoc("Consumer Explanation Letter", "[\n\r][\sI]*C[COQD]N[AES]UMER EXPLANATI[COQD]N L[AES]TT[AES]R[\sI]*[\n\r]", "Consumer_Explanation_Letter" & ".pdf", 0)) '1 page
        docs_to_find.Add(New ClientDoc("Addendum For Sale Of Other Property By Buyer", "ADDENDUM FOR[\sI]*[\n\r][\sI]*SALE OF OTHER PROPERTY BY BUYER[\sI]*[\n\r]", "Adnm_For_Sale_Other_Property_By_Buyer" & ".pdf", 0)) '1 page
        docs_to_find.Add(New ClientDoc("Notice to a Purchaser of Real Property in a Water District", "Notice to a Purchaser of Real Property in a Water District[LI1\s\,\.]*[\n\r]", "Notice_to_Purchaser_of_Real_Property_in_Water_District" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Disclosure of Relationship With Residential Service Company", "Disclosure of Relationship[\sI]*[\n\r].*With Residential Service Company[\sI]*[\n\r]", "Disclosure_of_Relationship_With_Residential_Service_Company" & ".pdf", 0)) '1 page
        docs_to_find.Add(New ClientDoc("Rebate Agreement", "[\n\r][\sI]*Rebate Agreement[\sI]*[\n\r]", "Rebate_Agreement" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Settlement Services Provider List", "[\n\r]SETTLEMENT SERVICES PROVIDER LIST[\n\r]", "Settlement_Services_Provider_List" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Title Residential Information Services", "Title Residential Information Services[\n\r].*Installment", "Title_Residential_Information_Services" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Closing Protection Letter", "[\n\r]Re\:\s*Closing Protection Letter[\n\r]", "Closing_Protection_Letter" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Factual Data Charges", "^Factual Data Charges", "Factual_Data_Charges" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Factual Data Credit Score", "[\n\r]FACTUAL DATA.*Credit Score Information", "Factual_Data_Credit_Score" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Fax Server", "Fax Ser[vu]er.*(?:To:|Page\s*(0|El)+1\s*[of]*[\s\n\r$]+)", "Fax_Server" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Individual Condominium Unit Appraisal Report", "[\n\r]Individual Condominium Unit Appraisal Report.*Page\s*[1li]\s*[of]*[\s\n\r$]+", "Individual_Condominium_Unit_Appraisal_Report" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Uniform Appraisal Dataset Definitions", "[\n\r]Uniform Appraisal Dataset Definitions", "Uniform_Appraisal_Dataset_Definitions" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Addendum", "^Addendum[\n\r].*Page\s*[1li]\s*[of]*[\s\n\r$]+", "Addendum" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Market Conditions Addendum to the Appraisal Report", "[\n\r]Market Conditions Addendum to the Appraisal Report.*Page\s*[1li]\s*[of]*[\s\n\r$]+", "Market_Conditions_Adnm_Appraisal_Report" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Subject Property Photo Addendum", "^Subject Property Photo Addendum[\n\r]", "Subject_Property_Photo_Addendum" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Location Map", "^Location Map[\n\r]", "Location_Map" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Comparable Property Photo Addendum", "^Comparable Property Photo Addendum[\n\r]", "Comparable_Property_Photo_Adnm" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Floorplan Sketch", "^Floorplan Sketch[\n\r]", "Floorplan_Sketch" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Appraisal And Valuation Professional Liability Insurance Policy", "[\n\r]PROFESS[LI1]ONAL L[LI1]AB[LI1]L[LI1]T[Y\\] [LI1]NSURANCE PO[LI1][LI1]C[Y\\]", "Appraisal_Valuation_Professional_Liability_Insurance_Policy" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Aerial Map", "^Aerial Map[\n\r]", "Aerial_Map" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Payment Via Real Time Solutions", "[\n\r]Your offer of .* \(the \""Payment\""\) in the form of.* will be accepted by Real Time", "Payment_Via_Real_Time_Solutions" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Specialized Loan Servicing", "[\n\r]LOAN INFORMATION[\n\r].*Specialized Loan Servicing", "Specialized_Loan_Servicing" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Loan Estimate Changed Circumstance", "[\n\r]Loan Estimate Changed Circumstance[\n\r]", "Loan_Estimate_Changed_Circumstance" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("DocMagic eSign Certificate", "DocMagic eSign Certificate[\n\r]", "DocMagic_eSign_Certificate" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Payoffs and Adjustments", "^[\sIL1.]*Payoffs and Adjustments[\sIL1.]*[\n\r]", "Payoffs_and_Adjustments" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("FHA Connection", "FHA Connection[\n\r]", "FHA_Connection" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Notice of Request for VA Appraisal", "[\n\r]\s*Notice of Request for VA Appraisal\s*[\n\r]", "Notice_of_Request_for_VA_Appraisal" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Lender's Notice of Value", "[\n\r][\s_]*L[\s_]*[E§S][\s_]*n[\s_]*d[\s_]*[E§S][\s_]*r[\s_\']*s[\s_]*N[\s_]*o[\s_]*t[\s_]*[LI1][\s_]*c[\s_]*[E§S][\s_]*O[\s_]*f[\s_]*V[\s_]*a[\s_]*[LI1][\s_]*u[\s_]*[E§S][\s_]*[\n\r]", "Lenders_Notice_of_Value" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Statement of Account Status", "^[\s_]*Statement of Account Status[\s_]*[\n\r]", "Statement_of_Account_Status" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Direct Endorsement Approval for a HUD/FHA-Insured Mortgage", "^((?!Borrower[']*s[']* Certification).)*[\n\r]Direct Endorsement Approval for a HUD[\/LI1]FHA[\-_]Insured Mortgage", "Direct_Endorsement_Approval_HUD_FHA_Insured_Mortgage" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Waiver of Advance Delivery of Appraisal", "[\n\r]\s*Waiver of Advance Delivery of Appraisal\s*[\n\r]", "Waiver_of_Advance_Delivery_of_Appraisal" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Affiliated Business Arrangement Disclosure Statement", "[\n\r]AFFILIATED BUSINESS ARRANGEMENT DISCLOSURE STATEMENT[\n\r]", "Affiliated_Business_Arrangement_Disclosure_Statement" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Title Insurance Information", "TITLE I*NSURANCE I*NFORMATION[\n\r]((?!\(Continued\)).)*$", "Title_Insurance_Information" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Title Database", "PAGE.\s*\:\s*1[\n\r]+RUN\s*DATE\s*\:[0-9\/\s]+.*TITLE DATABASE", "Title_Database" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Closing Disclosure - Attachment", "^.*Closing Disclosure - Attachment[\n\r]", "Closing_Disclosure_Attachment" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Suntrust Mortgage Verification Of Self Employment", "^SUNTRUST MORTGAGE VERIFICATION OF SELF EMPLOYMENT", "Suntrust_Mortgage_Verification_Of_Self_Employment" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Franchise Tax Account Status", "[\n\r]Franchise Tax Account Status[\n\r]", "Franchise_Tax_Account_Status" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Public Information Report", "[\n\r]Public Information Report[\n\r]", "Public_Information_Report" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Wire Fraud Alert", "[\n\r]WIRE FRAUD ALERT[\n\r]", "Wire_Fraud_Alert" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Rate Spread Calculator", "[\n\r]Rate Spread Calculator[\n\r]", "Rate_Spread_Calculator" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Amendment", "(^|[\n\r])[PF]ROMULGATED BY THE TEXAS REAL ESTATE COMMISSION.*[\n\r]AMENDMENT", "Amendment" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("e-Filed & e-Recorded", "e[\-_]Filed \& e[\-_]Recorded in the[\n\r]+.*Official Public Records of|[\n\r]Electronically Filed and Recorded[\n\r]", "eFiled_and_eRecorded" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Planned Unit Development Rider", "[\n\r]PLANNED UNIT DEVELOPMENT RIDER[\n\r]", "Planned_Unit_Development_Rider" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Farmers Value Insurance Package", "Farmers Value Insurance Package.*Agent\s*:", "Farmers_Value_Insurance_Package" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Appraisal Services Summary", "[\n\r]APPRAISAL SERVICES SUMMARY[\n\r]", "Appraisal_Services_Summary" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Consumer Explanation Letter", "[\n\r]CONSUME[TR] EXPLANA[TR]ION LE[TR][TR]E[TR]", "Consumer_Explanation_Letter" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Policy Declarations", "[\n\r]POLICY DECLARATIONS[\n\r]", "Policy_Declarations" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Standard Report", "^Standard Report", "Standard_Report" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Applicant Credit Disclosure", "[\n\r]App[LI1!][LI1!]can[TR] C[TR]ed[LI1!][TR] [DOQ][LI1!]sc[LI1!]osu[TR]*[E8][\n\r]", "Applicant_Credit_Disclosure" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Certificate Of Liability Insurance", "CERTIFICATE OF LIABILITY INSURANCE", "Certificate_Of_Liability_Insurance" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Title Agent Certificate Of License", "[\n\r]TITLE AGENT CERTIFICATE OF LICENSE[\n\r]", "Title_Agent_Certificate_Of_License" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Escrow Officer Certificate Of License", "[\n\r]ESCROW OFFICER CERTIFICATE OF LICENSE[\n\r]", "Escrow_Officer_Certificate_Of_License" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Avoid Mortgage Closing Scams", "Prevent email phishing scams\s*:\s*What to do if you are a victim\s*:\s*[\n\r]", "Avoid_Mortgage_Closing_Scams" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Bexar CAD", "[\n\r]Bexar CAD[\n\r]", "Bexar_CAD" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Verification Services", "VERIFICATION SERVICES[\n\r].*[1li]\/[0-9]\s*$", "Verification_Services" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Company Profile", "[\n\r]Company Profile[\n\r]", "Company_Profile" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Advantage Solutions and Daymon Worldwide Announce Partnership", "[\n\r]Advantage Solutions and Daymon[\n\r]+Worldwide Announce Partnership[\n\r]", "Advantage_Solutions_Daymon_Worldwide_Announce_Partnership" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("TRN Financial Mail", "TRN Financial Mail.*(Page\s*[1li]\s*[of]*[\s\n\r$]+|[1li]\/[0-9]\s*$)|(Page\s*[1li]\s*[of]*[\s\n\r]+.*TRN Financial Mail)", "TRN_Financial_Mail" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Tax Roll Inquiry", "(^|[\n\r])Tax Roll [IR]nquiry[\n\r]", "Tax_Roll_Inquiry" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Title Guaranty Company", "^((?!([\n\r]RE\s*[\:\']\s*Insured\s*Closing\s*Service)|(Form T-50: Insured Closing Service)).)*Title Guaranty Company[\n\r]((?!([\n\r]RE\s*[\:\']\s*Insured\s*Closing\s*Service)|(Form T-50: Insured Closing Service)).)*$", "Title_Guaranty_Company" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Insured Closing Service", "([\n\r]RE\s*[\:\']\s*Insured\s*Closing\s*Service)|(Form T-50: Insured Closing Service((?!\s*Page\s*[2-9]\s*[of]*[\s\n\r$]+).)*$)", "Insured_Closing_Service" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("U.S. Return of Partnership Income", "U.S. Return of Partnership Income", "US_Return_of_Partnership_Income" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("U.S. Individual Income Tax Return", "U.S. Individual Income Tax Return", "US_Individual_Income_Tax_Return" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Payoff Statement Form", "^PAYOFF STATEMENT FORM[\n\r]", "Payoff_Statement_Form" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Notice Concerning Refinance Of Existing Home Equity Loan To Non-Home Equity Loan", "NOTICE CONCERNING REFINANCE OF EXISTING HOME EQUITY[\n\r]+LOAN TO NON-HOME EQUITY LOAN", "Notice_Concerning_Refinance_Of_Existing_Home_Equity_Loan_To_Non_Home_Equity_Loan" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Tangible Net Benefit To Borrower Worksheet", "[\n\r]TANGIBLE NET BENEFIT TO BORROWER WORKSHEET[\n\r]", "Tangible_Net_Benefit_To_Borrower_Worksheet" & ".pdf", 0))
        docs_to_find.Add(New ClientDoc("Buyer and Seller Disclosure Sheet", "[\n\r]Buyer and Seller Disclosure Sheet[\n\r]", "Buyer_and_Seller_Disclosure_Sheet" & ".pdf", 0))


        '---Willie: Edited ones.  Make sure they don't return false positives and past captures are still correct.
        docs_to_find.Add(New ClientDoc("Wire Instructions", "[\n\r]\s*(W[IL1!]R[IL1!]NG|W[IL1!]R[E38]) [IL1!]NS[TIL1!]RU[CD][TIL1!][IL1!][O0CDQ]NS\s*[\n\r]", "Wire_Instructions" & ".pdf", 0))
        'Commitment For Title Insurance, which is part of a group above.
        'Schedule A, B, C, and D
        'Invoice
        'Notice to the Home Loan Applicant
        'DEPARTMENT OF VETERANS AFFAIRS
        'Borrower's Acknowledgement Of Disclosures
        'Electronic Record and Signature Disclosure
        'Legal Description


    End Sub
    ' -------------------------------------------------- end of HELPER FUNCTIONS --------------------------------------------------


    Class ClientDoc
        Public _name As String
        Public _pattern As String
        Public _file_name As String
        Public _number_of_matches As Integer

        Public Sub New()
            _number_of_matches = 0
        End Sub

        Public Sub New(ByVal name As String, ByVal pattern As String, ByVal file_name As String, ByVal number_of_matches As Integer)
            _name = name
            _pattern = pattern
            _file_name = file_name
            _number_of_matches = number_of_matches
        End Sub

        Public Overrides Function ToString() As String
            If _number_of_matches = 1 Then
                Return " - " & _name
            Else
                Return " - " & _name & " " & _number_of_matches
            End If
        End Function
    End Class


End Class
