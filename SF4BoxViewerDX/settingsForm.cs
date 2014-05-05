using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SF4BoxViewerDX
{
    public partial class settingsForm : Form
    {
        public settingsForm()
        {
            InitializeComponent();
            loadSettings();

            for (int i = 0x170; i <= 0x6000; i += 0xa0)
            {
      
                   //  lbBoxes.Items.Add("0x" + String.Format("{0:X}", i));
                lbBoxes.Items.Add(i.ToString());
            }

            lbAddedBoxes.Sorted = true;
            lbBoxes.Sorted = true;


        }

        //Below are for hotkeys

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd,
          int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);




        protected override void WndProc(ref Message m)
        {
            int id = m.WParam.ToInt32();
            if (m.Msg == 0x0312)

                if (id == 0)
                {
                    bPause.PerformClick();
                }
                else if (id == 1)
                {
                    bNextFrame.PerformClick();
                }
            base.WndProc(ref m);
        }

        //Above are for hotkeys
        
        

        private void cbP1Hit_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.P1Hit = cbP1Hit.Checked;
            Properties.Settings.Default.Save();         
        }


        private void loadSettings()
        {
            cbP1Hit.Checked = Properties.Settings.Default.P1Hit;
            cbP2Hit.Checked = Properties.Settings.Default.P2Hit;

            cbP1Grab.Checked = Properties.Settings.Default.P1Grab;
            cbP2Grab.Checked = Properties.Settings.Default.P2Grab;

            cbP1Projectile.Checked = Properties.Settings.Default.P1Projectile;
            cbP2Projectile.Checked = Properties.Settings.Default.P2Projectile;

            cbP1Prox.Checked = Properties.Settings.Default.P1Prox;
            cbP2Prox.Checked = Properties.Settings.Default.P2Prox;

            cbP1Basic.Checked = Properties.Settings.Default.P1Basic;
            cbP2Basic.Checked = Properties.Settings.Default.P2Basic;

            cbShowInfo.Checked = Properties.Settings.Default.showInfo;


            cbVsync.Checked = Properties.Settings.Default.vsync;
            cbSteam.Checked = Properties.Settings.Default.steam;
        }

        private void cbP2Hit_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.P2Hit = cbP2Hit.Checked;
            Properties.Settings.Default.Save();  
        }

        private void settingsForm_Load(object sender, EventArgs e)
        {
            RegisterHotKey(this.Handle, 0, 0, (int)Keys.Tab);            //hotkey for pause
            RegisterHotKey(this.Handle, 1, 2, (int)Keys.Tab);             //for next frame
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            if (lbBoxes.SelectedItem != null)
            {
                lbAddedBoxes.Items.Add(lbBoxes.SelectedItem);               
                lbBoxes.Items.Remove(lbBoxes.SelectedItem);
                try
                {
                    lbBoxes.SelectedIndex = lbBoxes.SelectedIndex + 1;
                }
                catch { }
                var array = lbAddedBoxes.Items.Cast<String>().ToArray();
                Form1.hurtboxes = array.Select(I => Convert.ToInt32(I)).ToArray(); 
            }
        }

        private void bRemove_Click(object sender, EventArgs e)
        {
            if (lbAddedBoxes.SelectedItem != null)
            {
                lbBoxes.Items.Add(lbAddedBoxes.SelectedItem);          
                lbAddedBoxes.Items.Remove(lbAddedBoxes.SelectedItem);
                try
                {
                    lbAddedBoxes.SelectedIndex = lbAddedBoxes.SelectedIndex + 1;
                }
                catch { }
                var array = lbAddedBoxes.Items.Cast<String>().ToArray();
                Form1.hurtboxes = array.Select(I => Convert.ToInt32(I)).ToArray(); 
            }
        }

        private void cbVsync_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVsync.Checked != Properties.Settings.Default.vsync)
            {
                Properties.Settings.Default.vsync = cbVsync.Checked;
                Properties.Settings.Default.Save();
                MessageBox.Show("You will need to restart SF4 Box Viewer before the change take effect", "Restart Required");
            }
        }

        private void cbSteam_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.steam = cbSteam.Checked;
            Properties.Settings.Default.Save();
            if (Properties.Settings.Default.steam)
            {
                readMemory.steamoffset = 0x10c0;
            }
            else
            {
                readMemory.steamoffset = 0x0;
            }
        }

        private void cbP1Grab_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.P1Grab = cbP1Grab.Checked;
            Properties.Settings.Default.Save();  
        }

        private void cbP2Grab_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.P2Grab = cbP2Grab.Checked;
            Properties.Settings.Default.Save();  
        }

        private void cbP1Projectile_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.P1Projectile = cbP1Projectile.Checked;
            Properties.Settings.Default.Save();  
        }

        private void cbP2Projectile_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.P2Projectile = cbP2Projectile.Checked;
            Properties.Settings.Default.Save();  
        }

        private void cbP1Prox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.P1Prox = cbP1Prox.Checked;
            Properties.Settings.Default.Save();  
        }

        private void cbP2Prox_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.P2Prox = cbP2Prox.Checked;
            Properties.Settings.Default.Save();  
        }

        private void cbP1Basic_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.P1Basic = cbP1Basic.Checked;
            Properties.Settings.Default.Save();
        }

        private void cbP2Basic_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.P2Basic = cbP2Basic.Checked;
            Properties.Settings.Default.Save();  
        }

        protected override void OnClosed(EventArgs e)
        {
            Application.Exit();
        }

        private void bAbout_Click(object sender, EventArgs e)
        {
            about about = new about();
            about.ShowDialog();
        }

        private void cbShowInfo_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.showInfo = cbShowInfo.Checked;
            Properties.Settings.Default.Save();  
        }

        private void bPause_Click(object sender, EventArgs e)
        {
            if (readMemory.paused == false)
            {
                readMemory.PauseGame(true);
                bPause.Text = "Unpause";
            }
            else
            {
                readMemory.PauseGame(false);
                bPause.Text = "Pause";
            }
        }

        private void bNextFrame_Click(object sender, EventArgs e)
        {
            if (readMemory.paused)
            {
                readMemory.setPauseState(0);
                readMemory.WaitFrames(1);
                readMemory.setPauseState(1);
            }
            else
            {
                MessageBox.Show("This function is only available while the pause function is activated.", "Next Frame function not available", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
