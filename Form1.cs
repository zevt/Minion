using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Documents;
using Outlook = Microsoft.Office.Interop.Outlook;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;



namespace Minion
{
    public partial class FormMinion : Form
    {
        const string iPhone_standard_old = "iPhone 4, 4S 5 out of contract";
        const string iPhone_standard_new = "iPhone 5c, 5s out of contract";
        const string iPhone_premium_old = "iPhone 4, 4S 5 premium";
        const string iPhone_premium_new = "iPhone 5c, 5s premium";
        const string iPhone_express = "iPhone express";
        const string strSamsungWebGross = "26";
        const string strSamsungEBayGross = "28";

        const string strG1 = "44";
        const string strG2 = "54";
        const string strG3 = "64";
        const string strG4 = "99";
        const string strG5 = "115";

        const int iDate = 1;
        const int iTime = 2;
        const int iName = 3;
        const int iEbayID = 4;
        const int iEmail = 5;
        const int iGross = 6;
        const int iIMEI = 7;
        const int iCode = 8;
        const int iDelivered = 9;
        const string strCodeUnavailable = "Processing";
        const string ConfigFile = "config.txt";
        const string strYes = "Yes";
        const string strNo = "No";
        public FormMinion()
        {
            InitializeComponent();
        }

        private void button_DataFile_Click(object sender, EventArgs e)
        {
            if (openFileDialogData.ShowDialog() == DialogResult.OK)
            {
                tbDataFilePath.Text = openFileDialogData.FileName;
                SaveConfiguration();
            }
        }

