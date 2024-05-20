namespace Administracion_ETRAY
{
    partial class Cierre_Caja
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
            this.btnCierre = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtMesasAtendidas = new System.Windows.Forms.TextBox();
            this.txtMediaAtendidas = new System.Windows.Forms.TextBox();
            this.txtMediaTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCierre
            // 
            this.btnCierre.Location = new System.Drawing.Point(106, 105);
            this.btnCierre.Name = "btnCierre";
            this.btnCierre.Size = new System.Drawing.Size(75, 23);
            this.btnCierre.TabIndex = 0;
            this.btnCierre.Text = "button1";
            this.btnCierre.UseVisualStyleBackColor = true;
            this.btnCierre.Click += new System.EventHandler(this.btnCierre_Click);
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(286, 164);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(100, 20);
            this.txtTotal.TabIndex = 1;
            // 
            // txtMesasAtendidas
            // 
            this.txtMesasAtendidas.Location = new System.Drawing.Point(286, 246);
            this.txtMesasAtendidas.Name = "txtMesasAtendidas";
            this.txtMesasAtendidas.Size = new System.Drawing.Size(100, 20);
            this.txtMesasAtendidas.TabIndex = 2;
            // 
            // txtMediaAtendidas
            // 
            this.txtMediaAtendidas.Location = new System.Drawing.Point(574, 264);
            this.txtMediaAtendidas.Name = "txtMediaAtendidas";
            this.txtMediaAtendidas.Size = new System.Drawing.Size(100, 20);
            this.txtMediaAtendidas.TabIndex = 4;
            // 
            // txtMediaTotal
            // 
            this.txtMediaTotal.Location = new System.Drawing.Point(574, 173);
            this.txtMediaTotal.Name = "txtMediaTotal";
            this.txtMediaTotal.Size = new System.Drawing.Size(100, 20);
            this.txtMediaTotal.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mesas Atendidas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Total ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(480, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mesas Atendidas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(505, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Media Total";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(541, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 29);
            this.label5.TabIndex = 9;
            this.label5.Text = "Media por Dia";
            // 
            // Cierre_Caja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMediaAtendidas);
            this.Controls.Add(this.txtMediaTotal);
            this.Controls.Add(this.txtMesasAtendidas);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.btnCierre);
            this.Name = "Cierre_Caja";
            this.Text = "Cierre_Caja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCierre;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.TextBox txtMesasAtendidas;
        private System.Windows.Forms.TextBox txtMediaAtendidas;
        private System.Windows.Forms.TextBox txtMediaTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}