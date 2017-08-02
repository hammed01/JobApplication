Email server that sends mail from .Net Applications to multiple recipients, download mails e.t.c.
Mails can be sent to single and multiple recipients depending on the functions used from the package

Usage:

1. In class where its to be used, just import the name space "EfueliteSolutionsMailHandler".

2. To send mail to single recipients, call string status = MailServer.SendMailSync(string FromEMailAddress, string FromEMailAddressDisplayName,
         string ToEMailAddresses, string ccEMailAddresses,
         string bccEMailAddresses, string Subject, string Message, string SMTPHost, string SMTPPort,
         string SMTPUser, string SMTPPassword,bool EnableSSL, bool ValidateServerCertificate);
		 
		 
	This function returns a string status telling the outcome of its operation.
	Parameters:
	FromEMailAddress: this  is the email address where the mail will be sent from.
	FromEMailAddressDisplayName: this  is the display name of the email address where the mail will be sent from.
	ToEMailAddresses: this is the email address where the mail will be sent to.
	ccEMailAddresses: a copy of the mail will be sent to this email address.
	bccEMailAddresses: a copy of the mail will be sent to this email address without the other recipients knowing about it.
	Subject: the subject of the email.
	Message: the body of the message, could be html e.t.c.
	SMTPHost: the smtp host of the email server.
	SMTPPort: the port for the mail server. usually a number.
	SMTPUser: the email address used to send out the mail.
	SMTPPassword: the password to the email address to be used for sending out mails.
	The information to log in string format.
	EnableSSL: this a boolean value that takes true/false. determines if the mail server requires the use of SSL or not.
	ValidateServerCertificate: this a boolean value that takes true/false. determines if the Server Certificate will be validated or not.
	
3. To send mail to multiple recipients, just add the email addresses separated by comma to the respective to,cc,bcc field e.g. info@efuelite.com,xyz@efuelite.com


For further enquiries, you can send mails to info@efuelite.com