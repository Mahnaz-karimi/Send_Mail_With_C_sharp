using System;
using System.Net.Mail;
using Newtonsoft.Json.Linq;
using System.Timers;

namespace automatesend
{
    public partial class Form1 : Form
    {
        public static System.Timers.Timer newTimer = new System.Timers.Timer();

        public Form1()
        {
            InitializeComponent();
        }

        public void btnSendMail_Click(object sender, EventArgs e)
        {

            // Specify the path to the configuration file 
            string filePath = "C:/json/config.json";

            // Read the contents of the file
            string jsonContent = System.IO.File.ReadAllText(filePath);

            // Convert content to object JObject
            JObject data = JObject.Parse(jsonContent);

            // Extract values
            string DB_HOST = (string)data["DB_HOST"];


            List<string> mails = new List<string>() { "minexemple@gmail.com", "mahnaaz2021@gmail.com" };

            try
            {
                using (MailMessage mail = new MailMessage())
                {

                    mail.From = new MailAddress((string)data["EMAIL_HOST_USER"]);
                    for (int i = 0; i < mails.Count; i++)
                    {
                        mail.To.Add(mails[i]);
                        Console.WriteLine(mails[i]);
                    }
                    mail.Subject = "subject";
                    mail.Body = "<h1>This is a body</h1>";
                    mail.IsBodyHtml = true;


                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential((string)data["EMAIL_HOST_USER"], (string)data["EMAIL_HOST_PASSWORD"]);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        label1.Text = "Email send";

                    }

                }

            }
            catch (Exception ex)
            {
                label1.Text = ex.Message;
            }


        }

        public void Form1_Load(object sender, EventArgs e)
        {
            
            newTimer.Interval = 100000; // starter eventes
            newTimer.Elapsed += Form1_Load; // event for timer            
            newTimer.Start();
            btnSendMail_Click(null, null);
        }
    
    }
}