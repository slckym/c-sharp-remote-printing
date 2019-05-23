using System;
using System.Drawing;
using System.Windows.Forms;
using SuperSocket.WebSocket;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Printing;
using Microsoft.Win32;
using System.Diagnostics;
using System.Collections.Generic;
using PdfiumViewer;

namespace POSPrinter
{

    public partial class Form1 : Form
    {
        string AppName = "PrintServer";
        
        private static WebSocketServer wsServer;

        private string orderPrinter;

        private IniFile Settings = new IniFile(Path.GetTempPath() + @"\Settings.ini");

        RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        private NotifyIcon notifyIcon1;

        public enum PrintType
        {
            PdfBuffer = 1,
        };

        public static string GetPrintType(PrintType type)
        {
            string result = String.Empty;
            switch (type)
            {
                case PrintType.PdfBuffer:
                default:
                    result = "pdf-buffer";
                    break;
            }
            return result;
        }
        
        public Form1()
        {
            InitializeComponent();
            wsServer = new WebSocketServer();
            var config = new ServerConfig
            {
                Name = AppName,
                Port = 6441,
                MaxRequestLength = Int32.MaxValue,
                Mode = SocketMode.Tcp
            };

            this.notifyIcon1 = new NotifyIcon();
            this.notifyIcon1.Icon = new System.Drawing.Icon("icon.ico");
            this.notifyIcon1.Text = this.AppName;
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += NotifyIcon1_DoubleClick;
            this.notifyIcon1.Visible = false;


            wsServer.Setup(new RootConfig(), config); 

            wsServer.NewSessionConnected += WsServer_NewSessionConnected;
            wsServer.NewMessageReceived += WsServer_NewMessageReceived;
            wsServer.NewDataReceived += WsServer_NewDataReceived;
            wsServer.SessionClosed += WsServer_SessionClosed;
            wsServer.Start();

            lblWsClientConnection.Text = "Server started";
            lblWsClientConnection.ForeColor = Color.Green;
        }

        private void WsServer_SessionClosed(WebSocketSession session, SuperSocket.SocketBase.CloseReason value)
        {
            try
            {
                lblWsClientConnection.Text = String.Format("{0} client connected", wsServer.SessionCount.ToString());
                lblWsClientConnection.ForeColor = Color.Green;
                if(wsServer.SessionCount == 0)
                {
                    lblWsClientConnection.Text = "Waiting client...";
                    lblWsClientConnection.ForeColor = Color.Orange;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WsServer_NewDataReceived(WebSocketSession session, byte[] value)
        {
            throw new NotImplementedException();
        }

        private void WsServer_NewMessageReceived(WebSocketSession session, string sourceString)
        {
            string json = @sourceString;
            JObject parsed = JObject.Parse(json);

            string type = parsed["type"].Value<string>();
            double width = parsed["width"].Value<double>();
            double height = parsed["height"].Value<double>();

            if ( type == GetPrintType(PrintType.PdfBuffer))
            {
                List<Byte> buffer = parsed["data"].ToObject<List<Byte>>();

                string tempWritePath = Path.Combine(Path.GetTempPath(), "NeedzaPosPrinter");
                string tempFilePath = Path.Combine(tempWritePath, "receipt.pdf");
                Directory.CreateDirectory(tempWritePath);
                File.WriteAllBytes(tempFilePath, buffer.ToArray());

                this.PrintPdf(tempFilePath, (int)width, (int)height);
            }
        }

        private void PrintPdf(string filePath, int width, int height)
        {
            float multiplier = 300f/(float)width;

            try
            {
                // Create the printer settings for our printer
                var printerSettings = new System.Drawing.Printing.PrinterSettings
                {
                    PrinterName = orderPrinter,
                    Copies = (short)1,
                };

                // Create our page settings for the paper size selected
                var pageSettings = new System.Drawing.Printing.PageSettings(printerSettings)
                {
                    Margins = new System.Drawing.Printing.Margins(100, 100, 0, 0),
                    PaperSize = new System.Drawing.Printing.PaperSize("receipt", (int)(width* multiplier), (int)(height*multiplier))
                };

                // Now print the PDF document
                using (var document = PdfDocument.Load(filePath))
                {
                    using (var printDocument = document.CreatePrintDocument())
                    {
                        printDocument.PrinterSettings = printerSettings;
                        printDocument.DefaultPageSettings = pageSettings;
                        printDocument.PrintController = new System.Drawing.Printing.StandardPrintController();
                        printDocument.Print();
                    }
                }
            }
            catch
            {

            }


            /*
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = @Directory.GetCurrentDirectory() + @"\PDFtoPrinter.exe";
            startInfo.Arguments = "\"" + @filePath + "\" \"" + orderPrinter + "\"";
            process.StartInfo = startInfo;
            process.Start();
            */

        }

        private void WsServer_NewSessionConnected(WebSocketSession session)
        {
            lblWsClientConnection.Text = String.Format("{0} Client connected.", wsServer.SessionCount.ToString());
            lblWsClientConnection.ForeColor = Color.Green;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            bgwListPrinters.RunWorkerAsync();
            if (rkApp.GetValue("PrintServer") == null)
            {
                runOnStartUp.Checked = false;
            }
            else
            {
                runOnStartUp.Checked = true;
            }
        }
        
        private void btnSavePrinters_Click(object sender, EventArgs e)
        {
            Settings.Write("Order", cmbOrderPrinters.SelectedItem.ToString(), "Printer");
            bgwListPrinters.RunWorkerAsync();
        }
        
        private PrintQueueCollection listSharedPrinters()
        {
            PrintServer printServer = new PrintServer();
            PrintQueueCollection printQueues = printServer.GetPrintQueues(new[]
            {
                EnumeratedPrintQueueTypes.Local,
                EnumeratedPrintQueueTypes.Connections
            });

            return printQueues;
        }

        private void LoadPrinters()
        {
            orderPrinter = Settings.Read("Order", "Printer");

            cmbOrderPrinters.Items.Clear();

            int index = 0;
            foreach (var printer in listSharedPrinters())
            {
                cmbOrderPrinters.Items.Add(printer.FullName);
                if (printer.FullName == orderPrinter)
                {
                    cmbOrderPrinters.SelectedIndex = index;
                }
                index++;
            }
        }

        private void bgwListPrinters_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            LoadPrinters();
        }

        private void runOnStartUp_Click(object sender, EventArgs e)
        {
            runOnStartUp.Checked = !runOnStartUp.Checked;

            if (runOnStartUp.Checked)
            {
                rkApp.SetValue(AppName, Application.ExecutablePath);
            }
            else
            {
                rkApp.DeleteValue(AppName, false);
            }
        }

        private void btnReloadPrinters_Click(object sender, EventArgs e)
        {
            bgwListPrinters.RunWorkerAsync();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == System.Windows.Forms.CloseReason.UserClosing)
            {
                //myNotifyIcon.Visible = true;
                this.Hide();
                this.notifyIcon1.Visible = true;
                e.Cancel = true;
            }
        }

        private void NotifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.notifyIcon1.Visible = false;
        }
    }
}
