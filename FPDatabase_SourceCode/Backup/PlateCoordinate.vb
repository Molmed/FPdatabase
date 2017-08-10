Option Strict Off
Option Explicit On
Friend Class PlateCoordinate
	
	Private sRow As String
	Private lColumn As Integer
	
	Public Sub Initialize(ByVal sInRow As String, ByVal lInColumn As Integer)
		sRow = sInRow
		lColumn = lInColumn
	End Sub
	
	Public ReadOnly Property getRowNr() As Integer
		Get
			getRowNr = Asc(sRow) - 64
		End Get
	End Property
	
	Public ReadOnly Property getColumnNr() As Integer
		Get
			getColumnNr = lColumn
		End Get
	End Property
End Class