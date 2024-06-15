Imports Newtonsoft.Json.Linq
Imports System.IO
Imports System.Net
Imports System.Text

Public Class Form4

    'Dim form1 As New Form1()

    Dim dataSetId As String = "" 'UID of Dataset
    Dim todayDate As String = Date.Now().ToString("yyyy-MM-dd") 'Today Date
    Dim period As String = "" 'Eg: 208101 for 2080 Baisakh
    Dim orgUnitId As String = "" 'Eg: Hospital UID
    Dim attributeOptionCombo As String = "" 'Only for ICD11 disease, UID of ICD11 disease

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtOrgUnitId.Text = "BAGHAUDA HOSPTIAL_CHITAWAN"
        ComPeriodId.Enabled = False
        Button1.Enabled = False
        Button2.Enabled = False
        Panel1.Hide()
        Panel2.Hide()
        Panel3.Hide()
        Panel4.Hide()
    End Sub

    Private Sub ComDataSetId_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComDataSetId.SelectedIndexChanged
        ComPeriodId.Enabled = True
        Button1.Enabled = True
        Button2.Enabled = True
    End Sub

    Private Sub ComPeriodId_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComPeriodId.SelectedIndexChanged
        Panel1.Show()
        Panel2.Show()
        Panel3.Show()
        Panel4.Show()
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

        Dim apiUrl = "https://hmis.gov.np/hmisdemo/api/dataValueSets"
        Dim userName = "baghauda.hosp"
        Dim passWord = "Hmis@3344"
        Dim jsonData = "{" &
    """dataSet"": """ & dataSetId & """," &
    """completeDate"": """ & todayDate & """," &
    """period"": """ & period & """," &
    """orgUnit"": """ & orgUnitId & """," &
   " ""attributeOptionCombo"": """"," &
    """dataValues"": [" &
       " {" &
        """dataElement"": ""hE0Kl0AKRKj""," &
"            ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"            ""value"": """ & TextBox1.Text & """," &
"            ""comment"": ""Sanctioned Bed""" &
"        }," &
"        {" &
"            ""dataElement"": ""XSzX9nccK7m""," &
"            ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"            ""value"": """ & TextBox2.Text & """," &
"            ""comment"": ""Operation in-patient bed""" &
"        }," &
"        {" &
"            ""dataElement"": ""hRg33LNWtxu""," &
"            ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"            ""value"": """ & TextBox3.Text & """," &
"            ""comment"": ""Emergency Bed""" &
"        }," &
"        {" &
"            ""dataElement"": ""e7awSzM03vh""," &
"            ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"            ""value"": """ & TextBox4.Text & """," &
"            ""comment"": ""Total Patients Admitted""" &
"        }," &
"        {" &
"            ""dataElement"": ""mVPlNZIq82F""," &
"            ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"            ""value"": """ & TextBox5.Text & """," &
"            ""comment"": ""Total InPatients Days""" &
"        }," &
"        {" &
"            ""dataElement"": ""hcc1X0ZUcwu""," &
"            ""categoryOptionCombo"": ""ye1QuAMRG5Z""," &
"            ""value"": """ & TextBox25.Text & """," &
"            ""comment"": ""Heart Female""" &
"        }," &
"        {" &
"            ""dataElement"": ""hcc1X0ZUcwu""," &
"            ""categoryOptionCombo"": ""PflKpozpO7b""," &
"            ""value"": """ & TextBox26.Text & """," &
"            ""comment"": ""Heart Male""" &
"        }," &
"        {" &
"            ""dataElement"": ""vAedweDY9Ov""," &
"            ""categoryOptionCombo"": ""ye1QuAMRG5Z""," &
"            ""value"": """ & TextBox34.Text & """," &
"            ""comment"": ""Kidney Female""" &
"        }," &
"        {" &
"            ""dataElement"": ""vAedweDY9Ov""," &
"            ""categoryOptionCombo"": ""PflKpozpO7b""," &
"            ""value"": """ & TextBox27.Text & """," &
"            ""comment"": ""Kidney Male""" &
"        }," &
"        {" &
"            ""dataElement"": ""sMadF784Ipm""," &
"            ""categoryOptionCombo"": ""ye1QuAMRG5Z""," &
"            ""value"": """ & TextBox35.Text & """," &
"            ""comment"": ""Cancer Female""" &
"        }," &
"        {" &
"            ""dataElement"": ""sMadF784Ipm""," &
"            ""categoryOptionCombo"": ""PflKpozpO7b""," &
"            ""value"": """ & TextBox28.Text & """," &
"            ""comment"": ""Cancer Male""" &
"        }," &
"        {" &
"            ""dataElement"": ""mepsRa1P7TF""," &
"            ""categoryOptionCombo"": ""ye1QuAMRG5Z""," &
"            ""value"": """ & TextBox36.Text & """," &
"            ""comment"": ""Head Injury Female""" &
"        }," &
"        {" &
"            ""dataElement"": ""mepsRa1P7TF""," &
"            ""categoryOptionCombo"": ""PflKpozpO7b""," &
"            ""value"": """ & TextBox29.Text & """," &
"            ""comment"": ""Head Injury Male""" &
"        }," &
"        {" &
"            ""dataElement"": ""NwwONXCMqqS""," &
"            ""categoryOptionCombo"": ""ye1QuAMRG5Z""," &
"            ""value"": """ & TextBox37.Text & """," &
"            ""comment"": ""Spinal Injury Female""" &
"        }," &
"        {" &
"            ""dataElement"": ""NwwONXCMqqS""," &
"            ""categoryOptionCombo"": ""PflKpozpO7b""," &
"            ""value"": """ & TextBox30.Text & """," &
"            ""comment"": ""Spinal Injury Male""" &
"        }," &
"        {" &
"            ""dataElement"": ""wrUj1hRMeRR""," &
"            ""categoryOptionCombo"": ""ye1QuAMRG5Z""," &
"            ""value"": """ & TextBox38.Text & """," &
"            ""comment"": ""Alzheimer Injury Female""" &
"        }," &
"        {" &
"            ""dataElement"": ""wrUj1hRMeRR""," &
"            ""categoryOptionCombo"": ""PflKpozpO7b""," &
"            ""value"": """ & TextBox31.Text & """," &
"            ""comment"": ""Alzheimer Injury Male""" &
"        }," &
"        {" &
"            ""dataElement"": ""lZRVWKdFWUz""," &
"            ""categoryOptionCombo"": ""ye1QuAMRG5Z""," &
"            ""value"": """ & TextBox39.Text & """," &
"            ""comment"": ""Parkinson Injury Female""" &
"        }," &
"        {" &
"            ""dataElement"": ""lZRVWKdFWUz""," &
"            ""categoryOptionCombo"": ""PflKpozpO7b""," &
"            ""value"": """ & TextBox32.Text & """," &
"            ""comment"": ""Parkinson Injury Male""" &
"        }," &
"        {" &
"            ""dataElement"": ""P75PjLQQwYx""," &
"            ""categoryOptionCombo"": ""ye1QuAMRG5Z""," &
"            ""value"": """ & TextBox40.Text & """," &
"            ""comment"": ""Sickle Cell Anaemia Female""" &
"        }," &
"        {" &
"            ""dataElement"": ""P75PjLQQwYx""," &
"            ""categoryOptionCombo"": ""PflKpozpO7b""," &
"            ""value"": """ & TextBox33.Text & """," &
"            ""comment"": ""Sickle Cell Anaemia Male""" &
"        }," &
"        {" &
"            ""dataElement"": ""yUNjmhz0j9s""," &
"            ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"            ""value"": """ & TextBox41.Text & """," &
"            ""comment"": ""PHC OutReach Clinic---Planned/Total No.""" &
"        }," &
"        {" &
"            ""dataElement"": ""BG55tDKF0np""," &
"            ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"            ""value"": """ & TextBox42.Text & """," &
"            ""comment"": ""PHC OutReach Clinic---Conducted/Report Received""" &
"        }," &
"        {" &
"            ""dataElement"": ""bKTB9K7u6DS""," &
"            ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"            ""value"": """ & TextBox43.Text & """," &
"            ""comment"": ""PHC OutReach Clinic---No. of Client Served""" &
"        }," &
"        {" &
"            ""dataElement"": ""sBAeCFmRvOG""," &
"            ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"            ""value"": """ & TextBox52.Text & """," &
"            ""comment"": ""Immunization Clinic---Planned/ Total No.""" &
"        }," &
"        {" &
"            ""dataElement"": ""w7FmV7f1Rcn""," &
"            ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"            ""value"": """ & TextBox51.Text & """," &
"            ""comment"": ""Immunization Clinic---Conducted/Report Received""" &
"        }," &
"        {" &
"            ""dataElement"": ""TEdItLSOdos""," &
"            ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"            ""value"": """ & TextBox44.Text & """," &
"            ""comment"": ""Immunization Clinic + Immunization Session---No. of Clients Served""" &
"        }," &
"        {" &
"            ""dataElement"": ""e0HZBrBDfpg""," &
"            ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"            ""value"": """ & TextBox53.Text & """," &
"            ""comment"": ""Immunization Session---Planned/ Total No.""" &
"        }," &
"        {" &
"            ""dataElement"": ""BF7zguwOCqE""," &
"            ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"            ""value"": """ & TextBox50.Text & """," &
"            ""comment"": ""Immunization Session---Conducted/Report Received""" &
"        }," &
"        {" &
"            ""dataElement"": ""IY9MMZYW2Td""," &
"            ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"            ""value"": """ & TextBox54.Text & """," &
"            ""comment"": ""Hygiene Promotion Sessions---Planned/ Total No.""" &
"        }," &
"        {" &
"            ""dataElement"": ""K8inoFQdq06""," &
"            ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"            ""value"": """ & TextBox49.Text & """," &
"            ""comment"": ""Hygiene Promotion Sessions---Conducted/Report Received""" &
"        }," &
"        {" &
"            ""dataElement"": ""Jy09iroElNr""," &
"            ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"            ""value"": """ & TextBox46.Text & """," &
"            ""comment"": ""Hygiene Promotion Session---No of Clients Served""" &
"        }," &
"        {" &
"            ""dataElement"": ""CfKB0tK9q3M""," &
"            ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"            ""value"": """ & TextBox55.Text & """," &
"            ""comment"": ""FCHV---Planned Total No.""" &
"        }," &
"        {" &
"            ""dataElement"": ""Lix74hdpuwt""," &
"            ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"            ""value"": """ & TextBox48.Text & """," &
"            ""comment"": ""FCHV---Conducted/Report Received""" &
"        }," &
"        {" &
"            ""dataElement"": ""GvdBFMcPVox""," &
"            ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"            ""value"": """ & TextBox47.Text & """," &
"            ""comment"": ""FCHV---No of Clients Served""" &
"        }," &
"        {" &
"            ""dataElement"": ""RXIa0TIoAP4""," &
"            ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"            ""value"": """ & TextBox6.Text & """," &
"            ""comment"": ""X-ray Number""" &
"        }," &
"        {" &
"            ""dataElement"": ""Hy2ikWKzAUh""," &
"            ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"            ""value"": """ & TextBox7.Text & """," &
"            ""comment"": ""USG-Number""" &
"        }," &
"        " &
"        {" &
"            ""dataElement"": ""gglzlE7oJpI""," &
"            ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"            ""value"": """ & TextBox8.Text & """," &
"            ""comment"": ""Echo-Number""" &
"        }," &
"        {" &
"            ""dataElement"": ""yVhL13Rc3Gw""," &
"            ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"            ""value"": """ & TextBox9.Text & """," &
"            ""comment"": ""EEG-Number""" &
"        }," &
"        {" &
"    ""dataElement"": ""HXPj1cIqZIC""," &
"    ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"    ""value"": """ & TextBox24.Text & """," &
"    ""comment"": ""ECG-Number"" " &
"}," &
"{" &
"    ""dataElement"": ""aBbZ4GirNpN""," &
"    ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"    ""value"": """ & TextBox10.Text & """," &
"    ""comment"": ""TreadMill"" " &
"}," &
"{" &
"    ""dataElement"": ""zQnc9f0Gq8Z""," &
"    ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"    ""value"": """ & TextBox11.Text & """," &
"    ""comment"": ""CT-Scan"" " &
"}," &
"{" &
"    ""dataElement"": ""gT5hXh5IQ8Y""," &
"    ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"    ""value"": """ & TextBox23.Text & """," &
"    ""comment"": ""MRI-Number"" " &
"}," &
"{" &
"    ""dataElement"": ""rU9EUoLmd1K""," &
"    ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"    ""value"": """ & TextBox12.Text & """," &
"    ""comment"": ""Endoscopy-Persons"" " &
"}," &
"{" &
"    ""dataElement"": ""CUrV07L8274""," &
"    ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"    ""value"": """ & TextBox45.Text & """," &
"    ""comment"": ""Colonoscopy-Persons"" " &
"}," &
"{" &
"    ""dataElement"": ""Ly477FanXE3""," &
"    ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"    ""value"": """ & TextBox13.Text & """," &
"    ""comment"": ""Bronchoscopy-Persons"" " &
"}," &
"{" &
"    ""dataElement"": ""d7xsrk6ZliX""," &
"    ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"    ""value"": """ & TextBox14.Text & """," &
"    ""comment"": ""Nuclear Medicine-Persons"" " &
"}," &
"{" &
"    ""dataElement"": ""vigLadIlROn""," &
"    ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"    ""value"": """ & TextBox15.Text & """," &
"    ""comment"": ""Mammogram-Persons"" " &
"}," &
"{" &
"    ""dataElement"": ""ztdpCtP5eOM""," &
"    ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"    ""value"": """ & TextBox16.Text & """," &
"    ""comment"": ""Cystoscopy-Persons"" " &
"}," &
"{" &
"    ""dataElement"": ""F8mMHpJm9cd""," &
"    ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"    ""value"": """ & TextBox17.Text & """," &
"    ""comment"": ""Dexa Scan-Persons"" " &
"}," &
"{" &
"    ""dataElement"": ""TbGgV5AODKc""," &
"    ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"    ""value"": """ & TextBox22.Text & """," &
"    ""comment"": ""DTPA Scan-Persons"" " &
"}," &
"{" &
"    ""dataElement"": ""ctyxkCUBEbX""," &
"    ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"    ""value"": """ & TextBox18.Text & """," &
"    ""comment"": ""ECT-Persons"" " &
"}," &
"{" &
"    ""dataElement"": ""ScWyls97aqY""," &
"    ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"    ""value"": """ & TextBox19.Text & """," &
"    ""comment"": ""TMS-Persons"" " &
"}," &
"{" &
"    ""dataElement"": ""UTJQ3DnKBGP""," &
"    ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"    ""value"": """ & TextBox20.Text & """," &
"    ""comment"": ""Total laboratory Services Provided-Persons"" " &
"}," &
"{" &
"    ""dataElement"": ""sFkotLeU4nk""," &
"    ""categoryOptionCombo"": ""kdsirVNKdhm""," &
"    ""value"": """ & TextBox21.Text & """," &
"    ""comment"": ""Other(if any)-Persons"" " &
"}" &
"    ]" &
"}"


        Dim response = SubmitData(apiUrl, userName, passWord, jsonData)
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