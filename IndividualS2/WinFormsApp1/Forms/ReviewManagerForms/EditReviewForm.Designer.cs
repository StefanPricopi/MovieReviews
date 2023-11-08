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
            ((System.ComponentModel.ISupportInitialize)dgvReview).BeginInit();
            SuspendLayout();
            // 
            // btnEditReview
            // 
            btnEditReview.Location = new Point(189, 457);
            btnEditReview.Name = "btnEditReview";
            btnEditReview.Size = new Size(137, 49);
            btnEditReview.TabIndex = 15;
            btnEditReview.Text = "Edit Review";
            btnEditReview.UseVisualStyleBackColor = true;
            btnEditReview.Click += btnEditReview_Click;
            // 
            // rtbDescription
            // 
            rtbDescription.Location = new Point(67, 164);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.Size = new Size(548, 287);
            rtbDescription.TabIndex = 14;
            rtbDescription.Text = "";
            // 
            // tbScore
            // 
            tbScore.Location = new Point(91, 111);
            tbScore.Name = "tbScore";
            tbScore.Size = new Size(125, 27);
            tbScore.TabIndex = 13;
            // 
            // tbTitle
            // 
            tbTitle.Location = new Point(91, 59);
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(125, 27);
            tbTitle.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(91, 141);
            label4.Name = "label4";
            label4.Size = new Size(136, 20);
            label4.TabIndex = 11;
            label4.Text = "Review Description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(91, 88);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 10;
            label3.Text = "Score";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(89, 35);
            label1.Name = "label1";
            label1.Size = new Size(128, 20);
            label1.TabIndex = 9;
            label1.Text = "Title of the review";
            // 
            // dgvReview
            // 
            dgvReview.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReview.Location = new Point(637, 27);
            dgvReview.Name = "dgvReview";
            dgvReview.RowHeadersWidth = 51;
            dgvReview.RowTemplate.Height = 29;
            dgvReview.Size = new Size(676, 479);
            dgvReview.TabIndex = 16;
            dgvReview.SelectionChanged += dgvReview_SelectionChanged;
            // 
            // EditReviewForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1325, 606);
            Controls.Add(dgvReview);
            Controls.Add(btnEditReview);
            Controls.Add(rtbDescription);
            Controls.Add(tbScore);
            Controls.Add(tbTitle);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
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
    }
}