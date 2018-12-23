Imports System
Imports System.Net
Imports System.Text
Imports System.Security
Imports System.Security.Cryptography

Public Class Form1

    Public Function MD5(ByVal Source) As String
        Dim Bytes() As Byte = ASCIIEncoding.ASCII.GetBytes(Source)
        Dim md5h As New MD5CryptoServiceProvider
        Dim Byt() As Byte = md5h.ComputeHash(Bytes)
        Dim i As Integer = (Byt.Length * 2 + (Byt.Length / 8))
        Dim StrBuild As StringBuilder = New StringBuilder(i)
        Dim i2 As Integer
        For i2 = 0 To Byt.Length - 1
            StrBuild.Append(BitConverter.ToString(Byt, i2, 1))
        Next i2
        Return StrBuild.ToString().TrimEnd(New Char() {" "c}).ToLower
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox2.Text = MD5(TextBox2.Text)
    End Sub

    Private Sub btnConvert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TextBox2.Text = MD5(TextBox1.Text)
    End Sub

    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Clipboard.SetDataObject(TextBox2.Text)
    End Sub
End Class
