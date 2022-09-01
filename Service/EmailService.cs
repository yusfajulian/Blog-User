using Microsoft.Extensions.Options;
using pertemuan1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace pertemuan1.Service
{
    public class EmailService
    {
        // ini yang di daftarin di startapp,cs
        private readonly IOptions<Email> _dariJson;

        public EmailService(IOptions<Email> em)
        {
            _dariJson = em;
        }

        public bool KirimEmail(string tujuan,string judulEmail, string isiEmail)
        {
            try
            {
                // dapatkan data dari appsetting.json
                // tampung di variable
                Email e = new();
                e.NamaClientnya = _dariJson.Value.NamaClientnya;
                e.Portnya = _dariJson.Value.Portnya;
                e.EmailKita = _dariJson.Value.EmailKita;
                e.PasswordEmailKita = _dariJson.Value.PasswordEmailKita;

                // atur email
                MailMessage m = new();
                m.From = new MailAddress(e.EmailKita);
                m.Subject = judulEmail;
                m.Body = isiEmail;
                m.IsBodyHtml = true;
                m.To.Add(tujuan);

                // atur server
                SmtpClient s = new(e.NamaClientnya);
                s.Port = e.Portnya;
                s.Credentials = new System.Net.NetworkCredential(e.EmailKita, e.PasswordEmailKita);
                s.EnableSsl = true;
                s.Send(m);

                //Kalo berhasil
                return true;
            }
            catch
            {
                //kalo gagal
                return false;
            }
        }
    }
}
