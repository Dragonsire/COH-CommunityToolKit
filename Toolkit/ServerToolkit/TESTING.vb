﻿Public Class TESTING
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Tester As New COH.Storage.DataBases.SQL_Lite.GameDatabase_SQL_Lite("E:\Project_COH_ToolKit\Tools\Servers\Accounts.DB", True)
    End Sub
End Class