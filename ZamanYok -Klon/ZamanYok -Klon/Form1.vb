Imports System.IO

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        NumericUpDown1.Value = 1
        NumericUpDown1.Maximum = 600
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Process.Start("http://coderzy.blogspot.com/")
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        Process.Start("https://twitter.com/CoderZY")
    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        Process.Start("https://plus.google.com/u/0/108018280406843929957")
    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox4.Click
        Process.Start("https://www.facebook.com/pages/Coderzy/469948773043640")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.OpenFileDialog1.Filter = "Tüm Dosyalar(*.*)|*.*"
        Me.OpenFileDialog1.FileName = ""
        Me.OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        Dim boyut As Integer
        TextBox1.Text = OpenFileDialog1.FileName
        Dim DosyaBoyutu As IO.FileInfo
        DosyaBoyutu = My.Computer.FileSystem.GetFileInfo(TextBox1.Text)
        boyut = DosyaBoyutu.Length / 1000000
        MessageBox.Show("Dosyanın Boyutu : " & boyut & " mb(s)")
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim flag As Boolean = String.Compare(Me.TextBox1.Text, "", False) = 0
        If flag Then
            Interaction.MsgBox("Lütfen şişirmek istediğiniz dosyayı seçiniz!", MsgBoxStyle.Exclamation, "Hata!")
        Else
            flag = (Decimal.Compare(Me.NumericUpDown1.Value, 0D) = 0)
            If flag Then
                Interaction.MsgBox("Lütfen dosyayı kaç mb şişirmek istediğinizi yazınız!", MsgBoxStyle.Exclamation, "Hata!")
            Else
                Try
                    Dim fileStream As FileStream = File.OpenWrite(Me.TextBox1.Text)
                    Dim num As Long = fileStream.Seek(0L, SeekOrigin.[End])
                    Dim num2 As Integer = Convert.ToInt32(Me.NumericUpDown1.Value)
                    Dim d As Decimal = New Decimal(CLng((num2 * 1048576)) + fileStream.Length)
                    While Decimal.Compare(New Decimal(num), d) < 0
                        num += 1L
                        fileStream.WriteByte(0)
                    End While
                    fileStream.Close()
                    Interaction.MsgBox("Dosya başarıyla şişirildi", MsgBoxStyle.Information, "Başarılı!")
                Catch ex As Exception
                    Interaction.MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Hata!")
                End Try
            End If
        End If
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
