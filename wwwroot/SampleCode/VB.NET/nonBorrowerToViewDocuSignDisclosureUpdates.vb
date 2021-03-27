//1.  Instead of adding the user/borrower as a signer, add as a view-only. Incorporated code into existing code:
If Len(strName) > 0 And Len(strEmail) > 0 Then
    If Not strSigner Then 'Add Signer as CC only
        AddRecipientAsCCToEnvelope(envDef, strName, strEmail, n, n) 'Add the Recipient to the CarbonCopies
    ElseIf ...etc...



//2.  Function that adds the user to DocuSign object in order to send to them via web services. Researched DocuSign's API and found CarbonCopies collection:
''' <summary>
''' If the DocuSign envelope's CarbonCopies list DNE, then it creates it and adds the recipient to DocuSign's CarbonCopies list.
''' </summary>
''' <param name="envDef">By Ref</param>
''' <param name="name"></param>
''' <param name="email"></param>
''' <param name="someField3"></param>
''' <param name="RecipientId"></param>
Private Sub AddRecipientAsCCToEnvelope(ByRef envDef As EnvelopeDefinition, ByVal name As String, ByVal email As String, ByVal someField3 As String, ByVal RecipientId As String)
    Dim oCC As CarbonCopy
    oCC = New CarbonCopy
    oCC.Name = name
    oCC.Email = email
    oCC.someField3 = someField3
    oCC.RecipientId = RecipientId

    If envDef.Recipients.CarbonCopies Is Nothing Then
        envDef.Recipients.CarbonCopies = New Collections.Generic.List(Of CarbonCopy) 'Create the CarbonCopies obj
    End If

    envDef.Recipients.CarbonCopies.Add(oCC)
End Sub



//3.  Send to DocuSign and run any code after confirmation received from them:
Try
    ' Use the EnvelopesApi to send the signature request! 
    Dim envelopesApi As New EnvelopesApi()
    Dim envelopeSummary As EnvelopeSummary = envelopesApi.CreateEnvelope(AccountId, envDef)
    Dim SignerNumber As Integer = 0
    Dim EnvelopeId As String
    Dim ReturnURL As ReturnUrlRequest
    Dim SenderView As ViewUrl

    EnvelopeId = envelopeSummary.EnvelopeId

    Dim oRecipients As Recipients
    oRecipients = envelopesApi.ListRecipients(AccountId, EnvelopeId)

    ReturnURL = New ReturnUrlRequest

    If Len(someField) > 0 Then
        ReturnURL.ReturnUrl = "https://www.myWebsite.com/default.aspx?sent=true"
    Else
        ReturnURL.ReturnUrl = "https://www.myWebsite.com/default.aspx?sent=true"
    End If

    SenderView = envelopesApi.CreateSenderView(AccountId, EnvelopeId, ReturnURL)

    If Len(SenderView.Url) > 0 Then

        Dim oSomeObject As zSomeClassClass
        oSomeObject = New someProject.zSomeClassClass()
        With oSomeObject
            .someField3 = "" ' will set after it comes back completed
            .someField = someField
            .someField2 = someField2
            .EnvelopeId = envelopeSummary.EnvelopeId
            .Sender.Email = txtSenderEmail.Text.Trim
            .Sender.Contact = txtSenderName.Text.Trim
            .Status = envelopeSummary.Status

            For Each oeSigner As Signer In oRecipients.Signers
                Dim oUserSigner As New someNameClass
                SignerNumber += 1
                oUserSigner.SignerName = oeSigner.Name
                oUserSigner.SignerEmail = oeSigner.Email
                oUserSigner.SignerCode = oeSigner.AccessCode
                oUserSigner.SignerGuid = oeSigner.RecipientIdGuid
                oUserSigner.RequireSignatureYN = True
                ' no anchor
                .Signers.Add(oUserSigner, "Signer" & SignerNumber)
            Next
        End With

        Dim oSomeObjects As New someProject.zDisclosureCollection
        If oSomeObjects.Insert(oSomeObject) Then
            Response.Redirect(SenderView.Url, False)
            System.Web.HttpContext.Current.ApplicationInstance.CompleteRequest()
        End If

    Else
        lblOutput.Text = envelopeSummary.Status
    End If
Catch ex As DocuSign.eSign.Client.ApiException
    Select Case ex.ErrorCode
        Case 400
            If ex.Message.Contains("PDF_VALIDATION_FAILED") Then
                lblOutput.Text = "At least one of the documents in the package does not appear to be a valid file.  Please remove from the package and try again."
            Else
                lblOutput.Text = "At least one of the esign recipient does not have a signature line in this package.  Please remove the recipient or recreate a new package with signature lines for them to sign.  You can also add a carbon copy recipient later once submitted to DocuSign."
            End If

        Case Else
            lblOutput.Text = ex.Message
    End Select

End Try