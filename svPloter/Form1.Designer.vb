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
        Me.txtFilePath = New System.Windows.Forms.TextBox()
        Me.btnFile = New System.Windows.Forms.Button()
        Me.btnProcess = New System.Windows.Forms.Button()
        Me.tvVrski = New System.Windows.Forms.TreeView()
        Me.SuspendLayout()
        '
        'txtFilePath
        '
        Me.txtFilePath.Location = New System.Drawing.Point(13, 13)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(767, 20)
        Me.txtFilePath.TabIndex = 0
        '
        'btnFile
        '
        Me.btnFile.Location = New System.Drawing.Point(786, 13)
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Size = New System.Drawing.Size(47, 23)
        Me.btnFile.TabIndex = 1
        Me.btnFile.Text = "..."
        Me.btnFile.UseVisualStyleBackColor = True
        '
        'btnProcess
        '
        Me.btnProcess.Location = New System.Drawing.Point(13, 40)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(767, 23)
        Me.btnProcess.TabIndex = 2
        Me.btnProcess.Text = "Process File"
        Me.btnProcess.UseVisualStyleBackColor = True
        '
        'tvVrski
        '
        Me.tvVrski.Location = New System.Drawing.Point(13, 70)
        Me.tvVrski.Name = "tvVrski"
        Me.tvVrski.Size = New System.Drawing.Size(820, 727)
        Me.tvVrski.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(845, 809)
        Me.Controls.Add(Me.tvVrski)
        Me.Controls.Add(Me.btnProcess)
        Me.Controls.Add(Me.btnFile)
        Me.Controls.Add(Me.txtFilePath)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFilePath As System.Windows.Forms.TextBox
    Friend WithEvents btnFile As System.Windows.Forms.Button
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    Friend WithEvents tvVrski As System.Windows.Forms.TreeView

End Class
