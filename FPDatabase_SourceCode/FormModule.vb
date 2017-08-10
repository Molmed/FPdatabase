Option Strict Off
Option Explicit On
Module FormModule
	
	
	'=====================================================================
	' Name: Function viewFPData
	' Input:
	'   ByRef oFPConnection  As ADODB.Connection - an open connection
	' Output:
	'   Integer - 0 = an error occured, 1 = everything is fine
	' Remarks: This will open an excel application, needs excel to work
	' Purpose: To open an excel application for the user an print the
	'           the results that belongs to a certain plate.
	'=====================================================================
	
	Public Function viewFPData(ByRef oFPConnection As ADODB.Connection, ByVal sMasterPlateName As String) As Short
		' opening excel and prining out the results
		
		Dim oXLApp As Microsoft.Office.Interop.Excel.Application
		oXLApp = New Microsoft.Office.Interop.Excel.Application
		
		Dim oXLWsheet As Microsoft.Office.Interop.Excel.Worksheet
		Dim oXLWbook As Microsoft.Office.Interop.Excel.Workbook
		oXLWbook = oXLApp.Workbooks.Add
		
		oXLWsheet = oXLWbook.Worksheets.Add
		
		Dim lMasterPlateId As Integer
		
		Dim sRawDataFile As String
		Dim sGenotypeFile As String
		
		' need a recordset and a string
		Dim Rs As New ADODB.Recordset
		Dim SQLQuery As String

        sRawDataFile = ""
        sGenotypeFile = ""
		' fining the id of the master plate
		SQLQuery = "SELECT id FROM plate WHERE identifier = '" & sMasterPlateName & "'"
		Rs.Open(SQLQuery, oFPConnection, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
		
		lMasterPlateId = Val(Rs.Fields(0).Value)
		Rs.Close()
		
		'Finding the data file names.
		Rs.Open("SELECT rawdatafile, genotypefile FROM filename WHERE plate_id =" & lMasterPlateId, oFPConnection)
		If Not Rs.EOF Then
			sRawDataFile = CStr(Rs.Fields(0).Value)
			sGenotypeFile = CStr(Rs.Fields(1).Value)
		End If
		Rs.Close()
		
		SQLQuery = "select p.well_row, p.well_column, p.genotype, m.identifier, s.identifier, d1.raw_data_parallel, d1.raw_data_perpendicular, d1.raw_data_ratio, r1.ratio_units, r1.method_id, d2.raw_data_parallel, d2.raw_data_perpendicular, d2.raw_data_ratio, r2.ratio_units, r2.method_id FROM plate_map p, marker m, sample s, data d1, data d2, run r1, run r2 WHERE p.marker_id = m.id AND p.sample_id = s.id AND d1.plate_map_id = p.id AND d2.plate_map_id = p.id AND d1.run_id = r1.id AND d2.run_id = r2.id and d1.id > d2.id and p.plate_id =" & lMasterPlateId
		Rs.Open(SQLQuery, oFPConnection, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)
		
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLWsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLWsheet.Cells._Default(1, 3).Value = "Plate:"
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLWsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLWsheet.Cells._Default(1, 4).Value = sMasterPlateName
		
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLWsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLWsheet.Cells._Default(2, 3).Value = "Rawdatafile:"
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLWsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLWsheet.Cells._Default(2, 4).Value = sRawDataFile
		
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLWsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLWsheet.Cells._Default(3, 3).Value = "Genotypefile"
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLWsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLWsheet.Cells._Default(3, 4).Value = sGenotypeFile
		
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLWsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLWsheet.Cells._Default(4, 1).Value = "Row"
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLWsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLWsheet.Cells._Default(4, 2).Value = "Column"
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLWsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLWsheet.Cells._Default(4, 3).Value = "Genotype"
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLWsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLWsheet.Cells._Default(4, 4).Value = "Marker"
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLWsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLWsheet.Cells._Default(4, 5).Value = "Sample"
		
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLWsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLWsheet.Cells._Default(4, 6).Value = "Raw Data Parallel"
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLWsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLWsheet.Cells._Default(4, 7).Value = "Raw Data Perpendicular"
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLWsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLWsheet.Cells._Default(4, 8).Value = "Ratio"
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLWsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLWsheet.Cells._Default(4, 9).Value = "Ratio unit"
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLWsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLWsheet.Cells._Default(4, 10).Value = "Method Id"
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLWsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLWsheet.Cells._Default(4, 11).Value = "Raw Data Parallel"
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLWsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLWsheet.Cells._Default(4, 12).Value = "Raw Data Perpendicular"
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLWsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLWsheet.Cells._Default(4, 13).Value = "Ratio"
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLWsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLWsheet.Cells._Default(4, 14).Value = "Ratio unit"
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLWsheet.Cells().Value. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLWsheet.Cells._Default(4, 15).Value = "Method Id"
		
		'UPGRADE_WARNING: Couldn't resolve default property of object oXLWsheet.Cells().CopyFromRecordset. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
		oXLWsheet.Cells._Default(5, 1).CopyFromRecordset(Rs)
		
		Rs.Close()
		
		oXLApp.Visible = True
		
		'UPGRADE_NOTE: Object Rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Rs = Nothing
		
		
	End Function
	
	
	'======================================================================
	' Name: Function ReadSampleName
	' Input: None
	' Output:
	'   collection - a collection of sample names, stored as a key map
	'               where the well is the key and the sample name the item
	' Remarks: This wil need microsoft excel to work, it will also use
	'           the form rngReadSampleName
	' Purpose: This will open excel, show an open file dialog, let the
	'           user open the file and then choose the sample names...
	'======================================================================
	
	Public Function ReadSampleName() As Collection
		Dim oXLApp As Microsoft.Office.Interop.Excel.Application
		Dim rngSample As Microsoft.Office.Interop.Excel.Range
		Dim aCell As Microsoft.Office.Interop.Excel.Range
		
		Dim iNrOfRows As Short
		Dim iNrOfColumns As Short
		
		
		On Error GoTo ReadSampleName_Error
		
		Dim ReturnCollection As New Collection
		
		'starting the excel application
		oXLApp = New Microsoft.Office.Interop.Excel.Application
		
		' showing the open file dialog
		oXLApp.Dialogs(Microsoft.Office.Interop.Excel.XlBuiltInDialog.xlDialogOpen).Show()
		
		' showing the excel application
		oXLApp.Visible = True
		
		' the input box will return the range that was choosen by the user,
		' because the inputbox is of type 8
		rngSample = oXLApp.InputBox(Prompt:="Select cells for samples external_reference", Type:=8)
		
		' removing excel from the screen
		oXLApp.Visible = False
		
		iNrOfRows = rngSample.Rows.Count
		iNrOfColumns = rngSample.Columns.Count
		
		Dim i As Short
		i = 0
		Dim iCurrentColumn As Short
		iCurrentColumn = 0
		Dim iCurrentRow As Short
		iCurrentRow = 0
		For	Each aCell In rngSample
			If i Mod iNrOfColumns = 0 Then
				iCurrentRow = iCurrentRow + 1
			End If
			ReturnCollection.Add(aCell.Text, (Chr(64 + iCurrentRow) & ((i Mod iNrOfColumns) + 1)))
			i = i + 1
		Next aCell
		
		oXLApp.Quit()
		
		'UPGRADE_NOTE: Object oXLApp may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		oXLApp = Nothing
		
		ReadSampleName = ReturnCollection
		
		'UPGRADE_NOTE: Object ReturnCollection may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		ReturnCollection = Nothing
		
		Exit Function
		
ReadSampleName_Error: 
		' if the cancel button was pressed while choosing the cells to use in adding samples
		' the range object will not be settable and an error thrown.
		' doing som cleaning up and returning from the function with ab enpty collection,
		' easy to checkk just with is nothing...
		
		oXLApp.Quit()
		'UPGRADE_NOTE: Object ReturnCollection may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		ReturnCollection = Nothing
		'UPGRADE_NOTE: Object ReadSampleName may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		ReadSampleName = Nothing
		
		Exit Function
		
	End Function
End Module