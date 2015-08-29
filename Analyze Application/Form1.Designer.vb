<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.backgroundthread = New System.ComponentModel.BackgroundWorker()
        Me.pbProgress = New System.Windows.Forms.ProgressBar()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbTimeline = New System.Windows.Forms.CheckBox()
        Me.tbFile = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbAPIKEY = New System.Windows.Forms.TextBox()
        Me.btnStartImport = New System.Windows.Forms.Button()
        Me.btnStopImport = New System.Windows.Forms.Button()
        Me.tbLog = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tbExportDir = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbBrawlers = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbDir = New System.Windows.Forms.TextBox()
        Me.backgroundbrawlers = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.tbItemsFile = New System.Windows.Forms.TextBox()
        Me.tbChampionsFile = New System.Windows.Forms.TextBox()
        Me.tbExportDir2 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'backgroundthread
        '
        Me.backgroundthread.WorkerReportsProgress = True
        Me.backgroundthread.WorkerSupportsCancellation = True
        '
        'pbProgress
        '
        Me.pbProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbProgress.Location = New System.Drawing.Point(12, 312)
        Me.pbProgress.Name = "pbProgress"
        Me.pbProgress.Size = New System.Drawing.Size(753, 23)
        Me.pbProgress.TabIndex = 0
        '
        'lblProgress
        '
        Me.lblProgress.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProgress.Location = New System.Drawing.Point(12, 286)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(834, 23)
        Me.lblProgress.TabIndex = 1
        Me.lblProgress.Text = "Waiting for start ..."
        Me.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cbTimeline)
        Me.GroupBox1.Controls.Add(Me.tbFile)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tbAPIKEY)
        Me.GroupBox1.Controls.Add(Me.btnStartImport)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(300, 271)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Import"
        '
        'cbTimeline
        '
        Me.cbTimeline.AutoSize = True
        Me.cbTimeline.Location = New System.Drawing.Point(82, 67)
        Me.cbTimeline.Name = "cbTimeline"
        Me.cbTimeline.Size = New System.Drawing.Size(103, 17)
        Me.cbTimeline.TabIndex = 8
        Me.cbTimeline.Text = "Include Timeline"
        Me.cbTimeline.UseVisualStyleBackColor = True
        '
        'tbFile
        '
        Me.tbFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbFile.Location = New System.Drawing.Point(81, 40)
        Me.tbFile.Name = "tbFile"
        Me.tbFile.Size = New System.Drawing.Size(213, 20)
        Me.tbFile.TabIndex = 5
        Me.tbFile.Text = "D:\Installed x64\inetpub\wwwroot\RIOT\RIOT\data\BILGEWATER\EUW.json"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(6, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "File"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "API Key"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbAPIKEY
        '
        Me.tbAPIKEY.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbAPIKEY.Location = New System.Drawing.Point(81, 19)
        Me.tbAPIKEY.Name = "tbAPIKEY"
        Me.tbAPIKEY.Size = New System.Drawing.Size(213, 20)
        Me.tbAPIKEY.TabIndex = 1
        Me.tbAPIKEY.Text = "902d3f91-f1ad-475b-96c7-766f73ea5f57"
        '
        'btnStartImport
        '
        Me.btnStartImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStartImport.Location = New System.Drawing.Point(219, 242)
        Me.btnStartImport.Name = "btnStartImport"
        Me.btnStartImport.Size = New System.Drawing.Size(75, 23)
        Me.btnStartImport.TabIndex = 0
        Me.btnStartImport.Text = "Start"
        Me.btnStartImport.UseVisualStyleBackColor = True
        '
        'btnStopImport
        '
        Me.btnStopImport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStopImport.Enabled = False
        Me.btnStopImport.Location = New System.Drawing.Point(771, 312)
        Me.btnStopImport.Name = "btnStopImport"
        Me.btnStopImport.Size = New System.Drawing.Size(75, 23)
        Me.btnStopImport.TabIndex = 6
        Me.btnStopImport.Text = "Stop"
        Me.btnStopImport.UseVisualStyleBackColor = True
        '
        'tbLog
        '
        Me.tbLog.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbLog.BackColor = System.Drawing.SystemColors.Menu
        Me.tbLog.Location = New System.Drawing.Point(641, 12)
        Me.tbLog.Multiline = True
        Me.tbLog.Name = "tbLog"
        Me.tbLog.ReadOnly = True
        Me.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.tbLog.Size = New System.Drawing.Size(205, 271)
        Me.tbLog.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.tbExportDir)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.lbBrawlers)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.tbDir)
        Me.GroupBox2.Location = New System.Drawing.Point(318, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(317, 139)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Analyze"
        '
        'tbExportDir
        '
        Me.tbExportDir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbExportDir.Location = New System.Drawing.Point(94, 41)
        Me.tbExportDir.Name = "tbExportDir"
        Me.tbExportDir.Size = New System.Drawing.Size(217, 20)
        Me.tbExportDir.TabIndex = 11
        Me.tbExportDir.Text = "D:\Installed x64\inetpub\wwwroot\RIOT\RIOT\data\BILGEWATER\EXPORT"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(6, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 20)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Export Dir"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbBrawlers
        '
        Me.lbBrawlers.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbBrawlers.Location = New System.Drawing.Point(159, 110)
        Me.lbBrawlers.Name = "lbBrawlers"
        Me.lbBrawlers.Size = New System.Drawing.Size(152, 23)
        Me.lbBrawlers.TabIndex = 9
        Me.lbBrawlers.Text = "Analyze"
        Me.lbBrawlers.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(6, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 20)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "API Key"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbDir
        '
        Me.tbDir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDir.Location = New System.Drawing.Point(94, 19)
        Me.tbDir.Name = "tbDir"
        Me.tbDir.Size = New System.Drawing.Size(217, 20)
        Me.tbDir.TabIndex = 9
        Me.tbDir.Text = "D:\Installed x64\inetpub\wwwroot\RIOT\RIOT\data\BILGEWATER\MERGED"
        '
        'backgroundbrawlers
        '
        Me.backgroundbrawlers.WorkerReportsProgress = True
        Me.backgroundbrawlers.WorkerSupportsCancellation = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.tbExportDir2)
        Me.GroupBox3.Controls.Add(Me.tbChampionsFile)
        Me.GroupBox3.Controls.Add(Me.tbItemsFile)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Location = New System.Drawing.Point(318, 157)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(317, 126)
        Me.GroupBox3.TabIndex = 7
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Export Data"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(159, 97)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(152, 23)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Export"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'tbItemsFile
        '
        Me.tbItemsFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbItemsFile.Location = New System.Drawing.Point(94, 19)
        Me.tbItemsFile.Name = "tbItemsFile"
        Me.tbItemsFile.Size = New System.Drawing.Size(217, 20)
        Me.tbItemsFile.TabIndex = 13
        Me.tbItemsFile.Text = "D:\Installed x64\inetpub\wwwroot\RIOT\RIOT\data\BILGEWATER\GLOBAL\item.json"
        '
        'tbChampionsFile
        '
        Me.tbChampionsFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbChampionsFile.Location = New System.Drawing.Point(94, 45)
        Me.tbChampionsFile.Name = "tbChampionsFile"
        Me.tbChampionsFile.Size = New System.Drawing.Size(217, 20)
        Me.tbChampionsFile.TabIndex = 14
        Me.tbChampionsFile.Text = "D:\Installed x64\inetpub\wwwroot\RIOT\RIOT\data\BILGEWATER\GLOBAL\champion.json"
        '
        'tbExportDir2
        '
        Me.tbExportDir2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbExportDir2.Location = New System.Drawing.Point(94, 71)
        Me.tbExportDir2.Name = "tbExportDir2"
        Me.tbExportDir2.Size = New System.Drawing.Size(217, 20)
        Me.tbExportDir2.TabIndex = 15
        Me.tbExportDir2.Text = "D:\Installed x64\inetpub\wwwroot\RIOT\RIOT\data\BILGEWATER\EXPORT"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(6, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 20)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Items File"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(6, 45)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 20)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Champions File"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(6, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 20)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Export Dir"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 347)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnStopImport)
        Me.Controls.Add(Me.tbLog)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.pbProgress)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents backgroundthread As System.ComponentModel.BackgroundWorker
    Friend WithEvents pbProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProgress As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnStartImport As System.Windows.Forms.Button
    Friend WithEvents tbLog As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbAPIKEY As System.Windows.Forms.TextBox
    Friend WithEvents tbFile As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnStopImport As System.Windows.Forms.Button
    Friend WithEvents cbTimeline As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lbBrawlers As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbDir As System.Windows.Forms.TextBox
    Friend WithEvents backgroundbrawlers As System.ComponentModel.BackgroundWorker
    Friend WithEvents tbExportDir As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbExportDir2 As System.Windows.Forms.TextBox
    Friend WithEvents tbChampionsFile As System.Windows.Forms.TextBox
    Friend WithEvents tbItemsFile As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
