namespace Minion
{
    partial class FormMinion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialogData = new System.Windows.Forms.OpenFileDialog();
            this.bt_DataFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbStartLine = new System.Windows.Forms.TextBox();
            this.tbDataFilePath = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabOrderInformation = new System.Windows.Forms.TabPage();
            this.rtbFullOrderInfo = new System.Windows.Forms.RichTextBox();
            this.tabCorrectIMEI = new System.Windows.Forms.TabPage();
            this.rtbCorrectIMEIs = new System.Windows.Forms.RichTextBox();
            this.tabMissingInformationOrder = new System.Windows.Forms.TabPage();
            this.rtbMissingInfoOrder = new System.Windows.Forms.RichTextBox();
            this.tabUnlockCodeResult = new System.Windows.Forms.TabPage();
            this.rtbUnlockCode = new System.Windows.Forms.RichTextBox();
            this.tabCompleteOrderResult = new System.Windows.Forms.TabPage();
            this.chbFullScan = new System.Windows.Forms.CheckBox();
            this.btGetCompleteOrder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.chbTest = new System.Windows.Forms.CheckBox();
            this.tbAttachFilePath = new System.Windows.Forms.TextBox();
            this.buttonSendEmail = new System.Windows.Forms.Button();
            this.buttonBrowseAttachFile = new System.Windows.Forms.Button();
            this.rtbCompleteOrderResult = new System.Windows.Forms.RichTextBox();
            this.tabPageiPhoneOrder = new System.Windows.Forms.TabPage();
            this.rtbiPhoneOrder = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPhoneIMEI = new System.Windows.Forms.TextBox();
            this.btExecute = new System.Windows.Forms.Button();
            this.ofdAttachFile = new System.Windows.Forms.OpenFileDialog();
            this.tbFilteredDataFilePath = new System.Windows.Forms.TextBox();
            this.btUnlockOrderDataFile = new System.Windows.Forms.Button();
            this.ofdFilteredDataFile = new System.Windows.Forms.OpenFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabOrderInformation.SuspendLayout();
            this.tabCorrectIMEI.SuspendLayout();
            this.tabMissingInformationOrder.SuspendLayout();
            this.tabUnlockCodeResult.SuspendLayout();
            this.tabCompleteOrderResult.SuspendLayout();
            this.tabPageiPhoneOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_DataFile
            // 
            this.bt_DataFile.AutoSize = true;
            this.bt_DataFile.Location = new System.Drawing.Point(869, 23);
            this.bt_DataFile.Name = "bt_DataFile";
            this.bt_DataFile.Size = new System.Drawing.Size(246, 23);
            this.bt_DataFile.TabIndex = 0;
            this.bt_DataFile.Text = "Browse Paypal Data File";
            this.bt_DataFile.UseVisualStyleBackColor = true;
            this.bt_DataFile.Click += new System.EventHandler(this.button_DataFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Data file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 3;
            // 
            // tbStartLine
            // 
            this.tbStartLine.Location = new System.Drawing.Point(179, 85);
            this.tbStartLine.Name = "tbStartLine";
            this.tbStartLine.Size = new System.Drawing.Size(114, 20);
            this.tbStartLine.TabIndex = 4;
            // 
            // tbDataFilePath
            // 
            this.tbDataFilePath.Location = new System.Drawing.Point(179, 28);
            this.tbDataFilePath.Name = "tbDataFilePath";
            this.tbDataFilePath.Size = new System.Drawing.Size(643, 20);
            this.tbDataFilePath.TabIndex = 5;
            this.tbDataFilePath.Text = "D:\\Coding\\C Sharp\\Data.xlsx";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabOrderInformation);
            this.tabControl.Controls.Add(this.tabCorrectIMEI);
            this.tabControl.Controls.Add(this.tabMissingInformationOrder);
            this.tabControl.Controls.Add(this.tabUnlockCodeResult);
            this.tabControl.Controls.Add(this.tabCompleteOrderResult);
            this.tabControl.Controls.Add(this.tabPageiPhoneOrder);
            this.tabControl.Location = new System.Drawing.Point(50, 134);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1127, 581);
            this.tabControl.TabIndex = 6;
            // 
            // tabOrderInformation
            // 
            this.tabOrderInformation.Controls.Add(this.rtbFullOrderInfo);
            this.tabOrderInformation.Location = new System.Drawing.Point(4, 22);
            this.tabOrderInformation.Name = "tabOrderInformation";
            this.tabOrderInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrderInformation.Size = new System.Drawing.Size(1119, 555);
            this.tabOrderInformation.TabIndex = 0;
            this.tabOrderInformation.Text = "Full Orders Information";
            this.tabOrderInformation.UseVisualStyleBackColor = true;
            // 
            // rtbFullOrderInfo
            // 
            this.rtbFullOrderInfo.Location = new System.Drawing.Point(7, 25);
            this.rtbFullOrderInfo.Name = "rtbFullOrderInfo";
            this.rtbFullOrderInfo.Size = new System.Drawing.Size(1054, 512);
            this.rtbFullOrderInfo.TabIndex = 7;
            this.rtbFullOrderInfo.Text = "";
            // 
            // tabCorrectIMEI
            // 
            this.tabCorrectIMEI.Controls.Add(this.rtbCorrectIMEIs);
            this.tabCorrectIMEI.Location = new System.Drawing.Point(4, 22);
            this.tabCorrectIMEI.Name = "tabCorrectIMEI";
            this.tabCorrectIMEI.Padding = new System.Windows.Forms.Padding(3);
            this.tabCorrectIMEI.Size = new System.Drawing.Size(1119, 555);
            this.tabCorrectIMEI.TabIndex = 1;
            this.tabCorrectIMEI.Text = "Correct IMEI in Order";
            this.tabCorrectIMEI.UseVisualStyleBackColor = true;
            // 
            // rtbCorrectIMEIs
            // 
            this.rtbCorrectIMEIs.Location = new System.Drawing.Point(0, 34);
            this.rtbCorrectIMEIs.Name = "rtbCorrectIMEIs";
            this.rtbCorrectIMEIs.Size = new System.Drawing.Size(1100, 474);
            this.rtbCorrectIMEIs.TabIndex = 1;
            this.rtbCorrectIMEIs.Text = "";
            // 
            // tabMissingInformationOrder
            // 
            this.tabMissingInformationOrder.Controls.Add(this.rtbMissingInfoOrder);
            this.tabMissingInformationOrder.Location = new System.Drawing.Point(4, 22);
            this.tabMissingInformationOrder.Name = "tabMissingInformationOrder";
            this.tabMissingInformationOrder.Padding = new System.Windows.Forms.Padding(3);
            this.tabMissingInformationOrder.Size = new System.Drawing.Size(1119, 555);
            this.tabMissingInformationOrder.TabIndex = 2;
            this.tabMissingInformationOrder.Text = "Missing Information Orders";
            this.tabMissingInformationOrder.UseVisualStyleBackColor = true;
            // 
            // rtbMissingInfoOrder
            // 
            this.rtbMissingInfoOrder.Location = new System.Drawing.Point(0, 26);
            this.rtbMissingInfoOrder.Name = "rtbMissingInfoOrder";
            this.rtbMissingInfoOrder.Size = new System.Drawing.Size(1087, 513);
            this.rtbMissingInfoOrder.TabIndex = 0;
            this.rtbMissingInfoOrder.Text = "";
            // 
            // tabUnlockCodeResult
            // 
            this.tabUnlockCodeResult.Controls.Add(this.rtbUnlockCode);
            this.tabUnlockCodeResult.Location = new System.Drawing.Point(4, 22);
            this.tabUnlockCodeResult.Name = "tabUnlockCodeResult";
            this.tabUnlockCodeResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabUnlockCodeResult.Size = new System.Drawing.Size(1119, 555);
            this.tabUnlockCodeResult.TabIndex = 3;
            this.tabUnlockCodeResult.Text = "Unlock Code Result";
            this.tabUnlockCodeResult.UseVisualStyleBackColor = true;
            // 
            // rtbUnlockCode
            // 
            this.rtbUnlockCode.Location = new System.Drawing.Point(6, 45);
            this.rtbUnlockCode.Name = "rtbUnlockCode";
            this.rtbUnlockCode.Size = new System.Drawing.Size(1089, 495);
            this.rtbUnlockCode.TabIndex = 0;
            this.rtbUnlockCode.Text = "";
            // 
            // tabCompleteOrderResult
            // 
            this.tabCompleteOrderResult.Controls.Add(this.chbFullScan);
            this.tabCompleteOrderResult.Controls.Add(this.btGetCompleteOrder);
            this.tabCompleteOrderResult.Controls.Add(this.label3);
            this.tabCompleteOrderResult.Controls.Add(this.chbTest);
            this.tabCompleteOrderResult.Controls.Add(this.tbAttachFilePath);
            this.tabCompleteOrderResult.Controls.Add(this.buttonSendEmail);
            this.tabCompleteOrderResult.Controls.Add(this.buttonBrowseAttachFile);
            this.tabCompleteOrderResult.Controls.Add(this.rtbCompleteOrderResult);
            this.tabCompleteOrderResult.Location = new System.Drawing.Point(4, 22);
            this.tabCompleteOrderResult.Name = "tabCompleteOrderResult";
            this.tabCompleteOrderResult.Size = new System.Drawing.Size(1119, 555);
            this.tabCompleteOrderResult.TabIndex = 4;
            this.tabCompleteOrderResult.Text = "Complete Order Result";
            this.tabCompleteOrderResult.UseVisualStyleBackColor = true;
            // 
            // chbFullScan
            // 
            this.chbFullScan.AutoSize = true;
            this.chbFullScan.Location = new System.Drawing.Point(22, 90);
            this.chbFullScan.Name = "chbFullScan";
            this.chbFullScan.Size = new System.Drawing.Size(70, 17);
            this.chbFullScan.TabIndex = 10;
            this.chbFullScan.Text = "Full Scan";
            this.chbFullScan.UseVisualStyleBackColor = true;
            // 
            // btGetCompleteOrder
            // 
            this.btGetCompleteOrder.Location = new System.Drawing.Point(326, 84);
            this.btGetCompleteOrder.Name = "btGetCompleteOrder";
            this.btGetCompleteOrder.Size = new System.Drawing.Size(164, 23);
            this.btGetCompleteOrder.TabIndex = 9;
            this.btGetCompleteOrder.Text = "Get Complete Order Result";
            this.btGetCompleteOrder.UseVisualStyleBackColor = true;
            this.btGetCompleteOrder.Click += new System.EventHandler(this.btGetCompleteOrder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Attach file";
            // 
            // chbTest
            // 
            this.chbTest.AutoSize = true;
            this.chbTest.Checked = true;
            this.chbTest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbTest.Location = new System.Drawing.Point(577, 88);
            this.chbTest.Name = "chbTest";
            this.chbTest.Size = new System.Drawing.Size(191, 17);
            this.chbTest.TabIndex = 7;
            this.chbTest.Text = "Testing by sending to Vladimir Tran";
            this.chbTest.UseVisualStyleBackColor = true;
            // 
            // tbAttachFilePath
            // 
            this.tbAttachFilePath.Location = new System.Drawing.Point(22, 39);
            this.tbAttachFilePath.Name = "tbAttachFilePath";
            this.tbAttachFilePath.Size = new System.Drawing.Size(746, 20);
            this.tbAttachFilePath.TabIndex = 6;
            this.tbAttachFilePath.Text = "D:\\eBay\\Paypal unlock code\\Instruction how to unlock sample Samsung Galaxy phone." +
    "pdf";
            this.tbAttachFilePath.TextChanged += new System.EventHandler(this.tbAttachFilePath_TextChanged);
            // 
            // buttonSendEmail
            // 
            this.buttonSendEmail.AutoSize = true;
            this.buttonSendEmail.Location = new System.Drawing.Point(815, 84);
            this.buttonSendEmail.Name = "buttonSendEmail";
            this.buttonSendEmail.Size = new System.Drawing.Size(105, 23);
            this.buttonSendEmail.TabIndex = 2;
            this.buttonSendEmail.Text = "Send Emails";
            this.buttonSendEmail.UseVisualStyleBackColor = true;
            this.buttonSendEmail.Click += new System.EventHandler(this.buttonSendEmail_Click);
            // 
            // buttonBrowseAttachFile
            // 
            this.buttonBrowseAttachFile.AutoSize = true;
            this.buttonBrowseAttachFile.Location = new System.Drawing.Point(815, 37);
            this.buttonBrowseAttachFile.Name = "buttonBrowseAttachFile";
            this.buttonBrowseAttachFile.Size = new System.Drawing.Size(105, 23);
            this.buttonBrowseAttachFile.TabIndex = 1;
            this.buttonBrowseAttachFile.Text = "Browse Attach File";
            this.buttonBrowseAttachFile.UseVisualStyleBackColor = true;
            this.buttonBrowseAttachFile.Click += new System.EventHandler(this.buttonBrowseAttachFile_Click);
            // 
            // rtbCompleteOrderResult
            // 
            this.rtbCompleteOrderResult.Location = new System.Drawing.Point(7, 133);
            this.rtbCompleteOrderResult.Name = "rtbCompleteOrderResult";
            this.rtbCompleteOrderResult.Size = new System.Drawing.Size(1089, 411);
            this.rtbCompleteOrderResult.TabIndex = 0;
            this.rtbCompleteOrderResult.Text = "";
            // 
            // tabPageiPhoneOrder
            // 
            this.tabPageiPhoneOrder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPageiPhoneOrder.Controls.Add(this.rtbiPhoneOrder);
            this.tabPageiPhoneOrder.Location = new System.Drawing.Point(4, 22);
            this.tabPageiPhoneOrder.Name = "tabPageiPhoneOrder";
            this.tabPageiPhoneOrder.Size = new System.Drawing.Size(1119, 555);
            this.tabPageiPhoneOrder.TabIndex = 5;
            this.tabPageiPhoneOrder.Text = "iPhone Orders";
            this.tabPageiPhoneOrder.UseVisualStyleBackColor = true;
            // 
            // rtbiPhoneOrder
            // 
            this.rtbiPhoneOrder.Location = new System.Drawing.Point(5, 40);
            this.rtbiPhoneOrder.Name = "rtbiPhoneOrder";
            this.rtbiPhoneOrder.Size = new System.Drawing.Size(1097, 512);
            this.rtbiPhoneOrder.TabIndex = 0;
            this.rtbiPhoneOrder.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Start From Line";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(51, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "iPhone Start From IMEI";
            // 
            // tbPhoneIMEI
            // 
            this.tbPhoneIMEI.Location = new System.Drawing.Point(179, 108);
            this.tbPhoneIMEI.Name = "tbPhoneIMEI";
            this.tbPhoneIMEI.Size = new System.Drawing.Size(365, 20);
            this.tbPhoneIMEI.TabIndex = 8;
            // 
            // btExecute
            // 
            this.btExecute.Location = new System.Drawing.Point(869, 85);
            this.btExecute.Name = "btExecute";
            this.btExecute.Size = new System.Drawing.Size(246, 23);
            this.btExecute.TabIndex = 10;
            this.btExecute.Text = "Execute";
            this.btExecute.UseVisualStyleBackColor = true;
            this.btExecute.Click += new System.EventHandler(this.buttonExecute_Click);
            // 
            // ofdAttachFile
            // 
            this.ofdAttachFile.FileName = "openFileDialog1";
            // 
            // tbFilteredDataFilePath
            // 
            this.tbFilteredDataFilePath.Location = new System.Drawing.Point(179, 54);
            this.tbFilteredDataFilePath.Name = "tbFilteredDataFilePath";
            this.tbFilteredDataFilePath.Size = new System.Drawing.Size(643, 20);
            this.tbFilteredDataFilePath.TabIndex = 11;
            this.tbFilteredDataFilePath.Text = "D:\\Coding\\C Sharp\\FilterData.xlsx";
            // 
            // btUnlockOrderDataFile
            // 
            this.btUnlockOrderDataFile.Location = new System.Drawing.Point(869, 51);
            this.btUnlockOrderDataFile.Name = "btUnlockOrderDataFile";
            this.btUnlockOrderDataFile.Size = new System.Drawing.Size(246, 23);
            this.btUnlockOrderDataFile.TabIndex = 12;
            this.btUnlockOrderDataFile.Text = "Browse Unlock Order Data File";
            this.btUnlockOrderDataFile.UseVisualStyleBackColor = true;
            this.btUnlockOrderDataFile.Click += new System.EventHandler(this.btUnlockOrderDataFile_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Read From";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Save To";
            // 
            // FormMinion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 771);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btUnlockOrderDataFile);
            this.Controls.Add(this.tbFilteredDataFilePath);
            this.Controls.Add(this.btExecute);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbPhoneIMEI);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.tbDataFilePath);
            this.Controls.Add(this.tbStartLine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt_DataFile);
            this.Name = "FormMinion";
            this.Text = "Minion";
            this.Load += new System.EventHandler(this.FormMinion_Load);
            this.tabControl.ResumeLayout(false);
            this.tabOrderInformation.ResumeLayout(false);
            this.tabCorrectIMEI.ResumeLayout(false);
            this.tabMissingInformationOrder.ResumeLayout(false);
            this.tabUnlockCodeResult.ResumeLayout(false);
            this.tabCompleteOrderResult.ResumeLayout(false);
            this.tabCompleteOrderResult.PerformLayout();
            this.tabPageiPhoneOrder.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialogData;
        private System.Windows.Forms.Button bt_DataFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbStartLine;
        private System.Windows.Forms.TextBox tbDataFilePath;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabOrderInformation;
        private System.Windows.Forms.RichTextBox rtbFullOrderInfo;
        private System.Windows.Forms.TabPage tabCorrectIMEI;
        private System.Windows.Forms.TabPage tabMissingInformationOrder;
        private System.Windows.Forms.TabPage tabUnlockCodeResult;
        private System.Windows.Forms.TabPage tabCompleteOrderResult;
        private System.Windows.Forms.RichTextBox rtbCorrectIMEIs;
        private System.Windows.Forms.RichTextBox rtbMissingInfoOrder;
        private System.Windows.Forms.RichTextBox rtbUnlockCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbTest;
        private System.Windows.Forms.TextBox tbAttachFilePath;
        private System.Windows.Forms.Button buttonSendEmail;
        private System.Windows.Forms.Button buttonBrowseAttachFile;
        private System.Windows.Forms.RichTextBox rtbCompleteOrderResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbPhoneIMEI;
        private System.Windows.Forms.Button btExecute;
        private System.Windows.Forms.TabPage tabPageiPhoneOrder;
        private System.Windows.Forms.RichTextBox rtbiPhoneOrder;
        private System.Windows.Forms.Button btGetCompleteOrder;
        private System.Windows.Forms.OpenFileDialog ofdAttachFile;
        private System.Windows.Forms.TextBox tbFilteredDataFilePath;
        private System.Windows.Forms.Button btUnlockOrderDataFile;
        private System.Windows.Forms.OpenFileDialog ofdFilteredDataFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chbFullScan;
    }
}

