Imports System.Data.SqlClient
Public Class frmReport
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents c1pBtnFileOpen1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnFileSave1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnFilePrint1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnPageSetup1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnReflow1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnStop1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnDocInfo1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnSeparator1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnShowNavigationBar1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnSeparator2 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnMouseHand1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnMouseZoom1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnMouseZoomOut1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnMouseSelect1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnFindText1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnSeparator3 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnGoFirst1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnGoPrev1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnGoNext1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnGoLast1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnSeparator4 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnHistoryPrev1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnHistoryNext1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnSeparator5 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnZoomOut1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnZoomIn1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnSeparator6 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnViewActualSize1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnViewFullPage1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnViewPageWidth1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnViewTwoPages1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnViewFourPages1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnSeparator7 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents c1pBtnHelp1 As C1.Win.C1PrintPreview.PreviewToolBarButton
    Friend WithEvents C1RptTaloes As C1.Win.C1Report.C1Report
    Friend WithEvents C1PrtPreview As C1.Win.C1PrintPreview.C1PrintPreview
    Friend WithEvents C1RptRelTaloes As C1.Win.C1Report.C1Report
    Friend WithEvents C1RptEncomendas As C1.Win.C1Report.C1Report
    Friend WithEvents C1Report1 As C1.Win.C1Report.C1Report
    Friend WithEvents C1RptReposicao As C1.Win.C1Report.C1Report
    Friend WithEvents C1RptEncomendasFoto As C1.Win.C1Report.C1Report
    Friend WithEvents C1RptRecolhaMalas As C1.Win.C1Report.C1Report
    Friend WithEvents C1RptTranfFoto As C1.Win.C1Report.C1Report
    Friend WithEvents C1RptAnaliseGeral As C1.Win.C1Report.C1Report
    Friend WithEvents C1RptRecolhaMalasResumo As C1.Win.C1Report.C1Report
    Friend WithEvents C1RptComissoesVnd As C1.Win.C1Report.C1Report
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents C1RptGT As C1.Win.C1Report.C1Report
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReport))
        Dim C1DocEngine4 As C1.C1PrintDocument.C1DocEngine = New C1.C1PrintDocument.C1DocEngine()
        Dim Root4 As C1.C1PrintDocument.DocEngine.Render.Root = New C1.C1PrintDocument.DocEngine.Render.Root()
        Dim DrawelRoot4 As C1.C1PrintDocument.DocEngine.Src.DrawelRoot = New C1.C1PrintDocument.DocEngine.Src.DrawelRoot()
        Dim DrawelText7 As C1.C1PrintDocument.DocEngine.Src.DrawelText = New C1.C1PrintDocument.DocEngine.Src.DrawelText()
        Dim C1DColors7 As C1.C1PrintDocument.DocEngine.Src.C1DColors = New C1.C1PrintDocument.DocEngine.Src.C1DColors()
        Dim Widths13 As C1.C1PrintDocument.DocEngine.Src.Widths = New C1.C1PrintDocument.DocEngine.Src.Widths()
        Dim Widths14 As C1.C1PrintDocument.DocEngine.Src.Widths = New C1.C1PrintDocument.DocEngine.Src.Widths()
        Dim DrawelText8 As C1.C1PrintDocument.DocEngine.Src.DrawelText = New C1.C1PrintDocument.DocEngine.Src.DrawelText()
        Dim C1DColors8 As C1.C1PrintDocument.DocEngine.Src.C1DColors = New C1.C1PrintDocument.DocEngine.Src.C1DColors()
        Dim Widths15 As C1.C1PrintDocument.DocEngine.Src.Widths = New C1.C1PrintDocument.DocEngine.Src.Widths()
        Dim Widths16 As C1.C1PrintDocument.DocEngine.Src.Widths = New C1.C1PrintDocument.DocEngine.Src.Widths()
        Dim UiStrings4 As C1.Util.UIStrings = New C1.Util.UIStrings()
        Me.C1RptRecolhaMalasResumo = New C1.Win.C1Report.C1Report()
        Me.C1PrtPreview = New C1.Win.C1PrintPreview.C1PrintPreview()
        Me.c1pBtnFileOpen1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnFileSave1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnFilePrint1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnPageSetup1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnReflow1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnStop1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnDocInfo1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnSeparator1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnShowNavigationBar1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnSeparator2 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnMouseHand1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnMouseZoom1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnMouseZoomOut1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnMouseSelect1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnFindText1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnSeparator3 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnGoFirst1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnGoPrev1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnGoNext1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnGoLast1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnSeparator4 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnHistoryPrev1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnHistoryNext1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnSeparator5 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnZoomOut1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnZoomIn1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnSeparator6 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnViewActualSize1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnViewFullPage1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnViewPageWidth1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnViewTwoPages1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnViewFourPages1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnSeparator7 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.c1pBtnHelp1 = New C1.Win.C1PrintPreview.PreviewToolBarButton()
        Me.C1RptTaloes = New C1.Win.C1Report.C1Report()
        Me.C1RptRelTaloes = New C1.Win.C1Report.C1Report()
        Me.C1RptGT = New C1.Win.C1Report.C1Report()
        Me.C1RptEncomendas = New C1.Win.C1Report.C1Report()
        Me.C1Report1 = New C1.Win.C1Report.C1Report()
        Me.C1RptReposicao = New C1.Win.C1Report.C1Report()
        Me.C1RptEncomendasFoto = New C1.Win.C1Report.C1Report()
        Me.C1RptRecolhaMalas = New C1.Win.C1Report.C1Report()
        Me.C1RptTranfFoto = New C1.Win.C1Report.C1Report()
        Me.C1RptAnaliseGeral = New C1.Win.C1Report.C1Report()
        Me.C1RptComissoesVnd = New C1.Win.C1Report.C1Report()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.C1RptRecolhaMalasResumo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1PrtPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1RptTaloes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1RptRelTaloes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1RptGT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1RptEncomendas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1Report1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1RptReposicao, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1RptEncomendasFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1RptRecolhaMalas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1RptTranfFoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1RptAnaliseGeral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1RptComissoesVnd, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1RptRecolhaMalasResumo
        '
        Me.C1RptRecolhaMalasResumo.ReportDefinition = resources.GetString("C1RptRecolhaMalasResumo.ReportDefinition")
        Me.C1RptRecolhaMalasResumo.ReportName = "C1RptRecolhaMalasResumo"
        '
        'C1PrtPreview
        '
        Me.C1PrtPreview.C1DPageSettings = "color:True;landscape:False;margins:100,100,100,100;papersize:827,1169,QQA0ACAAKAA" &
    "yADEAIAB4ACAAMgA5ACwANwAgAGMAbQApACAA"
        Me.C1PrtPreview.Dock = System.Windows.Forms.DockStyle.Fill
        C1DocEngine4.DisplayName = ""
        C1DocEngine4.Name = ""
        C1DocEngine4.rnd = Root4
        DrawelRoot4.bc = Nothing
        DrawelRoot4.bo = Nothing
        DrawelRoot4.dct = Nothing
        DrawelRoot4.f = New System.Drawing.Font("Arial", 20.0!)
        DrawelRoot4.hh = Nothing
        DrawelRoot4.i = CType(1, Long)
        DrawelRoot4.ib = Nothing
        DrawelRoot4.iba = Nothing
        DrawelRoot4.mi = Nothing
        DrawelRoot4.n = "root"
        DrawelRoot4.oi = Nothing
        DrawelRoot4.pa = Nothing
        C1DColors7.Bottom = System.Drawing.Color.LightGreen
        C1DColors7.Left = System.Drawing.Color.LightGreen
        C1DColors7.Right = System.Drawing.Color.LightGreen
        C1DColors7.Top = System.Drawing.Color.Gray
        DrawelText7.bc = C1DColors7
        DrawelText7.bl = 1
        DrawelText7.bo = Widths13
        DrawelText7.cb = System.Drawing.Color.GhostWhite
        DrawelText7.cf = System.Drawing.Color.Blue
        DrawelText7.f = New System.Drawing.Font("Arial", 18.0!)
        DrawelText7.hh = Nothing
        DrawelText7.i = CType(3, Long)
        DrawelText7.ib = Nothing
        DrawelText7.iba = Nothing
        DrawelText7.mi = Nothing
        DrawelText7.n = "text"
        DrawelText7.oi = Nothing
        DrawelText7.pa = Widths14
        DrawelText7.s = Nothing
        DrawelText7.sp = Nothing
        DrawelText7.t = "Generated on quinta-feira, 20 de Abril de 2006."
        DrawelText7.th = C1.C1PrintDocument.DocEngine.Src.Names.HorzTextAlignment.right
        DrawelText7.ud = Nothing
        DrawelText7.ww = Nothing
        DrawelText7.xx = Nothing
        DrawelText7.yy = Nothing
        DrawelRoot4.pf = DrawelText7
        C1DColors8.Bottom = System.Drawing.Color.Gray
        C1DColors8.Left = System.Drawing.Color.LightGreen
        C1DColors8.Right = System.Drawing.Color.LightGreen
        C1DColors8.Top = System.Drawing.Color.LightGreen
        DrawelText8.bc = C1DColors8
        DrawelText8.bl = 1
        DrawelText8.bo = Widths15
        DrawelText8.cb = System.Drawing.Color.GhostWhite
        DrawelText8.cf = System.Drawing.Color.Blue
        DrawelText8.f = New System.Drawing.Font("Arial", 18.0!)
        DrawelText8.gn = "#p"
        DrawelText8.gt = "#P"
        DrawelText8.hh = Nothing
        DrawelText8.i = CType(2, Long)
        DrawelText8.ib = Nothing
        DrawelText8.iba = Nothing
        DrawelText8.mi = Nothing
        DrawelText8.n = "text"
        DrawelText8.oi = Nothing
        DrawelText8.pa = Widths16
        DrawelText8.s = Nothing
        DrawelText8.sp = Nothing
        DrawelText8.t = "Page #p of #P"
        DrawelText8.th = C1.C1PrintDocument.DocEngine.Src.Names.HorzTextAlignment.right
        DrawelText8.ud = Nothing
        DrawelText8.ww = Nothing
        DrawelText8.xx = Nothing
        DrawelText8.yy = Nothing
        DrawelRoot4.ph = DrawelText8
        DrawelRoot4.ps = Nothing
        DrawelRoot4.rf = True
        DrawelRoot4.s = "block,ttb"
        DrawelRoot4.sp = Nothing
        DrawelRoot4.ud = CType(resources.GetObject("DrawelRoot4.ud"), Object)
        DrawelRoot4.ww = Nothing
        DrawelRoot4.xx = Nothing
        DrawelRoot4.yy = Nothing
        C1DocEngine4.src = DrawelRoot4
        UiStrings4.Content = New String(-1) {}
        C1DocEngine4.UIStrings = UiStrings4
        Me.C1PrtPreview.Document = C1DocEngine4
        Me.C1PrtPreview.Location = New System.Drawing.Point(0, 0)
        Me.C1PrtPreview.Name = "C1PrtPreview"
        Me.C1PrtPreview.NavigationBar.Cursor = System.Windows.Forms.Cursors.Default
        Me.C1PrtPreview.NavigationBar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1PrtPreview.NavigationBar.OutlineView.Cursor = System.Windows.Forms.Cursors.Default
        Me.C1PrtPreview.NavigationBar.OutlineView.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1PrtPreview.NavigationBar.OutlineView.Indent = 19
        Me.C1PrtPreview.NavigationBar.OutlineView.ItemHeight = 16
        Me.C1PrtPreview.NavigationBar.OutlineView.TabIndex = 0
        Me.C1PrtPreview.NavigationBar.OutlineView.Visible = False
        Me.C1PrtPreview.NavigationBar.Padding = New System.Drawing.Point(6, 3)
        Me.C1PrtPreview.NavigationBar.TabIndex = 2
        Me.C1PrtPreview.NavigationBar.ThumbnailsView.AutoArrange = True
        Me.C1PrtPreview.NavigationBar.ThumbnailsView.Cursor = System.Windows.Forms.Cursors.Default
        Me.C1PrtPreview.NavigationBar.ThumbnailsView.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1PrtPreview.NavigationBar.ThumbnailsView.TabIndex = 0
        Me.C1PrtPreview.NavigationBar.ThumbnailsView.Visible = True
        Me.C1PrtPreview.NavigationBar.Width = 192
        Me.C1PrtPreview.Size = New System.Drawing.Size(926, 505)
        Me.C1PrtPreview.Splitter.Cursor = System.Windows.Forms.Cursors.VSplit
        Me.C1PrtPreview.Splitter.Width = 4
        Me.C1PrtPreview.StatusBar.Cursor = System.Windows.Forms.Cursors.Default
        Me.C1PrtPreview.StatusBar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1PrtPreview.StatusBar.TabIndex = 4
        Me.C1PrtPreview.TabIndex = 0
        Me.C1PrtPreview.ToolBar.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.c1pBtnFileOpen1, Me.c1pBtnFileSave1, Me.c1pBtnFilePrint1, Me.c1pBtnPageSetup1, Me.c1pBtnReflow1, Me.c1pBtnStop1, Me.c1pBtnDocInfo1, Me.c1pBtnSeparator1, Me.c1pBtnShowNavigationBar1, Me.c1pBtnSeparator2, Me.c1pBtnMouseHand1, Me.c1pBtnMouseZoom1, Me.c1pBtnMouseZoomOut1, Me.c1pBtnMouseSelect1, Me.c1pBtnFindText1, Me.c1pBtnSeparator3, Me.c1pBtnGoFirst1, Me.c1pBtnGoPrev1, Me.c1pBtnGoNext1, Me.c1pBtnGoLast1, Me.c1pBtnSeparator4, Me.c1pBtnHistoryPrev1, Me.c1pBtnHistoryNext1, Me.c1pBtnSeparator5, Me.c1pBtnZoomOut1, Me.c1pBtnZoomIn1, Me.c1pBtnSeparator6, Me.c1pBtnViewActualSize1, Me.c1pBtnViewFullPage1, Me.c1pBtnViewPageWidth1, Me.c1pBtnViewTwoPages1, Me.c1pBtnViewFourPages1, Me.c1pBtnSeparator7, Me.c1pBtnHelp1})
        Me.C1PrtPreview.ToolBar.Cursor = System.Windows.Forms.Cursors.Default
        Me.C1PrtPreview.ToolBar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'c1pBtnFileOpen1
        '
        Me.c1pBtnFileOpen1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.FileOpen
        Me.c1pBtnFileOpen1.ImageIndex = 0
        Me.c1pBtnFileOpen1.Name = "c1pBtnFileOpen1"
        Me.c1pBtnFileOpen1.ToolTipText = "File Open"
        '
        'c1pBtnFileSave1
        '
        Me.c1pBtnFileSave1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.FileSave
        Me.c1pBtnFileSave1.Enabled = False
        Me.c1pBtnFileSave1.ImageIndex = 1
        Me.c1pBtnFileSave1.Name = "c1pBtnFileSave1"
        Me.c1pBtnFileSave1.ToolTipText = "File Save"
        '
        'c1pBtnFilePrint1
        '
        Me.c1pBtnFilePrint1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.FilePrint
        Me.c1pBtnFilePrint1.Enabled = False
        Me.c1pBtnFilePrint1.ImageIndex = 2
        Me.c1pBtnFilePrint1.Name = "c1pBtnFilePrint1"
        Me.c1pBtnFilePrint1.ToolTipText = "Print"
        '
        'c1pBtnPageSetup1
        '
        Me.c1pBtnPageSetup1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.PageSetup
        Me.c1pBtnPageSetup1.ImageIndex = 3
        Me.c1pBtnPageSetup1.Name = "c1pBtnPageSetup1"
        Me.c1pBtnPageSetup1.ToolTipText = "Page Setup"
        '
        'c1pBtnReflow1
        '
        Me.c1pBtnReflow1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.Reflow
        Me.c1pBtnReflow1.Enabled = False
        Me.c1pBtnReflow1.ImageIndex = 4
        Me.c1pBtnReflow1.Name = "c1pBtnReflow1"
        Me.c1pBtnReflow1.ToolTipText = "Reflow"
        '
        'c1pBtnStop1
        '
        Me.c1pBtnStop1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.[Stop]
        Me.c1pBtnStop1.ImageIndex = 5
        Me.c1pBtnStop1.Name = "c1pBtnStop1"
        Me.c1pBtnStop1.ToolTipText = "Stop"
        Me.c1pBtnStop1.Visible = False
        '
        'c1pBtnDocInfo1
        '
        Me.c1pBtnDocInfo1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.DocInfo
        Me.c1pBtnDocInfo1.Enabled = False
        Me.c1pBtnDocInfo1.ImageIndex = 26
        Me.c1pBtnDocInfo1.Name = "c1pBtnDocInfo1"
        Me.c1pBtnDocInfo1.ToolTipText = "Document information"
        '
        'c1pBtnSeparator1
        '
        Me.c1pBtnSeparator1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.None
        Me.c1pBtnSeparator1.Name = "c1pBtnSeparator1"
        Me.c1pBtnSeparator1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'c1pBtnShowNavigationBar1
        '
        Me.c1pBtnShowNavigationBar1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.ShowNavigationBar
        Me.c1pBtnShowNavigationBar1.ImageIndex = 6
        Me.c1pBtnShowNavigationBar1.Name = "c1pBtnShowNavigationBar1"
        Me.c1pBtnShowNavigationBar1.Pushed = True
        Me.c1pBtnShowNavigationBar1.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.c1pBtnShowNavigationBar1.ToolTipText = "Show Navigation Bar"
        '
        'c1pBtnSeparator2
        '
        Me.c1pBtnSeparator2.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.None
        Me.c1pBtnSeparator2.Name = "c1pBtnSeparator2"
        Me.c1pBtnSeparator2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'c1pBtnMouseHand1
        '
        Me.c1pBtnMouseHand1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.MouseHand
        Me.c1pBtnMouseHand1.Enabled = False
        Me.c1pBtnMouseHand1.ImageIndex = 7
        Me.c1pBtnMouseHand1.Name = "c1pBtnMouseHand1"
        Me.c1pBtnMouseHand1.Pushed = True
        Me.c1pBtnMouseHand1.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.c1pBtnMouseHand1.ToolTipText = "Hand Tool"
        '
        'c1pBtnMouseZoom1
        '
        Me.c1pBtnMouseZoom1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.MouseZoom
        Me.c1pBtnMouseZoom1.Enabled = False
        Me.c1pBtnMouseZoom1.ImageIndex = 8
        Me.c1pBtnMouseZoom1.Name = "c1pBtnMouseZoom1"
        Me.c1pBtnMouseZoom1.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.c1pBtnMouseZoom1.ToolTipText = "Zoom In Tool"
        '
        'c1pBtnMouseZoomOut1
        '
        Me.c1pBtnMouseZoomOut1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.MouseZoomOut
        Me.c1pBtnMouseZoomOut1.Enabled = False
        Me.c1pBtnMouseZoomOut1.ImageIndex = 25
        Me.c1pBtnMouseZoomOut1.Name = "c1pBtnMouseZoomOut1"
        Me.c1pBtnMouseZoomOut1.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.c1pBtnMouseZoomOut1.ToolTipText = "Zoom Out Tool"
        Me.c1pBtnMouseZoomOut1.Visible = False
        '
        'c1pBtnMouseSelect1
        '
        Me.c1pBtnMouseSelect1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.MouseSelect
        Me.c1pBtnMouseSelect1.Enabled = False
        Me.c1pBtnMouseSelect1.ImageIndex = 9
        Me.c1pBtnMouseSelect1.Name = "c1pBtnMouseSelect1"
        Me.c1pBtnMouseSelect1.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.c1pBtnMouseSelect1.ToolTipText = "Select Text"
        '
        'c1pBtnFindText1
        '
        Me.c1pBtnFindText1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.FindText
        Me.c1pBtnFindText1.Enabled = False
        Me.c1pBtnFindText1.ImageIndex = 10
        Me.c1pBtnFindText1.Name = "c1pBtnFindText1"
        Me.c1pBtnFindText1.ToolTipText = "Find Text"
        '
        'c1pBtnSeparator3
        '
        Me.c1pBtnSeparator3.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.None
        Me.c1pBtnSeparator3.Name = "c1pBtnSeparator3"
        Me.c1pBtnSeparator3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'c1pBtnGoFirst1
        '
        Me.c1pBtnGoFirst1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.GoFirst
        Me.c1pBtnGoFirst1.Enabled = False
        Me.c1pBtnGoFirst1.ImageIndex = 11
        Me.c1pBtnGoFirst1.Name = "c1pBtnGoFirst1"
        Me.c1pBtnGoFirst1.ToolTipText = "First Page"
        '
        'c1pBtnGoPrev1
        '
        Me.c1pBtnGoPrev1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.GoPrev
        Me.c1pBtnGoPrev1.Enabled = False
        Me.c1pBtnGoPrev1.ImageIndex = 12
        Me.c1pBtnGoPrev1.Name = "c1pBtnGoPrev1"
        Me.c1pBtnGoPrev1.ToolTipText = "Previous Page"
        '
        'c1pBtnGoNext1
        '
        Me.c1pBtnGoNext1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.GoNext
        Me.c1pBtnGoNext1.Enabled = False
        Me.c1pBtnGoNext1.ImageIndex = 13
        Me.c1pBtnGoNext1.Name = "c1pBtnGoNext1"
        Me.c1pBtnGoNext1.ToolTipText = "Next Page"
        '
        'c1pBtnGoLast1
        '
        Me.c1pBtnGoLast1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.GoLast
        Me.c1pBtnGoLast1.Enabled = False
        Me.c1pBtnGoLast1.ImageIndex = 14
        Me.c1pBtnGoLast1.Name = "c1pBtnGoLast1"
        Me.c1pBtnGoLast1.ToolTipText = "Last Page"
        '
        'c1pBtnSeparator4
        '
        Me.c1pBtnSeparator4.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.None
        Me.c1pBtnSeparator4.Name = "c1pBtnSeparator4"
        Me.c1pBtnSeparator4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'c1pBtnHistoryPrev1
        '
        Me.c1pBtnHistoryPrev1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.HistoryPrev
        Me.c1pBtnHistoryPrev1.Enabled = False
        Me.c1pBtnHistoryPrev1.ImageIndex = 15
        Me.c1pBtnHistoryPrev1.Name = "c1pBtnHistoryPrev1"
        Me.c1pBtnHistoryPrev1.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.c1pBtnHistoryPrev1.ToolTipText = "Previous View"
        '
        'c1pBtnHistoryNext1
        '
        Me.c1pBtnHistoryNext1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.HistoryNext
        Me.c1pBtnHistoryNext1.Enabled = False
        Me.c1pBtnHistoryNext1.ImageIndex = 16
        Me.c1pBtnHistoryNext1.Name = "c1pBtnHistoryNext1"
        Me.c1pBtnHistoryNext1.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.c1pBtnHistoryNext1.ToolTipText = "Next View"
        '
        'c1pBtnSeparator5
        '
        Me.c1pBtnSeparator5.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.None
        Me.c1pBtnSeparator5.Name = "c1pBtnSeparator5"
        Me.c1pBtnSeparator5.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        Me.c1pBtnSeparator5.Visible = False
        '
        'c1pBtnZoomOut1
        '
        Me.c1pBtnZoomOut1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.ZoomOut
        Me.c1pBtnZoomOut1.Enabled = False
        Me.c1pBtnZoomOut1.ImageIndex = 17
        Me.c1pBtnZoomOut1.Name = "c1pBtnZoomOut1"
        Me.c1pBtnZoomOut1.ToolTipText = "Zoom Out"
        Me.c1pBtnZoomOut1.Visible = False
        '
        'c1pBtnZoomIn1
        '
        Me.c1pBtnZoomIn1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.ZoomIn
        Me.c1pBtnZoomIn1.Enabled = False
        Me.c1pBtnZoomIn1.ImageIndex = 18
        Me.c1pBtnZoomIn1.Name = "c1pBtnZoomIn1"
        Me.c1pBtnZoomIn1.ToolTipText = "Zoom In"
        Me.c1pBtnZoomIn1.Visible = False
        '
        'c1pBtnSeparator6
        '
        Me.c1pBtnSeparator6.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.None
        Me.c1pBtnSeparator6.Name = "c1pBtnSeparator6"
        Me.c1pBtnSeparator6.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        Me.c1pBtnSeparator6.Visible = False
        '
        'c1pBtnViewActualSize1
        '
        Me.c1pBtnViewActualSize1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.ViewActualSize
        Me.c1pBtnViewActualSize1.Enabled = False
        Me.c1pBtnViewActualSize1.ImageIndex = 19
        Me.c1pBtnViewActualSize1.Name = "c1pBtnViewActualSize1"
        Me.c1pBtnViewActualSize1.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.c1pBtnViewActualSize1.ToolTipText = "Actual Size"
        '
        'c1pBtnViewFullPage1
        '
        Me.c1pBtnViewFullPage1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.ViewFullPage
        Me.c1pBtnViewFullPage1.Enabled = False
        Me.c1pBtnViewFullPage1.ImageIndex = 20
        Me.c1pBtnViewFullPage1.Name = "c1pBtnViewFullPage1"
        Me.c1pBtnViewFullPage1.Pushed = True
        Me.c1pBtnViewFullPage1.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.c1pBtnViewFullPage1.ToolTipText = "Full Page"
        '
        'c1pBtnViewPageWidth1
        '
        Me.c1pBtnViewPageWidth1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.ViewPageWidth
        Me.c1pBtnViewPageWidth1.Enabled = False
        Me.c1pBtnViewPageWidth1.ImageIndex = 21
        Me.c1pBtnViewPageWidth1.Name = "c1pBtnViewPageWidth1"
        Me.c1pBtnViewPageWidth1.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.c1pBtnViewPageWidth1.ToolTipText = "Page Width"
        '
        'c1pBtnViewTwoPages1
        '
        Me.c1pBtnViewTwoPages1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.ViewTwoPages
        Me.c1pBtnViewTwoPages1.Enabled = False
        Me.c1pBtnViewTwoPages1.ImageIndex = 22
        Me.c1pBtnViewTwoPages1.Name = "c1pBtnViewTwoPages1"
        Me.c1pBtnViewTwoPages1.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
        Me.c1pBtnViewTwoPages1.ToolTipText = "Two Pages"
        '
        'c1pBtnViewFourPages1
        '
        Me.c1pBtnViewFourPages1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.ViewFourPages
        Me.c1pBtnViewFourPages1.Enabled = False
        Me.c1pBtnViewFourPages1.ImageIndex = 23
        Me.c1pBtnViewFourPages1.Name = "c1pBtnViewFourPages1"
        Me.c1pBtnViewFourPages1.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.c1pBtnViewFourPages1.ToolTipText = "Four Pages"
        '
        'c1pBtnSeparator7
        '
        Me.c1pBtnSeparator7.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.None
        Me.c1pBtnSeparator7.Name = "c1pBtnSeparator7"
        Me.c1pBtnSeparator7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        Me.c1pBtnSeparator7.Visible = False
        '
        'c1pBtnHelp1
        '
        Me.c1pBtnHelp1.Action = C1.Win.C1PrintPreview.ToolBarButtonActionEnum.Help
        Me.c1pBtnHelp1.ImageIndex = 24
        Me.c1pBtnHelp1.Name = "c1pBtnHelp1"
        Me.c1pBtnHelp1.ToolTipText = "Help"
        Me.c1pBtnHelp1.Visible = False
        '
        'C1RptTaloes
        '
        Me.C1RptTaloes.ReportDefinition = resources.GetString("C1RptTaloes.ReportDefinition")
        Me.C1RptTaloes.ReportName = "Talões"
        '
        'C1RptRelTaloes
        '
        Me.C1RptRelTaloes.ReportDefinition = resources.GetString("C1RptRelTaloes.ReportDefinition")
        Me.C1RptRelTaloes.ReportName = "RelaTaloes"
        '
        'C1RptGT
        '
        Me.C1RptGT.ReportDefinition = resources.GetString("C1RptGT.ReportDefinition")
        Me.C1RptGT.ReportName = "GuiaTransp"
        '
        'C1RptEncomendas
        '
        Me.C1RptEncomendas.ReportDefinition = resources.GetString("C1RptEncomendas.ReportDefinition")
        Me.C1RptEncomendas.ReportName = "C1RptEncomendas"
        '
        'C1Report1
        '
        Me.C1Report1.ReportDefinition = resources.GetString("C1Report1.ReportDefinition")
        Me.C1Report1.ReportName = "C1Report1"
        '
        'C1RptReposicao
        '
        Me.C1RptReposicao.ReportDefinition = resources.GetString("C1RptReposicao.ReportDefinition")
        Me.C1RptReposicao.ReportName = "C1RptReposicao"
        '
        'C1RptEncomendasFoto
        '
        Me.C1RptEncomendasFoto.ReportDefinition = resources.GetString("C1RptEncomendasFoto.ReportDefinition")
        Me.C1RptEncomendasFoto.ReportName = "C1RptEncomendasFoto"
        '
        'C1RptRecolhaMalas
        '
        Me.C1RptRecolhaMalas.ReportDefinition = resources.GetString("C1RptRecolhaMalas.ReportDefinition")
        Me.C1RptRecolhaMalas.ReportName = "C1RptRecolhaMalas"
        '
        'C1RptTranfFoto
        '
        Me.C1RptTranfFoto.ReportDefinition = resources.GetString("C1RptTranfFoto.ReportDefinition")
        Me.C1RptTranfFoto.ReportName = "C1RptTranfFoto"
        '
        'C1RptAnaliseGeral
        '
        Me.C1RptAnaliseGeral.ReportDefinition = resources.GetString("C1RptAnaliseGeral.ReportDefinition")
        Me.C1RptAnaliseGeral.ReportName = "C1RptAnaliseGeral"
        '
        'C1RptComissoesVnd
        '
        Me.C1RptComissoesVnd.ReportDefinition = resources.GetString("C1RptComissoesVnd.ReportDefinition")
        Me.C1RptComissoesVnd.ReportName = "C1RptComissoesVnd"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(750, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(162, 30)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Email"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'frmReport
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(926, 505)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.C1PrtPreview)
        Me.Name = "frmReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmReport"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.C1RptRecolhaMalasResumo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1PrtPreview, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1RptTaloes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1RptRelTaloes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1RptGT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1RptEncomendas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1Report1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1RptReposicao, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1RptEncomendasFoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1RptRecolhaMalas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1RptTranfFoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1RptAnaliseGeral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1RptComissoesVnd, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region



    Private Sub C1RptTaloes_PrintSection(ByVal sender As Object, ByVal e As C1.Win.C1Report.ReportEventArgs) Handles C1RptTaloes.PrintSection
        If xFotoReport = True Then
            If Me.C1RptTaloes.ReportName = "Talões" Or Me.C1RptTaloes.ReportName = "Precos" Then
                Dim xFilePath As String = xFotosPath + C1RptTaloes.Fields.Item("txtFoto").Value + ".jpg"
                If IO.File.Exists(xFilePath) Then
                    'Dim a As New Bitmap("c:\a.jpg")
                    'pic.Image = New Bitmap(a)
                    'a.Dispose()
                    Me.C1RptTaloes.Fields.Item("PicBox").Picture = Image.FromFile(xFilePath)
                End If
            End If
        End If
    End Sub

    Private Sub C1RptEncomendas_StartPage(ByVal sender As Object, ByVal e As C1.Win.C1Report.ReportEventArgs) Handles C1RptEncomendas.StartPage
        Dim I As Integer
        Try

            With Me.C1RptEncomendas
                With .Sections
                    For I = 1 To 10
                        .Item("PageHeader").Fields("TAM" + I.ToString).Text = ""
                        .Item("PageHeader").Fields("TAM" + I.ToString).Visible = False
                        .Item("Detail").Fields("QTD" + Format(I, "00").ToString).Text = ""
                        .Item("Detail").Fields("QTD" + Format(I, "00").ToString).Visible = False
                        .Item("FooterFornID").Fields("QTDT" + Format(I, "00").ToString).Visible = False
                    Next
                    I = 1
                    For Each c As DataRow In ds_Enc.Tables(0).Rows
                        .Item("PageHeader").Fields("TAM" + I.ToString).Text = c(0)
                        .Item("Detail").Fields("QTD" + Format(I, "00").ToString).Text = "[" + c(0).ToString + "]"
                        .Item("PageHeader").Fields("TAM" + I.ToString).Visible = True
                        .Item("Detail").Fields("QTD" + Format(I, "00").ToString).Visible = True
                        .Item("FooterFornID").Fields("QTDT" + Format(I, "00").ToString).Visible = True
                        I += 1
                    Next
                End With
            End With
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, Me.Name & ": C1RptEncomendas_StartPage")
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name & ": C1RptEncomendas_StartPage")
        Finally
            da.Dispose()
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub C1RptReposicao_StartPage(ByVal sender As Object, ByVal e As C1.Win.C1Report.ReportEventArgs) Handles C1RptReposicao.StartPage
        Dim I As Integer
        Try

            With Me.C1RptReposicao
                With .Sections
                    For I = 1 To 10
                        .Item("PageHeader").Fields("ARM" + I.ToString).Text = ""
                        .Item("PageHeader").Fields("ARM" + I.ToString).Visible = False
                        .Item("Detail").Fields("QTD" + Format(I, "00").ToString).Text = ""
                        .Item("Detail").Fields("QTD" + Format(I, "00").ToString).Visible = False
                    Next
                    I = 1
                    For Each r As DataRow In ds.Tables(0).Rows
                        .Item("PageHeader").Fields("ARM" + I.ToString).Text = r(0)
                        .Item("Detail").Fields("QTD" + Format(I, "00").ToString).Text = "[" + r(0).ToString + "]"
                        .Item("PageHeader").Fields("ARM" + I.ToString).Visible = True
                        .Item("Detail").Fields("QTD" + Format(I, "00").ToString).Visible = True
                        I += 1
                    Next
                End With
            End With
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, Me.Name & ": C1RptReposicao_StartPage")
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name & ": C1RptReposicao_StartPage")
        Finally
            da.Dispose()
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Sub C1RptEncomendasFoto_PrintSection(ByVal sender As Object, ByVal e As C1.Win.C1Report.ReportEventArgs) Handles C1RptEncomendasFoto.PrintSection
        If Me.C1RptEncomendasFoto.ReportName = "Encomendas" Then
            If FotoFornec() = False Then
                Dim xFilePath As String = xFotosPath + C1RptEncomendasFoto.Fields.Item("txtFoto").Value + ".jpg"
                If IO.File.Exists(xFilePath) Then
                    Me.C1RptEncomendasFoto.Fields.Item("PicBox").Picture = Image.FromFile(xFilePath)
                End If
            End If
        End If
    End Sub

    Private Sub C1RptEncomendasFoto_StartPage(ByVal sender As Object, ByVal e As C1.Win.C1Report.ReportEventArgs) Handles C1RptEncomendasFoto.StartPage
        'Dim I As Integer
        Try

            With Me.C1RptEncomendasFoto
                With .Sections
                    'For I = 1 To 10
                    '.Item("PageHeader").Fields("TAM" + I.ToString).Text = ""
                    '.Item("PageHeader").Fields("TAM" + I.ToString).Visible = False
                    '.Item("Detail").Fields("QTD" + Format(I, "00").ToString).Text = ""
                    '.Item("Detail").Fields("QTD" + Format(I, "00").ToString).Visible = False
                    'Next
                    'I = 1
                    'For Each c As DataRow In ds_Enc.Tables(0).Rows
                    '.Item("PageHeader").Fields("TAM" + I.ToString).Text = c(0)
                    '.Item("Detail").Fields("QTD" + Format(I, "00").ToString).Text = "[" + c(0).ToString + "]"
                    '.Item("PageHeader").Fields("TAM" + I.ToString).Visible = True
                    '.Item("Detail").Fields("QTD" + Format(I, "00").ToString).Visible = True
                    'I += 1
                    'Next
                End With
            End With
        Catch ex As SqlException
            ErroSQL(ex.Number, ex.Message, Me.Name & ": C1RptEncomendasFoto_StartPage")
        Catch ex As Exception
            ErroVB(ex.Message, Me.Name & ": C1RptEncomendasFoto_StartPage")
        Finally
            da.Dispose()
            If cn.State = ConnectionState.Open Then cn.Close()
        End Try
    End Sub

    Private Function FotoFornec() As Boolean
        FotoFornec = False
        Dim xFornecedor As String = C1RptEncomendasFoto.Fields.Item("FornID").Value
        If Not C1RptEncomendasFoto.Fields.Item("RefForn").Value Is DBNull.Value Then
            Dim xForncfoto As String = C1RptEncomendasFoto.Fields.Item("RefForn").Value & ".jpg"
            If IO.Directory.Exists(xFotosPath & xFornecedor) Then
                If IO.File.Exists(xFotosPath & xFornecedor & "/" & xForncfoto) Then
                    Me.C1RptEncomendasFoto.Fields.Item("PicBox").Picture = Image.FromFile(xFotosPath & xFornecedor & "/" & xForncfoto)
                    Return True
                End If
            End If
        End If

    End Function

    Private Sub C1RptRecolhaMalas_StartReport(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1RptRecolhaMalas.StartReport
        C1RptRecolhaMalas.Fields.Item("txtDeData").Value = xDeDataRecolha
        C1RptRecolhaMalas.Fields.Item("txtAteData").Value = xAteDataRecolha
    End Sub

    Private Sub C1RptTranfFoto_PrintSection(ByVal sender As Object, ByVal e As C1.Win.C1Report.ReportEventArgs) Handles C1RptTranfFoto.PrintSection
        If Me.C1RptTranfFoto.ReportName = "TransfFoto" Then
            Dim xFilePath As String = xFotosPath + C1RptTranfFoto.Fields.Item("txtFoto").Value + ".jpg"
            If IO.File.Exists(xFilePath) Then
                Me.C1RptTranfFoto.Fields.Item("PicBox").Picture = Image.FromFile(xFilePath)
            End If
        End If
    End Sub

    Private Sub C1RptAnaliseGeral_PrintSection(ByVal sender As Object, ByVal e As C1.Win.C1Report.ReportEventArgs) Handles C1RptAnaliseGeral.PrintSection
        If Me.C1RptAnaliseGeral.ReportName = "AnaliseGeral" Then
            Dim xFilePath As String = xFotosPath + C1RptAnaliseGeral.Fields.Item("txtFoto").Value + ".jpg"
            If IO.File.Exists(xFilePath) Then
                Me.C1RptAnaliseGeral.Fields.Item("PicBox").Picture = Image.FromFile(xFilePath)
            Else
                Me.C1RptAnaliseGeral.Fields.Item("PicBox").Picture = Image.FromFile(xFotosPath + "xok.jpg")
            End If
        End If
    End Sub

    Private Sub C1Report1_StartPage(ByVal sender As Object, ByVal e As C1.Win.C1Report.ReportEventArgs) Handles C1Report1.StartPage
        Dim nPag As Int16 = xNPag

        If bImprimeSubRelatorio = True Then
            C1Report1.Fields.Item("srDocsRela").Visible = True
        End If

    End Sub

    Private Sub C1RptComissoesVnd_StartReport(ByVal sender As Object, ByVal e As System.EventArgs) Handles C1RptComissoesVnd.StartReport
        C1RptComissoesVnd.Fields.Item("txtDeData").Value = xDeDataRecolha
        C1RptComissoesVnd.Fields.Item("txtAteData").Value = xAteDataRecolha
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        MsgBox("email enviado com sucesso")
    End Sub


End Class
