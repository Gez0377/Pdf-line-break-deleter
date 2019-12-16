// linespaceDeleter.Form1
using linespaceDeleter;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form
{
	private string buff;

	private HotKeys h = new HotKeys();

	private IContainer components = null;

	private Button button1;

	private Button button2;

	private Label label1;

	private Button button3;

	private TextBox textBox1;

	private Label label2;

	private Label label3;

	private TextBox textBox2;

	private RadioButton radioButton1;

	public Form1()
	{
		InitializeComponent();
	}

	private void button1_Click(object sender, EventArgs e)
	{
		IDataObject dataObject = Clipboard.GetDataObject();
		if (dataObject.GetDataPresent(DataFormats.Text))
		{
			string text = (string)dataObject.GetData(DataFormats.Text);
			if (radioButton1.Checked)
			{
				buff = text.Replace("\r\n", " ").Replace(textBox1.Text, textBox2.Text);
			}
			else
			{
				buff = text.Replace("\r\n", " ");
			}
			Clipboard.SetDataObject(buff);
			label1.Text = "已复制到剪贴板";
		}
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		base.MaximizeBox = false;
	}

	private void button2_Click(object sender, EventArgs e)
	{
		h.Regist(base.Handle, 2, Keys.D, CallBack);
		label1.Text = "快捷键已启动";
	}

	private void button3_Click(object sender, EventArgs e)
	{
		h.UnRegist(base.Handle, CallBack);
		label1.Text = "快捷键已关闭";
	}

	protected override void WndProc(ref Message m)
	{
		h.ProcessHotKey(m);
		base.WndProc(ref m);
	}

	public void CallBack()
	{
		button1_Click(null, null);
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		button1 = new System.Windows.Forms.Button();
		button2 = new System.Windows.Forms.Button();
		label1 = new System.Windows.Forms.Label();
		button3 = new System.Windows.Forms.Button();
		textBox1 = new System.Windows.Forms.TextBox();
		label2 = new System.Windows.Forms.Label();
		label3 = new System.Windows.Forms.Label();
		textBox2 = new System.Windows.Forms.TextBox();
		radioButton1 = new System.Windows.Forms.RadioButton();
		SuspendLayout();
		button1.Location = new System.Drawing.Point(12, 12);
		button1.Name = "button1";
		button1.Size = new System.Drawing.Size(154, 23);
		button1.TabIndex = 0;
		button1.Text = "处理（ctrl+d）";
		button1.UseVisualStyleBackColor = true;
		button1.Click += new System.EventHandler(button1_Click);
		button2.Location = new System.Drawing.Point(197, 12);
		button2.Name = "button2";
		button2.Size = new System.Drawing.Size(75, 23);
		button2.TabIndex = 1;
		button2.Text = "快捷键打开";
		button2.UseVisualStyleBackColor = true;
		button2.Click += new System.EventHandler(button2_Click);
		label1.AutoSize = true;
		label1.Location = new System.Drawing.Point(12, 116);
		label1.Name = "label1";
		label1.Size = new System.Drawing.Size(53, 12);
		label1.TabIndex = 2;
		label1.Text = "准备工作";
		button3.Location = new System.Drawing.Point(197, 39);
		button3.Name = "button3";
		button3.Size = new System.Drawing.Size(75, 23);
		button3.TabIndex = 3;
		button3.Text = "快捷键卸载";
		button3.UseVisualStyleBackColor = true;
		button3.Click += new System.EventHandler(button3_Click);
		textBox1.Location = new System.Drawing.Point(14, 76);
		textBox1.Name = "textBox1";
		textBox1.Size = new System.Drawing.Size(72, 21);
		textBox1.TabIndex = 4;
		label2.AutoSize = true;
		label2.Location = new System.Drawing.Point(90, 59);
		label2.Name = "label2";
		label2.Size = new System.Drawing.Size(41, 12);
		label2.TabIndex = 5;
		label2.Text = "替代词";
		label3.AutoSize = true;
		label3.Location = new System.Drawing.Point(12, 59);
		label3.Name = "label3";
		label3.Size = new System.Drawing.Size(41, 12);
		label3.TabIndex = 6;
		label3.Text = "查找词";
		textBox2.Location = new System.Drawing.Point(92, 76);
		textBox2.Name = "textBox2";
		textBox2.Size = new System.Drawing.Size(74, 21);
		textBox2.TabIndex = 7;
		radioButton1.AutoSize = true;
		radioButton1.Location = new System.Drawing.Point(177, 81);
		radioButton1.Name = "radioButton1";
		radioButton1.Size = new System.Drawing.Size(71, 16);
		radioButton1.TabIndex = 8;
		radioButton1.TabStop = true;
		radioButton1.Text = "使用替代";
		radioButton1.UseVisualStyleBackColor = true;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(284, 137);
		base.Controls.Add(radioButton1);
		base.Controls.Add(textBox2);
		base.Controls.Add(label3);
		base.Controls.Add(label2);
		base.Controls.Add(textBox1);
		base.Controls.Add(button3);
		base.Controls.Add(label1);
		base.Controls.Add(button2);
		base.Controls.Add(button1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.Name = "Form1";
		Text = "删除换行符";
		base.Load += new System.EventHandler(Form1_Load);
		ResumeLayout(false);
		PerformLayout();
	}
}
