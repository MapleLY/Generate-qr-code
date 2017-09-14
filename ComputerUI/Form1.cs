using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ZXing.QrCode;
using ZXing;
using ZXing.Common;
using ZXing.Rendering;  
namespace ComputerUI
{
    public partial class Form1 : Form
    {
        EncodingOptions options = null;
        BarcodeWriter writer = null; 
        public Form1()
        {
            InitializeComponent();

            options = new QrCodeEncodingOptions
             {
                 DisableECI = true,
                 CharacterSet = "UTF-8",
                 Width = pictureBox2.Width,
                 Height = pictureBox2.Height
             }; 
            writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options; 
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("输入内容不能为空！");
                return;
            }
            Bitmap bitmap = writer.Write(textBox1.Text);
            pictureBox2.Image = bitmap;  
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "请输入网址")
            {
                textBox1.Text = "";
            }
            textBox1.ForeColor = Color.Black;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Title = "选择保存文件位置";
            sf.Filter = "保存图片(*.jpg) |*.jpg|所有文件(*.*) |*.*";
            //设置默认文件类型显示顺序
            sf.FilterIndex = 1;
            //保存对话框是否记忆上次打开的目录
            sf.RestoreDirectory = true;
            if (sf.ShowDialog() == DialogResult.OK)
            {
                Image im = this.pictureBox2.Image;
                //获得文件路径
                string localFilePath = sf.FileName.ToString();
                if (sf.FileName != "")
                {
                    string fileNameExt = localFilePath.Substring(localFilePath.LastIndexOf("\\") + 1);//获取文件名，不带路径
                    // newFileName = fileNameExt+DateTime.Now.ToString("yyyyMMdd")  ;//给文件名后加上时间
                    string FilePath = localFilePath.Substring(0, localFilePath.LastIndexOf("."));  //获取文件路径，带文件名,不带后缀
                    string fn = sf.FileName;
                    pictureBox2.Image.Save(FilePath + "-" + DateTime.Now.ToString("yyyyMMdd") + ".jpg");

                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
