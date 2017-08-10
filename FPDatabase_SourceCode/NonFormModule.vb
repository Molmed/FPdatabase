Option Strict Off
Option Explicit On
Module NonFormModule
	
	'UPGRADE_WARNING: Application will terminate when Sub Main() finishes. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="E08DDC71-66BA-424F-A612-80AF11498FF8"'
	Public Sub Main()
		
		On Error GoTo Main_Error
		
		'----- For development purpose -------------------
        Dim DEVELOPMENT_VERSION As Boolean
        Dim MyfrmStart As frmStart

        DEVELOPMENT_VERSION = False
        '-------------------------------------------------

        Dim oFPConnection As New ADODB.Connection
        Dim oGtdbConnection As New ADODB.Connection
        Dim bPracticeMode As Boolean

        oFPConnection.Provider = "sqloledb"
        oFPConnection.ConnectionString = ReadConfigString("FPConnectionString")

        oGtdbConnection.Provider = "sqloledb"
        oGtdbConnection.ConnectionString = ReadConfigString("ChiasmaConnectionString")

        oFPConnection.Open()
        oGtdbConnection.Open()

        If Not DEVELOPMENT_VERSION Then
            'UPGRADE_ISSUE: App object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
            If isCorrectVersion(oGtdbConnection) = False Then
                MsgBox("Permission to database denied. You may be using an old version of this application.")
                Exit Sub
            End If
        End If

        ' trying to find the current user in the database
        Dim sUserName As String
        Dim sName As String
        Dim Rs As New ADODB.Recordset
        Rs.Open("SELECT SYSTEM_USER", oFPConnection)
        sUserName = Rs.Fields(0).Value
        Rs.Close()

        Rs.Open("SELECT id FROM person WHERE user_handel ='" & sUserName & "'")
        If Not Rs.EOF Then
            Rs.Close()
        Else
            frmUserName.ShowDialog()
            sName = frmUserName.txtUserName.Text
            Rs.Close()
            frmUserName.Close()

            If sName = "" Then
                Exit Sub
            End If

            'inserting the new user
            oFPConnection.Execute("INSERT INTO person( name, user_handel ) VALUES('" & sName & "','" & sUserName & "')")
            Rs.Open("SELECT SCOPE_IDENTITY()")

        End If

        Call frmStart.Initialize(oFPConnection, oGtdbConnection, bPracticeMode)

        frmStart.ShowDialog()


        Exit Sub

Main_Error:
        MsgBox(Err.Description)
        Exit Sub
    End Sub

    '=============================================================================
    ' Name: Function createPlate
    ' Input:
    '   ByVal sIdentifier As String - The name of the plate you want to create
    '   ByVal sPlateSchemeName As String - The name of the plate_scheme that this
    '       plate should be build out of.
    '   ByRef oFPConnection As ADODB.Connection - an open connection to the database
    ' Output:
    '   Long - The id of the created plate, or if an error occured = 0
    ' Remarks: None
    ' Purpose: To add a plate in the database, using the plate_scheme defined in
    '           the sPlateSchemeName variable.
    '=============================================================================

    Public Function createPlate(ByVal sIdentifier As String, ByVal sPlateSchemeName As String, ByRef oFPConnection As ADODB.Connection) As Integer

        On Error GoTo createPlate_Error

        ' need to find the id of the plate_scheme first
        Dim lPlateSchemeId As Integer
        Dim Rs As New ADODB.Recordset
        Rs.Open("SELECT id FROM plate_scheme WHERE identifier = '" & sPlateSchemeName & "'", oFPConnection)


        If Rs.EOF Then
            Err.Raise(-10000,  , "Unable to find the plate-scheme: " & sPlateSchemeName)
        Else
            lPlateSchemeId = CInt(Rs.Fields(0).Value)
            Rs.Close()
        End If

        'need to pick out the person id as well..
        Dim lPersonId As Integer

        Rs.Open("SELECT id FROM person WHERE user_handel = SYSTEM_USER", oFPConnection)

        If Rs.EOF Then
            Err.Raise(-10000,  , "Unable to find the current person_id")
        Else
            lPersonId = Rs.Fields(0).Value
            Rs.Close()
        End If

        'now we are ready to create the plate entry
        Dim lPlateId As Integer

        oFPConnection.BeginTrans()
        oFPConnection.Execute("INSERT INTO plate(identifier, person_id) VALUES('" & sIdentifier & "'," & lPersonId & ")")
        Rs.Open("SELECT SCOPE_IDENTITY()")

        If Rs.EOF Then
            Err.Raise(-10000,  , "Unable to create the plate")
        ElseIf Rs.Fields(0).Value = 0 Then
            Err.Raise(-10000,  , "Unable to create the plate")
        Else
            lPlateId = Rs.Fields(0).Value
        End If

        'filling the plate map with the samples from the plate-scheme
        oFPConnection.Execute("INSERT INTO plate_map(plate_id, sample_id, well_row, well_column) SELECT " & lPlateId & " as plate_id, " & "sample_id, well_row, well_column FROM plate_scheme_map WHERE plate_scheme_id = " & lPlateSchemeId)


        ' if everything went ok, return the plate id and quit the function
        oFPConnection.CommitTrans()
        createPlate = lPlateId

        'UPGRADE_NOTE: Object Rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        Rs = Nothing

        Exit Function

createPlate_Error:
        MsgBox(Err.Description)

        createPlate = 0
        oFPConnection.RollbackTrans()
        'UPGRADE_NOTE: Object Rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        Rs = Nothing
        Exit Function
    End Function


    '=======================================================================
    ' Name: Function setMarker
    ' Input:
    '   ByVal sMarkerName As String - The name of the marker that we should combine
    '                   the data with
    '   ByVal lSegmentId As Long - The id number of the segment that the marker
    '                   should be added to
    ' Output:
    '   Integer - Error checking 0= error free 1 = error
    ' Purpose: To check if the marker is in the database, if it is in the database
    '           take the id number and bind all the data in the segment to id
    '           if it is not in the database add it.
    ' Remarks: None
    '=======================================================================

    Public Function setMarker(ByVal sMarkerName As String, ByVal lSegmentId As Integer, ByRef oFPConnection As ADODB.Connection) As Short

        On Error GoTo setMarker_Error


        Dim Rs As New ADODB.Recordset
        Dim SQLQuery As String

        Rs.Open("SELECT id FROM marker WHERE identifier = '" & sMarkerName & "'", oFPConnection)
        If Rs.EOF Then
            ' the marker was not in the database. add it
            Rs.Close()
            oFPConnection.Execute("INSERT INTO marker(identifier) VALUES('" & sMarkerName & "')")

            ' and pick out its id number
            Rs.Open("SELECT SCOPE_IDENTITY()", oFPConnection)

            ' and update all the plate_map entities that belong to the specified
            ' segment to this marker
            oFPConnection.Execute("UPDATE plate_map SET marker_id =" & Val(Rs.Fields(0).Value) & " WHERE segment_id = " & lSegmentId)

            Rs.Close()

        Else

            oFPConnection.Execute("UPDATE plate_map SET marker_id =" & Val(Rs.Fields(0).Value) & " WHERE segment_id = " & lSegmentId)

            Rs.Close()

        End If

        setMarker = 1

        'UPGRADE_NOTE: Object Rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        Rs = Nothing


        Exit Function


