using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3DES
{
    public partial class MainForm : Form
    {
        List<Classes.Message> historyList = new List<Classes.Message> { };
        int count = 1;
        bool encode = true;
        public MainForm()
        {
            InitializeComponent();
        }

        private void EncodeBtn_Click(object sender, EventArgs e)
        {
            if (encode)
            {
                if (Key1.Text == "" || Key2.Text == "" || Key3.Text == "" || InMsg.Text == "" || IsRussian(InMsg.Text)) { MessageBox.Show("Wrong input!", "Trouble"); }
                else 
                { 
                    historyList.Add(new Classes.Message(InMsg.Text, Key1.Text, Key2.Text, Key3.Text, encode)); History.Items.Add($"{count} Сообщение"); count++;
                    OutMsg.Text = new Classes.Message(InMsg.Text, Key1.Text, Key2.Text, Key3.Text, encode).encryptedMsg;
                }
            }
            else
            {
                if (Key1.Text == "" || Key2.Text == "" || Key3.Text == "" || InMsg.Text == "") { MessageBox.Show("Wrong input!", "Trouble"); }
                else 
                {
                    historyList.Add(new Classes.Message(InMsg.Text, Key1.Text, Key2.Text, Key3.Text, encode)); History.Items.Add($"{count} Сообщение"); count++;
                    OutMsg.Text = new Classes.Message(InMsg.Text, Key1.Text, Key2.Text, Key3.Text, encode).decryptedMsg;
                }
            }

        }

        private void History_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (historyList[History.SelectedIndex].mode)
            {
                RecKey1.Text = historyList[History.SelectedIndex].key1;
                RecKey2.Text = historyList[History.SelectedIndex].key2;
                RecKey3.Text = historyList[History.SelectedIndex].key3;
                RecInMsg.Text = historyList[History.SelectedIndex].msg;
                RecOutMsg.Text = historyList[History.SelectedIndex].encryptedMsg;
            }
            else
            {
                RecKey1.Text = historyList[History.SelectedIndex].key1;
                RecKey2.Text = historyList[History.SelectedIndex].key2;
                RecKey3.Text = historyList[History.SelectedIndex].key3;
                RecInMsg.Text = historyList[History.SelectedIndex].msg;
                RecOutMsg.Text = historyList[History.SelectedIndex].decryptedMsg;
            }
        }

        private void EncodeMode_Click(object sender, EventArgs e)
        {
            encode = true;
            OutMsgLabel.Text = "Закодированное сообщение:";
            EncodeBtn.Text = "Закодировать";
        }

        private void DecodeMode_Click(object sender, EventArgs e)
        {
            encode = false;
            OutMsgLabel.Text = "Раскодированное сообщение:";
            EncodeBtn.Text = "Раскодировать";
        }
        private bool IsRussian(string str)
        {
            char[] chr = str.ToCharArray();
            for (int i = 0; i < chr.Length; i++)
            {
                if (chr[i] >= 'А' && chr[i] <= 'я')
                    return true;
            }
            return false;
        }
    }
}
