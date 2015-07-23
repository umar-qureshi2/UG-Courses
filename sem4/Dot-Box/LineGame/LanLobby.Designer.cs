namespace LineGame
{
    partial class LanLobby
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
            this.AvailablePlayers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_list = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.strt_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AvailablePlayers
            // 
            this.AvailablePlayers.BackColor = System.Drawing.Color.Black;
            this.AvailablePlayers.Font = new System.Drawing.Font("Andy", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AvailablePlayers.ForeColor = System.Drawing.Color.Chocolate;
            this.AvailablePlayers.FormattingEnabled = true;
            this.AvailablePlayers.ItemHeight = 23;
            this.AvailablePlayers.Location = new System.Drawing.Point(70, 115);
            this.AvailablePlayers.Name = "AvailablePlayers";
            this.AvailablePlayers.Size = new System.Drawing.Size(248, 441);
            this.AvailablePlayers.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Andy", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Chocolate;
            this.label1.Location = new System.Drawing.Point(224, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 72);
            this.label1.TabIndex = 1;
            this.label1.Text = "LAN LOBBY";
            // 
            // btn_list
            // 
            this.btn_list.FlatAppearance.BorderColor = System.Drawing.Color.Chocolate;
            this.btn_list.FlatAppearance.BorderSize = 2;
            this.btn_list.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_list.Font = new System.Drawing.Font("Andy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_list.ForeColor = System.Drawing.Color.Chocolate;
            this.btn_list.Location = new System.Drawing.Point(761, 316);
            this.btn_list.Name = "btn_list";
            this.btn_list.Size = new System.Drawing.Size(106, 26);
            this.btn_list.TabIndex = 2;
            this.btn_list.Text = "Retrieve List";
            this.btn_list.UseVisualStyleBackColor = false;
            // 
            // back
            // 
            this.back.FlatAppearance.BorderColor = System.Drawing.Color.Chocolate;
            this.back.FlatAppearance.BorderSize = 2;
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.Font = new System.Drawing.Font("Andy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back.ForeColor = System.Drawing.Color.Chocolate;
            this.back.Location = new System.Drawing.Point(761, 529);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(106, 27);
            this.back.TabIndex = 3;
            this.back.Text = "Back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // strt_btn
            // 
            this.strt_btn.FlatAppearance.BorderColor = System.Drawing.Color.Chocolate;
            this.strt_btn.FlatAppearance.BorderSize = 2;
            this.strt_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.strt_btn.Font = new System.Drawing.Font("Andy", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.strt_btn.ForeColor = System.Drawing.Color.Chocolate;
            this.strt_btn.Location = new System.Drawing.Point(761, 409);
            this.strt_btn.Name = "strt_btn";
            this.strt_btn.Size = new System.Drawing.Size(106, 26);
            this.strt_btn.TabIndex = 2;
            this.strt_btn.Text = "Start Game";
            this.strt_btn.UseVisualStyleBackColor = false;
            this.strt_btn.Click += new System.EventHandler(this.strt_btn_Click);
            // 
            // LanLobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(902, 591);
            this.Controls.Add(this.back);
            this.Controls.Add(this.strt_btn);
            this.Controls.Add(this.btn_list);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AvailablePlayers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LanLobby";
            this.Text = "LanLobby";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox AvailablePlayers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_list;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button strt_btn;
    }
}