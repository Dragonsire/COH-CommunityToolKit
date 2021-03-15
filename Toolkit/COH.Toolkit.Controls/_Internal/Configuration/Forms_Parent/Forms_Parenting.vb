Imports System.ComponentModel

Namespace Controls.Configuration
    <TypeConverter(GetType(ExpandableObjectConverter))>
    Public Class FormsConfiguration_Parenting

#Region "Properties"
        Public Property ParentForm As Form '//Not Saved
        Public Property ParentFormDock As DockStyle
        Public Property ParentLocation As Rectangle
        Public Property TopMost As Boolean
        Public Property Form_StartPosition As FormStartPosition
            Get
                Return rForm_StartPosition
            End Get
            Set(value As FormStartPosition)
                Select Case value
                    Case FormStartPosition.CenterParent, FormStartPosition.CenterScreen
                        rForm_StartPosition = FormStartPosition.CenterParent
                    Case Else
                        rForm_StartPosition = FormStartPosition.Manual
                End Select
            End Set
        End Property
        Private rForm_StartPosition As FormStartPosition
#End Region

#Region "Create New Instance"
        Public Sub New()
            Me.New(True)
        End Sub
        Public Sub New(ResetDefaults As Boolean)
            MyBase.New
            If ResetDefaults = True Then ResetToDefault()
        End Sub
        Public Sub ResetToDefault()
            ParentLocation = Nothing
            ParentForm = Nothing
            ParentFormDock = DockStyle.None
            rForm_StartPosition = FormStartPosition.CenterParent
            TopMost = False
        End Sub
#End Region

#Region "Updating Form"
        Public Sub ModifyForm_FromSettings(ByRef SelectedForm As Form)
            ModifyForm_FromSettings(Me, SelectedForm)
        End Sub
        Public Shared Sub ModifyForm_FromSettings(ByRef Settings As FormsConfiguration_Parenting, ByRef SelectedForm As Form)
            If Settings Is Nothing Then Exit Sub
            If Settings.ParentForm Is Nothing Then Exit Sub
            With SelectedForm
                '//.MdiParent = Settings.ParentForm
                .TopLevel = False
                .TopMost = Settings.TopMost
                If .TopMost = False Then
                    .Dock = DockStyle.None
                    .StartPosition = FormStartPosition.Manual
                    Settings.ParentForm.Controls.Add(SelectedForm)
                    .MdiParent = Settings.ParentForm
                    .Size = Settings.ParentLocation.Size
                    .Location = Settings.ParentLocation.Location
                    .WindowState = FormWindowState.Maximized
                Else
                    .StartPosition = Settings.Form_StartPosition
                    .Dock = Settings.ParentFormDock
                    Settings.ParentForm.Controls.Add(SelectedForm)
                End If
            End With
        End Sub
#End Region

#Region "Clone"
        Public Overloads Function CreateClone() As FormsConfiguration_Parenting
            Dim Destination As New FormsConfiguration_Parenting
            CloneTo(Destination)
            Return Destination
        End Function
        Public Overloads Sub CloneTo(ByRef Destination As FormsConfiguration_Parenting)
            With Destination
                .ParentLocation = New Rectangle(ParentLocation.Location, ParentLocation.Size)
                .ParentForm = ParentForm
                .ParentFormDock = ParentFormDock
                .TopMost = TopMost
            End With
        End Sub
#End Region

    End Class
End Namespace