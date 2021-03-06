﻿Namespace GameContent.Structures.[Shared].Drawing
    Public NotInheritable Class COH_Vector4
        Inherits COH_FileStructure

#Region "Enum"
        Public Enum InternalVerions
            Standard = 0
        End Enum
#End Region

#Region "Properties - Override"
        Public Overrides ReadOnly Property InternalDisplayName As String
            Get
                Return String.Format("{0},{1},{2},{3}", New Object(3) {X, Y, Z, W})
            End Get
        End Property
#End Region

#Region "Properties"
        <Xml.Serialization.XmlAttribute> Property X As Single
        <Xml.Serialization.XmlAttribute> Property Y As Single
        <Xml.Serialization.XmlAttribute> Property Z As Single
        <Xml.Serialization.XmlAttribute> Property W As Single
#End Region

#Region "Create New Instance"
        Public Sub New()
            MyBase.New
        End Sub
        Public Sub New(SetDefaults As Boolean, Optional Version As Integer = 0, Optional BuildType As COH_BuildType = COH_BuildType.Either)
            MyBase.New(SetDefaults, Version)
        End Sub
        Public Sub New(ByRef Buffer As Byte(), Optional Settings as COH_Serialization_Settings = Nothing)
            MyBase.New(Buffer, Settings)
        End Sub
        Public Sub New(ByRef Stream As IO.MemoryStream, Optional Settings as COH_Serialization_Settings = Nothing)
            MyBase.New(Stream, Settings)
        End Sub
        Public Sub New(ByRef CurrentReader As COH_BinaryReader)
            MyBase.New(CurrentReader)
        End Sub
        Public Overrides Sub ResetDefaults(Optional Version As Integer = 0)
            MyBase.ResetDefaults()
            Dim InternvalVerson As InternalVerions = Version
            Select Case InternvalVerson
                Case InternalVerions.Standard
                    X = Y = Z = W = 0
            End Select
        End Sub
#End Region

#Region "Update From MAP"
        Public Overrides Sub UpdateLocalizations(ByRef LocalizeController As ISupport_COH_LocalizeContent)
        End Sub
#End Region

#Region "Clone"
        Public Function Clone() As COH_Vector4
            Dim Result As COH_Vector4 = New COH_Vector4
            'MyBase.CloneTo(TryCast(Result, COH_FileStructure))
            With Result
                .X = X
                .Y = Y
                .Z = Z
                .W = W
                Return Result
            End With
        End Function
#End Region

#Region "Import/Export - CrypticS"
        Protected Overrides Function Write_ToStream(ByRef CurrentWriter As COH_BinaryWriter) As Boolean
            CurrentWriter.Write(X)
            CurrentWriter.Write(Y)
            CurrentWriter.Write(Z)
            CurrentWriter.Write(W)
            Return True
        End Function
        Protected Overrides Function Read_FromStream(ByRef CurrentReader As COH_BinaryReader) As Boolean
            X = CurrentReader.ReadSingle
            Y = CurrentReader.ReadSingle
            Z = CurrentReader.ReadSingle
            W = CurrentReader.ReadSingle
            Return True
        End Function
#End Region

    End Class
End Namespace