setMarker_Error:
        MsgBox(Err.Description)
        setMarker = 0
        'UPGRADE_NOTE: Object Rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        Rs = Nothing

        ' need to clean up from the database so that all that were added is removed
        ' first remove the run table
        oFPConnection.Execute("DELETE FROM run WHERE id IN ( SELECT run_id FROM data WHERE plate_map_id IN ( SELECT id FROM plate_map WHERE segment_id = " & lSegmentId & "))")
        ' then we remove the segment
        oFPConnection.Execute("DELETE FROM segment WHERE id = " & lSegmentId)


        Exit Function


    End Function


    '=================================================================================
    ' Name: Function setGenotype
    ' Input:
    '   ByVal lSegmentId As Long -  The segment to which the genotype is added
    '   ByRef oFPConnection As ADODB.Connection -  an open connection
    '   ByVal sFileName As String - the name of the file to parse
    '   ByVal sCorrectSNPType As String - the SNP type as defined by the assay, e.g. "C/T"
    ' Output:
    '   Integer - showing if everything went OK, 1= OK 0= Error
    ' Purpose: To set the genotype call in the database for the samples that belong
    '           to the master plate that is sent as an argument
    ' Remarks:  None
    '================================================================================

    Public Function setGenotype(ByVal sFileName As String, ByVal lSegmentId As Integer, ByVal sCorrectSNPType As String, ByRef oFPConnection As ADODB.Connection) As Short
        ' need first to convert the 1 and 0's that are in the result file form allele caller
        ' to actual genotypes. Reading what base it is from the file, and the direction of
        ' the marker is sent as an argument

        ' need file sysobject and a textstream object to read the file

        On Error GoTo setGenotype_Error

        Dim parsedDate As DateTime
        Dim cultureEN As System.Globalization.CultureInfo
        Dim cultureSE As System.Globalization.CultureInfo
        ' need a some object to work with open files
        Dim oFileSysObj As New Scripting.FileSystemObject
        Dim oTextStream As Scripting.TextStream
        Dim str As String
        oTextStream = oFileSysObj.OpenTextFile(sFileName, Scripting.IOMode.ForReading, False, Scripting.Tristate.TristateUseDefault)

        ' defining a collection that is used to save the result form the string tokenier
        Dim oTextLine As Collection

        ' defining the genotypes
        Dim g1 As String
        Dim g2 As String

        ' a bool to break the while loop in genotype reading
        Dim bBreak As Boolean
        bBreak = False

        Dim lPlateMapId As Integer

        ' need a recordset and a string to query the database
        Dim Rs As New ADODB.Recordset
        Dim SQLQuery As String

        ' a string to store the actual genotype
        Dim sGenotype As String

        ' startring to read the file ...

        'the first row contains the program name
        oTextLine = StringTokenizer(oTextStream.ReadLine(), Chr(9))
        'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        oFPConnection.Execute("UPDATE segment SET genotype_program = '" & Mid(oTextLine.Item(1), 2) & "' WHERE id =" & lSegmentId)


        ' the next line fontains the name of the input file
        oTextLine = StringTokenizer(oTextStream.ReadLine, Chr(9))

        ' the third line contains the date when the call took place
        oTextLine = StringTokenizer(oTextStream.ReadLine, Chr(9))

        'checking if the date can be easely converted ( this depends on the
        ' regional settings of the computer...)
        'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'

        cultureEN = New Globalization.CultureInfo("en-US")
        cultureSE = New Globalization.CultureInfo("sv-SE")
        'If IsDate(Mid(oTextLine.Item(1), 14)) Then
        If DateTime.TryParse(Mid(oTextLine.Item(1), 14), parsedDate) Or
             DateTime.TryParse(Mid(oTextLine.Item(1), 14), cultureEN, Globalization.DateTimeStyles.None, parsedDate) Or
             DateTime.TryParse(Mid(oTextLine.Item(1), 14), cultureSE, Globalization.DateTimeStyles.None, parsedDate) Then
            ' if it was convertible just go ahead and write to the database
            'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            'oFPConnection.Execute("UPDATE segment SET genotype_date = '" & VB6.Format(CDate(Mid(oTextLine.Item(1), 14, 18)), "yyyy-mm-dd hh:mm:ss") & "' WHERE id =" & lSegmentId)
            oFPConnection.Execute("UPDATE segment SET genotype_date = '" & parsedDate.ToString("yyyy-MM-dd hh:mm:ss") & "' WHERE id =" & lSegmentId)
        Else
            ' otherwise ask the user what it says
            'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            frmAddDate.Initialize((Mid(oTextLine.Item(1), 14)))
            frmAddDate.ShowDialog()

            If frmAddDate.getOk = True Then
                str = frmAddDate.getDate.ToString("yyyy-MM-dd hh:mm:ss")
                oFPConnection.Execute("UPDATE segment SET genotype_date = '" & str & "' WHERE id =" & lSegmentId)
            Else
                MsgBox("You need to specify a date")
                Exit Function
            End If
        End If


        ' the fourth line is empty
        oTextLine = StringTokenizer(oTextStream.ReadLine, Chr(9))


        ' reading the fifth line which contains which sort of marker it is

        oTextLine = StringTokenizer(oTextStream.ReadLine, Chr(9))

        'settting the genotype
        'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        g1 = oTextLine.Item(2)
        'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
        g2 = oTextLine.Item(3)

        'Checking if the SNP type is the same as that defined by the assay.
        If Not ((g1 = Left(sCorrectSNPType, 1) And g2 = Right(sCorrectSNPType, 1)) Or (g2 = Left(sCorrectSNPType, 1) And g1 = Right(sCorrectSNPType, 1))) Then
            Err.Raise(-1000, , "The assay SNP type is different from that in the file.")
        End If

        ' reading all the genotypes and updating to the database
        Do While bBreak = False

            'reading a new line from file
            oTextLine = StringTokenizer(oTextStream.ReadLine, Chr(9))

            ' picking out the sample id from the database that corresponds to the well number
            'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            SQLQuery = "SELECT id FROM plate_map WHERE segment_id = " & lSegmentId & " AND well_column = " & Val(Mid(oTextLine.Item(1), 2, Len(oTextLine.Item(1)))) & " AND well_row = '" & Left(oTextLine.Item(1), 1) & "'"
            Rs.Open(SQLQuery, oFPConnection, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockReadOnly)

            If Rs.EOF Then
                Err.Raise(-10000, , "The genotype file contained wells that were not defined on the plate.")
            End If
            lPlateMapId = Val(Rs.Fields(0).Value)
            Rs.Close()
            ' calling the genotype

            'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            If Val(oTextLine.Item(2)) = 1 And Val(oTextLine.Item(3)) = 0 Then
                sGenotype = g1 & g1
                'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ElseIf Val(oTextLine.Item(2)) = 1 And Val(oTextLine.Item(3)) = 1 Then
                sGenotype = g1 & g2
                'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ElseIf Val(oTextLine.Item(2)) = 0 And Val(oTextLine.Item(3)) = 1 Then
                sGenotype = g2 & g2
                'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
            ElseIf Val(oTextLine.Item(2)) = 0 And Val(oTextLine.Item(3)) = 0 Then
                sGenotype = "**"
            Else
                MsgBox("Unrecognized genotype")
                setGenotype = 0
                Exit Function
            End If



            'updating the genotype to the database
            oFPConnection.Execute("UPDATE plate_map SET genotype = '" & sGenotype & "' WHERE id =" & lPlateMapId)
            'checking if we are at the end of the file
            If oTextStream.AtEndOfLine = True Then
                bBreak = True
            End If
        Loop


        setGenotype = 1

        'cleaning up
        'UPGRADE_NOTE: Object Rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        Rs = Nothing
        'UPGRADE_NOTE: Object oTextStream may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        oTextStream = Nothing
        'UPGRADE_NOTE: Object oTextLine may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        oTextLine = Nothing
        'UPGRADE_NOTE: Object oFileSysObj may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        oFileSysObj = Nothing

        Exit Function

