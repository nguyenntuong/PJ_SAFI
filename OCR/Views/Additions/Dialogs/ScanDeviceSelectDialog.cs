﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OCR.Utils.Extensions.UIs;
using OCR.Utils.Helpers.DriverControls;

namespace OCR.Views.Additions.Dialogs
{
    public partial class ScanDeviceSelectDialog : Form
    {
        #region static
        public static DialogResult ShowCustomDialog(out string scannerID)
        {
            scannerID = "";
            using (ScanDeviceSelectDialog dialog = new ScanDeviceSelectDialog())
            {
                var diRes = dialog.ShowDialog();
                if (dialog.cbb_ScanDeviceLists.SelectedItem != null)
                    scannerID = dialog.cbb_ScanDeviceLists.SelectedItem.ToString();
                return diRes;
            }
        }
        #endregion
        #region instance
        private ScanDeviceSelectDialog()
        {
            InitializeComponent();
        }

        private void ScanDeviceSelectDialog_Load(object sender, EventArgs e)
        {
            var devices = WIAScannerControl.GetDevices();
            cbb_ScanDeviceLists.UpdateUI(devices, devices.Count > 0 ? devices[0] : null);
        }

        private void Btn_Apply_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Cbb_ScanDeviceLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cbb = sender as ComboBox;
            SetDefaultUI();
            if (cbb.SelectedItem != null)
            {
                var properties = WIAScannerControl.GetDevicesProperty(cbb.SelectedItem.ToString().Trim());
                if (properties != null)
                {
                    foreach (var p in properties)
                    {
                        lst_ScanProperties.Items.Add($"{p.Key}: {p.Value}");
                    }
                }
            }
        }

        private void SetDefaultUI()
        {
            lst_ScanProperties.Items.Clear();
        }
        #endregion
    }
}
