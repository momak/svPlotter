Public Class Form1

    Dim svList As List(Of staVrs) = New List(Of staVrs)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnFile.Click
        Dim OpenXML As OpenFileDialog = New OpenFileDialog()

        ' Call ShowDialog.
        OpenXML.InitialDirectory = "C:\Users\Bojan\Documents\Visual Studio 2013\Projects\svPloter" '"D:\"
        OpenXML.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*"

        ' Test result.
        If OpenXML.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ' Get the file name.
            Dim path As String = OpenXML.FileName
            txtFilePath.Text = path

        End If
    End Sub

    Private Sub btnProcess_Click(sender As Object, e As EventArgs) Handles btnProcess.Click

        Dim sVrski As staVrs = New staVrs()
        svList = sVrski.GetList(txtFilePath.Text.Trim)

        tvVrski.Nodes.Clear()

        For Each vrska In isStavkaPodIzvor(svList)

            Dim nodeParent1 As New TreeNode
            nodeParent1.Text = vrska.Stavka
            nodeParent1.ToolTipText = vrska.Kod
            nodeParent1.Name = vrska.Stavka

            If (vrska.Znak = 1) Then
                nodeParent1.ForeColor = Color.Green
            Else
                nodeParent1.ForeColor = Color.Red
            End If
            tvVrski.Nodes.Add(nodeParent1)

            CreateNodes(getVrskiByPodIzvor(vrska), nodeParent1)

        Next


        'Dim nodeParent As New TreeNode
        'nodeParent.Text = svList(0).Stavka
        'nodeParent.ToolTipText = svList(0).Kod
        'nodeParent.Name = svList(0).Stavka

        'If (svList(0).Znak = 1) Then
        '    nodeParent.ForeColor = Color.Green
        'Else
        '    nodeParent.ForeColor = Color.Red
        'End If
        'tvVrski.Nodes.Add(nodeParent)

        'CreateNodes(getVrskiByPodIzvor(svList(0)), nodeParent)

    End Sub

    Private Sub CreateNodes(vrski As List(Of staVrs), parent As TreeNode)

        Try

            For Each vrska As staVrs In vrski

                Dim node As New TreeNode
                Try
                    node.Text = vrska.PodIzvor
                    node.ToolTipText = vrska.Kod
                    node.Name = vrska.PodIzvor
                Catch ex As Exception
                    MessageBox.Show(vrska.Izvor + " " + vrska.PodIzvor + " " + vrska.Kod)
                End Try
                If (vrska.Kod = 1) Then
                    'terminalen element   
                    node.BackColor = Color.Red
                End If

                If (vrska.Znak = 1) Then
                    node.ForeColor = Color.Green
                Else
                    node.ForeColor = Color.Red
                End If
                parent.Nodes.Add(node)

                CreateNodes(getVrskiByStavka(vrska), node)

            Next
        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Function getVrskiByPodIzvor(vrska As staVrs) As List(Of staVrs)

        Dim svRetList As List(Of staVrs) = New List(Of staVrs)

        For Each vrskaL As staVrs In svList

            If (vrskaL.Stavka = vrska.Stavka) Then

                svRetList.Add(vrskaL)

            End If
        Next

        Return svRetList

    End Function

    Private Function getVrskiByStavka(vrska As staVrs) As List(Of staVrs)

        Dim svRetList As List(Of staVrs) = New List(Of staVrs)

        For Each vrskaL As staVrs In svList

            If (vrskaL.Stavka = vrska.PodIzvor) Then

                svRetList.Add(vrskaL)

            End If
        Next

        Return svRetList

    End Function

    Private Function isStavkaPodIzvor(lstVrski As List(Of staVrs)) As List(Of staVrs)

        Dim svRetList As List(Of staVrs) = New List(Of staVrs)


        For Each vrska As staVrs In lstVrski

            If (Not isStavkaChild(vrska, lstVrski) And vrska.Kod <> "1") Then
                svRetList.Add(vrska)
            End If

        Next

        Return svRetList

    End Function


    Private Function isStavkaChild(vrska As staVrs, lstVrski As List(Of staVrs)) As Boolean

        For Each vrskaL As staVrs In svList

            If (vrskaL.PodIzvor = vrska.Stavka) Then
                Return True
            End If
        Next

        Return False


    End Function


End Class