        private void buttonExecute_Click(object sender, EventArgs e)
        {
            // Prepare lists of data to display in rich text boxes
            List<string> FullSamsungOrderList = new List<string>();  // Store Samsung order (Email, ID, IMEI)
            List<string> IMEISamsungOrderList = new List<string>();   // Store only IMEI
            List<string> FulliPhoneOrderList = new List<string>(); //Store all iPhone order (Email, IMEI, Gorss)
            List<string>[] iPhoneIMEIList = new List<string>[5];
            // index for type of iPhone order by gross
            int G1, G2, G3, G4, G5;
            int index = 0;
            G1 = index++; G2 = index++; G3 = index++; G4 = index++; G5 = index;
            for (index = 0; index < 5; ++index)
            {
                iPhoneIMEIList[index] = new List<string>();
            }
            RegexUltilities ulti = new RegexUltilities();
            string Datafile = tbDataFilePath.Text;
            Excel.Application DataApp = DataApp = new Excel.Application();
            DataApp.Visible = false;
            Excel.Workbook DataBook = DataApp.Workbooks.Open(Datafile);
            Excel.Worksheet DataSheet = (Excel.Worksheet)DataBook.Sheets[1];
            //Excel.Worksheet DataSheet = (Excel.Worksheet)DataBook.Sheets.get_Item(1);
            int iRow = DataSheet.UsedRange.Rows.Count;
            int iCol = DataSheet.UsedRange.Columns.Count;
            System.Array DataValues = null;
            Excel.Range range;
            // Move the last row up to the first line that has actual data
            range = DataSheet.get_Range("A" + iRow.ToString(), "X" + iRow.ToString());
            DataValues = (System.Array)range.Cells.Value;
            while (DataValues.GetValue(1, 1) == null && iRow > 1)
            {
                --iRow;
                range = DataSheet.get_Range("A" + iRow.ToString(), "X" + iRow.ToString());
                DataValues = (System.Array)range.Cells.Value;
            }
            if (iRow == 1) // Data file contains only header line
            {
                MessageBox.Show("File " + Datafile + " contains only header line");
                DataBook.Close();
                return;
            }
            // Get Data from excel file and set to Array of string named DataValues
            range = DataSheet.get_Range("A" + "1", "X" + iRow.ToString());
            DataValues = (System.Array)range.Cells.Value;

            #region
            // Get indexes of all caption of the output filtered data excel file
            int indexName, indexEmail, indexGross, indexNote, indexEBayID, indexiPhoneIMEI, indexSamsungIMEI;
            int indexDate, indexTime;
            indexName = indexEmail = indexGross = indexNote = indexEBayID = indexiPhoneIMEI = indexSamsungIMEI = 1;
            indexDate = indexTime = 1;
            while (!((string)DataValues.GetValue(1, indexName)).Contains("Name"))
            {
                ++indexName;
            }
            while (!((string)DataValues.GetValue(1, indexEmail)).Contains("From Email Address"))
            {
                ++indexEmail;
            }
            while (!((string)DataValues.GetValue(1, indexGross)).Contains("Gross"))
            {
                ++indexGross;
            }
            while (!((string)DataValues.GetValue(1, indexNote)).Contains("Note"))
            {
                ++indexNote;
            }
            while (!((string)DataValues.GetValue(1, indexEBayID)).Contains("Buyer ID"))
            {
                ++indexEBayID;
            }
            while (!((string)DataValues.GetValue(1, indexiPhoneIMEI)).Contains("Option 2 Value"))
            {
                ++indexiPhoneIMEI;
            }
            while (!((string)DataValues.GetValue(1, indexSamsungIMEI)).Contains("Option 1 Value"))
            {
                ++indexSamsungIMEI;
            }
            while (!((string)DataValues.GetValue(1, indexDate)).Contains("Date"))
            {
                ++indexDate;
            }
            while (!((string)DataValues.GetValue(1, indexTime)).Contains("Time"))
            {
                ++indexTime;
            }
            #endregion
            // Open or create output excel file for filtered data
            int i, j;
            //iCol = DataValues.GetLength(1);
            // Create a excel file to write filtered data in it
            string PurifiedDataFilename = tbFilteredDataFilePath.Text;
            Excel.Application FilterDataApp = new Excel.Application();
            FilterDataApp.Visible = false;
            Excel.Workbook FilterDataBook;
            Excel.Worksheet FilterDataSheet;
            // Prepare caption indexes for output excel file of filtered data
            index = 1;
            bool FirstTimECreated;

            if (!System.IO.File.Exists(PurifiedDataFilename))  // Create file PurifedData.xlsx if not exist
            {
                FirstTimECreated = true;
                FilterDataBook = FilterDataApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
                FilterDataSheet = (Excel.Worksheet)FilterDataBook.Worksheets[1];
                FilterDataSheet.Cells[1, iDate] = "Date";
                FilterDataSheet.Cells[1, iTime] = "Time";
                FilterDataSheet.Cells[1, iName] = "Name";
                FilterDataSheet.Cells[1, iEmail] = "Email";
                FilterDataSheet.Cells[1, iEbayID] = "Ebay ID";
                FilterDataSheet.Cells[1, iGross] = "Gross";
                FilterDataSheet.Cells[1, iIMEI] = "IMEI";
                FilterDataSheet.Cells[1, iCode] = "Unlock Code";
                FilterDataSheet.Cells[1, iDelivered] = "Delivered";
            }
            else  // Open if PurifedData.xlsx already exists
            {
                FirstTimECreated = false;
                FilterDataBook = FilterDataApp.Workbooks.Open(PurifiedDataFilename);
                FilterDataSheet = (Excel.Worksheet)FilterDataBook.Worksheets[1];
            }

            int LastRow = FilterDataSheet.UsedRange.Rows.Count;
            // Reduce LastRow until it has actual data
            FilterDataApp.Visible = false;
            string strDate;
            string strTime;
            const string MissingIMEI = "Missing";

            if (LastRow > 1) // has at least 1 or more data line than header line
            {
                Array LastRowData;
                Excel.Range lrdRange;
                // Move to line that has actual data from bottom
                lrdRange = FilterDataSheet.get_Range("A" + LastRow.ToString(), "D" + LastRow.ToString());
                LastRowData = (System.Array)lrdRange.Cells.Value;
                while (LastRowData.GetValue(1, iDate) == null)
                {
                    --LastRow;
                    lrdRange = FilterDataSheet.get_Range("A" + LastRow.ToString(), "D" + LastRow.ToString());
                    LastRowData = (System.Array)lrdRange.Cells.Value;
                }
                if (LastRow > 1) // Filtered Data file has 1 or more actual data line than just header
                {
                    DateTime lastupdatePoint, currentRowDate;
                    // At this point, iRow is the last row of data file that contains actual data line
                    ++iRow;
                    string strLastPointDate = LastRowData.GetValue(1, iDate).ToString();
                    string strLastPointTime = LastRowData.GetValue(1, iTime).ToString();
                    // Convert string date and time to lastupdatepoint.
                    lastupdatePoint = DateTime.Parse(strLastPointDate);
                    lastupdatePoint = lastupdatePoint.Add(TimeSpan.FromSeconds(double.Parse(strLastPointTime) * 3600 * 24));
                    currentRowDate = lastupdatePoint.Add(TimeSpan.FromSeconds(-100.0));
                    // Match to the first line in Data file that hasn't been passed to filtered file yet
                    do
                    {
                        --iRow;
                        if (iRow == 1) continue; // break;

                        strDate = DataValues.GetValue(iRow, indexDate).ToString();
                        strTime = DataValues.GetValue(iRow, indexTime).ToString();
                        // Get date and time from last row of Filter data
                        currentRowDate = DateTime.Parse(strDate);
                        currentRowDate = currentRowDate.Add(TimeSpan.FromSeconds(double.Parse(strTime) * 3600 * 24));
                    }
                    while (DateTime.Compare(lastupdatePoint, currentRowDate) >= 0 && iRow > 1);
                    // Here, if iRow == 1 then stop process because there is no information need to update to filter file
                    // however the next loop for start from iRow > 1 so the process stop anyway
                    if (iRow == 1)
                    {
                        MessageBox.Show(" There is no new order available  need to update");
                        FilterDataBook.Close();
                        DataBook.Close();
                        return;
                    }
                }
            }

            for (i = iRow; i > 1; --i)
            {
                //if (DataValues.GetValue(i, j) == null) continue;
                string strGross, strIMEI, strEmail, strEbayID;
                strGross = DataValues.GetValue(i, indexGross).ToString();

                // ignore following rows 
                if (strGross.Contains(strSamsungWebGross) && (DataValues.GetValue(i, indexSamsungIMEI - 1) == null))
                    continue;
                if (strGross.Contains(strSamsungEBayGross) && (DataValues.GetValue(i, indexGross + 1) == null))
                    continue;
                if (!ulti.IsUnlockOrder(strGross))
                    continue;

                //  Record only row that is valid Unlock code order and contains enough information
                ++LastRow;
                FilterDataSheet.Cells[LastRow, iGross] = strGross;
                strDate = DataValues.GetValue(i, indexDate).ToString();
                strTime = DataValues.GetValue(i, indexTime).ToString();
                FilterDataSheet.Cells[LastRow, iDate] = strDate;
                FilterDataSheet.Cells[LastRow, iTime] = strTime;
                FilterDataSheet.Cells[LastRow, iName] = DataValues.GetValue(i, indexName).ToString();
                FilterDataSheet.Cells[LastRow, iCode] = strCodeUnavailable;
                strEmail = DataValues.GetValue(i, indexEmail).ToString();
                FilterDataSheet.Cells[LastRow, iEmail] = strEmail;
                if (DataValues.GetValue(i, indexEBayID) != null)
                {
                    strEbayID = DataValues.GetValue(i, indexEBayID).ToString();
                    FilterDataSheet.Cells[LastRow, iEbayID] = strEbayID;
                }
                else
                    strEbayID = String.Empty;
                FilterDataSheet.Cells[LastRow, iDelivered] = strNo;
                if (strGross.Contains(strSamsungWebGross))
                {
                    if (DataValues.GetValue(i, indexSamsungIMEI) != null)
                    {
                        strIMEI = DataValues.GetValue(i, indexSamsungIMEI).ToString();
                        // Delete character / and last 2 digits in IMEI if it exist.
                        strIMEI = ulti.CheckAndCorrectIMEI(strIMEI);
                    }
                    else
                        strIMEI = RegexUltilities.sMissingIMEI;

                    FullSamsungOrderList.Add(strEmail);
                    FullSamsungOrderList.Add(strIMEI);
                    IMEISamsungOrderList.Add(strIMEI);
                }
                else if (strGross.Contains(strSamsungEBayGross))
                {
                    if (DataValues.GetValue(i, indexNote) != null)
                    {
                        strIMEI = DataValues.GetValue(i, indexNote).ToString();
                        if (ulti.ContainIMEI(strIMEI))
                        strIMEI = ulti.GetIMEI(strIMEI);
                        else
                        {
                            strIMEI = RegexUltilities.sMissingIMEI;
                        }
                    }
                    else
                        strIMEI = RegexUltilities.sMissingIMEI;

                    FullSamsungOrderList.Add(strEmail + "\t" + strEbayID);
                    FullSamsungOrderList.Add(strIMEI);
                    IMEISamsungOrderList.Add(strIMEI);
                }
                else
                {
                    if (DataValues.GetValue(i, indexiPhoneIMEI) != null)
                    {
                        strIMEI = DataValues.GetValue(i, indexiPhoneIMEI).ToString();
                        strIMEI = "0" + strIMEI;
                    }
                    else strIMEI = RegexUltilities.sMissingIMEI;
                    ///////following code needs to be rewrite using const string[]
                    if (strGross.Contains(strG1))
                    {
                        index = G1;
                        FulliPhoneOrderList.Add(strEmail + "\t" + strG1);
                    }
                    else if (strGross.Contains(strG2))
                    {
                        index = G2;
                        FulliPhoneOrderList.Add(strEmail + "\t" + strG2);
                    }
                    else if (strGross.Contains(strG3))
                    {
                        index = G3;
                        FulliPhoneOrderList.Add(strEmail + "\t" + strG3);
                    }
                    else if (strGross.Contains(strG4))
                    {
                        index = G4;
                        FulliPhoneOrderList.Add(strEmail + "\t" + strG4);
                    }
                    else if (strGross.Contains(strG5))
                    {
                        index = G5;
                        FulliPhoneOrderList.Add(strEmail + "\t" + strG5);
                    }
                    iPhoneIMEIList[index].Add(strIMEI);
                    FulliPhoneOrderList.Add(strIMEI);

                }
                FilterDataSheet.Cells[LastRow, iIMEI] = strIMEI;
            }
            if (FirstTimECreated)
                FilterDataBook.SaveAs(PurifiedDataFilename);
            else
                FilterDataBook.Save();
            FilterDataBook.Close();
            DataBook.Close();
            // Show information in rich text boxes
            rtbFullOrderInfo.Text = null;
            foreach (string s in FullSamsungOrderList)
            {
                rtbFullOrderInfo.Text += s + Environment.NewLine;
            }
            rtbCorrectIMEIs.Text = null;
            foreach (string s in IMEISamsungOrderList)
            {
                rtbCorrectIMEIs.Text += s + Environment.NewLine;
            }
            // Display information for iPhone order in compact and in details below compact
            // These code needs to be rewrite using const string[]
            rtbiPhoneOrder.Text = null;
            foreach (string s in FulliPhoneOrderList)
            {
                rtbiPhoneOrder.Text += s + Environment.NewLine;
            }
            rtbiPhoneOrder.Text += iPhone_standard_old + Environment.NewLine;
            foreach (string s in iPhoneIMEIList[G1])
            {
                rtbiPhoneOrder.Text += s + Environment.NewLine;
            }
            rtbiPhoneOrder.Text += iPhone_standard_new + Environment.NewLine;
            foreach (string s in iPhoneIMEIList[G2])
            {
                rtbiPhoneOrder.Text += s + Environment.NewLine;
            }
            rtbiPhoneOrder.Text += iPhone_premium_old + Environment.NewLine;
            foreach (string s in iPhoneIMEIList[G3])
            {
                rtbiPhoneOrder.Text += s + Environment.NewLine;
            }
            rtbiPhoneOrder.Text += iPhone_premium_new + Environment.NewLine;
            foreach (string s in iPhoneIMEIList[G4])
            {
                rtbiPhoneOrder.Text += s + Environment.NewLine;
            }
            rtbiPhoneOrder.Text += iPhone_express + Environment.NewLine;
            foreach (string s in iPhoneIMEIList[G5])
            {
                rtbiPhoneOrder.Text += s + Environment.NewLine;
            }
        }

