namespace Desktop_App.Forms.ReviewManagerForms
{
    partial class EditReviewForm
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
            btnEditReview = new Button();
            rtbDescription = new RichTextBox();
            tbScore = new TextBox();
            tbTitle = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            dgvReview = new DataGridView();
            label2 = new Label();
            tbMediaID = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvReview).BeginInit();
            SuspendLayout();
            // 
            // btnEditReview
            // 
            btnEditReview.Location = new Point(784, 396);
            btnEditReview.Margin = new Padding(3, 2, 3, 2);
            btnEditReview.Name = "btnEditReview";
            btnEditReview.Size = new Size(186, 37);
            btnEditReview.TabIndex = 15;
            btnEditReview.Text = "Edit Review";
            btnEditReview.UseVisualStyleBackColor = true;
            btnEditReview.Click += btnEditReview_Click;
            // 
            // rtbDescription
            // 
            rtbDescription.Location = new Point(26, 217);
            rtbDescription.Margin = new Padding(3, 2, 3, 2);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.Size = new Size(480, 216);
            rtbDescription.TabIndex = 14;
            rtbDescription.Text = "";
            // 
            // tbScore
            // 
            tbScore.Location = new Point(26, 83);
            tbScore.Margin = new Padding(3, 2, 3, 2);
            tbScore.Name = "tbScore";
            tbScore.Size = new Size(110, 23);
            tbScore.TabIndex = 13;
            // 
            // tbTitle
            // 
            tbTitle.Location = new Point(26, 44);
            tbTitle.Margin = new Padding(3, 2, 3, 2);
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(110, 23);
            tbTitle.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 200);
            label4.Name = "label4";
            label4.Size = new Size(107, 15);
            label4.TabIndex = 11;
            label4.Text = "Review Description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 69);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 10;
            label3.Text = "Score";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 27);
            label1.Name = "label1";
            label1.Size = new Size(100, 15);
            label1.TabIndex = 9;
            label1.Text = "Title of the review";
            // 
            // dgvReview
            // 
            dgvReview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReview.Location = new Point(557, 20);
            dgvReview.Margin = new Padding(3, 2, 3, 2);
            dgvReview.Name = "dgvReview";
            dgvReview.RowHeadersWidth = 51;
            dgvReview.RowTemplate.Height = 29;
            dgvReview.Size = new Size(592, 359);
            dgvReview.TabIndex = 16;
            dgvReview.SelectionChanged += dgvReview_SelectionChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 127);
            label2.Name = "label2";
            label2.Size = new Size(51, 15);
            label2.TabIndex = 17;
            label2.Text = "MediaID";
            // 
            // tbMediaID
            // 
            tbMediaID.Location = new Point(30, 147);
            tbMediaID.Name = "tbMediaID";
            tbMediaID.Size = new Size(100, 23);
            tbMediaID.TabIndex = 18;
            // 
            // EditReviewForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1159, 454);
            Controls.Add(tbMediaID);
            Controls.Add(label2);
            Controls.Add(dgvReview);
            Controls.Add(btnEditReview);
            Controls.Add(rtbDescription);
            Controls.Add(tbScore);
            Controls.Add(tbTitle);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "EditReviewForm";
            Text = "EditReviewForm";
            ((System.ComponentModel.ISupportInitialize)dgvReview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEditReview;
        private RichTextBox rtbDescription;
        private TextBox tbScore;
        private TextBox tbTitle;
        private Label label4;
        private Label label3;
        private Label label1;
        private DataGridView dgvReview;
        private Label label2;
        private TextBox tbMediaID;
    }
}