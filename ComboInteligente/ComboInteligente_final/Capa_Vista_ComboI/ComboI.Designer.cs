namespace Capa_Vista_ComboI
{
    partial class ComboI
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboPrueba = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cboPrueba
            // 
            this.cboPrueba.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboPrueba.FormattingEnabled = true;
            this.cboPrueba.Location = new System.Drawing.Point(0, 0);
            this.cboPrueba.Name = "cboPrueba";
            this.cboPrueba.Size = new System.Drawing.Size(603, 24);
            this.cboPrueba.TabIndex = 0;
            // 
            // ComboI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cboPrueba);
            this.Name = "ComboI";
            this.Size = new System.Drawing.Size(603, 24);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboPrueba;
    }
}
