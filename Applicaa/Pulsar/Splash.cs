// Decompiled with JetBrains decompiler
// Type: SIMS.UserInterfaces.Splash
// Assembly: Pulsar, Version=7.180.40.0, Culture=neutral, PublicKeyToken=21f532fe36bf9cd6
// MVID: 426271C6-CBAA-459D-A1E4-8EB841AEB1DD
// Assembly location: C:\Program Files (x86)\SIMS\SIMS .net\Pulsar.exe

using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace SIMS.UserInterfaces
{
  public class Splash : System.Windows.Forms.Form
  {
    private string version = "";
    private const string releaseState = "RELEASE";
    private PageSetupDialog pageSetupDialog1;
    private PageSetupDialog pageSetupDialog2;
    private System.Windows.Forms.Label labelCopyright;
    private System.Windows.Forms.Label labelLoading;
    private System.Windows.Forms.Label labelVersion;
    private Container components;
    private System.Windows.Forms.Label labelReleaseState;

    public Splash()
    {
      this.InitializeComponent();
      Assembly.GetExecutingAssembly();
      FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath);
      this.version = string.Format("{0}.{1}", (object) versionInfo.FileMajorPart, (object) versionInfo.FileMinorPart);
      this.labelVersion.Text = "Version " + this.version;
      this.labelCopyright.Text = versionInfo.LegalCopyright + ". All rights reserved";
      this.Refresh();
    }

    private void swapFontForLabels()
    {
      FontFamily family = new FontFamily("Tahoma");
      if (family == null)
        return;
      if (family.IsStyleAvailable(FontStyle.Regular))
        this.labelVersion.Font = new Font(family, 8.25f, FontStyle.Regular);
      if (!family.IsStyleAvailable(FontStyle.Bold))
        return;
      this.labelLoading.Font = new Font(family, 8.25f, FontStyle.Bold);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Splash));
      this.pageSetupDialog1 = new PageSetupDialog();
      this.pageSetupDialog2 = new PageSetupDialog();
      this.labelLoading = new System.Windows.Forms.Label();
      this.labelVersion = new System.Windows.Forms.Label();
      this.labelCopyright = new System.Windows.Forms.Label();
      this.labelReleaseState = new System.Windows.Forms.Label();
      this.SuspendLayout();
      this.labelLoading.BackColor = Color.Transparent;
      this.labelLoading.Font = new Font("Microsoft Sans Serif", 7.5f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelLoading.ForeColor = Color.SteelBlue;
      this.labelLoading.Location = new Point(47, 208);
      this.labelLoading.Name = "labelLoading";
      this.labelLoading.Size = new Size(309, 17);
      this.labelLoading.TabIndex = 7;
      this.labelLoading.Text = "Loading...";
      this.labelLoading.TextAlign = ContentAlignment.MiddleCenter;
      this.labelVersion.BackColor = Color.Transparent;
      this.labelVersion.Font = new Font("Microsoft Sans Serif", 7.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelVersion.Location = new Point(9, 223);
      this.labelVersion.Name = "labelVersion";
      this.labelVersion.Size = new Size(136, 16);
      this.labelVersion.TabIndex = 6;
      this.labelVersion.Text = "Version ???";
      this.labelVersion.TextAlign = ContentAlignment.MiddleLeft;
      this.labelCopyright.BackColor = Color.Transparent;
      this.labelCopyright.Font = new Font("Microsoft Sans Serif", 7.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.labelCopyright.Location = new Point(98, 223);
      this.labelCopyright.Name = "labelCopyright";
      this.labelCopyright.Size = new Size(298, 13);
      this.labelCopyright.TabIndex = 5;
      this.labelCopyright.Text = "© Capita Business Services Ltd 1984-2008. All rights reserved";
      this.labelCopyright.TextAlign = ContentAlignment.MiddleRight;
      this.labelReleaseState.AutoSize = true;
      this.labelReleaseState.BackColor = Color.Transparent;
      this.labelReleaseState.Font = new Font("Microsoft Sans Serif", 15f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.labelReleaseState.ForeColor = Color.FromArgb((int) byte.MaxValue, 128, 0);
      this.labelReleaseState.Location = new Point(20, 125);
      this.labelReleaseState.Name = "labelReleaseState";
      this.labelReleaseState.Size = new Size(0, 25);
      this.labelReleaseState.TabIndex = 8;
      this.labelReleaseState.Text = string.Format("{0} Release", (object) "RELEASE");
      this.labelReleaseState.Visible = false;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.BackColor = SystemColors.Window;
      this.BackgroundImage = (Image) componentResourceManager.GetObject("$this.BackgroundImage");
      this.BackgroundImageLayout = ImageLayout.Zoom;
      this.ClientSize = new Size(399, 299);
      this.ControlBox = false;
      this.Controls.Add((Control) this.labelReleaseState);
      this.Controls.Add((Control) this.labelCopyright);
      this.Controls.Add((Control) this.labelVersion);
      this.Controls.Add((Control) this.labelLoading);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Name = nameof (Splash);
      this.ShowInTaskbar = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
