Namespace Internal.Events
    Public Class COH_Event_Error
        Inherits EventArgs

#Region "Enums"
        Public Enum COH_ErrorEvent
            Debug = 0
            ControlledError = 1
            FatalError = 2
        End Enum
#End Region

#Region "Properties"
        Public ReadOnly Property ErrorLevel As COH_ErrorEvent
            Get
                Return mErrorLevel
            End Get
        End Property
        Public ReadOnly Property Message As String
            Get
                Return mMessage
            End Get
        End Property
        Public ReadOnly Property MessageException As Exception
            Get
                Return mException
            End Get
        End Property
        Public Property ThrowException As Boolean
            Get
                Return mThrowException
            End Get
            Set(value As Boolean)
                mThrowException = value
            End Set
        End Property
        Public Property AllowContinue As Boolean
            Get
                Return mContinue
            End Get
            Set(value As Boolean)
                mContinue = value
            End Set
        End Property
#End Region

#Region "Private Usage"
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mContinue As Boolean
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mMessage As String
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mException As Exception
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mErrorLevel As COH_ErrorEvent
        <EditorBrowsable(COH_DeveloperMode_ShowPrivate)> Private mThrowException As Boolean
#End Region

#Region "Initialize"
        Public Sub New()
            mMessage = ""
            mContinue = True
            mErrorLevel = COH_ErrorEvent.Debug
        End Sub
        Public Sub New(TheEvent As COH_ErrorEvent, Message As String, Optional ByRef ErrorException As Exception = Nothing, Optional AllowContinue As Boolean = False)
            mMessage = Message
            mContinue = AllowContinue
            mErrorLevel = TheEvent
            mException = ErrorException
            mThrowException = Not (MessageException Is Nothing)
        End Sub
#End Region
    End Class
End Namespace
