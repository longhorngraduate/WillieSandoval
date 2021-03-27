//1.  Main - sort by datetime using LINQ and then call the method that will further sort by the description:
' ----- CREATE and SORT list of Packages -----
Dim list_main As List(Of ProjectName.Package) = New List(Of Package)
Dim list_Description As ArrayList = New ArrayList()

'CREATE list of Packages
For Each oPkg As ProjectName.Package In SessionObj.Packages
	list_main.Add(oPkg)
Next

'SORT list of Packages
list_main = list_main.OrderByDescending(Function(x) x.TimeCreated).ToList() '.ThenBy(Function(x) x.Description).ToList()

'CREATE list of unique Package Descriptions
For Each oPkg As ProjectName.Package In list_main 'SessionObj.Packages
	If Not list_Description.Contains(oPkg.Description) Then
		list_Description.Add(oPkg.Description)
	End If
Next

'Further SORT the list of Packages while iterating the list of Package Descriptions
SortByDescription(list_main, list_Description)
' ----- end of CREATE and SORT list of Packages -----



//2.  Iterating from left to right, once I find a unique description, move the 2nd iteration right until you find a Package with the same description and then move it right next to the 1st occurence of it:
'The goal is to group together packages with the same Package Descriptions.  The list list_main is already sorted by datetime and now we need to further sort them by Package Description using list_Description.
'	We do this by having i assigned to the 1st package with an incorrect Package Description and to use "j" to iterate until we find a package with the correct Package Description.  Once we do, swap.
Private Sub SortByDescription(ByRef list_main As List(Of ProjectName.Package), ByVal list_Description As ArrayList)
	Dim i As Integer = 1 'list_main[0] is correct so skip it.  Start at position 1 instead of 0.

	For Each oPkg_Desc In list_Description
		For j As Integer = i To list_main.Count - 1
			
			'If they are equal, this means they are in the correct order and you should move on to the next index;
			'	otherwise, continue.
			If list_main.Item(i).Description = oPkg_Desc Then 'Move the index until you're at an incorrect package.
				i += 1
				j -= 1 'necessary because j will increment during each for-loop iteration and ignore this current element @ j
			Else
				If j <> i AND j > i Then 'There's nothing to swap if they are on the same element.
					If list_main.Item(j).Description = oPkg_Desc Then 'Swap i and j?
						list_main.Insert(i, list_main.Item(j))
						i += 1
						list_main.RemoveAt(j + 1) 'the collection has shifted up by 1 so remove the next element
					End If
				End If
			End If
		Next 'When this for-loop is completed, i will be at the correct position for the next group of Packages, so reuse it for the next oPkg_Desc iteration on the main for-loop.
	Next
End Sub



