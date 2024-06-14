Imports System.IO
Imports System.Net
Imports System.Text

Imports System.Net.Http
Imports System.Threading.Tasks
Imports Newtonsoft.Json.Linq
Imports System.Windows.Forms.VisualStyles.VisualStyleElement




Public Class Form1

    Dim dataSetId As String = "" 'UID of Dataset
    Dim todayDate As String = Date.Now().ToString("yyyy-MM-dd") 'Today Date
    Dim period As String = "" 'Eg: 208101 for 2080 Baisakh
    Dim orgUnitId As String = "" 'Eg: Hospital UID
    Dim attributeOptionCombo As String = "" 'Only for ICD11 disease, UID of ICD11 disease

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtOrgUnitId.Text = "BAGHAUDA HOSPTIAL_CHITAWAN"
        ComPeriodId.Enabled = False
        Button1.Enabled = False
        Button2.Enabled = False
        Panel.Hide()
        Label5.Hide()
    End Sub

    Private Sub ComDataSetId_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComDataSetId.SelectedIndexChanged
        ComPeriodId.Enabled = True
        Button1.Enabled = True
        Button2.Enabled = True

    End Sub

    Private Sub ComPeriodId_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComPeriodId.SelectedIndexChanged
        Panel.Show()
        Label5.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ComDataSetId.SelectedItem = "01-2 Hospital Summary Dataset(NEW)" Then
            dataSetId = "CjuEkVeLgsT"
        End If
        If TxtOrgUnitId.Text = "BAGHAUDA HOSPTIAL_CHITAWAN" Then
            orgUnitId = "aUv4lHwAFh9"
        End If
        If ComPeriodId.SelectedItem = "Baishak 2081" Then
            period = "208101"
        ElseIf ComPeriodId.SelectedItem = "Jestha 2081" Then
            period = "208102"
        End If


        Dim apiUrl As String = "https://hmis.gov.np/hmisdemo/api/dataValueSets"
        Dim userName As String = "baghauda.hosp"
        Dim passWord As String = "Hmis@3344"

        Dim jsonData As String = "{" &
    """dataSet"": ""CjuEkVeLgsT""," &
    """completeDate"": """ & todayDate & """," &
    """period"": """ & period & """," &
    """orgUnit"": ""aUv4lHwAFh9""," &
    """attributeOptionCombo"": """"," &
    """dataValues"": [" &
    "    {" &
    "        ""dataElement"": ""HscG3R78Jzc""," &
    "        ""categoryOptionCombo"": ""I1gylzOskBs""," &
    "        ""value"": """ & TextBox2.Text & """," &
    "        ""comment"": ""Hospital Services--New Clients Served Female Age Group 0-9 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""HscG3R78Jzc""," &
    "        ""categoryOptionCombo"": ""TTNFd2X49S6""," &
    "        ""value"": """ & TextBox3.Text & """," &
    "        ""comment"": ""Male Age Group 0-9 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""HscG3R78Jzc""," &
    "        ""categoryOptionCombo"": ""ciTvZ1HjQTw""," &
    "        ""value"": """ & TextBox4.Text & """," &
    "        ""comment"": ""Female Age Group 10-14 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""HscG3R78Jzc""," &
    "        ""categoryOptionCombo"": ""SDgsEKTs0IH""," &
    "        ""value"": """ & TextBox5.Text & """," &
    "        ""comment"": ""Male Age Group 10-14 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""HscG3R78Jzc""," &
    "        ""categoryOptionCombo"": ""RnH2ZpATWSI""," &
    "        ""value"": """ & TextBox10.Text & """," &
    "        ""comment"": ""Female Age Group 15-19 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""HscG3R78Jzc""," &
    "        ""categoryOptionCombo"": ""ffNSZ7u5Y5P""," &
    "        ""value"": """ & TextBox6.Text & """," &
    "        ""comment"": ""Male Age Group 15-19 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""HscG3R78Jzc""," &
    "        ""categoryOptionCombo"": ""sfmUgn8yywu""," &
    "        ""value"": """ & TextBox11.Text & """," &
    "        ""comment"": ""Female Age Group 20-59 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""HscG3R78Jzc""," &
    "        ""categoryOptionCombo"": ""iUcXHCikw4W""," &
    "        ""value"": """ & TextBox7.Text & """," &
    "        ""comment"": ""Male Age Group 20-59 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""HscG3R78Jzc""," &
    "        ""categoryOptionCombo"": ""COAFy42YNLg""," &
    "        ""value"": """ & TextBox12.Text & """," &
    "        ""comment"": ""Female Age Group 60-69 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""HscG3R78Jzc""," &
    "        ""categoryOptionCombo"": ""D7tJYC2XYrC""," &
    "        ""value"": """ & TextBox8.Text & """," &
    "        ""comment"": ""Male Age Group 60-69 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""HscG3R78Jzc""," &
    "        ""categoryOptionCombo"": ""M0yrPwi8vEK""," &
    "        ""value"": """ & TextBox13.Text & """," &
    "        ""comment"": ""Female Age Group >=70 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""HscG3R78Jzc""," &
    "        ""categoryOptionCombo"": ""DYUdGTQhgf9""," &
    "        ""value"": """ & TextBox9.Text & """," &
    "        ""comment"": ""Male Age Group >=70 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""XjuXeaVPUsr""," &
    "        ""categoryOptionCombo"": ""I1gylzOskBs""," &
    "        ""value"": """ & TextBox14.Text & """," &
    "        ""comment"": ""Hospital Services--Total Clients Served Female Age Group 0-9 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""XjuXeaVPUsr""," &
    "        ""categoryOptionCombo"": ""TTNFd2X49S6""," &
    "        ""value"": """ & TextBox15.Text & """," &
    "        ""comment"": ""Male Age Group 0-9 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""XjuXeaVPUsr""," &
    "        ""categoryOptionCombo"": ""ciTvZ1HjQTw""," &
    "        ""value"": """ & TextBox25.Text & """," &
    "        ""comment"": ""Female Age Group 10-14 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""XjuXeaVPUsr""," &
    "        ""categoryOptionCombo"": ""SDgsEKTs0IH""," &
    "        ""value"": """ & TextBox16.Text & """," &
    "        ""comment"": ""Male Age Group 10-14 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""XjuXeaVPUsr""," &
    "        ""categoryOptionCombo"": ""RnH2ZpATWSI""," &
    "        ""value"": """ & TextBox24.Text & """," &
    "        ""comment"": ""Female Age Group 15-19 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""XjuXeaVPUsr""," &
    "        ""categoryOptionCombo"": ""ffNSZ7u5Y5P""," &
    "        ""value"": """ & TextBox17.Text & """," &
    "        ""comment"": ""Male Age Group 15-19 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""XjuXeaVPUsr""," &
    "        ""categoryOptionCombo"": ""sfmUgn8yywu""," &
    "        ""value"": """ & TextBox23.Text & """," &
    "        ""comment"": ""Female Age Group 20-59 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""XjuXeaVPUsr""," &
    "        ""categoryOptionCombo"": ""iUcXHCikw4W""," &
    "        ""value"": """ & TextBox18.Text & """," &
    "        ""comment"": ""Male Age Group 20-59 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""XjuXeaVPUsr""," &
    "        ""categoryOptionCombo"": ""COAFy42YNLg""," &
    "        ""value"": """ & TextBox22.Text & """," &
    "        ""comment"": ""Female Age Group 60-69 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""XjuXeaVPUsr""," &
    "        ""categoryOptionCombo"": ""D7tJYC2XYrC""," &
    "        ""value"": """ & TextBox19.Text & """," &
    "        ""comment"": ""Male Age Group 60-69 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""XjuXeaVPUsr""," &
    "        ""categoryOptionCombo"": ""M0yrPwi8vEK""," &
    "        ""value"": """ & TextBox21.Text & """," &
    "        ""comment"": ""Female Age Group >=70 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""XjuXeaVPUsr""," &
    "        ""categoryOptionCombo"": ""DYUdGTQhgf9""," &
    "        ""value"": """ & TextBox20.Text & """," &
    "        ""comment"": ""Male Age Group >=70 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""fuHbV1eiKs0""," &
    "        ""categoryOptionCombo"": ""ye1QuAMRG5Z""," &
    "        ""value"": """ & TextBox26.Text & """," &
    "        ""comment"": ""Emergency Services--Total Clients Served Female Age Group 0-9 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""fuHbV1eiKs0""," &
    "        ""categoryOptionCombo"": ""PflKpozpO7b""," &
    "        ""value"": """ & TextBox27.Text & """," &
    "        ""comment"": ""Male Age Group 0-9 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""qQ8UCWW6YUs""," &
    "        ""categoryOptionCombo"": ""ye1QuAMRG5Z""," &
    "        ""value"": """ & TextBox33.Text & """," &
    "        ""comment"": ""Female Age Group 10-14 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""qQ8UCWW6YUs""," &
    "        ""categoryOptionCombo"": ""PflKpozpO7b""," &
    "        ""value"": """ & TextBox28.Text & """," &
    "        ""comment"": ""Male Age Group 10-14 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""SbdW0pjvph3""," &
    "        ""categoryOptionCombo"": ""ye1QuAMRG5Z""," &
    "        ""value"": """ & TextBox34.Text & """," &
    "        ""comment"": ""Female Age Group 15-19 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""SbdW0pjvph3""," &
    "        ""categoryOptionCombo"": ""PflKpozpO7b""," &
    "        ""value"": """ & TextBox29.Text & """," &
    "        ""comment"": ""Male Age Group 15-19 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""CLYbMAU5lhD""," &
    "        ""categoryOptionCombo"": ""ye1QuAMRG5Z""," &
    "        ""value"": """ & TextBox35.Text & """," &
    "        ""comment"": ""Female Age Group 20-59 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""CLYbMAU5lhD""," &
    "        ""categoryOptionCombo"": ""PflKpozpO7b""," &
    "        ""value"": """ & TextBox30.Text & """," &
    "        ""comment"": ""Male Age Group 20-59 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""GaDfMW8NKGd""," &
    "        ""categoryOptionCombo"": ""ye1QuAMRG5Z""," &
    "        ""value"": """ & TextBox36.Text & """," &
    "        ""comment"": ""Female Age Group 60-69 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""GaDfMW8NKGd""," &
    "        ""categoryOptionCombo"": ""PflKpozpO7b""," &
    "        ""value"": """ & TextBox31.Text & """," &
    "        ""comment"": ""Male Age Group 60-69 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""jXzZ2AFEqgP""," &
    "        ""categoryOptionCombo"": ""ye1QuAMRG5Z""," &
    "        ""value"": """ & TextBox37.Text & """," &
    "        ""comment"": ""Female Age Group >=70 Years""" &
    "    }," &
    "    {" &
    "        ""dataElement"": ""jXzZ2AFEqgP""," &
    "        ""categoryOptionCombo"": ""PflKpozpO7b""," &
    "        ""value"": """ & TextBox32.Text & """," &
    "        ""comment"": ""Male Age Group >=70 Years""" &
    "    }" &
    "]" &
