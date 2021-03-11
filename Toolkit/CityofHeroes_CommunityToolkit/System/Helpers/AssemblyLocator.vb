Namespace Toolkit.Helpers
    Public NotInheritable Class Toolkit_AssemblyLocator

#Region "Properties"
        Public ReadOnly Property ProgramAssemblies As Reflection.[Assembly]
            Get
                Return pProgramAssemblies
            End Get
        End Property
        Public ReadOnly Property ProgramAssemblies_Referenced As Reflection.AssemblyName()
            Get
                Return pProgramAssemblies_Referenced
            End Get
        End Property
        Public ReadOnly Property ProgramAssemblies_Folder As String
            Get
                Return pSystemPath
            End Get
        End Property
#End Region

#Region "Private Properties"
        Private pSystemPath As String
        Private pProgramAssemblies As Reflection.[Assembly]
        Private pProgramAssemblies_Referenced() As Reflection.AssemblyName
#End Region

#Region "Initialize"
        Public Sub New(ByRef ExecutingAssembly As Reflection.[Assembly], SystemPath As String)
            pSystemPath = SystemPath
            pProgramAssemblies = ExecutingAssembly
            pProgramAssemblies_Referenced = ProgramAssemblies.GetReferencedAssemblies()
            '// AddHandler AppDomain.CurrentDomain.AssemblyResolve, AddressOf Resolve_DLL_PathsHandler
        End Sub
#End Region

#Region "Usage"
        Public Function Resolve_DLL_Path(ByVal sender As Object, ByVal args As ResolveEventArgs) As Reflection.[Assembly]
            If LCase(args.Name).Contains(".resources") Then
                Return Nothing
            ElseIf LCase(args.Name).Contains(".xmlserializers") Then
                Return Nothing
            End If
            Dim Reference As String = args.Name.Substring(0, args.Name.IndexOf(","))
            For Each AssemblyName As Reflection.AssemblyName In pProgramAssemblies_Referenced
                Dim Compare_Assembly As String = args.Name.Substring(0, args.Name.IndexOf(","))
                If Compare_Assembly = Reference Then Return LoadAssembly(Reference)
            Next
            TiggerShutDownError()
            Return Nothing
        End Function
        Private Function LoadAssembly(Reference As String) As Reflection.[Assembly]
            Dim Assembly_FilePath As String = IO.Path.Combine(pSystemPath, (Reference & ".dll"))
            If IO.File.Exists(Assembly_FilePath) = True Then
                Dim MyAssembly As Reflection.[Assembly]
                MyAssembly = Reflection.[Assembly].LoadFrom(Assembly_FilePath)
                Return MyAssembly
            Else
                TiggerShutDownError()
                Return Nothing
            End If
        End Function
        Private Sub TiggerShutDownError()
            'MsgBox("Assebly Missing!" & Environment.NewLine & Assembly_FilePath, MsgBoxStyle.Critical, ProgramName)
            'End
        End Sub
#End Region
    End Class
End Namespace