//3.  Backend to create HTML structure. The purpose here was to only display the leading Package and hide the following Packages if any that had the same Package Description, and then add a + to expand or a - to minimize that group of Packages.
//I needed to take the following approach below because it's what the Lead Software Developer wanted, but a different and better approach in my opinion would have been to send the data in JSON structure to the front end with certain fields set to "expand" and "collapse", and then have the front end create the HTML, which would have avoided hardcoded strings to create HTML.  For example, once the JSON was retrieved on the front end via AJAX, then you could get hidden HTML that was created for this purpose, call it div_template_html, and then replace placeholder data, call it placeholder_class and placeholder_name, etc, with the current record's actual data in order to start creating your HTML for that record.  Finally, insert it into a new dynamically created table, which would be placed inside a container_div with .innerHTML().
//.....but here is the solution the Lead Software Developer wanted me to implement:
For Each oPkg As WizardEngineDotNet.PackageClass In list_main 'ThisLoan.Packages
	...
	...
	...
	If Package_Description <> prev_Package_Desc Then 'Is this the main row that contains a new Package Description?
        package_group += 1
        prev_Package_Desc = Package_Description

        tr_package_row = "<tr class='package_group_1st_" & package_group & "' name='package_group_1st_" & package_group & "' id='row_" & i & "'>"
        expand_collapse_images = "" &
			"&nbsp;" &
			"<i name='expand' id='expand_" & package_group & "' Class='far fa-plus-square' style='font-size:1rem;color:green;'></i>" &
			"<i name='collapse' id='collapse_" & package_group & "' Class='far fa-minus-square' style='display:none;font-size:1rem;color:red;'></i></div>"
    Else
        tr_package_row = "<tr class='package_group_" & package_group & "' name='package_group_" & package_group & "' id='row_" & i & "' style='display:none;'>"
        expand_collapse_images = "<div id='spacer_" & i & "' style='width:50px;'>&nbsp;</div>"
    End If

    strBuilder.Append(tr_package_row)
	...
	...
	...
	' ----- RENAME and UPDATE/CANCEL IMAGES -----
    strBuilder.Append("<td style='position:relative;vertical-align: middle;'>")
    strBuilder.Append("<span name='rename' id='rename_" & i & "' class='fake-link' style='vertical-align: middle;'>Rename</span>") 'strBuilder.Append(CreateButton("rename", "rename_" & i, "Rename")) 'strBuilder.Append("<input type='button' name='rename' id='rename_" & i & "' value='Rename' />")
    strBuilder.Append("<i name='update' id='update_" & i & "' Class='fas fa-check' style='display:none;vertical-align: middle;padding-right:5px;font-size:1.4rem;color:green;'></i>") 'strBuilder.Append("<input type='button' name='update' id='update_" & i & "' value='Update' style='display:none;' />")
    strBuilder.Append("<i name='cancel' id='cancel_" & i & "' Class='fas fa-times' style='display:none;vertical-align: middle;padding-left:5px;font-size:1.5rem;color:red;'></i>")
    strBuilder.Append("<input type='hidden' name='pid' id='pid_" & i & "' value='" & oPkg.PackageId & "' />")
    strBuilder.Append("</td>")
    ' ----- end of RENAME and UPDATE/CANCEL IMAGES -----
	...
	...
	...
Next



//4.  HTML
<asp:Panel ID="pnlPackages" runat="server" Visible="False">
	<div style="max-width: 1100px" class="card custom-card-margin mt-5 ">
		<div class="card-header card-header-blue  ">
			<!-- Activity Menu -->
			<h5 style="margin-top: 0px;">Packages</h5>
			<!-- End Search -->
		</div>
		<div class="table_scroll">
			<asp:Label ID="lblPackages" runat="server"></asp:Label>
		</div>
	</div>
</asp:Panel>



//5.  JS
function getPackageIndex(myThis) {
	var id_full = $(myThis).prop('id');
	var id_parts = id_full.split('_');
	return id_parts.pop();
}

function updatePackage(id_index)
{
	var result = true;

	if (SomeClassName.UpdatePackage($('#pid_' + id_index).val(), $('#package_input_' + id_index).val()))
	{
		$('#package_text_' + id_index).text($('#package_input_' + id_index).val());
	}
	else
	{
		result = false;
	}

	return result;
}

