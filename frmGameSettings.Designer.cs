namespace Tic_Tac_Toe_Game
{
    partial class frmGameSettings
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
            this.btnWithFriend = new System.Windows.Forms.Button();
            this.btnWithComputer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnWithFriend
            // 
            this.btnWithFriend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWithFriend.Font = new System.Drawing.Font("Modern No. 20", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWithFriend.ForeColor = System.Drawing.Color.Blue;
            this.btnWithFriend.Location = new System.Drawing.Point(452, 202);
            this.btnWithFriend.Name = "btnWithFriend";
            this.btnWithFriend.Size = new System.Drawing.Size(97, 47);
            this.btnWithFriend.TabIndex = 3;
            this.btnWithFriend.Text = "Play with Friend";
            this.btnWithFriend.UseVisualStyleBackColor = true;
            this.btnWithFriend.Click += new System.EventHandler(this.btnWithFriend_Click);
            // 
            // btnWithComputer
            // 
            this.btnWithComputer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWithComputer.Font = new System.Drawing.Font("Modern No. 20", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWithComputer.ForeColor = System.Drawing.Color.Lime;
            this.btnWithComputer.Location = new System.Drawing.Point(253, 202);
            this.btnWithComputer.Name = "btnWithComputer";
            this.btnWithComputer.Size = new System.Drawing.Size(97, 47);
            this.btnWithComputer.TabIndex = 2;
            this.btnWithComputer.Text = "Play with Computer";
            this.btnWithComputer.UseVisualStyleBackColor = true;
            this.btnWithComputer.Click += new System.EventHandler(this.btnWithComputer_Click);
            // 
            // frmGameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnWithFriend);
            this.Controls.Add(this.btnWithComputer);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "frmGameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGameSettings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWithFriend;
        private System.Windows.Forms.Button btnWithComputer;
    }
}