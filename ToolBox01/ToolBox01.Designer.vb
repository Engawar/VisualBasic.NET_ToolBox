<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ToolBox01
    Inherits System.Windows.Forms.Form


    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.名前 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.数値1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.数値2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lbldgv説明 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.名前, Me.数値1, Me.数値2})
        Me.DataGridView1.Location = New System.Drawing.Point(78, 230)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersWidth = 82
        Me.DataGridView1.RowTemplate.Height = 41
        Me.DataGridView1.Size = New System.Drawing.Size(1252, 630)
        Me.DataGridView1.TabIndex = 0
        '
        '名前
        '
        Me.名前.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.名前.Frozen = True
        Me.名前.HeaderText = "名前"
        Me.名前.MaxInputLength = 50
        Me.名前.MinimumWidth = 60
        Me.名前.Name = "名前"
        Me.名前.ReadOnly = True
        Me.名前.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.名前.Width = 68
        '
        '数値1
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.NullValue = "0"
        Me.数値1.DefaultCellStyle = DataGridViewCellStyle1
        Me.数値1.HeaderText = "数値1"
        Me.数値1.MaxInputLength = 5
        Me.数値1.MinimumWidth = 60
        Me.数値1.Name = "数値1"
        Me.数値1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.数値1.Width = 120
        '
        '数値2
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.NullValue = "0"
        Me.数値2.DefaultCellStyle = DataGridViewCellStyle2
        Me.数値2.HeaderText = "数値2"
        Me.数値2.MaxInputLength = 5
        Me.数値2.MinimumWidth = 60
        Me.数値2.Name = "数値2"
        Me.数値2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.数値2.Width = 120
        '
        'lbldgv説明
        '
        Me.lbldgv説明.AutoSize = True
        Me.lbldgv説明.Location = New System.Drawing.Point(78, 162)
        Me.lbldgv説明.Name = "lbldgv説明"
        Me.lbldgv説明.Size = New System.Drawing.Size(126, 32)
        Me.lbldgv説明.TabIndex = 1
        Me.lbldgv説明.Text = "入力用dgv"
        '
        'ToolBox01
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 32.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1502, 969)
        Me.Controls.Add(Me.lbldgv説明)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "ToolBox01"
        Me.Text = "Form1"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub


    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents lbldgv説明 As Label
    Friend WithEvents 名前 As DataGridViewTextBoxColumn
    Friend WithEvents 数値1 As DataGridViewTextBoxColumn
    Friend WithEvents 数値2 As DataGridViewTextBoxColumn
End Class
