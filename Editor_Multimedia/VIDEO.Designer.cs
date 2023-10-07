
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
            this.BTN_SUBIR_ARCHIVO_I = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Imagen_lienzo)).BeginInit();
            this.SuspendLayout();
            // 
            // Imagen_lienzo
            // 
            this.Imagen_lienzo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Imagen_lienzo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(48)))), ((int)(((byte)(74)))));
            this.Imagen_lienzo.Location = new System.Drawing.Point(14, 12);
            this.Imagen_lienzo.Name = "Imagen_lienzo";
            this.Imagen_lienzo.Size = new System.Drawing.Size(773, 348);
            this.Imagen_lienzo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Imagen_lienzo.TabIndex = 3;
            this.Imagen_lienzo.TabStop = false;
            // 
            // BTN_SUBIR_ARCHIVO_I
            // 
            this.BTN_SUBIR_ARCHIVO_I.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(48)))), ((int)(((byte)(118)))));
            this.BTN_SUBIR_ARCHIVO_I.FlatAppearance.BorderSize = 0;
            this.BTN_SUBIR_ARCHIVO_I.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(48)))), ((int)(((byte)(118)))));
            this.BTN_SUBIR_ARCHIVO_I.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_SUBIR_ARCHIVO_I.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_SUBIR_ARCHIVO_I.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BTN_SUBIR_ARCHIVO_I.Image = ((System.Drawing.Image)(resources.GetObject("BTN_SUBIR_ARCHIVO_I.Image")));
            this.BTN_SUBIR_ARCHIVO_I.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BTN_SUBIR_ARCHIVO_I.Location = new System.Drawing.Point(12, 389);
            this.BTN_SUBIR_ARCHIVO_I.Name = "BTN_SUBIR_ARCHIVO_I";
            this.BTN_SUBIR_ARCHIVO_I.Size = new System.Drawing.Size(184, 34);
            this.BTN_SUBIR_ARCHIVO_I.TabIndex = 21;
            this.BTN_SUBIR_ARCHIVO_I.Text = "Subir Archivo";
            this.BTN_SUBIR_ARCHIVO_I.UseVisualStyleBackColor = false;
            // 
            // VIDEO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(80)))), ((int)(((byte)(103)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BTN_SUBIR_ARCHIVO_I);
            this.Controls.Add(this.Imagen_lienzo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VIDEO";
            this.Text = "VIDEO";
            ((System.ComponentModel.ISupportInitialize)(this.Imagen_lienzo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox Imagen_lienzo;
        private System.Windows.Forms.Button BTN_SUBIR_ARCHIVO_I;
    }
}