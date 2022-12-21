using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Globalization;
using PROJETO;

public static class EmailAvisoAdministradorSendEmail
{
	public static bool Send(string ParNAME, string ParLOGIN, string ParEMAIL, string ParPASSWORD)
	{
		EmailAvisoAdministradorEmailProvider Email = new EmailAvisoAdministradorEmailProvider((ParNAME), (ParLOGIN), (ParEMAIL), (ParPASSWORD));
		return Email.Send();
	}
}

public class EmailAvisoAdministradorEmailProvider
{
	public string ParNAME = "";
	public string ParLOGIN = "";
	public string ParEMAIL = "";
	public string ParPASSWORD = "";
	public EmailAvisoAdministradorEmailProvider(string ParNAME, string ParLOGIN, string ParEMAIL, string ParPASSWORD)
	{
		Attachments = new List<Attachment>();
        Destinatarios = new List<string>();
		this.ParNAME = ParNAME;
		this.ParLOGIN = ParLOGIN;
		this.ParEMAIL = ParEMAIL;
		this.ParPASSWORD = ParPASSWORD;
	}

	public string DestinatarioEmail
	{
		get
		{
			return (ParEMAIL).ToString();
		}
	}

	public string DestinatarioNome
	{
		get
		{
			return (ParNAME).ToString();
		}
	}

	public string RemetenteEmail
	{
		get
		{
			return (EnvironmentVariable.DBGERPROJETO.TB_PARAMETRO.HDEmail).ToString();
		}
	}

	public string RemetenteNome
	{
		get
		{
			return (EnvironmentVariable.DBGERPROJETO.TB_PARAMETRO.HDNome).ToString();
		}
	}

	public string Usuario
	{
		get
		{
			return ("pls.suporte@dnit.gov.br").ToString();
		}
	}

	public string Senha
	{
		get
		{
			return ("0").ToString();
		}
	}

	public string Assunto
	{
		get
		{
			return ("Novo Cadastro de usuário no GProjeto").ToString();
		}
	}

	public string Conteudo
	{
		get
		{
			string EMail = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + @"\Pages\Email\EmailAvisoAdministradorEmailBody.gwmail");
			EMail = EMail.Replace("¥", "");
			return EMail;
		}
	}

	public string Smtp
	{
		get
		{
			return (EnvironmentVariable.DBGERPROJETO.TB_PARAMETRO.HDSMTP).ToString();
		}
	}

	public int Porta
	{
		get
		{
			return Convert.ToInt32(EnvironmentVariable.DBGERPROJETO.TB_PARAMETRO.HDPorta);
		}
	}

	public bool SSL
	{
		get
		{
			return Convert.ToBoolean(EnvironmentVariable.DBGERPROJETO.TB_PARAMETRO.HDSSL);
		}
	}

    public List<Attachment> Attachments { get; set; }
    
	public List<string> Destinatarios { get; set; }
	
	public bool Send()
	{
		try
		{
			MailMessage msg = new MailMessage();
            if (Destinatarios.Count == 0)
            {
                string[] dest = DestinatarioEmail.Split(',');
                foreach (string destEmail in dest)
                {
                    MailAddress Destinatario = new MailAddress(destEmail, DestinatarioNome);
                    msg.To.Add(Destinatario);
                }
            }
            else
            {
                foreach (string dest in Destinatarios)
                {
                    string[] parts = dest.Split(';');
                    MailAddress Destinatario = new MailAddress(parts[1], parts[0]);
                    msg.To.Add(Destinatario);
                }

            }			msg.From = new MailAddress(RemetenteEmail, RemetenteNome);
			msg.Subject = Assunto;
			msg.IsBodyHtml = true;
			msg.Body = Conteudo;

			foreach (Attachment att in Attachments)
            {
                msg.Attachments.Add(att);
            }

			SmtpClient SmtpClient = new SmtpClient(Smtp, Porta);
			SmtpClient.UseDefaultCredentials = false;
			SmtpClient.Credentials = new System.Net.NetworkCredential(Usuario, Senha);
			SmtpClient.EnableSsl = SSL;
			SmtpClient.Send(msg);

			msg.Dispose();
			SmtpClient = null;
			return true;
		}
		catch (System.IO.IOException e)
		{
			return false;
		}
	}

}
