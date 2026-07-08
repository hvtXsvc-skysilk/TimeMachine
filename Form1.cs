using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeMachine
{
    public partial class Form1 : Form
    {
        public int index = -1;
        public Timer progressTimer;
        public int totalSec;
        public int elapsedSec;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            textBox1.Visible=false;
            progressTimer = new Timer();
            progressTimer.Interval = 1000;
            progressTimer.Tick += ProgressTimer_Tick;
        }
        public void StartProgress(int seconds)
        {
            if (seconds < 0)
            {
                MessageBox.Show("秒数不能为0","错误",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
            }
            try
            {
                totalSec = seconds;
                elapsedSec = 0;
                progressFill.Width = 0;
                progressTimer.Start();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("数值过大！","错误");
            }

        }
        public void ProgressTimer_Tick(object sender, EventArgs e)
        {
            elapsedSec++;
            double progress = Math.Min(1.0,(double)elapsedSec/totalSec);
            int fillWidth = (int)(progressBackground.Width * progress);
            progressFill.Width = fillWidth;
            if (progress >= 1.0)
            {
                progressTimer.Stop();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = comboBox1.SelectedIndex;
            if (index == 0)
            {
                textBox1.Visible = true;
            }
            else
            {
                textBox1.Visible = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            async Task DelayInChunks(int Sec)
            {
                while (Sec > 0)
                {
                    int wait = Math.Min(1, Sec);
                    await Task.Delay(TimeSpan.FromSeconds(wait));
                    Sec -= wait;
                }
            }

            switch (index)
            {
                case -1:
                    MessageBox.Show("请选择一个选项", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;

                case 0:
                    {
                        string input = textBox1.Text;
                        if (string.IsNullOrWhiteSpace(input))
                        {
                            MessageBox.Show("请输入一个有效的数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (!int.TryParse(input, out int seconds))
                        {
                            MessageBox.Show("请输入一个有效的数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (seconds < 0)
                        {
                            MessageBox.Show("请输入一个非负的数字", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        StartProgress(seconds);
                        await DelayInChunks(seconds);                    // 原：await Task.Delay(TimeSpan.FromSeconds(seconds));
                        MessageBox.Show($"已穿越到{seconds}秒后", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;

                case 1:
                    StartProgress(5);
                    await DelayInChunks(5);                              // 原：await Task.Delay(TimeSpan.FromSeconds(5));
                    MessageBox.Show("已穿越到5秒后", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case 2:
                    StartProgress(10);
                    await DelayInChunks(10);
                    MessageBox.Show("已穿越到10秒后", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case 3:
                    StartProgress(60);
                    await DelayInChunks(60);
                    MessageBox.Show("已穿越到一分钟后", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case 4:
                    StartProgress(180);
                    await DelayInChunks(180);
                    MessageBox.Show("已穿越到三分钟后", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case 5:
                    StartProgress(600);
                    await DelayInChunks(600);
                    MessageBox.Show("已穿越到十分钟后", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case 6:
                    StartProgress(3600);
                    await DelayInChunks(3600);
                    MessageBox.Show("已穿越到一小时后", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case 7:
                    StartProgress(36000);
                    await DelayInChunks(36000);
                    MessageBox.Show("已穿越到十小时后", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case 8:
                    StartProgress(30 * 24 * 3600);
                    await DelayInChunks(30 * 24 * 3600);
                    MessageBox.Show("已穿越到一个月后", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case 9:
                    StartProgress(3 * 30 * 24 * 3600);
                    await DelayInChunks(3 * 30 * 24 * 3600);
                    MessageBox.Show("已穿越到三个月后", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case 10:
                    StartProgress(365 * 24 * 3600);
                    await DelayInChunks(365 * 24 * 3600);
                    MessageBox.Show("已穿越到一年后", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;

                case 11:
                    StartProgress(10 * 365 * 24 * 3600);
                    await DelayInChunks(10 * 365 * 24 * 3600);
                    MessageBox.Show("已穿越到十年后", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
