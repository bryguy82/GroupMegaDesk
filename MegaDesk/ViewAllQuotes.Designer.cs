namespace MegaDesk
{
    partial class ViewAllQuotes
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
            this.viewAllMainMenu = new System.Windows.Forms.Button();
            this.quotesGrid = new System.Windows.Forms.DataGridView();
            this.displayQuoteButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.quotesGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // viewAllMainMenu
            // 
            this.viewAllMainMenu.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewAllMainMenu.Location = new System.Drawing.Point(472, 339);
            this.viewAllMainMenu.Name = "viewAllMainMenu";
            this.viewAllMainMenu.Size = new System.Drawing.Size(120, 30);
            this.viewAllMainMenu.TabIndex = 0;
            this.viewAllMainMenu.Text = "&Main Menu";
            this.viewAllMainMenu.UseVisualStyleBackColor = true;
            this.viewAllMainMenu.Click += new System.EventHandler(this.mainMenu_Click);
            // 
            // quotesGrid
            // 
            this.quotesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.quotesGrid.Location = new System.Drawing.Point(21, 31);
            this.quotesGrid.Name = "quotesGrid";
            this.quotesGrid.Size = new System.Drawing.Size(560, 285);
            this.quotesGrid.TabIndex = 1;
            this.quotesGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.quotesGrid_CellContentClick);
            this.quotesGrid.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.quotesGrid_CellContentClick);
            // 
            // displayQuoteButton
            // 
            this.displayQuoteButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displayQuoteButton.Location = new System.Drawing.Point(12, 339);
            this.displayQuoteButton.Name = "displayQuoteButton";
            this.displayQuoteButton.Size = new System.Drawing.Size(120, 30);
            this.displayQuoteButton.TabIndex = 2;
            this.displayQuoteButton.Text = "&Display Quote";
            this.displayQuoteButton.UseVisualStyleBackColor = true;
            this.displayQuoteButton.Click += new System.EventHandler(this.displayQuoteButton_Click);
            // 
            // ViewAllQuotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 381);
            this.Controls.Add(this.displayQuoteButton);
            this.Controls.Add(this.quotesGrid);
            this.Controls.Add(this.viewAllMainMenu);
            this.Name = "ViewAllQuotes";
            this.Text = "ViewAllQuotes";
            ((System.ComponentModel.ISupportInitialize)(this.quotesGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button viewAllMainMenu;
        private System.Windows.Forms.DataGridView quotesGrid;
        private System.Windows.Forms.Button displayQuoteButton;
    }
}