setGenotype_Error:
        ' showing the error message
        MsgBox(Err.Description)

        ' setting the setGentype return flag to error
        setGenotype = 0

        ' cleaning up
        'UPGRADE_NOTE: Object Rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        Rs = Nothing
        'UPGRADE_NOTE: Object oTextStream may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        oTextStream = Nothing
        'UPGRADE_NOTE: Object oTextLine may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        oTextLine = Nothing
        'UPGRADE_NOTE: Object oFileSysObj may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
        oFileSysObj = Nothing

        'need to remove all the data that we were trying to upload at the same time
        ' as the genotype

        ' first remove the run table
        oFPConnection.Execute("DELETE FROM run WHERE id IN ( SELECT run_id FROM data WHERE plate_map_id IN ( SELECT id FROM plate_map WHERE segment_id = " & lSegmentId & "))")
        ' then we remove the segment
        oFPConnection.Execute("DELETE FROM segment WHERE id = " & lSegmentId)


        Exit Function


    End Function

    '======================================================================
    ' Name: Function RawDataFileParser
    ' Input:
    '   ByRef oFPConnection As ADODB.Connection
    '   ByVal sFileName As String -  the filename for the file to parse
    '   ByVal sMarkerName As String - the name of the marker that is used
    '   ByVal lPersonId As Long - the id of the person that is uploading the data
    ' Output:
    '   Long -  This will return the master plate id, if the function works, otherwise it will
    '               return 0
    ' Purpose: To read an FP raw datafile and upload the result
    '           to the database for the FP instrument
    ' Remarks: None
    '====================================================================

    Public Function RawDataFileParser(ByVal sFileName As String, ByRef oFPConnection As ADODB.Connection, ByVal sMarkerName As String, ByVal lPersonId As Integer, ByVal lPlateId As Integer) As Integer

        ' need a recordset to work with the database
        Dim Rs As New ADODB.Recordset
        Dim SQLQuery As String

        ' need a some object to work with open files
        Dim oFileSysObj As New Scripting.FileSystemObject
        Dim oTextStream As Scripting.TextStream

        oTextStream = oFileSysObj.OpenTextFile(sFileName, Scripting.IOMode.ForReading, False, Scripting.Tristate.TristateUseDefault)

        ' a line of text in the file
        Dim sTextLine As String
        ' a line of text tokenized into different strings and saved in a colllection
        Dim oTextLine As Collection

        oTextLine = Nothing
        ' a bool used to  break the while loop
        Dim bBreak As Boolean
        bBreak = False

        ' the name for the master plate ( the filename )
        Dim sMasterPlateName As String

        ' the id for the masterplate in the database
        Dim lMasterPlateId As Integer

        ' the id for the run table in the database
        Dim lRunId As Integer

        ' a key map to keep a list of sample_id that correspond to well
        Dim PlateWellId As New Scripting.Dictionary

        ' indexes to create the well names in the sample table
        Dim iWellRow As Short
        Dim iWellColumn As Short

        ' used to keep track of the segments that the data should be enterd in
        ' the segment is created by the function
        Dim lSegmentId As Integer


        Dim i As Short

        ' saving the plate name for the last past of the total filename
        sMasterPlateName = Mid(sFileName, InStrRev(sFileName, "\") + 1, Len(sFileName))


        ' tree matrices for saving the data for the different modes
        ' parallel, perpendicular and ratio
        Dim iParallel(,) As String
        Dim iPerpendicular(,) As String
        Dim iRatio(,) As String

        ' an array to save all the parameters for the plate table in the database
        'UPGRADE_WARNING: Lower bound of array sPlateParameters was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
        Dim sPlateParameters(16) As String

        ' an array to store the data that comes after detection mode
        'UPGRADE_WARNING: Lower bound of array sDetectionModeParameters was changed from 1 to 0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
        Dim sDetectionModeParameters(24) As String


        On Error GoTo RawDataFileParser_Error




        'creating the segment and storing the id for the inserted id
        oFPConnection.Execute("INSERT INTO segment(genotype_program) VALUES(null)")
        'quering for the segment id
        Rs.Open("SELECT SCOPE_IDENTITY()", oFPConnection)
        lSegmentId = Val(Rs.Fields(0).Value)
        Rs.Close()


        ' prepared statements used in the uploading of raw data
        Dim cmdData As New ADODB.Command
        Dim prmDataParallel As New ADODB.Parameter
        Dim prmDataPerpendicular As New ADODB.Parameter
        Dim prmDataRatio As New ADODB.Parameter
        Dim prmDataRunId As New ADODB.Parameter
        Dim prmDataPlateMapId As New ADODB.Parameter

        cmdData.ActiveConnection = oFPConnection
        cmdData.CommandText = "INSERT INTO data( raw_data_parallel, raw_data_perpendicular, raw_data_ratio, run_id, plate_map_id) VALUES(?,?,?,?,?)"
        cmdData.CommandType = ADODB.CommandTypeEnum.adCmdText
        cmdData.Prepared = True

        prmDataParallel = cmdData.CreateParameter("raw_data_parallel", ADODB.DataTypeEnum.adBigInt, ADODB.ParameterDirectionEnum.adParamInput, 16, 0)
        prmDataPerpendicular = cmdData.CreateParameter("raw_data_perpendicular", ADODB.DataTypeEnum.adBigInt, ADODB.ParameterDirectionEnum.adParamInput, 16, 0)
        prmDataRatio = cmdData.CreateParameter("raw_data_ratio", ADODB.DataTypeEnum.adBigInt, ADODB.ParameterDirectionEnum.adParamInput, 16, 0)
        prmDataRunId = cmdData.CreateParameter("run_id", ADODB.DataTypeEnum.adBigInt, ADODB.ParameterDirectionEnum.adParamInput, 16, 0)
        prmDataPlateMapId = cmdData.CreateParameter("plate_map_id", ADODB.DataTypeEnum.adBigInt, ADODB.ParameterDirectionEnum.adParamInput, 16, 0)

        cmdData.Parameters.Append(prmDataParallel)
        cmdData.Parameters.Append(prmDataPerpendicular)
        cmdData.Parameters.Append(prmDataRatio)
        cmdData.Parameters.Append(prmDataRunId)
        cmdData.Parameters.Append(prmDataPlateMapId)


        Dim cmdSegment As New ADODB.Command
        Dim prmSegmentId As New ADODB.Parameter
        Dim prmPlateMapId As New ADODB.Parameter
        cmdSegment.ActiveConnection = oFPConnection

        cmdSegment.CommandText = "UPDATE plate_map SET segment_id =? WHERE id = ?"
        cmdSegment.CommandType = ADODB.CommandTypeEnum.adCmdText
        cmdSegment.Prepared = True

        cmdSegment.ActiveConnection = oFPConnection

        prmSegmentId = cmdSegment.CreateParameter("segment_id", ADODB.DataTypeEnum.adBigInt, ADODB.ParameterDirectionEnum.adParamInput, 16, 0)
        cmdSegment.Parameters.Append(prmSegmentId)
        prmPlateMapId = cmdSegment.CreateParameter("plate_map_id", ADODB.DataTypeEnum.adBigInt, ADODB.ParameterDirectionEnum.adParamInput, 16, 0)
        cmdSegment.Parameters.Append(prmPlateMapId)





        Dim iAnswer As Short
        Do While bBreak = False

            ' saving the parameters for the plate ( ie searching for tags and
            ' saving whats beside them )

            Do While True
                sTextLine = oTextStream.ReadLine
                oTextLine = StringTokenizer(sTextLine, Chr(9))

                'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If Trim(oTextLine.Item(1)) = "Detection mode:" Then
                    Exit Do
                End If

                'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                If Trim(oTextLine.Item(1)) = "Load time:" Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    sPlateParameters(1) = oTextLine.Item(2)
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ElseIf oTextLine.Item(1) = "Read time:" Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    sPlateParameters(2) = oTextLine.Item(2)
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ElseIf oTextLine.Item(1) = "Kinetic read cycle:" Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    sPlateParameters(3) = oTextLine.Item(2)
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ElseIf oTextLine.Item(1) = "Read start delay time:" Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    sPlateParameters(4) = oTextLine.Item(2) & " " & oTextLine.Item(3)
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ElseIf oTextLine.Item(1) = "Time delay between kinetic reads:" Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    sPlateParameters(5) = oTextLine.Item(2)
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ElseIf oTextLine.Item(1) = "Barcode:" Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    sPlateParameters(6) = oTextLine.Item(2)
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ElseIf oTextLine.Item(1) = "Method ID:" Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    sPlateParameters(7) = oTextLine.Item(2)
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ElseIf oTextLine.Item(1) = "Plate ID:" Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    sPlateParameters(8) = oTextLine.Item(2)
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ElseIf oTextLine.Item(1) = "Comment:" Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    sPlateParameters(9) = oTextLine.Item(2)
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ElseIf oTextLine.Item(1) = "Microplate format:" Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    sPlateParameters(10) = oTextLine.Item(2)
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ElseIf oTextLine.Item(1) = "Shake time:" Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    sPlateParameters(11) = oTextLine.Item(2) & " " & oTextLine.Item(3)
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ElseIf oTextLine.Item(1) = "Temperature:" Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    sPlateParameters(12) = oTextLine.Item(2) & " " & oTextLine.Item(3)
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ElseIf oTextLine.Item(1) = "Instrument tag:" Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    sPlateParameters(13) = oTextLine.Item(2)
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ElseIf oTextLine.Item(1) = "Serial number:" Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    sPlateParameters(14) = oTextLine.Item(2)
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ElseIf oTextLine.Item(1) = "Read sequence:" Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    sPlateParameters(15) = oTextLine.Item(2)
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ElseIf oTextLine.Item(1) = "Mode sequence:" Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    sPlateParameters(16) = oTextLine.Item(2)
                End If

            Loop

            ' create the plate with the data that has been gathered

            ' need to check if this run has already been uploaded to the database
            Rs.Open("SELECT plate_id FROM run WHERE plate_id = '" & sPlateParameters(8) & "'", oFPConnection)
            If Not Rs.EOF Then
                ' if the run has already been uploaded once, ask the user.
                iAnswer = MsgBox("This run has already been uploaded, do you wish to continue anyway?", MsgBoxStyle.YesNo)

                If Not iAnswer = MsgBoxResult.Yes Then
                    Err.Raise(vbObjectError + 1,  , "The plate already existed, bailing out")
                End If
            End If
            Rs.Close()

            oFPConnection.Execute("INSERT INTO run(load_time, read_time, kinetic_read_cycle, read_start_delay_time, time_delay_between_kinetic_reads, barcode, method_id, plate_id, comment, microplate_format, shake_time, temperature, instrument_tag, serial_number, read_sequence, mode_sequence ) VALUES('" & VB6.Format(CDate(sPlateParameters(1)), "yyyy-mm-dd hh:mm:ss") & "','" & VB6.Format(CDate(sPlateParameters(2)), "yyyy-mm-dd hh:mm:ss") & "','" & sPlateParameters(3) & "','" & sPlateParameters(4) & "','" & sPlateParameters(5) & "','" & sPlateParameters(6) & "','" & sPlateParameters(7) & "','" & sPlateParameters(8) & "','" & sPlateParameters(9) & "','" & sPlateParameters(10) & "','" & sPlateParameters(11) & "','" & sPlateParameters(12) & "','" & sPlateParameters(13) & "','" & sPlateParameters(14) & "','" & sPlateParameters(15) & "','" & sPlateParameters(16) & "')")
            Rs.Open("SELECT SCOPE_IDENTITY()", oFPConnection)

            lRunId = Val(Rs.Fields(0).Value)
			Rs.Close()
			
			
			
			' time to read the detection mode data, which will be inserted
			' into a separate table
			
			'saving the detection mode
			'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			sDetectionModeParameters(1) = oTextLine.Item(2)
			Do While True
				
				
				oTextLine = StringTokenizer(oTextStream.ReadLine(), Chr(9))
				
				'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If oTextLine.Item(1) = "Light sensor:" Then
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sDetectionModeParameters(2) = oTextLine.Item(2)
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf oTextLine.Item(1) = "Excitation side:" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sDetectionModeParameters(3) = oTextLine.Item(2)
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf oTextLine.Item(1) = "Emission side:" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sDetectionModeParameters(4) = oTextLine.Item(2)
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf oTextLine.Item(1) = "Lamp:" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sDetectionModeParameters(5) = oTextLine.Item(2)
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf oTextLine.Item(1) = "Readings per well:" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sDetectionModeParameters(6) = oTextLine.Item(2)
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf oTextLine.Item(1) = "Time between readings:" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sDetectionModeParameters(7) = oTextLine.Item(2)
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf oTextLine.Item(1) = "Integration time:" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sDetectionModeParameters(8) = oTextLine.Item(2) & " " & oTextLine.Item(3)
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf oTextLine.Item(1) = "Attenuator mode:" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sDetectionModeParameters(9) = oTextLine.Item(2)
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf oTextLine.Item(1) = "Motion settling time:" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sDetectionModeParameters(10) = oTextLine.Item(2) & " " & oTextLine.Item(3)
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf oTextLine.Item(1) = "Z Height:" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(4). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sDetectionModeParameters(11) = oTextLine.Item(2) & " " & oTextLine.Item(3) & " " & oTextLine.Item(4)
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                ElseIf oTextLine.Item(1) = "Excitation" Then
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                    sDetectionModeParameters(12) = oTextLine.Item(2) & " " & oTextLine.Item(3)
                    'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf oTextLine.Item(1) = "Emission filter:" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sDetectionModeParameters(13) = oTextLine.Item(2) & " " & oTextLine.Item(3)
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf oTextLine.Item(1) = "Beamsplitter:" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(3). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sDetectionModeParameters(14) = oTextLine.Item(2) & " " & oTextLine.Item(3)
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf oTextLine.Item(1) = "Excitation polarizer filter:" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sDetectionModeParameters(15) = oTextLine.Item(2)
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf oTextLine.Item(1) = "Emission polarizer filter:" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sDetectionModeParameters(16) = oTextLine.Item(2)
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf oTextLine.Item(1) = "Detector counting:" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sDetectionModeParameters(17) = oTextLine.Item(2)
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf oTextLine.Item(1) = "Flash lamp voltage:" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sDetectionModeParameters(18) = oTextLine.Item(2)
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf oTextLine.Item(1) = "Delay after flash:" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sDetectionModeParameters(19) = oTextLine.Item(2)
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf oTextLine.Item(1) = "Sensitivity setting:" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sDetectionModeParameters(20) = oTextLine.Item(2)
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf oTextLine.Item(1) = "A/D converter gain:" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sDetectionModeParameters(21) = oTextLine.Item(2)
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf oTextLine.Item(1) = "Integrating gain:" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sDetectionModeParameters(22) = oTextLine.Item(2)
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf oTextLine.Item(1) = "Max cps:" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sDetectionModeParameters(23) = oTextLine.Item(2)
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf oTextLine.Item(1) = "Min counts:" Then 
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sDetectionModeParameters(24) = oTextLine.Item(2)
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf oTextLine.Item(1) = "Detection mode:" Then 
					'saving the setting in the database
					
					SQLQuery = "INSERT INTO detection_mode( run_id, detection_mode, light_sensor, excitation_side, emission_side, lamp, readings_per_well, time_between_readings, integration_time, attenuator_mode, motion_settling_time, z_height, excitation_filter, emission_filter, beamsplitter, excitation_polarizer_filter, emission_polarizer_filter, detector_counting, flash_lamp_voltage, delay_after_flash, sensitivity_setting, ad_converter_gain, integrating_gain, max_cps, min_counts) VALUES(" & lRunId & ",'" & sDetectionModeParameters(1) & "','" & sDetectionModeParameters(2) & "','" & sDetectionModeParameters(3) & "','" & sDetectionModeParameters(4) & "','" & sDetectionModeParameters(5) & "','" & sDetectionModeParameters(6) & "','" & sDetectionModeParameters(7) & "','" & sDetectionModeParameters(8) & "','" & sDetectionModeParameters(9) & "','" & sDetectionModeParameters(10) & "','" & sDetectionModeParameters(11) & "','" & sDetectionModeParameters(12) & "','" & sDetectionModeParameters(13) & "','" & sDetectionModeParameters(14) & "','" & sDetectionModeParameters(15) & "','" & sDetectionModeParameters(16) & "','" & sDetectionModeParameters(17) & "','" & sDetectionModeParameters(18) & "','" & sDetectionModeParameters(19) & "','" & sDetectionModeParameters(20) & "','" & sDetectionModeParameters(21) & "','" & sDetectionModeParameters(22) & "','" & sDetectionModeParameters(23) & "','" & sDetectionModeParameters(24) & "')"
					
					
					oFPConnection.Execute(SQLQuery)
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
					sDetectionModeParameters(1) = oTextLine.Item(2)
					'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				ElseIf oTextLine.Item(1) = "Well list:" Then 
					
					'saving the setting in the database
					
					SQLQuery = "INSERT INTO detection_mode( run_id, detection_mode, light_sensor, excitation_side, emission_side, lamp, readings_per_well, time_between_readings, integration_time, attenuator_mode, motion_settling_time, z_height, excitation_filter, emission_filter, beamsplitter, excitation_polarizer_filter, emission_polarizer_filter, detector_counting, flash_lamp_voltage, delay_after_flash, sensitivity_setting, ad_converter_gain, integrating_gain, max_cps, min_counts) VALUES(" & lRunId & ",'" & sDetectionModeParameters(1) & "','" & sDetectionModeParameters(2) & "','" & sDetectionModeParameters(3) & "','" & sDetectionModeParameters(4) & "','" & sDetectionModeParameters(5) & "','" & sDetectionModeParameters(6) & "','" & sDetectionModeParameters(7) & "','" & sDetectionModeParameters(8) & "','" & sDetectionModeParameters(9) & "','" & sDetectionModeParameters(10) & "','" & sDetectionModeParameters(11) & "','" & sDetectionModeParameters(12) & "','" & sDetectionModeParameters(13) & "','" & sDetectionModeParameters(14) & "','" & sDetectionModeParameters(15) & "','" & sDetectionModeParameters(16) & "','" & sDetectionModeParameters(17) & "','" & sDetectionModeParameters(18) & "','" & sDetectionModeParameters(19) & "','" & sDetectionModeParameters(20) & "','" & sDetectionModeParameters(21) & "','" & sDetectionModeParameters(22) & "','" & sDetectionModeParameters(23) & "','" & sDetectionModeParameters(24) & "')"
					
					
					oFPConnection.Execute(SQLQuery)
					
					Exit Do
					
					
				End If
				
			Loop 
			
			
			' updating parameters for the parallel raw data
			'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			oFPConnection.Execute("UPDATE run SET raw_data_parallel_well_list = '" & oTextLine.Item(2) & "' WHERE id = " & lRunId)
			sTextLine = oTextStream.ReadLine
			oTextLine = StringTokenizer(oTextStream.ReadLine, Chr(9))
			'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			oFPConnection.Execute("UPDATE run SET raw_data_parallel_units= '" & oTextLine.Item(2) & "' WHERE id = " & lRunId)
			oTextLine = StringTokenizer(oTextStream.ReadLine, Chr(9))
			'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			oFPConnection.Execute("UPDATE run SET raw_data_parallel_display_format= '" & oTextLine.Item(2) & "' WHERE id = " & lRunId)
			'
			sTextLine = oTextStream.ReadLine()
			oTextLine = StringTokenizer(sTextLine, Chr(9))
			
			' reading the line which contains the column numbers for the plates
			' if the collection after the line has been tokenized is 25 items
			' it must be a 384 plate, if it is 13 items it is an 96 plate
			
			If oTextLine.Count() = 25 Then
				' setting up for 386 format
				' changing the size of the matrices
				'UPGRADE_WARNING: Lower bound of array iParallel was changed from 1,1 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
                ReDim iParallel(24, 16)
				'UPGRADE_WARNING: Lower bound of array iPerpendicular was changed from 1,1 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
				ReDim iPerpendicular(24, 16)
				'UPGRADE_WARNING: Lower bound of array iRatio was changed from 1,1 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
				ReDim iRatio(24, 16)
				
				' checking if the samples have already been created
				' ie checking if there are any realtaions in the
				' collection
				If PlateWellId.Count = 0 Then
					' if there aren't any relations
					' creating wells in the database that corresponds to a 384 plate
					For iWellRow = 0 To 15
						For iWellColumn = 1 To 24
							
							' asiking the database for the id number for the well
							' that has just been uploaded
							Rs.Open("SELECT id FROM plate_map WHERE well_row ='" & Chr(65 + iWellRow) & "' AND well_column = " & iWellColumn & " AND plate_id = " & lPlateId)
							
							If Not Rs.EOF Then 'Check if the well exists.
								PlateWellId.Add(Chr(65 + iWellRow) & iWellColumn, Val(Rs.Fields(0).Value))
							End If
							Rs.Close()
							
						Next iWellColumn
					Next iWellRow
				End If
				
				' saving the data from the file into matrices
				
                For iWellRow = 1 To 16
                    oTextLine = StringTokenizer(oTextStream.ReadLine(), Chr(9))
                    For iWellColumn = 1 To 24
                        ' because that the matrix starts at position 2 in the
                        ' tab dilimited file we need to save at position -1
                        ' in the matrix

                        'checking to see if the current position contains any data
                        'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(iWellColumn + 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                        If Not oTextLine.Item(iWellColumn + 1) = "" Then
                            ' if it had data we save it
                            'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
                            iParallel(iWellColumn, iWellRow) = CStr(Val(oTextLine.Item(iWellColumn + 1)))
                        End If
                    Next iWellColumn
                Next iWellRow
				
				'reading data for the perpendicular raw data
				oTextLine = StringTokenizer(oTextStream.ReadLine, Chr(9))
				'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				oFPConnection.Execute("UPDATE run SET raw_data_perpendicular_well_list = '" & oTextLine.Item(2) & "' WHERE id = " & lRunId)
				sTextLine = oTextStream.ReadLine
				oTextLine = StringTokenizer(oTextStream.ReadLine, Chr(9))
				'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				oFPConnection.Execute("UPDATE run SET raw_data_perpendicular_units= '" & oTextLine.Item(2) & "' WHERE id = " & lRunId)
				oTextLine = StringTokenizer(oTextStream.ReadLine, Chr(9))
				'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				oFPConnection.Execute("UPDATE run SET raw_data_perpendicular_display_format= '" & oTextLine.Item(2) & "' WHERE id = " & lRunId)
				
				sTextLine = oTextStream.ReadLine
				
				
				'filling the next matrix
				For iWellRow = 1 To 16
					oTextLine = StringTokenizer(oTextStream.ReadLine(), Chr(9))
					For iWellColumn = 1 To 24
						'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(iWellColumn + 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If Not oTextLine.Item(iWellColumn + 1) = "" Then
							'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							iPerpendicular(iWellColumn, iWellRow) = CStr(Val(oTextLine.Item(iWellColumn + 1)))
						End If
					Next iWellColumn
				Next iWellRow
				
				
				oTextLine = StringTokenizer(oTextStream.ReadLine, Chr(9))
				'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				oFPConnection.Execute("UPDATE run SET ratio_well_list = '" & oTextLine.Item(2) & "' WHERE id = " & lRunId)
				sTextLine = oTextStream.ReadLine
				oTextLine = StringTokenizer(oTextStream.ReadLine, Chr(9))
				'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				oFPConnection.Execute("UPDATE run SET ratio_units= '" & oTextLine.Item(2) & "' WHERE id = " & lRunId)
				oTextLine = StringTokenizer(oTextStream.ReadLine, Chr(9))
				'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				oFPConnection.Execute("UPDATE run SET ratio_display_format= '" & oTextLine.Item(2) & "' WHERE id = " & lRunId)
				
				sTextLine = oTextStream.ReadLine
				
				
				
				
				'filling the next matrix
				For iWellRow = 1 To 16
					oTextLine = StringTokenizer(oTextStream.ReadLine(), Chr(9))
					For iWellColumn = 1 To 24
						'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(iWellColumn + 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If Not oTextLine.Item(iWellColumn + 1) = "" Then
							'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							iRatio(iWellColumn, iWellRow) = CStr(Val(oTextLine.Item(iWellColumn + 1)))
						End If
					Next iWellColumn
				Next iWellRow
				
				' it is time to update to the database
				' using prepared statements as usual
				
				
				For iWellRow = 1 To 16
					For iWellColumn = 1 To 24
						' update to the database where samplename and plate id
						If (Not iParallel(iWellColumn, iWellRow) = "") And (Not iPerpendicular(iWellColumn, iWellRow) = "") And (Not iRatio(iWellColumn, iWellRow) = "") Then
							' checking to see that all the different matrices contains data
							' Make sure the well exists.
							If PlateWellId.Exists(Chr(65 + iWellRow - 1) & iWellColumn) Then
								cmdData.Parameters("raw_data_parallel").Value = iParallel(iWellColumn, iWellRow)
								cmdData.Parameters("raw_data_perpendicular").Value = iPerpendicular(iWellColumn, iWellRow)
								cmdData.Parameters("raw_data_ratio").Value = iRatio(iWellColumn, iWellRow)
								cmdData.Parameters("run_id").Value = lRunId
								'UPGRADE_WARNING: Couldn't resolve default property of object PlateWellId.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								cmdData.Parameters("plate_map_id").Value = PlateWellId.item(Chr(65 + iWellRow - 1) & iWellColumn)
								cmdData.Execute()
								' if we wrote data we need to assign this data to the correct
								' segment
								cmdSegment.Parameters("segment_id").Value = lSegmentId
								'UPGRADE_WARNING: Couldn't resolve default property of object PlateWellId.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								cmdSegment.Parameters("plate_map_id").Value = PlateWellId.item(Chr(65 + iWellRow - 1) & iWellColumn)
								cmdSegment.Execute()
							End If
						End If
					Next iWellColumn
				Next iWellRow
				
				
			ElseIf oTextLine.Count() = 13 Then 
				' setting up for 386 format
				' changing the size of the matrices
				'UPGRADE_WARNING: Lower bound of array iParallel was changed from 1,1 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
				ReDim iParallel(12, 8)
				'UPGRADE_WARNING: Lower bound of array iPerpendicular was changed from 1,1 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
				ReDim iPerpendicular(12, 8)
				'UPGRADE_WARNING: Lower bound of array iRatio was changed from 1,1 to 0,0. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="0F1C9BE1-AF9D-476E-83B1-17D43BECFF20"'
				ReDim iRatio(12, 8)
				
				' checking if the samples have already been created
				' ie checking if there are any realtaions in the
				' collection
				If PlateWellId.Count = 0 Then
					' if there aren't any relations
					' creating wells in the database that corresponds to a 384 plate
					For iWellRow = 0 To 7
						For iWellColumn = 1 To 12
							
							' asiking the database for the id number for the well
							' that has just been uploaded
							Rs.Open("SELECT id FROM plate_map WHERE well_row ='" & Chr(65 + iWellRow) & "' AND well_column = " & iWellColumn & " AND plate_id = " & lPlateId)
							
							PlateWellId.Add(Chr(65 + iWellRow) & iWellColumn, Val(Rs.Fields(0).Value))
							Rs.Close()
							
							'MsgBox Chr(65 + iWellRow) & iWellColumn
						Next iWellColumn
					Next iWellRow
				End If
				
				' saving the data from the file into matrices
				
				For iWellRow = 1 To 8
					oTextLine = StringTokenizer(oTextStream.ReadLine(), Chr(9))
					For iWellColumn = 1 To 12
						' because that the matrix starts at position 2 in the
						' tab dilimited file we need to save at position -1
						' in the matrix
						
						'checking to see if the current position contains any data
						'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(iWellColumn + 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If Not oTextLine.Item(iWellColumn + 1) = "" Then
							' if it had data we save it
							'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							iParallel(iWellColumn, iWellRow) = CStr(Val(oTextLine.Item(iWellColumn + 1)))
						End If
					Next iWellColumn
				Next iWellRow
				
				'reading data for the perpendicular raw data
				oTextLine = StringTokenizer(oTextStream.ReadLine, Chr(9))
				'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				oFPConnection.Execute("UPDATE run SET raw_data_perpendicular_well_list = '" & oTextLine.Item(2) & "' WHERE id = " & lRunId)
				sTextLine = oTextStream.ReadLine
				oTextLine = StringTokenizer(oTextStream.ReadLine, Chr(9))
				'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				oFPConnection.Execute("UPDATE run SET raw_data_perpendicular_units= '" & oTextLine.Item(2) & "' WHERE id = " & lRunId)
				oTextLine = StringTokenizer(oTextStream.ReadLine, Chr(9))
				'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				oFPConnection.Execute("UPDATE run SET raw_data_perpendicular_display_format= '" & oTextLine.Item(2) & "' WHERE id = " & lRunId)
				
				sTextLine = oTextStream.ReadLine
				
				
				'filling the next matrix
				For iWellRow = 1 To 8
					oTextLine = StringTokenizer(oTextStream.ReadLine(), Chr(9))
					For iWellColumn = 1 To 12
						'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(iWellColumn + 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If Not oTextLine.Item(iWellColumn + 1) = "" Then
							'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							iPerpendicular(iWellColumn, iWellRow) = CStr(Val(oTextLine.Item(iWellColumn + 1)))
						End If
					Next iWellColumn
				Next iWellRow
				
				
				oTextLine = StringTokenizer(oTextStream.ReadLine, Chr(9))
				'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				oFPConnection.Execute("UPDATE run SET ratio_well_list = '" & oTextLine.Item(2) & "' WHERE id = " & lRunId)
				sTextLine = oTextStream.ReadLine
				oTextLine = StringTokenizer(oTextStream.ReadLine, Chr(9))
				'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				oFPConnection.Execute("UPDATE run SET ratio_units= '" & oTextLine.Item(2) & "' WHERE id = " & lRunId)
				oTextLine = StringTokenizer(oTextStream.ReadLine, Chr(9))
				'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				oFPConnection.Execute("UPDATE run SET ratio_display_format= '" & oTextLine.Item(2) & "' WHERE id = " & lRunId)
				
				sTextLine = oTextStream.ReadLine
				
				
				
				
				'filling the next matrix
				For iWellRow = 1 To 8
					oTextLine = StringTokenizer(oTextStream.ReadLine(), Chr(9))
					For iWellColumn = 1 To 12
						'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(iWellColumn + 1). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
						If Not oTextLine.Item(iWellColumn + 1) = "" Then
							'UPGRADE_WARNING: Couldn't resolve default property of object oTextLine.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
							iRatio(iWellColumn, iWellRow) = CStr(Val(oTextLine.Item(iWellColumn + 1)))
						End If
					Next iWellColumn
				Next iWellRow
				
				' it is time to update to the database
				' using prepared statements as usual
				
				
				For iWellRow = 1 To 8
					For iWellColumn = 1 To 12
						' update to the database where samplename and plate id
						If (Not iParallel(iWellColumn, iWellRow) = "") And (Not iPerpendicular(iWellColumn, iWellRow) = "") And (Not iRatio(iWellColumn, iWellRow) = "") Then
							' checking to see that all the different matrices contains data
							' Check if the well exists.
							If PlateWellId.Exists(Chr(65 + iWellRow - 1) & iWellColumn) Then
								cmdData.Parameters("raw_data_parallel").Value = iParallel(iWellColumn, iWellRow)
								cmdData.Parameters("raw_data_perpendicular").Value = iPerpendicular(iWellColumn, iWellRow)
								cmdData.Parameters("raw_data_ratio").Value = iRatio(iWellColumn, iWellRow)
								cmdData.Parameters("run_id").Value = lRunId
								'UPGRADE_WARNING: Couldn't resolve default property of object PlateWellId.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								cmdData.Parameters("plate_map_id").Value = PlateWellId.item(Chr(65 + iWellRow - 1) & iWellColumn)
								cmdData.Execute()
								' if we wrote data we need to assign this data to the correct
								' segment
								cmdSegment.Parameters("segment_id").Value = lSegmentId
								'UPGRADE_WARNING: Couldn't resolve default property of object PlateWellId.item(). Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
								cmdSegment.Parameters("plate_map_id").Value = PlateWellId.item(Chr(65 + iWellRow - 1) & iWellColumn)
								cmdSegment.Execute()
							End If
						End If
					Next iWellColumn
				Next iWellRow
				
				
				
			Else
				MsgBox("unrecognized array format")
				RawDataFileParser = 0
				Exit Function
			End If
			
			
			
			
			
			If oTextStream.AtEndOfStream Then
				bBreak = True
			End If
			
			
		Loop 
		
		
		
		RawDataFileParser = lSegmentId
		' closing the file
		oTextStream.Close()
		
		
		
		' cleaning up
		'UPGRADE_NOTE: Object Rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Rs = Nothing
		'UPGRADE_NOTE: Object PlateWellId may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		PlateWellId = Nothing
		'UPGRADE_NOTE: Object oTextStream may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		oTextStream = Nothing
		'UPGRADE_NOTE: Object oTextLine may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		oTextLine = Nothing
		'UPGRADE_NOTE: Object oFileSysObj may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		oFileSysObj = Nothing
		
		
		Exit Function
		
RawDataFileParser_Error: 
		MsgBox(Err.Description)
		oTextStream.Close()
		'UPGRADE_NOTE: Object Rs may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		Rs = Nothing
		'UPGRADE_NOTE: Object PlateWellId may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		PlateWellId = Nothing
		'UPGRADE_NOTE: Object oTextStream may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		oTextStream = Nothing
		'UPGRADE_NOTE: Object oTextLine may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		oTextLine = Nothing
		'UPGRADE_NOTE: Object oFileSysObj may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		oFileSysObj = Nothing
		
		' need to remove all the tables that we just added
		' first remove the run table
		oFPConnection.Execute("DELETE FROM run WHERE id IN ( SELECT run_id FROM data WHERE plate_map_id IN ( SELECT id FROM plate_map WHERE segment_id = " & lSegmentId & "))")
		' then we remove the segment
		oFPConnection.Execute("DELETE FROM segment WHERE id = " & lSegmentId)
		
		
		
		Exit Function
	End Function
	
	Private Function StringTokenizer(ByRef sInputString As String, ByRef sDelimit As String) As Collection
		Dim temp As New Collection
		Dim iPosition As Short
		Dim bEnd As Boolean
        bEnd = False
        StringTokenizer = Nothing
		Do While Not bEnd
			iPosition = InStr(1, sInputString, sDelimit)
			If iPosition = 0 Then
				temp.Add(sInputString)
				bEnd = True
			Else
				temp.Add(Mid(sInputString, 1, iPosition - 1))
				sInputString = Mid(sInputString, iPosition + 1, Len(sInputString))
			End If
			
			StringTokenizer = temp
			
		Loop 
	End Function
	
	Public Sub UnloadAllForms()
		On Error Resume Next
		FPresultDB.Close()
		frmAddDate.Close()
		frmLoadOrderName.Close()
		frmPlateAdd.Close()
		frmPlateScheme.Close()
		frmPlateSchemeLoadOrder.Close()
		frmReadSampleName.Close()
		frmSelectMasterPlate.Close()
		frmSelectPlateSchemeName.Close()
		frmSelectSampleFile.Close()
		frmUserName.Close()
	End Sub
	
	'UPGRADE_ISSUE: VB.App object was not upgraded. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6B85A2A7-FE9F-4FBE-AA0C-CF11AC86A305"'
    Public Function isCorrectVersion(ByRef gtdbConnection As ADODB.Connection) As Boolean
        'Checks if the current application is allowed to connect to the database.

        Dim strSQLLine As String
        Dim strCurrentVersion As String
        Dim strCurrentApplication As String
        Dim Rs As New ADODB.Recordset

        On Error GoTo isCorrectVersion_Error

        isCorrectVersion = False 'Not sure it is alright yet.
        strCurrentVersion = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision
        strCurrentApplication = My.Application.Info.AssemblyName

        strSQLLine = "SELECT version_id FROM application_version WHERE identifier='" & strCurrentApplication & "' AND version='" & strCurrentVersion & "'"
        Call Rs.Open(strSQLLine, gtdbConnection)

        If Rs.EOF Then
            'No lines returned, i.e. current application version not listed in the database.
            isCorrectVersion = False
        Else
            'At least one line returned, this application is allowed to connect.
            isCorrectVersion = True
        End If

        Exit Function

isCorrectVersion_Error:
        MsgBox(Err.Description)
        isCorrectVersion = False

    End Function
	
	
	
	Private Function GetRegValue(ByVal hKey As Integer, ByVal sSectKey As String, ByVal sSubKey As String, ByRef sValue As String) As Boolean
		Dim lResult As Integer
		Dim phkResult As Integer
		Dim dWReserved As Integer
		Dim bFound As Short
		Dim szBuffer As String
		Dim lBuffSize As Integer
		Dim szBuffer2 As String
		Dim lBuffSize2 As Integer
		Dim lIndex As Integer
		Dim lType As Integer
		Dim sCompKey As String
		lIndex = 0
		lResult = RegOpenKeyEx(hKey, sSectKey, 0, 1, phkResult)
		
		
		Do While lResult = ERROR_SUCCESS And Not bFound
			szBuffer = Space(255)
			lBuffSize = Len(szBuffer)
			szBuffer2 = Space(255)
			lBuffSize2 = Len(szBuffer2)
			'Get next value.
			lResult = RegEnumValue(phkResult, lIndex, szBuffer, lBuffSize, dWReserved, lType, szBuffer2, lBuffSize2)
			
			If lResult = ERROR_SUCCESS Then
				sCompKey = Left(szBuffer, lBuffSize)
				If sCompKey = sSubKey Then
					sValue = Left(szBuffer2, lBuffSize2 - 1)
					bFound = True
				End If
			End If
			lIndex = lIndex + 1
		Loop 
		Call RegCloseKey(phkResult)
		GetRegValue = bFound
	End Function
	
	
	Public Function getPath(ByRef sFullFileName As String) As String
		Dim iLastSlashPos As Integer
		On Error GoTo errHandler
		
		
		iLastSlashPos = InStrRev(sFullFileName, "\")
		
		If iLastSlashPos <> 0 Then
			getPath = Left(sFullFileName, iLastSlashPos)
		Else
			getPath = ""
		End If
		Exit Function
errHandler: 
		getPath = ""
	End Function
	
	Public Function getPathVariable(ByRef sKey As String) As String
		Dim sValue As String
        sValue = ""
        getPathVariable = ""
		If GetRegValue(CInt(chiRegClassKey), chiRegSubSectionPathKey, sKey, sValue) Then
			getPathVariable = sValue
		End If
		
	End Function
	
	
	Public Sub SetPathVariable(ByRef Key As String, ByRef sPathVariable As String)
		Dim lResult As Integer
		Dim phkResult As Integer
		Dim lCreate As Integer
		Dim SecrtAttr As SECURITY_ATTRIBUTES
		
		Call RegCreateKeyEx(CInt(chiRegClassKey), chiRegSubSectionPathKey, 0, "", REG_OPTION_NON_VOLATILE, KEY_ALL_ACCESS, SecrtAttr, phkResult, lCreate)
		lResult = RegSetValueEx(phkResult, Key, 0, REG_SZ, sPathVariable, CInt(Len(sPathVariable) + 1))
		Call RegCloseKey(phkResult)
		
		If lResult <> ERROR_SUCCESS Then
			MsgBox("Could not update path settings in the registry.")
		End If
	End Sub
	
	Public Function ReadConfigString(ByRef configItem As String) As String
		Dim fso As New Scripting.FileSystemObject
		Dim configFile As Scripting.File
		Dim ts As Scripting.TextStream
		Dim s, item As Object
		Dim value As String
		Dim sArray() As String
		
		On Error GoTo errHandler
		
		configFile = fso.GetFile(chiConfigFileName)
		
		' Read the contents of the file.
		ts = configFile.OpenAsTextStream(Scripting.IOMode.ForReading)
		
		While (Not ts.AtEndOfStream)
			'UPGRADE_WARNING: Couldn't resolve default property of object s. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			s = ts.ReadLine
			'UPGRADE_WARNING: Couldn't resolve default property of object s. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
			sArray = Split(s, vbTab)
			If UBound(sArray, 1) > 0 Then
				'UPGRADE_WARNING: Couldn't resolve default property of object item. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				item = Trim(sArray(0))
				value = Trim(sArray(1))
				'UPGRADE_WARNING: Couldn't resolve default property of object item. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
				If UCase(item) = UCase(configItem) Then
					ReadConfigString = value
					ts.Close()
					Exit Function
				End If
			End If
		End While
		
		'Pass through to errHandler if could not read any value:
		
errHandler: 
		MsgBox("Could not read configuration value " & configItem & " from file " & chiConfigFileName)
		
		If Not ts Is Nothing Then
			ts.Close()
		End If
	End Function
End Module