<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModelBrowna
    Inherits System.Windows.Forms.Form

    'Formularz zastępuje metodę dispose, aby wyczyścić listę składników.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wymagane przez Projektanta formularzy systemu Windows
    Private components As System.ComponentModel.IContainer

    'UWAGA: Następująca procedura jest wymagana przez Projektanta formularzy systemu Windows
    'Można to modyfikować, używając Projektanta formularzy systemu Windows.  
    'Nie należy modyfikować za pomocą edytora kodu.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series3 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModelBrowna))
        Me.dgv_dane = New System.Windows.Forms.DataGridView()
        Me.Odswiez = New System.Windows.Forms.Button()
        Me.alfa2 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DaneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DodajDaneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DodajDaneDoWyliczeniaŚrednichToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZapiszDaneDoExcelaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EksportujBłędyDoCSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AktualizacjeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZakończToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilePath = New System.Windows.Forms.TextBox()
        Me.Wykres2 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.WczytajDane = New System.Windows.Forms.OpenFileDialog()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Współczynnik = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Wartość = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.TrackBar2 = New System.Windows.Forms.TrackBar()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.SaveFileDialog2 = New System.Windows.Forms.SaveFileDialog()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.dgv_dane, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.Wykres2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_dane
        '
        Me.dgv_dane.AllowDrop = True
        Me.dgv_dane.AllowUserToAddRows = False
        Me.dgv_dane.AllowUserToDeleteRows = False
        Me.dgv_dane.AllowUserToOrderColumns = True
        Me.dgv_dane.AllowUserToResizeColumns = False
        Me.dgv_dane.AllowUserToResizeRows = False
        Me.dgv_dane.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgv_dane.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgv_dane.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_dane.Location = New System.Drawing.Point(6, 6)
        Me.dgv_dane.Name = "dgv_dane"
        Me.dgv_dane.Size = New System.Drawing.Size(566, 347)
        Me.dgv_dane.TabIndex = 0
        '
        'Odswiez
        '
        Me.Odswiez.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Odswiez.Enabled = False
        Me.Odswiez.Location = New System.Drawing.Point(156, 364)
        Me.Odswiez.Name = "Odswiez"
        Me.Odswiez.Size = New System.Drawing.Size(95, 23)
        Me.Odswiez.TabIndex = 47
        Me.Odswiez.Text = "Odśwież"
        Me.Odswiez.UseVisualStyleBackColor = True
        '
        'alfa2
        '
        Me.alfa2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.alfa2.Enabled = False
        Me.alfa2.Location = New System.Drawing.Point(56, 365)
        Me.alfa2.Name = "alfa2"
        Me.alfa2.Size = New System.Drawing.Size(94, 20)
        Me.alfa2.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 364)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 24)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "α ="
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DaneToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1135, 24)
        Me.MenuStrip1.TabIndex = 57
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DaneToolStripMenuItem
        '
        Me.DaneToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DodajDaneToolStripMenuItem, Me.DodajDaneDoWyliczeniaŚrednichToolStripMenuItem, Me.ZapiszDaneDoExcelaToolStripMenuItem, Me.EksportujBłędyDoCSVToolStripMenuItem, Me.AktualizacjeToolStripMenuItem, Me.ZakończToolStripMenuItem})
        Me.DaneToolStripMenuItem.Name = "DaneToolStripMenuItem"
        Me.DaneToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.DaneToolStripMenuItem.Text = "Dane"
        '
        'DodajDaneToolStripMenuItem
        '
        Me.DodajDaneToolStripMenuItem.Name = "DodajDaneToolStripMenuItem"
        Me.DodajDaneToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
        Me.DodajDaneToolStripMenuItem.Text = "Dodaj dane"
        '
        'DodajDaneDoWyliczeniaŚrednichToolStripMenuItem
        '
        Me.DodajDaneDoWyliczeniaŚrednichToolStripMenuItem.Name = "DodajDaneDoWyliczeniaŚrednichToolStripMenuItem"
        Me.DodajDaneDoWyliczeniaŚrednichToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
        Me.DodajDaneDoWyliczeniaŚrednichToolStripMenuItem.Text = "Uśrednianie, różnicowanie danych"
        '
        'ZapiszDaneDoExcelaToolStripMenuItem
        '
        Me.ZapiszDaneDoExcelaToolStripMenuItem.Name = "ZapiszDaneDoExcelaToolStripMenuItem"
        Me.ZapiszDaneDoExcelaToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
        Me.ZapiszDaneDoExcelaToolStripMenuItem.Text = "Eksportuj dane do CSV"
        '
        'EksportujBłędyDoCSVToolStripMenuItem
        '
        Me.EksportujBłędyDoCSVToolStripMenuItem.Name = "EksportujBłędyDoCSVToolStripMenuItem"
        Me.EksportujBłędyDoCSVToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
        Me.EksportujBłędyDoCSVToolStripMenuItem.Text = "Eksportuj błędy do CSV"
        '
        'AktualizacjeToolStripMenuItem
        '
        Me.AktualizacjeToolStripMenuItem.Name = "AktualizacjeToolStripMenuItem"
        Me.AktualizacjeToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
        Me.AktualizacjeToolStripMenuItem.Text = "Pomoc i aktualizacje"
        '
        'ZakończToolStripMenuItem
        '
        Me.ZakończToolStripMenuItem.Name = "ZakończToolStripMenuItem"
        Me.ZakończToolStripMenuItem.Size = New System.Drawing.Size(254, 22)
        Me.ZakończToolStripMenuItem.Text = "Zakończ"
        '
        'FilePath
        '
        Me.FilePath.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FilePath.Enabled = False
        Me.FilePath.Location = New System.Drawing.Point(72, 3)
        Me.FilePath.Name = "FilePath"
        Me.FilePath.ReadOnly = True
        Me.FilePath.Size = New System.Drawing.Size(545, 20)
        Me.FilePath.TabIndex = 58
        '
        'Wykres2
        '
        Me.Wykres2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray
        ChartArea1.Name = "ChartArea1"
        Me.Wykres2.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Wykres2.Legends.Add(Legend1)
        Me.Wykres2.Location = New System.Drawing.Point(578, 54)
        Me.Wykres2.Name = "Wykres2"
        Series1.ChartArea = "ChartArea1"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Series2.ChartArea = "ChartArea1"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series2.Legend = "Legend1"
        Series2.Name = "Series2"
        Me.Wykres2.Series.Add(Series1)
        Me.Wykres2.Series.Add(Series2)
        Me.Wykres2.Size = New System.Drawing.Size(516, 413)
        Me.Wykres2.TabIndex = 60
        Me.Wykres2.Text = "Chart2"
        '
        'WczytajDane
        '
        Me.WczytajDane.FileName = "OpenFileDialog1"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(952, 6)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(171, 13)
        Me.LinkLabel1.TabIndex = 62
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "https://www.visualmonsters.cba.pl"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 29)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1111, 605)
        Me.TabControl1.TabIndex = 63
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.RadioButton6)
        Me.TabPage1.Controls.Add(Me.RadioButton5)
        Me.TabPage1.Controls.Add(Me.RadioButton4)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.TextBox5)
        Me.TabPage1.Controls.Add(Me.ListView1)
        Me.TabPage1.Controls.Add(Me.Button6)
        Me.TabPage1.Controls.Add(Me.Button7)
        Me.TabPage1.Controls.Add(Me.TrackBar2)
        Me.TabPage1.Controls.Add(Me.Button8)
        Me.TabPage1.Controls.Add(Me.Button9)
        Me.TabPage1.Controls.Add(Me.Odswiez)
        Me.TabPage1.Controls.Add(Me.TrackBar1)
        Me.TabPage1.Controls.Add(Me.alfa2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.dgv_dane)
        Me.TabPage1.Controls.Add(Me.Wykres2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1103, 579)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Podgląd danych, wykresu"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(579, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 13)
        Me.Label4.TabIndex = 77
        Me.Label4.Text = "Wybierz wartość dla y*1"
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.Enabled = False
        Me.RadioButton6.Location = New System.Drawing.Point(923, 31)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(226, 17)
        Me.RadioButton6.TabIndex = 76
        Me.RadioButton6.Text = "Y*1 = średnia z pięciu pierwszych wyrazów"
        Me.RadioButton6.UseVisualStyleBackColor = True
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.Enabled = False
        Me.RadioButton5.Location = New System.Drawing.Point(676, 31)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(228, 17)
        Me.RadioButton5.TabIndex = 75
        Me.RadioButton5.Text = "y*1 =  średnia z trzech pierwszych wyrazów"
        Me.RadioButton5.UseVisualStyleBackColor = True
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.Checked = True
        Me.RadioButton4.Enabled = False
        Me.RadioButton4.Location = New System.Drawing.Point(582, 31)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(63, 17)
        Me.RadioButton4.TabIndex = 74
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Text = "y*1 = y1"
        Me.RadioButton4.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(261, 366)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(132, 26)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "Suma wybranych komurek" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "lub wartosc komurki"
        '
        'TextBox5
        '
        Me.TextBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBox5.Location = New System.Drawing.Point(399, 366)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(173, 20)
        Me.TextBox5.TabIndex = 72
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Współczynnik, Me.Wartość})
        Me.ListView1.Location = New System.Drawing.Point(17, 405)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(555, 162)
        Me.ListView1.TabIndex = 70
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'Współczynnik
        '
        Me.Współczynnik.Text = "Współczynnik"
        Me.Współczynnik.Width = 190
        '
        'Wartość
        '
        Me.Wartość.Text = "Wartość"
        Me.Wartość.Width = 184
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button6.Enabled = False
        Me.Button6.Location = New System.Drawing.Point(1078, 525)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(19, 43)
        Me.Button6.TabIndex = 69
        Me.Button6.Text = ">" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & ">"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button7.Enabled = False
        Me.Button7.Location = New System.Drawing.Point(582, 524)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(19, 43)
        Me.Button7.TabIndex = 68
        Me.Button7.Text = "<" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'TrackBar2
        '
        Me.TrackBar2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TrackBar2.BackColor = System.Drawing.Color.White
        Me.TrackBar2.Enabled = False
        Me.TrackBar2.Location = New System.Drawing.Point(607, 524)
        Me.TrackBar2.Name = "TrackBar2"
        Me.TrackBar2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TrackBar2.Size = New System.Drawing.Size(467, 45)
        Me.TrackBar2.TabIndex = 67
        '
        'Button8
        '
        Me.Button8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button8.Enabled = False
        Me.Button8.Location = New System.Drawing.Point(1078, 473)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(19, 43)
        Me.Button8.TabIndex = 66
        Me.Button8.Text = ">" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & ">"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button9.Enabled = False
        Me.Button9.Location = New System.Drawing.Point(581, 475)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(19, 43)
        Me.Button9.TabIndex = 65
        Me.Button9.Text = "<" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "<"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'TrackBar1
        '
        Me.TrackBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TrackBar1.BackColor = System.Drawing.Color.White
        Me.TrackBar1.Enabled = False
        Me.TrackBar1.Location = New System.Drawing.Point(607, 473)
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(465, 45)
        Me.TrackBar1.TabIndex = 64
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.RadioButton3)
        Me.TabPage2.Controls.Add(Me.RadioButton2)
        Me.TabPage2.Controls.Add(Me.RadioButton1)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.DataGridView2)
        Me.TabPage2.Controls.Add(Me.Chart1)
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.DataGridView1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1103, 579)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Szukanie idealnego współczynnika  α"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.Location = New System.Drawing.Point(7, 117)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(100, 17)
        Me.RadioButton3.TabIndex = 70
        Me.RadioButton3.Text = "Najmniejsze ME"
        Me.RadioButton3.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(7, 94)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(107, 17)
        Me.RadioButton2.TabIndex = 69
        Me.RadioButton2.Text = "Najmniejsze MSE"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(7, 71)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(115, 17)
        Me.RadioButton1.TabIndex = 68
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Najmniejsze RMSE"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(190, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(141, 13)
        Me.Label9.TabIndex = 67
        Me.Label9.Text = "Najniższe wartości osiągamy"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(190, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 66
        Me.Label7.Text = "dla α ="
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(248, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 13)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(248, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 13)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "0"
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToResizeRows = False
        Me.DataGridView2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView2.Location = New System.Drawing.Point(190, 85)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.Size = New System.Drawing.Size(186, 478)
        Me.DataGridView2.TabIndex = 62
        '
        'Chart1
        '
        Me.Chart1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        ChartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray
        ChartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray
        ChartArea2.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend2)
        Me.Chart1.Location = New System.Drawing.Point(391, 19)
        Me.Chart1.Name = "Chart1"
        Series3.ChartArea = "ChartArea1"
        Series3.Legend = "Legend1"
        Series3.Name = "Series1"
        Me.Chart1.Series.Add(Series3)
        Me.Chart1.Size = New System.Drawing.Size(693, 544)
        Me.Chart1.TabIndex = 61
        Me.Chart1.Text = "Chart2"
        '
        'Button1
        '
        Me.Button1.Enabled = False
        Me.Button1.Location = New System.Drawing.Point(6, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(178, 57)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Szukaj"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(7, 140)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.Size = New System.Drawing.Size(177, 423)
        Me.DataGridView1.TabIndex = 0
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(637, 6)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(309, 13)
        Me.Label8.TabIndex = 167
        Me.Label8.Text = "Posiadasz wersje programu: 1.2 Sprawdź pomoc i informacje na:"
        '
        'ModelBrowna
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1135, 646)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.FilePath)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ModelBrowna"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Model Wygladzania Wykladniczego Browna wersja 1.3"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv_dane, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.Wykres2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.TrackBar2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgv_dane As System.Windows.Forms.DataGridView
    Friend WithEvents Odswiez As System.Windows.Forms.Button
    Friend WithEvents alfa2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DaneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DodajDaneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZakończToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FilePath As System.Windows.Forms.TextBox
    Friend WithEvents Wykres2 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents WczytajDane As System.Windows.Forms.OpenFileDialog
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents TrackBar2 As System.Windows.Forms.TrackBar
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Współczynnik As System.Windows.Forms.ColumnHeader
    Friend WithEvents Wartość As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DodajDaneDoWyliczeniaŚrednichToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents ZapiszDaneDoExcelaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveFileDialog2 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents AktualizacjeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents EksportujBłędyDoCSVToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
