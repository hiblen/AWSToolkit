namespace AwsTools
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboInstances = new System.Windows.Forms.ComboBox();
            this.lblRegion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblDns = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblAccount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboInstances
            // 
            this.cboInstances.FormattingEnabled = true;
            this.cboInstances.Location = new System.Drawing.Point(116, 46);
            this.cboInstances.Name = "cboInstances";
            this.cboInstances.Size = new System.Drawing.Size(182, 21);
            this.cboInstances.TabIndex = 0;
            this.cboInstances.SelectedIndexChanged += new System.EventHandler(this.cboInstances_SelectedIndexChanged);
            // 
            // lblRegion
            // 
            this.lblRegion.AutoSize = true;
            this.lblRegion.Location = new System.Drawing.Point(12, 9);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(64, 13);
            this.lblRegion.TabIndex = 1;
            this.lblRegion.Tag = "Region : {0}";
            this.lblRegion.Text = "Region : {0}";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Tag = "";
            this.label2.Text = "Instance";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(28, 84);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(55, 13);
            this.lblState.TabIndex = 3;
            this.lblState.Tag = "State : {0}";
            this.lblState.Text = "State : {0}";
            // 
            // lblDns
            // 
            this.lblDns.AutoSize = true;
            this.lblDns.Location = new System.Drawing.Point(28, 111);
            this.lblDns.Name = "lblDns";
            this.lblDns.Size = new System.Drawing.Size(85, 13);
            this.lblDns.TabIndex = 4;
            this.lblDns.Tag = "Public DNS : {0}";
            this.lblDns.Text = "Public DNS : {0}";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(31, 140);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(116, 140);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(304, 44);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblAccount
            // 
            this.lblAccount.AutoSize = true;
            this.lblAccount.Location = new System.Drawing.Point(247, 9);
            this.lblAccount.Name = "lblAccount";
            this.lblAccount.Size = new System.Drawing.Size(70, 13);
            this.lblAccount.TabIndex = 8;
            this.lblAccount.Tag = "Account : {0}";
            this.lblAccount.Text = "Account : {0}";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 346);
            this.Controls.Add(this.lblAccount);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblDns);
            this.Controls.Add(this.lblState);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblRegion);
            this.Controls.Add(this.cboInstances);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboInstances;
        private System.Windows.Forms.Label lblRegion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblDns;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblAccount;

    }
}

