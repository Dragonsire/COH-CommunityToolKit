﻿Namespace GameContent.Structures.Resources
    Public Class COH_Resource_GEO_PackNames

#Region "Private Properties"
        Property Names() As String
        Property count As Integer
#End Region

#Region "Create New Instances"
        Public Sub New()
            MyBase.New
        End Sub
#End Region

#Region "Update"
        Private Sub Update_FromBytes(Version As Integer, RawBytes As Byte())
            Dim Stream As New IO.MemoryStream(RawBytes)
            Using CurrentReader As New COH_BinaryReader(Stream)

            End Using
        End Sub
#End Region

    End Class
End Namespace