        /*
        static public bool IsIphoneOrder(string str)
        {
            if (str != iPhone_standard_old
                && str != iPhone_standard_new
                && str != iPhone_premium_old
                && str != iPhone_premium_new
                && str != iPhone_express)
                return false;
            else return true;
        }
        */
        private void btGetCompleteOrder_Click(object sender, EventArgs e)
        {
            if (rtbUnlockCode.Lines == null || rtbUnlockCode.Lines.GetLength(0) == 0)
            {
                MessageBox.Show("No unlock code result to fill to the file");
                return;
            }
            RegexUltilities util = new RegexUltilities();
            List<string> UnlockResultList = new List<string>();
            // Get unlock code result
            foreach (string s in rtbUnlockCode.Lines)
            {
                if (s.Contains("IMEI") || s.Contains("NETWORK"))
                    UnlockResultList.Add(s);
            }

            string FilteredDataFilePath = tbFilteredDataFilePath.Text;
            if (!System.IO.File.Exists(FilteredDataFilePath))
            {
                MessageBox.Show("Filtered Data file doesn't exist", "File not exist", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                return;
            }
            Excel.Application OutApp = new Excel.Application();
            Workbook Outbook = OutApp.Workbooks.Open(FilteredDataFilePath);
            Worksheet outsheet = (Worksheet)Outbook.Sheets[1];
            int iRow;
            int index;
            iRow = outsheet.UsedRange.Rows.Count;
            // Move to line that has actual data from bottom

            Excel.Range range;
            range = outsheet.get_Range("A" + iRow.ToString(), "D" + iRow.ToString());
            Array LastRowData = (System.Array)range.Cells.Value;
            while (LastRowData.GetValue(1, iDate) == null)
            {
                --iRow;
                range = outsheet.get_Range("A" + iRow.ToString(), "D" + iRow.ToString());
                LastRowData = (System.Array)range.Cells.Value;
            }
            if (iRow == 1)
            {
                MessageBox.Show("File " + FilteredDataFilePath + " contains only header line");
                Outbook.Close();
                return;
            }

            // At this point, iRow is equal number of line that contains actual data in excel file
            //  Finding the index where process filling unlock code should stop.
            range = outsheet.get_Range("A" + "1", "I" + iRow.ToString());
            Array DataValue = (System.Array)range.Cells.Value;

            if (chbFullScan.Checked)
            {
                index = 2;
            }
            else
            {
                index = iRow;
                while (index > 1 && DataValue.GetValue(index, iCode).ToString().Contains(strCodeUnavailable))
                {
                    --index;
                }
                ++index;
            }
            if (index > iRow) // All orders in file already filled with unlock code
            {
                MessageBox.Show(" No information available from current start line");
                Outbook.Close();
                return;
            }
            int iDataValueBeginLine = index;
            range = outsheet.get_Range("A" + iDataValueBeginLine.ToString(), "I" + iRow.ToString());
            DataValue = (System.Array)range.Cells.Value;
            iRow = DataValue.GetLength(0);
            string strIMEI, strEmail, strCode, strEBayID;
            int i;
            rtbCompleteOrderResult.Text = null;
            for (i = 1; i <= iRow; ++i)
            {
                strCode = DataValue.GetValue(i, iCode).ToString();
                // Check if unlock code already exist
                if (!strCode.Contains(strCodeUnavailable))
                    continue;
                strIMEI = DataValue.GetValue(i, iIMEI).ToString();
                index = 0;
                int CodeListSize = UnlockResultList.Count();
                while ((index < CodeListSize) && !UnlockResultList[index].Contains(strIMEI))
                {
                    ++index;
                }
                if (index < CodeListSize)  // Code found. Unlock code will be the next row
                {
                    strCode = UnlockResultList[index + 1];
                    // Update Unlock Code to data file
                    outsheet.Cells[iDataValueBeginLine + i - 1, iCode] = strCode;
                    UnlockResultList.RemoveAt(index); // remove the IMEI from the UnlockResultList, 
                    //Length of UnockResultList decrease by 1
                    UnlockResultList.RemoveAt(index); // Remove the code from UnlockResultList 
                    strEmail = DataValue.GetValue(i, iEmail).ToString();
                    // Output to rich text box
                    rtbCompleteOrderResult.Text += Environment.NewLine + strEmail;
                    if (DataValue.GetValue(i, iEbayID) != null)
                    {
                        strEBayID = DataValue.GetValue(i, iEbayID).ToString();
                        rtbCompleteOrderResult.Text += "\t" + strEBayID;
                    }
                    rtbCompleteOrderResult.Text += Environment.NewLine + strIMEI;
                    rtbCompleteOrderResult.Text += Environment.NewLine + strCode;
                }
            }
            Outbook.Save();
            Outbook.Close();
        }

        private void buttonSendEmail_Click(object sender, EventArgs e)
        {
            string FirstPartEmail = "<p>Dear, <br/> Result  Unlock Code</p>";
            string LastPartEmail = "<p>Please put a unauthorized Sim card into the phone and restart it.";
            LastPartEmail += " The phone will ask for unlock PIN.";
            LastPartEmail += " <p> Read the instruction in attached file to know how to use the code to unlock your phone.";
            LastPartEmail += " Remember that the code in the pdf file is example code, not yours. Your code is above.</p> ";
            LastPartEmail += "<p> If you have any question feel free to email me</p>";
            LastPartEmail += " <p>Best Regards.</p>";
            string strEmail;
            string strIMEI;
            string strCode;
            string strDeliver;
            string EmailBody;
            RegexUltilities util = new RegexUltilities();
            List<string> ResultList = new List<string>();
            foreach (string str in rtbCompleteOrderResult.Lines)
            {
                ResultList.Add(str);
            }
            // Load data from file that contain orders not receive Unlock Code yet.
            string FilteredDataFilePath = tbFilteredDataFilePath.Text;
            if (!System.IO.File.Exists(FilteredDataFilePath))
            {
                MessageBox.Show("Filtered Data file doesn't exist", "File not exist", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                return;
            }
            Excel.Application OutApp = new Excel.Application();
            Workbook Outbook = OutApp.Workbooks.Open(FilteredDataFilePath);
            Worksheet outsheet = (Worksheet)Outbook.Sheets[1];
            int iRow;
            int index;
            iRow = outsheet.UsedRange.Rows.Count;
            // Move to line that has actual data from bottom

            Excel.Range range;
            range = outsheet.get_Range("A" + iRow.ToString(), "D" + iRow.ToString());
            Array LastRowData = (System.Array)range.Cells.Value;
            while (LastRowData.GetValue(1, iDate) == null)
            {
                --iRow;
                range = outsheet.get_Range("A" + iRow.ToString(), "D" + iRow.ToString());
                LastRowData = (System.Array)range.Cells.Value;
            }
            if (iRow == 1)
            {
                MessageBox.Show("Data file contains only header");
                Outbook.Close();
                return;
            }
            // At this point, iRow is equal number of line that contains actual data in excel file

            //  Finding the index where process filling unlock code should stop.
            range = outsheet.get_Range("A" + "1", "I" + iRow.ToString());
            Array DataValue = (System.Array)range.Cells.Value;
            string strNotDeliver = strNo;
            if (chbFullScan.Checked) // Perform full scan when working with iPhone IMEI
            {
                index = 2;
            }
            else
            {
                index = iRow;
                while (DataValue.GetValue(index, iDelivered).ToString().Contains(strNotDeliver) && index > 1)
                {
                    --index;
                }
                ++index;
            }
            if (index > iRow)
            {
                MessageBox.Show(" All unlock codes were sent out");
                Outbook.Close();
                return;
            }
            range = outsheet.get_Range("A" + index.ToString(), "I" + iRow.ToString());
            DataValue = (System.Array)range.Cells.Value;
            // This fragment code send unlock code to customers' emails, using information in filter data file ( result data)
            iRow = DataValue.GetLength(0);
            int i;
            for (i = 1; i <= iRow; ++i)
            {
                try
                {
                    strIMEI = DataValue.GetValue(i, iIMEI).ToString();
                    strCode = DataValue.GetValue(i, iCode).ToString();
                    strDeliver = DataValue.GetValue(i, iDelivered).ToString();
                    // Check if the code is ready yet
                    if (strCode.Contains(strCodeUnavailable) || strDeliver.Contains(strYes)) continue;

                    strEmail = DataValue.GetValue(i, iEmail).ToString();
                    EmailBody = FirstPartEmail;
                    EmailBody += "<p><font size = \"+1\" >" + strIMEI + "</p>";
                    EmailBody += "<p><font size = \"+1\" >" + strCode + "</p>";
                    EmailBody += LastPartEmail;
                    try
                    {
                        // Create the Outlook application.
                        Outlook.Application oApp = new Outlook.Application();
                        // Create a new mail item.
                        Outlook.MailItem oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
                        // Set HTMLBody. 
                        //add the body of the email

                        oMsg.HTMLBody = EmailBody;
                        //Add an attachment.
                        String sDisplayName = "Instruction";
                        int iPosition = (int)oMsg.Body.Length + 1;
                        int iAttachType = (int)Outlook.OlAttachmentType.olByValue;
                        //now attached the file
                        Outlook.Attachment oAttach = oMsg.Attachments.Add(tbAttachFilePath.Text, iAttachType, iPosition, sDisplayName);
                        //Subject line
                        oMsg.Subject = "UNLOCK CODE";
                        // Add a recipient.
                        Outlook.Recipients oRecips = (Outlook.Recipients)oMsg.Recipients;
                        // Change the recipient in the next line if necessary.
                        if (chbTest.Checked)
                        {
                            strEmail = "vladimir.tran@gmail.com";
                        }
                        else
                        {
                            outsheet.Cells[index + i - 1, iDelivered] = strYes;
                        }
                        Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(strEmail);
                        oRecip.Resolve();
                        // Send.
                        oMsg.Send();
                        // Clean up.
                        oRecip = null;
                        oRecips = null;
                        oMsg = null;
                        oApp = null;
                    }//end of try block
                    catch (Exception ex)
                    {
                    }//end of catch                      
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    break;
                }
            }
            Outbook.Save();
            Outbook.Close();
        }

        private void buttonBrowseAttachFile_Click(object sender, EventArgs e)
        {
            if (ofdAttachFile.ShowDialog() == DialogResult.OK)
            {
                tbAttachFilePath.Text = ofdAttachFile.FileName;
                SaveConfiguration();
            }
        }

        private void btUnlockOrderDataFile_Click(object sender, EventArgs e)
        {
            if (ofdFilteredDataFile.ShowDialog() == DialogResult.OK)
            {
                tbFilteredDataFilePath.Text = ofdFilteredDataFile.FileName;
                SaveConfiguration();
            }
        }

        private void FormMinion_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(ConfigFile))
            {
                StreamReader config_infile = new StreamReader(ConfigFile);
                tbDataFilePath.Text = config_infile.ReadLine();
                tbFilteredDataFilePath.Text = config_infile.ReadLine();
                tbAttachFilePath.Text = config_infile.ReadLine();
                tbStartLine.Text = config_infile.ReadLine();
                config_infile.Close();
            }
        }
        private void SaveConfiguration()
        {
            StreamWriter config_ofile = new StreamWriter(ConfigFile, false);
            config_ofile.WriteLine(tbDataFilePath.Text);
            config_ofile.WriteLine(tbFilteredDataFilePath.Text);
            config_ofile.WriteLine(tbAttachFilePath.Text);
            config_ofile.WriteLine(tbStartLine.Text);
            config_ofile.Close();
        }

        private void tbAttachFilePath_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
