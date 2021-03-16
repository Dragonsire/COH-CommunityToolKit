Namespace Controls
    Public NotInheritable Class FormRegion_Button
        Inherits FormRegion

#Region "Properties - Display"
#End Region

#Region "Initialize"
        Public Sub New()
            MyBase.New
        End Sub
        Public Sub New(ResetDefaults As Boolean)
            MyBase.New(ResetDefaults)
        End Sub
        Public Sub New(UniqueTag As String, IsEnabled As Boolean, IsVisible As Boolean, Optional IsMouseRegion As Boolean = True)
            MyBase.New(UniqueTag, IsEnabled, IsVisible, IsMouseRegion)
        End Sub
        Public Overrides Sub ResetToDefault()
            '///ALL HERE
            MyBase.ResetToDefault()
        End Sub
#End Region

#Region "Drawing"
        Public Overrides Function Draw(ByRef CurrentDrawing As Graphics, Optional Forced As Boolean = False) As Boolean
            Throw New NotImplementedException()
        End Function
#End Region

#Region "Clone/Write"
        Public Overrides Function Clone() As Object
            Dim Destination As New FormRegion_Button()
            CloneTo(Destination)
            Return Destination
        End Function
        Protected Overloads Sub CloneTo(ByRef Destination As FormRegion_Button)
            With Destination
                MyBase.CloneTo(Destination)
            End With
        End Sub
#End Region
    End Class
End Namespace