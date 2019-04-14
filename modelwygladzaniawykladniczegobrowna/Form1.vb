Imports System.Windows.Forms.DataVisualization.Charting

Public Class ModelBrowna

    Private filename As String ''przechowuje ścieżkę naszego pliku 
    Dim wartoscAlfa As Double = 0.4 ''początkowa wartość alfa
    Dim dane As New List(Of Double) ''przechowuje nasze dane w formie tablicy
    Dim prognozy As New List(Of Double) ''przechowuje nasze prognozy
    Dim kontroler As Boolean = True

  

    Private Sub DodajDaneToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DodajDaneToolStripMenuItem.Click

        'filtr danych
        WczytajDane.Filter = "csv files|;*.csv;*.txt"
        WczytajDane.Title = "Select a csv file"
        WczytajDane.FileName = ""

        Try
            With WczytajDane
                If .ShowDialog() = DialogResult.OK Then

                    '' kontroler posłuży nam do zaznaczania czy dane są wczytanie czy też nie,
                    '' daje to możliwość załadowania innych danych jeśli te nam już nie będą potrzebna.
                    If kontroler = False Then


                        dane.Clear() 'czyści tablice
                        prognozy.Clear()

                        dgv_dane.Rows.Clear() 'czyści datagridview
                        filename = .FileName 'ładuje ścieżkę pliku do zmiennej string
                        FilePath.Text = filename 'wizualizuje ścieżkę pliku w textboxie
                        alfa2.Text = wartoscAlfa.ToString ' wizualizuje wzsłczynnik alfa

                        TworzTabele(filename) ' funkcja przetwarzająca nasze dane z 
                        'pliku txt i ładujące je do tablicy (nie gotowa na tym etapie)
                        Metoda_Browna(wartoscAlfa) ' funkcja tworząca metode Browna (nie gotowa na tym etapie)

                        TrackBar2.Value = 0
                        TrackBar1.Value = 0
                        tworz_wykres(0, 0) ' funkcja ładująca dane do wykresu (nie gotowa na tym etapie)
                        '   Label4.Text = maximum
                    Else
                        Odblokuj()
                        filename = .FileName
                        FilePath.Text = filename
                        alfa2.Text = wartoscAlfa.ToString

                        TworzTabele(filename)
                        Metoda_Browna(wartoscAlfa)

                        tworz_wykres(0, 0)
                        kontroler = False
                        TrackBar1.Enabled = True
                        TrackBar2.Enabled = True
                        Button6.Enabled = True
                        Button7.Enabled = True
                        Button8.Enabled = True
                        Button9.Enabled = True

                    End If
                End If
            End With
        Catch ex As Exception
        End Try
    End Sub



    Private Sub Metoda_Browna(ByVal alfa As Double)
        Dim dane1 As Double = 0
        Dim dane2 As Double = 0
        Dim dane3 As Double = 0
        Dim dane4 As Double = 0
        Dim dane5 As Double = 0
        Try
            dgv_dane.ColumnCount = 9
            dgv_dane.Columns(0).Name = "t"
            dgv_dane.Columns(1).Name = "yt"
            dgv_dane.Columns(2).Name = "ŷt"
            dgv_dane.Columns(3).Name = "Δŷt"
            dgv_dane.Columns(4).Name = "yt*"
            dgv_dane.Columns(5).Name = "yt-y*t"
            dgv_dane.Columns(6).Name = "(yt-y*t)^2"
            dgv_dane.Columns(7).Name = "|(yt-y*t)/yt|"
            dgv_dane.Columns(8).Name = "yt^2"

            '' Dodaje t
            For i As Integer = 0 To dane.Count - 1
                dgv_dane.Rows.Add()    'wypełnia datagridview wierszami
                dgv_dane.Rows(i).Cells(0).Value = i + 1   ' =dodaje numeracje
            Next

            '' Dodaje yt
            For i As Integer = 0 To dane.Count - 1
                dgv_dane.Rows(i).Cells(1).Value = dane(i)
            Next

            '' dodaje ŷt (wartość wygładzona) ŷt=L*(ŷt-1)+(1-L)*(yt-1)

            dgv_dane.Rows(1).Cells(2).Value = dane(0)



            For i As Integer = 2 To dane.Count - 1
                dgv_dane.Rows(i).Cells(2).Value = dgv_dane.Rows(i - 1).Cells(2).Value * alfa + (1 - alfa) * dane(i - 1)

            Next
            '' dodaje Δŷt przyrost oceny wartości trendu (różnica ostatnich wartości wygładzonych)
            For i As Integer = 1 To dane.Count - 1
                dgv_dane.Rows(i).Cells(3).Value = dgv_dane.Rows(i).Cells(2).Value - dgv_dane.Rows(i - 1).Cells(2).Value
            Next
            '' dodaje yt* = L*(yt-1)+(1-L)*(y*t-1)
            For i As Integer = 1 To dane.Count
                If i = 1 Then
                    If RadioButton4.Checked = True Then
                        dgv_dane.Rows(i).Cells(4).Value = dane(i - 1)
                        dgv_dane.Rows(i).Cells(4).Style.BackColor = Color.LightGray
                    ElseIf RadioButton5.Checked = True Then
                        dgv_dane.Rows(1).Cells(4).Value = (dane(0) + dane(1) + dane(2)) / 3

                    ElseIf RadioButton6.Checked = True Then
                        dgv_dane.Rows(1).Cells(4).Value = (dane(0) + dane(1) + dane(2) + dane(3) + dane(4)) / 5
                    End If
                ElseIf i = dane.Count - 1 Then
                    'dodaje ekstra wiersz
                    dgv_dane.Rows.Add()
                    dgv_dane.Rows(i).Cells(4).Value = alfa * dane(i - 1) + (1 - alfa) * dgv_dane.Rows(i - 1).Cells(4).Value
                    dgv_dane.Rows(i + 1).Cells(0).Value = i + 2
                    dgv_dane.Rows(i).Cells(4).Style.BackColor = Color.LightGray
                Else
                    dgv_dane.Rows(i).Cells(4).Value = alfa * dane(i - 1) + (1 - alfa) * dgv_dane.Rows(i - 1).Cells(4).Value
                    dgv_dane.Rows(i).Cells(4).Style.BackColor = Color.LightGray
                End If
            Next
            '' dodaje yt-y*t
            For i As Integer = 1 To dane.Count - 1
                dgv_dane.Rows(i).Cells(5).Value = dane(i) - dgv_dane.Rows(i).Cells(4).Value
            Next
            '' Dodaje (yt-y*t)^2
            For i As Integer = 1 To dane.Count - 1
                dgv_dane.Rows(i).Cells(6).Value = dgv_dane.Rows(i).Cells(5).Value ^ 2
            Next
            '' Dodaje |(yt-y*t)/yt|
            For i As Integer = 1 To dane.Count - 1
                dgv_dane.Rows(i).Cells(7).Value = Math.Abs(dgv_dane.Rows(i).Cells(5).Value / dane(i))
            Next

            '' Dodaje vt^2
            For i As Integer = 1 To dane.Count - 1
                dgv_dane.Rows(i).Cells(8).Value = dane(i) ^ 2
            Next

            ''Przygotowanie zmiennych do Obliczeń
            '' Suma (yt-y*t)
            For i As Integer = 1 To dane.Count - 1
                dane1 += dgv_dane.Rows(i).Cells(5).Value
            Next
            '' Suma (yt-y*t)^2
            For i As Integer = 1 To dane.Count - 1
                dane2 += dgv_dane.Rows(i).Cells(6).Value
            Next
            '' suma |(yt-y*t)/yt|
            For i As Integer = 1 To dane.Count - 1
                dane3 += dgv_dane.Rows(i).Cells(7).Value
            Next
            '' Suma ((yt-y*t)/yt)^2
            For i As Integer = 1 To dane.Count - 1
                dane4 += dgv_dane.Rows(i).Cells(7).Value ^ 2
            Next
            '' Suma yt^2
            For i As Integer = 1 To dane.Count - 1
                dane5 += dgv_dane.Rows(i).Cells(8).Value
            Next

            ''Wyświetlanie obliczeń
            ListView1.Columns(0).Width = 200
            ListView1.Columns(1).Width = 330

            ListView1.Items.Clear()

            Dim newitem2 As New ListViewItem("ME (Średni błąd)")
            newitem2.SubItems.Add((1 / (dane.Count - 1)) * dane1)

            ListView1.Items.Add(newitem2)
            Dim newitem3 As New ListViewItem("MSE (Błąd średniokwadratowy)")
            newitem3.SubItems.Add(((dane2) / (dane.Count - 1)))
            ListView1.Items.Add(newitem3)
            Dim mse As Double = (dane2) / (dane.Count - 1)
            Dim newitem4 As New ListViewItem("RMSE (Pierwiastem MSE)")
            newitem4.SubItems.Add(Math.Sqrt(mse))
            ListView1.Items.Add(newitem4)
            Dim newitem As New ListViewItem("RMSPE (procentowy RMSE)")
            newitem.SubItems.Add(Math.Round(Math.Sqrt(((1 / (dane.Count - 1)) * (dane4))) * 100, 4).ToString + " %")
            ListView1.Items.Add(newitem)


            Dim newitem5 As New ListViewItem("MAPE")
            newitem5.SubItems.Add(((1 / (dane.Count - 1)) * (dane3)) * 100)
            ListView1.Items.Add(newitem5)

            Dim newitem10 As New ListViewItem("Wsp Theila")
            newitem10.SubItems.Add(dane1 / dane5)
            ListView1.Items.Add(newitem10)

            Dim newitem7 As New ListViewItem("Prognoza")
            newitem7.SubItems.Add(dgv_dane.Rows(dane.Count).Cells(4).Value)
            ListView1.Items.Add(newitem7)

            Dim newitem6 As New ListViewItem("Ilość elementów")
            newitem6.SubItems.Add(dane.Count)
            ListView1.Items.Add(newitem6)



            Dim newitem8 As New ListViewItem("suma (yt-y*t)^2")
            newitem8.SubItems.Add(dane2)
            ListView1.Items.Add(newitem8)

            Dim newitem9 As New ListViewItem("suma yt^2")
            newitem9.SubItems.Add(dane5)
            ListView1.Items.Add(newitem9)




        Catch ex As Exception
            MsgBox("Error building datatable: " & ex.Message)
        End Try
        prognozy.Add(dane(0))
        For i As Integer = 1 To dgv_dane.Rows.Count - 1
            prognozy.Add(dgv_dane.Rows(i).Cells(4).Value)
        Next
    End Sub

    Private Sub Odswiez_Click(sender As Object, e As EventArgs) Handles Odswiez.Click
        wartoscAlfa = alfa2.Text
        dgv_dane.Rows.Clear()
        Metoda_Browna(wartoscAlfa)
        tworz_wykres(TrackBar1.Value, TrackBar2.Value)
    End Sub

    Private Sub tworz_wykres(ByVal wartosc As Integer, ByVal wartosc2 As Integer)

        Wykres2.ChartAreas(0).AxisY.LabelStyle.Format = "N2"
        Wykres2.Series.Clear()
        ' Określamy minimum i maximum osi y aby nasze dane calościowo mieściły się na wykresie
        Dim minimum As New Double
        Dim maximum As New Double
        'wstępne ustawienie minimum i maximum
        minimum = dane(wartosc)
        maximum = dane(wartosc)
        'pętle szukające minimalnych/maxymalnych wartości
        For i As Integer = wartosc + 1 To dane.Count - 1 - wartosc2
            If dane(i) < minimum Then
                minimum = dane(i)
            End If
        Next
        For i As Integer = wartosc + 1 To dane.Count - 1 - wartosc2
            If dane(i) > maximum Then
                maximum = dane(i)
            End If
        Next
        'ustawienie wartości
        Wykres2.Series.Add(0)
        Wykres2.Series.Add(1)

        If (dane.Count - 3) - wartosc - wartosc2 <= 20 Then
            Wykres2.Series(0).IsValueShownAsLabel = True
            Wykres2.Series(1).IsValueShownAsLabel = True
            Wykres2.Series(0).LabelFormat = "N4"
            Wykres2.Series(1).LabelFormat = "N4"
            Wykres2.Series(0).MarkerStyle = MarkerStyle.Square
            Wykres2.Series(1).MarkerStyle = MarkerStyle.Square
            Wykres2.Series(0).MarkerSize = 5
            Wykres2.Series(1).MarkerSize = 5
        Else
            Wykres2.Series(0).IsValueShownAsLabel = False
            Wykres2.Series(1).IsValueShownAsLabel = False
            Wykres2.Series(0).MarkerStyle = MarkerStyle.None
            Wykres2.Series(1).MarkerStyle = MarkerStyle.None
        End If
        Wykres2.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Line
        Wykres2.Series(0).Points.Clear()
        Wykres2.Series(0).Name = "yt"
        Wykres2.Series(0).BorderWidth = 2
        If TrackBar2.Value = 0 Then
            For Count As Integer = wartosc To dgv_dane.Rows.Count - 2 - wartosc2
                Wykres2.Series(0).Points.AddXY(dgv_dane.Item(0, Count).Value, dgv_dane.Item(1, Count).Value)
            Next
        Else
            For Count As Integer = wartosc To dgv_dane.Rows.Count - 1 - wartosc2
                Wykres2.Series(0).Points.AddXY(dgv_dane.Item(0, Count).Value, dgv_dane.Item(1, Count).Value)
            Next
        End If
        Wykres2.Series(1).ChartType = DataVisualization.Charting.SeriesChartType.Line
        Wykres2.Series(1).Points.Clear()
        Wykres2.Series(1).Color = Color.Red
        Wykres2.Series(1).Name = "y*t"
        Wykres2.Series(1).BorderWidth = 2
        For Count As Integer = wartosc To dgv_dane.Rows.Count - 1 - wartosc2
            Wykres2.Series(1).Points.AddXY(dgv_dane.Item(0, Count).Value, dgv_dane.Item(4, Count).Value)
            If Count > 0 Then
                If dgv_dane.Item(4, Count).Value < minimum Then
                    minimum = dgv_dane.Item(4, Count).Value
                End If
                If dgv_dane.Item(4, Count).Value > maximum Then
                    maximum = dgv_dane.Item(4, Count).Value
                End If
            End If

        Next
        Wykres2.ChartAreas(0).AxisY.Minimum = Val(minimum)
        Wykres2.ChartAreas(0).AxisY.Maximum = Val(maximum)

        Wykres2.Legends(0).Docking = Docking.Top


    End Sub



    Private Sub alfa_KeyDown(sender As Object, e As KeyEventArgs) Handles alfa2.KeyDown
        Select Case e.KeyCode
            Case Keys.Up
                wartoscAlfa += 0.01
                alfa2.Text = wartoscAlfa
                dgv_dane.Rows.Clear()
                Metoda_Browna(wartoscAlfa)
                tworz_wykres(TrackBar1.Value, TrackBar2.Value)
            Case Keys.Down
                wartoscAlfa -= 0.01
                alfa2.Text = wartoscAlfa
                dgv_dane.Rows.Clear()
                Metoda_Browna(wartoscAlfa)
                tworz_wykres(TrackBar1.Value, TrackBar2.Value)
        End Select
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://visualmonsters.cba.pl/index.php/statystyka/")
    End Sub

    Private Sub ZakończToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZakończToolStripMenuItem.Click
        End
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DataGridView1.Rows.Clear()
        DataGridView2.Rows.Clear()
        If DataGridView1.ColumnCount = 0 Then
            DataGridView1.ColumnCount = 2
            DataGridView1.Columns(0).Name = "t"
            DataGridView1.Columns(1).Name = "yt"
            DataGridView1.Columns(0).Width = 60
            DataGridView1.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If
        For i As Integer = 0 To dane.Count - 1
            DataGridView1.Rows.Add()    'wypełnia datagridview wierszami
            DataGridView1.Rows(i).Cells(0).Value = i + 1   ' =dodaje numeracje
        Next
        For i As Integer = 0 To dane.Count - 1
            DataGridView1.Rows(i).Cells(1).Value = dane(i)
        Next
        If DataGridView2.ColumnCount = 0 Then
            DataGridView2.ColumnCount = 2
            DataGridView2.Columns(0).Name = "α"
            DataGridView2.Columns(1).Name = "Wartość"
            DataGridView2.Columns(0).Width = 60
            DataGridView2.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        End If

        ''szukanie idealnych wartosci
        Dim prognozyWygasle As New List(Of String)
        Dim ME_bledy As New List(Of String)
        Dim alfa As Double = 0.01
        Dim koniec As Double = 1
        Dim najmniejszyBlad As Double
        Dim idealnaAlfa As Double
        Dim licznikWierszy As Integer = 0

        Do While alfa <= koniec + 0.01
            prognozyWygasle.Clear()
            ME_bledy.Clear()
            Dim blad As Double = 0

            For i As Integer = 0 To dane.Count - 1
                If i = 0 Then
                    If RadioButton4.Checked = True Then
                       prognozyWygasle.Add(dane(0))
                    ElseIf RadioButton5.Checked = True Then     
                        prognozyWygasle.Add((dane(0) + dane(1) + dane(2)) / 3)
                    ElseIf RadioButton6.Checked = True Then
                        prognozyWygasle.Add((dane(0) + dane(1) + dane(2) + dane(3) + dane(4)) / 5)
                    End If
                Else
                    prognozyWygasle.Add(alfa * dane(i) + (1 - alfa) * prognozyWygasle(i - 1))
                End If
            Next


            If RadioButton1.Checked = True Then
                For i As Integer = 0 To prognozyWygasle.Count - 2
                    ME_bledy.Add((dane(i + 1) - prognozyWygasle(i)) ^ 2)
                Next

                For Each elements In ME_bledy
                    blad += elements
                Next

                blad = blad / ME_bledy.Count ''średni błąd
                blad = Math.Sqrt(blad)
            ElseIf RadioButton2.Checked = True Then
                For i As Integer = 0 To prognozyWygasle.Count - 2
                    ME_bledy.Add((dane(i + 1) - prognozyWygasle(i)) ^ 2)
                Next

                For Each elements In ME_bledy
                    blad += elements
                Next

                blad = blad / ME_bledy.Count ''średni błąd
            ElseIf RadioButton3.Checked = True Then

                For i As Integer = 0 To prognozyWygasle.Count - 2
                    ME_bledy.Add((dane(i + 1) - prognozyWygasle(i)))
                Next

                For Each elements In ME_bledy
                    blad += elements
                Next
                blad = blad / ME_bledy.Count ''średni błąd
            End If

            DataGridView2.Rows.Add()

            DataGridView2.Rows(licznikWierszy).Cells(0).Value = Math.Round(alfa, 2)
            DataGridView2.Rows(licznikWierszy).Cells(1).Value = blad


            If alfa = 0.01 Then
                idealnaAlfa = alfa
                najmniejszyBlad = Math.Abs(blad)
            ElseIf Math.Abs(blad) < najmniejszyBlad Then
                idealnaAlfa = alfa
                najmniejszyBlad = Math.Abs(blad)
            End If

            alfa = alfa + 0.01
            licznikWierszy = licznikWierszy + 1
        Loop

        '''druga faza
        If idealnaAlfa >= 1 Or idealnaAlfa <= 0 Then
            MsgBox("Niestety ale dla tych danych nie istnieje idealna Alfa")
        Else
            Dim drugafazaPoczatek As Double
            Dim drugafazakoniec As Double
            For a As Integer = 2 To 6
                drugafazaPoczatek = Math.Round(idealnaAlfa - 0.5 * (10) ^ -a, a + 1)
                drugafazakoniec = Math.Round(idealnaAlfa + 0.5 * (10) ^ -a, a + 1)

                Do While drugafazaPoczatek <= drugafazakoniec + 1 * (10) ^ (-a - 1)
                    prognozyWygasle.Clear()
                    ME_bledy.Clear()
                    Dim blad As Double = 0
                    For i As Integer = 0 To dane.Count - 1
                        If i = 0 Then
                            If RadioButton4.Checked = True Then
                                prognozyWygasle.Add(dane(0))
                            ElseIf RadioButton5.Checked = True Then
                                prognozyWygasle.Add((dane(0) + dane(1) + dane(2)) / 3)
                            ElseIf RadioButton6.Checked = True Then
                                prognozyWygasle.Add((dane(0) + dane(1) + dane(2) + dane(3) + dane(4)) / 5)
                            End If
                        Else
                            prognozyWygasle.Add(drugafazaPoczatek * dane(i) + (1 - drugafazaPoczatek) * prognozyWygasle(i - 1))
                        End If
                    Next

                    If RadioButton1.Checked = True Then
                        For i As Integer = 0 To prognozyWygasle.Count - 2
                            ME_bledy.Add((dane(i + 1) - prognozyWygasle(i)) ^ 2)
                        Next

                        For Each elements In ME_bledy
                            blad += elements
                        Next

                        blad = blad / ME_bledy.Count ''średni błąd
                        blad = Math.Sqrt(blad)
                    ElseIf RadioButton2.Checked = True Then
                        For i As Integer = 0 To prognozyWygasle.Count - 2
                            ME_bledy.Add((dane(i + 1) - prognozyWygasle(i)) ^ 2)
                        Next

                        For Each elements In ME_bledy
                            blad += elements
                        Next

                        blad = blad / ME_bledy.Count ''średni błąd
                    ElseIf RadioButton3.Checked = True Then

                        For i As Integer = 0 To prognozyWygasle.Count - 2
                            ME_bledy.Add((dane(i + 1) - prognozyWygasle(i)))
                        Next

                        For Each elements In ME_bledy
                            blad += elements
                        Next
                        blad = blad / ME_bledy.Count ''średni błąd
                    End If


                    If drugafazaPoczatek = idealnaAlfa - 0.5 * (10) ^ -a Then
                        idealnaAlfa = drugafazaPoczatek
                        najmniejszyBlad = Math.Abs(blad)
                    ElseIf Math.Abs(blad) < najmniejszyBlad Then
                        idealnaAlfa = drugafazaPoczatek
                        najmniejszyBlad = Math.Abs(blad)
                    End If

                    drugafazaPoczatek += 1 * (10) ^ (-a - 1)
                Loop
                a += 1
            Next
        End If
        Label2.Text = idealnaAlfa.ToString
        Label3.Text = najmniejszyBlad.ToString
        tworz_wykres2()

        wartoscAlfa = idealnaAlfa
        dgv_dane.Rows.Clear()
        Metoda_Browna(idealnaAlfa)
        tworz_wykres(TrackBar1.Value, TrackBar2.Value)
        alfa2.Text = idealnaAlfa.ToString
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If (TrackBar1.Value + TrackBar2.Value) < dane.Count - 2 Then
            If Not TrackBar1.Value = TrackBar1.Maximum Then
                TrackBar1.Value += 1
            End If
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If (TrackBar1.Value + TrackBar2.Value) < dane.Count - 2 Then
            If Not TrackBar1.Value = 0 Then
                TrackBar1.Value -= 1
            End If
        End If
    End Sub

    Private Sub TrackBar1_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar1.ValueChanged
        If (TrackBar1.Value + TrackBar2.Value) < dane.Count - 2 Then
            tworz_wykres(TrackBar1.Value, TrackBar2.Value)
        End If
    End Sub

    Private Sub TrackBar2_ValueChanged(sender As Object, e As EventArgs) Handles TrackBar2.ValueChanged
        If (TrackBar1.Value + TrackBar2.Value) < dane.Count - 2 Then
            tworz_wykres(TrackBar1.Value, TrackBar2.Value)
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If (TrackBar1.Value + TrackBar2.Value) < dane.Count - 2 Then
            If Not TrackBar2.Value = 0 Then
                TrackBar2.Value -= 1
            End If
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If (TrackBar1.Value + TrackBar2.Value) < dane.Count - 2 Then
            If Not TrackBar2.Value = TrackBar2.Maximum Then
                TrackBar2.Value += 1
            End If
        End If
    End Sub

    Private Sub tworz_wykres2()
        Chart1.Series(0).ChartType = DataVisualization.Charting.SeriesChartType.Line
        Chart1.Series(0).Points.Clear()
        Chart1.Series(0).Name = "yt"
        Chart1.Series(0).BorderWidth = 2

        For Count As Integer = 0 To DataGridView2.Rows.Count - 1
            Chart1.Series(0).Points.AddXY(DataGridView2.Item(0, Count).Value, DataGridView2.Item(1, Count).Value)
        Next

        Chart1.Legends(0).Docking = Docking.Top

    End Sub


    Public Sub TworzTabele(ByVal sciezkaDoPliku As String)
        Dim i As Integer
        Dim wartosc As String() 'przechowuje dane z pliku
        Dim f As IO.File = Nothing
        Dim rodzajkodu As New IO.StreamReader(sciezkaDoPliku, System.Text.Encoding.UTF8)
        Try
            Dim k As String
            k = InputBox("Wprowadź znak separatora. (pozostawienie pustego pola oznacza użycie vbNewline)", "")
            If k = "" Then
                wartosc = rodzajkodu.ReadLine().Split(ControlChars.Tab)
            Else
                wartosc = rodzajkodu.ReadLine().Split(k)
            End If
            For i = 0 To wartosc.Length() - 1
                dane.Add(wartosc(i))
            Next
            While rodzajkodu.Peek() <> -1
                wartosc = rodzajkodu.ReadLine().Split()
                For i = 0 To wartosc.Length() - 1
                    dane.Add(wartosc(i)) 'Ładuje dane do tablicy dane
                Next
            End While
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            rodzajkodu.Close()
        End Try
        ' minimum = dane(0)
        '  maximum = dane(0)
        TrackBar1.Maximum = dane.Count - 2
        TrackBar2.Maximum = dane.Count - 2

    End Sub

   
    Private Sub dgv_dane_SelectionChanged(sender As Object, e As EventArgs) Handles dgv_dane.SelectionChanged

        Try
            Dim Cell As DataGridViewCell
            Dim Total As Double

            For Each Cell In dgv_dane.SelectedCells
                If CastAsNumber(Cell.Value) = True Then
                    Total = Total + Cell.Value
                End If
            Next
            TextBox5.Text = Total
        Catch ex As Exception
            Debug.Print(ex.ToString)
        End Try
    End Sub

    Public Function CastAsNumber(ByVal CellValue As String) As Boolean
        Try
            Dim value As Double
            value = CDbl(CellValue)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Private Sub DodajDaneDoWyliczeniaŚrednichToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DodajDaneDoWyliczeniaŚrednichToolStripMenuItem.Click
        Form2.Show()
    End Sub

    Public Sub Sredniegieldowe(ByVal listasrednich As List(Of Double))
        If kontroler = False Then
            dane.Clear() 'czyści tablice
            dgv_dane.Rows.Clear() 'czyści datagridview

            alfa2.Text = wartoscAlfa.ToString ' wizualizuje wzsłczynnik alfa
            For i = 0 To listasrednich.Count - 1
                dane.Add(listasrednich(i)) 'Ładuje dane do tablicy dane
            Next
            ' funkcja przetwarzająca nasze dane z 
            'pliku txt i ładujące je do tablicy (nie gotowa na tym etapie)
            Metoda_Browna(wartoscAlfa) ' funkcja tworząca metode Browna (nie gotowa na tym etapie)
            ' funkcja ładująca dane do wykresu (nie gotowa na tym etapie)
            '  minimum = dane(0)
            '    maximum = dane(0)
            TrackBar1.Maximum = dane.Count - 2
            TrackBar2.Maximum = dane.Count - 2
            tworz_wykres(0, 0)
            Odblokuj()
        Else

            alfa2.Text = wartoscAlfa.ToString
            For i = 0 To listasrednich.Count - 1
                dane.Add(listasrednich(i)) 'Ładuje dane do tablicy dane
            Next

            Metoda_Browna(wartoscAlfa)

            kontroler = False
            TrackBar1.Enabled = True
            TrackBar2.Enabled = True
            Button6.Enabled = True
            Button7.Enabled = True
            Button8.Enabled = True
            Button9.Enabled = True

            TrackBar1.Maximum = dane.Count - 2
            TrackBar2.Maximum = dane.Count - 2
            tworz_wykres(0, 0)
            Odblokuj()

        End If
    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        wartoscAlfa = alfa2.Text
        dgv_dane.Rows.Clear()
        Metoda_Browna(wartoscAlfa)
        tworz_wykres(TrackBar1.Value, TrackBar2.Value)
    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton6.CheckedChanged
        wartoscAlfa = alfa2.Text
        dgv_dane.Rows.Clear()
        Metoda_Browna(wartoscAlfa)
        tworz_wykres(TrackBar1.Value, TrackBar2.Value)
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If kontroler = False Then
            wartoscAlfa = alfa2.Text
            dgv_dane.Rows.Clear()
            Metoda_Browna(wartoscAlfa)
            tworz_wykres(TrackBar1.Value, TrackBar2.Value)
        End If
    End Sub

    Private Sub ZapiszDaneDoExcelaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZapiszDaneDoExcelaToolStripMenuItem.Click
        Dim sfd As New SaveFileDialog
        With sfd
            .FileName = ""
            .Filter = "Text File|*.csv"
        End With

        If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then
            Call data_to_txt(dgv_dane, sfd.FileName, ListView1)
        End If
    End Sub

    Private Sub data_to_txt(ByVal dt As DataGridView, ByVal filename As String, ByVal lv As ListView)
        Dim sw As New IO.StreamWriter(filename, False)
        If dt.Columns.Count < 0 OrElse dt.Rows.Count < 0 Then
            Exit Sub
        End If
        For Each col As DataGridViewColumn In dt.Columns
            sw.Write(col.HeaderText & ControlChars.Tab) '& delimiter)
        Next
        sw.WriteLine()
        'Loop through all the cells in the datatable
        For row As Integer = 0 To dt.Rows.Count - 1
            For col As Integer = 0 To dt.Columns.Count - 1
                sw.Write(dt.Rows(row).Cells(col).Value & ControlChars.Tab) ' ".")
            Next
            'At the final column, start a new line
            sw.Write(Environment.NewLine)
        Next

        Dim line As String
        Dim values As New List(Of String)
        For Each LVI As ListViewItem In lv.Items
            values.Clear()
            For i As Integer = 0 To LVI.SubItems.Count - 1
                values.Add(LVI.SubItems(i).Text)
            Next
            line = String.Join(ControlChars.Tab, values.ToArray)
            sw.WriteLine(line)
        Next

        'Close the streamwriter
        sw.Close()
        MsgBox("Dane zosyały zapisane")
    End Sub

    Private Sub AktualizacjeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AktualizacjeToolStripMenuItem.Click
        Process.Start("http://visualmonsters.cba.pl/index.php/pomoc-i-obsluga-programu-metoda-browna")
    End Sub

    Private Sub EksportujBłędyDoCSVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EksportujBłędyDoCSVToolStripMenuItem.Click

        Dim sfd As New SaveFileDialog
        With sfd
            .FileName = ""
            .Filter = "Text File|*.csv"
        End With

        If sfd.ShowDialog = Windows.Forms.DialogResult.OK Then

            Call data_to_txt2(dgv_dane, sfd.FileName)

        End If
    End Sub

    Private Sub data_to_txt2(ByVal dt As DataGridView, ByVal filename As String)
        Dim sw As New IO.StreamWriter(filename, False)
        If dt.Columns.Count < 0 OrElse dt.Rows.Count < 0 Then
            Exit Sub
        End If

        sw.Write(dt.Columns(5).HeaderText & ControlChars.Tab) '& delimiter)
        sw.WriteLine()
        'Loop through all the cells in the datatable
        For row As Integer = 1 To dt.Rows.Count - 2
            sw.Write(dt.Rows(row).Cells(5).Value & ControlChars.Tab) ' ".")
            sw.Write(Environment.NewLine)
        Next
        'At the final column, start a new line

        'Close the streamwriter
        sw.Close()
        MsgBox("Dane zosyały zapisane")
    End Sub

    Private Sub Odblokuj()
        RadioButton4.Enabled = True
        RadioButton5.Enabled = True
        RadioButton6.Enabled = True
        Odswiez.Enabled = True
        alfa2.Enabled = True
        Button1.Enabled = True
    End Sub


    Private Sub dgv_dane_KeyUp(sender As Object, e As KeyEventArgs) Handles dgv_dane.KeyUp
        If Control.ModifierKeys = Keys.Control Then
            Select Case e.KeyCode
                Case Keys.X
                    '   DGVCutCopyPaste.CutDGVCells(DataGridView1)
                Case Keys.C
                    '  DGVCutCopyPaste.CopyDGVCells(DataGridView1)
                Case Keys.V
                    If Clipboard.ContainsText Then

                        Dim str As String = Clipboard.GetText 'e.Data.GetData("Text").ToString()
                        Dim k As String
                        k = InputBox("Wprowadź znak separatora. (pozostawienie pustego pola oznacza użycie vbNewline)", "")
                        Dim parts As String()
                        If k = "" Then
                            parts = str.Split(New String() {Environment.NewLine}, StringSplitOptions.None)
                        Else
                            parts = str.Split(New String() {k}, StringSplitOptions.None)
                        End If
                        If kontroler = False Then
                            dane.Clear() 'czyści tablice
                            prognozy.Clear()
                            dgv_dane.Rows.Clear() 'czyści datagridview
                            alfa2.Text = wartoscAlfa.ToString ' wizualizuje wzsłczynnik alfa
                            For i As Integer = 0 To parts.Length - 2
                                dane.Add(parts(i))
                            Next
                            'pliku txt i ładujące je do tablicy (nie gotowa na tym etapie)
                            Metoda_Browna(wartoscAlfa) ' funkcja tworząca metode Browna (nie gotowa na tym etapie)
                            TrackBar2.Value = 0
                            TrackBar1.Value = 0
                            tworz_wykres(0, 0) ' funkcja ładująca dane do wykresu (nie gotowa na tym etapie)
                            TrackBar1.Maximum = dane.Count - 2
                            TrackBar2.Maximum = dane.Count - 2
                            '   Label4.Text = maximum
                        Else
                            Odblokuj()
                            alfa2.Text = wartoscAlfa.ToString
                            For i As Integer = 0 To parts.Length - 2
                                dane.Add(parts(i))
                            Next
                            TrackBar1.Maximum = dane.Count - 2
                            TrackBar2.Maximum = dane.Count - 2
                            Metoda_Browna(wartoscAlfa)
                            tworz_wykres(0, 0)
                            kontroler = False
                            TrackBar1.Enabled = True
                            TrackBar2.Enabled = True
                            Button6.Enabled = True
                            Button7.Enabled = True
                            Button8.Enabled = True
                            Button9.Enabled = True
                        End If
                    End If
            End Select
        End If
    End Sub

    Private Sub menuChoice(ByVal sender As Object, ByVal e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        '-- etc
        If selection = 1 Then
            If Clipboard.ContainsText Then

                Dim str As String = Clipboard.GetText 'e.Data.GetData("Text").ToString()
                Dim k As String
                k = InputBox("Wprowadź znak separatora. (pozostawienie pustego pola oznacza użycie vbNewline)", "")
                Dim parts As String()
                If k = "" Then
                    parts = str.Split(New String() {Environment.NewLine}, StringSplitOptions.None)
                Else
                    parts = str.Split(New String() {k}, StringSplitOptions.None)
                End If
                If kontroler = False Then
                    dane.Clear() 'czyści tablice
                    prognozy.Clear()
                    dgv_dane.Rows.Clear() 'czyści datagridview
                    alfa2.Text = wartoscAlfa.ToString ' wizualizuje wzsłczynnik alfa
                    For i As Integer = 0 To parts.Length - 2
                        dane.Add(parts(i))
                    Next
                    'pliku txt i ładujące je do tablicy (nie gotowa na tym etapie)
                    Metoda_Browna(wartoscAlfa) ' funkcja tworząca metode Browna (nie gotowa na tym etapie)
                    TrackBar2.Value = 0
                    TrackBar1.Value = 0
                    tworz_wykres(0, 0) ' funkcja ładująca dane do wykresu (nie gotowa na tym etapie)
                    TrackBar1.Maximum = dane.Count - 2
                    TrackBar2.Maximum = dane.Count - 2
                    '   Label4.Text = maximum
                Else
                    Odblokuj()
                    alfa2.Text = wartoscAlfa.ToString
                    For i As Integer = 0 To parts.Length - 2
                        dane.Add(parts(i))
                    Next
                    TrackBar1.Maximum = dane.Count - 2
                    TrackBar2.Maximum = dane.Count - 2
                    Metoda_Browna(wartoscAlfa)
                    tworz_wykres(0, 0)
                    kontroler = False
                    TrackBar1.Enabled = True
                    TrackBar2.Enabled = True
                    Button6.Enabled = True
                    Button7.Enabled = True
                    Button8.Enabled = True
                    Button9.Enabled = True
                End If
            End If
        ElseIf selection = 2 Then

            Try
                Clipboard.SetDataObject(Me.DataGridView1.GetClipboardContent())
            Catch ex As System.Runtime.InteropServices.ExternalException
                MsgBox("The Clipboard could not be accessed. Please try again.")
            End Try

        End If

    End Sub
    Private Sub DataGridView1_MouseUp(sender As Object, e As MouseEventArgs) Handles dgv_dane.MouseUp

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
        cms.Show(dgv_dane, e.Location)
    End Sub

    Private Sub dgv_dane_DragDrop(sender As Object, e As DragEventArgs) Handles dgv_dane.DragDrop

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then

            Dim MyFiles() As String
                ' Assign the files to an array.
                MyFiles = e.Data.GetData(DataFormats.FileDrop)
                ' Display the file Name
                'TextBoxDrop.Text = MyFiles(0)
                ' Display the file contents
                Dim str As String = My.Computer.FileSystem.ReadAllText(MyFiles(0))
                Dim parts As String() = str.Split(New String() {Environment.NewLine}, StringSplitOptions.None)
            If kontroler = False Then
                dane.Clear() 'czyści tablice
                prognozy.Clear()

                dgv_dane.Rows.Clear() 'czyści datagridview

                alfa2.Text = wartoscAlfa.ToString ' wizualizuje wzsłczynnik alfa

                For i As Integer = 0 To parts.Length - 2
                    dane.Add(parts(i))

                Next

                'pliku txt i ładujące je do tablicy (nie gotowa na tym etapie)
                Metoda_Browna(wartoscAlfa) ' funkcja tworząca metode Browna (nie gotowa na tym etapie)

                TrackBar2.Value = 0
                TrackBar1.Value = 0
                tworz_wykres(0, 0) ' funkcja ładująca dane do wykresu (nie gotowa na tym etapie)
                TrackBar1.Maximum = dane.Count - 2
                TrackBar2.Maximum = dane.Count - 2
                '   Label4.Text = maximum
            Else
                Odblokuj()


                alfa2.Text = wartoscAlfa.ToString

                For i As Integer = 0 To parts.Length - 2
                    dane.Add(parts(i))

                Next
                TrackBar1.Maximum = dane.Count - 2
                TrackBar2.Maximum = dane.Count - 2
                Metoda_Browna(wartoscAlfa)

                tworz_wykres(0, 0)
                kontroler = False
                TrackBar1.Enabled = True
                TrackBar2.Enabled = True
                Button6.Enabled = True
                Button7.Enabled = True
                Button8.Enabled = True
                Button9.Enabled = True

            End If
        Else
            Dim str As String = e.Data.GetData("Text").ToString()
            Dim parts As String() = str.Split(New String() {Environment.NewLine}, StringSplitOptions.None)

            If kontroler = False Then

                dane.Clear() 'czyści tablice
                prognozy.Clear()

                dgv_dane.Rows.Clear() 'czyści datagridview

                alfa2.Text = wartoscAlfa.ToString ' wizualizuje wzsłczynnik alfa

                For i As Integer = 0 To parts.Length - 2
                    dane.Add(parts(i))

                Next

                'pliku txt i ładujące je do tablicy (nie gotowa na tym etapie)
                Metoda_Browna(wartoscAlfa) ' funkcja tworząca metode Browna (nie gotowa na tym etapie)

                TrackBar2.Value = 0
                TrackBar1.Value = 0
                tworz_wykres(0, 0) ' funkcja ładująca dane do wykresu (nie gotowa na tym etapie)
                TrackBar1.Maximum = dane.Count - 2
                TrackBar2.Maximum = dane.Count - 2
                '   Label4.Text = maximum
            Else
                Odblokuj()


                alfa2.Text = wartoscAlfa.ToString

                For i As Integer = 0 To parts.Length - 2
                    dane.Add(parts(i))

                Next
                TrackBar1.Maximum = dane.Count - 2
                TrackBar2.Maximum = dane.Count - 2
                Metoda_Browna(wartoscAlfa)

                tworz_wykres(0, 0)
                kontroler = False
                TrackBar1.Enabled = True
                TrackBar2.Enabled = True
                Button6.Enabled = True
                Button7.Enabled = True
                Button8.Enabled = True
                Button9.Enabled = True

            End If
        End If
    End Sub

    Private Sub dgv_dane_DragEnter(sender As Object, e As DragEventArgs) Handles dgv_dane.DragEnter
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
End Class
