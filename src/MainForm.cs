using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Simple_Hyperterminal
{
    public partial class MainForm : Form
    {
        #region Private Properties
        private Socket mySocket;                // The socket to be used
        private AsyncCallback acceptCallback;   // Callback to accept incoming connection requests
        private AsyncCallback receiveCallback;  // Callback to receive incoming data
        private Byte[] receiveBuffer;           // byte buffer to receive incoming data 
        private object lockObject = new object(); // Object to use as a lock (we use a GUI thread an seperate threads for Accept and Receive
        private bool isAscii = false;
        private int len = 0;
        private string hexacode = string.Empty;
        #endregion

        #region Form Methods and events
        /// <summary>
        /// Initialisation of the form
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // Init the local variables
            acceptCallback = new AsyncCallback(AcceptComplete);
            receiveCallback = new AsyncCallback(ReceiveComplete);
            receiveBuffer = new Byte[256];

            // Get the local IP addresses and add them to the combo box
            IPAddress[] localAddresses = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            cmbLocalIP.Items.AddRange(localAddresses);
            cmbLocalIP.Items.Add(IPAddress.Loopback);
            if (cmbLocalIP.Items.Count > 0)
            {
                cmbLocalIP.SelectedIndex = 0;
                // Adjust GUI
                txtLocalPort.ReadOnly = chkConnect.Checked;
                txtRemoteIP.ReadOnly = chkConnect.Checked;
                txtRemotePort.ReadOnly = chkConnect.Checked;
                cmbLocalIP.Enabled = !chkConnect.Checked;
                txtData.ReadOnly = !chkConnect.Checked;
                txtData2.ReadOnly = !chkConnect.Checked;

            }
        }


        /// <summary>
        /// Form closing event
        /// Used to clean up things
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mySocket != null)
            {
                CloseConnection();
            }
        } 
        #endregion

        #region Control Events
        /// <summary>
        /// Used for the input fields for port and IP address
        /// to make sure only numbers are entered
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numeric values and backspace
            e.Handled = !((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar == 8));

            // In case of the remote IP text box also allow the .
            if (sender == txtRemoteIP)
                e.Handled = !(!e.Handled || e.KeyChar == '.');
        }

        /// <summary>
        /// Send data as it is entered into the TextBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtData_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Make sure the socket is there and connected
            if (mySocket != null && mySocket.Connected)
            {
                // Change input key to string
                String dataToSend = e.KeyChar.ToString();
                // If Enter key is pressed add a line feed as well
                if (e.KeyChar == '\r')
                {
                    dataToSend += '\n';
                }
                // Change string into byte array
                byte[] data = Encoding.ASCII.GetBytes(dataToSend);
                // Send the data
                try
                {
                    mySocket.Send(data);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                if (e.KeyChar == '\r')
                {
                    txtData.Text = "";
                }
                
            }
        }

        /// <summary>
        /// Clear the data input text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtData.Text = "";
            txtData2.Text = "";
        }

        /// <summary>
        /// Open or close the connection as server or client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkConnect_CheckedChanged(object sender, EventArgs e)
        {
            // Adjust GUI
            txtLocalPort.ReadOnly = chkConnect.Checked;
            txtRemoteIP.ReadOnly = chkConnect.Checked;
            txtRemotePort.ReadOnly = chkConnect.Checked;
            cmbLocalIP.Enabled = !chkConnect.Checked;

            // Do we need to connect...
            if (chkConnect.Checked)
            {
                // Check if client or server is selected
                if (txtRemoteIP.Text == "")
                {
                    // Use as server
                    StartAsServer();
                }
                else
                {
                    // Use as client
                    StartAsClient();
                }
                // Set user input to data text field at the end of the current text
                txtData.Focus();
                txtData.SelectionStart = txtData.Text.Length;
            }
            else
            {
                // Close connection
                txtData.ReadOnly = true;
                CloseConnection();
            }
        } 

        private void autoFill_MouseClick(object sender, EventArgs e)
        {
            txtData.Focus();
            txtData.SelectionStart = txtData.Text.Length;
            string usr = FromConfig("USER");
            string pwd = FromConfig("PWD");
            byte[] data = Encoding.ASCII.GetBytes(usr+pwd);
            // Send the data
            try
            {
                mySocket.Send(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void genLog_MouseClick(object sender, EventArgs e)
        {
            txtData.Focus();
            txtData.SelectionStart = txtData.Text.Length;
            string cmd = FromConfig("LOGCMD");
            byte[] data = Encoding.ASCII.GetBytes(cmd);
            // Send the data
            try
            {
                mySocket.Send(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getProcSet_MouseClick(object sender, EventArgs e)
        {
            txtData.Focus();
            txtData.SelectionStart = txtData.Text.Length;
            byte[] data = Encoding.ASCII.GetBytes("rs\r\n");
            // Send the data
            try
            {
                mySocket.Send(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            isAscii = true;
        }


        #endregion

        #region Private Methods

        #region Socket Related Stuff
        /// <summary>
        /// Close the current connection
        /// </summary>
        private void CloseConnection()
        {
            if (mySocket != null)
            {
                // We need to lock this part of the code
                // Accepting a connection (as server) or receiving data
                // is handled asynchronously. So it might happen that we close
                // down the connection while at the same time we try to accept
                // a connection or read data. In both cases we would then try
                // to set a non-existing socket back to BeginReceive()
                lock (lockObject)
                {
                    // Close connection
                    mySocket.Shutdown(SocketShutdown.Both);
                    mySocket.Close();
                    mySocket = null;
                }
            }
        }

        /// <summary>
        /// Use the socket as server and put it to the listen state 
        /// to wait for incoming connection requests
        /// </summary>
        private void StartAsServer()
        {
            // Make sure local port is selected
            Int32 portNumber = Convert.ToInt32(txtLocalPort.Text);
            if (portNumber == 0)
            {
                MessageBox.Show("Please select a valid local port (>0)");
                chkConnect.Checked = false;
                return;
            }
            // Local IP address and port
            IPEndPoint localEndpoint = new IPEndPoint(cmbLocalIP.SelectedItem as IPAddress, portNumber);
            mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            mySocket.Bind(localEndpoint);
            // Let server listen (no backlog for incoming connections)
            mySocket.Listen(0);
            mySocket.BeginAccept(acceptCallback, mySocket);
        }

        /// <summary>
        /// Use the socket as a client
        /// </summary>
        private void StartAsClient()
        {
            // Test the IP Address
            IPAddress remoteIP;
            if (IPAddress.TryParse(txtRemoteIP.Text, out remoteIP))
            {
                // Define local and remote endpoint (use 0 as local port to let the system select one)
                IPEndPoint localEndpoint = new IPEndPoint(cmbLocalIP.SelectedItem as IPAddress, 0);
                IPEndPoint remoteEndpoint = new IPEndPoint(remoteIP, Convert.ToInt32(txtRemotePort.Text));
                mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                mySocket.Bind(localEndpoint);
                try
                {
                    // Connect
                    mySocket.Connect(remoteEndpoint);
                    // Start receiving data
                    mySocket.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, receiveCallback, mySocket);
                    txtData.ReadOnly = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    chkConnect.Checked = false;
                }
            }
        }

        /// <summary>
        /// Called when a connection request arrives
        /// </summary>
        /// <param name="result"></param>
        private void AcceptComplete(IAsyncResult result)
        {
            // Lock this part to make sure the GUI thread does not
            // try to close the connection at the same time
            lock (lockObject)
            {
                // Get the socket with the connection
                mySocket = mySocket.EndAccept(result);
                // Start receiving data
                try
                {
                    mySocket.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, receiveCallback, mySocket);
                    txtData.ReadOnly = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    chkConnect.Checked = false;
                } 
            }
        }

        /// <summary>
        /// Called when the socket received data
        /// This is not called on the GUI thread so we cannot
        /// use it to write into controls directly
        /// </summary>
        /// <param name="result"></param>
        private void ReceiveComplete(IAsyncResult result)
        {
            // Lock this part to make sure the GUI thread does not
            // try to close the connection at the same time
            lock (lockObject)
            {
                if (mySocket != null && mySocket.Connected)
                {
                    Int32 receivedBytes = mySocket.EndReceive(result);
                    if (receivedBytes > 0)
                    {
                        string s = Encoding.ASCII.GetString(receiveBuffer, 0, receivedBytes);
                        if(isAscii)
                        {
                            if(len==0)
                            {
                                string[] subs = s.Split('\n');
                                len = int.Parse(subs[1].Replace("\n", "").Replace("\r", ""));
                            }
                            if(hexacode.Length < len+256)
                                hexacode += s;
                            else
                            {
                                string[] hexacodes = hexacode.Split('\r');
                                string hexacod = string.Empty;
                                for(int i = 2; i<(len/80); i++)
                                    hexacod += hexacodes[i];
                                s = ConvertHex(len, hexacod.Replace("\n", "").Replace("\r", ""));
                                AddText(txtData2, s);
                                isAscii = false;
                                len = 0;
                                hexacode = string.Empty;
                            }
                            
                        }
                        //If intro display else sequence
                        else if(!s.Contains("<"))
                            AddText(txtData2, s);
                        else{
                            s = s.Replace(">", ":   >");
                            string[] subs = s.Split('>', '<');
                            foreach (var sub in subs)
                                if(!sub.Contains("/") && !string.IsNullOrEmpty(sub))
                                    AddText(txtData2, sub);
                        }
                    }
                    // Set the socket back into receive state
                    try
                    {
                        mySocket.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, receiveCallback, mySocket);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        SetCheckState(chkConnect, false);
                    }
                } 
            }
        } 

        /// <summary>
        /// Convert hexadecimal to ascii
        /// </summary>
        /// <param name="hexString"></param>
        public static string ConvertHex(int l, String hexString)
        {
            string rs = string.Empty;
            for(int k = 0; k<(l/80)-10; k++)
            {
                string sub = hexString.Substring(k*80,80);
                try
                {
                    string ascii = string.Empty;

                    for (int i = 0; i < sub.Length; i += 2)
                    {
                        String hs = string.Empty;

                        hs   = sub.Replace("\n", "").Replace("\r", "").Substring(i,2);
                        uint decval =   System.Convert.ToUInt32(hs, 16);
                        char character = System.Convert.ToChar(decval);
                        ascii += character;

                    }

                    rs += ascii;
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            return rs;
        }

        public static string FromConfig(String label)
        {
            String line = string.Empty;
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("config.txt");
                bool fnd = false;
                //Read the first line of text
                line = sr.ReadLine();
                while (!fnd && line != "ENDCONFIG")
                {
                    if(line.Contains(label) && label != "LOGCMD")
                    {
                        string[] subs = line.Split(' ');                    
                        line = subs[1]+"\r\n";
                        fnd = true;
                    }
                    else if(line.Contains(label) && label == "LOGCMD")
                    {
                        line = sr.ReadLine();
                        line += "\r\n";
                        while (!line.Contains("ENDCONFIG"))
                        {
                            line += sr.ReadLine();
                            line += "\r\n";
                            //Console.WriteLine(line);
                        }
                        fnd = true;
                        line = line.Replace("ENDCONFIG\r\n", "");
                    }
                    else
                        line = sr.ReadLine();
                }
                //close the file
                sr.Close();             
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return line;
        }

        #endregion

        #region Other Stuff
        /// <summary>
        /// Delegate to write into a TextBox from a thread other that the GUI
        /// </summary>
        /// <param name="box"></param>
        /// <param name="data"></param>
        private delegate void AddTextDelegate(TextBox box, String data);

        /// <summary>
        /// Method to write into a TextBox from a thread other that the GUI
        /// </summary>
        /// <param name="box"></param>
        /// <param name="data"></param>
        private void AddText(TextBox box, String data)
        {
            if (InvokeRequired)
            {
                AddTextDelegate del = new AddTextDelegate(AddText);
                Invoke(del, new object[] { box, data });
                return;
            }

            box.Text += data;
            box.SelectionStart = box.Text.Length;
        }

        /// <summary>
        /// Delegate to set the Checked state of a CheckBox control
        /// from a thread other than the GUI
        /// </summary>
        /// <param name="box"></param>
        /// <param name="state"></param>
        private delegate void SetCheckStateDelegate(CheckBox box, Boolean state);

        /// <summary>
        /// Method to set the Checked state of a CheckBox control
        /// from a thread other than the GUI
        /// </summary>
        /// <param name="box"></param>
        /// <param name="state"></param>
        private void SetCheckState(CheckBox box, Boolean state)
        {
            if (InvokeRequired)
            {
                SetCheckStateDelegate del = new SetCheckStateDelegate(SetCheckState);
                Invoke(del, new object[] { box, state });
                return;
            }

            box.Checked = state;
        }
        #endregion

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
