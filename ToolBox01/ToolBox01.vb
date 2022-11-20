Public Class ToolBox01

#Region "変数・定数定義"
    Private lst名前 As List(Of String) = New List(Of String) From
            {"山田太郎",
             "田中二朗",
             "伊藤三郎",
             "高橋史朗"}
    Private strZero As String = "0"
#End Region

#Region "コンストラクタ"
    Public Sub New()

        ' この呼び出しはデザイナーで必要です。
        InitializeComponent()

        ' InitializeComponent() 呼び出しの後で初期化を追加します。
        'DataGridViewに表示する初期値を作成
        For i As Integer = 0 To lst名前.Count - 1
            With DataGridView1
                .Rows.Add()
                .Rows(i).Cells(0).Value = lst名前(i)
                .Rows(i).Cells(1).Value = strZero
                .Rows(i).Cells(2).Value = strZero
            End With
        Next

    End Sub

#End Region

#Region "イベント"

#Region "FormToolbox_Load"
    ''' <summary>
    ''' 初期状態の画面を表示する。
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub FormToolbox_Load(sender As Object, e As EventArgs) Handles MyBase.Load


    End Sub
#End Region

#Region "DataGridView1_EditingControlShowing"
    ''' <summary>
    ''' セルが編集モードになると処理を開始するイベント。
    ''' KeyDownでの入力制御の際に使用。
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object,
         ByVal e As DataGridViewEditingControlShowingEventArgs) _
         Handles DataGridView1.EditingControlShowing
        '表示されているコントロールがDataGridViewTextBoxEditingControlか調べる
        If TypeOf e.Control Is DataGridViewTextBoxEditingControl Then
            Dim dgv As DataGridView = CType(sender, DataGridView)

            '編集のために表示されているコントロールを取得
            Dim tb As DataGridViewTextBoxEditingControl =
             CType(e.Control, DataGridViewTextBoxEditingControl)

                'イベントハンドラを削除
                RemoveHandler tb.KeyDown, AddressOf DataGridView1_Keydown '強さ:PreviewKeyDown>Keydown>KeyPress

                '該当する列か調べる
                If dgv.CurrentCell.OwningColumn.Name = "数値1" Then
                    'KeyDownイベントハンドラを追加
                    AddHandler tb.KeyDown, AddressOf DataGridView1_Keydown
                ElseIf dgv.CurrentCell.OwningColumn.Name = "数値2" Then
                    'KeyDownイベントハンドラを追加
                    AddHandler tb.KeyDown, AddressOf DataGridView1_Keydown
                End If
            End If
    End Sub
#End Region

#Region "DataGridView1_Keydown"
    ''' <summary>
    ''' DataGridView1の数値1,数値2に入力可能なキーを設定するイベント。
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DataGridView1_Keydown(sender As Object, e As KeyEventArgs)
        Select Case e.KeyCode '制御しない場合は何も書かない。
            Case Windows.Forms.Keys.D0 To Windows.Forms.Keys.D9
            Case Windows.Forms.Keys.NumPad0 To Windows.Forms.Keys.NumPad9
            Case Windows.Forms.Keys.Back
            Case Windows.Forms.Keys.Delete
            Case Windows.Forms.Keys.Tab
            Case Windows.Forms.Keys.Up
            Case Windows.Forms.Keys.Down
            Case Windows.Forms.Keys.Left
            Case Windows.Forms.Keys.Right
            Case Windows.Forms.Keys.ShiftKey
            Case Windows.Forms.Keys.Enter '次のコントロールに移動する系はSelectNextControlで制御
                SelectNextControl(sender, True, True, True, False)
            Case Windows.Forms.Keys.Tab '次のコントロールに移動する系はSelectNextControlで制御
                SelectNextControl(sender, True, True, True, False)
            Case Else
                e.SuppressKeyPress = True '制御.そもそも押下できないようになる
        End Select
    End Sub
#End Region

#Region "DataGridView1_CellBeginEdit"
    ''' <summary>
    ''' セルの編集モード開始時にカンマを消去する
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DataGridView1_CellBeginEdit(sender As Object, e As DataGridViewCellCancelEventArgs) Handles DataGridView1.CellBeginEdit
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        '現在のセルのアドレスを取得する(Xは列アドレス,Yは行アドレス)
        Dim dgvCurrentXAddress As Integer = dgv.CurrentCellAddress.X
        Dim dgvCurrentYAddress As Integer = dgv.CurrentCellAddress.Y
        '名前行の場合、Exit Sub
        If dgvCurrentXAddress = 0 Then
            Exit Sub
        End If


        '数値項目のカンマを除去する
        If Not dgv.CurrentCell Is Nothing OrElse
               Not dgv.CurrentCell.Value = String.Empty Then
            dgv.CurrentCell.Value = NumDisplaySwitching(dgv.CurrentCell.Value, False)
        End If

    End Sub
#End Region

#Region "DataGridView1_CellValidated"
    ''' <summary>
    ''' セルの入力チェックを行う
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DataGridView1_CellValidated(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValidated
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)
        '現在のセルのアドレスを取得する(Xは列アドレス,Yは行アドレス)
        Dim dgvCurrentXAddress As Integer = dgv.CurrentCellAddress.X
        Dim dgvCurrentYAddress As Integer = dgv.CurrentCellAddress.Y
        '名前行の場合、Exit Sub
        If dgvCurrentXAddress = 0 Then
            Exit Sub
        End If

        '数値1は空白を許さない(空白を0に置き換える)
        '数値2は空白を許容する
        Select Case dgvCurrentXAddress
            Case 1
                If dgv.CurrentCell.Value = String.Empty Then
                    dgv.CurrentCell.Value = strZero
                End If
        End Select

        '数値2が空白の場合以外は数値を3桁カンマ区切りで表示する
        If dgv.CurrentCell.Value <> String.Empty Then
            dgv.CurrentCell.Value = NumDisplaySwitching(dgv.CurrentCell.Value.ToString, True)
        End If
    End Sub





#End Region

#End Region

#Region "メソッド"

#Region "NumDisplaySwitching"

    ''' <summary>
    ''' 数値項目を表示する際に3桁カンマ区切りにする。
    ''' もしくは数値項目に入力する際にカンマを除去する。
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="NeedComma"></param>
    ''' <returns></returns>
    Private Function NumDisplaySwitching(value As String, NeedComma As Boolean)
        If NeedComma Then
            Return CInt(value).ToString("#,0")
        Else
            Return value.Replace(",", "")
        End If
    End Function

#End Region

#End Region

End Class
