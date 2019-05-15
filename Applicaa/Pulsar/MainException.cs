// Decompiled with JetBrains decompiler
// Type: SIMS.UserInterfaces.MainException
// Assembly: Pulsar, Version=7.180.40.0, Culture=neutral, PublicKeyToken=21f532fe36bf9cd6
// MVID: 426271C6-CBAA-459D-A1E4-8EB841AEB1DD
// Assembly location: C:\Program Files (x86)\SIMS\SIMS .net\Pulsar.exe

using SIMS.Entities;
using SIMS.Utilities;
using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SIMS.UserInterfaces
{
  public class MainException : System.Windows.Forms.Form
  {
    private string faultCode = "";
    private string notAvailable = "NOT AVAILABLE";
    public ImageList imageListStandard;
    public ToolBar toolBarLeft;
    public System.Windows.Forms.ToolBarButton toolBarButtonSave;
    private System.Windows.Forms.TextBox textBoxStackTrace;
    private IContainer components;
    private SaveFileDialog saveFileDialog;
    private Button buttonMore;
    private Button buttonClose;
    private Label labelFaultDescription;
    private Exception exception;
    private LinkLabel labelFaultCode;
    private Button buttonLaunchSupportNet;
    private ToolTip toolTipMainException;
    private GroupBox pictureBoxBase;

    public MainException()
    {
      this.InitializeComponent();
    }

    public MainException(Exception exception)
    {
      this.InitializeComponent();
      this.BackColor = XPThemeInformation.TaskPaneEnd;
      this.exception = exception;
      this.Text = "SIMS Fault";
      this.Visible = true;
      this.faultCode = this.constructErrorCode(exception);
      this.labelFaultCode.Text = "Fault Code : " + this.faultCode;
      this.labelFaultDescription.Text = exception.Message + " : " + exception.GetType().ToString();
      this.textBoxStackTrace.Text = exception.StackTrace;
      if (this.linkAvailable(Cache.SupportURL))
      {
        this.buttonLaunchSupportNet.Left = this.labelFaultCode.Left + this.labelFaultCode.Width + 16;
        this.buttonLaunchSupportNet.Click -= new EventHandler(this.buttonLaunchSupportNet_Click);
        this.buttonLaunchSupportNet.Click += new EventHandler(this.buttonLaunchSupportNet_Click);
      }
      else
      {
        this.buttonLaunchSupportNet.Visible = false;
        this.labelFaultCode.LinkBehavior = LinkBehavior.NeverUnderline;
        this.labelFaultCode.LinkArea = new LinkArea(0, 0);
      }
    }

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      ImageList imageList = CheckBoxListViewImages.CreateImageList();
      this.imageListStandard.Images.Clear();
      this.imageListStandard.Images.Add(imageList.Images[2]);
      this.imageListStandard.Images.Add(imageList.Images[3]);
    }

    private string constructErrorCode(Exception exception)
    {
      try
      {
        SqlException sqlException = exception as SqlException;
        string stackFor1 = this.parseStackFor("SIMS.UserInterfaces.", exception.StackTrace);
        string stackFor2 = this.parseStackFor("SIMS.Entities.", exception.StackTrace);
        string stackFor3 = this.parseStackFor("SIMS.Processes.", exception.StackTrace);
        string str1 = "";
        if (sqlException != null)
          str1 = sqlException.Number.ToString();
        string message = exception.Message;
        string str2 = Math.Abs((this.tidyStackTraceMessage(stackFor1) + this.tidyStackTraceMessage(stackFor2) + this.tidyStackTraceMessage(stackFor3) + str1 + message).GetHashCode()).ToString();
        StringBuilder stringBuilder = new StringBuilder();
        for (int startIndex = 0; startIndex < str2.Length; startIndex += 4)
          stringBuilder.Append((str2 + "0000").Substring(startIndex, 4) + "-");
        string str3 = stringBuilder.ToString();
        return str3.Substring(0, str3.Length - 1);
      }
      catch
      {
        return "0000-0000";
      }
    }

    private string tidyStackTraceMessage(string originalMessage)
    {
      if (originalMessage.Length <= 6)
        return originalMessage;
      string str1 = originalMessage.Substring(6);
      int length = str1.IndexOf("(");
      string str2 = str1.Substring(0, length);
      return str2.Substring(0, str2.LastIndexOf("."));
    }

    private string parseStackFor(string namespaceName, string stack)
    {
      string[] strArray = stack.Split(Environment.NewLine.ToCharArray());
      for (int index = strArray.Length - 1; index > -1; --index)
      {
        if (strArray[index].TrimStart().StartsWith("at " + namespaceName))
          return strArray[index];
      }
      return "";
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ResourceManager resourceManager = new ResourceManager(typeof (MainException));
      this.imageListStandard = new ImageList(this.components);
      this.toolBarLeft = new ToolBar();
      this.toolBarButtonSave = new System.Windows.Forms.ToolBarButton();
      this.textBoxStackTrace = new System.Windows.Forms.TextBox();
      this.saveFileDialog = new SaveFileDialog();
      this.buttonMore = new Button();
      this.buttonClose = new Button();
      this.pictureBoxBase = new GroupBox();
      this.labelFaultCode = new LinkLabel();
      this.buttonLaunchSupportNet = new Button();
      this.labelFaultDescription = new Label();
      this.toolTipMainException = new ToolTip(this.components);
      this.pictureBoxBase.SuspendLayout();
      this.SuspendLayout();
      this.imageListStandard.ColorDepth = ColorDepth.Depth16Bit;
      this.imageListStandard.ImageSize = new Size(16, 16);
      this.imageListStandard.ImageStream = (ImageListStreamer) resourceManager.GetObject("imageListStandard.ImageStream");
      this.imageListStandard.TransparentColor = SystemColors.Control;
      this.toolBarLeft.Appearance = ToolBarAppearance.Flat;
      ((System.Windows.Forms.ToolBar) this.toolBarLeft).Buttons.AddRange(new System.Windows.Forms.ToolBarButton[1]
      {
        this.toolBarButtonSave
      });
      this.toolBarLeft.ButtonSize = new Size(53, 22);
      this.toolBarLeft.Divider = false;
      this.toolBarLeft.DropDownArrows = true;
      this.toolBarLeft.ImageList = this.imageListStandard;
      this.toolBarLeft.Location = new System.Drawing.Point(0, 0);
      this.toolBarLeft.Name = "toolBarLeft";
      this.toolBarLeft.ShowToolTips = true;
      this.toolBarLeft.Size = new Size(736, 26);
      this.toolBarLeft.TabIndex = 4;
      this.toolBarLeft.TextAlign = ToolBarTextAlign.Right;
      this.toolBarLeft.ButtonClick += new ToolBarButtonClickEventHandler(this.toolBarLeft_ButtonClick);
      this.toolBarButtonSave.ImageIndex = 1;
      this.toolBarButtonSave.Text = "Save As";
      this.textBoxStackTrace.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
      this.textBoxStackTrace.BackColor = Color.AliceBlue;
      this.textBoxStackTrace.BorderStyle = BorderStyle.FixedSingle;
      this.textBoxStackTrace.Location = new System.Drawing.Point(0, 224);
      this.textBoxStackTrace.Multiline = true;
      this.textBoxStackTrace.Name = "textBoxStackTrace";
      this.textBoxStackTrace.ReadOnly = true;
      this.textBoxStackTrace.ScrollBars = ScrollBars.Vertical;
      this.textBoxStackTrace.Size = new Size(736, 0);
      this.textBoxStackTrace.TabIndex = 10;
      this.textBoxStackTrace.Text = "";
      this.saveFileDialog.DefaultExt = "XML";
      this.saveFileDialog.FileName = "SIMS Fault Report.xml";
      this.saveFileDialog.Title = "Save Fault Description To File";
      this.buttonMore.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.buttonMore.BackColor = Color.Transparent;
      this.buttonMore.FlatStyle = FlatStyle.Flat;
      this.buttonMore.Location = new System.Drawing.Point(510, 192);
      this.buttonMore.Name = "buttonMore";
      this.buttonMore.NoEdit = false;
      this.buttonMore.NoUIModify = false;
      this.buttonMore.OriginalText = "&More Details";
      this.buttonMore.Size = new Size(104, 24);
      this.buttonMore.TabIndex = 2;
      this.buttonMore.Text = "&More Details";
      this.buttonMore.Click += new EventHandler(this.buttonMore_Click);
      this.buttonClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
      this.buttonClose.BackColor = Color.Transparent;
      this.buttonClose.FlatStyle = FlatStyle.Flat;
      this.buttonClose.Location = new System.Drawing.Point(622, 192);
      this.buttonClose.Name = "buttonClose";
      this.buttonClose.NoEdit = false;
      this.buttonClose.NoUIModify = false;
      this.buttonClose.OriginalText = "&Close";
      this.buttonClose.Size = new Size(104, 24);
      this.buttonClose.TabIndex = 3;
      this.buttonClose.Text = "&Close";
      this.buttonClose.Click += new EventHandler(this.buttonClose_Click);
      this.pictureBoxBase.AltKeySequence = -1;
      this.pictureBoxBase.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.pictureBoxBase.BackColor = Color.Transparent;
      this.pictureBoxBase.BorderColor = Color.Empty;
      this.pictureBoxBase.BorderWidth = 1;
      this.pictureBoxBase.Controls.Add((Control) this.labelFaultCode);
      this.pictureBoxBase.Controls.Add((Control) this.buttonLaunchSupportNet);
      this.pictureBoxBase.Controls.Add((Control) this.labelFaultDescription);
      this.pictureBoxBase.DrawBorder = false;
      this.pictureBoxBase.GroupBoxStyle = GroupBox.GroupBoxStyleEnum.XPFadeToBottom;
      this.pictureBoxBase.LargeImage = false;
      this.pictureBoxBase.Location = new System.Drawing.Point(8, 32);
      this.pictureBoxBase.Name = "pictureBoxBase";
      this.pictureBoxBase.NoEdit = false;
      this.pictureBoxBase.NoUIModify = false;
      this.pictureBoxBase.OriginalText = "An application fault has occurred. Please print or save the following message and contact your support advisor.";
      this.pictureBoxBase.PanelColour = Color.Empty;
      this.pictureBoxBase.Size = new Size(718, 152);
      this.pictureBoxBase.TabIndex = 15;
      this.pictureBoxBase.TabStop = false;
      this.pictureBoxBase.Text = "An application fault has occurred. Please print or save the following message and contact your support advisor.";
      this.pictureBoxBase.TitleImage = ButtonImage.None;
      this.labelFaultCode.AltText = "";
      this.labelFaultCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.labelFaultCode.AutoSize = true;
      this.labelFaultCode.BackColor = Color.Transparent;
      this.labelFaultCode.Font = new Font("Microsoft Sans Serif", 8.25f);
      this.labelFaultCode.ForeColor = SystemColors.ControlLightLight;
      this.labelFaultCode.LinkColor = Color.FromArgb(33, 93, 198);
      this.labelFaultCode.LinkedToTextOfControl = (Control) null;
      this.labelFaultCode.Location = new System.Drawing.Point(8, 40);
      this.labelFaultCode.Name = "labelFaultCode";
      this.labelFaultCode.NoAlign = false;
      this.labelFaultCode.NoEdit = false;
      this.labelFaultCode.NoUIModify = false;
      this.labelFaultCode.OriginalText = "xxxxxxxx";
      this.labelFaultCode.Size = new Size(49, 16);
      this.labelFaultCode.TabIndex = 0;
      this.labelFaultCode.TabStop = true;
      this.labelFaultCode.Text = "xxxxxxxx";
      this.labelFaultCode.TextAlign = ContentAlignment.MiddleLeft;
      this.labelFaultCode.LinkClicked += new LinkLabelLinkClickedEventHandler(this.labelFaultCode_LinkClicked);
      this.buttonLaunchSupportNet.BackColor = Color.Transparent;
      this.buttonLaunchSupportNet.FlatStyle = FlatStyle.Flat;
      this.buttonLaunchSupportNet.Location = new System.Drawing.Point(256, 36);
      this.buttonLaunchSupportNet.Name = "buttonLaunchSupportNet";
      this.buttonLaunchSupportNet.NoEdit = false;
      this.buttonLaunchSupportNet.NoUIModify = false;
      this.buttonLaunchSupportNet.OriginalText = "&Search for Solution...";
      this.buttonLaunchSupportNet.Size = new Size(128, 24);
      this.buttonLaunchSupportNet.TabIndex = 1;
      this.buttonLaunchSupportNet.Text = "&Search for Solution...";
      this.toolTipMainException.SetToolTip((Control) this.buttonLaunchSupportNet, "Search for help on this fault code");
      this.labelFaultDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      this.labelFaultDescription.BackColor = Color.Transparent;
      this.labelFaultDescription.BorderStyle = BorderStyle.FixedSingle;
      this.labelFaultDescription.ForeColor = Color.Brown;
      this.labelFaultDescription.Location = new System.Drawing.Point(8, 64);
      this.labelFaultDescription.Name = "labelFaultDescription";
      this.labelFaultDescription.NoAlign = false;
      this.labelFaultDescription.NoEdit = false;
      this.labelFaultDescription.NoUIModify = false;
      this.labelFaultDescription.OriginalText = "Fault Description";
      this.labelFaultDescription.Size = new Size(702, 80);
      this.labelFaultDescription.TabIndex = 16;
      this.labelFaultDescription.Text = "Fault Description";
      this.AcceptButton = (IButtonControl) this.buttonClose;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(736, 222);
      this.Controls.Add((Control) this.pictureBoxBase);
      this.Controls.Add((Control) this.buttonClose);
      this.Controls.Add((Control) this.buttonMore);
      this.Controls.Add((Control) this.textBoxStackTrace);
      this.Controls.Add((Control) this.toolBarLeft);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.Icon = (Icon) resourceManager.GetObject("$this.Icon");
      this.Name = nameof (MainException);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (MainException);
      this.pictureBoxBase.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    private void saveXML()
    {
      if (this.saveFileDialog.ShowDialog() != DialogResult.OK)
        return;
      string fileName = this.saveFileDialog.FileName;
      using (MemoryStream memoryStream = new MemoryStream())
      {
        XmlWriter xmlWriter = (XmlWriter) new XmlTextWriter((Stream) memoryStream, (Encoding) new UTF8Encoding());
        Serializer.Serialize(xmlWriter, (object) this.exception);
        xmlWriter.Flush();
        memoryStream.Seek(0L, SeekOrigin.Begin);
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load((Stream) memoryStream);
        XmlElement element = xmlDocument.CreateElement("FaultCode");
        element.InnerText = this.faultCode;
        xmlDocument.DocumentElement.InsertBefore((XmlNode) element, xmlDocument.DocumentElement.FirstChild);
        xmlDocument.Save(fileName);
        xmlWriter.Close();
      }
    }

    private void toolBarLeft_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
    {
      if (e.Button != this.toolBarButtonSave)
        return;
      this.saveXML();
    }

    private void buttonMore_Click(object sender, EventArgs e)
    {
      this.Height += 250;
      this.buttonMore.Enabled = false;
    }

    private void buttonClose_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void buttonLaunchSupportNet_Click(object sender, EventArgs e)
    {
      this.openSupportNet();
    }

    private void labelFaultCode_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      this.openSupportNet();
    }

    private void openSupportNet()
    {
      this.TopMost = false;
      if (Cache.SupportURL.Length <= 0 || !this.linkAvailable(Cache.SupportURL))
        return;
      Process.Start(new ProcessStartInfo(string.Format(Cache.SupportURL, (object) this.faultCode))
      {
        WindowStyle = ProcessWindowStyle.Normal
      });
    }

    private bool linkAvailable(string url)
    {
      return url.ToUpper().Trim() != this.notAvailable;
    }
  }
}
