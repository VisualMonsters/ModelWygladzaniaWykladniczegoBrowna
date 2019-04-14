Public Class Form2
    Private FileName As String
    Private ds As New DataSet()
    Dim srednie As New List(Of Double)
    Dim start As Integer = 0
    Dim koniec As Integer = 0
    Dim iloscKolumn As Integer = 0
    Dim kontroler As Boolean = False


    Private Sub DaneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DaneToolStripMenuItem.Click

        OpenFileDialog1.Filter = "csv files|;*.csv;*.txt;"
        OpenFileDialog1.Title = "Select a csv, dat file"
        OpenFileDialog1.FileName = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        start = 0
        Try
            With OpenFileDialog1
                If .ShowDialog() = DialogResult.OK Then
                    FileName = .FileName

                    If kontroler = False Then
                        Dim myData As DataTable = TworzTabele(FileName, TextBox1.Text) ' inicjacja nowej tabeli i wypełnienie jej funkcją
                        ds.Tables.Add(myData) ' wypełnienie bazy danych informacjami z tabeli
                        DataGridView1.DataSource = myData ' wyświetlenie tabeli w DatagridView
                        koniec = DataGridView1.Rows.Count - 1
                        TextBox2.Text = start
                        TextBox3.Text = koniec
                        kontroler = True
                    Else
                        DataGridView2.Rows.Clear()
                        Panel1.Controls.Clear()
                        ds.Clear()
                        ds.Tables.Clear()
                        DataGridView1.DataSource = Nothing
                        srednie.Clear()

                        Dim myData As DataTable = TworzTabele(FileName, TextBox1.Text) ' inicjacja nowej tabeli i wypełnienie jej funkcją
                        ds.Tables.Add(myData) ' wypełnienie bazy danych informacjami z tabeli
                        DataGridView1.DataSource = myData


                        koniec = DataGridView1.Rows.Count - 1
                        TextBox2.Text = start
                        TextBox3.Text = koniec
                    End If

                End If
            End With
        Catch
        End Try


    End Sub


    Private Function TworzTabele(ByVal SciezkaDoPliku As String, ByVal separator As String) As DataTable


        Dim Tabela As DataTable = New DataTable("MyTable")
        Dim i As Integer
        Dim wiersze As DataRow
        Dim wartosc As String()
        Dim f As IO.File = Nothing
        Dim rodzajkodu As New IO.StreamReader(SciezkaDoPliku, System.Text.Encoding.UTF8)

        Try
            If TextBox1.Text.ToUpper = "VBTAB" Then
                wartosc = rodzajkodu.ReadLine().Split(vbTab)
            Else
                wartosc = rodzajkodu.ReadLine().Split(separator)
            End If


            For i = 0 To wartosc.Length() - 1
                Tabela.Columns.Add(New DataColumn("kolumna" & i))
                Dim checkBox = New CheckBox()
                Panel1.Controls.Add(checkBox)
                checkBox.Location = New Point(10, 20 + 20 * i)
                checkBox.Text = "kolumna" & i
            Next

            wiersze = Tabela.NewRow
            For i = 0 To wartosc.Length() - 1
                wiersze.Item(i) = wartosc(i).ToString
            Next
            Tabela.Rows.Add(wiersze)
            While rodzajkodu.Peek() <> -1
                wartosc = rodzajkodu.ReadLine().Split(separator)
                wiersze = Tabela.NewRow
                For i = 0 To wartosc.Length() - 1
                    wiersze.Item(i) = wartosc(i).ToString
                Next
                Tabela.Rows.Add(wiersze)
            End While
        Catch ex As Exception
            MsgBox("Error building datatable: " & ex.Message)
            Return New DataTable("Empty")
        Finally
            rodzajkodu.Close()
        End Try

        Return Tabela
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox2.Text = ""
        TextBox3.Text = ""
        Dim listawewnatrz As New List(Of String)

        For j As Integer = 0 To DataGridView1.RowCount - 1
            Dim wiersz As String = ""
            For i As Integer = 0 To DataGridView1.ColumnCount - 1
                wiersz += DataGridView1.Rows(j).Cells(i).Value
            Next
            listawewnatrz.Add(wiersz)
        Next

        Panel1.Controls.Clear()
        ds.Clear()
        ds.Tables.Clear()
        DataGridView1.DataSource = Nothing
        Dim myData As DataTable
        If TextBox1.Text.ToUpper = "VBTAB" Then
            myData = TworzTabele3(listawewnatrz, vbTab)
        Else
            myData = TworzTabele3(listawewnatrz, TextBox1.Text)
        End If
        ' inicjacja nowej tabeli i wypełnienie jej funkcją
        ds.Tables.Add(myData) ' wypełnienie bazy danych informacjami z tabeli
        DataGridView1.DataSource = myData
        DataGridView2.Rows.Clear()
        srednie.Clear()
        koniec = DataGridView1.Rows.Count - 1
        TextBox2.Text = start
        TextBox3.Text = koniec
        If DataGridView1.ColumnCount = 1 Then
            Button2.Text = "Przenieś dane do różnicowania"
        Else
            Button2.Text = "Wylicz średnią z kolumn"
        End If
    End Sub

    Private Function TworzTabele3(ByVal SciezkaDoPliku As List(Of String), ByVal separator As String) As DataTable
        Dim Tabela As DataTable = New DataTable("MyTable")
        Dim i As Integer
        Dim wiersze As DataRow
        Dim f As IO.File = Nothing
        Dim wartosc As String()
        Try

            If TextBox1.Text.ToUpper = "VBTAB" Then
                wartosc = SciezkaDoPliku(0).Split(vbTab)
            Else
                wartosc = SciezkaDoPliku(0).Split(separator)
            End If

            For i = 0 To wartosc.Length() - 1
                Tabela.Columns.Add(New DataColumn("kolumna" & i))
                Dim checkBox = New CheckBox()
                Panel1.Controls.Add(checkBox)
                checkBox.Location = New Point(10, 20 + 20 * i)
                checkBox.Text = "kolumna" & i
            Next


            For k As Integer = 0 To SciezkaDoPliku.Count - 1
                wartosc = SciezkaDoPliku(k).Split(separator)
                wiersze = Tabela.NewRow
                For i = 0 To wartosc.Length() - 1
                    wiersze.Item(i) = wartosc(i).ToString
                Next
                Tabela.Rows.Add(wiersze)
            Next
        Catch ex As Exception
            MsgBox("Error building datatable: " & ex.Message)
            Return New DataTable("Empty")
        End Try
        Return Tabela
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        start = TextBox2.Text
        koniec = TextBox3.Text
        Try
            For Each elements In Panel1.Controls



                If elements.checked = True Then
                    iloscKolumn += 1
                    If srednie.Count = 0 Then
                        For i As Integer = start To koniec
                            If Not IsNumeric(DataGridView1.Rows(i).Cells(elements.text).value) Then
                                srednie.Add(Replace(DataGridView1.Rows(i).Cells(elements.text).value, ".", ","))
                            Else
                                srednie.Add(DataGridView1.Rows(i).Cells(elements.text).value)
                            End If
                        Next
                    Else
                        For i As Integer = 0 To srednie.Count - 1
                            If Not IsNumeric(DataGridView1.Rows(i).Cells(elements.text).value) Then
                                srednie(i) = srednie(i) + Replace(DataGridView1.Rows(i + start).Cells(elements.text).value, ".", ",")
                            Else
                                srednie(i) = srednie(i) + Replace(DataGridView1.Rows(i + start).Cells(elements.text).value, ".", ",")
                            End If
                        Next
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        For i As Integer = 0 To srednie.Count - 1
            DataGridView2.Rows.Add()
            DataGridView2.Rows(i).Cells(0).Value = srednie(i) / iloscKolumn
            srednie(i) = srednie(i) / iloscKolumn
        Next
        Button2.Enabled = False
        Button6.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        DataGridView2.Rows.Clear()
        srednie.Clear()
        Button2.Enabled = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim sfd As New SaveFileDialog
        With sfd
            .FileName = "nowa"
            .Filter = "Text File|*.txt"
        End With
        Dim sep As String
        sep = InputBox("Wprowadź rodzaj separatora. Puste pole oznacza vbNewline.", "Separator", "")
        If sep = "" Then
            If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                Call data_to_txt(srednie, sfd.FileName, ControlChars.NewLine)
                MsgBox("Zapis udany.")
            End If
        Else
            If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
                Call data_to_txt(srednie, sfd.FileName, sep)
                MsgBox("Zapis udany.")
            End If
        End If

    End Sub

    Private Sub data_to_txt(ByVal dt As List(Of Double), ByVal filename As String, ByVal sep As String)
        Dim sw As New IO.StreamWriter(filename, False)
        For col As Integer = 0 To srednie.Count - 1
            sw.Write((srednie(col) / iloscKolumn).ToString & sep)
        Next
        sw.Close()
    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ModelBrowna.Sredniegieldowe(srednie)
    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        DataGridView2.Rows.Clear()

        DataGridView2.Rows.Add()
        DataGridView2.Rows(0).Cells(0).Value = srednie(0)
        For i As Integer = 1 To srednie.Count - 1
            DataGridView2.Rows.Add()
            DataGridView2.Rows(i).Cells(0).Value = srednie(i) - srednie(i - 1)
        Next
        srednie.Clear()
        For i As Integer = 0 To DataGridView2.Rows.Count - 1
            srednie.Add(DataGridView2.Rows(i).Cells(0).Value)
        Next
        Label5.Text = Label5.Text + 1
    End Sub

    Private Sub DataGridView1_DragDrop(sender As Object, e As DragEventArgs) Handles DataGridView1.DragDrop

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim MyFiles() As String
            ' Assign the files to an array.
            MyFiles = e.Data.GetData(DataFormats.FileDrop)
            ' Display the file Name
            'TextBoxDrop.Text = MyFiles(0)
            ' Display the file contents
            Dim str As String = My.Computer.FileSystem.ReadAllText(MyFiles(0))
            Dim parts As String() = str.Split(New String() {Environment.NewLine}, StringSplitOptions.None)

            Dim listawewnatrz As New List(Of String)
            For j As Integer = 0 To parts.Count - 1

                listawewnatrz.Add(parts(j))
            Next

            ds.Clear()
            ds.Tables.Clear()
            DataGridView1.DataSource = Nothing
            Dim myData As DataTable
            myData = TworzTabele2(listawewnatrz)
            ds.Tables.Add(myData) ' wypełnienie bazy danych informacjami z tabeli
            DataGridView1.DataSource = myData
            DataGridView2.Rows.Clear()
            srednie.Clear()
            koniec = DataGridView1.Rows.Count - 1
            TextBox2.Text = start
            TextBox3.Text = koniec
        Else
            Dim str As String = e.Data.GetData("Text").ToString()
            Dim parts As String() = str.Split(New String() {Environment.NewLine}, StringSplitOptions.None)

            Dim listawewnatrz As New List(Of String)
            For j As Integer = 0 To parts.Count - 1
                listawewnatrz.Add(parts(j))
            Next

            ds.Clear()
            ds.Tables.Clear()
            DataGridView1.DataSource = Nothing
            Dim myData As DataTable
            myData = TworzTabele2(listawewnatrz)
            ds.Tables.Add(myData) ' wypełnienie bazy danych informacjami z tabeli
            DataGridView1.DataSource = myData
            DataGridView2.Rows.Clear()
            srednie.Clear()
            koniec = DataGridView1.Rows.Count - 1
            TextBox2.Text = start
            TextBox3.Text = koniec


        End If
    End Sub

    Private Function TworzTabele2(ByVal SciezkaDoPliku As List(Of String)) As DataTable
        Dim Tabela As DataTable = New DataTable("MyTable")
        Dim i As Integer
        Dim wiersze As DataRow
        Dim f As IO.File = Nothing
        Try

            Tabela.Columns.Add(New DataColumn("kolumna" & 0))
            Dim checkBox = New CheckBox()
            Panel1.Controls.Add(checkBox)
            checkBox.Location = New Point(10, 20 + 20 * 0)
            checkBox.Text = "kolumna" & 0

            wiersze = Tabela.NewRow
            For i = 0 To SciezkaDoPliku.Count - 1
                wiersze = Tabela.NewRow
                wiersze.Item(0) = SciezkaDoPliku(i)
                Tabela.Rows.Add(wiersze)
            Next

        Catch ex As Exception
            MsgBox("Error building datatable: " & ex.Message)
            Return New DataTable("Empty")
        End Try
        Return Tabela
    End Function

    Private Sub DataGridView1_DragEnter(sender As Object, e As DragEventArgs) Handles DataGridView1.DragEnter
        Dim availableFormats As String() = e.Data.GetFormats()

        'check to see if a desired format is contained in the drag object
        If (e.Data.GetDataPresent("Text")) Then
            'if it is then set the mode to "Copy", which will leave the data in the excel sheet
            e.Effect = DragDropEffects.Copy
        ElseIf e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        Else
            'if not, then prevent the drop, changing the cursor to the "not allowed" version
            e.Effect = DragDropEffects.None
        End If

    End Sub

    Private Sub DataGridView1_MouseUp(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseUp

        If e.Button <> Windows.Forms.MouseButtons.Right Then Return
        Dim cms = New ContextMenuStrip

        Dim item1 = cms.Items.Add("Wklej")
        item1.Tag = 1
        AddHandler item1.Click, AddressOf menuChoice
        Dim item2 = cms.Items.Add("Kopiuj")
        item2.Tag = 2
        AddHandler item2.Click, AddressOf menuChoice
        '-- etc
        '..
        cms.Show(DataGridView1, e.Location)
    End Sub


    Private Sub menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        '-- etc
        If selection = 1 Then
            If Clipboard.ContainsText Then

                Dim str As String = Clipboard.GetText 'e.Data.GetData("Text").ToString()

                Dim parts As String()

                parts = str.Split(New String() {Environment.NewLine}, StringSplitOptions.None)
                Dim listawewnatrz As New List(Of String)
                For j As Integer = 0 To parts.Count - 1
                    listawewnatrz.Add(parts(j))
                Next

                ds.Clear()
                ds.Tables.Clear()
                DataGridView1.DataSource = Nothing
                Dim myData As DataTable
                myData = TworzTabele2(listawewnatrz)
                ds.Tables.Add(myData) ' wypełnienie bazy danych informacjami z tabeli
                DataGridView1.DataSource = myData
                DataGridView2.Rows.Clear()
                srednie.Clear()
                koniec = DataGridView1.Rows.Count - 1
                TextBox2.Text = start
                TextBox3.Text = koniec

            End If
        ElseIf selection = 2 Then

            Try
                Clipboard.SetDataObject(Me.DataGridView1.GetClipboardContent())
            Catch ex As System.Runtime.InteropServices.ExternalException
                MsgBox("The Clipboard could not be accessed. Please try again.")
            End Try

        End If

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolTip1.SetToolTip(Label6, "Inne separatory:" + vbNewLine + "Tabulator - vbTab")
    End Sub
End Class
