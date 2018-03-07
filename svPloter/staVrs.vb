Imports System.Xml

Public Class staVrs

    Private _stavka As String
    Public Property Stavka() As String
        Get
            Return _stavka
        End Get
        Set(value As String)
            _stavka = value
        End Set
    End Property

    Private _podIzvor As String
    Public Property PodIzvor() As String
        Get
            Return _podIzvor
        End Get
        Set(value As String)
            _podIzvor = value
        End Set
    End Property

    'Private _osnov As String
    'Public Property Osnov() As String
    '    Get
    '        Return _osnov
    '    End Get
    '    Set(value As String)
    '        _osnov = value
    '    End Set
    'End Property

    Private _izvor As Integer
    Public Property Izvor() As Integer
        Get
            Return _izvor
        End Get
        Set(value As Integer)
            _izvor = value
        End Set
    End Property

    Private _znak As Integer
    Public Property Znak() As Integer
        Get
            Return _znak
        End Get
        Set(value As Integer)
            _znak = value
        End Set
    End Property

    Private _kod As Integer
    Public Property Kod() As Integer
        Get
            Return _kod
        End Get
        Set(value As Integer)
            _kod = value
        End Set
    End Property


    Public Sub New()
    End Sub

    Public Sub New(ByVal stv As String, ByVal pIzv As String, ByVal izv As Integer, ByVal znk As Integer, ByVal kd As Integer)

        Stavka = stv
        PodIzvor = pIzv
        'Osnov = osn
        Izvor = izv
        Znak = znk
        Kod = kd

    End Sub


    Public Function GetList(ByVal filePath As String) As List(Of staVrs)
        Dim list As New List(Of staVrs)()

        Dim doc As New XmlDocument()
        doc.Load(filePath)

        Dim root As XmlNode = doc.SelectSingleNode("//Vrski")
        Dim nodeList As XmlNodeList = root.SelectNodes("Vrska")

        For Each n As XmlNode In nodeList
            Dim _sVrs As New staVrs()

            _sVrs.Stavka = n.SelectSingleNode("Stavka").InnerText
            _sVrs.PodIzvor = n.SelectSingleNode("podIzvor").InnerText
            '_sVrs.Osnov = n.SelectSingleNode("Osnov").InnerText
            '_sVrs.Izvor = Convert.ToInt32(n.SelectSingleNode("Izvor").InnerText)
            _sVrs.Znak = 1'Convert.ToInt32(n.SelectSingleNode("Znak").InnerText)
            _sVrs.Kod = Convert.ToInt32(n.SelectSingleNode("Kod").InnerText)

            list.Add(_sVrs)
        Next
        Return list
    End Function

End Class
