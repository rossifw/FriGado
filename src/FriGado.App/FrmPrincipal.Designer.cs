namespace FriGado.App
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnMenu = new System.Windows.Forms.Panel();
            this.btnRelatorio = new System.Windows.Forms.Button();
            this.btnCompraGadoItem = new System.Windows.Forms.Button();
            this.btnCompraGado = new System.Windows.Forms.Button();
            this.btnAnimal = new System.Windows.Forms.Button();
            this.btnPecuarista = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.pnFrm = new System.Windows.Forms.Panel();
            this.pnPai = new System.Windows.Forms.Panel();
            this.pnMenu.SuspendLayout();
            this.pnPai.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnMenu
            // 
            this.pnMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.pnMenu.Controls.Add(this.btnRelatorio);
            this.pnMenu.Controls.Add(this.btnCompraGadoItem);
            this.pnMenu.Controls.Add(this.btnCompraGado);
            this.pnMenu.Controls.Add(this.btnAnimal);
            this.pnMenu.Controls.Add(this.btnPecuarista);
            this.pnMenu.Controls.Add(this.btnSair);
            this.pnMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnMenu.Location = new System.Drawing.Point(0, 0);
            this.pnMenu.Name = "pnMenu";
            this.pnMenu.Size = new System.Drawing.Size(129, 500);
            this.pnMenu.TabIndex = 0;
            // 
            // btnRelatorio
            // 
            this.btnRelatorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnRelatorio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRelatorio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnRelatorio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRelatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelatorio.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelatorio.Location = new System.Drawing.Point(3, 293);
            this.btnRelatorio.Name = "btnRelatorio";
            this.btnRelatorio.Size = new System.Drawing.Size(123, 50);
            this.btnRelatorio.TabIndex = 5;
            this.btnRelatorio.Text = "Relatório";
            this.btnRelatorio.UseVisualStyleBackColor = false;
            this.btnRelatorio.Click += new System.EventHandler(this.btnRelatorio_Click);
            // 
            // btnCompraGadoItem
            // 
            this.btnCompraGadoItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCompraGadoItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompraGadoItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCompraGadoItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCompraGadoItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompraGadoItem.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompraGadoItem.Location = new System.Drawing.Point(3, 225);
            this.btnCompraGadoItem.Name = "btnCompraGadoItem";
            this.btnCompraGadoItem.Size = new System.Drawing.Size(123, 50);
            this.btnCompraGadoItem.TabIndex = 4;
            this.btnCompraGadoItem.Text = "Compra Item";
            this.btnCompraGadoItem.UseVisualStyleBackColor = false;
            this.btnCompraGadoItem.Click += new System.EventHandler(this.btnCompraGadoItem_Click);
            // 
            // btnCompraGado
            // 
            this.btnCompraGado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnCompraGado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCompraGado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCompraGado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCompraGado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompraGado.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompraGado.Location = new System.Drawing.Point(3, 171);
            this.btnCompraGado.Name = "btnCompraGado";
            this.btnCompraGado.Size = new System.Drawing.Size(123, 50);
            this.btnCompraGado.TabIndex = 3;
            this.btnCompraGado.Text = "Compra Gado";
            this.btnCompraGado.UseVisualStyleBackColor = false;
            this.btnCompraGado.Click += new System.EventHandler(this.btnCompraGado_Click);
            // 
            // btnAnimal
            // 
            this.btnAnimal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAnimal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnimal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAnimal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAnimal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnimal.Font = new System.Drawing.Font("Arial", 14.25F);
            this.btnAnimal.Location = new System.Drawing.Point(3, 115);
            this.btnAnimal.Name = "btnAnimal";
            this.btnAnimal.Size = new System.Drawing.Size(123, 50);
            this.btnAnimal.TabIndex = 2;
            this.btnAnimal.Text = "Animal";
            this.btnAnimal.UseVisualStyleBackColor = false;
            this.btnAnimal.Click += new System.EventHandler(this.btnAnimal_Click);
            // 
            // btnPecuarista
            // 
            this.btnPecuarista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnPecuarista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPecuarista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnPecuarista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPecuarista.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPecuarista.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPecuarista.Location = new System.Drawing.Point(3, 59);
            this.btnPecuarista.Name = "btnPecuarista";
            this.btnPecuarista.Size = new System.Drawing.Size(123, 50);
            this.btnPecuarista.TabIndex = 1;
            this.btnPecuarista.Text = "Pecuarista";
            this.btnPecuarista.UseVisualStyleBackColor = false;
            this.btnPecuarista.Click += new System.EventHandler(this.btnPecuarista_Click);
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.LightCoral;
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.btnSair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Arial", 14.25F);
            this.btnSair.Location = new System.Drawing.Point(3, 467);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(123, 30);
            this.btnSair.TabIndex = 0;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // pnFrm
            // 
            this.pnFrm.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.pnFrm.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnFrm.Location = new System.Drawing.Point(130, 0);
            this.pnFrm.Name = "pnFrm";
            this.pnFrm.Size = new System.Drawing.Size(502, 500);
            this.pnFrm.TabIndex = 1;
            // 
            // pnPai
            // 
            this.pnPai.Controls.Add(this.pnMenu);
            this.pnPai.Controls.Add(this.pnFrm);
            this.pnPai.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPai.Location = new System.Drawing.Point(0, 0);
            this.pnPai.Name = "pnPai";
            this.pnPai.Size = new System.Drawing.Size(632, 500);
            this.pnPai.TabIndex = 0;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 500);
            this.Controls.Add(this.pnPai);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.pnMenu.ResumeLayout(false);
            this.pnPai.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMenu;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Panel pnFrm;
        private System.Windows.Forms.Panel pnPai;
        private System.Windows.Forms.Button btnAnimal;
        private System.Windows.Forms.Button btnPecuarista;
        private System.Windows.Forms.Button btnCompraGado;
        private System.Windows.Forms.Button btnCompraGadoItem;
        private System.Windows.Forms.Button btnRelatorio;
    }
}

