Imports System.Data.SqlClient
Imports System.Data.DataView
Public Class Form1

    Dim dv As New System.Data.DataView
    Private Sub MostrarDatos()
        ' Creacion de la Cadena de Conexion
        Dim cadena As String = "Server=SERVIDOR01\SQLEXPRESS;DataBase=AdventureWorks2012;Integrated Security=SSPI"
        Using connection As New SqlConnection(cadena)
            connection.Open()
            Dim dt As New DataTable("Department")
            Dim adapter As SqlDataAdapter = New SqlDataAdapter("Select * From HumanResources.Department", connection)
            adapter.Fill(dt)
            dv.Table = dt
            DataGridView1.DataSource = dv
        End Using
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MostrarDatos()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try
            dv.RowFilter = String.Format("Name Like '%{0}%'", TextBox1.Text)
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
End Class
