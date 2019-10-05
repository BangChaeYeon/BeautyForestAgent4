using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace BeautyForestAgent
{
    public partial class FormMemo : Form
    {
        public FormMemo()
        {
            InitializeComponent();
        }

        private void BtnReadFileSelect_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openFileDlg.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    this.txtReadFile.Text = this.openFileDlg.FileName;
                    break;
                case DialogResult.Cancel:
                    MessageBox.Show("취소하셨습니다", "알림");
                    break;
            }


        }

        private void BtnReadText_Click(object sender, EventArgs e)
        {
            if (txtReadFile.Text == "")
            {
                MessageBox.Show("읽을 파일을 선택해 주세요", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!File.Exists(txtReadFile.Text))
            {
                MessageBox.Show("읽을 파일이 없습니다", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (StreamReader sr = new StreamReader(this.txtReadFile.Text))
            {
                this.txtReadText.Text = sr.ReadToEnd();
            }

        }

        private void BtnWriteFileSelect_Click(object sender, EventArgs e)
        {
            DialogResult result = this.saveFileDlg.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    this.txtWriteFile.Text = this.saveFileDlg.FileName;
                    break;
                case DialogResult.Cancel:
                    MessageBox.Show("취소하셨습니다", "알림");
                    break;
            }

        }

        private void BtnWriteText_Click(object sender, EventArgs e)
        {
            if (txtWriteFile.Text == "")
            {
                MessageBox.Show("저장할 파일을 선택해 주세요", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(this.txtWriteFile.Text))
                {
                    sw.WriteLine(this.txtWriteText.Text);
                }
                MessageBox.Show("파일 저장 성공", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("파일 저장에 실패했습니다", "에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
