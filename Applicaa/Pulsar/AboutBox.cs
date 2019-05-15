// Decompiled with JetBrains decompiler
// Type: SIMS.UserInterfaces.AboutBox
// Assembly: Pulsar, Version=7.180.40.0, Culture=neutral, PublicKeyToken=21f532fe36bf9cd6
// MVID: 426271C6-CBAA-459D-A1E4-8EB841AEB1DD
// Assembly location: C:\Program Files (x86)\SIMS\SIMS .net\Pulsar.exe

using SIMS.Entities;
using SIMS.Utilities;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace SIMS.UserInterfaces
{
  public class AboutBox : System.Windows.Forms.Form
  {
    private const string releaseState = "RELEASE";
    private Panel panelAboutBox;
    private IContainer components;
    private Button buttonOK;
    private Label labelVersion;
    private Label labelBuild;
    private Label labelDatabase;
    private Label labelEdition;
    private ToolTip toolTip1;
    private Label labelCopyright;
    private System.Windows.Forms.Label labelReleaseState;
    private Label labelAcknowledgement;
    private FileVersionInfo fileVersionInfo;

    public AboutBox()
    {
      this.InitializeComponent();
      Assembly executingAssembly = Assembly.GetExecutingAssembly();
      this.fileVersionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
      FileAssemblyInfo assemblyInfo = FileAssemblyInfo.GetAssemblyInfo(executingAssembly);
      this.toolTip1 = new ToolTip();
      this.toolTip1.SetToolTip((Control) this, this.fileVersionInfo.FileDescription + "\nModule Reference: SS\nFull Version Number: " + this.fileVersionInfo.FileVersion + "\nVersion: " + string.Format("{0}.{1}", (object) this.fileVersionInfo.FileMajorPart, (object) this.fileVersionInfo.FileMinorPart) + "\nBuild: " + this.fileVersionInfo.FileBuildPart.ToString() + "\nRelease Status: RELEASE\nDatabase Schema Version: " + SystemConfigurationCache.DatabaseVersion + "\nAssembly Version: " + assemblyInfo.Version + "\nEdition: " + SystemConfigurationCache.Edition + "\nLocale: " + SystemConfigurationCache.Locale + "\nRequired Fileset number:" + 900.ToString());
      this.toolTip1.AutoPopDelay = 90000;
      this.bindControlsToAttributes();
    }

    private void bindControlsToAttributes()
    {
      this.labelVersion.Text = "Version " + string.Format("{0}.{1}", (object) this.fileVersionInfo.FileMajorPart, (object) this.fileVersionInfo.FileMinorPart);
      this.labelBuild.Text = "Build " + this.fileVersionInfo.FileBuildPart.ToString();
      this.labelDatabase.Text = "Database build " + SystemConfigurationCache.DatabaseVersion;
      this.labelEdition.Text = SystemConfigurationCache.Locale + " " + SystemConfigurationCache.Edition;
      this.labelCopyright.Text = this.fileVersionInfo.LegalCopyright + " All rights reserved";
      this.labelAcknowledgement.Text = "Contains iTextSharp © 2008 Bruno Lowgie";
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AboutBox));
      this.buttonOK = new Button();
      this.panelAboutBox = new Panel();
      this.labelAcknowledgement = new Label();
      this.labelReleaseState = new System.Windows.Forms.Label();
      this.labelBuild = new Label();
      this.labelVersion = new Label();
      this.labelEdition = new Label();
      this.labelDatabase = new Label();
      this.labelCopyright = new Label();
      this.panelAboutBox.SuspendLayout();
      this.SuspendLayout();
      this.buttonOK.FlatStyle = FlatStyle.Flat;
      this.buttonOK.Location = new System.Drawing.Point(0, 0);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.NoEdit = false;
      this.buttonOK.NoUIModify = false;
      this.buttonOK.OriginalText = "";
      this.buttonOK.Size = new Size(75, 23);
      this.buttonOK.TabIndex = 0;
      this.panelAboutBox.BackColor = Color.White;
      this.panelAboutBox.BackgroundImage = (Image) componentResourceManager.GetObject("panelAboutBox.BackgroundImage");
      this.panelAboutBox.BackgroundImageLayout = ImageLayout.Zoom;
      this.panelAboutBox.Controls.Add((Control) this.labelAcknowledgement);
      this.panelAboutBox.Controls.Add((Control) this.labelReleaseState);
      this.panelAboutBox.Controls.Add((Control) this.labelBuild);
      this.panelAboutBox.Controls.Add((Control) this.labelVersion);
      this.panelAboutBox.Controls.Add((Control) this.labelEdition);
      this.panelAboutBox.Controls.Add((Control) this.labelDatabase);
      this.panelAboutBox.Controls.Add((Control) this.labelCopyright);
      this.panelAboutBox.Dock = DockStyle.Fill;
      this.panelAboutBox.Location = new System.Drawing.Point(0, 0);
      this.panelAboutBox.Name = "panelAboutBox";
      this.panelAboutBox.Shaded = false;
      this.panelAboutBox.Size = new Size(399, 299);
      this.panelAboutBox.TabIndex = 5;
      this.panelAboutBox.Click += new EventHandler(this.buttonOK_Click);
      this.labelAcknowledgement.BackColor = Color.Transparent;
      this.labelAcknowledgement.Font = new Font("Microsoft Sans Serif", 7f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelAcknowledgement.Location = new System.Drawing.Point(126, 253);
      this.labelAcknowledgement.Name = "labelAcknowledgement";
      this.labelAcknowledgement.NoAlign = false;
      this.labelAcknowledgement.NoEdit = false;
      this.labelAcknowledgement.NoUIModify = false;
      this.labelAcknowledgement.OriginalText = "Acknowledgements";
      this.labelAcknowledgement.Size = new Size(213, 41);
      this.labelAcknowledgement.TabIndex = 6;
      this.labelAcknowledgement.Text = "Acknowledgements";
      this.labelAcknowledgement.TextAlign = ContentAlignment.BottomLeft;
      this.labelReleaseState.AutoSize = true;
      this.labelReleaseState.BackColor = Color.Transparent;
      this.labelReleaseState.Font = new Font("Microsoft Sans Serif", 14.25f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelReleaseState.ForeColor = Color.FromArgb((int) byte.MaxValue, 128, 0);
      this.labelReleaseState.Location = new System.Drawing.Point(20, 128);
      this.labelReleaseState.Name = "labelReleaseState";
      this.labelReleaseState.Size = new Size(0, 24);
      this.labelReleaseState.TabIndex = 5;
      this.labelReleaseState.Visible = false;
      this.labelReleaseState.Click += new EventHandler(this.buttonOK_Click);
      this.labelBuild.BackColor = Color.Transparent;
      this.labelBuild.Font = new Font("Microsoft Sans Serif", 7f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelBuild.Location = new System.Drawing.Point(6, 210);
      this.labelBuild.Name = "labelBuild";
      this.labelBuild.NoAlign = false;
      this.labelBuild.NoEdit = false;
      this.labelBuild.NoUIModify = false;
      this.labelBuild.OriginalText = "Build 15";
      this.labelBuild.Size = new Size(49, 13);
      this.labelBuild.TabIndex = 1;
      this.labelBuild.Text = "Build 15";
      this.labelBuild.TextAlign = ContentAlignment.MiddleLeft;
      this.labelVersion.BackColor = Color.Transparent;
      this.labelVersion.Font = new Font("Microsoft Sans Serif", 7f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelVersion.Location = new System.Drawing.Point(5, 223);
      this.labelVersion.Name = "labelVersion";
      this.labelVersion.NoAlign = false;
      this.labelVersion.NoEdit = false;
      this.labelVersion.NoUIModify = false;
      this.labelVersion.OriginalText = "Version ???  ";
      this.labelVersion.Size = new Size(86, 19);
      this.labelVersion.TabIndex = 0;
      this.labelVersion.Text = "Version ???  ";
      this.labelVersion.TextAlign = ContentAlignment.MiddleLeft;
      this.labelEdition.BackColor = Color.Transparent;
      this.labelEdition.Font = new Font("Microsoft Sans Serif", 7f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelEdition.Location = new System.Drawing.Point(232, 210);
      this.labelEdition.Name = "labelEdition";
      this.labelEdition.NoAlign = false;
      this.labelEdition.NoEdit = false;
      this.labelEdition.NoUIModify = false;
      this.labelEdition.OriginalText = "Edition State";
      this.labelEdition.Size = new Size(167, 16);
      this.labelEdition.TabIndex = 3;
      this.labelEdition.Text = "Edition State";
      this.labelEdition.TextAlign = ContentAlignment.MiddleRight;
      this.labelDatabase.BackColor = Color.Transparent;
      this.labelDatabase.Font = new Font("Microsoft Sans Serif", 7f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelDatabase.Location = new System.Drawing.Point(108, 210);
      this.labelDatabase.Name = "labelDatabase";
      this.labelDatabase.NoAlign = false;
      this.labelDatabase.NoEdit = false;
      this.labelDatabase.NoUIModify = false;
      this.labelDatabase.OriginalText = "Database 3.60.009";
      this.labelDatabase.Size = new Size(152, 16);
      this.labelDatabase.TabIndex = 2;
      this.labelDatabase.Text = "Database 3.60.009";
      this.labelDatabase.TextAlign = ContentAlignment.MiddleLeft;
      this.labelCopyright.BackColor = Color.Transparent;
      this.labelCopyright.Font = new Font("Microsoft Sans Serif", 7f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelCopyright.Location = new System.Drawing.Point(108, 224);
      this.labelCopyright.Name = "labelCopyright";
      this.labelCopyright.NoAlign = false;
      this.labelCopyright.NoEdit = false;
      this.labelCopyright.NoUIModify = false;
      this.labelCopyright.OriginalText = "CopyrightCopyrightCopyrightCopyrightCopyrightCopyrightCopyrightCopyrightCopyright";
      this.labelCopyright.Size = new Size(376, 16);
      this.labelCopyright.TabIndex = 4;
      this.labelCopyright.Text = "CopyrightCopyrightCopyrightCopyrightCopyrightCopyrightCopyrightCopyrightCopyright";
      this.labelCopyright.TextAlign = ContentAlignment.MiddleLeft;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(399, 299);
      this.Controls.Add((Control) this.panelAboutBox);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (AboutBox);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "About SIMS .net";
      this.panelAboutBox.ResumeLayout(false);
      this.panelAboutBox.PerformLayout();
      this.ResumeLayout(false);
    }

    private void buttonOK_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
