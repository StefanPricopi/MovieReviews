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
            richTextBox1 = new RichTextBox();
            textBox3 = new TextBox();
            textBox1 = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // btnEditReview
            // 
            btnEditReview.Location = new Point(575, 367);
            btnEditReview.Name = "btnEditReview";
            btnEditReview.Size = new Size(137, 49);
            btnEditReview.TabIndex = 15;
            btnEditReview.Text = "Edit Review";
            btnEditReview.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(92, 164);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(498, 177);
            richTextBox1.TabIndex = 14;
            richTextBox1.Text = "";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(92, 111);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 13;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(92, 58);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(92, 141);
            label4.Name = "label4";
            label4.Size = new Size(136, 20);
            label4.TabIndex = 11;
            label4.Text = "Review Description";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(92, 88);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 10;
            label3.Text = "Score";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(89, 34);
            label1.Name = "label1";
            label1.Size = new Size(128, 20);
            label1.TabIndex = 9;
            label1.Text = "Title of the review";
            // 
            // EditReviewForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEditReview);
            Controls.Add(richTextBox1);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "EditReviewForm";
            Text = "EditReviewForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEditReview;
        private RichTextBox richTextBox1;
        private TextBox textBox3;
        private TextBox textBox1;
        private Label label4;
        private Label label3;
        private Label label1;
    }
}