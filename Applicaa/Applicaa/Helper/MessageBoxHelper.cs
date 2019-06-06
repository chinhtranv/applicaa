﻿using System.Windows.Forms;

namespace Applicaa.Helper
{
    public class MessageBoxHelper
    {
        private const string caption = "SIMS Integartion";
        public static void ShowInfo(string messeages)
        {
            MessageBox.Show(messeages, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowError(string messeages)
        {
            MessageBox.Show(messeages, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
