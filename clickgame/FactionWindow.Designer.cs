namespace Servi_urbe
{
    partial class FactionWindow
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.FactionCBox = new System.Windows.Forms.PictureBox();
            this.FactionBBox = new System.Windows.Forms.PictureBox();
            this.FactionABox = new System.Windows.Forms.PictureBox();
            this.DebugLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FactionCBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FactionBBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FactionABox)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1, 299);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(801, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // FactionCBox
            // 
            this.FactionCBox.Image = global::Servi_urbe.Properties.Resources.FactionC;
            this.FactionCBox.Location = new System.Drawing.Point(536, 12);
            this.FactionCBox.Name = "FactionCBox";
            this.FactionCBox.Size = new System.Drawing.Size(252, 281);
            this.FactionCBox.TabIndex = 3;
            this.FactionCBox.TabStop = false;
            this.FactionCBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FactionCBox_MouseClick);
            // 
            // FactionBBox
            // 
            this.FactionBBox.Image = global::Servi_urbe.Properties.Resources.FactionB;
            this.FactionBBox.Location = new System.Drawing.Point(270, 12);
            this.FactionBBox.Name = "FactionBBox";
            this.FactionBBox.Size = new System.Drawing.Size(260, 281);
            this.FactionBBox.TabIndex = 2;
            this.FactionBBox.TabStop = false;
            this.FactionBBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FactionBBox_MouseClick);
            // 
            // FactionABox
            // 
            this.FactionABox.Image = global::Servi_urbe.Properties.Resources.FactionA;
            this.FactionABox.Location = new System.Drawing.Point(12, 12);
            this.FactionABox.Name = "FactionABox";
            this.FactionABox.Size = new System.Drawing.Size(252, 281);
            this.FactionABox.TabIndex = 1;
            this.FactionABox.TabStop = false;
            this.FactionABox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.FactionABox_MouseClick);
            // 
            // DebugLabel
            // 
            this.DebugLabel.AutoSize = true;
            this.DebugLabel.Location = new System.Drawing.Point(365, 363);
            this.DebugLabel.Name = "DebugLabel";
            this.DebugLabel.Size = new System.Drawing.Size(13, 13);
            this.DebugLabel.TabIndex = 4;
            this.DebugLabel.Text = "0";
            // 
            // FactionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DebugLabel);
            this.Controls.Add(this.FactionCBox);
            this.Controls.Add(this.FactionBBox);
            this.Controls.Add(this.FactionABox);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FactionWindow";
            this.Text = "Fraktionen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FactionWindow_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FactionCBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FactionBBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FactionABox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox FactionABox;
        private System.Windows.Forms.PictureBox FactionBBox;
        private System.Windows.Forms.PictureBox FactionCBox;
        private System.Windows.Forms.Label DebugLabel;
    }
}