"}"

        Dim response As String = SubmitData(apiUrl, userName, passWord, jsonData)
        'MsgBox(response)
    End Sub

    Public Shared Function SubmitData(ByVal apiUrl As String, ByVal username As String, ByVal password As String, ByVal jsonData As String) As String
        Dim ReturnValue As String = ""
        Dim request As HttpWebRequest = CType(WebRequest.Create(apiUrl), HttpWebRequest)
        request.Method = "POST"
        request.ContentType = "application/json"
        Dim credentials As String = Convert.ToBase64String(Encoding.ASCII.GetBytes(username & ":" + password))
        request.Headers(HttpRequestHeader.Authorization) = "Basic " & credentials

        Try

            Using writer As StreamWriter = New StreamWriter(request.GetRequestStream())
                writer.Write(jsonData)
                writer.Flush()
            End Using

            Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)

                Using responseStream As Stream = response.GetResponseStream()

                    Using reader As StreamReader = New StreamReader(responseStream)
                        Dim responseJson As String = reader.ReadToEnd()
                        Dim responseObject As Object = JObject.Parse(responseJson)
                        Dim status As String = responseObject("status").ToString()
                        MsgBox(status)

                    End Using
                End Using
            End Using

        Catch ex As WebException
            ReturnValue = ex.Message
            MsgBox(ReturnValue)

        End Try

        Return ReturnValue

    End Function


End Class