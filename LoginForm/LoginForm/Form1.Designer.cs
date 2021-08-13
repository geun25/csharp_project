
namespace LoginForm
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
            this.ID_txt = new System.Windows.Forms.TextBox();
            this.PW_txt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Login_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ID_txt
            // 
            this.ID_txt.Location = new System.Drawing.Point(158, 96);
            this.ID_txt.Name = "ID_txt";
            this.ID_txt.Size = new System.Drawing.Size(106, 28);
            this.ID_txt.TabIndex = 0;
            // 
            // PW_txt
            // 
            this.PW_txt.Location = new System.Drawing.Point(158, 130);
            this.PW_txt.Name = "PW_txt";
            this.PW_txt.PasswordChar = '●';
            this.PW_txt.Size = new System.Drawing.Size(106, 28);
            this.PW_txt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(108, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(108, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "PW";
            // 
            // Login_btn
            // 
            this.Login_btn.Location = new System.Drawing.Point(287, 96);
            this.Login_btn.Name = "Login_btn";
            this.Login_btn.Size = new System.Drawing.Size(79, 62);
            this.Login_btn.TabIndex = 4;
            this.Login_btn.Text = "Login";
            this.Login_btn.UseVisualStyleBackColor = true;
            this.Login_btn.Click += new System.EventHandler(this.Login_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Login_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PW_txt);
            this.Controls.Add(this.ID_txt);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ID_txt;
        private System.Windows.Forms.TextBox PW_txt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Login_btn;
    }
}

