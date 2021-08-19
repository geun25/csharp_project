
namespace NGCrawler
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.Search_Btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Search_Tbx = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.News_Rbn = new System.Windows.Forms.RadioButton();
            this.Blog_Rbn = new System.Windows.Forms.RadioButton();
            this.Cafe_Rbn = new System.Windows.Forms.RadioButton();
            this.Post_Rbn = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Search_Lbx = new System.Windows.Forms.ListBox();
            this.Search_Lbx2 = new System.Windows.Forms.ListBox();
            this.Video_Lbx = new System.Windows.Forms.ListBox();
            this.Video_Lbx2 = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Search_Btn
            // 
            this.Search_Btn.Font = new System.Drawing.Font("궁서체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Search_Btn.Location = new System.Drawing.Point(80, 680);
            this.Search_Btn.Name = "Search_Btn";
            this.Search_Btn.Size = new System.Drawing.Size(119, 76);
            this.Search_Btn.TabIndex = 0;
            this.Search_Btn.Text = "검색(ENTER)";
            this.Search_Btn.UseVisualStyleBackColor = true;
            this.Search_Btn.Click += new System.EventHandler(this.Search_Btn_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(48, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "검색어 입력";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Search_Tbx
            // 
            this.Search_Tbx.Location = new System.Drawing.Point(54, 133);
            this.Search_Tbx.Multiline = true;
            this.Search_Tbx.Name = "Search_Tbx";
            this.Search_Tbx.Size = new System.Drawing.Size(188, 41);
            this.Search_Tbx.TabIndex = 2;
            this.Search_Tbx.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Search_Tbx_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton5);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Font = new System.Drawing.Font("궁서체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(54, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 170);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "구글 검색 연산자";
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(6, 139);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(96, 22);
            this.radioButton5.TabIndex = 9;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "\'\' 검색";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 27);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(114, 22);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "일반 검색";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 111);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(105, 22);
            this.radioButton4.TabIndex = 8;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Filetype";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 55);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(96, 22);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Intitle";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 83);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(87, 22);
            this.radioButton3.TabIndex = 7;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Intext";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.News_Rbn);
            this.groupBox2.Controls.Add(this.Blog_Rbn);
            this.groupBox2.Controls.Add(this.Cafe_Rbn);
            this.groupBox2.Controls.Add(this.Post_Rbn);
            this.groupBox2.Font = new System.Drawing.Font("궁서체", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(54, 468);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(188, 144);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "네이버 검색 종류";
            // 
            // News_Rbn
            // 
            this.News_Rbn.AutoSize = true;
            this.News_Rbn.Location = new System.Drawing.Point(113, 87);
            this.News_Rbn.Name = "News_Rbn";
            this.News_Rbn.Size = new System.Drawing.Size(69, 22);
            this.News_Rbn.TabIndex = 9;
            this.News_Rbn.TabStop = true;
            this.News_Rbn.Text = "뉴스";
            this.News_Rbn.UseVisualStyleBackColor = true;
            // 
            // Blog_Rbn
            // 
            this.Blog_Rbn.AutoSize = true;
            this.Blog_Rbn.Location = new System.Drawing.Point(6, 87);
            this.Blog_Rbn.Name = "Blog_Rbn";
            this.Blog_Rbn.Size = new System.Drawing.Size(87, 22);
            this.Blog_Rbn.TabIndex = 8;
            this.Blog_Rbn.TabStop = true;
            this.Blog_Rbn.Text = "블로그";
            this.Blog_Rbn.UseVisualStyleBackColor = true;
            // 
            // Cafe_Rbn
            // 
            this.Cafe_Rbn.AutoSize = true;
            this.Cafe_Rbn.Location = new System.Drawing.Point(113, 45);
            this.Cafe_Rbn.Name = "Cafe_Rbn";
            this.Cafe_Rbn.Size = new System.Drawing.Size(69, 22);
            this.Cafe_Rbn.TabIndex = 7;
            this.Cafe_Rbn.TabStop = true;
            this.Cafe_Rbn.Text = "카페";
            this.Cafe_Rbn.UseVisualStyleBackColor = true;
            // 
            // Post_Rbn
            // 
            this.Post_Rbn.AutoSize = true;
            this.Post_Rbn.Location = new System.Drawing.Point(6, 45);
            this.Post_Rbn.Name = "Post_Rbn";
            this.Post_Rbn.Size = new System.Drawing.Size(87, 22);
            this.Post_Rbn.TabIndex = 6;
            this.Post_Rbn.TabStop = true;
            this.Post_Rbn.Text = "포스트";
            this.Post_Rbn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(563, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 46);
            this.label2.TabIndex = 5;
            this.label2.Text = "Google";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(1485, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 46);
            this.label3.TabIndex = 6;
            this.label3.Text = "Naver";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(1027, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(194, 46);
            this.label4.TabIndex = 7;
            this.label4.Text = "통합 검색 결과";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("궁서체", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(1017, 669);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 46);
            this.label5.TabIndex = 8;
            this.label5.Text = "동영상 검색 결과";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Search_Lbx
            // 
            this.Search_Lbx.FormattingEnabled = true;
            this.Search_Lbx.ItemHeight = 18;
            this.Search_Lbx.Location = new System.Drawing.Point(318, 133);
            this.Search_Lbx.Name = "Search_Lbx";
            this.Search_Lbx.Size = new System.Drawing.Size(693, 328);
            this.Search_Lbx.TabIndex = 9;
            // 
            // Search_Lbx2
            // 
            this.Search_Lbx2.FormattingEnabled = true;
            this.Search_Lbx2.ItemHeight = 18;
            this.Search_Lbx2.Location = new System.Drawing.Point(1236, 133);
            this.Search_Lbx2.Name = "Search_Lbx2";
            this.Search_Lbx2.Size = new System.Drawing.Size(693, 328);
            this.Search_Lbx2.TabIndex = 10;
            // 
            // Video_Lbx
            // 
            this.Video_Lbx.FormattingEnabled = true;
            this.Video_Lbx.ItemHeight = 18;
            this.Video_Lbx.Location = new System.Drawing.Point(318, 513);
            this.Video_Lbx.Name = "Video_Lbx";
            this.Video_Lbx.Size = new System.Drawing.Size(693, 328);
            this.Video_Lbx.TabIndex = 11;
            // 
            // Video_Lbx2
            // 
            this.Video_Lbx2.FormattingEnabled = true;
            this.Video_Lbx2.ItemHeight = 18;
            this.Video_Lbx2.Location = new System.Drawing.Point(1236, 513);
            this.Video_Lbx2.Name = "Video_Lbx2";
            this.Video_Lbx2.Size = new System.Drawing.Size(693, 328);
            this.Video_Lbx2.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1388, 832);
            this.Controls.Add(this.Video_Lbx2);
            this.Controls.Add(this.Video_Lbx);
            this.Controls.Add(this.Search_Lbx2);
            this.Controls.Add(this.Search_Lbx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Search_Tbx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Search_Btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Search_Btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Search_Tbx;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton News_Rbn;
        private System.Windows.Forms.RadioButton Blog_Rbn;
        private System.Windows.Forms.RadioButton Cafe_Rbn;
        private System.Windows.Forms.RadioButton Post_Rbn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox Search_Lbx;
        private System.Windows.Forms.ListBox Search_Lbx2;
        private System.Windows.Forms.ListBox Video_Lbx;
        private System.Windows.Forms.ListBox Video_Lbx2;
    }
}

