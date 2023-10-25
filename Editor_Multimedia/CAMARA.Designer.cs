
namespace Editor_Multimedia
{
    partial class CAMARA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CAMARA));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BTN_INICIAR_VIDEO = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.rjComboBox2 = new Editor_Multimedia.RJComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(48)))), ((int)(((byte)(74)))));
            this.pictureBox1.Location = new System.Drawing.Point(15, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(773, 379);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Dispositivos:";
            // 
            // BTN_INICIAR_VIDEO
            // 
            this.BTN_INICIAR_VIDEO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_INICIAR_VIDEO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(48)))), ((int)(((byte)(118)))));
            this.BTN_INICIAR_VIDEO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_INICIAR_VIDEO.FlatAppearance.BorderSize = 0;
            this.BTN_INICIAR_VIDEO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(48)))), ((int)(((byte)(118)))));
            this.BTN_INICIAR_VIDEO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_INICIAR_VIDEO.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_INICIAR_VIDEO.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTN_INICIAR_VIDEO.Image = ((System.Drawing.Image)(resources.GetObject("BTN_INICIAR_VIDEO.Image")));
            this.BTN_INICIAR_VIDEO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_INICIAR_VIDEO.Location = new System.Drawing.Point(493, 9);
            this.BTN_INICIAR_VIDEO.Name = "BTN_INICIAR_VIDEO";
            this.BTN_INICIAR_VIDEO.Size = new System.Drawing.Size(146, 34);
            this.BTN_INICIAR_VIDEO.TabIndex = 22;
            this.BTN_INICIAR_VIDEO.Text = "        Iniciar Video";
            this.BTN_INICIAR_VIDEO.UseVisualStyleBackColor = false;
            this.BTN_INICIAR_VIDEO.Click += new System.EventHandler(this.BTN_INICIAR_VIDEO_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(48)))), ((int)(((byte)(118)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(48)))), ((int)(((byte)(118)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(645, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 34);
            this.button1.TabIndex = 23;
            this.button1.Text = "       Parar Video";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rjComboBox2
            // 
            this.rjComboBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(48)))), ((int)(((byte)(118)))));
            this.rjComboBox2.BackColor1 = System.Drawing.Color.WhiteSmoke;
            this.rjComboBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(48)))), ((int)(((byte)(118)))));
            this.rjComboBox2.BorderSize = 3;
            this.rjComboBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rjComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.rjComboBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rjComboBox2.ForeColor = System.Drawing.Color.DimGray;
            this.rjComboBox2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(48)))), ((int)(((byte)(118)))));
            this.rjComboBox2.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.rjComboBox2.ListTextColor = System.Drawing.Color.DimGray;
            this.rjComboBox2.Location = new System.Drawing.Point(103, 12);
            this.rjComboBox2.MinimumSize = new System.Drawing.Size(200, 30);
            this.rjComboBox2.Name = "rjComboBox2";
            this.rjComboBox2.Padding = new System.Windows.Forms.Padding(3);
            this.rjComboBox2.Size = new System.Drawing.Size(200, 30);
            this.rjComboBox2.TabIndex = 3;
            this.rjComboBox2.Texts = "";
            this.rjComboBox2.OnSelectedIndexChanged += new System.EventHandler(this.rjComboBox2_OnSelectedIndexChanged);
            // 
            // CAMARA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(80)))), ((int)(((byte)(103)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BTN_INICIAR_VIDEO);
            this.Controls.Add(this.rjComboBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CAMARA";
            this.Text = "CAMARA";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CAMARA_FormClosed);
            this.Load += new System.EventHandler(this.CAMARA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private RJComboBox rjComboBox2;
        private System.Windows.Forms.Button BTN_INICIAR_VIDEO;
        private System.Windows.Forms.Button button1;
    }
}