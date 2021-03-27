//1.  Use my Nutshell class to execute web service call and Get/Send data to Nutshell.com
' *************************************************************************************************
' Add user to Nutshell via JSON-RPC
' *************************************************************************************************

Dim newCompany As New Nutshell.Company()
newCompany.name = SomeClass.TheClient.Company

Dim newContact As New Nutshell.Contact()
newContact.name = NewUser.FirstName & " " & NewUser.LastName
newContact.address = { New Nutshell.Address(txtAddress1.Text, txtAddress2.Text, txtCity.Text, txtState.Text, txtZipCode.Text)}
newContact.email = { txtEMail.Text}
Dim phone = "1" & txtPhone.Text
newContact.phone = If(txtExt.Text = "", {phone}, { phone & " Ext." & txtExt.Text})

Dim exists = Nutshell_Get_Company(newCompany)
If Not exists Then
	Nutshell_Create_Company(newCompany)
End If

Dim newAccount() = { New Nutshell.Account(newCompany.id)}
newContact.accounts = newAccount

exists = Nutshell_Get_Contact(newCompany, newContact)
If Not exists Then
	Nutshell_Create_Contact(newContact)
End If

Dim newAssignee As New Nutshell.Assignee("Users", someIntergerHere) 'My Nutshell Id
Dim LOS As String = If(someWebControl.SelectedItem.Value <> "Other", someWebControl.SelectedItem.Value, someWebControl.SelectedItem.Value & " " & txtLOSOther.Text)
Dim newCustomField As New Nutshell.LOS(LOS)

Dim newLead As New Nutshell.Lead(newContact.name, newAssignee, newAccount, {newContact}, "Created via Registration Page", newCustomField)
Nutshell_Create_Lead(newLead)



//2.  Nutshell Class
Imports System.IO
Imports System.Net
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Json


' Helpful websites:
' -	Convert JSON to C# classes - https://app.quicktype.io/#l=cs&r=json2csharp
' - http://how2doinvbdotnet.blogspot.com/2015/07/send-http-json-post-request-online.html


