namespace Lab16
{
    partial class Form1
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
            userNameTextBox = new TextBox();
            loginButton = new Button();
            logoutButton = new Button();
            sendButton = new Button();
            chatTextBox = new TextBox();
            messageTextBox = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // userNameTextBox
            // 
            userNameTextBox.Location = new Point(109, 34);
            userNameTextBox.Name = "userNameTextBox";
            userNameTextBox.Size = new Size(239, 23);
            userNameTextBox.TabIndex = 0;
            // 
            // loginButton
            // 
            loginButton.Location = new Point(393, 34);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(75, 23);
            loginButton.TabIndex = 1;
            loginButton.Text = "Вхід";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(393, 74);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(75, 23);
            logoutButton.TabIndex = 2;
            logoutButton.Text = "Вихід";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // sendButton
            // 
            sendButton.Location = new Point(402, 328);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(86, 50);
            sendButton.TabIndex = 3;
            sendButton.Text = "Відправити";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // chatTextBox
            // 
            chatTextBox.Location = new Point(12, 117);
            chatTextBox.Multiline = true;
            chatTextBox.Name = "chatTextBox";
            chatTextBox.Size = new Size(476, 204);
            chatTextBox.TabIndex = 4;
            // 
            // messageTextBox
            // 
            messageTextBox.Location = new Point(12, 328);
            messageTextBox.Multiline = true;
            messageTextBox.Name = "messageTextBox";
            messageTextBox.Size = new Size(384, 50);
            messageTextBox.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 37);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 6;
            label1.Text = "Введіть ім'я";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 390);
            Controls.Add(label1);
            Controls.Add(messageTextBox);
            Controls.Add(chatTextBox);
            Controls.Add(sendButton);
            Controls.Add(logoutButton);
            Controls.Add(loginButton);
            Controls.Add(userNameTextBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox userNameTextBox;
        private Button loginButton;
        private Button logoutButton;
        private Button sendButton;
        private TextBox chatTextBox;
        private TextBox messageTextBox;
        private Label label1;
    }
}
