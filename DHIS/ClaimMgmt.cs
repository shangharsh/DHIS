using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DHIS
{
    public static class ClaimMgmt
    {
        //// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        //public class BillablePeriod
        //{
        //    public DateTime start { get; set; }
        //    public DateTime end { get; set; }
        //}

        ////public class Category
        ////{
        ////    public string text { get; set; }
        ////}

        //public class Coding
        //{
        //    public string code { get; set; }
        //    public string system { get; set; }
        //}

        //public class Diagnosis
        //{
        //    public DiagnosisCodeableConcept diagnosisCodeableConcept { get; set; }
        //    public int sequence { get; set; }
        //    public List<Type> type { get; set; }
        //}

        //public class DiagnosisCodeableConcept
        //{
        //    public List<Coding> coding { get; set; }
        //}

        //public class Enterer
        //{
        //    public string reference { get; set; }
        //}

        //public class Facility
        //{
        //    public string reference { get; set; }
        //}

        //public class Identifier
        //{
        //    public Type type { get; set; }
        //    public string use { get; set; }
        //    public string value { get; set; }
        //}

        //public class Item
        //{
        //    //public Category category { get; set; }
        //    public Quantity quantity { get; set; }
        //    public int sequence { get; set; }
        //    public Service service { get; set; }
        //    public UnitPrice unitPrice { get; set; }
        //}

        //public class Patient
        //{
        //    public string reference { get; set; }
        //}

        //public class Quantity
        //{
        //    public int value { get; set; }
        //}

        //public class ClaimPostRequestRoot
        //{
        //    public string resourceType { get; set; }
        //    public BillablePeriod billablePeriod { get; set; }
        //    public DateTime created { get; set; }
        //    public List<Diagnosis> diagnosis { get; set; }
        //    public Enterer enterer { get; set; }
        //    public Facility facility { get; set; }
        //    public string id { get; set; }
        //    public List<Identifier> identifier { get; set; }
        //    public List<Item> item { get; set; }
        //    public Total total { get; set; }
        //    public Patient patient { get; set; }
        //    public Type type { get; set; }
        //}

        //public class Service
        //{
        //    public string text { get; set; }
        //}

        //public class Total
        //{
        //    public double value { get; set; }
        //}

        //public class Type
        //{
        //    public string text { get; set; }
        //    public List<Coding> coding { get; set; }
        //}

        //public class UnitPrice
        //{
        //    public double value { get; set; }
        //}


        public static string SubmitClaim(String apiUrl, String username, String password,string jsonData)
        {
            
            string ReturnValue = "";


            // Create a web request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiUrl);
            request.Method = "POST";
            request.ContentType = "application/json";

            // Add Basic Authentication header
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));
            request.Headers[HttpRequestHeader.Authorization] = "Basic" + credentials;

            // Add custom header
            //request.Headers[headerKey] = headerValue;

            try
            {
                // Write JSON data to the request stream
                using (StreamWriter writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(jsonData);
                    writer.Flush();
                }


                // Get the response
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    // Read the response
                    using (Stream responseStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            string responseJson = reader.ReadToEnd();
                            ReturnValue= responseJson;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle any exceptions
                //Console.WriteLine("Error: " + ex.Message);
                ReturnValue = ex.Message ;
            }
            //if(ReturnValue !="NA")
            //{
            //    //ReturnValue= "Successfully Posted";
            //}
            return ReturnValue ;
        }

   

        public static string GetJsonStringSpecifiedValue(string jsonData, string[] path)
        {
            try
            {
                JObject jsonObject = JObject.Parse(jsonData);
                JToken token = jsonObject;

                foreach (string key in path)
                {
                    token = token[key];
                }

                return token.ToString();

            }
            catch (Exception ex)
            {
                Clipboard.SetText("GetJsonStringSpecifiedValue" + ex.Message);
                MessageBox.Show(ex.Message);
                return jsonData;
            }

           
        }




        //public static string createJsonSubmitString(DataGridView grdServiceList, DataGridView grdPackageView, DataGridView grdDischargeItems, DataGridView itemdataGridView, string APIJSONFormat, string DefaultData)
        //{



        //    int seq = 1;
        //    string[] arrInfo = DefaultData.Split('|');
        //    string[] patuuid = arrInfo[5].Split('/');
        //    // Deserialize the JSON string into a JObject
        //    JObject jsonObject = JObject.Parse(APIJSONFormat);

        //    // Reference to your DataGridView (replace dgvItems with your DataGridView name)
        //    //DataGridView dgvItems = new DataGridView();

        //    // Initialize the 'item' property as a JArray
        //    JArray itemArray = new JArray();

        //    //// Update the 'start', 'end', and 'created' fields
        //    jsonObject["billablePeriod"]["start"] = arrInfo[11]; //DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
        //    jsonObject["billablePeriod"]["end"] = arrInfo[12]; //DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
        //    jsonObject["created"] = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");


        //    // Update the 'diagnosisCodeableConcept', 'enterer', 'facility', 'identifier', and 'patient' fields
        //    jsonObject["diagnosis"][0]["diagnosisCodeableConcept"]["coding"][0]["code"] = arrInfo[0];//"UpdatedDiagnosisCode";
        //    jsonObject["enterer"]["reference"] = arrInfo[1];// "UpdatedPractitionerReference";
        //    jsonObject["facility"]["reference"] = arrInfo[2]; //"UpdatedFacilityReference";

        //    jsonObject["id"] = patuuid[1];
        //    jsonObject["identifier"][0]["value"] = patuuid[1];//arrInfo[3]; for insurance no. patuuid[1] for uuid of patient
        //    jsonObject["identifier"][1]["value"] = arrInfo[4]; //"UpdatedValue2";
        //    jsonObject["patient"]["reference"] = arrInfo[5]; //"UpdatedPatientReference";
        //                                                     //arrInfo[6] for OPD ER Code
        //                                                     //arrInfo[7] for OPDDays Limit Setting Value
        //                                                     // arrInfo[8] Count
        //    jsonObject["information"][0]["valueString"] = arrInfo[13];
        //    jsonObject["nmc"] = arrInfo[13];
        //    jsonObject["careType"] = arrInfo[14];
        //    jsonObject["type"]["text"] = arrInfo[6].Substring(0, 1);


        //    //if (arrInfo[6] == "OPD4")
        //    //{
        //    //    if (Convert.ToInt32(arrInfo[8]) >= Convert.ToInt32(arrInfo[7])) // This is for new OPD only, not follow up for "HospitalSetting Value" days
        //    //    {
        //    //        JObject OPDServiceObject = JObject.FromObject(new
        //    //        {
        //    //            category = new { text = "service" },
        //    //            quantity = new { value = 1 },
        //    //            sequence = seq,
        //    //            service = new { text = arrInfo[6] },
        //    //            unitPrice = new { value = 0.00 }

        //    //        });

        //    //        itemArray.Add(OPDServiceObject);
        //    //    }
        //    //    else if (Convert.ToInt32(arrInfo[8]) == 0) // This is for new OPD only, not follow up for "HospitalSetting Value" days
        //    //    {
        //    //        JObject OPDServiceObject = JObject.FromObject(new
        //    //        {
        //    //            category = new { text = "service" },
        //    //            quantity = new { value = 1 },
        //    //            sequence = seq,
        //    //            service = new { text = arrInfo[6] },
        //    //            unitPrice = new { value = 0.00 }

        //    //        });

        //    //        itemArray.Add(OPDServiceObject);
        //    //    }
        //    //}
        //    //else
        //    //{
        //    //    JObject OPDServiceObject = JObject.FromObject(new
        //    //    {
        //    //        category = new { text = "service" },
        //    //        quantity = new { value = 1 },
        //    //        sequence = seq,
        //    //        service = new { text = arrInfo[6] },
        //    //        unitPrice = new { value = 0.00 }

        //    //    });

        //    //    itemArray.Add(OPDServiceObject);
        //    //}
        //    //seq++;

        //    // Loop through SERVICE DataGridView rows
        ////    if (grdServiceList != null)
        ////        { 
        ////    for (int c = 0; c <= grdServiceList.Rows.Count - 2; c++)
        ////        {

        ////            if (!string.IsNullOrEmpty(grdServiceList.Rows[c].Cells["ServiceCode"].Value.ToString()))
        ////            {
        ////                // Create a JObject for each row
        ////                JObject ServiceObject = JObject.FromObject(new
        ////                {

        ////                    category = new { text = "service" },
        ////                    quantity = new { value = Convert.ToInt32(grdServiceList.Rows[c].Cells["Qty"].Value.ToString()) },
        ////                    sequence = seq,
        ////                    service = new { text = grdServiceList.Rows[c].Cells["ServiceCode"].Value.ToString() },
        ////                    unitPrice = new { value = 0.00 }

        ////                });

        ////                // Add the itemObject to the itemArray
        ////                itemArray.Add(ServiceObject);
        ////            }
        ////            seq++;
        ////        }
        ////}

        //    // Loop through packageSERVICE DataGridView rows

        //    //if (grdPackageView != null)
        //    //{

        //    //    for (int c = 0; c <= grdPackageView.Rows.Count - 2; c++)
        //    //    {
        //    //        if (!string.IsNullOrEmpty(grdPackageView.Rows[c].Cells["InsCode"].Value.ToString()))
        //    //        {
        //    //            // Create a JObject for each row
        //    //            JObject ServiceObject = JObject.FromObject(new
        //    //            {
        //    //                category = new { text = "service" },
        //    //                quantity = new { value = Convert.ToInt32(grdPackageView.Rows[c].Cells["Qty"].Value.ToString()) },
        //    //                sequence = seq,
        //    //                service = new { text = grdPackageView.Rows[c].Cells["InsCode"].Value.ToString() },
        //    //                unitPrice = new { value = 0.00 }

        //    //            });
        //    //            // Add the itemObject to the itemArray
        //    //            itemArray.Add(ServiceObject);
        //    //            seq++;
        //    //        }

        //    //    }
        //    //}

        //    // Loop through grdDischargeItemsSERVICE DataGridView rows

        //    //if (grdDischargeItems != null)
        //    //{

        //    //    for (int c = 0; c <= grdDischargeItems.Rows.Count - 2; c++)
        //    //    {

        //    //        if (!string.IsNullOrEmpty(grdDischargeItems.Rows[c].Cells["ServiceCode"].Value.ToString()))
        //    //        {
        //    //            // Create a JObject for each row
        //    //            JObject ServiceObject = JObject.FromObject(new
        //    //            {

        //    //                category = new { text = "service" },
        //    //                quantity = new { value = Convert.ToInt32(grdDischargeItems.Rows[c].Cells["Qty"].Value.ToString()) },
        //    //                sequence = seq,
        //    //                service = new { text = grdDischargeItems.Rows[c].Cells["ServiceCode"].Value.ToString() },
        //    //                unitPrice = new { value = 0.00 }


        //    //            });


        //    //            // Add the itemObject to the itemArray
        //    //            itemArray.Add(ServiceObject);
        //    //        }
        //    //        seq++;

        //    //    }
        //    //}

        //    // Loop through grdItemList DataGridView rows










        //    for (int c = 0; c <= itemdataGridView.Rows.Count - 2; c++)
        //    {

        //        if (itemdataGridView.Rows[c].Cells["grdInsGenCode"].Value.ToString().Trim() != "" && itemdataGridView.Rows[c].Cells["grdInsGenCode"].Value.ToString().Trim() != "0" && itemdataGridView.Rows[c].Cells["grdRate"].Value.ToString().Trim() != "0")
        //        {
        //            // Create a JObject for each row
        //            JObject ServiceObject = JObject.FromObject(new
        //            {

        //                category = new { text = "item" },
        //                quantity = new { value = Convert.ToInt32(itemdataGridView.Rows[c].Cells["grdQty"].Value.ToString()) },
        //                sequence = seq,
        //                service = new { text = itemdataGridView.Rows[c].Cells["GrdInsGenCode"].Value.ToString() },
        //                unitPrice = new { value = 0.00 }
        //            });

        //            // Add the itemObject to the itemArray
        //            itemArray.Add(ServiceObject);
        //        }
        //        seq++;

        //    }
        //    // Add the itemArray to the 'item' property in the jsonObject
        //    jsonObject["item"] = itemArray;

        //    // Serialize the JObject back to a JSON string
        //    string updatedJsonString = jsonObject.ToString(Formatting.None);
        //    Clipboard.SetText(updatedJsonString);
        //    return updatedJsonString;
        //}


        //public static string createCoPaymentJsonSubmitString(DataGridView grdServiceList, DataGridView grdPackageView, DataGridView grdDischargeItems, DataGridView itemdataGridView, string APIJSONFormat, string DefaultData)
        //{

        //    int seq = 1;
        //    string[] arrInfo = DefaultData.Split('|');
        //    float val = 0.0f;
        //    // Deserialize the JSON string into a JObject
        //    JObject jsonObject = JObject.Parse(APIJSONFormat);

        //    // Reference to your DataGridView (replace dgvItems with your DataGridView name)
        //    //DataGridView dgvItems = new DataGridView();

        //    // Initialize the 'item' property as a JArray
        //    JArray itemArray = new JArray();
        //    JArray ExtArray = new JArray();

        //    //// Update the 'start', 'end', and 'created' fields
        //    jsonObject["billablePeriod"]["start"] = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
        //    jsonObject["billablePeriod"]["end"] = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");
        //    jsonObject["created"] = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

        //    // Update the 'diagnosisCodeableConcept', 'enterer', 'facility', 'identifier', and 'patient' fields
        //    jsonObject["diagnosis"][0]["diagnosisCodeableConcept"]["coding"][0]["code"] = arrInfo[0];//"UpdatedDiagnosisCode";
        //    jsonObject["enterer"]["reference"] = arrInfo[1];// "UpdatedPractitionerReference";
        //    jsonObject["facility"]["reference"] = arrInfo[2]; //"UpdatedFacilityReference";
        //    jsonObject["identifier"][0]["value"] = arrInfo[3]; //"UpdatedValue1";
        //    jsonObject["identifier"][1]["value"] = arrInfo[4]; //"UpdatedValue2";
        //    jsonObject["patient"]["reference"] = arrInfo[5]; //"UpdatedPatientReference";
        //                                                     //arrInfo[6] for OPD ER Code
        //                                                     //arrInfo[7] for OPDDays Limit Setting Value
        //                                                     // arrInfo[8] Count
        //                                                     //arrInfo[9] Co-Pay Status
        //                                                     //arrInfo[10] //OPD/IPD


        //    jsonObject["id"] = arrInfo[5].Split('/')[1].ToString();
        //    jsonObject["type"]["text"] = arrInfo[6].Substring(0, 1);
        //    jsonObject["information"][0]["ValueString"] = arrInfo[10];

        //    if (arrInfo[9].ToLower() == "true")
        //    {
        //        jsonObject["extension"][0]["valueDecimal"] = 0.1;
        //        //jsonObject["extension"]["valueDecimal"] = "0.1";
        //        val = 0.1f;
        //    }
        //    else
        //    {
        //        jsonObject["extension"][0]["valueDecimal"] = 0.0;
        //        val = 0.0f;
        //    }

        //    JObject ExtObject = JObject.FromObject(new
        //    {

        //        url = new { text = "service" },
        //        valueDecimal = new { value = 1 },
        //        valueMoney = seq,
        //        valueString = new { text = arrInfo[6] },
        //        // unitPrice = new { value = 0.00 },




        //    });
        //    ExtArray.Add(ExtObject);
        //    if (arrInfo[6] == "OPD4")
        //    {
        //        if (Convert.ToInt32(arrInfo[8]) >= Convert.ToInt32(arrInfo[7])) // This is for new OPD only, not follow up for "HospitalSetting Value" days
        //        {
        //            JObject OPDServiceObject = JObject.FromObject(new
        //            {
        //                category = new { text = "service" },
        //                quantity = new { value = 1 },
        //                sequence = seq,
        //                service = new { text = arrInfo[6] },
        //                unitPrice = new { value = 0.00 },





        //            });


        //            itemArray.Add(OPDServiceObject);
        //            itemArray.Add(ExtArray["extension"]);

        //        }
        //        else if (Convert.ToInt32(arrInfo[8]) == 0) // This is for new OPD only, not follow up for "HospitalSetting Value" days
        //        {
        //            JObject OPDServiceObject = JObject.FromObject(new
        //            {
        //                category = new { text = "service" },
        //                quantity = new { value = 1 },
        //                sequence = seq,
        //                service = new { text = arrInfo[6] },
        //                unitPrice = new { value = 0.00 },
        //                extension = new { url = "https://hib.gov.np/fhir/FHIE+extension+Copayment+Item+Value", valueDecimal = 0.1, valueMoney = 100.1, valueString = "new extension reason" }


        //            });

        //            itemArray.Add(OPDServiceObject);
        //        }
        //    }
        //    else
        //    {
        //        JObject OPDServiceObject = JObject.FromObject(new
        //        {
        //            category = new { text = "service" },
        //            quantity = new { value = 1 },
        //            sequence = seq,
        //            service = new { text = arrInfo[6] },
        //            unitPrice = new { value = 0.00 },
        //            extension = new { url = "https://hib.gov.np/fhir/FHIE+extension+Copayment+Item+Value", valueDecimal = 0.1, valueMoney = 100.1, valueString = "new extension reason" }

        //        });

        //        itemArray.Add(OPDServiceObject);
        //    }
        //    seq++;

        //    // Loop through SERVICE DataGridView rows
        //    for (int c = 0; c <= grdServiceList.Rows.Count - 2; c++)
        //    {

        //        if (!string.IsNullOrEmpty(grdServiceList.Rows[c].Cells["ServiceCode"].Value.ToString()))
        //        {
        //            // Create a JObject for each row
        //            JObject ServiceObject = JObject.FromObject(new
        //            {

        //                category = new { text = "service" },
        //                quantity = new { value = Convert.ToInt32(grdServiceList.Rows[c].Cells["Qty"].Value.ToString()) },
        //                sequence = seq,
        //                service = new { text = grdServiceList.Rows[c].Cells["ServiceCode"].Value.ToString() },
        //                unitPrice = new { value = 0.00 },
        //                // extension = new { url = "https://hib.gov.np/fhir/FHIE+extension+Copayment+Item+Value", valueDecimal = 0.1, valueMoney = 100.1, valueString = "new extension reason" }

        //            });

        //            // Add the itemObject to the itemArray
        //            itemArray.Add(ServiceObject);
        //            itemArray.Add(ExtArray);
        //        }
        //        seq++;
        //    }


        //    // Loop through packageSERVICE DataGridView rows



        //    for (int c = 0; c <= grdPackageView.Rows.Count - 2; c++)
        //    {
        //        if (!string.IsNullOrEmpty(grdPackageView.Rows[c].Cells["InsCode"].Value.ToString()))
        //        {
        //            // Create a JObject for each row
        //            JObject ServiceObject = JObject.FromObject(new
        //            {
        //                category = new { text = "service" },
        //                quantity = new { value = Convert.ToInt32(grdPackageView.Rows[c].Cells["Qty"].Value.ToString()) },
        //                sequence = seq,
        //                service = new { text = grdPackageView.Rows[c].Cells["InsCode"].Value.ToString() },
        //                unitPrice = new { value = 0.00 },
        //                // extension = new { url = "https://hib.gov.np/fhir/FHIE+extension+Copayment+Item+Value", valueDecimal = 0.1, valueMoney = 100.1, valueString = "new extension reason" }

        //            });
        //            // Add the itemObject to the itemArray
        //            itemArray.Add(ServiceObject);
        //            seq++;
        //        }

        //    }
        //    // Loop through grdDischargeItemsSERVICE DataGridView rows

        //    for (int c = 0; c <= grdDischargeItems.Rows.Count - 2; c++)
        //    {

        //        if (!string.IsNullOrEmpty(grdDischargeItems.Rows[c].Cells["ServiceCode"].Value.ToString()))
        //        {
        //            // Create a JObject for each row
        //            JObject ServiceObject = JObject.FromObject(new
        //            {

        //                category = new { text = "service" },
        //                quantity = new { value = Convert.ToInt32(grdDischargeItems.Rows[c].Cells["Qty"].Value.ToString()) },
        //                sequence = seq,
        //                service = new { text = grdDischargeItems.Rows[c].Cells["ServiceCode"].Value.ToString() },
        //                unitPrice = new { value = 0.00 },
        //                // extension = new { url = "https://hib.gov.np/fhir/FHIE+extension+Copayment+Item+Value", valueDecimal = 0.1, valueMoney = 100.1, valueString = "new extension reason" }


        //            });


        //            // Add the itemObject to the itemArray
        //            itemArray.Add(ServiceObject);
        //        }
        //        seq++;

        //    }

        //    // Loop through grdItemList DataGridView rows

        //    for (int c = 0; c <= itemdataGridView.Rows.Count - 2; c++)
        //    {

        //        if (!string.IsNullOrEmpty(itemdataGridView.Rows[c].Cells["InsGenCode"].Value.ToString().Trim()) || itemdataGridView.Rows[c].Cells["InsGenCode"].Value.ToString().Trim()!="")
        //        {
        //            // Create a JObject for each row
        //            JObject ServiceObject = JObject.FromObject(new
        //            {

        //                category = new { text = "item" },
        //                quantity = new { value = Convert.ToInt32(itemdataGridView.Rows[c].Cells["Qty"].Value.ToString()) },
        //                sequence = seq,
        //                service = new { text = itemdataGridView.Rows[c].Cells["InsGenCode"].Value.ToString() },
        //                unitPrice = new { value = 0.00 },
        //                //  extension = new object { url = "https://hib.gov.np/fhir/FHIE+extension+Copayment+Item+Value", valueDecimal = 0.1, valueMoney = 100.1, valueString = "new extension reason" }
        //            });

        //            // Add the itemObject to the itemArray
        //            itemArray.Add(ServiceObject);
        //        }
        //        seq++;

        //    }
        //    // Add the itemArray to the 'item' property in the jsonObject
        //    jsonObject["item"] = itemArray;

        //    // Serialize the JObject back to a JSON string
        //    string updatedJsonString = jsonObject.ToString(Formatting.None);
        //    Clipboard.SetText(updatedJsonString);
        //    return updatedJsonString;
        //}


    }


}