setPackageJS();//also called when 1 or more Packages were edited/removed.
function setPackageJS() {
	//-------------------- Expand/Collapse Packages --------------------
	// Remove + and - images if no sub Packages exist.
	$('[name="expand"]').each(function () {
		var group_index = getPackageIndex(this);

		if ($('[name="package_group_' + group_index + '"]').length < 1) {
			$('#expand_' + group_index).hide();
			$('#collapse_' + group_index).hide();
		}
		else {
			//spacer_
		}
	});

	$('[name="expand"]').off().on('click', function () {
		var group_index = getPackageIndex(this);

		$('#expand_' + group_index).closest('table').find('tr.package_group_' + group_index).show();//show all the sub packages
		//dnw:  $('#expand_' + group_index).closest('table').find('tr.package_group_' & group_index).css('diplay', 'block');
		$('#collapse_' + group_index).show();//show the minus sign

		$(this).hide();//hide the + sign
	});

	$('[name="collapse"]').off().on('click', function () {
		var group_index = getPackageIndex(this);

		$('#expand_' + group_index).show();//show the + sign

		//hide the sub packages
		$(this).closest('table').find('tr.package_group_' + group_index).hide();//$(this).closest('table').children('[name="package_group_' + group_index + '"]').hide();
		//dnw:  $(this).closest('table').find('tr.package_group_' & group_index).css('display', '');//$(this).closest('table').children('[name="package_group_' + group_index + '"]').hide();
		$(this).hide();//hide the - sign
	});
	//-------------------- end of Expand/Collapse Packages --------------------

	//-------------------- Rename Packages --------------------
	$('#rename_all').off().on('click', function () {
		$('#rename_all').hide();
		$('[name="update"], [name="cancel"], [name="package_text"]').hide();

		$('#update_all').show();
		$('#cancel_all').show();
		$('[name="package_input"]').show();
		$('[name="rename"]').show();
		//$('[name="rename"]').removeClass("button_blue_middle");
		//$('[name="rename"]').addClass("button_grey_middle");//.attr('class', 'button_grey_middle');//.css("color", "grey");

		$('[name="rename"]').css('pointer-events', 'none').removeClass('fake-link');
	});

	$('#update_all').off().on('click', function () {
		$("body").css("cursor", "progress");

		var result = true;
		var package_count = $('#package_count').val();

		for (var i = 0; i < package_count; ++i) {
			result = result && updatePackage(i);
		}

		$('#update_all').hide();
		$('#cancel_all').hide();
		$('[name="update"], [name="cancel"], [name="package_input"]').hide();

		$('#rename_all').show();
		$('[name="package_text"]').show();
		$('[name="rename"]').show();
		//$('[name="rename"]').removeClass("button_grey_middle");
		//$('[name="rename"]').addClass("button_blue_middle");//$('[name="rename"]').show().attr('class', 'button_blue_middle');//.css("color", "");

		$('[name="rename"]').css('pointer-events', 'auto').addClass('fake-link');

		if (result) {
			$("#ctl00_ContentPlaceHolder1_lblPackages").html(SomeClassName.GetPackages(xLoanGuid).value);
			setPackageJS();
		}
		else {
			alert("Error:  One or more package descriptions were NOT updated.");
		}

		$("body").css("cursor", "default");
	});

	$('#cancel_all').off().on('click', function () {
		var package_count = $('#package_count').val();

		for (var i = 0; i < package_count; ++i) {
			$('#package_input_' + i).val($('#package_text_' + i).text());
		}

		$('#update_all').hide();
		$('#cancel_all').hide();
		$('[name="update"], [name="cancel"], [name="package_input"]').hide();

		$('#rename_all').show();
		$('[name="package_text"]').show();
		$('[name="rename"]').show();
		//$('[name="rename"]').removeClass("button_grey_middle");
		//$('[name="rename"]').addClass("button_blue_middle");//$('[name="rename"]').show().attr('class', 'button_blue_middle');//.css("color", "");

		$('[name="rename"]').css('pointer-events', 'auto').addClass('fake-link');
	});

	$('[name="rename"]').off().on('click', function () {
		var id_index = getPackageIndex(this);

		$(this).hide();
		$('#package_text_' + id_index).hide();

		$('#update_' + id_index).show();
		$('#cancel_' + id_index).show();
		$('#package_input_' + id_index).show();
	});

	$('[name="update"]').off().on('click', function () {
		$("body").css("cursor", "progress");

		var result = true;
		var id_index = getPackageIndex(this);

		result = updatePackage(id_index);

		$(this).hide();
		$('#cancel_' + id_index).hide();
		$('#package_input_' + id_index).hide();

		$('#rename_' + id_index).show();
		$('#package_text_' + id_index).show();

		if (result) {
			$("#ctl00_ContentPlaceHolder1_lblPackages").html(SomeClassName.GetPackages(xLoanGuid).value);
			setPackageJS();
		}
		else {
			alert("Error:  The package description was NOT updated.");
		}

		$("body").css("cursor", "default");
	});

	$('[name="cancel"]').off().on('click', function () {
		var id_index = getPackageIndex(this);

		$('#update_' + id_index).hide();
		$(this).hide();
		$('#package_input_' + id_index).hide();
		$('#package_input_' + id_index).val($('#package_text_' + id_index).text());

		$('#rename_' + id_index).show();
		$('#package_text_' + id_index).show();
	});
	//-------------------- end of Rename Packages --------------------
}