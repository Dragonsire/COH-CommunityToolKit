Public Class TESTING
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Tester As New COH.Storage.DataBases.SQL_Lite.GameDatabase_SQL_Lite("E:\Project_COH_ToolKit\Tools\Servers\Accounts.DB", True)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Dim Tester As New COH.Storage.DataBases.SQL.GameDatabase_SQL
        ' Tester.Database_OpenConnection_WinAuth()
        ' Tester.DeleteDatabase()
        ' Tester.CreateDatabase()
        Dim Wrap = COH.Storage.DataBases.SQL.GameDatabase_SQL.CreateWrapper_AccountDatabase("COH_ACC", "E:\COH_TEST.MDF")
        Dim T = Wrap.Export_CommandString_Create
        Dim T2 = Wrap.Tables(0).Export_CommandString_Create
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click_2(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click_3(sender As Object, e As EventArgs)

    End Sub
End Class