// Token: 0x02000022 RID: 34
public partial class Form1 : global::System.Windows.Forms.Form
{
	// Token: 0x060000C4 RID: 196 RVA: 0x000023ED File Offset: 0x000005ED
	protected override void Dispose(bool disposing)
	{
		if (disposing && this.icontainer_0 != null)
		{
			this.icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	// Token: 0x060000C5 RID: 197 RVA: 0x00005DE0 File Offset: 0x00003FE0
	private void InitializeComponent()
	{
		global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Form1));
		this.label8 = new global::System.Windows.Forms.Label();
		this.label7 = new global::System.Windows.Forms.Label();
		this.label6 = new global::System.Windows.Forms.Label();
		this.label5 = new global::System.Windows.Forms.Label();
		this.label4 = new global::System.Windows.Forms.Label();
		this.label3 = new global::System.Windows.Forms.Label();
		this.button5 = new global::System.Windows.Forms.Button();
		this.button4 = new global::System.Windows.Forms.Button();
		this.textBox3 = new global::System.Windows.Forms.TextBox();
		this.label9 = new global::System.Windows.Forms.Label();
		this.button3 = new global::System.Windows.Forms.Button();
		this.button2 = new global::System.Windows.Forms.Button();
		this.button1 = new global::System.Windows.Forms.Button();
		this.textBox2 = new global::System.Windows.Forms.TextBox();
		this.textBox1 = new global::System.Windows.Forms.TextBox();
		this.label2 = new global::System.Windows.Forms.Label();
		this.label1 = new global::System.Windows.Forms.Label();
		this.textBox4 = new global::System.Windows.Forms.TextBox();
		this.label10 = new global::System.Windows.Forms.Label();
		this.button6 = new global::System.Windows.Forms.Button();
		base.SuspendLayout();
		this.label8.AutoSize = true;
		this.label8.Location = new global::System.Drawing.Point(383, 154);
		this.label8.Name = "label8";
		this.label8.Size = new global::System.Drawing.Size(11, 12);
		this.label8.TabIndex = 52;
		this.label8.Text = "0";
		this.label7.AutoSize = true;
		this.label7.Location = new global::System.Drawing.Point(306, 154);
		this.label7.Name = "label7";
		this.label7.Size = new global::System.Drawing.Size(71, 12);
		this.label7.TabIndex = 51;
		this.label7.Text = "解密失败数:";
		this.label6.AutoSize = true;
		this.label6.Location = new global::System.Drawing.Point(232, 154);
		this.label6.Name = "label6";
		this.label6.Size = new global::System.Drawing.Size(11, 12);
		this.label6.TabIndex = 50;
		this.label6.Text = "0";
		this.label5.AutoSize = true;
		this.label5.Location = new global::System.Drawing.Point(149, 154);
		this.label5.Name = "label5";
		this.label5.Size = new global::System.Drawing.Size(77, 12);
		this.label5.TabIndex = 49;
		this.label5.Text = "解密成功数：";
		this.label4.AutoSize = true;
		this.label4.Location = new global::System.Drawing.Point(67, 154);
		this.label4.Name = "label4";
		this.label4.Size = new global::System.Drawing.Size(11, 12);
		this.label4.TabIndex = 48;
		this.label4.Text = "0";
		this.label3.AutoSize = true;
		this.label3.Location = new global::System.Drawing.Point(8, 154);
		this.label3.Name = "label3";
		this.label3.Size = new global::System.Drawing.Size(53, 12);
		this.label3.TabIndex = 47;
		this.label3.Text = "文件数：";
		this.button5.Location = new global::System.Drawing.Point(495, 65);
		this.button5.Name = "button5";
		this.button5.Size = new global::System.Drawing.Size(75, 34);
		this.button5.TabIndex = 46;
		this.button5.Text = "加密";
		this.button5.UseVisualStyleBackColor = true;
		this.button5.Click += new global::System.EventHandler(this.button5_Click);
		this.button4.Location = new global::System.Drawing.Point(496, 15);
		this.button4.Name = "button4";
		this.button4.Size = new global::System.Drawing.Size(75, 34);
		this.button4.TabIndex = 45;
		this.button4.Text = "解密";
		this.button4.UseVisualStyleBackColor = true;
		this.button4.Click += new global::System.EventHandler(this.button4_Click);
		this.textBox3.Location = new global::System.Drawing.Point(90, 84);
		this.textBox3.Name = "textBox3";
		this.textBox3.Size = new global::System.Drawing.Size(305, 21);
		this.textBox3.TabIndex = 44;
		this.label9.AutoSize = true;
		this.label9.Location = new global::System.Drawing.Point(7, 87);
		this.label9.Name = "label9";
		this.label9.Size = new global::System.Drawing.Size(77, 12);
		this.label9.TabIndex = 43;
		this.label9.Text = "加密后路径：";
		this.button3.Location = new global::System.Drawing.Point(402, 84);
		this.button3.Name = "button3";
		this.button3.Size = new global::System.Drawing.Size(75, 23);
		this.button3.TabIndex = 42;
		this.button3.Text = "打开文件夹";
		this.button3.UseVisualStyleBackColor = true;
		this.button3.Click += new global::System.EventHandler(this.button3_Click);
		this.button2.Location = new global::System.Drawing.Point(402, 46);
		this.button2.Name = "button2";
		this.button2.Size = new global::System.Drawing.Size(75, 23);
		this.button2.TabIndex = 41;
		this.button2.Text = "打开文件夹";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new global::System.EventHandler(this.button2_Click);
		this.button1.Location = new global::System.Drawing.Point(402, 12);
		this.button1.Name = "button1";
		this.button1.Size = new global::System.Drawing.Size(75, 23);
		this.button1.TabIndex = 40;
		this.button1.Text = "打开文件夹";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new global::System.EventHandler(this.button1_Click);
		this.textBox2.Location = new global::System.Drawing.Point(91, 48);
		this.textBox2.Name = "textBox2";
		this.textBox2.Size = new global::System.Drawing.Size(305, 21);
		this.textBox2.TabIndex = 39;
		this.textBox1.Location = new global::System.Drawing.Point(91, 12);
		this.textBox1.Name = "textBox1";
		this.textBox1.Size = new global::System.Drawing.Size(305, 21);
		this.textBox1.TabIndex = 38;
		this.label2.AutoSize = true;
		this.label2.Location = new global::System.Drawing.Point(8, 51);
		this.label2.Name = "label2";
		this.label2.Size = new global::System.Drawing.Size(77, 12);
		this.label2.TabIndex = 37;
		this.label2.Text = "解密后路径：";
		this.label1.AutoSize = true;
		this.label1.Location = new global::System.Drawing.Point(8, 15);
		this.label1.Name = "label1";
		this.label1.Size = new global::System.Drawing.Size(77, 12);
		this.label1.TabIndex = 36;
		this.label1.Text = "原文件路径：";
		this.textBox4.AllowDrop = true;
		this.textBox4.Location = new global::System.Drawing.Point(91, 121);
		this.textBox4.Name = "textBox4";
		this.textBox4.Size = new global::System.Drawing.Size(305, 21);
		this.textBox4.TabIndex = 54;
		this.textBox4.DragDrop += new global::System.Windows.Forms.DragEventHandler(this.textBox4_DragDrop);
		this.textBox4.DragEnter += new global::System.Windows.Forms.DragEventHandler(this.textBox4_DragEnter);
		this.label10.AutoSize = true;
		this.label10.Location = new global::System.Drawing.Point(8, 124);
		this.label10.Name = "label10";
		this.label10.Size = new global::System.Drawing.Size(77, 12);
		this.label10.TabIndex = 53;
		this.label10.Text = "效验Ab文件：";
		this.button6.Location = new global::System.Drawing.Point(495, 113);
		this.button6.Name = "button6";
		this.button6.Size = new global::System.Drawing.Size(75, 34);
		this.button6.TabIndex = 55;
		this.button6.Text = "效验";
		this.button6.UseVisualStyleBackColor = true;
		this.button6.Click += new global::System.EventHandler(this.button6_Click);
		base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new global::System.Drawing.Size(582, 186);
		base.Controls.Add(this.button6);
		base.Controls.Add(this.textBox4);
		base.Controls.Add(this.label10);
		base.Controls.Add(this.label8);
		base.Controls.Add(this.label7);
		base.Controls.Add(this.label6);
		base.Controls.Add(this.label5);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.button5);
		base.Controls.Add(this.button4);
		base.Controls.Add(this.textBox3);
		base.Controls.Add(this.label9);
		base.Controls.Add(this.button3);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.textBox2);
		base.Controls.Add(this.textBox1);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
		base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.Name = "Form1";
		this.Text = "JuFengLongTools";
		base.ResumeLayout(false);
		base.PerformLayout();
	}

	// Token: 0x0400008C RID: 140
	private global::System.ComponentModel.IContainer icontainer_0 = null;

	// Token: 0x0400008D RID: 141
	private global::System.Windows.Forms.Label label8;

	// Token: 0x0400008E RID: 142
	private global::System.Windows.Forms.Label label7;

	// Token: 0x0400008F RID: 143
	private global::System.Windows.Forms.Label label6;

	// Token: 0x04000090 RID: 144
	private global::System.Windows.Forms.Label label5;

	// Token: 0x04000091 RID: 145
	private global::System.Windows.Forms.Label label4;

	// Token: 0x04000092 RID: 146
	private global::System.Windows.Forms.Label label3;

	// Token: 0x04000093 RID: 147
	private global::System.Windows.Forms.Button button5;

	// Token: 0x04000094 RID: 148
	private global::System.Windows.Forms.Button button4;

	// Token: 0x04000095 RID: 149
	private global::System.Windows.Forms.TextBox textBox3;

	// Token: 0x04000096 RID: 150
	private global::System.Windows.Forms.Label label9;

	// Token: 0x04000097 RID: 151
	private global::System.Windows.Forms.Button button3;

	// Token: 0x04000098 RID: 152
	private global::System.Windows.Forms.Button button2;

	// Token: 0x04000099 RID: 153
	private global::System.Windows.Forms.Button button1;

	// Token: 0x0400009A RID: 154
	private global::System.Windows.Forms.TextBox textBox2;

	// Token: 0x0400009B RID: 155
	private global::System.Windows.Forms.TextBox textBox1;

	// Token: 0x0400009C RID: 156
	private global::System.Windows.Forms.Label label2;

	// Token: 0x0400009D RID: 157
	private global::System.Windows.Forms.Label label1;

	// Token: 0x0400009E RID: 158
	private global::System.Windows.Forms.TextBox textBox4;

	// Token: 0x0400009F RID: 159
	private global::System.Windows.Forms.Label label10;

	// Token: 0x040000A0 RID: 160
	private global::System.Windows.Forms.Button button6;
}
