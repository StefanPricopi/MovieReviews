namespace Desktop_App.Forms.ReviewManagerForms
{
    partial class AddReviewForm
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
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            tbTitle = new TextBox();
            tbScore = new TextBox();
            rtbDescription = new RichTextBox();
            btnAddReview = new Button();
            cbMediaTitle = new ComboBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(87, 56);
            label1.Name = "label1";
            label1.Size = new Size(128, 20);
            label1.TabIndex = 0;
            label1.Text = "Title of the review";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(90, 110);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 2;
            label3.Text = "Score";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(90, 163);
            label4.Name = "label4";
            label4.Size = new Size(136, 20);
            label4.TabIndex = 3;
            label4.Text = "Review Description";
            // 
            // tbTitle
            // 
            tbTitle.Location = new Point(90, 80);
            tbTitle.Name = "tbTitle";
            tbTitle.Size = new Size(125, 27);
            tbTitle.TabIndex = 4;
            // 
            // tbScore
            // 
            tbScore.Location = new Point(90, 133);
            tbScore.Name = "tbScore";
            tbScore.Size = new Size(125, 27);
            tbScore.TabIndex = 6;
            // 
            // rtbDescription
            // 
            rtbDescription.Location = new Point(90, 186);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.Size = new Size(1119, 413);
            rtbDescription.TabIndex = 7;
            rtbDescription.Text = "";
            // 
            // btnAddReview
            // 
            btnAddReview.Location = new Point(515, 629);
            btnAddReview.Name = "btnAddReview";
            btnAddReview.Size = new Size(251, 49);
            btnAddReview.TabIndex = 8;
            btnAddReview.Text = "Add Review";
            btnAddReview.UseVisualStyleBackColor = true;
            btnAddReview.Click += btnAddReview_Click;
            // 
            // cbMediaTitle
            // 
            cbMediaTitle.FormattingEnabled = true;
            cbMediaTitle.Location = new Point(315, 79);
            cbMediaTitle.Name = "cbMediaTitle";
            cbMediaTitle.Size = new Size(151, 28);
            cbMediaTitle.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(315, 56);
            label2.Name = "label2";
            label2.Size = new Size(84, 20);
            label2.TabIndex = 10;
            label2.Text = "Media Title";
            // 
            // AddReviewForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1272, 703);
            Controls.Add(label2);
            Controls.Add(cbMediaTitle);
            Controls.Add(btnAddReview);
            Controls.Add(rtbDescription);
            Controls.Add(tbScore);
            Controls.Add(tbTitle);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "AddReviewForm";
            Text = "AddReviewForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private Label label4;
        private TextBox tbTitle;
        private TextBox tbScore;
        private RichTextBox rtbDescription;
        private Button btnAddReview;
        private ComboBox cbMediaTitle;
        private Label label2;
    }
}