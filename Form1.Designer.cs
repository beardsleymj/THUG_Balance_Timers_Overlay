namespace THUG_Balance_Timers_Overlay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.manualLabel = new System.Windows.Forms.Label();
            this.grindLabel = new System.Windows.Forms.Label();
            this.manual = new System.Windows.Forms.Label();
            this.grind = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // manualLabel
            // 
            this.manualLabel.AutoSize = true;
            this.manualLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manualLabel.ForeColor = System.Drawing.Color.White;
            this.manualLabel.Location = new System.Drawing.Point(104, 8);
            this.manualLabel.Name = "manualLabel";
            this.manualLabel.Size = new System.Drawing.Size(45, 24);
            this.manualLabel.TabIndex = 0;
            this.manualLabel.Text = "0.00";
            this.manualLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Any_MouseClick);
            this.manualLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Any_MouseDown);
            // 
            // grindLabel
            // 
            this.grindLabel.AutoSize = true;
            this.grindLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grindLabel.ForeColor = System.Drawing.Color.White;
            this.grindLabel.Location = new System.Drawing.Point(104, 32);
            this.grindLabel.Name = "grindLabel";
            this.grindLabel.Size = new System.Drawing.Size(45, 24);
            this.grindLabel.TabIndex = 1;
            this.grindLabel.Text = "0.00";
            this.grindLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Any_MouseClick);
            this.grindLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Any_MouseDown);
            // 
            // manual
            // 
            this.manual.AutoSize = true;
            this.manual.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manual.ForeColor = System.Drawing.Color.White;
            this.manual.Location = new System.Drawing.Point(4, 8);
            this.manual.Name = "manual";
            this.manual.Size = new System.Drawing.Size(72, 24);
            this.manual.TabIndex = 2;
            this.manual.Text = "manual";
            this.manual.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Any_MouseClick);
            this.manual.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Any_MouseDown);
            // 
            // grind
            // 
            this.grind.AutoSize = true;
            this.grind.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grind.ForeColor = System.Drawing.Color.White;
            this.grind.Location = new System.Drawing.Point(4, 32);
            this.grind.Name = "grind";
            this.grind.Size = new System.Drawing.Size(53, 24);
            this.grind.TabIndex = 3;
            this.grind.Text = "grind";
            this.grind.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Any_MouseClick);
            this.grind.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Any_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(175, 66);
            this.Controls.Add(this.grind);
            this.Controls.Add(this.manual);
            this.Controls.Add(this.grindLabel);
            this.Controls.Add(this.manualLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "THUGPRO Balance";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Any_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Any_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label manualLabel;
        private System.Windows.Forms.Label grindLabel;
        private System.Windows.Forms.Label manual;
        private System.Windows.Forms.Label grind;
    }
}

