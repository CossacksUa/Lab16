using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab16
{
    public partial class Form1 : Form
    {
        bool alive = false; // �� ���� ��������� ���� ��� ���������
        UdpClient client;
        const int LOCALPORT = 8001; // ���� ��� ��������� ����������
        const int REMOTEPORT = 8001; // ���� ��� ����������� ����������
        const int TTL = 20;
        const string HOST = "235.5.5.1"; // ���� ��� ��������� ����������
        IPAddress groupAddress; // ������ ��� ��������� ����������
        string userName; // ��� ����������� � ���

        public Form1()
        {
            InitializeComponent();
            loginButton.Enabled = true; // ������ �����
            logoutButton.Enabled = false; // ������ ������
            sendButton.Enabled = false; // ������ ��������
            chatTextBox.ReadOnly = true; // ���� ��� ����������
            groupAddress = IPAddress.Parse(HOST);
        }

        // ������� ������������ ��������� ����
        private void SetupChat()
        {
            userName = userNameTextBox.Text;
            userNameTextBox.ReadOnly = true;
            try
            {
                client = new UdpClient(LOCALPORT);
                //�������� �� ��������� ����������
                client.JoinMulticastGroup(groupAddress, TTL);

                // ������ �� ��������� ����������
                Task receiveTask = new Task(ReceiveMessages);
                receiveTask.Start();
                // ����� ����������� ��� ���� ������ �����������
                string message = userName + " ����� � ���";
                byte[] data = Encoding.Unicode.GetBytes(message);
                client.Send(data, data.Length, HOST, REMOTEPORT);
                loginButton.Enabled = false;
                logoutButton.Enabled = true;
                sendButton.Enabled = true;

                // ��������� ������ �� �����
                chatTextBox.AppendText($"Connected to: {HOST}:{REMOTEPORT}\r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ����� ��������� �����������
        private void ReceiveMessages()
        {
            alive = true;
            try
            {
                while (alive)
                {
                    IPEndPoint remoteIp = null;
                    byte[] data = client.Receive(ref remoteIp);
                    string message = Encoding.Unicode.GetString(data);
                    // ��������� ���������� ��������� � ��������� ����
                    this.Invoke(new MethodInvoker(() =>
                    {
                        string time = DateTime.Now.ToShortTimeString();
                        chatTextBox.BackColor = System.Drawing.Color.YellowGreen;
                        chatTextBox.Font = new System.Drawing.Font(chatTextBox.Font, System.Drawing.FontStyle.Bold);
                        chatTextBox.AppendText(time + " " + message + "\r\n");
                        SaveChatLog(time + " " + message);
                    }));
                }
            }
            catch (ObjectDisposedException)
            {
                if (!alive)
                    return;
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // ������� ��������� ���� ���� � ��������� ����
        private void SaveChatLog(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("chatlog.txt", true))
                {
                    writer.WriteLine(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving chat log: " + ex.Message);
            }
        }

        // �������� ���������� ������ loginButton
        private void loginButton_Click(object sender, EventArgs e)
        {
            SetupChat();
        }

        // �������� ���������� ������ sendButton
        private void sendButton_Click(object sender, EventArgs e)
        {
            try
            {
                string message = String.Format("{0}: {1}", userName, messageTextBox.Text);
                byte[] data = Encoding.Unicode.GetBytes(message);
                client.Send(data, data.Length, HOST, REMOTEPORT);
                messageTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // �������� ���������� ������ logoutButton
        private void logoutButton_Click(object sender, EventArgs e)
        {
            ExitChat();
        }

        // ����� � ����
        private void ExitChat()
        {
            string message = userName + " �������� ���";
            byte[] data = Encoding.Unicode.GetBytes(message);
            client.Send(data, data.Length, HOST, REMOTEPORT);
            client.DropMulticastGroup(groupAddress);
            alive = false;
            client.Close();
            loginButton.Enabled = true;
            logoutButton.Enabled = false;
            sendButton.Enabled = false;
            this.Invoke(new MethodInvoker(() =>
            {
                chatTextBox.BackColor = System.Drawing.Color.White;
            }));
        }

        // ���������� ������� �������� �����
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (alive)
                ExitChat();
        }
    }
}
