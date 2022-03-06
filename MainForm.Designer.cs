namespace JumpingPlatformGame {
	partial class MainForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.worldPanel = new System.Windows.Forms.Panel();
            this.jumpingPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.customer_listBox = new System.Windows.Forms.ListBox();
            this.button_add_customer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // worldPanel
            // 
            this.worldPanel.BackColor = System.Drawing.Color.White;
            this.worldPanel.Location = new System.Drawing.Point(12, 41);
            this.worldPanel.Name = "worldPanel";
            this.worldPanel.Size = new System.Drawing.Size(696, 416);
            this.worldPanel.TabIndex = 0;
            // 
            // jumpingPanel
            // 
            this.jumpingPanel.BackColor = System.Drawing.Color.Khaki;
            this.jumpingPanel.Location = new System.Drawing.Point(12, 463);
            this.jumpingPanel.Name = "jumpingPanel";
            this.jumpingPanel.Size = new System.Drawing.Size(850, 96);
            this.jumpingPanel.TabIndex = 1;
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 40;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // customer_listBox
            // 
            this.customer_listBox.FormattingEnabled = true;
            this.customer_listBox.Location = new System.Drawing.Point(713, 41);
            this.customer_listBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.customer_listBox.Name = "customer_listBox";
            this.customer_listBox.Size = new System.Drawing.Size(152, 329);
            this.customer_listBox.TabIndex = 6;
            // 
            // button_add_customer
            // 
            this.button_add_customer.Location = new System.Drawing.Point(713, 374);
            this.button_add_customer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_add_customer.Name = "button_add_customer";
            this.button_add_customer.Size = new System.Drawing.Size(151, 84);
            this.button_add_customer.TabIndex = 7;
            this.button_add_customer.Text = "Add Customer Boxcar";
            this.button_add_customer.UseVisualStyleBackColor = true;
            this.button_add_customer.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 571);
            this.Controls.Add(this.button_add_customer);
            this.Controls.Add(this.customer_listBox);
            this.Controls.Add(this.jumpingPanel);
            this.Controls.Add(this.worldPanel);
            this.Name = "MainForm";
            this.Text = "Jumping Platform Game";
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel worldPanel;
		private System.Windows.Forms.FlowLayoutPanel jumpingPanel;
		private System.Windows.Forms.Timer updateTimer;
		private System.Windows.Forms.ListBox customer_listBox;
		private System.Windows.Forms.Button button_add_customer;
	}
}

