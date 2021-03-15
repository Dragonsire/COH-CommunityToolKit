Imports System.ComponentModel

Namespace Storage.Structures
    Public MustInherit Class COH_ObservableObject
        Implements ISupportInitialize, INotifyPropertyChanged

#Region "Private Properties"
        Public Enum ObjectState_Enum
            [New] = 0
            Initializing = 1
            Modifying = 2
            Ready = 128
            Modified = 250
            Modified_AlreadyNotified = 251
            Disposed = 254
            ShowAll = 255
        End Enum
        Private rCurrentState As ObjectState_Enum
#End Region

#Region "Create New Instance"
        Public Sub New()
            Me.New(True)
        End Sub
        Public Sub New(ResetDefaults As Boolean)
            MyBase.New
            rCurrentState = ObjectState_Enum.New
            If ResetDefaults = True Then ResetToDefault()
            rCurrentState = ObjectState_Enum.Ready
        End Sub
#End Region

#Region "Initialize"
        Public Overridable Sub ResetToDefault()
            OnModified()
        End Sub
        Public Sub BeginInit() Implements ISupportInitialize.BeginInit
            rCurrentState = ObjectState_Enum.Initializing
        End Sub
        Public Sub EndInit() Implements ISupportInitialize.EndInit
            rCurrentState = ObjectState_Enum.Ready
        End Sub
#End Region

#Region "Modifications"
        Public Event WasModified As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged
        Protected Function UpdatePrivateProperty(Of T)(ByRef PrivateValue As T, ByVal value As T, <Runtime.CompilerServices.CallerMemberName> ByVal Optional PropertyName As String = "") As Boolean
            If Object.Equals(PrivateValue, value) Then Return False
            PrivateValue = value
            OnModified(PropertyName)
            Return True
        End Function
        Protected Sub OnModified(Optional PropertyName As String = "")
            If rCurrentState = ObjectState_Enum.Modified_AlreadyNotified Then Exit Sub
            If rCurrentState >= ObjectState_Enum.Ready Then rCurrentState = ObjectState_Enum.Modified
            If rCurrentState = ObjectState_Enum.Modified Then
                OnHandleModified()
                RaiseEvent WasModified(Me, New PropertyChangedEventArgs(PropertyName))
                rCurrentState = ObjectState_Enum.Modified_AlreadyNotified
            End If
        End Sub
        Protected Overridable Sub OnHandleModified()
        End Sub
        Public Function Check_WasModified() As Boolean
            If rCurrentState = ObjectState_Enum.Modified Then Return True
            If rCurrentState = ObjectState_Enum.Modified_AlreadyNotified Then Return True
            Return False
        End Function
        Protected Sub Update_CurrentState(CurrentState As ObjectState_Enum)
            rCurrentState = CurrentState
        End Sub
#End Region
    End Class
End Namespace