
namespace Editor_Multimedia
{
    partial class VIDEO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VIDEO));
            this.Imagen_lienzo = new System.Windows.Forms.PictureBox();
            this.BTN_EXPORTAR_VID = new System.Windows.Forms.Button();
            this.videoOri = new System.Windows.Forms.PictureBox();
            this.macTrackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.BTN_APLICAR_FILTRO = new System.Windows.Forms.Button();
            this.histog = new System.Windows.Forms.PictureBox();
            this.Lista_Filtros = new Editor_Multimedia.RJComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen_lienzo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoOri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.macTrackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.histog)).BeginInit();
            this.SuspendLayout();
            // 
            // Imagen_lienzo
            // 
            this.Imagen_lienzo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(48)))), ((int)(((byte)(74)))));
            this.Imagen_lienzo.Location = new System.Drawing.Point(12, 41);
            this.Imagen_lienzo.Name = "Imagen_lienzo";
            this.Imagen_lienzo.Size = new System.Drawing.Size(371, 211);
            this.Imagen_lienzo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Imagen_lienzo.TabIndex = 3;
            this.Imagen_lienzo.TabStop = false;
            // 
            // BTN_EXPORTAR_VID
            // 
            this.BTN_EXPORTAR_VID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BTN_EXPORTAR_VID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(48)))), ((int)(((byte)(118)))));
            this.BTN_EXPORTAR_VID.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_EXPORTAR_VID.FlatAppearance.BorderSize = 0;
            this.BTN_EXPORTAR_VID.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(48)))), ((int)(((byte)(118)))));
            this.BTN_EXPORTAR_VID.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_EXPORTAR_VID.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_EXPORTAR_VID.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTN_EXPORTAR_VID.Image = ((System.Drawing.Image)(resources.GetObject("BTN_EXPORTAR_VID.Image")));
            this.BTN_EXPORTAR_VID.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_EXPORTAR_VID.Location = new System.Drawing.Point(12, 391);
            this.BTN_EXPORTAR_VID.Name = "BTN_EXPORTAR_VID";
            this.BTN_EXPORTAR_VID.Size = new System.Drawing.Size(176, 34);
            this.BTN_EXPORTAR_VID.TabIndex = 21;
            this.BTN_EXPORTAR_VID.Text = "      Subir Archivo";
            this.BTN_EXPORTAR_VID.UseVisualStyleBackColor = false;
            this.BTN_EXPORTAR_VID.Click += new System.EventHandler(this.BTN_SUBIR_ARCHIVO_I_Click);
            // 
            // videoOri
            // 
            this.videoOri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.videoOri.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(48)))), ((int)(((byte)(74)))));
            this.videoOri.Location = new System.Drawing.Point(593, 41);
            this.videoOri.Name = "videoOri";
            this.videoOri.Size = new System.Drawing.Size(195, 114);
            this.videoOri.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.videoOri.TabIndex = 22;
            this.videoOri.TabStop = false;
            // 
            // macTrackBar1
            // 
            this.macTrackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.macTrackBar1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.macTrackBar1.Location = new System.Drawing.Point(410, 431);
            this.macTrackBar1.Name = "macTrackBar1";
            this.macTrackBar1.Size = new System.Drawing.Size(378, 45);
            this.macTrackBar1.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(660, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 21);
            this.label1.TabIndex = 24;
            this.label1.Text = "Original";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(80)))), ((int)(((byte)(103)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(48)))), ((int)(((byte)(118)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(593, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 34);
            this.button1.TabIndex = 25;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(80)))), ((int)(((byte)(103)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(48)))), ((int)(((byte)(118)))));
            this.button2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(639, 391);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 34);
            this.button2.TabIndex = 26;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(80)))), ((int)(((byte)(103)))));
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(48)))), ((int)(((byte)(118)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(547, 391);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 34);
            this.button3.TabIndex = 27;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(165, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 21);
            this.label2.TabIndex = 28;
            this.label2.Text = "Filtro";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(48)))), ((int)(((byte)(118)))));
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(48)))), ((int)(((byte)(118)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(12, 431);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(176, 34);
            this.button4.TabIndex = 30;
            this.button4.Text = "      Exportar Archivo";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // BTN_APLICAR_FILTRO
            // 
            this.BTN_APLICAR_FILTRO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(48)))), ((int)(((byte)(118)))));
            this.BTN_APLICAR_FILTRO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_APLICAR_FILTRO.FlatAppearance.BorderSize = 0;
            this.BTN_APLICAR_FILTRO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(48)))), ((int)(((byte)(118)))));
            this.BTN_APLICAR_FILTRO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_APLICAR_FILTRO.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_APLICAR_FILTRO.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTN_APLICAR_FILTRO.Image = ((System.Drawing.Image)(resources.GetObject("BTN_APLICAR_FILTRO.Image")));
            this.BTN_APLICAR_FILTRO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_APLICAR_FILTRO.Location = new System.Drawing.Point(12, 258);
            this.BTN_APLICAR_FILTRO.Name = "BTN_APLICAR_FILTRO";
            this.BTN_APLICAR_FILTRO.Size = new System.Drawing.Size(121, 30);
            this.BTN_APLICAR_FILTRO.TabIndex = 31;
            this.BTN_APLICAR_FILTRO.Text = "     Aplicar";
            this.BTN_APLICAR_FILTRO.UseVisualStyleBackColor = false;
            this.BTN_APLICAR_FILTRO.Click += new System.EventHandler(this.BTN_APLICAR_FILTRO_Click);
            // 
            // histog
            // 
            this.histog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.histog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(48)))), ((int)(((byte)(74)))));
            this.histog.Location = new System.Drawing.Point(593, 182);
            this.histog.Name = "histog";
            this.histog.Size = new System.Drawing.Size(195, 114);
            this.histog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.histog.TabIndex = 32;
            this.histog.TabStop = false;
            // 
            // Lista_Filtros
            // 
            this.Lista_Filtros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(48)))), ((int)(((byte)(118)))));
            this.Lista_Filtros.BackColor1 = System.Drawing.Color.WhiteSmoke;
            this.Lista_Filtros.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(48)))), ((int)(((byte)(118)))));
            this.Lista_Filtros.BorderSize = 1;
            this.Lista_Filtros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Lista_Filtros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.Lista_Filtros.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Lista_Filtros.ForeColor = System.Drawing.Color.DimGray;
            this.Lista_Filtros.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(48)))), ((int)(((byte)(118)))));
            this.Lista_Filtros.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.Lista_Filtros.ListTextColor = System.Drawing.Color.DimGray;
            this.Lista_Filtros.Location = new System.Drawing.Point(154, 258);
            this.Lista_Filtros.MinimumSize = new System.Drawing.Size(200, 30);
            this.Lista_Filtros.Name = "Lista_Filtros";
            this.Lista_Filtros.Padding = new System.Windows.Forms.Padding(1);
            this.Lista_Filtros.Size = new System.Drawing.Size(230, 30);
            this.Lista_Filtros.TabIndex = 29;
            this.Lista_Filtros.Texts = "";
            this.Lista_Filtros.OnSelectedIndexChanged += new System.EventHandler(this.Lista_Filtros_OnSelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(635, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 21);
            this.label3.TabIndex = 33;
            this.label3.Text = "Histograma";
            // 
            // VIDEO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(80)))), ((int)(((byte)(103)))));
            this.ClientSize = new System.Drawing.Size(800, 488);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.histog);
            this.Controls.Add(this.BTN_APLICAR_FILTRO);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.Lista_Filtros);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.macTrackBar1);
            this.Controls.Add(this.videoOri);
            this.Controls.Add(this.BTN_EXPORTAR_VID);
            this.Controls.Add(this.Imagen_lienzo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VIDEO";
            this.Text = "VIDEO";
            ((System.ComponentModel.ISupportInitialize)(this.Imagen_lienzo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.videoOri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.macTrackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.histog)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox Imagen_lienzo;
        private System.Windows.Forms.Button BTN_EXPORTAR_VID;
        public System.Windows.Forms.PictureBox videoOri;
        private System.Windows.Forms.TrackBar macTrackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private RJComboBox Lista_Filtros;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button BTN_APLICAR_FILTRO;
        public System.Windows.Forms.PictureBox histog;
        private System.Windows.Forms.Label label3;
    }
}