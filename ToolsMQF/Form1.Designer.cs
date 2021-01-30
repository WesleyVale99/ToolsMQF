namespace ToolsMQF
{
	// Token: 0x02000002 RID: 2
	public partial class Form1 : global::System.Windows.Forms.Form
	{
		// Token: 0x06000004 RID: 4 RVA: 0x000026A0 File Offset: 0x000008A0
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000026D8 File Offset: 0x000008D8
		private void InitializeComponent()
		{
			this.openFileDialog1 = new global::System.Windows.Forms.OpenFileDialog();
			this.button1 = new global::System.Windows.Forms.Button();
			this.Save = new global::System.Windows.Forms.Button();
			this.txtPath = new global::System.Windows.Forms.TextBox();
			this.label1 = new global::System.Windows.Forms.Label();
			base.SuspendLayout();
			this.openFileDialog1.Filter = "MQF File (*.Mqf|*.mqf";
			this.button1.Location = new global::System.Drawing.Point(343, 12);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(37, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.Save.Location = new global::System.Drawing.Point(386, 12);
			this.Save.Name = "Save";
			this.Save.Size = new global::System.Drawing.Size(57, 23);
			this.Save.TabIndex = 1;
			this.Save.Text = "Save";
			this.Save.UseVisualStyleBackColor = true;
			this.Save.Click += new global::System.EventHandler(this.button2_Click);
			this.txtPath.Enabled = false;
			this.txtPath.Location = new global::System.Drawing.Point(13, 14);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new global::System.Drawing.Size(324, 20);
			this.txtPath.TabIndex = 2;
			this.label1.AutoSize = true;
			this.label1.Location = new global::System.Drawing.Point(12, 39);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(40, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "waiting";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(447, 53);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.txtPath);
			base.Controls.Add(this.Save);
			base.Controls.Add(this.button1);
			base.MaximizeBox = false;
			base.Name = "Form1";
			this.Text = "Tools MQF (Build 001)     [ By: Wesley Vale ]";
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000001 RID: 1
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000002 RID: 2
		private global::System.Windows.Forms.OpenFileDialog openFileDialog1;

		// Token: 0x04000003 RID: 3
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000004 RID: 4
		private global::System.Windows.Forms.Button Save;

		// Token: 0x04000005 RID: 5
		private global::System.Windows.Forms.TextBox txtPath;

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.Label label1;
	}
}