' -------------------------------------------------- Nutshell Commands --------------------------------------------------
Public Module NutshellCommands

	Public Function Nutshell_Get_Company(ByRef newCompany As Nutshell.Company) As Boolean
		Dim NutshellURL As String = "https://app.nutshell.com/api/v1/json"

		'Create new local Nutshell object
		Dim data As New Nutshell.Search
		data.id = "GetCompany"
		data.method = "searchAccounts"
		data.params.string = newCompany.name

		'Create new local serialized data
		Dim stream As MemoryStream = New MemoryStream
		Dim ser As DataContractJsonSerializer = New DataContractJsonSerializer(data.GetType)
		ser.WriteObject(stream, data)
		stream.Position = 0
		Dim SR As StreamReader = New StreamReader(stream)
		Dim JsonData As String = SR.ReadToEnd()

		'Execute the POST JSON-RPC
		Dim request_Nutshell_GetData As HttpWebRequest = PostJSON(NutshellURL, JsonData.ToString)

		'Populate the JSON-RPC data into NutshellCompanyId
		Return response_Nutshell_Get_Company(request_Nutshell_GetData, newCompany)
	End Function

	Private Function response_Nutshell_Get_Company(ByVal httpWebRequest As HttpWebRequest, ByRef newCompany As Nutshell.Company) As String
		Try
			'Create new local Nutshell object and populate it with Nutshell's serialized data
			Dim httpResponse = DirectCast(httpWebRequest.GetResponse(), HttpWebResponse)
			Using stream = httpResponse.GetResponseStream()
				Dim data As New Nutshell.GetCompanyResults()
				Dim ser As DataContractJsonSerializer = New DataContractJsonSerializer(data.GetType)
				data = ser.ReadObject(stream)

				Dim iCompanyId, iCompanyName As String
				For Each company As Nutshell.Company In data.result
					iCompanyId = company.id
					iCompanyName = company.name

					If iCompanyName = newCompany.name Then
						newCompany.id = iCompanyId
						Return True
					End If
				Next
			End Using
		Catch ex As Exception
			Console.WriteLine("GetResponse Error[{0}]", ex.Message)

			Return False
		End Try

		Return False
	End Function


	Public Function Nutshell_Create_Company(ByRef newCompany As Nutshell.Company) As Boolean
		Dim NutshellURL As String = "https://app.nutshell.com/api/v1/json"

		'Create new local Nutshell object
		Dim data As New Nutshell.CreateCompany
		data.id = "NewCompany"
		data.method = "newAccount"
		data.params(0) = newCompany

		'Create new local serialized data
		Dim stream As MemoryStream = New MemoryStream
		Dim ser As DataContractJsonSerializer = New DataContractJsonSerializer(data.GetType)
		ser.WriteObject(stream, data)
		stream.Position = 0
		Dim SR As StreamReader = New StreamReader(stream)
		Dim JsonData As String = SR.ReadToEnd() '"{" & SR.ReadToEnd() & "}"

		'Execute the POST JSON-RPC
		Dim request_Nutshell_GetData As HttpWebRequest = PostJSON(NutshellURL, JsonData.ToString)

		'Populate the JSON-RPC data into NutshellCompanyId
		Return response_Nutshell_Create_Company(request_Nutshell_GetData, newCompany)
	End Function

	Private Function response_Nutshell_Create_Company(ByVal httpWebRequest As HttpWebRequest, ByRef newCompany As Nutshell.Company) As Boolean
		Try
			'Create new local Nutshell object and populate it with Nutshell's serialized data
			Dim httpResponse = DirectCast(httpWebRequest.GetResponse(), HttpWebResponse)
			Using stream = httpResponse.GetResponseStream()
				Dim data As New Nutshell.GetGenericResults
				Dim ser As DataContractJsonSerializer = New DataContractJsonSerializer(data.GetType)
				data = ser.ReadObject(stream)

				newCompany.id = data.result.id

				If IsNumeric(newCompany.id) Then
					Return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Console.WriteLine("GetResponse Error[{0}]", ex.Message)

			Return False
		End Try

		Return False
	End Function


	Public Function Nutshell_Get_Contact(ByRef newCompany As Nutshell.Company, ByRef newContact As Nutshell.Contact) As Boolean
		Dim NutshellURL As String = "https://app.nutshell.com/api/v1/json"

		'Create new local Nutshell object
		Dim data As New Nutshell.Search
		data.id = "GetContact"
		data.method = "searchContacts"
		data.params.string = newContact.name

		'Create new local serialized data
		Dim stream As MemoryStream = New MemoryStream
		Dim ser As DataContractJsonSerializer = New DataContractJsonSerializer(data.GetType)
		ser.WriteObject(stream, data)
		stream.Position = 0
		Dim SR As StreamReader = New StreamReader(stream)
		Dim JsonData As String = SR.ReadToEnd()

		'Execute the POST JSON-RPC
		Dim request_Nutshell_GetData As HttpWebRequest = PostJSON(NutshellURL, JsonData.ToString)

		'Populate the JSON-RPC data into NutshellContactId and NutshellCompanyId
		Return response_Nutshell_Get_Contact(request_Nutshell_GetData, newCompany, newContact)
	End Function

	Private Function response_Nutshell_Get_Contact(ByVal httpWebRequest As HttpWebRequest, ByRef newCompany As Nutshell.Company, ByRef newContact As Nutshell.Contact) As Boolean
		Try
			'Create new local Nutshell object and populate it with Nutshell's serialized data
			Dim httpResponse = DirectCast(httpWebRequest.GetResponse(), HttpWebResponse)
			Using stream = httpResponse.GetResponseStream()
				Dim data As New Nutshell.GetContactResults
				Dim ser As DataContractJsonSerializer = New DataContractJsonSerializer(data.GetType)
				data = ser.ReadObject(stream)

				Dim iContactId, iContactName, iJobTitle As String
				For Each contact As Nutshell.Contact In data.result
					iContactId = contact.id
					iContactName = contact.name
					iJobTitle = contact.jobTitle

					If iContactName = newContact.name And iJobTitle = newCompany.name Then
						newContact.id = iContactId
						Return True
					End If
				Next
			End Using
		Catch ex As Exception
			Console.WriteLine("GetResponse Error[{0}]", ex.Message)

			Return False
		End Try

		Return False
	End Function


	Public Function Nutshell_Create_Contact(ByRef newContact As Nutshell.Contact) As Boolean
		Dim NutshellURL As String = "https://app.nutshell.com/api/v1/json"

		'Create new local Nutshell object
		Dim data As New Nutshell.CreateContact
		data.id = "NewContact"
		data.method = "newContact"
		data.params(0) = newContact

		'Create new local serialized data
		Dim stream As MemoryStream = New MemoryStream
		Dim ser As DataContractJsonSerializer = New DataContractJsonSerializer(data.GetType)
		ser.WriteObject(stream, data)
		stream.Position = 0
		Dim SR As StreamReader = New StreamReader(stream)
		Dim JsonData As String = SR.ReadToEnd()

		'Execute the POST JSON-RPC
		Dim request_Nutshell_GetData As HttpWebRequest = PostJSON(NutshellURL, JsonData.ToString)

		'Populate the JSON-RPC data into NutshellCompanyId
		Return response_Nutshell_Create_Contact(request_Nutshell_GetData, newContact)
	End Function

	Private Function response_Nutshell_Create_Contact(ByVal httpWebRequest As HttpWebRequest, ByRef newContact As Nutshell.Contact) As Boolean
		Try
			'Create new local Nutshell object and populate it with Nutshell's serialized data
			Dim httpResponse = DirectCast(httpWebRequest.GetResponse(), HttpWebResponse)
			Using stream = httpResponse.GetResponseStream()
				Dim data As New Nutshell.GetGenericResults
				Dim ser As DataContractJsonSerializer = New DataContractJsonSerializer(data.GetType)
				data = ser.ReadObject(stream)

				newContact.id = data.result.id

				If IsNumeric(newContact.id) Then
					Return True
				Else
					Return False
				End If
			End Using
		Catch ex As Exception
			Console.WriteLine("GetResponse Error[{0}]", ex.Message)

			Return False
		End Try

		Return False
	End Function


	Public Function Nutshell_Create_Lead(ByVal newLead As Nutshell.Lead) As Boolean
		Dim NutshellURL As String = "https://app.nutshell.com/api/v1/json"

		'Create new local Nutshell object
		Dim data As New Nutshell.CreateLead
		data.id = "NewLead"
		data.method = "newLead"
		data.params(0) = newLead

		'Create new local serialized data
		Dim stream As MemoryStream = New MemoryStream
		Dim ser As DataContractJsonSerializer = New DataContractJsonSerializer(data.GetType)
		ser.WriteObject(stream, data)
		stream.Position = 0
		Dim SR As StreamReader = New StreamReader(stream)
		Dim JsonData As String = SR.ReadToEnd()

		'Execute the POST JSON-RPC
		Dim request_Nutshell_GetData As HttpWebRequest = PostJSON(NutshellURL, JsonData.ToString)

		'Execute the JSON-RPC request in order to create Lead
		Return response_Nutshell_Create_Lead(request_Nutshell_GetData)
	End Function

	Private Function response_Nutshell_Create_Lead(ByVal httpWebRequest As HttpWebRequest) As Boolean
		Try
			'Create new local Nutshell object and populate it with Nutshell's serialized data
			Dim httpResponse = DirectCast(httpWebRequest.GetResponse(), HttpWebResponse)
			httpResponse.GetResponseStream()

			Return True
		Catch ex As Exception
			Console.WriteLine("GetResponse Error[{0}]", ex.Message)

			Return False
		End Try

		Return False
	End Function


	'GENERIC VERSION
	Private Function PostJSON(ByVal url As String, ByVal JsonData As String) As HttpWebRequest
		Dim objhttpWebRequest As HttpWebRequest
		Try
			Dim httpWebRequest = DirectCast(WebRequest.Create(url), HttpWebRequest)
			httpWebRequest.ContentType = "application/json-rpc" '"application/json"
			httpWebRequest.Method = "POST"
			httpWebRequest.Credentials = New NetworkCredential(System.Configuration.ConfigurationManager.AppSettings("myNutshellEmailRef"), System.Configuration.ConfigurationManager.AppSettings("myNutshellKeyRef"))

			Using streamWriter = New StreamWriter(httpWebRequest.GetRequestStream())
				streamWriter.Write(JsonData)
				streamWriter.Flush()
				streamWriter.Close()
			End Using

			objhttpWebRequest = httpWebRequest

		Catch ex As Exception
			Console.WriteLine("Send Request Error[{0}]", ex.Message)

			Return Nothing
		End Try

		Return objhttpWebRequest
	End Function
