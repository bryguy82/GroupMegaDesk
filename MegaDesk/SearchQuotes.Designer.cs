namespace MegaDesk
{
    partial class SearchQuotes
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
            this.searchMainMenu = new System.Windows.Forms.Button();
            this.searchGrid = new System.Windows.Forms.DataGridView();
            this.materialComboBox = new System.Windows.Forms.ComboBox();
            this.nameComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.displaySearchQuoteButton = new System.Windows.Forms.Button();
            this.changeNameButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // searchMainMenu
            // 
            this.searchMainMenu.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchMainMenu.Location = new System.Drawing.Point(472, 329);
            this.searchMainMenu.Name = "searchMainMenu";
            this.searchMainMenu.Size = new System.Drawing.Size(110, 30);
            this.searchMainMenu.TabIndex = 3;
            this.searchMainMenu.Text = "&Main Menu";
            this.searchMainMenu.UseVisualStyleBackColor = true;
            this.searchMainMenu.Click += new System.EventHandler(this.mainMenu_Click);
            // 
            // searchGrid
            // 
            this.searchGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.searchGrid.Location = new System.Drawing.Point(12, 49);
            this.searchGrid.Name = "searchGrid";
            this.searchGrid.Size = new System.Drawing.Size(333, 253);
            this.searchGrid.TabIndex = 0;
            this.searchGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.searchGrid_CellContentClick);
            this.searchGrid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.searchGrid_CellContentClick);
            // 
            // materialComboBox
            // 
            this.materialComboBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.materialComboBox.FormattingEnabled = true;
            this.materialComboBox.Location = new System.Drawing.Point(382, 247);
            this.materialComboBox.Name = "materialComboBox";
            this.materialComboBox.Size = new System.Drawing.Size(200, 27);
            this.materialComboBox.TabIndex = 2;
            // 
            // nameComboBox
            // 
            this.nameComboBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameComboBox.FormattingEnabled = true;
            this.nameComboBox.Location = new System.Drawing.Point(382, 105);
            this.nameComboBox.Name = "nameComboBox";
            this.nameComboBox.Size = new System.Drawing.Size(200, 27);
            this.nameComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(404, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 30);
            this.label1.TabIndex = 27;
            this.label1.Text = "Search by Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(404, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 30);
            this.label2.TabIndex = 28;
            this.label2.Text = "Change Material";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // displaySearchQuoteButton
            // 
            this.displaySearchQuoteButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displaySearchQuoteButton.Location = new System.Drawing.Point(12, 329);
            this.displaySearchQuoteButton.Name = "displaySearchQuoteButton";
            this.displaySearchQuoteButton.Size = new System.Drawing.Size(120, 30);
            this.displaySearchQuoteButton.TabIndex = 4;
            this.displaySearchQuoteButton.Text = "&Display Quote";
            this.displaySearchQuoteButton.UseVisualStyleBackColor = true;
            this.displaySearchQuoteButton.Click += new System.EventHandler(this.displaySearchQuoteButton_Click);
            // 
            // changeNameButton
            // 
            this.changeNameButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeNameButton.Location = new System.Drawing.Point(427, 138);
            this.changeNameButton.Name = "changeNameButton";
            this.changeNameButton.Size = new System.Drawing.Size(120, 30);
            this.changeNameButton.TabIndex = 29;
            this.changeNameButton.Text = "&Change Name";
            this.changeNameButton.UseVisualStyleBackColor = true;
            this.changeNameButton.Click += new System.EventHandler(this.changeNameButton_Click);
            // 
            // SearchQuotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 381);
            this.Controls.Add(this.changeNameButton);
            this.Controls.Add(this.displaySearchQuoteButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameComboBox);
            this.Controls.Add(this.materialComboBox);
            this.Controls.Add(this.searchGrid);
            this.Controls.Add(this.searchMainMenu);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchQuotes";
            this.Text = "SearchQuotes";
            ((System.ComponentModel.ISupportInitialize)(this.searchGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button searchMainMenu;
        private System.Windows.Forms.DataGridView searchGrid;
        private System.Windows.Forms.ComboBox materialComboBox;
        private System.Windows.Forms.ComboBox nameComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button displaySearchQuoteButton;
        private System.Windows.Forms.Button changeNameButton;
    }
}