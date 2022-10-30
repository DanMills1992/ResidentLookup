
namespace ResidentLookup
{
    partial class ResidentLookupWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ResidenceDataGrid = new System.Windows.Forms.DataGridView();
            this.SearchButton = new System.Windows.Forms.Button();
            this.UserMessageLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.StreetNameTextbox = new System.Windows.Forms.TextBox();
            this.StreetNumberTextbox = new System.Windows.Forms.TextBox();
            this.StreetNameLabel = new System.Windows.Forms.Label();
            this.StreetNumberLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ResidenceDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ResidenceDataGrid
            // 
            this.ResidenceDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ResidenceDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResidenceDataGrid.Location = new System.Drawing.Point(29, 132);
            this.ResidenceDataGrid.Name = "ResidenceDataGrid";
            this.ResidenceDataGrid.ReadOnly = true;
            this.ResidenceDataGrid.RowTemplate.Height = 25;
            this.ResidenceDataGrid.Size = new System.Drawing.Size(565, 267);
            this.ResidenceDataGrid.TabIndex = 3;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(469, 98);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(125, 23);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // UserMessageLabel
            // 
            this.UserMessageLabel.Location = new System.Drawing.Point(-3, 54);
            this.UserMessageLabel.Name = "UserMessageLabel";
            this.UserMessageLabel.Size = new System.Drawing.Size(639, 24);
            this.UserMessageLabel.TabIndex = 2;
            this.UserMessageLabel.Text = "Please search by inputtingthe street name and number below.";
            this.UserMessageLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TitleLabel.Location = new System.Drawing.Point(226, 9);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(173, 30);
            this.TitleLabel.TabIndex = 3;
            this.TitleLabel.Text = "Resident Lookup";
            // 
            // StreetNameTextbox
            // 
            this.StreetNameTextbox.AcceptsTab = true;
            this.StreetNameTextbox.Location = new System.Drawing.Point(29, 99);
            this.StreetNameTextbox.Name = "StreetNameTextbox";
            this.StreetNameTextbox.Size = new System.Drawing.Size(150, 23);
            this.StreetNameTextbox.TabIndex = 0;
            // 
            // StreetNumberTextbox
            // 
            this.StreetNumberTextbox.AcceptsTab = true;
            this.StreetNumberTextbox.Location = new System.Drawing.Point(263, 99);
            this.StreetNumberTextbox.Name = "StreetNumberTextbox";
            this.StreetNumberTextbox.Size = new System.Drawing.Size(100, 23);
            this.StreetNumberTextbox.TabIndex = 1;
            this.StreetNumberTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StreetNumberTextbox_KeyPress);
            // 
            // StreetNameLabel
            // 
            this.StreetNameLabel.AutoSize = true;
            this.StreetNameLabel.Location = new System.Drawing.Point(185, 102);
            this.StreetNameLabel.Name = "StreetNameLabel";
            this.StreetNameLabel.Size = new System.Drawing.Size(72, 15);
            this.StreetNameLabel.TabIndex = 6;
            this.StreetNameLabel.Text = "Street Name";
            // 
            // StreetNumberLabel
            // 
            this.StreetNumberLabel.AutoSize = true;
            this.StreetNumberLabel.Location = new System.Drawing.Point(369, 103);
            this.StreetNumberLabel.Name = "StreetNumberLabel";
            this.StreetNumberLabel.Size = new System.Drawing.Size(51, 15);
            this.StreetNumberLabel.TabIndex = 7;
            this.StreetNumberLabel.Text = "Number";
            // 
            // ResidentLookupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 430);
            this.Controls.Add(this.StreetNumberLabel);
            this.Controls.Add(this.StreetNameLabel);
            this.Controls.Add(this.StreetNumberTextbox);
            this.Controls.Add(this.StreetNameTextbox);
            this.Controls.Add(this.TitleLabel);
            this.Controls.Add(this.UserMessageLabel);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.ResidenceDataGrid);
            this.Name = "ResidentLookupWindow";
            this.Text = "Resident Lookup";
            ((System.ComponentModel.ISupportInitialize)(this.ResidenceDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView ResidenceDataGrid;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Label UserMessageLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.TextBox StreetNameTextbox;
        private System.Windows.Forms.TextBox StreetNumberTextbox;
        private System.Windows.Forms.Label StreetNameLabel;
        private System.Windows.Forms.Label StreetNumberLabel;
    }
}