End Module
' -------------------------------------------------- end of Nutshell Commands --------------------------------------------------



' -------------------------------------------------- Nutshell Objects --------------------------------------------------
Public Class Nutshell

	' ----------------------------------------- root JSON (commands) -----------------------------------------
	<DataContract>
	Public Class CreateCompany
		<DataMember>
		Private Property jsonrpc As String = "2.0"
		<DataMember>
		Public Property method As String
		<DataMember>
		Private Property username As String = System.Configuration.ConfigurationManager.AppSettings("myNutshellEmailRef")
		<DataMember>
		Private Property api As String = System.Configuration.ConfigurationManager.AppSettings("myNutshellKeyRef")
		< DataMember >
		Public Property id As String

		Private _params(0) As Company

		<DataMember>
		Public Property params () As Company()
			Get
				Return _params
			End Get
			Set(ByVal value() As Company)
				_params = value
			End Set
		End Property

		Public Property paramsItem(ByVal i As Integer) As Object
			Get
				Return _params(i)
			End Get
			Set(ByVal value As Object)
				_params(i) = value
			End Set
		End Property
	End Class

	<DataContract>
	Public Class CreateContact
		<DataMember>
		Private Property jsonrpc As String = "2.0"
		<DataMember>
		Public Property method As String
		<DataMember>
		Private Property username As String = System.Configuration.ConfigurationManager.AppSettings("myNutshellEmailRef")
		<DataMember>
		Private Property api As String = System.Configuration.ConfigurationManager.AppSettings("myNutshellKeyRef")
		< DataMember >
		Public Property id As String

		Private _params(0) As Contact

		<DataMember>
		Public Property params () As Contact()
			Get
				Return _params
			End Get
			Set(ByVal value() As Contact)
				_params = value
			End Set
		End Property

		Public Property paramsItem(ByVal i As Integer) As Object
			Get
				Return _params(i)
			End Get
			Set(ByVal value As Object)
				_params(i) = value
			End Set
		End Property
	End Class

	<DataContract>
	Public Class CreateLead
		<DataMember>
		Private Property jsonrpc As String = "2.0"
		<DataMember>
		Public Property method As String
		<DataMember>
		Private Property username As String = System.Configuration.ConfigurationManager.AppSettings("myNutshellEmailRef")
		<DataMember>
		Private Property api As String = System.Configuration.ConfigurationManager.AppSettings("myNutshellKeyRef")
		< DataMember >
		Public Property id As String

		Private _params(0) As Lead

		<DataMember>
		Public Property params () As Lead()
			Get
				Return _params
			End Get
			Set(ByVal value() As Lead)
				_params = value
			End Set
		End Property

		Public Property paramsItem(ByVal i As Integer) As Object
			Get
				Return _params(i)
			End Get
			Set(ByVal value As Object)
				_params(i) = value
			End Set
		End Property
	End Class

	Public Class GetGenericResults
		Public result As Result
	End Class

	Public Class GetCompanyResults
		Private _result(0) As Company

		<DataMember>
		Public Property result() As Company()
			Get
				Return _result
			End Get
			Set(ByVal value() As Company)
				_result = value
			End Set
		End Property

		Public Property resultItem(ByVal i As Integer) As Object
			Get
				Return _result(i)
			End Get
			Set(ByVal value As Object)
				_result(i) = value
			End Set
		End Property

		Public Sub New()
			_result(0) = New Company()
		End Sub
	End Class

	Public Class GetContactResults
		Private _result(0) As Contact

		<DataMember>
		Public Property result() As Contact()
			Get
				Return _result
			End Get
			Set(ByVal value() As Contact)
				_result = value
			End Set
		End Property

		Public Property resultItem(ByVal i As Integer) As Object
			Get
				Return _result(i)
			End Get
			Set(ByVal value As Object)
				_result(i) = value
			End Set
		End Property

		Public Sub New()
			_result(0) = New Contact()
		End Sub
	End Class

	<DataContract>
	Public Class Search
		<DataMember>
		Private Property jsonrpc As String = "2.0"
		<DataMember>
		Public Property method As String
		<DataMember>
		Private Property username As String = System.Configuration.ConfigurationManager.AppSettings("myNutshellEmailRef")
		<DataMember>
		Private Property api As String = System.Configuration.ConfigurationManager.AppSettings("myNutshellKeyRef")
		< DataMember >
		Public Property id As String
		<DataMember>
		Public Property params As New StringClass
	End Class
	' ----------------------------------------- end of root JSON (commands) -----------------------------------------


	' -------------------------------------------------- OBJS --------------------------------------------------
	<DataContract>
	Public Class Account
		<DataMember>
		Public Property id As String

		Public Sub New()
		End Sub

		Public Sub New(ByVal id As String)
			Me.id = id
		End Sub
	End Class

	<DataContract>
	Public Class Address
		<DataMember>
		Public Property address_1 As String
		<DataMember>
		Public Property address_2 As String
		<DataMember>
		Public Property city As String
		<DataMember>
		Public Property state As String
		<DataMember>
		Public Property postalCode As String

		Public Sub New(ByVal address_1 As String, ByVal address_2 As String, ByVal city As String, ByVal state As String, ByVal postalCode As String)
			Me.address_1 = address_1
			Me.address_2 = address_2
			Me.city = city
			Me.state = state
			Me.postalCode = postalCode
		End Sub
	End Class

	<DataContract>
	Public Class Assignee
		<DataMember>
		Public Property entityType As String
		<DataMember>
		Public Property id As Integer

		Public Sub New(ByVal entityType As String, ByVal id As Integer)
			Me.entityType = entityType
			Me.id = id
		End Sub
	End Class

	<DataContract>
	Public Class Company

		<DataMember(IsRequired:= False, EmitDefaultValue:= False)>
		  Public Property id As String
		<DataMember(IsRequired:= False, EmitDefaultValue:= False)>
		  Public Property name As String


		Public Sub New()
		End Sub

		Public Sub New(ByVal id As String)
			Me.id = id
		End Sub
	End Class

	<DataContract>
	Public Class Contact

		<DataMember(IsRequired:= False, EmitDefaultValue:= False)>
		  Public Property id As String
		<DataMember(IsRequired:= False, EmitDefaultValue:= False)>
		  Public Property jobTitle As String
		<DataMember(IsRequired:= False, EmitDefaultValue:= False)>
		  Public Property name As String
		<DataMember(IsRequired:= False, EmitDefaultValue:= False)>
		  Public Property phone As String()
		< DataMember(IsRequired:= False, EmitDefaultValue:= False) >
		Public Property email As String()
		< DataMember(IsRequired:= False, EmitDefaultValue:= False) >
		Public Property address As Address()
		< DataMember(IsRequired:= False, EmitDefaultValue:= False) >
		Public Property accounts As Account()

		Public Sub New()
		End Sub

		Public Sub New(ByVal id As String)
			Me.id = id
		End Sub

		Public Sub New(ByVal id As String, ByVal jobTitle As String, ByVal name As String, ByVal phone As String(), ByVal email As String(), ByVal address As Address(), ByVal accounts As Account())
			Me.id = id
			Me.jobTitle = jobTitle
			Me.name = name
			Me.phone = phone
			Me.email = email
			Me.address = address
			Me.accounts = accounts
		End Sub
	End Class

	<DataContract>
	Public Class Lead
		<DataMember>
		Public Property description As String
		<DataMember>
		Public Property assignee As Assignee

		<DataMember>
		Public Property note As String
		<DataMember>
		Public Property customFields As LOS

		Private _accounts(0) As Account

		<DataMember>
		Public Property accounts() As Account()
			Get
				Return _accounts
			End Get
			Set(ByVal value() As Account)
				_accounts = value
			End Set
		End Property

		Public Property accountsItem(ByVal i As Integer) As Object
			Get
				Return _accounts(i)
			End Get
			Set(ByVal value As Object)
				_accounts(i) = value
			End Set
		End Property

		Private _contacts(0) As Contact

		<DataMember>
		Public Property contacts() As Contact()
			Get
				Return _contacts
			End Get
			Set(ByVal value() As Contact)
				_contacts = value
			End Set
		End Property

		Public Property contactsItem(ByVal i As Integer) As Object
			Get
				Return _contacts(i)
			End Get
			Set(ByVal value As Object)
				_contacts(i) = value
			End Set
		End Property

		Public Sub New(ByVal description As String, ByVal assignee As Assignee, ByVal accounts As Account(), ByVal contacts As Contact(), ByVal note As String, ByVal customFields As LOS)
			Me.description = description
			Me.assignee = assignee
			Me.accounts = accounts
			Me.contacts = contacts
			Me.note = note
			Me.customFields = customFields
		End Sub
	End Class

	<DataContract>
	Public Class LOS
		<DataMember>
		Public Property LOS As String

		Public Sub New(ByVal LOS As String)
			Me.LOS = LOS
		End Sub
	End Class

	Public Class Result
		Public id As Integer
	End Class

	<DataContract>
	Public Class StringClass
		<DataMember>
		Public Property [string] As String
	End Class
	' -------------------------------------------------- end of OBJS --------------------------------------------------


End Class
' -------------------------------------------------- end of Nutshell Objects --------------------------------------------------