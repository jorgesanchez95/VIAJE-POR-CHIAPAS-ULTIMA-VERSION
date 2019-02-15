using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace CreativaSl.Web.ViajesPorChiapas.Models
{
    public static class Comun
    {
        static string _dominio = "http://www.viajeporchiapas.com/";

        static string _facebook = "#";
        static string _twitter = "#";
        static string _googleplus = "#";
        static string _instagram = "#";
        static string _youtube = "#";
        static string codigo = " 35071010002";
        public static Image ResizeImage(Image srcImage, int newWidth, int newHeight)
        {
            using (Bitmap imagenBitmap =
               new Bitmap(newWidth, newHeight, PixelFormat.Format32bppRgb))
            {
                imagenBitmap.SetResolution(
                   Convert.ToInt32(srcImage.HorizontalResolution),
                   Convert.ToInt32(srcImage.HorizontalResolution));

                using (Graphics imagenGraphics =
                        Graphics.FromImage(imagenBitmap))
                {
                    imagenGraphics.SmoothingMode =
                       SmoothingMode.AntiAlias;
                    imagenGraphics.InterpolationMode =
                       InterpolationMode.HighQualityBicubic;
                    imagenGraphics.PixelOffsetMode =
                       PixelOffsetMode.HighQuality;
                    imagenGraphics.DrawImage(srcImage,
                       new Rectangle(0, 0, newWidth, newHeight),
                       new Rectangle(0, 0, srcImage.Width, srcImage.Height),
                       GraphicsUnit.Pixel);
                    MemoryStream imagenMemoryStream = new MemoryStream();
                    imagenBitmap.Save(imagenMemoryStream, ImageFormat.Jpeg);
                    srcImage = Image.FromStream(imagenMemoryStream);
                }
            }
            return srcImage;
        }
        public static bool EnviarCorreo(string De, string Contraseña, string Para, string Asunto, string Mensaje, bool banArchivo, string Archivo, bool Html, string Host, int Port, bool Ssl)
        {
            try
            {
                //GMAIL
                //Habilitar las siguientes opciones en correo de gmail
                //https://www.google.com/settings/security/lesssecureapps
                //https://accounts.google.com/DisplayUnlockCaptcha
                //HOTMAIL
                //Enviara las primeras veces despues nos llegara un correo para reconocer el inicio de sesion 
                //ya que depende del servidor donde esta alojado y se tiene que reconocer el inicio de sesion 
                System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                mailMessage.From = new System.Net.Mail.MailAddress(De);
                mailMessage.To.Add(Para);
                mailMessage.Subject = Asunto;
                if (banArchivo)
                    mailMessage.Attachments.Add(new System.Net.Mail.Attachment(Archivo));
                mailMessage.Body = Mensaje;
                mailMessage.IsBodyHtml = Html;
                System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient(Host);
                smtpClient.Port = Port;
                smtpClient.EnableSsl = Ssl;
                smtpClient.Credentials = new NetworkCredential(De, Contraseña);
                smtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #region HtmlContacto
        public static string GenerarHtmlRegistoUsuario(string Usuario, string Password)
        {
            string dominio = _dominio;
            string login = "/Admin/Account/";
            string creativa = "creativasoftline.com";
            string html = @"
            <!DOCTYPE html>
	        <html>
	        <head>
		        <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" />
		        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
		        <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"">
		        <meta name=""format-detection"" content=""telephone=no"" />
		        <title>Viaje por Chiapas</title>
		        <style type=""text/css"">
			        html { background-color:#E1E1E1; margin:0; padding:0; }
			        body, #bodyTable, #bodyCell, #bodyCell{height:100% !important; margin:0; padding:0; width:100% !important;font-family:Helvetica, Arial, ""Lucida Grande"", sans-serif;}
			        table{border-collapse:collapse;}
			        table[id=bodyTable] {width:100%!important;margin:auto;max-width:500px!important;color:#b6b24c;font-weight:normal;}
			        img, a img{border:0; outline:none; text-decoration:none;height:auto; line-height:100%;}
			        a {text-decoration:none !important;border-bottom: 1px solid;}
			        h1, h2, h3, h4, h5, h6{color:#5F5F5F; font-weight:normal; font-family:Helvetica; font-size:20px; line-height:125%; text-align:Left; letter-spacing:normal;margin-top:0;margin-right:0;margin-bottom:10px;margin-left:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;}
			        .ReadMsgBody{width:100%;} .ExternalClass{width:100%;} /* Force Hotmail/Outlook.com to display emails at full width. */
			        .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div{line-height:100%;} /* Force Hotmail/Outlook.com to display line heights normally. */
			        table, td{mso-table-lspace:0pt; mso-table-rspace:0pt;} /* Remove spacing between tables in Outlook 2007 and up. */
			        #outlook a{padding:0;} /* Force Outlook 2007 and up to provide a ""view in browser"" message. */
			        img{-ms-interpolation-mode: bicubic;display:block;outline:none; text-decoration:none;} /* Force IE to smoothly render resized images. */
			        body, table, td, p, a, li, blockquote{-ms-text-size-adjust:100%; -webkit-text-size-adjust:100%; font-weight:normal!important;} /* Prevent Windows- and Webkit-based mobile platforms from changing declared text sizes. */
			        .ExternalClass td[class=""ecxflexibleContainerBox""] h3 {padding-top: 10px !important;} /* Force hotmail to push 2-grid sub headers down */

			        h1{display:block;font-size:26px;font-style:normal;font-weight:normal;line-height:100%;}
			        h2{display:block;font-size:20px;font-style:normal;font-weight:normal;line-height:120%;}
			        h3{display:block;font-size:17px;font-style:normal;font-weight:normal;line-height:110%;}
			        h4{display:block;font-size:18px;font-style:italic;font-weight:normal;line-height:100%;}
			        .flexibleImage{height:auto;}
			        .linkRemoveBorder{border-bottom:0 !important;}
			        table[class=flexibleContainerCellDivider] {padding-bottom:0 !important;padding-top:0 !important;}

			        body, #bodyTable{background-color:#E1E1E1;}
			        #emailHeader{background-color:#b6b24c;}
			        #emailBody{background-color:#FFFFFF;}
			        #emailFooter{background-color:#E1E1E1;}
			        .nestedContainer{background-color:#F8F8F8; border:1px solid #CCCCCC;}
			        .emailButton{background-color:#205478; border-collapse:separate;}
			        .buttonContent{color:#FFFFFF; font-family:Helvetica; font-size:18px; font-weight:bold; line-height:100%; padding:15px; text-align:center;}
			        .buttonContent a{color:#FFFFFF; display:block; text-decoration:none!important; border:0!important;}
			        .emailCalendar{background-color:#FFFFFF; border:1px solid #CCCCCC;}
			        .emailCalendarMonth{background-color:#205478; color:#FFFFFF; font-family:Helvetica, Arial, sans-serif; font-size:16px; font-weight:bold; padding-top:10px; padding-bottom:10px; text-align:center;}
			        .emailCalendarDay{color:#205478; font-family:Helvetica, Arial, sans-serif; font-size:60px; font-weight:bold; line-height:100%; padding-top:20px; padding-bottom:20px; text-align:center;}
			        .imageContentText {margin-top: 10px;line-height:0;}
			        .imageContentText a {line-height:0;}
			        #invisibleIntroduction {display:none !important;} /* Removing the introduction text from the view */
			        span[class=ios-color-hack] a {color:#275100!important;text-decoration:none!important;}
			        span[class=ios-color-hack2] a {color:#205478!important;text-decoration:none!important;}
			        span[class=ios-color-hack3] a {color:#8B8B8B!important;text-decoration:none!important;}
			        .a[href^=""tel""], a[href^=""sms""] {text-decoration:none!important;color:#606060!important;pointer-events:none!important;cursor:default!important;}
			        .mobile_link a[href^=""tel""], .mobile_link a[href^=""sms""] {text-decoration:none!important;color:#606060!important;pointer-events:auto!important;cursor:default!important;}

			        @media only screen and (max-width: 480px){
				        body{width:100% !important; min-width:100% !important;}
				        /*td[class=""textContent""], td[class=""flexibleContainerCell""] { width: 100%; padding-left: 10px !important; padding-right: 10px !important; }*/
				        table[id=""emailHeader""],
				        table[id=""emailBody""],
				        table[id=""emailFooter""],
				        table[class=""flexibleContainer""],
				        td[class=""flexibleContainerCell""] {width:100% !important;}
				        td[class=""flexibleContainerBox""], td[class=""flexibleContainerBox""] table {display: block;width: 100%;text-align: left;}
				        td[class=""imageContent""] img {height:auto !important; width:100% !important; max-width:100% !important; }
				        img[class=""flexibleImage""]{height:auto !important; width:100% !important;max-width:100% !important;}
				        img[class=""flexibleImageSmall""]{height:auto !important; width:auto !important;}
				        table[class=""emailButton""]{width:100% !important;}
				        td[class=""buttonContent""]{padding:0 !important;}
				        td[class=""buttonContent""] a{padding:15px !important;}
			        }
			        @media only screen and (-webkit-device-pixel-ratio:.75){
			        }
			        @media only screen and (-webkit-device-pixel-ratio:1){
			        }
			        @media only screen and (-webkit-device-pixel-ratio:1.5){
			        }
			        @media only screen and (min-device-width : 320px) and (max-device-width:568px) {
			        }
		        </style>
		        <!--[if mso 12]><style type=""text/css"">.flexibleContainer{display:block !important; width:100% !important;}</style><![endif]-->
		        <!--[if mso 14]><style type=""text/css"">.flexibleContainer{display:block !important; width:100% !important;}</style><![endif]-->
	        </head>
	        <body bgcolor=""#E1E1E1"" leftmargin=""0"" marginwidth=""0"" topmargin=""0"" marginheight=""0"" offset=""0"">
		        <center style=""background-color:#E1E1E1;"">
			        <table border=""0"" cellpadding=""0"" cellspacing=""0"" height=""100%"" width=""100%"" id=""bodyTable"" style=""table-layout: fixed;max-width:100% !important;width: 100% !important;min-width: 100% !important;"">
				        <tr>
					        <td align=""center"" valign=""top"" id=""bodyCell"">
						        <table bgcolor=""#FFFFFF""  border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" id=""emailBody"">
							        <tr>
								        <td align=""center"" valign=""top"">
									        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""color:#FFFFFF;"" bgcolor=""#3498db"">
										        <tr>
											        <td align=""center"" valign=""top"">
												        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
													        <tr>
														        <td align=""center"" valign=""top"" width=""500"" class=""flexibleContainerCell"">
															        <table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""100%"">
																        <tr>
																	        <td align=""center"" valign=""top"" class=""textContent"">
																		        <h1 style=""color:#FFFFFF;line-height:100%;font-family:Helvetica,Arial,sans-serif;font-size:35px;font-weight:normal;margin-bottom:5px;text-align:center;"">Viaje por Chiapas</h1>
																		        <h2 style=""text-align:center;font-weight:normal;font-family:Helvetica,Arial,sans-serif;font-size:23px;margin-bottom:10px;color:#205478;line-height:135%;"">Viaje por Chiapas, A.C.</h2>
																		        <div style=""text-align:center;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#FFFFFF;line-height:135%;"">Promooción</div>
																	        </td>
																        </tr>
															        </table>
														        </td>
													        </tr>
												        </table>
											        </td>
										        </tr>
									        </table>
								        </td>
							        </tr>
							        <tr mc:hideable>
								        <td align=""center"" valign=""top"">
									        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
										        <tr>
											        <td align=""center"" valign=""top"">
												        <table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
													        <tr>
														        <td valign=""top"" width=""500"" class=""flexibleContainerCell"">
															        <table align=""left"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
																        <tr>
																	        <td align=""left"" valign=""top"" class=""flexibleContainerBox"">
																		        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""210"" style=""max-width: 100%;"">
																			        <tr>
																				        <td align=""left"" class=""textContent"">
																					        <h3 style=""color:#5F5F5F;line-height:125%;font-family:Helvetica,Arial,sans-serif;font-size:20px;font-weight:normal;margin-top:0;margin-bottom:3px;text-align:left;"">Usuario:</h3>
																					        <div style=""text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;"">" + Usuario + @"</div>
																				        </td>
																			        </tr>
																		        </table>
																	        </td>
																	        <td align=""right"" valign=""middle"" class=""flexibleContainerBox"">
																		        <table class=""flexibleContainerBoxNext"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""210"" style=""max-width: 100%;"">
																			        <tr>
																				        <td align=""left"" class=""textContent"">
																					        <h3 style=""color:#5F5F5F;line-height:125%;font-family:Helvetica,Arial,sans-serif;font-size:20px;font-weight:normal;margin-top:0;margin-bottom:3px;text-align:left;"">Contraseña:</h3>
																					        <div style=""text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;"">" + Password + @"</div>
																				        </td>
																			        </tr>
																		        </table>
																	        </td>
																        </tr>
															        </table>
															        <br><br>
														        </td>
													        </tr>
												        </table>
											        </td>
										        </tr>
									        </table>
								        </td>
							        </tr>
							        <tr>
								        <td align=""center"" valign=""top"">
									        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
										        <tr style=""padding-top:0;"">
											        <td align=""center"" valign=""top"">
												        <table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
													        <tr>
														        <td style=""padding-top:0;"" align=""center"" valign=""top"" width=""500"" class=""flexibleContainerCell"">
															        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""50%"" class=""emailButton"" style=""background-color: #b6b24c;"">
																        <tr>
																	        <td align=""center"" valign=""middle"" class=""buttonContent"" style=""padding-top:15px;padding-bottom:15px;padding-right:15px;padding-left:15px;"">
																		        <a style=""color:#FFFFFF;text-decoration:none;font-family:Helvetica,Arial,sans-serif;font-size:20px;line-height:135%;"" href=""" + dominio + login + @""" target=""_blank"">Ingresar</a>
																	        </td>
																        </tr>
															        </table>
														        </td>
													        </tr>
												        </table>
											        </td>
										        </tr>
									        </table>
								        </td>
							        </tr>
						        </table>
						        <table bgcolor=""#E1E1E1"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" id=""emailFooter"">
							        <tr>
								        <td align=""center"" valign=""top"">
									        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
										        <tr>
											        <td align=""center"" valign=""top"">
												        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
													        <tr>
														        <td align=""center"" valign=""top"" width=""500"" class=""flexibleContainerCell"">
															        <table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""100%"">
																        <tr>
																	        <td valign=""top"" bgcolor=""#E1E1E1"">
																		        <div style=""font-family:Helvetica,Arial,sans-serif;font-size:13px;color:#828282;text-align:center;line-height:120%;"">
																			        <div>Copyright &#169; 2016 <a href=""" + dominio + @""" target=""_blank"" style=""text-decoration:none;color:#828282;""><span style=""color:#828282;"">CSL</span></a>. All&nbsp;rights&nbsp;reserved.</div>
																			        <div>Creativa Softline <a href=""" + creativa + @""" target=""""_blank"""" style=""text-decoration:none;color:#828282;""><span style=""color:#828282;"">comunicarse</span></a>.</div>
																		        </div>
																	        </td>
																        </tr>
															        </table>
														        </td>
													        </tr>
												        </table>
											        </td>
										        </tr>
									        </table>
								        </td>
							        </tr>
						        </table>
					        </td>
				        </tr>
			        </table>
		        </center>
	        </body>
        </html>
            ";
            return html;
        }
        public static string GenerarHtmlMensajeContacto(string Nombre, string Correo, string Telefono, string Mensaje)
        {
            string dominio = _dominio;
            string login = "/Admin/Account/";
            string creativa = "creativasoftline.com";
            string html = @"
            <!DOCTYPE html>
	        <html>
	        <head>
		        <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" />
		        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
		        <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"">
		        <meta name=""format-detection"" content=""telephone=no"" />
		        <title>Viaje por Chiapas</title>
		        <style type=""text/css"">
			        html { background-color:#E1E1E1; margin:0; padding:0; }
			        body, #bodyTable, #bodyCell, #bodyCell{height:100% !important; margin:0; padding:0; width:100% !important;font-family:Helvetica, Arial, ""Lucida Grande"", sans-serif;}
			        table{border-collapse:collapse;}
			        table[id=bodyTable] {width:100%!important;margin:auto;max-width:500px!important;color:#b6b24c;font-weight:normal;}
			        img, a img{border:0; outline:none; text-decoration:none;height:auto; line-height:100%;}
			        a {text-decoration:none !important;border-bottom: 1px solid;}
			        h1, h2, h3, h4, h5, h6{color:#5F5F5F; font-weight:normal; font-family:Helvetica; font-size:20px; line-height:125%; text-align:Left; letter-spacing:normal;margin-top:0;margin-right:0;margin-bottom:10px;margin-left:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;}
			        .ReadMsgBody{width:100%;} .ExternalClass{width:100%;} /* Force Hotmail/Outlook.com to display emails at full width. */
			        .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div{line-height:100%;} /* Force Hotmail/Outlook.com to display line heights normally. */
			        table, td{mso-table-lspace:0pt; mso-table-rspace:0pt;} /* Remove spacing between tables in Outlook 2007 and up. */
			        #outlook a{padding:0;} /* Force Outlook 2007 and up to provide a ""view in browser"" message. */
			        img{-ms-interpolation-mode: bicubic;display:block;outline:none; text-decoration:none;} /* Force IE to smoothly render resized images. */
			        body, table, td, p, a, li, blockquote{-ms-text-size-adjust:100%; -webkit-text-size-adjust:100%; font-weight:normal!important;} /* Prevent Windows- and Webkit-based mobile platforms from changing declared text sizes. */
			        .ExternalClass td[class=""ecxflexibleContainerBox""] h3 {padding-top: 10px !important;} /* Force hotmail to push 2-grid sub headers down */

			        h1{display:block;font-size:26px;font-style:normal;font-weight:normal;line-height:100%;}
			        h2{display:block;font-size:20px;font-style:normal;font-weight:normal;line-height:120%;}
			        h3{display:block;font-size:17px;font-style:normal;font-weight:normal;line-height:110%;}
			        h4{display:block;font-size:18px;font-style:italic;font-weight:normal;line-height:100%;}
			        .flexibleImage{height:auto;}
			        .linkRemoveBorder{border-bottom:0 !important;}
			        table[class=flexibleContainerCellDivider] {padding-bottom:0 !important;padding-top:0 !important;}

			        body, #bodyTable{background-color:#E1E1E1;}
			        #emailHeader{background-color:#b6b24c;}
			        #emailBody{background-color:#FFFFFF;}
			        #emailFooter{background-color:#E1E1E1;}
			        .nestedContainer{background-color:#F8F8F8; border:1px solid #CCCCCC;}
			        .emailButton{background-color:#205478; border-collapse:separate;}
			        .buttonContent{color:#FFFFFF; font-family:Helvetica; font-size:18px; font-weight:bold; line-height:100%; padding:15px; text-align:center;}
			        .buttonContent a{color:#FFFFFF; display:block; text-decoration:none!important; border:0!important;}
			        .emailCalendar{background-color:#FFFFFF; border:1px solid #CCCCCC;}
			        .emailCalendarMonth{background-color:#205478; color:#FFFFFF; font-family:Helvetica, Arial, sans-serif; font-size:16px; font-weight:bold; padding-top:10px; padding-bottom:10px; text-align:center;}
			        .emailCalendarDay{color:#205478; font-family:Helvetica, Arial, sans-serif; font-size:60px; font-weight:bold; line-height:100%; padding-top:20px; padding-bottom:20px; text-align:center;}
			        .imageContentText {margin-top: 10px;line-height:0;}
			        .imageContentText a {line-height:0;}
			        #invisibleIntroduction {display:none !important;} /* Removing the introduction text from the view */
			        span[class=ios-color-hack] a {color:#275100!important;text-decoration:none!important;}
			        span[class=ios-color-hack2] a {color:#205478!important;text-decoration:none!important;}
			        span[class=ios-color-hack3] a {color:#8B8B8B!important;text-decoration:none!important;}
			        .a[href^=""tel""], a[href^=""sms""] {text-decoration:none!important;color:#606060!important;pointer-events:none!important;cursor:default!important;}
			        .mobile_link a[href^=""tel""], .mobile_link a[href^=""sms""] {text-decoration:none!important;color:#606060!important;pointer-events:auto!important;cursor:default!important;}

			        @media only screen and (max-width: 480px){
				        body{width:100% !important; min-width:100% !important;}
				        /*td[class=""textContent""], td[class=""flexibleContainerCell""] { width: 100%; padding-left: 10px !important; padding-right: 10px !important; }*/
				        table[id=""emailHeader""],
				        table[id=""emailBody""],
				        table[id=""emailFooter""],
				        table[class=""flexibleContainer""],
				        td[class=""flexibleContainerCell""] {width:100% !important;}
				        td[class=""flexibleContainerBox""], td[class=""flexibleContainerBox""] table {display: block;width: 100%;text-align: left;}
				        td[class=""imageContent""] img {height:auto !important; width:100% !important; max-width:100% !important; }
				        img[class=""flexibleImage""]{height:auto !important; width:100% !important;max-width:100% !important;}
				        img[class=""flexibleImageSmall""]{height:auto !important; width:auto !important;}
				        table[class=""emailButton""]{width:100% !important;}
				        td[class=""buttonContent""]{padding:0 !important;}
				        td[class=""buttonContent""] a{padding:15px !important;}
			        }
			        @media only screen and (-webkit-device-pixel-ratio:.75){
			        }
			        @media only screen and (-webkit-device-pixel-ratio:1){
			        }
			        @media only screen and (-webkit-device-pixel-ratio:1.5){
			        }
			        @media only screen and (min-device-width : 320px) and (max-device-width:568px) {
			        }
		        </style>
		        <!--[if mso 12]><style type=""text/css"">.flexibleContainer{display:block !important; width:100% !important;}</style><![endif]-->
		        <!--[if mso 14]><style type=""text/css"">.flexibleContainer{display:block !important; width:100% !important;}</style><![endif]-->
	        </head>
	        <body bgcolor=""#E1E1E1"" leftmargin=""0"" marginwidth=""0"" topmargin=""0"" marginheight=""0"" offset=""0"">
		        <center style=""background-color:#E1E1E1;"">
			        <table border=""0"" cellpadding=""0"" cellspacing=""0"" height=""100%"" width=""100%"" id=""bodyTable"" style=""table-layout: fixed;max-width:100% !important;width: 100% !important;min-width: 100% !important;"">
				        <tr>
					        <td align=""center"" valign=""top"" id=""bodyCell"">
						        <table bgcolor=""#FFFFFF""  border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" id=""emailBody"">
							        <tr>
								        <td align=""center"" valign=""top"">
									        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""color:#FFFFFF;"" bgcolor=""#3498db"">
										        <tr>
											        <td align=""center"" valign=""top"">
												        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
													        <tr>
														        <td align=""center"" valign=""top"" width=""500"" class=""flexibleContainerCell"">
															        <table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""100%"">
																        <tr>
																	        <td align=""center"" valign=""top"" class=""textContent"">
																		        <h1 style=""color:#FFFFFF;line-height:100%;font-family:Helvetica,Arial,sans-serif;font-size:35px;font-weight:normal;margin-bottom:5px;text-align:center;"">Viaje por Chiapas</h1>
																		        <h2 style=""text-align:center;font-weight:normal;font-family:Helvetica,Arial,sans-serif;font-size:23px;margin-bottom:10px;color:#205478;line-height:135%;"">Viajes Por Chiapas</h2>
																		        <div style=""text-align:center;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#FFFFFF;line-height:135%;"">Gracias por contactarnos "+Nombre+@", hemos recibido tu mensaje, en breve le responderemos</div>
																	        </td>
																        </tr>
															        </table>
														        </td>
													        </tr>
												        </table>
											        </td>
										        </tr>
									        </table>
								        </td>
							        </tr>
							        <tr mc:hideable>
								        <td align=""center"" valign=""top"">
									        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
										        <tr>
											        <td align=""center"" valign=""top"">
												        <table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
													        <tr>
														        <td valign=""top"" width=""500"" class=""flexibleContainerCell"">
															        <table align=""left"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
																        <tr>
																	        <td align=""left"" valign=""top"" class=""flexibleContainerBox"">
																		        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""210"" style=""max-width: 100%;"">
																			        <tr>
																				        <td align=""left"" class=""textContent"">
																					        <h3 style=""color:#5F5F5F;line-height:125%;font-family:Helvetica,Arial,sans-serif;font-size:20px;font-weight:normal;margin-top:0;margin-bottom:3px;text-align:left;"">Nombre:</h3>
																					        <div style=""text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;"">" + Nombre + @"</div>
																				        </td>
																			        </tr>
																		        </table>
																	        </td>
																	        <td align=""right"" valign=""middle"" class=""flexibleContainerBox"">
																		        <table class=""flexibleContainerBoxNext"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""210"" style=""max-width: 100%;"">
																			        <tr>
																				        <td align=""left"" class=""textContent"">
																					        <h3 style=""color:#5F5F5F;line-height:125%;font-family:Helvetica,Arial,sans-serif;font-size:20px;font-weight:normal;margin-top:0;margin-bottom:3px;text-align:left;"">Correo:</h3>
																					        <div style=""text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;"">" + Correo + @"</div>
																				        </td>
																			        </tr>
																		        </table>
																	        </td>
																        </tr>
																        <tr>
																	        <td align=""left"" valign=""top"" class=""flexibleContainerBox"">
																		        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""210"" style=""max-width: 100%;"">
																			        <tr>
																				        <td align=""left"" class=""textContent"">
																					        <h3 style=""color:#5F5F5F;line-height:125%;font-family:Helvetica,Arial,sans-serif;font-size:20px;font-weight:normal;margin-top:0;margin-bottom:3px;text-align:left;"">Telefono:</h3>
																					        <div style=""text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;"">" + Telefono + @"</div>
																				        </td>
																			        </tr>
																		        </table>
																	        </td>
																        </tr>
															        </table>
															        <br><br>
														        </td>
													        </tr>
												        </table>
											        </td>
										        </tr>
									        </table>
								        </td>
							        </tr>
							        <tr>
								        <td align=""center"" valign=""top"">
											<table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
												<tr style=""padding-top:0;"">
													<td align=""center"" valign=""top"">
														<table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
															<tr>
																<td align=""left"" class=""textContent"">
																	<h3 style=""color:#5F5F5F;line-height:125%;font-family:Helvetica,Arial,sans-serif;font-size:20px;font-weight:normal;margin-top:0;margin-bottom:3px;text-align:left;"">Mensaje:</h3>
																	<div style=""text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;"">" + Mensaje + @"</div>
														        </td>
															</tr>
														</table>
													</td>
												</tr>
											</table>
										</td>
							        </tr>
						        </table>
						        <table bgcolor=""#E1E1E1"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" id=""emailFooter"">
							        <tr>
								        <td align=""center"" valign=""top"">
									        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
										        <tr>
											        <td align=""center"" valign=""top"">
												        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
													        <tr>
														        <td align=""center"" valign=""top"" width=""500"" class=""flexibleContainerCell"">
															        <table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""100%"">
																        <tr>
																	        <td valign=""top"" bgcolor=""#E1E1E1"">
																		        <div style=""font-family:Helvetica,Arial,sans-serif;font-size:13px;color:#828282;text-align:center;line-height:120%;"">
																			        <div>Copyright &#169; 2016 <a href=""" + dominio + @""" target=""_blank"" style=""text-decoration:none;color:#828282;""><span style=""color:#828282;"">CSL</span></a>. All&nbsp;rights&nbsp;reserved.</div>
																			        <div>Creativa Softline <a href=""" + creativa + @""" target=""""_blank"""" style=""text-decoration:none;color:#828282;""><span style=""color:#828282;"">comunicarse</span></a>.</div>
																		        </div>
																	        </td>
																        </tr>
															        </table>
														        </td>
													        </tr>
												        </table>
											        </td>
										        </tr>
									        </table>
								        </td>
							        </tr>
						        </table>
					        </td>
				        </tr>
			        </table>
		        </center>
	        </body>
        </html>
            ";
            return html;
        }
        public static string GenerarHtmlRespuestaContacto(string Nombre, string Correo, string Telefono, string Mensaje, string Respuesta)
        {
            string dominio = _dominio;
            string login = "/Admin/Account/";
            string creativa = "creativasoftline.com";
            string html = @"
                        <!DOCTYPE html>
	        <html>
	        <head>
		        <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" />
		        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
		        <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"">
		        <meta name=""format-detection"" content=""telephone=no"" />
		        <title>viaje por chiapas</title>
		        <style type=""text/css"">
			        html { background-color:#E1E1E1; margin:0; padding:0; }
			        body, #bodyTable, #bodyCell, #bodyCell{height:100% !important; margin:0; padding:0; width:100% !important;font-family:Helvetica, Arial, ""Lucida Grande"", sans-serif;}
			        table{border-collapse:collapse;}
			        table[id=bodyTable] {width:100%!important;margin:auto;max-width:500px!important;color:#b6b24c;font-weight:normal;}
			        img, a img{border:0; outline:none; text-decoration:none;height:auto; line-height:100%;}
			        a {text-decoration:none !important;border-bottom: 1px solid;}
			        h1, h2, h3, h4, h5, h6{color:#5F5F5F; font-weight:normal; font-family:Helvetica; font-size:20px; line-height:125%; text-align:Left; letter-spacing:normal;margin-top:0;margin-right:0;margin-bottom:10px;margin-left:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;}
			        .ReadMsgBody{width:100%;} .ExternalClass{width:100%;} /* Force Hotmail/Outlook.com to display emails at full width. */
			        .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div{line-height:100%;} /* Force Hotmail/Outlook.com to display line heights normally. */
			        table, td{mso-table-lspace:0pt; mso-table-rspace:0pt;} /* Remove spacing between tables in Outlook 2007 and up. */
			        #outlook a{padding:0;} /* Force Outlook 2007 and up to provide a ""view in browser"" message. */
			        img{-ms-interpolation-mode: bicubic;display:block;outline:none; text-decoration:none;} /* Force IE to smoothly render resized images. */
			        body, table, td, p, a, li, blockquote{-ms-text-size-adjust:100%; -webkit-text-size-adjust:100%; font-weight:normal!important;} /* Prevent Windows- and Webkit-based mobile platforms from changing declared text sizes. */
			        .ExternalClass td[class=""ecxflexibleContainerBox""] h3 {padding-top: 10px !important;} /* Force hotmail to push 2-grid sub headers down */

			        h1{display:block;font-size:26px;font-style:normal;font-weight:normal;line-height:100%;}
			        h2{display:block;font-size:20px;font-style:normal;font-weight:normal;line-height:120%;}
			        h3{display:block;font-size:17px;font-style:normal;font-weight:normal;line-height:110%;}
			        h4{display:block;font-size:18px;font-style:italic;font-weight:normal;line-height:100%;}
			        .flexibleImage{height:auto;}
			        .linkRemoveBorder{border-bottom:0 !important;}
			        table[class=flexibleContainerCellDivider] {padding-bottom:0 !important;padding-top:0 !important;}

			        body, #bodyTable{background-color:#E1E1E1;}
			        #emailHeader{background-color:#b6b24c;}
			        #emailBody{background-color:#FFFFFF;}
			        #emailFooter{background-color:#E1E1E1;}
			        .nestedContainer{background-color:#F8F8F8; border:1px solid #CCCCCC;}
			        .emailButton{background-color:#205478; border-collapse:separate;}
			        .buttonContent{color:#FFFFFF; font-family:Helvetica; font-size:18px; font-weight:bold; line-height:100%; padding:15px; text-align:center;}
			        .buttonContent a{color:#FFFFFF; display:block; text-decoration:none!important; border:0!important;}
			        .emailCalendar{background-color:#FFFFFF; border:1px solid #CCCCCC;}
			        .emailCalendarMonth{background-color:#205478; color:#FFFFFF; font-family:Helvetica, Arial, sans-serif; font-size:16px; font-weight:bold; padding-top:10px; padding-bottom:10px; text-align:center;}
			        .emailCalendarDay{color:#205478; font-family:Helvetica, Arial, sans-serif; font-size:60px; font-weight:bold; line-height:100%; padding-top:20px; padding-bottom:20px; text-align:center;}
			        .imageContentText {margin-top: 10px;line-height:0;}
			        .imageContentText a {line-height:0;}
			        #invisibleIntroduction {display:none !important;} /* Removing the introduction text from the view */
			        span[class=ios-color-hack] a {color:#275100!important;text-decoration:none!important;}
			        span[class=ios-color-hack2] a {color:#205478!important;text-decoration:none!important;}
			        span[class=ios-color-hack3] a {color:#8B8B8B!important;text-decoration:none!important;}
			        .a[href^=""tel""], a[href^=""sms""] {text-decoration:none!important;color:#606060!important;pointer-events:none!important;cursor:default!important;}
			        .mobile_link a[href^=""tel""], .mobile_link a[href^=""sms""] {text-decoration:none!important;color:#606060!important;pointer-events:auto!important;cursor:default!important;}

			        @media only screen and (max-width: 480px){
				        body{width:100% !important; min-width:100% !important;}
				        /*td[class=""textContent""], td[class=""flexibleContainerCell""] { width: 100%; padding-left: 10px !important; padding-right: 10px !important; }*/
				        table[id=""emailHeader""],
				        table[id=""emailBody""],
				        table[id=""emailFooter""],
				        table[class=""flexibleContainer""],
				        td[class=""flexibleContainerCell""] {width:100% !important;}
				        td[class=""flexibleContainerBox""], td[class=""flexibleContainerBox""] table {display: block;width: 100%;text-align: left;}
				        td[class=""imageContent""] img {height:auto !important; width:100% !important; max-width:100% !important; }
				        img[class=""flexibleImage""]{height:auto !important; width:100% !important;max-width:100% !important;}
				        img[class=""flexibleImageSmall""]{height:auto !important; width:auto !important;}
				        table[class=""emailButton""]{width:100% !important;}
				        td[class=""buttonContent""]{padding:0 !important;}
				        td[class=""buttonContent""] a{padding:15px !important;}
			        }
			        @media only screen and (-webkit-device-pixel-ratio:.75){
			        }
			        @media only screen and (-webkit-device-pixel-ratio:1){
			        }
			        @media only screen and (-webkit-device-pixel-ratio:1.5){
			        }
			        @media only screen and (min-device-width : 320px) and (max-device-width:568px) {
			        }
		        </style>
		        <!--[if mso 12]><style type=""text/css"">.flexibleContainer{display:block !important; width:100% !important;}</style><![endif]-->
		        <!--[if mso 14]><style type=""text/css"">.flexibleContainer{display:block !important; width:100% !important;}</style><![endif]-->
	        </head>
	        <body bgcolor=""#E1E1E1"" leftmargin=""0"" marginwidth=""0"" topmargin=""0"" marginheight=""0"" offset=""0"">
		        <center style=""background-color:#E1E1E1;"">
			        <table border=""0"" cellpadding=""0"" cellspacing=""0"" height=""100%"" width=""100%"" id=""bodyTable"" style=""table-layout: fixed;max-width:100% !important;width: 100% !important;min-width: 100% !important;"">
				        <tr>
					        <td align=""center"" valign=""top"" id=""bodyCell"">
						        <table bgcolor=""#FFFFFF""  border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" id=""emailBody"">
							        <tr>
								        <td align=""center"" valign=""top"">
									        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""color:#FFFFFF;"" bgcolor=""#3498db"">
										        <tr>
											        <td align=""center"" valign=""top"">
												        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
													        <tr>
														        <td align=""center"" valign=""top"" width=""500"" class=""flexibleContainerCell"">
															        <table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""100%"">
																        <tr>
																	        <td align=""center"" valign=""top"" class=""textContent"">
																		        <h1 style=""color:#FFFFFF;line-height:100%;font-family:Helvetica,Arial,sans-serif;font-size:35px;font-weight:normal;margin-bottom:5px;text-align:center;"">viaje por chiapas</h1>
																		        <h2 style=""text-align:center;font-weight:normal;font-family:Helvetica,Arial,sans-serif;font-size:23px;margin-bottom:10px;color:#205478;line-height:135%;"">viaje por chiapas</h2>
																		        <div style=""text-align:center;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#FFFFFF;line-height:135%;"">Gracias por contactarnos "+Nombre+@"</div>
																	        </td>
																        </tr>
															        </table>
														        </td>
													        </tr>
												        </table>
											        </td>
										        </tr>
									        </table>
								        </td>
							        </tr>
							        <tr mc:hideable>
								        <td align=""center"" valign=""top"">
									        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
										        <tr>
											        <td align=""center"" valign=""top"">
												        <table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
													        <tr>
														        <td valign=""top"" width=""500"" class=""flexibleContainerCell"">
															        <table align=""left"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
																        <tr>
																	        <td align=""left"" valign=""top"" class=""flexibleContainerBox"">
																		        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""210"" style=""max-width: 100%;"">
																			        <tr>
																				        <td align=""left"" class=""textContent"">
																					        <h3 style=""color:#5F5F5F;line-height:125%;font-family:Helvetica,Arial,sans-serif;font-size:20px;font-weight:normal;margin-top:0;margin-bottom:3px;text-align:left;"">Nombre:</h3>
																					        <div style=""text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;"">" + Nombre + @"</div>
																				        </td>
																			        </tr>
																		        </table>
																	        </td>
																	        <td align=""right"" valign=""middle"" class=""flexibleContainerBox"">
																		        <table class=""flexibleContainerBoxNext"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""210"" style=""max-width: 100%;"">
																			        <tr>
																				        <td align=""left"" class=""textContent"">
																					        <h3 style=""color:#5F5F5F;line-height:125%;font-family:Helvetica,Arial,sans-serif;font-size:20px;font-weight:normal;margin-top:0;margin-bottom:3px;text-align:left;"">Correo:</h3>
																					        <div style=""text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;"">" + Correo + @"</div>
																				        </td>
																			        </tr>
																		        </table>
																	        </td>
																        </tr>
																        <tr>
																	        <td align=""left"" valign=""top"" class=""flexibleContainerBox"">
																		        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""210"" style=""max-width: 100%;"">
																			        <tr>
																				        <td align=""left"" class=""textContent"">
																					        <h3 style=""color:#5F5F5F;line-height:125%;font-family:Helvetica,Arial,sans-serif;font-size:20px;font-weight:normal;margin-top:0;margin-bottom:3px;text-align:left;"">Telefono:</h3>
																					        <div style=""text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;"">" + Telefono + @"</div>
																				        </td>
																			        </tr>
																		        </table>
																	        </td>
																        </tr>
															        </table>
															        <br><br>
														        </td>
													        </tr>
												        </table>
											        </td>
										        </tr>
									        </table>
								        </td>
							        </tr>
							        <tr>
								        <td align=""center"" valign=""top"">
											<table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
												<tr style=""padding-top:0;"">
													<td align=""center"" valign=""top"">
														<table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
															<tr>
																<td align=""left"" class=""textContent"">
																	<h3 style=""color:#5F5F5F;line-height:125%;font-family:Helvetica,Arial,sans-serif;font-size:20px;font-weight:normal;margin-top:0;margin-bottom:3px;text-align:left;"">Mensaje:</h3>
																	<div style=""text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;"">" + Mensaje + @"</div>
														        </td>
															</tr>
														</table>
													</td>
												</tr>
											</table>
										</td>
							        </tr>
							        <tr>
								        <td align=""center"" valign=""top"">
											<table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
												<tr style=""padding-top:0;"">
													<td align=""center"" valign=""top"">
														<table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
															<tr>
																<td align=""left"" class=""textContent"">
																	<h3 style=""color:#5F5F5F;line-height:125%;font-family:Helvetica,Arial,sans-serif;font-size:20px;font-weight:normal;margin-top:0;margin-bottom:3px;text-align:left;"">Respuesta:</h3>
																	<div style=""text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;"">" + Respuesta + @"</div>
														        </td>
															</tr>
														</table>
													</td>
												</tr>
											</table>
										</td>
							        </tr>
						        </table>
						        <table bgcolor=""#E1E1E1"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" id=""emailFooter"">
							        <tr>
								        <td align=""center"" valign=""top"">
									        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
										        <tr>
											        <td align=""center"" valign=""top"">
												        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
													        <tr>
														        <td align=""center"" valign=""top"" width=""500"" class=""flexibleContainerCell"">
															        <table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""100%"">
																        <tr>
																	        <td valign=""top"" bgcolor=""#E1E1E1"">
																		        <div style=""font-family:Helvetica,Arial,sans-serif;font-size:13px;color:#828282;text-align:center;line-height:120%;"">
																			        <div>Copyright &#169; 2016 <a href=""" + dominio + @""" target=""_blank"" style=""text-decoration:none;color:#828282;""><span style=""color:#828282;"">CSL</span></a>. All&nbsp;rights&nbsp;reserved.</div>
																			        <div>Creativa Softline <a href=""" + creativa + @""" target=""""_blank"""" style=""text-decoration:none;color:#828282;""><span style=""color:#828282;"">comunicarse</span></a>.</div>
																		        </div>
																	        </td>
																        </tr>
															        </table>
														        </td>
													        </tr>
												        </table>
											        </td>
										        </tr>
									        </table>
								        </td>
							        </tr>
						        </table>
					        </td>
				        </tr>
			        </table>
		        </center>
	        </body>
        </html>
            ";
            return html;
        }
        public static string GenerarHtmlResetContraseña(string usuario, string password)
        {
            string dominio = _dominio;
            string login = "/Admin/Account/";
            string creativa = "creativasoftline.com";
            string html = @"
            <!DOCTYPE html>
	        <html>
	        <head>
		        <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" />
		        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
		        <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"">
		        <meta name=""format-detection"" content=""telephone=no"" />
		        <title>Viaje por Chiapas</title>
		        <style type=""text/css"">
			        html { background-color:#E1E1E1; margin:0; padding:0; }
			        body, #bodyTable, #bodyCell, #bodyCell{height:100% !important; margin:0; padding:0; width:100% !important;font-family:Helvetica, Arial, ""Lucida Grande"", sans-serif;}
			        table{border-collapse:collapse;}
			        table[id=bodyTable] {width:100%!important;margin:auto;max-width:500px!important;color:#b6b24c;font-weight:normal;}
			        img, a img{border:0; outline:none; text-decoration:none;height:auto; line-height:100%;}
			        a {text-decoration:none !important;border-bottom: 1px solid;}
			        h1, h2, h3, h4, h5, h6{color:#5F5F5F; font-weight:normal; font-family:Helvetica; font-size:20px; line-height:125%; text-align:Left; letter-spacing:normal;margin-top:0;margin-right:0;margin-bottom:10px;margin-left:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;}
			        .ReadMsgBody{width:100%;} .ExternalClass{width:100%;} /* Force Hotmail/Outlook.com to display emails at full width. */
			        .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div{line-height:100%;} /* Force Hotmail/Outlook.com to display line heights normally. */
			        table, td{mso-table-lspace:0pt; mso-table-rspace:0pt;} /* Remove spacing between tables in Outlook 2007 and up. */
			        #outlook a{padding:0;} /* Force Outlook 2007 and up to provide a ""view in browser"" message. */
			        img{-ms-interpolation-mode: bicubic;display:block;outline:none; text-decoration:none;} /* Force IE to smoothly render resized images. */
			        body, table, td, p, a, li, blockquote{-ms-text-size-adjust:100%; -webkit-text-size-adjust:100%; font-weight:normal!important;} /* Prevent Windows- and Webkit-based mobile platforms from changing declared text sizes. */
			        .ExternalClass td[class=""ecxflexibleContainerBox""] h3 {padding-top: 10px !important;} /* Force hotmail to push 2-grid sub headers down */

			        h1{display:block;font-size:26px;font-style:normal;font-weight:normal;line-height:100%;}
			        h2{display:block;font-size:20px;font-style:normal;font-weight:normal;line-height:120%;}
			        h3{display:block;font-size:17px;font-style:normal;font-weight:normal;line-height:110%;}
			        h4{display:block;font-size:18px;font-style:italic;font-weight:normal;line-height:100%;}
			        .flexibleImage{height:auto;}
			        .linkRemoveBorder{border-bottom:0 !important;}
			        table[class=flexibleContainerCellDivider] {padding-bottom:0 !important;padding-top:0 !important;}

			        body, #bodyTable{background-color:#E1E1E1;}
			        #emailHeader{background-color:#b6b24c;}
			        #emailBody{background-color:#FFFFFF;}
			        #emailFooter{background-color:#E1E1E1;}
			        .nestedContainer{background-color:#F8F8F8; border:1px solid #CCCCCC;}
			        .emailButton{background-color:#205478; border-collapse:separate;}
			        .buttonContent{color:#FFFFFF; font-family:Helvetica; font-size:18px; font-weight:bold; line-height:100%; padding:15px; text-align:center;}
			        .buttonContent a{color:#FFFFFF; display:block; text-decoration:none!important; border:0!important;}
			        .emailCalendar{background-color:#FFFFFF; border:1px solid #CCCCCC;}
			        .emailCalendarMonth{background-color:#205478; color:#FFFFFF; font-family:Helvetica, Arial, sans-serif; font-size:16px; font-weight:bold; padding-top:10px; padding-bottom:10px; text-align:center;}
			        .emailCalendarDay{color:#205478; font-family:Helvetica, Arial, sans-serif; font-size:60px; font-weight:bold; line-height:100%; padding-top:20px; padding-bottom:20px; text-align:center;}
			        .imageContentText {margin-top: 10px;line-height:0;}
			        .imageContentText a {line-height:0;}
			        #invisibleIntroduction {display:none !important;} /* Removing the introduction text from the view */
			        span[class=ios-color-hack] a {color:#275100!important;text-decoration:none!important;}
			        span[class=ios-color-hack2] a {color:#205478!important;text-decoration:none!important;}
			        span[class=ios-color-hack3] a {color:#8B8B8B!important;text-decoration:none!important;}
			        .a[href^=""tel""], a[href^=""sms""] {text-decoration:none!important;color:#606060!important;pointer-events:none!important;cursor:default!important;}
			        .mobile_link a[href^=""tel""], .mobile_link a[href^=""sms""] {text-decoration:none!important;color:#606060!important;pointer-events:auto!important;cursor:default!important;}

			        @media only screen and (max-width: 480px){
				        body{width:100% !important; min-width:100% !important;}
				        /*td[class=""textContent""], td[class=""flexibleContainerCell""] { width: 100%; padding-left: 10px !important; padding-right: 10px !important; }*/
				        table[id=""emailHeader""],
				        table[id=""emailBody""],
				        table[id=""emailFooter""],
				        table[class=""flexibleContainer""],
				        td[class=""flexibleContainerCell""] {width:100% !important;}
				        td[class=""flexibleContainerBox""], td[class=""flexibleContainerBox""] table {display: block;width: 100%;text-align: left;}
				        td[class=""imageContent""] img {height:auto !important; width:100% !important; max-width:100% !important; }
				        img[class=""flexibleImage""]{height:auto !important; width:100% !important;max-width:100% !important;}
				        img[class=""flexibleImageSmall""]{height:auto !important; width:auto !important;}
				        table[class=""emailButton""]{width:100% !important;}
				        td[class=""buttonContent""]{padding:0 !important;}
				        td[class=""buttonContent""] a{padding:15px !important;}
			        }
			        @media only screen and (-webkit-device-pixel-ratio:.75){
			        }
			        @media only screen and (-webkit-device-pixel-ratio:1){
			        }
			        @media only screen and (-webkit-device-pixel-ratio:1.5){
			        }
			        @media only screen and (min-device-width : 320px) and (max-device-width:568px) {
			        }
		        </style>
		        <!--[if mso 12]><style type=""text/css"">.flexibleContainer{display:block !important; width:100% !important;}</style><![endif]-->
		        <!--[if mso 14]><style type=""text/css"">.flexibleContainer{display:block !important; width:100% !important;}</style><![endif]-->
	        </head>
	        <body bgcolor=""#E1E1E1"" leftmargin=""0"" marginwidth=""0"" topmargin=""0"" marginheight=""0"" offset=""0"">
		        <center style=""background-color:#E1E1E1;"">
			        <table border=""0"" cellpadding=""0"" cellspacing=""0"" height=""100%"" width=""100%"" id=""bodyTable"" style=""table-layout: fixed;max-width:100% !important;width: 100% !important;min-width: 100% !important;"">
				        <tr>
					        <td align=""center"" valign=""top"" id=""bodyCell"">
						        <table bgcolor=""#FFFFFF""  border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" id=""emailBody"">
							        <tr>
								        <td align=""center"" valign=""top"">
									        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""color:#FFFFFF;"" bgcolor=""#3498db"">
										        <tr>
											        <td align=""center"" valign=""top"">
												        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
													        <tr>
														        <td align=""center"" valign=""top"" width=""500"" class=""flexibleContainerCell"">
															        <table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""100%"">
																        <tr>
																	        <td align=""center"" valign=""top"" class=""textContent"">
																		        <h1 style=""color:#FFFFFF;line-height:100%;font-family:Helvetica,Arial,sans-serif;font-size:35px;font-weight:normal;margin-bottom:5px;text-align:center;"">Viaje por Chiapas</h1>
																		        <h2 style=""text-align:center;font-weight:normal;font-family:Helvetica,Arial,sans-serif;font-size:23px;margin-bottom:10px;color:#205478;line-height:135%;"">Viaje por Chiapas</h2>
																		        <div style=""text-align:center;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#FFFFFF;line-height:135%;"">Contraseña reseteada este es usuario y contraseña</div>
																	        </td>
																        </tr>
															        </table>
														        </td>
													        </tr>
												        </table>
											        </td>
										        </tr>
									        </table>
								        </td>
							        </tr>
							        <tr mc:hideable>
								        <td align=""center"" valign=""top"">
									        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
										        <tr>
											        <td align=""center"" valign=""top"">
												        <table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
													        <tr>
														        <td valign=""top"" width=""500"" class=""flexibleContainerCell"">
															        <table align=""left"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
																        <tr>
																	        <td align=""left"" valign=""top"" class=""flexibleContainerBox"">
																		        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""210"" style=""max-width: 100%;"">
																			        <tr>
																				        <td align=""left"" class=""textContent"">
																					        <h3 style=""color:#5F5F5F;line-height:125%;font-family:Helvetica,Arial,sans-serif;font-size:20px;font-weight:normal;margin-top:0;margin-bottom:3px;text-align:left;"">Usuario:</h3>
																					        <div style=""text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;"">" + usuario + @"</div>
																				        </td>
																			        </tr>
																		        </table>
																	        </td>
																	        <td align=""right"" valign=""middle"" class=""flexibleContainerBox"">
																		        <table class=""flexibleContainerBoxNext"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""210"" style=""max-width: 100%;"">
																			        <tr>
																				        <td align=""left"" class=""textContent"">
																					        <h3 style=""color:#5F5F5F;line-height:125%;font-family:Helvetica,Arial,sans-serif;font-size:20px;font-weight:normal;margin-top:0;margin-bottom:3px;text-align:left;"">Contraseña:</h3>
																					        <div style=""text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;"">" + password + @"</div>
																				        </td>
																			        </tr>
																		        </table>
																	        </td>
																        </tr>
															        </table>
															        <br><br>
														        </td>
													        </tr>
												        </table>
											        </td>
										        </tr>
									        </table>
								        </td>
							        </tr>
							        <tr>
								        <td align=""center"" valign=""top"">
									        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
										        <tr style=""padding-top:0;"">
											        <td align=""center"" valign=""top"">
												        <table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
													        <tr>
														        <td style=""padding-top:0;"" align=""center"" valign=""top"" width=""500"" class=""flexibleContainerCell"">
															        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""50%"" class=""emailButton"" style=""background-color: #b6b24c;"">
																        <tr>
																	        <td align=""center"" valign=""middle"" class=""buttonContent"" style=""padding-top:15px;padding-bottom:15px;padding-right:15px;padding-left:15px;"">
																		        <a style=""color:#FFFFFF;text-decoration:none;font-family:Helvetica,Arial,sans-serif;font-size:20px;line-height:135%;"" href=""" + dominio + login + @""" target=""_blank"">Ingresar</a>
																	        </td>
																        </tr>
															        </table>
														        </td>
													        </tr>
												        </table>
											        </td>
										        </tr>
									        </table>
								        </td>
							        </tr>
						        </table>
						        <table bgcolor=""#E1E1E1"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" id=""emailFooter"">
							        <tr>
								        <td align=""center"" valign=""top"">
									        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
										        <tr>
											        <td align=""center"" valign=""top"">
												        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
													        <tr>
														        <td align=""center"" valign=""top"" width=""500"" class=""flexibleContainerCell"">
															        <table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""100%"">
																        <tr>
																	        <td valign=""top"" bgcolor=""#E1E1E1"">
																		        <div style=""font-family:Helvetica,Arial,sans-serif;font-size:13px;color:#828282;text-align:center;line-height:120%;"">
																			        <div>Copyright &#169; 2016 <a href=""" + dominio + @""" target=""_blank"" style=""text-decoration:none;color:#828282;""><span style=""color:#828282;"">CSL</span></a>. All&nbsp;rights&nbsp;reserved.</div>
																			        <div>Creativa Softline <a href=""" + creativa + @""" target=""""_blank"""" style=""text-decoration:none;color:#828282;""><span style=""color:#828282;"">comunicarse</span></a>.</div>
																		        </div>
																	        </td>
																        </tr>
															        </table>
														        </td>
													        </tr>
												        </table>
											        </td>
										        </tr>
									        </table>
								        </td>
							        </tr>
						        </table>
					        </td>
				        </tr>
			        </table>
		        </center>
	        </body>
        </html>
            ";
            return html;
        }
        public static string GenerarHtmlResetContraseñaPaginaWeb(string usuario, string password)
        {
            string dominio = _dominio;
            string login = "/Login/";
            string creativa = "creativasoftline.com";
            string html = @"
            <!DOCTYPE html>
	        <html>
	        <head>
		        <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" />
		        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
		        <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"">
		        <meta name=""format-detection"" content=""telephone=no"" />
		        <title>Viaje por Chiapas</title>
		        <style type=""text/css"">
			        html { background-color:#E1E1E1; margin:0; padding:0; }
			        body, #bodyTable, #bodyCell, #bodyCell{height:100% !important; margin:0; padding:0; width:100% !important;font-family:Helvetica, Arial, ""Lucida Grande"", sans-serif;}
			        table{border-collapse:collapse;}
			        table[id=bodyTable] {width:100%!important;margin:auto;max-width:500px!important;color:#b6b24c;font-weight:normal;}
			        img, a img{border:0; outline:none; text-decoration:none;height:auto; line-height:100%;}
			        a {text-decoration:none !important;border-bottom: 1px solid;}
			        h1, h2, h3, h4, h5, h6{color:#5F5F5F; font-weight:normal; font-family:Helvetica; font-size:20px; line-height:125%; text-align:Left; letter-spacing:normal;margin-top:0;margin-right:0;margin-bottom:10px;margin-left:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;}
			        .ReadMsgBody{width:100%;} .ExternalClass{width:100%;} /* Force Hotmail/Outlook.com to display emails at full width. */
			        .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div{line-height:100%;} /* Force Hotmail/Outlook.com to display line heights normally. */
			        table, td{mso-table-lspace:0pt; mso-table-rspace:0pt;} /* Remove spacing between tables in Outlook 2007 and up. */
			        #outlook a{padding:0;} /* Force Outlook 2007 and up to provide a ""view in browser"" message. */
			        img{-ms-interpolation-mode: bicubic;display:block;outline:none; text-decoration:none;} /* Force IE to smoothly render resized images. */
			        body, table, td, p, a, li, blockquote{-ms-text-size-adjust:100%; -webkit-text-size-adjust:100%; font-weight:normal!important;} /* Prevent Windows- and Webkit-based mobile platforms from changing declared text sizes. */
			        .ExternalClass td[class=""ecxflexibleContainerBox""] h3 {padding-top: 10px !important;} /* Force hotmail to push 2-grid sub headers down */

			        h1{display:block;font-size:26px;font-style:normal;font-weight:normal;line-height:100%;}
			        h2{display:block;font-size:20px;font-style:normal;font-weight:normal;line-height:120%;}
			        h3{display:block;font-size:17px;font-style:normal;font-weight:normal;line-height:110%;}
			        h4{display:block;font-size:18px;font-style:italic;font-weight:normal;line-height:100%;}
			        .flexibleImage{height:auto;}
			        .linkRemoveBorder{border-bottom:0 !important;}
			        table[class=flexibleContainerCellDivider] {padding-bottom:0 !important;padding-top:0 !important;}

			        body, #bodyTable{background-color:#E1E1E1;}
			        #emailHeader{background-color:#b6b24c;}
			        #emailBody{background-color:#FFFFFF;}
			        #emailFooter{background-color:#E1E1E1;}
			        .nestedContainer{background-color:#F8F8F8; border:1px solid #CCCCCC;}
			        .emailButton{background-color:#205478; border-collapse:separate;}
			        .buttonContent{color:#FFFFFF; font-family:Helvetica; font-size:18px; font-weight:bold; line-height:100%; padding:15px; text-align:center;}
			        .buttonContent a{color:#FFFFFF; display:block; text-decoration:none!important; border:0!important;}
			        .emailCalendar{background-color:#FFFFFF; border:1px solid #CCCCCC;}
			        .emailCalendarMonth{background-color:#205478; color:#FFFFFF; font-family:Helvetica, Arial, sans-serif; font-size:16px; font-weight:bold; padding-top:10px; padding-bottom:10px; text-align:center;}
			        .emailCalendarDay{color:#205478; font-family:Helvetica, Arial, sans-serif; font-size:60px; font-weight:bold; line-height:100%; padding-top:20px; padding-bottom:20px; text-align:center;}
			        .imageContentText {margin-top: 10px;line-height:0;}
			        .imageContentText a {line-height:0;}
			        #invisibleIntroduction {display:none !important;} /* Removing the introduction text from the view */
			        span[class=ios-color-hack] a {color:#275100!important;text-decoration:none!important;}
			        span[class=ios-color-hack2] a {color:#205478!important;text-decoration:none!important;}
			        span[class=ios-color-hack3] a {color:#8B8B8B!important;text-decoration:none!important;}
			        .a[href^=""tel""], a[href^=""sms""] {text-decoration:none!important;color:#606060!important;pointer-events:none!important;cursor:default!important;}
			        .mobile_link a[href^=""tel""], .mobile_link a[href^=""sms""] {text-decoration:none!important;color:#606060!important;pointer-events:auto!important;cursor:default!important;}

			        @media only screen and (max-width: 480px){
				        body{width:100% !important; min-width:100% !important;}
				        /*td[class=""textContent""], td[class=""flexibleContainerCell""] { width: 100%; padding-left: 10px !important; padding-right: 10px !important; }*/
				        table[id=""emailHeader""],
				        table[id=""emailBody""],
				        table[id=""emailFooter""],
				        table[class=""flexibleContainer""],
				        td[class=""flexibleContainerCell""] {width:100% !important;}
				        td[class=""flexibleContainerBox""], td[class=""flexibleContainerBox""] table {display: block;width: 100%;text-align: left;}
				        td[class=""imageContent""] img {height:auto !important; width:100% !important; max-width:100% !important; }
				        img[class=""flexibleImage""]{height:auto !important; width:100% !important;max-width:100% !important;}
				        img[class=""flexibleImageSmall""]{height:auto !important; width:auto !important;}
				        table[class=""emailButton""]{width:100% !important;}
				        td[class=""buttonContent""]{padding:0 !important;}
				        td[class=""buttonContent""] a{padding:15px !important;}
			        }
			        @media only screen and (-webkit-device-pixel-ratio:.75){
			        }
			        @media only screen and (-webkit-device-pixel-ratio:1){
			        }
			        @media only screen and (-webkit-device-pixel-ratio:1.5){
			        }
			        @media only screen and (min-device-width : 320px) and (max-device-width:568px) {
			        }
		        </style>
		        <!--[if mso 12]><style type=""text/css"">.flexibleContainer{display:block !important; width:100% !important;}</style><![endif]-->
		        <!--[if mso 14]><style type=""text/css"">.flexibleContainer{display:block !important; width:100% !important;}</style><![endif]-->
	        </head>
	        <body bgcolor=""#E1E1E1"" leftmargin=""0"" marginwidth=""0"" topmargin=""0"" marginheight=""0"" offset=""0"">
		        <center style=""background-color:#E1E1E1;"">
			        <table border=""0"" cellpadding=""0"" cellspacing=""0"" height=""100%"" width=""100%"" id=""bodyTable"" style=""table-layout: fixed;max-width:100% !important;width: 100% !important;min-width: 100% !important;"">
				        <tr>
					        <td align=""center"" valign=""top"" id=""bodyCell"">
						        <table bgcolor=""#FFFFFF""  border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" id=""emailBody"">
							        <tr>
								        <td align=""center"" valign=""top"">
									        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""color:#FFFFFF;"" bgcolor=""#3498db"">
										        <tr>
											        <td align=""center"" valign=""top"">
												        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
													        <tr>
														        <td align=""center"" valign=""top"" width=""500"" class=""flexibleContainerCell"">
															        <table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""100%"">
																        <tr>
																	        <td align=""center"" valign=""top"" class=""textContent"">
																		        <h1 style=""color:#FFFFFF;line-height:100%;font-family:Helvetica,Arial,sans-serif;font-size:35px;font-weight:normal;margin-bottom:5px;text-align:center;"">Viaje por Chiapas</h1>
																		        <h2 style=""text-align:center;font-weight:normal;font-family:Helvetica,Arial,sans-serif;font-size:23px;margin-bottom:10px;color:#205478;line-height:135%;"">Viaje por Chiapas</h2>
																		        <div style=""text-align:center;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#FFFFFF;line-height:135%;"">Contraseña reseteada este es usuario y contraseña</div>
																	        </td>
																        </tr>
															        </table>
														        </td>
													        </tr>
												        </table>
											        </td>
										        </tr>
									        </table>
								        </td>
							        </tr>
							        <tr mc:hideable>
								        <td align=""center"" valign=""top"">
									        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
										        <tr>
											        <td align=""center"" valign=""top"">
												        <table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
													        <tr>
														        <td valign=""top"" width=""500"" class=""flexibleContainerCell"">
															        <table align=""left"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
																        <tr>
																	        <td align=""left"" valign=""top"" class=""flexibleContainerBox"">
																		        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""210"" style=""max-width: 100%;"">
																			        <tr>
																				        <td align=""left"" class=""textContent"">
																					        <h3 style=""color:#5F5F5F;line-height:125%;font-family:Helvetica,Arial,sans-serif;font-size:20px;font-weight:normal;margin-top:0;margin-bottom:3px;text-align:left;"">Usuario:</h3>
																					        <div style=""text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;"">" + usuario + @"</div>
																				        </td>
																			        </tr>
																		        </table>
																	        </td>
																	        <td align=""right"" valign=""middle"" class=""flexibleContainerBox"">
																		        <table class=""flexibleContainerBoxNext"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""210"" style=""max-width: 100%;"">
																			        <tr>
																				        <td align=""left"" class=""textContent"">
																					        <h3 style=""color:#5F5F5F;line-height:125%;font-family:Helvetica,Arial,sans-serif;font-size:20px;font-weight:normal;margin-top:0;margin-bottom:3px;text-align:left;"">Contraseña:</h3>
																					        <div style=""text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;"">" + password + @"</div>
																				        </td>
																			        </tr>
																		        </table>
																	        </td>
																        </tr>
															        </table>
															        <br><br>
														        </td>
													        </tr>
												        </table>
											        </td>
										        </tr>
									        </table>
								        </td>
							        </tr>
							        <tr>
								        <td align=""center"" valign=""top"">
									        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
										        <tr style=""padding-top:0;"">
											        <td align=""center"" valign=""top"">
												        <table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
													        <tr>
														        <td style=""padding-top:0;"" align=""center"" valign=""top"" width=""500"" class=""flexibleContainerCell"">
															        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""50%"" class=""emailButton"" style=""background-color: #b6b24c;"">
																        <tr>
																	        <td align=""center"" valign=""middle"" class=""buttonContent"" style=""padding-top:15px;padding-bottom:15px;padding-right:15px;padding-left:15px;"">
																		        <a style=""color:#FFFFFF;text-decoration:none;font-family:Helvetica,Arial,sans-serif;font-size:20px;line-height:135%;"" href=""" + dominio + login + @""" target=""_blank"">Ingresar</a>
																	        </td>
																        </tr>
															        </table>
														        </td>
													        </tr>
												        </table>
											        </td>
										        </tr>
									        </table>
								        </td>
							        </tr>
						        </table>
						        <table bgcolor=""#E1E1E1"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" id=""emailFooter"">
							        <tr>
								        <td align=""center"" valign=""top"">
									        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
										        <tr>
											        <td align=""center"" valign=""top"">
												        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
													        <tr>
														        <td align=""center"" valign=""top"" width=""500"" class=""flexibleContainerCell"">
															        <table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""100%"">
																        <tr>
																	        <td valign=""top"" bgcolor=""#E1E1E1"">
																		        <div style=""font-family:Helvetica,Arial,sans-serif;font-size:13px;color:#828282;text-align:center;line-height:120%;"">
																			        <div>Copyright &#169; 2016 <a href=""" + dominio + @""" target=""_blank"" style=""text-decoration:none;color:#828282;""><span style=""color:#828282;"">CSL</span></a>. All&nbsp;rights&nbsp;reserved.</div>
																			        <div>Creativa Softline <a href=""" + creativa + @""" target=""""_blank"""" style=""text-decoration:none;color:#828282;""><span style=""color:#828282;"">comunicarse</span></a>.</div>
																		        </div>
																	        </td>
																        </tr>
															        </table>
														        </td>
													        </tr>
												        </table>
											        </td>
										        </tr>
									        </table>
								        </td>
							        </tr>
						        </table>
					        </td>
				        </tr>
			        </table>
		        </center>
	        </body>
        </html>
            ";
            return html;
        }
        public static string GenerarHtmlCorreos()
        {
            string dominio = _dominio;
            string link = "/Admin/Account/";
            string creativa = "creativasoftline.com";
            string html = @"
            <!DOCTYPE html>
	        <html>
	        <head>
		        <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" />
		        <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
		        <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"">
		        <meta name=""format-detection"" content=""telephone=no"" />
		        <title>Viaje por Chiapas</title>
		        <style type=""text/css"">
			        html { background-color:#E1E1E1; margin:0; padding:0; }
			        body, #bodyTable, #bodyCell, #bodyCell{height:100% !important; margin:0; padding:0; width:100% !important;font-family:Helvetica, Arial, ""Lucida Grande"", sans-serif;}
			        table{border-collapse:collapse;}
			        table[id=bodyTable] {width:100%!important;margin:auto;max-width:500px!important;color:#b6b24c;font-weight:normal;}
			        img, a img{border:0; outline:none; text-decoration:none;height:auto; line-height:100%;}
			        a {text-decoration:none !important;border-bottom: 1px solid;}
			        h1, h2, h3, h4, h5, h6{color:#5F5F5F; font-weight:normal; font-family:Helvetica; font-size:20px; line-height:125%; text-align:Left; letter-spacing:normal;margin-top:0;margin-right:0;margin-bottom:10px;margin-left:0;padding-top:0;padding-bottom:0;padding-left:0;padding-right:0;}
			        .ReadMsgBody{width:100%;} .ExternalClass{width:100%;} /* Force Hotmail/Outlook.com to display emails at full width. */
			        .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div{line-height:100%;} /* Force Hotmail/Outlook.com to display line heights normally. */
			        table, td{mso-table-lspace:0pt; mso-table-rspace:0pt;} /* Remove spacing between tables in Outlook 2007 and up. */
			        #outlook a{padding:0;} /* Force Outlook 2007 and up to provide a ""view in browser"" message. */
			        img{-ms-interpolation-mode: bicubic;display:block;outline:none; text-decoration:none;} /* Force IE to smoothly render resized images. */
			        body, table, td, p, a, li, blockquote{-ms-text-size-adjust:100%; -webkit-text-size-adjust:100%; font-weight:normal!important;} /* Prevent Windows- and Webkit-based mobile platforms from changing declared text sizes. */
			        .ExternalClass td[class=""ecxflexibleContainerBox""] h3 {padding-top: 10px !important;} /* Force hotmail to push 2-grid sub headers down */

			        h1{display:block;font-size:26px;font-style:normal;font-weight:normal;line-height:100%;}
			        h2{display:block;font-size:20px;font-style:normal;font-weight:normal;line-height:120%;}
			        h3{display:block;font-size:17px;font-style:normal;font-weight:normal;line-height:110%;}
			        h4{display:block;font-size:18px;font-style:italic;font-weight:normal;line-height:100%;}
			        .flexibleImage{height:auto;}
			        .linkRemoveBorder{border-bottom:0 !important;}
			        table[class=flexibleContainerCellDivider] {padding-bottom:0 !important;padding-top:0 !important;}

			        body, #bodyTable{background-color:#E1E1E1;}
			        #emailHeader{background-color:#b6b24c;}
			        #emailBody{background-color:#FFFFFF;}
			        #emailFooter{background-color:#E1E1E1;}
			        .nestedContainer{background-color:#F8F8F8; border:1px solid #CCCCCC;}
			        .emailButton{background-color:#205478; border-collapse:separate;}
			        .buttonContent{color:#FFFFFF; font-family:Helvetica; font-size:18px; font-weight:bold; line-height:100%; padding:15px; text-align:center;}
			        .buttonContent a{color:#FFFFFF; display:block; text-decoration:none!important; border:0!important;}
			        .emailCalendar{background-color:#FFFFFF; border:1px solid #CCCCCC;}
			        .emailCalendarMonth{background-color:#205478; color:#FFFFFF; font-family:Helvetica, Arial, sans-serif; font-size:16px; font-weight:bold; padding-top:10px; padding-bottom:10px; text-align:center;}
			        .emailCalendarDay{color:#205478; font-family:Helvetica, Arial, sans-serif; font-size:60px; font-weight:bold; line-height:100%; padding-top:20px; padding-bottom:20px; text-align:center;}
			        .imageContentText {margin-top: 10px;line-height:0;}
			        .imageContentText a {line-height:0;}
			        #invisibleIntroduction {display:none !important;} /* Removing the introduction text from the view */
			        span[class=ios-color-hack] a {color:#275100!important;text-decoration:none!important;}
			        span[class=ios-color-hack2] a {color:#205478!important;text-decoration:none!important;}
			        span[class=ios-color-hack3] a {color:#8B8B8B!important;text-decoration:none!important;}
			        .a[href^=""tel""], a[href^=""sms""] {text-decoration:none!important;color:#606060!important;pointer-events:none!important;cursor:default!important;}
			        .mobile_link a[href^=""tel""], .mobile_link a[href^=""sms""] {text-decoration:none!important;color:#606060!important;pointer-events:auto!important;cursor:default!important;}

			        @media only screen and (max-width: 480px){
				        body{width:100% !important; min-width:100% !important;}
				        /*td[class=""textContent""], td[class=""flexibleContainerCell""] { width: 100%; padding-left: 10px !important; padding-right: 10px !important; }*/
				        table[id=""emailHeader""],
				        table[id=""emailBody""],
				        table[id=""emailFooter""],
				        table[class=""flexibleContainer""],
				        td[class=""flexibleContainerCell""] {width:100% !important;}
				        td[class=""flexibleContainerBox""], td[class=""flexibleContainerBox""] table {display: block;width: 100%;text-align: left;}
				        td[class=""imageContent""] img {height:auto !important; width:100% !important; max-width:100% !important; }
				        img[class=""flexibleImage""]{height:auto !important; width:100% !important;max-width:100% !important;}
				        img[class=""flexibleImageSmall""]{height:auto !important; width:auto !important;}
				        table[class=""emailButton""]{width:100% !important;}
				        td[class=""buttonContent""]{padding:0 !important;}
				        td[class=""buttonContent""] a{padding:15px !important;}
			        }
			        @media only screen and (-webkit-device-pixel-ratio:.75){
			        }
			        @media only screen and (-webkit-device-pixel-ratio:1){
			        }
			        @media only screen and (-webkit-device-pixel-ratio:1.5){
			        }
			        @media only screen and (min-device-width : 320px) and (max-device-width:568px) {
			        }
		        </style>
		        <!--[if mso 12]><style type=""text/css"">.flexibleContainer{display:block !important; width:100% !important;}</style><![endif]-->
		        <!--[if mso 14]><style type=""text/css"">.flexibleContainer{display:block !important; width:100% !important;}</style><![endif]-->
	        </head>
	        <body bgcolor=""#E1E1E1"" leftmargin=""0"" marginwidth=""0"" topmargin=""0"" marginheight=""0"" offset=""0"">
		        <center style=""background-color:#E1E1E1;"">
			        <table border=""0"" cellpadding=""0"" cellspacing=""0"" height=""100%"" width=""100%"" id=""bodyTable"" style=""table-layout: fixed;max-width:100% !important;width: 100% !important;min-width: 100% !important;"">
				        <tr>
					        <td align=""center"" valign=""top"" id=""bodyCell"">
						        <table bgcolor=""#FFFFFF""  border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" id=""emailBody"">
							        <tr>
								        <td align=""center"" valign=""top"">
									        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""color:#FFFFFF;"" bgcolor=""#3498db"">
										        <tr>
											        <td align=""center"" valign=""top"">
												        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
													        <tr>
														        <td align=""center"" valign=""top"" width=""500"" class=""flexibleContainerCell"">
															        <table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""100%"">
																        <tr>
																	        <td align=""center"" valign=""top"" class=""textContent"">
																		        <h1 style=""color:#FFFFFF;line-height:100%;font-family:Helvetica,Arial,sans-serif;font-size:35px;font-weight:normal;margin-bottom:5px;text-align:center;"">Viaje por Chiapas</h1>
																		        <h2 style=""text-align:center;font-weight:normal;font-family:Helvetica,Arial,sans-serif;font-size:23px;margin-bottom:10px;color:#205478;line-height:135%;"">Viaje por Chiapas, A.C.</h2>
																		        <div style=""text-align:center;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#FFFFFF;line-height:135%;"">Promooción</div>
																	        </td>
																        </tr>
															        </table>
														        </td>
													        </tr>
												        </table>
											        </td>
										        </tr>
									        </table>
								        </td>
							        </tr>
							        <tr mc:hideable>
								        <td align=""center"" valign=""top"">
									        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
										        <tr>
											        <td align=""center"" valign=""top"">
												        <table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
													        <tr>
														        <td valign=""top"" width=""500"" class=""flexibleContainerCell"">
															        <table align=""left"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
																        <tr>
																	        <td align=""left"" valign=""top"" class=""flexibleContainerBox"">
																		        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""210"" style=""max-width: 100%;"">
																			        <tr>
																				        <td align=""left"" class=""textContent"">
																					        <h3 style=""color:#5F5F5F;line-height:125%;font-family:Helvetica,Arial,sans-serif;font-size:20px;font-weight:normal;margin-top:0;margin-bottom:3px;text-align:left;"">Usuario:</h3>
																					        <div style=""text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;"">" + "" + @"</div>
																				        </td>
																			        </tr>
																		        </table>
																	        </td>
																	        <td align=""right"" valign=""middle"" class=""flexibleContainerBox"">
																		        <table class=""flexibleContainerBoxNext"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""210"" style=""max-width: 100%;"">
																			        <tr>
																				        <td align=""left"" class=""textContent"">
																					        <h3 style=""color:#5F5F5F;line-height:125%;font-family:Helvetica,Arial,sans-serif;font-size:20px;font-weight:normal;margin-top:0;margin-bottom:3px;text-align:left;"">Contraseña:</h3>
																					        <div style=""text-align:left;font-family:Helvetica,Arial,sans-serif;font-size:15px;margin-bottom:0;color:#5F5F5F;line-height:135%;"">" + "" + @"</div>
																				        </td>
																			        </tr>
																		        </table>
																	        </td>
																        </tr>
															        </table>
															        <br><br>
														        </td>
													        </tr>
												        </table>
											        </td>
										        </tr>
									        </table>
								        </td>
							        </tr>
							        <tr>
								        <td align=""center"" valign=""top"">
									        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
										        <tr style=""padding-top:0;"">
											        <td align=""center"" valign=""top"">
												        <table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
													        <tr>
														        <td style=""padding-top:0;"" align=""center"" valign=""top"" width=""500"" class=""flexibleContainerCell"">
															        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""50%"" class=""emailButton"" style=""background-color: #b6b24c;"">
																        <tr>
																	        <td align=""center"" valign=""middle"" class=""buttonContent"" style=""padding-top:15px;padding-bottom:15px;padding-right:15px;padding-left:15px;"">
																		        <a style=""color:#FFFFFF;text-decoration:none;font-family:Helvetica,Arial,sans-serif;font-size:20px;line-height:135%;"" href=""" + dominio + link + @""" target=""_blank"">Ir</a>
																	        </td>
																        </tr>
															        </table>
														        </td>
													        </tr>
												        </table>
											        </td>
										        </tr>
									        </table>
								        </td>
							        </tr>
						        </table>
						        <table bgcolor=""#E1E1E1"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" id=""emailFooter"">
							        <tr>
								        <td align=""center"" valign=""top"">
									        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
										        <tr>
											        <td align=""center"" valign=""top"">
												        <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""500"" class=""flexibleContainer"">
													        <tr>
														        <td align=""center"" valign=""top"" width=""500"" class=""flexibleContainerCell"">
															        <table border=""0"" cellpadding=""30"" cellspacing=""0"" width=""100%"">
																        <tr>
																	        <td valign=""top"" bgcolor=""#E1E1E1"">
																		        <div style=""font-family:Helvetica,Arial,sans-serif;font-size:13px;color:#828282;text-align:center;line-height:120%;"">
																			        <div>Copyright &#169; 2016 <a href=""" + dominio + @""" target=""_blank"" style=""text-decoration:none;color:#828282;""><span style=""color:#828282;"">CSL</span></a>. All&nbsp;rights&nbsp;reserved.</div>
																			        <div>Creativa Softline <a href=""" + creativa + @""" target=""""_blank"""" style=""text-decoration:none;color:#828282;""><span style=""color:#828282;"">comunicarse</span></a>.</div>
																		        </div>
																	        </td>
																        </tr>
															        </table>
														        </td>
													        </tr>
												        </table>
											        </td>
										        </tr>
									        </table>
								        </td>
							        </tr>
						        </table>
					        </td>
				        </tr>
			        </table>
		        </center>
	        </body>
        </html>
            ";
            return html;
        }
        public static string GenerarHtmlContactos(string nombre, string correo, string telefono, string horarioContacto, string asunto, string mensaje, DataTable tablaRedesSociales, DataTable TablaPaquetesPopulares,string nombrePersona)
        {
            string _facebook = tablaRedesSociales.Rows[0]["facebook"].ToString();
            string _twitter = tablaRedesSociales.Rows[0]["twitter"].ToString();
            string _instagram = tablaRedesSociales.Rows[0]["instagram"].ToString();
            string _youtube = tablaRedesSociales.Rows[0]["youtube"].ToString();
            string _googleplus = tablaRedesSociales.Rows[0]["googleplus"].ToString();
            string dominio = _dominio;

            string creativa = "creativasoftline.com";
            string html = @"
            <!DOCTYPE html>
	        <html>
            <head>
            <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" >
            <meta name=""viewport"" content=""width=device-width; initial-scale=1.0; maximum-scale=1.0;"" >
            <meta property=""og:title"" content=""*|MC:SUBJECT|*"" >
            <title></title>
            <style type=""text/css"">
            div, p, a, li, td { -webkit-text-size-adjust:none; }
            .ReadMsgBody
            {width: 100%; background-color: #ffffff;}
            .ExternalClass
            {width: 100%; background-color: #ffffff;}
            body
            {width: 100%; background-color: #ffffff; margin:0; padding:0; -webkit-font-smoothing: antialiased; mso-margin-top-alt:0px; mso-margin-bottom-alt:0px; mso-padding-alt: 0px 0px 0px 0px;}
            html
            {width: 100%; }
            img 
            {border:0px; outline:none; text-decoration:none; display:block; }
            a
            {text-decoration: none; text-transform: capitalize; line-height: 30px; color: #ffffff;}
            a span
            {text-decoration:none; color: #ffffff;}
            h1 
            {font-size: 30px; margin: 20px 0 20px 0; font-family: Helvetica, Arial, sans-serif; font-weight: normal; font-style: normal; color: #151516; text-align: left; line-height:40px;} 
            h2 
            {font-size: 18px; margin: 10px 0 10px 0; color: #000; text-align: left; font-weight: normal; font-family: Helvetica, Arial, sans-serif !important; line-height: 22px; text-decoration:none; text-transform:uppercase;}
            h3 
            {font-size: 12px; margin: 5px 0 5px 0; color: #000; text-align: left; font-weight: normal; font-family: Helvetica, Arial, sans-serif; line-height: 18px;}
            @media only screen and (max-width: 900px) 
            {td[class=headerBG] {width: 100%!important; background-repeat: no-repeat!important; background-size: 900px!important; background-position: center middle!important;}}
            @media only screen and (max-width: 640px)
            { body{ width:auto!important; }
            .BoxWrap { width:440px !important;}
            .RespoHideMedium { display:none !important; } 
            .RespoShowMedium { display:block !important; } 
            .RespoCenterMedium { text-align:center !important; }
            td[class=headerBG] {width: 100%!important;background-repeat: no-repeat!important; background-size: 800px!important; background-position: center!important;}
            img[class=RespoImage_OneTo50W],img[class=RespoImage_OneTo50] { width: 440px!important; height: 212px!important; }
            img[class=RespoImage_OneTo75W],img[class=RespoImage_OneTo75] { width: 440px!important; height: 335px!important; }
            img[class=RespoImage_OneToOneW],img[class=RespoImage_OneToOne] { width: 440px!important; height: 440px!important; }
            img[class=RespoImage_70ToOneW],img[class=RespoImage_70ToOne] { width: 440px!important; height: 628px!important; }
            }
            @media only screen and (max-width: 479px)
            {
            body{width:auto!important;}
            .BoxWrap { width:280px !important;}
            .RespoHideSmall { display:none !important; }
            .RespoCenterSmall { text-align:center !important; }
            img[class=RespoImage_OneTo50W],img[class=RespoImage_OneTo50] { width: 280px!important; height: 135px!important; }
            img[class=RespoImage_OneTo75W],img[class=RespoImage_OneTo75] { width: 280px!important; height: 213px!important; }
            img[class=RespoImage_OneToOneW],img[class=RespoImage_OneToOne] { width: 280px!important; height: 280px!important; }
            img[class=RespoImage_70ToOneW],img[class=RespoImage_70ToOne] { width: 280px!important; height: 400px!important; }
            }
            .Bg_Color
            {
             background-color: #fefefe;
            }
            .BgImageAltColor
            {
            background-color: #2B9EB6;
            }
            .Preheader_Color
            {
            background-color: #2B9EB6;
            }
            .Content_Color
            {
             /*@editable*/ background-color: #ffffff;
            }
            .Color01_B
            {
             /*@editable background-color: #CE0000;*/
            }
            .Color01_D
            {
             /*@editable background-color: #000000;*/
            }
            .Color02_B
            {
             /*@editable*/ background-color: #E7E7EF;
            } 
            </style>
            </head>
            <body style=""width: 100%;background-color: #ffffff;margin: 0;padding: 0;-webkit-font-smoothing: antialiased;mso-margin-top-alt: 0px;mso-margin-bottom-alt: 0px;mso-padding-alt: 0px 0px 0px 0px;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""0"" cellspacing=""0"" align=""center"">
            <tbody>
            <tr>
            <td valign=""top"" class="""" bgcolor=""#f3f3f3"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
                <tbody>
                    <tr>
                        <td style=""-webkit-text-size-adjust: none;"">
                            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
                                <tbody>
                                    <tr>
                                    <td width=""191"" align=""center"" style=""-webkit-text-size-adjust: none;"">
                                    <a href=""#"" style=""border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
                                    <img width=""191"" height=""50"" src=" + dominio + @"Content/Pagina/logo.png" + "" + @"  alt="""" border=""0"" style=""width: 191px;height: 50px;max-width: 191px;max-height: 50px;display: block;border: 0px;outline: none;text-decoration: none;"">
                                </a>
                            </td>
                    </tr>
                </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td class=""BgImageAltColor"" bgcolor=""#2B9EB6"" style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" align=""center"" style=""clear:both;"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td valign=""top"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""100%"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: center;color: #ffffff;font-size: 18px;margin: 10px 0 10px 0;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Operadora Turística - Viaje por Chiapas</h2>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td width=""100%"" height=""1"" class="""" bgcolor=""#2B9EB6"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td width=""100%"" height=""10"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h1 style=""text-transform: uppercase;text-align: center;color: #ffffff;font-size: 30px;margin: 20px 0 20px 0;font-family: Helvetica, Arial, sans-serif;font-weight: normal;font-style: normal;line-height: 40px;""><a href=""#"" style=""color: #ffffff;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;font-style: italic;"">Gracias por contactarnos<br></a></h1>
            <h3 style=""text-align: center;color: #8CBE3F;font-size: 22px;margin: 5px 0 5px 0;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px; font-style:italic;"">La mejor experiencia para su viaje.
            </h3>
            </td>
            </tr>
             <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h1 style=""text-transform: uppercase;text-align: center;color: #ffffff;font-size: 30px;margin: 20px 0 20px 0;font-family: Helvetica, Arial, sans-serif;font-weight: normal;font-style: normal;line-height: 40px;"">" + nombre+@"</h1>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td width=""100%"" height=""1"" class="""" bgcolor=""#2B9EB6"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>

            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style="""">
            <table class=""ecxColor02_B"" bgcolor=""#fefefe"" cellpadding=""5"" cellspacing=""0"" width=""100%"">
            <tbody>
            <tr>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td valign=""top"" height=""40"" style=""-webkit-text-size-adjust: none;""> 
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td valign=""top"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 18px;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">DATOS</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""20"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Nombre:</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + nombre + @"</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Correo:</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: none;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + correo + @"</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Teléfono:</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + telefono + @"</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Horario:</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + horarioContacto + @"</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Asunto:</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: justify;text-transform: none;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + asunto + @"</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>

            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 18px;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Mensaje</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>

            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <p style=""text-align: justify;text-transform: none;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">
            " + mensaje + @"
            </p>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>

            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td valign=""top"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""30"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="" bgcolor=""#fff"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text - align:center; margin: 20px 0 0 0; font - size:14px; color:#000; font-weight:bold; line-height:22px; text-decoration:none; text-transform:none; font-family:Helvetica,Arial,sans-serif"">Aceptamos pagos con tarjeta de crédito vía PayPal, depósito en efectivo o transferencia bancaria. En breve, uno de nuestros asesores se contactará con usted para explicarle a mayor detalle nuestros servicios.</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""40"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td valign=""top"" class="""" bgcolor=""#2B9EB6"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""184"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class="""" bgcolor=""#2B9EB6"" width=""100%"" cellpadding=""14"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #c5c5c5;text-align: left;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Datos de contacto:</h2>
            <h3 style=""color: #ffffff;font-size: 12px;margin: 5px 0 5px 0;text-align: left;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Tel. " + tablaRedesSociales.Rows[0]["telefono"].ToString() + @"<br><a href=""#"" style=""-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">Email. " + tablaRedesSociales.Rows[0]["correo"].ToString() + @"</a></h3>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""RespoHideMedium"" width=""0"" align=""left"" cellpadding=""0"" cellspacing=""0"" style=""font-size: 0;line-height: 0;border-collapse: collapse;"">
            <tbody>
            <tr>
            <td width=""0"" height=""2"" style=""font-size: 0;line-height: 0;border-collapse: collapse;-webkit-text-size-adjust: none;"">
            <p style=""padding-left: 20px;-webkit-text-size-adjust: none;"">&nbsp;</p>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""BoxWrap"" width=""184"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class="""" bgcolor=""#2B9EB6"" width=""100%"" cellpadding=""14"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #c5c5c5;text-align: left;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Paquetes Populares</h2>
            
            <h3 style=""color: #ffffff;font-size: 12px;margin: 5px 0 5px 0;text-align: left;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">
                 ";
            foreach (DataRow PaquetPulares in TablaPaquetesPopulares.Rows)
            {

                string id = PaquetPulares["nombre_pagina"].ToString();
                string nombreLugar = PaquetPulares["nombre"].ToString();
                html = html + @"
                        <a href = """ + dominio + @"Paquetes/DetallePaquete/"+ id+@""" style = ""-webkit-text-size-adjust:none;text-decoration: none;text-transform: capitalize;line-height: 20px; color: #ffffff;"">" + nombreLugar + @"</a>
                            <br>";
               
            } html=html+@"</h3>

                
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""RespoHideMedium"" width=""0"" align=""left"" cellpadding=""0"" cellspacing=""0"" style=""font-size: 0;line-height: 0;border-collapse: collapse;"">
            <tbody>
            <tr>
            <td width=""0"" height=""2"" style=""font-size: 0;line-height: 0;border-collapse: collapse;-webkit-text-size-adjust: none;"">
            <p style=""padding-left: 20px;-webkit-text-size-adjust: none;"">&nbsp;</p>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""BoxWrap"" width=""184"" align=""right"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class="""" bgcolor=""#2B9EB6"" width=""100%"" cellpadding=""14"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #c5c5c5;text-align: left;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Redes Sociales:</h2>
            <a href=""" + _facebook + @""" style="" float: left; border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://icon-icons.com/icons2/642/PNG/512/facebook_icon-icons.com_59205.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _twitter + @""" style="" float: left; border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://icon-icons.com/icons2/838/PNG/512/circle-twitter_icon-icons.com_66835.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _instagram + @""" style="" float: left; border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://images.vexels.com/media/users/3/137380/isolated/preview/1b2ca367caa7eff8b45c09ec09b44c16-instagram-icon-logo-by-vexels.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _youtube + @""" style=""float:left;border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""http://icons.iconarchive.com/icons/igh0zt/ios7-style-metro-ui/256/MetroUI-YouTube-Alt-icon.png"" alt ="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _googleplus + @""" style=""border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://icon-icons.com/icons2/838/PNG/512/circle-google-plus_icon-icons.com_66818.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td style="" width=""100%"" height=""10""></td>
            </tr>
            <tr>
            <td style=""text-align: center;"">
            <h3 style=""text-align:center;color:#fff;font-size:18px;font-weight:normal;font-family:Helvetica, Arial, sans-serif;line-height:18px;"">
            <a href=""" + dominio + @"/TerminosYCondiciones/"""" style=""text-align:center;color:#fff;font-size:18px;font-weight:normal;font-family:Helvetica, Arial, sans-serif;line-height:18px;"">Términos y Condiciones de Servicio</a></h3>
            </td>
            </tr>
            <tr>
            <td style="" width=""100%"" height=""20""></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
           
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </body>            
        </html>
            ";
            return html;
        }
        #endregion
        #region Html Paquetes
        public static string GenerarHtmlPaqueteCotizado(DataTable datosGenerales, DataTable tablaRecamaras, DataTable redesSociales, DataTable tablaItinerario,DataTable TablaPaquetesPopulares,string nombrePersona, string nombrePaquete)
        {
            string _facebook = redesSociales.Rows[0]["facebook"].ToString();
            string _twitter = redesSociales.Rows[0]["twitter"].ToString();
            string _instagram = redesSociales.Rows[0]["instagram"].ToString();
            string _youtube = redesSociales.Rows[0]["youtube"].ToString();
            string _googleplus = redesSociales.Rows[0]["google"].ToString();
            string dominio = _dominio;

            // Remainder of string starting at c.
            
            string s = String.Format("{0:f2}", redesSociales.Rows[0]["porcentajeAnticipo"]);
            int i = s.IndexOf('.');
            string Anticipo = s.Substring(0, i);
            string m = String.Format("{0:f2}", (100.00 - Convert.ToSingle(redesSociales.Rows[0]["porcentajeAnticipo"])));
            int ii = m.IndexOf('.') ;
            string AnticipoResto = m.Substring(0, ii);
            string pass = (datosGenerales.Rows[0]["password"].ToString() != "") ? datosGenerales.Rows[0]["password"].ToString() : "*****";
            string numeroEstrellas = "";
            if (datosGenerales.Rows[0]["numeroEstrellas"].ToString() != null)
            {
                for (int j = 0; j < Convert.ToInt32(datosGenerales.Rows[0]["numeroEstrellas"].ToString()); j++)
                {
                    numeroEstrellas += "*";
                }
            }
            string html = @"<html>
            <head>
            <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" >
            <meta name=""viewport"" content=""width=device-width; initial-scale=1.0; maximum-scale=1.0;"" >
            <meta property=""og:title"" content=""*|MC:SUBJECT|*"" >
            <title></title>
            <style type=""text/css"">
            div, p, a, li, td { -webkit-text-size-adjust:none; }
            .ReadMsgBody
            {width: 100%; background-color: #ffffff;}
            .ExternalClass
            {width: 100%; background-color: #ffffff;}
            body
            {width: 100%; background-color: #ffffff; margin:0; padding:0; -webkit-font-smoothing: antialiased; mso-margin-top-alt:0px; mso-margin-bottom-alt:0px; mso-padding-alt: 0px 0px 0px 0px;}
            html
            {width: 100%; }
            img 
            {border:0px; outline:none; text-decoration:none; display:block; }
            a
            {text-decoration: none; text-transform: capitalize; line-height: 30px; color: #ffffff;}
            a span
            {text-decoration:none; color: #ffffff;}
            h1 
            {font-size: 30px; margin: 20px 0 20px 0; font-family: Helvetica, Arial, sans-serif; font-weight: normal; font-style: normal; color: #151516; text-align: left; line-height:40px;} 
            h2 
            {font-size: 18px; margin: 10px 0 10px 0; color: #000; text-align: left; font-weight: normal; font-family: Helvetica, Arial, sans-serif !important; line-height: 22px; text-decoration:none; text-transform:uppercase;}
            h3 
            {font-size: 12px; margin: 5px 0 5px 0; color: #000; text-align: left; font-weight: normal; font-family: Helvetica, Arial, sans-serif; line-height: 18px;}
            @media only screen and (max-width: 900px) 
            {td[class=headerBG] {width: 100%!important; background-repeat: no-repeat!important; background-size: 900px!important; background-position: center middle!important;}}
            @media only screen and (max-width: 640px)
            { body{ width:auto!important; }
            .BoxWrap { width:440px !important;}
            .RespoHideMedium { display:none !important; } 
            .RespoShowMedium { display:block !important; } 
            .RespoCenterMedium { text-align:center !important; }
            td[class=headerBG] {width: 100%!important;background-repeat: no-repeat!important; background-size: 800px!important; background-position: center!important;}
            img[class=RespoImage_OneTo50W],img[class=RespoImage_OneTo50] { width: 440px!important; height: 212px!important; }
            img[class=RespoImage_OneTo75W],img[class=RespoImage_OneTo75] { width: 440px!important; height: 335px!important; }
            img[class=RespoImage_OneToOneW],img[class=RespoImage_OneToOne] { width: 440px!important; height: 440px!important; }
            img[class=RespoImage_70ToOneW],img[class=RespoImage_70ToOne] { width: 440px!important; height: 628px!important; }
            }
            @media only screen and (max-width: 479px)
            {
            body{width:auto!important;}
            .BoxWrap { width:280px !important;}
            .RespoHideSmall { display:none !important; }
            .RespoCenterSmall { text-align:center !important; }
            img[class=RespoImage_OneTo50W],img[class=RespoImage_OneTo50] { width: 280px!important; height: 135px!important; }
            img[class=RespoImage_OneTo75W],img[class=RespoImage_OneTo75] { width: 280px!important; height: 213px!important; }
            img[class=RespoImage_OneToOneW],img[class=RespoImage_OneToOne] { width: 280px!important; height: 280px!important; }
            img[class=RespoImage_70ToOneW],img[class=RespoImage_70ToOne] { width: 280px!important; height: 400px!important; }
            }
            .Bg_Color
            {
             background-color: #fefefe;
            }
            .BgImageAltColor
            {
            background-color: #000000;
            }
            .Preheader_Color
            {
            background-color: #f3f3f3;
            }
            .Content_Color
            {
             /*@editable*/ background-color: #ffffff;
            }
            .Color01_B
            {
             /*@editable*/ background-color: #CE0000;
            }
            .Color01_D
            {
             /*@editable*/ background-color: #000000;
            }
            .Color02_B
            {
             /*@editable*/ background-color: #fff;
            } 
            </style>
            </head>
            <body style=""width: 100%;background-color: #ffffff;margin: 0;padding: 0;-webkit-font-smoothing: antialiased;mso-margin-top-alt: 0px;mso-margin-bottom-alt: 0px;mso-padding-alt: 0px 0px 0px 0px;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""0"" cellspacing=""0"" align=""center"">
            <tbody>
            <tr>
            <td valign=""top"" class=""Preheader_Color"" bgcolor=""#f3f3f3"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""191"" align=""center"" style=""-webkit-text-size-adjust: none;"">
            <a href=""#"" style=""border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""191"" height=""50"" src=" + dominio + @"Content/Pagina/logo.png" + "" + @"  alt="""" border=""0"" style=""width: 191px;height: 50px;max-width: 191px;max-height: 50px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td class="""" bgcolor=""#f3f3f3"" style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" align=""center"" style=""clear:both;"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td valign=""top"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""100%"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: center;color: #8CBE3F;font-size: 22px;margin: 5px 0 5px 0;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px; font-style:italic;"">¡Gracias por contartarse!</h3>
            </td>
            </tr>
             <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: center;color: #8CBE3F;font-size: 22px;margin: 5px 0 5px 0;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px; font-style:italic;"">" + nombrePersona + @"</h3>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td width=""100%"" height=""1"" class="""" bgcolor=""#2B9EB6"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td width=""100%"" height=""10"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td bgcolor=""#f3f3f3"" style=""-webkit-text-size-adjust: none;"">
           
            

<tr>
            <td valign=""top"" height=""40"" style=""-webkit-text-size-adjust: none;"">
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td valign=""top"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 18px;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Presentamos Cotización Solicitada</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""20"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Nombre del Paquete</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + datosGenerales.Rows[0]["nombrePaquete"].ToString() + @"</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Tiempo de Recorrido</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + datosGenerales.Rows[0]["numdias"].ToString() + @" Días y " + datosGenerales.Rows[0]["numnoches"].ToString() + @" Noches</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Más información</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;""><a style=""color:red;font-weight:bold;text-transform:uppercase;"" href="+dominio+ "paquetes/detallepaquete/" + nombrePaquete+ @">CLICK AQUÍ</a></h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""0"" cellspacing=""0"">
            <tbody>



            

            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 18px;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">DATOS</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""20"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Fecha y hora de llegada:</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + Convert.ToDateTime(datosGenerales.Rows[0]["fechaLlegada"].ToString()).ToShortDateString() + @"  " + datosGenerales.Rows[0]["horaLlegada"].ToString() + @"</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Fecha y hora de Salida:</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + Convert.ToDateTime(datosGenerales.Rows[0]["fechaSalida"].ToString()).ToShortDateString() + @"  " + datosGenerales.Rows[0]["horaSalida"].ToString() + @"</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Categoria de Hotel:</h3>
            </td> 
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 39px;margin: 10px 0px 0px 0px;color: #F7E82F;font-weight: 800;line-height: 0px;text-decoration: none;font-family: Helvetica, Arial, sans-serif; margin-top: 15px;"">" + numeroEstrellas + @"</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Numero de personas:</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + datosGenerales.Rows[0]["numPersonas"].ToString() + @"</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 18px;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">NÚMERO DE PERSONAS</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>          
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Adultos</h2>
            </td>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Niños 3-10</h2>
            </td>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Niños 0-2</h2>
            </td>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Camas</h2>
            </td>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Tipo de Habitación</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>";
            foreach (DataRow recamara in tablaRecamaras.Rows)
            {
                html = html + @"<tr>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
                <tbody>
                <tr>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + recamara["numAdultos"].ToString() + @"</h2>
                </td>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + recamara["NumNinioMenor11"].ToString() + @"</h2>
                </td>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + recamara["NumNiniosMenor4"].ToString() + @"</h2>
                </td>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + recamara["NumCamas"].ToString() + @"</h2>
                </td>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + recamara["tipoHabitacion"].ToString() + @"</h2>
                </td>
                </tr>
                </tbody>
                </table>
                </td>
                </tr>
                <tr>
                <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
                </tr>";
            }

            html = html + @"<tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 18px;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">DESGLOSE DE LA COTIZACIÓN</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>          
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Tipo de Habitación</h2>
            </td>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Costo por Adulto</h2>
            </td>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Costo por Niños 3-10</h2>
            </td>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Costo por Niños 0-2</h2>
            </td>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Costo subtotal</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>";
            foreach (DataRow recamara in tablaRecamaras.Rows)
            {
                string costoporadulto = "(No Aplica)";
                string costoporniño511 = "(No Aplica)";
                string costoporniño04 = "(No Aplica)";
                string costoporhabitacion = "(No Aplica)";

                if (Convert.ToSingle(recamara["CostoAdulto"]) > 0.0)
                    costoporadulto = String.Format("{0:C}", Convert.ToSingle(recamara["CostoAdulto"]));

                if (Convert.ToSingle(recamara["ConstoNinioMeno11"]) > 0.0)
                    costoporniño511 = String.Format("{0:C}", Convert.ToSingle(recamara["ConstoNinioMeno11"]));

                if (Convert.ToSingle(recamara["CostoNinioMenor4"]) > 0.0)
                    costoporniño04 = String.Format("{0:C}", Convert.ToSingle(recamara["CostoNinioMenor4"]));

                if (Convert.ToSingle(recamara["CostosTotalHabitacion"]) > 0.0)
                    costoporhabitacion = String.Format("{0:C}", Convert.ToSingle(recamara["CostosTotalHabitacion"]));

                html = html + @"<tr>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
                <tbody>
                <tr>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + recamara["tipoHabitacion"].ToString() + @"</h2>
                </td>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + costoporadulto + @"</h2>
                </td>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + costoporniño511 + @"</h2>
                </td>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + costoporniño04 + @"</h2>
                </td>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + costoporhabitacion + @"</h2>
                </td>
                </tr>
                </tbody>
                </table>
                </td>
                </tr>
                <tr>
                <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
                </tr>";
            }

            html = html + @"<tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 18px;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Itinerario</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>      
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Orden</h2>
            </td>
            <td style=""-webkit-text-size-adjust: none; width:80%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Lugar</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>";
            foreach (DataRow itinerario in tablaItinerario.Rows)
            {
                html = html + @"<tr>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
                <tbody>
                <tr>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + itinerario["orden"].ToString() + @"</h2>
                </td>
                <td style=""-webkit-text-size-adjust: none; width:78%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + itinerario["nombre"].ToString() + @"</h2>
                </td>
                </tr>
                </tbody>
                </table>
                </td>
                </tr>
                <tr>
                <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
                </tr>";
            }
           
            if (Convert.ToSingle(datosGenerales.Rows[0]["precio"]) > 0.0)
            {
                html = html + @"<tr>
                <td style=""-webkit-text-size-adjust: none;"">
                <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #000;text-align: right;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Precio total normal</h2>
                <h1 style=""font-size: 30px;margin: 20px 0 20px 0;font-family: Helvetica, Arial, sans-serif;font-weight: normal;font-style: normal;color: #151516;text-align: right;line-height: 40px;"">" + String.Format("{0:C}", Convert.ToSingle(datosGenerales.Rows[0]["precio"])) + @"</h1>
                 <h1 style=""font-size: 20px;margin: 20px 0 20px 0;font-family: Helvetica, Arial, sans-serif;font-weight: normal;font-style: normal;color: #151516;text-align: right;line-height: 40px;"">Descuento en pago de contado: " + String.Format("{0:C}", (Convert.ToSingle(datosGenerales.Rows[0]["precio"])) - (Convert.ToSingle(datosGenerales.Rows[0]["precio"]) * (0.10))) + @"</h1>
                 <h1 style=""font-size: 20px;margin: 20px 0 20px 0;font-family: Helvetica, Arial, sans-serif;font-weight: normal;font-style: normal;color: #151516;text-align: right;line-height: 40px;"">Pagos diferidos a 6 mensualidades de: " + String.Format("{0:C}", (Convert.ToSingle(datosGenerales.Rows[0]["precio"])) / 6) + @"</h1>
                </td>
                </tr>";
            }
            else
            {
                html = html + @"<tr>
                  <td style=""-webkit-text-size-adjust: none;"">
                      <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #000;text-align: right;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;""></h2>
                      <h1 style=""font-size: 22px;margin: 20px 0 20px 0;font-family: Helvetica, Arial, sans-serif;font-weight: normal;font-style: normal;color: #151516;text-align: center;line-height: 40px;"">Su cotización no pudo ser generada automáticamente. Uno de nuestros ejecutivos lo contactará para proporcionarle la información solicitada.</h1>   
                  </td>
                </tr>";
            }

            html = html + @"            
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            ";
            if (!string.IsNullOrEmpty(datosGenerales.Rows[0]["Comentarios"].ToString()))
            {
                html = html + @"<tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 18px;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">OBSERVACIONES</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
                <td style=""-webkit-text-size-adjust: none;"">
                    <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""20"" cellspacing=""0"">
                        <tbody>
                            <tr>
                                <td style=""-webkit-text-size-adjust: none;"">
                                    <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
                                        <tbody>
                                            <tr>
                                               <td style=""-webkit-text-size-adjust: none;"">
                                                <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
                                                    <tbody>
                                                        <tr>
                                                            <td style=""-webkit-text-size-adjust: none;"">
                                                            <h2 style=""text-align: right;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + datosGenerales.Rows[0]["Comentarios"].ToString() + @"</h2>
                                                            </td>
                                                        <tr>
                                                     </tbody>
                                                </table>
                                              </td>
                                           <tr>
                                       </tbody>
                                        <tr>
                                            <td style=""-webkit-text-size-adjust: none;"">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>";
            }

            html = html + @"
	        <tr>
            <td valign=""top"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="" bgcolor=""#fff"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 14px;color: #000;font-weight: bold;line-height: 18px;text-decoration: none;text-transform: none;font-family: Helvetica, Arial, sans-serif;"">Aceptamos pagos con tarjeta de crédito vía PayPal, depósito en efectivo o transferencia bancaria. En breve, uno de nuestros asesores se contactará con usted para explicarle a mayor detalle nuestros servicios.</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""40"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td valign=""top"" class="""" bgcolor=""#2B9EB6"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""184"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class="""" bgcolor=""#2B9EB6"" width=""100%"" cellpadding=""14"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #c5c5c5;text-align: left;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Datos de contacto:</h2>
            <h3 style=""color: #ffffff;font-size: 12px;margin: 5px 0 5px 0;text-align: left;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Tel. " + redesSociales.Rows[0]["telefono"].ToString() + @"<br><a href=""#"" style=""-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">Email. " + redesSociales.Rows[0]["correo"].ToString() + @"</a></h3>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""RespoHideMedium"" width=""0"" align=""left"" cellpadding=""0"" cellspacing=""0"" style=""font-size: 0;line-height: 0;border-collapse: collapse;"">
            <tbody>
            <tr>
            <td width=""0"" height=""2"" style=""font-size: 0;line-height: 0;border-collapse: collapse;-webkit-text-size-adjust: none;"">
            <p style=""padding-left: 20px;-webkit-text-size-adjust: none;"">&nbsp;</p>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""BoxWrap"" width=""184"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class="""" bgcolor=""#2B9EB6"" width=""100%"" cellpadding=""14"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
                    
                <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #c5c5c5;text-align: left;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Paquetes Populares</h2>
            
            <h3 style=""color: #ffffff;font-size: 12px;margin: 5px 0 5px 0;text-align: left;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">
                 ";
            foreach (DataRow PaquetPulares in TablaPaquetesPopulares.Rows)
            {

                string id = PaquetPulares["nombre_pagina"].ToString();
                string nombreLugar = PaquetPulares["nombre"].ToString();
                html = html + @"
                        <a href = """ + dominio + @"Paquetes/DetallePaquete/" + id + @""" style = ""-webkit-text-size-adjust:none;text-decoration: none;text-transform: capitalize;line-height: 20px; color: #ffffff;"">" + nombreLugar + @"</a>
                            <br>";

            }
            html = html + @"</h3>
                
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""RespoHideMedium"" width=""0"" align=""left"" cellpadding=""0"" cellspacing=""0"" style=""font-size: 0;line-height: 0;border-collapse: collapse;"">
            <tbody>
            <tr>
            <td width=""0"" height=""2"" style=""font-size: 0;line-height: 0;border-collapse: collapse;-webkit-text-size-adjust: none;"">
            <p style=""padding-left: 20px;-webkit-text-size-adjust: none;"">&nbsp;</p>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""BoxWrap"" width=""184"" align=""right"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class="""" bgcolor=""#2B9EB6"" width=""100%"" cellpadding=""14"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #c5c5c5;text-align: left;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Redes Sociales</h2>
                
            <a href=""" + _facebook + @""" style="" float: left; border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://icon-icons.com/icons2/642/PNG/512/facebook_icon-icons.com_59205.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _twitter + @""" style="" float: left; border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://icon-icons.com/icons2/838/PNG/512/circle-twitter_icon-icons.com_66835.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _instagram + @""" style="" float: left; border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://images.vexels.com/media/users/3/137380/isolated/preview/1b2ca367caa7eff8b45c09ec09b44c16-instagram-icon-logo-by-vexels.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _youtube + @""" style=""float:left;border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""http://icons.iconarchive.com/icons/igh0zt/ios7-style-metro-ui/256/MetroUI-YouTube-Alt-icon.png"" alt ="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _googleplus + @""" style=""border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://icon-icons.com/icons2/838/PNG/512/circle-google-plus_icon-icons.com_66818.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>   
        
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>            
            <tr>
            <td style="" width=""100%"" height=""10""></td>
            </tr>
            <tr>
            <td>
            <h3 style=""text-align:center;color:#fff;font-size:18px;font-weight:normal;font-family:Helvetica, Arial, sans-serif;line-height:18px;"">
            <a style=""text-align:center;color:#fff;font-size:18px;font-weight:normal;font-family:Helvetica, Arial, sans-serif;line-height:18px;"" href=""" + dominio + @"/TerminosYCondiciones/"""">Términos y Condiciones de Servicio</a></h3>
            </td>
            </tr>
            <tr>
            <td style="" width=""100%"" height=""20"">
            <h3 style=""text-align: center;color: #8CBE3F;font-size: 22px;margin: 5px 0 5px 0;font-weight: normal;line-height: 18px; font-style:italic;"">Registro Nacional de Turismo No. " + codigo + @"</h3>
            </td>
              </tr>
            </tbody>
            </table>
            </td>
            </tr>
            
            <tr>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </body>
            </html>
            ";
            return html;
        }
        #endregion
        #region Html Paquetes Vip
        public static string GenerarHtmlPaqueteVipCotizado(DataTable datosGenerales, DataTable tablaRecamaras, DataTable redesSociales, DataTable tablaItinerario, DataTable TablaPaquetesPopulares, string nombrePersona)
        {
            string _facebook = redesSociales.Rows[0]["facebook"].ToString();
            string _twitter = redesSociales.Rows[0]["twitter"].ToString();
            string _instagram = redesSociales.Rows[0]["instagram"].ToString();
            string _youtube = redesSociales.Rows[0]["youtube"].ToString();
            string _googleplus = redesSociales.Rows[0]["google"].ToString();
            string dominio = _dominio;
            string s = String.Format("{0:f2}", redesSociales.Rows[0]["porcentajeAnticipo"]);
            int i = s.IndexOf('.');
            string Anticipo = s.Substring(0, i);
            string m = String.Format("{0:f2}", (100.00 - Convert.ToSingle(redesSociales.Rows[0]["porcentajeAnticipo"])));
            int ii = m.IndexOf('.');
            string AnticipoResto = m.Substring(0, ii);

            string pass = (datosGenerales.Rows[0]["password"].ToString() != "") ? datosGenerales.Rows[0]["password"].ToString() : "*****";
            string numeroEstrellas = "";
            if (datosGenerales.Rows[0]["numeroEstrellas"].ToString() != null)
            {
                for (int j = 0; j < Convert.ToInt32(datosGenerales.Rows[0]["numeroEstrellas"].ToString()); j++)
                {
                    numeroEstrellas += "*";
                }
            }
            string html = @"<html>
            <head>
            <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" >
            <meta name=""viewport"" content=""width=device-width; initial-scale=1.0; maximum-scale=1.0;"" >
            <meta property=""og:title"" content=""*|MC:SUBJECT|*"" >
            <title></title>
            <style type=""text/css"">
            div, p, a, li, td { -webkit-text-size-adjust:none; }
            .ReadMsgBody
            {width: 100%; background-color: #ffffff;}
            .ExternalClass
            {width: 100%; background-color: #ffffff;}
            body
            {width: 100%; background-color: #ffffff; margin:0; padding:0; -webkit-font-smoothing: antialiased; mso-margin-top-alt:0px; mso-margin-bottom-alt:0px; mso-padding-alt: 0px 0px 0px 0px;}
            html
            {width: 100%; }
            img 
            {border:0px; outline:none; text-decoration:none; display:block; }
            a
            {text-decoration: none; text-transform: capitalize; line-height: 30px; color: #ffffff;}
            a span
            {text-decoration:none; color: #ffffff;}
            h1 
            {font-size: 30px; margin: 20px 0 20px 0; font-family: Helvetica, Arial, sans-serif; font-weight: normal; font-style: normal; color: #151516; text-align: left; line-height:40px;} 
            h2 
            {font-size: 18px; margin: 10px 0 10px 0; color: #000; text-align: left; font-weight: normal; font-family: Helvetica, Arial, sans-serif !important; line-height: 22px; text-decoration:none; text-transform:uppercase;}
            h3 
            {font-size: 12px; margin: 5px 0 5px 0; color: #000; text-align: left; font-weight: normal; font-family: Helvetica, Arial, sans-serif; line-height: 18px;}
            @media only screen and (max-width: 900px) 
            {td[class=headerBG] {width: 100%!important; background-repeat: no-repeat!important; background-size: 900px!important; background-position: center middle!important;}}
            @media only screen and (max-width: 640px)
            { body{ width:auto!important; }
            .BoxWrap { width:440px !important;}
            .RespoHideMedium { display:none !important; } 
            .RespoShowMedium { display:block !important; } 
            .RespoCenterMedium { text-align:center !important; }
            td[class=headerBG] {width: 100%!important;background-repeat: no-repeat!important; background-size: 800px!important; background-position: center!important;}
            img[class=RespoImage_OneTo50W],img[class=RespoImage_OneTo50] { width: 440px!important; height: 212px!important; }
            img[class=RespoImage_OneTo75W],img[class=RespoImage_OneTo75] { width: 440px!important; height: 335px!important; }
            img[class=RespoImage_OneToOneW],img[class=RespoImage_OneToOne] { width: 440px!important; height: 440px!important; }
            img[class=RespoImage_70ToOneW],img[class=RespoImage_70ToOne] { width: 440px!important; height: 628px!important; }
            }
            @media only screen and (max-width: 479px)
            {
            body{width:auto!important;}
            .BoxWrap { width:280px !important;}
            .RespoHideSmall { display:none !important; }
            .RespoCenterSmall { text-align:center !important; }
            img[class=RespoImage_OneTo50W],img[class=RespoImage_OneTo50] { width: 280px!important; height: 135px!important; }
            img[class=RespoImage_OneTo75W],img[class=RespoImage_OneTo75] { width: 280px!important; height: 213px!important; }
            img[class=RespoImage_OneToOneW],img[class=RespoImage_OneToOne] { width: 280px!important; height: 280px!important; }
            img[class=RespoImage_70ToOneW],img[class=RespoImage_70ToOne] { width: 280px!important; height: 400px!important; }
            }
            .Bg_Color
            {
             background-color: #fefefe;
            }
            .BgImageAltColor
            {
            background-color: #000000;
            }
            .Preheader_Color
            {
            background-color: #f3f3f3;
            }
            .Content_Color
            {
             /*@editable*/ background-color: #ffffff;
            }
            .Color01_B
            {
             /*@editable*/ background-color: #CE0000;
            }
            .Color01_D
            {
             /*@editable*/ background-color: #000000;
            }
            .Color02_B
            {
             /*@editable*/ background-color: #fff;
            } 
            </style>
            </head>
            <body style=""width: 100%;background-color: #ffffff;margin: 0;padding: 0;-webkit-font-smoothing: antialiased;mso-margin-top-alt: 0px;mso-margin-bottom-alt: 0px;mso-padding-alt: 0px 0px 0px 0px;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""0"" cellspacing=""0"" align=""center"">
            <tbody>
            <tr>
            <td valign=""top"" class=""Preheader_Color"" bgcolor=""#f3f3f3"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""191"" align=""center"" style=""-webkit-text-size-adjust: none;"">
            <a href=""#"" style=""border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""191"" height=""50"" src=" + dominio + @"Content/Pagina/logo.png" + "" + @"  alt="""" border=""0"" style=""width: 191px;height: 50px;max-width: 191px;max-height: 50px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td class="""" bgcolor=""#f3f3f3"" style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" align=""center"" style=""clear:both;"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td valign=""top"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""100%"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: center;color: #8CBE3F;font-size: 22px;margin: 5px 0 5px 0;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px; font-style:italic;"">¡Gracias por contactarnos!</h3>
            </td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: center;color: #8CBE3F;font-size: 22px;margin: 5px 0 5px 0;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px; font-style:italic;"">" + nombrePersona + @"</h3>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td width=""100%"" height=""1"" class="""" bgcolor=""#2B9EB6"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td width=""100%"" height=""10"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td bgcolor=""#f3f3f3"" style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Color02_B"" bgcolor=""#f3f3f3"" cellpadding=""5"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td valign=""top"" height=""40"" style=""-webkit-text-size-adjust: none;"">
            &nbsp; 
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td valign=""top"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 18px;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">PRESENTAMOS COTIZACIÓN SOLICITADA</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""20"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Fecha y hora de llegada:</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + Convert.ToDateTime(datosGenerales.Rows[0]["fechaLlegada"].ToString()).ToShortDateString() + @"  " + datosGenerales.Rows[0]["horaLlegada"].ToString() + @"</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Fecha y hora de Salida:</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + Convert.ToDateTime(datosGenerales.Rows[0]["fechaSalida"].ToString()).ToShortDateString() + @"  " + datosGenerales.Rows[0]["horaSalida"].ToString() + @"</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Categoria de Hotel:</h3>
            </td> 
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 39px;margin: 10px 0px 0px 0px;color: #F7E82F;font-weight: 800;line-height: 0px;text-decoration: none;font-family: Helvetica, Arial, sans-serif; margin-top: 15px;"">" + numeroEstrellas + @"</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Numero de personas:</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + datosGenerales.Rows[0]["numPersonas"].ToString() + @"</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>

            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 18px;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">NÚMERO DE PERSONAS</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Adultos</h2>
            </td>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Niños 3-10</h2>
            </td>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Niños 0-2</h2>
            </td>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Camas</h2>
            </td>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Tipo de Habitación</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>";

            foreach (DataRow recamara in tablaRecamaras.Rows)
            {
                html = html + @"<tr>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
                <tbody>
                <tr>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + recamara["numAdultos"].ToString() + @"</h2>
                </td>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + recamara["NumNinioMenor11"].ToString() + @"</h2>
                </td>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + recamara["NumNiniosMenor4"].ToString() + @"</h2>
                </td>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + recamara["NumCamas"].ToString() + @"</h2>
                </td>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + recamara["tipoHabitacion"].ToString() + @"</h2>
                </td>
                </tr>
                </tbody>
                </table>
                </td>
                </tr>
                <tr>
                <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
                </tr>";
            }

            html = html + @"<tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 18px;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">DESGLOSE DE LA COTIZACIÓN</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>          
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Tipo de Habitación</h2>
            </td>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Costo por Adultos</h2>
            </td>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Costo por Niños 3-10</h2>
            </td>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Costo por Niños 0-2</h2>
            </td>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Costo subtotal</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>";
            foreach (DataRow recamara in tablaRecamaras.Rows)
            {
                string costoporadulto = "(No Aplica)";
                string costoporniño511 = "(No Aplica)";
                string costoporniño04 = "(No Aplica)";
                string costoporhabitacion = "(No Aplica)";

                if (Convert.ToSingle(recamara["CostoAdulto"]) > 0.0)
                    costoporadulto = String.Format("{0:C}", Convert.ToSingle(recamara["CostoAdulto"]));

                if (Convert.ToSingle(recamara["ConstoNinioMeno11"]) > 0.0)
                    costoporniño511 = String.Format("{0:C}", Convert.ToSingle(recamara["ConstoNinioMeno11"]));

                if (Convert.ToSingle(recamara["CostoNinioMenor4"]) > 0.0)
                    costoporniño04 = String.Format("{0:C}", Convert.ToSingle(recamara["CostoNinioMenor4"]));

                if (Convert.ToSingle(recamara["CostosTotalHabitacion"]) > 0.0)
                    costoporhabitacion = String.Format("{0:C}", Convert.ToSingle(recamara["CostosTotalHabitacion"]));

                html = html + @"<tr>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
                <tbody>
                <tr>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + recamara["tipoHabitacion"].ToString() + @"</h2>
                </td>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + costoporadulto + @"</h2>
                </td>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + costoporniño511 + @"</h2>
                </td>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + costoporniño04 + @"</h2>
                </td>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + costoporhabitacion + @"</h2>
                </td>
                </tr>
                </tbody>
                </table>
                </td>
                </tr>
                <tr>
                <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
                </tr>";
            }

            html = html + @"<tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 18px;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Itinerario</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>      
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Orden</h2>
            </td>
            <td style=""-webkit-text-size-adjust: none; width:80%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Lugar</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>";
            foreach (DataRow itinerario in tablaItinerario.Rows)
            {
                html = html + @"<tr>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
                <tbody>
                <tr>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + itinerario["orden"].ToString() + @"</h2>
                </td>
                <td style=""-webkit-text-size-adjust: none; width:78%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + itinerario["nombre"].ToString() + @"</h2>
                </td>
                </tr>
                </tbody>
                </table>
                </td>
                </tr>
                <tr>
                <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
                </tr>";
            }            
            if (Convert.ToSingle(datosGenerales.Rows[0]["precio"]) > 0.0)
            {
                html = html + @"<tr>
                <td style=""-webkit-text-size-adjust: none;"">
                <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #000;text-align: right;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Precio total normal</h2>
                <h1 style=""font-size: 30px;margin: 20px 0 20px 0;font-family: Helvetica, Arial, sans-serif;font-weight: normal;font-style: normal;color: #151516;text-align: right;line-height: 40px;"">" + String.Format("{0:C}", Convert.ToSingle(datosGenerales.Rows[0]["precio"])) + @"</h1>
                 <h1 style=""font-size: 20px;margin: 20px 0 20px 0;font-family: Helvetica, Arial, sans-serif;font-weight: normal;font-style: normal;color: #151516;text-align: right;line-height: 40px;"">Descuento en pago de contado: " + String.Format("{0:C}", (Convert.ToSingle(datosGenerales.Rows[0]["precio"])) - (Convert.ToSingle(datosGenerales.Rows[0]["precio"]) * (0.10))) + @"</h1>
                 <h1 style=""font-size: 20px;margin: 20px 0 20px 0;font-family: Helvetica, Arial, sans-serif;font-weight: normal;font-style: normal;color: #151516;text-align: right;line-height: 40px;"">Pagos diferidos a 6 mensualidades de: " + String.Format("{0:C}", (Convert.ToSingle(datosGenerales.Rows[0]["precio"])) / 6) + @"</h1>
                </td>
                </tr>
                ";
            }
            else
            {
                html = html + @"<tr>
                  <td style=""-webkit-text-size-adjust: none;"">
                     
                      <h1 style=""font-size: 22px;margin: 20px 0 20px 0;font-family: Helvetica, Arial, sans-serif;font-weight: normal;font-style: normal;color: #151516;text-align: right;line-height: 40px;"">Su cotización no pudo ser generada automáticamente. Uno de nuestros ejecutivos lo contactará para proporcionarle la información solicitada.</h1>   
                  </td>
                </tr>";
            }

            html = html + @"            
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            ";
            if (!string.IsNullOrEmpty(datosGenerales.Rows[0]["Comentarios"].ToString()))
            {
                html = html + @"<tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 18px;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">OBSERVACIONES</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
                <td style=""-webkit-text-size-adjust: none;"">
                    <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""20"" cellspacing=""0"">
                        <tbody>
                            <tr>
                                <td style=""-webkit-text-size-adjust: none;"">
                                    <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
                                        <tbody>
                                            <tr>
                                               <td style=""-webkit-text-size-adjust: none;"">
                                                <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
                                                    <tbody>
                                                        <tr>
                                                            <td style=""-webkit-text-size-adjust: none;"">
                                                            <h2 style=""text-align: right;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + datosGenerales.Rows[0]["Comentarios"].ToString() + @"</h2>
                                                            </td>
                                                        <tr>
                                                     </tbody>
                                                </table>
                                              </td>
                                           <tr>
                                       </tbody>
                                        <tr>
                                            <td style=""-webkit-text-size-adjust: none;"">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>";
            }

            html = html + @"
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
	        <tr>
            <td valign=""top"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="" bgcolor=""#fff"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
             <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 14px;color: #000;font-weight: bold;line-height: 18px;text-decoration: none;text-transform: none;font-family: Helvetica, Arial, sans-serif;"">Aceptamos pagos con tarjeta de crédito vía PayPal, depósito en efectivo o transferencia bancaria. En breve, uno de nuestros asesores se contactará con usted para explicarle a mayor detalle nuestros servicios.</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""40"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td valign=""top"" class="""" bgcolor=""#2B9EB6"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""184"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class="""" bgcolor=""#2B9EB6"" width=""100%"" cellpadding=""14"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #c5c5c5;text-align: left;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Datos de contacto:</h2>
            <h3 style=""color: #ffffff;font-size: 12px;margin: 5px 0 5px 0;text-align: left;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Tel. " + redesSociales.Rows[0]["telefono"].ToString() + @"<br><a href=""#"" style=""-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">Email. " + redesSociales.Rows[0]["correo"].ToString() + @"</a></h3>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""RespoHideMedium"" width=""0"" align=""left"" cellpadding=""0"" cellspacing=""0"" style=""font-size: 0;line-height: 0;border-collapse: collapse;"">
            <tbody>
            <tr>
            <td width=""0"" height=""2"" style=""font-size: 0;line-height: 0;border-collapse: collapse;-webkit-text-size-adjust: none;"">
            <p style=""padding-left: 20px;-webkit-text-size-adjust: none;"">&nbsp;</p>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""BoxWrap"" width=""184"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class="""" bgcolor=""#2B9EB6"" width=""100%"" cellpadding=""14"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
                    
                <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #c5c5c5;text-align: left;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Paquetes Populares</h2>
            
            <h3 style=""color: #ffffff;font-size: 12px;margin: 5px 0 5px 0;text-align: left;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">
                 ";
            foreach (DataRow PaquetPulares in TablaPaquetesPopulares.Rows)
            {

                string id = PaquetPulares["nombre_pagina"].ToString();
                string nombreLugar = PaquetPulares["nombre"].ToString();
                html = html + @"
                        <a href = """ + dominio + @"Paquetes/DetallePaquete/" + id + @""" style = ""-webkit-text-size-adjust:none;text-decoration: none;text-transform: capitalize;line-height: 20px; color: #ffffff;"">" + nombreLugar + @"</a>
                            <br>";

            }
            html = html + @"</h3>
                
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""RespoHideMedium"" width=""0"" align=""left"" cellpadding=""0"" cellspacing=""0"" style=""font-size: 0;line-height: 0;border-collapse: collapse;"">
            <tbody>
            <tr>
            <td width=""0"" height=""2"" style=""font-size: 0;line-height: 0;border-collapse: collapse;-webkit-text-size-adjust: none;"">
            <p style=""padding-left: 20px;-webkit-text-size-adjust: none;"">&nbsp;</p>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""BoxWrap"" width=""184"" align=""right"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class="""" bgcolor=""#2B9EB6"" width=""100%"" cellpadding=""14"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #c5c5c5;text-align: left;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Redes Sociales</h2>
                
            <a href=""" + _facebook + @""" style="" float: left; border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://icon-icons.com/icons2/642/PNG/512/facebook_icon-icons.com_59205.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _twitter + @""" style="" float: left; border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://icon-icons.com/icons2/838/PNG/512/circle-twitter_icon-icons.com_66835.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _instagram + @""" style="" float: left; border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://images.vexels.com/media/users/3/137380/isolated/preview/1b2ca367caa7eff8b45c09ec09b44c16-instagram-icon-logo-by-vexels.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _youtube + @""" style=""float:left;border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""http://icons.iconarchive.com/icons/igh0zt/ios7-style-metro-ui/256/MetroUI-YouTube-Alt-icon.png"" alt ="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _googleplus + @""" style=""border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://icon-icons.com/icons2/838/PNG/512/circle-google-plus_icon-icons.com_66818.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>   
        
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>            
            <tr>
            <td style="" width=""100%"" height=""10""></td>
            </tr>
            <tr>
            <td>
            <h3 style=""text-align:center;color:#fff;font-size:18px;font-weight:normal;font-family:Helvetica, Arial, sans-serif;line-height:18px;"">
            <a style=""text-align:center;color:#fff;font-size:18px;font-weight:normal;font-family:Helvetica, Arial, sans-serif;line-height:18px;"" href=""" + dominio + @"/TerminosYCondiciones/"""">Términos y Condiciones de Servicio</a></h3>
            </td>
            </tr>
            <tr>
            <td style="" width=""100%"" height=""20"">
            <h3 style=""text-align: center;color: #8CBE3F;font-size: 22px;margin: 5px 0 5px 0;font-weight: normal;line-height: 18px; font-style:italic;"">Registro Nacional de Turismo No. " + codigo + @"</h3>
            </td>
              </tr>
            </tbody>
            </table>
            </td>
            </tr>
            
            <tr>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </body>
            </html>
            ";
            return html;

        }
        #endregion
        #region Html Tours
        public static string GenerarHtmlToursCotizado(DataTable datosGenerales, DataTable redesSociales,DataTable TablaPaquetesPopulares,string nombrePersona,string nombrePagina)
        {
            string _facebook = redesSociales.Rows[0]["facebook"].ToString();
            string _twitter = redesSociales.Rows[0]["twitter"].ToString();
            string _googleplus = redesSociales.Rows[0]["google"].ToString();
            string _instagram = redesSociales.Rows[0]["instagram"].ToString();
            string _youtube = redesSociales.Rows[0]["youtube"].ToString();
            
            string dominio = _dominio;
            string s = String.Format("{0:f2}", redesSociales.Rows[0]["porcentajeAnticipo"]);
            int i = s.IndexOf('.');
            string Anticipo = s.Substring(0, i);
            string m = String.Format("{0:f2}", (100.00 - Convert.ToSingle(redesSociales.Rows[0]["porcentajeAnticipo"])));
            int ii = m.IndexOf('.');
            string AnticipoResto = m.Substring(0, ii);

            string pass = (datosGenerales.Rows[0]["password"].ToString() != "") ? datosGenerales.Rows[0]["password"].ToString() : "*****";
            string html = @"<html>
            <head>
            <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" >
            <meta name=""viewport"" content=""width=device-width; initial-scale=1.0; maximum-scale=1.0;"" >
            <meta property=""og:title"" content=""*|MC:SUBJECT|*"" >
            <title></title>
            <style type=""text/css"">
            div, p, a, li, td { -webkit-text-size-adjust:none; }
            .ReadMsgBody
            {width: 100%; background-color: #ffffff;}
            .ExternalClass
            {width: 100%; background-color: #ffffff;}
            body
            {width: 100%; background-color: #ffffff; margin:0; padding:0; -webkit-font-smoothing: antialiased; mso-margin-top-alt:0px; mso-margin-bottom-alt:0px; mso-padding-alt: 0px 0px 0px 0px;}
            html
            {width: 100%; }
            img 
            {border:0px; outline:none; text-decoration:none; display:block; }
            a
            {text-decoration: none; text-transform: capitalize; line-height: 30px; color: #ffffff;}
            a span
            {text-decoration:none; color: #ffffff;}
            h1 
            {font-size: 30px; margin: 20px 0 20px 0; font-family: Helvetica, Arial, sans-serif; font-weight: normal; font-style: normal; color: #151516; text-align: left; line-height:40px;} 
            h2 
            {font-size: 18px; margin: 10px 0 10px 0; color: #000; text-align: left; font-weight: normal; font-family: Helvetica, Arial, sans-serif !important; line-height: 22px; text-decoration:none; text-transform:uppercase;}
            h3 
            {font-size: 12px; margin: 5px 0 5px 0; color: #000; text-align: left; font-weight: normal; font-family: Helvetica, Arial, sans-serif; line-height: 18px;}
            @media only screen and (max-width: 900px) 
            {td[class=headerBG] {width: 100%!important; background-repeat: no-repeat!important; background-size: 900px!important; background-position: center middle!important;}}
            @media only screen and (max-width: 640px)
            { body{ width:auto!important; }
            .BoxWrap { width:440px !important;}
            .RespoHideMedium { display:none !important; } 
            .RespoShowMedium { display:block !important; } 
            .RespoCenterMedium { text-align:center !important; }
            td[class=headerBG] {width: 100%!important;background-repeat: no-repeat!important; background-size: 800px!important; background-position: center!important;}
            img[class=RespoImage_OneTo50W],img[class=RespoImage_OneTo50] { width: 440px!important; height: 212px!important; }
            img[class=RespoImage_OneTo75W],img[class=RespoImage_OneTo75] { width: 440px!important; height: 335px!important; }
            img[class=RespoImage_OneToOneW],img[class=RespoImage_OneToOne] { width: 440px!important; height: 440px!important; }
            img[class=RespoImage_70ToOneW],img[class=RespoImage_70ToOne] { width: 440px!important; height: 628px!important; }
            }
            @media only screen and (max-width: 479px)
            {
            body{width:auto!important;}
            .BoxWrap { width:280px !important;}
            .RespoHideSmall { display:none !important; }
            .RespoCenterSmall { text-align:center !important; }
            img[class=RespoImage_OneTo50W],img[class=RespoImage_OneTo50] { width: 280px!important; height: 135px!important; }
            img[class=RespoImage_OneTo75W],img[class=RespoImage_OneTo75] { width: 280px!important; height: 213px!important; }
            img[class=RespoImage_OneToOneW],img[class=RespoImage_OneToOne] { width: 280px!important; height: 280px!important; }
            img[class=RespoImage_70ToOneW],img[class=RespoImage_70ToOne] { width: 280px!important; height: 400px!important; }
            }
            .Bg_Color
            {
             background-color: #fefefe;
            }
            .BgImageAltColor
            {
            background-color: #000000;
            }
            .Preheader_Color
            {
            background-color: #f3f3f3;
            }
            .Content_Color
            {
             /*@editable*/ background-color: #ffffff;
            }
            .Color01_B
            {
             /*@editable*/ background-color: #CE0000;
            }
            .Color01_D
            {
             /*@editable*/ background-color: #000000;
            }
            .Color02_B
            {
             /*@editable*/ background-color: #fff;
            } 
            </style>
            </head>
            <body style=""width: 100%;background-color: #ffffff;margin: 0;padding: 0;-webkit-font-smoothing: antialiased;mso-margin-top-alt: 0px;mso-margin-bottom-alt: 0px;mso-padding-alt: 0px 0px 0px 0px;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""0"" cellspacing=""0"" align=""center"">
            <tbody>
            <tr>
            <td valign=""top"" class=""Preheader_Color"" bgcolor=""#f3f3f3"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""191"" align=""center"" style=""-webkit-text-size-adjust: none;"">
            <a href=""#"" style=""border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""191"" height=""50"" src=" + dominio + @"Content/Pagina/logo.png"+""+@" alt="""" border=""0"" style=""width: 191px;height: 50px;max-width: 191px;max-height: 50px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td class="""" bgcolor=""#f3f3f3"" style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" align=""center"" style=""clear:both;"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td valign=""top"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""100%"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: center;color: #8CBE3F;font-size: 22px;margin: 5px 0 5px 0;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px; font-style:italic;"">¡Gracias por su preferencia!</h3>
            </td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: center;color: #8CBE3F;font-size: 22px;margin: 5px 0 5px 0;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px; font-style:italic;"">" + nombrePersona+ @"</h3>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td width=""100%"" height=""1"" class="""" bgcolor=""#2B9EB6"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td width=""100%"" height=""10"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td bgcolor=""#f3f3f3"" style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Color02_B"" bgcolor=""#f3f3f3"" cellpadding=""5"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td valign=""top"" height=""40"" style=""-webkit-text-size-adjust: none;"">
            &nbsp; 
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td valign=""top"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>

            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 18px;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">PRESENTAMOS COTIZACIÓN SOLICITADA </h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""20"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Nombre del tour</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">"+ datosGenerales.Rows[0]["nombrePaquete"].ToString() + @"</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Tiempo de recorrido</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + datosGenerales.Rows[0]["numdias"].ToString() + @" días y  " + datosGenerales.Rows[0]["numnoches"].ToString() +" noches" + @"</h2>
            </td>
            </tr>
            
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Más información</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;""><a style=""color:red;font-weight:bold;text-transform:uppercase;"" href=" + dominio + "tours/detalletour/" + nombrePagina + @">Click Aquí</a></h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>

            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 18px;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">DATOS</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""20"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Fecha y hora de llegada:</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + Convert.ToDateTime(datosGenerales.Rows[0]["fechaLlegada"].ToString()).ToShortDateString() + @"  " + datosGenerales.Rows[0]["horaLlegada"].ToString() + @"</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Fecha y hora de Salida:</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + Convert.ToDateTime(datosGenerales.Rows[0]["fechaSalida"].ToString()).ToShortDateString() + @"  " + datosGenerales.Rows[0]["horaSalida"].ToString() + @"</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Numero de personas:</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + datosGenerales.Rows[0]["numPersonas"].ToString() + @"</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>




            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">";

            if (Convert.ToSingle(datosGenerales.Rows[0]["precio"]) > 0.0)
            {
                html = html + @"<tr>
                <td style=""-webkit-text-size-adjust: none;"">
                <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #000;text-align: right;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Precio</h2>
                <h1 style=""font-size: 30px;margin: 20px 0 20px 0;font-family: Helvetica, Arial, sans-serif;font-weight: normal;font-style: normal;color: #151516;text-align: right;line-height: 40px;"">" + String.Format("{0:C}", Convert.ToSingle(datosGenerales.Rows[0]["precio"])) + @"</h1>
                </td>
                </tr>";
            }
            else
            {
                html = html + @"<tr>
                  <td style=""-webkit-text-size-adjust: none;"">
                      <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #000;text-align: right;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;""></h2>
                      <h1 style=""font-size: 22px;margin: 20px 0 20px 0;font-family: Helvetica, Arial, sans-serif;font-weight: normal;font-style: normal;color: #151516;text-align: center;line-height: 40px;"">Su cotización no pudo ser generada automáticamente. Uno de nuestros ejecutivos lo contactará para proporcionarle la información solicitada.</h1>   
                  </td>
                </tr>";
            }

            html = html + @"
            
            
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
";
            if (!string.IsNullOrEmpty(datosGenerales.Rows[0]["Comentarios"].ToString()))
            {
                html = html + @"<tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 18px;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">OBSERVACIONES</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
                <td style=""-webkit-text-size-adjust: none;"">
                    <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""20"" cellspacing=""0"">
                        <tbody>
                            <tr>
                                <td style=""-webkit-text-size-adjust: none;"">
                                    <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
                                        <tbody>
                                            <tr>
                                               <td style=""-webkit-text-size-adjust: none;"">
                                                <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
                                                    <tbody>
                                                        <tr>
                                                            <td style=""-webkit-text-size-adjust: none;"">
                                                            <h2 style=""text-align: right;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + datosGenerales.Rows[0]["Comentarios"].ToString() + @"</h2>
                                                            </td>
                                                        <tr>
                                                     </tbody>
                                                </table>
                                              </td>
                                           <tr>
                                       </tbody>
                                        <tr>
                                            <td style=""-webkit-text-size-adjust: none;"">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>";
            }

            html = html + @"
            <tr>
            <td valign=""top"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="" bgcolor=""#fff"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
           
           <h2 style=""text - align:center; margin: 20px 0 0 0; font - size:14px; color:#000; font-weight:bold; line-height:22px; text-decoration:none; text-transform:none; font-family:Helvetica,Arial,sans-serif"">Aceptamos pagos con tarjeta de crédito vía PayPal, depósito en efectivo o transferencia bancaria. En breve, uno de nuestros asesores se contactará con usted para explicarle a mayor detalle nuestros servicios.</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""40"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td valign=""top"" class="""" bgcolor=""#2B9EB6"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""184"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class="""" bgcolor=""#2B9EB6"" width=""100%"" cellpadding=""14"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #c5c5c5;text-align: left;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Datos de contacto:</h2>
            <h3 style=""color: #ffffff;font-size: 12px;margin: 5px 0 5px 0;text-align: left;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Tel. " + redesSociales.Rows[0]["telefono"].ToString() + @"<br><a href=""#"" style=""-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">Email. " + redesSociales.Rows[0]["correo"].ToString() + @"</a></h3>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""RespoHideMedium"" width=""0"" align=""left"" cellpadding=""0"" cellspacing=""0"" style=""font-size: 0;line-height: 0;border-collapse: collapse;"">
            <tbody>
            <tr>
            <td width=""0"" height=""2"" style=""font-size: 0;line-height: 0;border-collapse: collapse;-webkit-text-size-adjust: none;"">
            <p style=""padding-left: 20px;-webkit-text-size-adjust: none;"">&nbsp;</p>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""BoxWrap"" width=""184"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class="""" bgcolor=""#2B9EB6"" width=""100%"" cellpadding=""14"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
              <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #c5c5c5;text-align: left;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Paquetes Populares</h2>
            
            <h3 style=""color: #ffffff;font-size: 12px;margin: 5px 0 5px 0;text-align: left;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">
                 ";
            foreach (DataRow PaquetPulares in TablaPaquetesPopulares.Rows)
            {

                string id = PaquetPulares["nombre_pagina"].ToString();
                string nombreLugar = PaquetPulares["nombre"].ToString();
                html = html + @"
                        <a href = """ + dominio + @"Paquetes/DetallePaquete/" + id + @""" style = ""-webkit-text-size-adjust:none;text-decoration: none;text-transform: capitalize;line-height: 20px; color: #ffffff;"">" + nombreLugar + @"</a>
                            <br>";

            }
            html = html + @"</h3>
            
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""RespoHideMedium"" width=""0"" align=""left"" cellpadding=""0"" cellspacing=""0"" style=""font-size: 0;line-height: 0;border-collapse: collapse;"">
            <tbody>
            <tr>
            <td width=""0"" height=""2"" style=""font-size: 0;line-height: 0;border-collapse: collapse;-webkit-text-size-adjust: none;"">
            <p style=""padding-left: 20px;-webkit-text-size-adjust: none;"">&nbsp;</p>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""BoxWrap"" width=""184"" align=""right"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class="""" bgcolor=""#2B9EB6"" width=""100%"" cellpadding=""14"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #c5c5c5;text-align: left;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Redes Sociales:</h2>
            <a href=""" + _facebook + @""" style="" float: left; border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://icon-icons.com/icons2/642/PNG/512/facebook_icon-icons.com_59205.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _twitter + @""" style="" float: left; border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://icon-icons.com/icons2/838/PNG/512/circle-twitter_icon-icons.com_66835.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _instagram + @""" style="" float: left; border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://images.vexels.com/media/users/3/137380/isolated/preview/1b2ca367caa7eff8b45c09ec09b44c16-instagram-icon-logo-by-vexels.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _youtube + @""" style=""float:left;border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""http://icons.iconarchive.com/icons/igh0zt/ios7-style-metro-ui/256/MetroUI-YouTube-Alt-icon.png"" alt ="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _googleplus + @""" style=""border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://icon-icons.com/icons2/838/PNG/512/circle-google-plus_icon-icons.com_66818.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>

            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td style="" width=""100%"" height=""10""></td>
            </tr>
            <tr>
            <td>
            <h3 style=""text-align:center;color:#fff;font-size:18px;font-weight:normal;font-family:Helvetica, Arial, sans-serif;line-height:18px;"">
            <a style=""text-align:center;color:#fff;font-size:18px;font-weight:normal;font-family:Helvetica, Arial, sans-serif;line-height:18px;"" href=""" + dominio + @"/TerminosYCondiciones/"""">Términos y Condiciones de Servicio</a></h3>
            </td>
            </tr>
            <tr>
            <td>
            <h3 style=""text-align: center;color: #8CBE3F;font-size: 22px;margin: 5px 0 5px 0;font-weight: normal;line-height: 18px; font-style:italic;"">Registro Nacional de Turismo No.  " + codigo + @"</h3>
            </td>
            </tr>
           
            <tr>
            <td style="" width=""100%"" height=""20""></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td valign=""top"" class=""Preheader_Color"" bgcolor=""#f3f3f3"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
           
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </body>
            </html>
            ";
            return html;
        }
        #endregion
        #region Html Hoteles
        public static string GenerarHtmlHotelesCotizado(DataTable datosGenerales, DataTable tablaRecamaras, DataTable redesSociales)
        {
            string _facebook = redesSociales.Rows[0]["facebook"].ToString();
            string _twitter = redesSociales.Rows[0]["twitter"].ToString();
            string _googleplus = redesSociales.Rows[0]["google"].ToString();
            string _instagram = redesSociales.Rows[0]["instagram"].ToString();
            string _youtube = redesSociales.Rows[0]["youtube"].ToString();
            string dominio = _dominio;
            string s = String.Format("{0:f2}", redesSociales.Rows[0]["porcentajeAnticipo"]);
            int i = s.IndexOf('.');
            string Anticipo = s.Substring(0, i);
            string m = String.Format("{0:f2}", (100.00 - Convert.ToSingle(redesSociales.Rows[0]["porcentajeAnticipo"])));
            int ii = m.IndexOf('.');
            string AnticipoResto = m.Substring(0, ii);

            string pass = (datosGenerales.Rows[0]["password"].ToString() != "") ? datosGenerales.Rows[0]["password"].ToString() : "*****";
            string numeroEstrellas = "";
            if (datosGenerales.Rows[0]["numeroEstrellas"].ToString() != null)
            {
                for (int j = 0; j < Convert.ToInt32(datosGenerales.Rows[0]["numeroEstrellas"].ToString()); j++)
                {
                    numeroEstrellas += "*";
                }
            }
            string html = @"<html>
            <head>
            <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" >
            <meta name=""viewport"" content=""width=device-width; initial-scale=1.0; maximum-scale=1.0;"" >
            <meta property=""og:title"" content=""*|MC:SUBJECT|*"" >
            <title></title>
            <style type=""text/css"">
            div, p, a, li, td { -webkit-text-size-adjust:none; }
            .ReadMsgBody
            {width: 100%; background-color: #ffffff;}
            .ExternalClass
            {width: 100%; background-color: #ffffff;}
            body
            {width: 100%; background-color: #ffffff; margin:0; padding:0; -webkit-font-smoothing: antialiased; mso-margin-top-alt:0px; mso-margin-bottom-alt:0px; mso-padding-alt: 0px 0px 0px 0px;}
            html
            {width: 100%; }
            img 
            {border:0px; outline:none; text-decoration:none; display:block; }
            a
            {text-decoration: none; text-transform: capitalize; line-height: 30px; color: #ffffff;}
            a span
            {text-decoration:none; color: #ffffff;}
            h1 
            {font-size: 30px; margin: 20px 0 20px 0; font-family: Helvetica, Arial, sans-serif; font-weight: normal; font-style: normal; color: #151516; text-align: left; line-height:40px;} 
            h2 
            {font-size: 18px; margin: 10px 0 10px 0; color: #000; text-align: left; font-weight: normal; font-family: Helvetica, Arial, sans-serif !important; line-height: 22px; text-decoration:none; text-transform:uppercase;}
            h3 
            {font-size: 12px; margin: 5px 0 5px 0; color: #000; text-align: left; font-weight: normal; font-family: Helvetica, Arial, sans-serif; line-height: 18px;}
            @media only screen and (max-width: 900px) 
            {td[class=headerBG] {width: 100%!important; background-repeat: no-repeat!important; background-size: 900px!important; background-position: center middle!important;}}
            @media only screen and (max-width: 640px)
            { body{ width:auto!important; }
            .BoxWrap { width:440px !important;}
            .RespoHideMedium { display:none !important; } 
            .RespoShowMedium { display:block !important; } 
            .RespoCenterMedium { text-align:center !important; }
            td[class=headerBG] {width: 100%!important;background-repeat: no-repeat!important; background-size: 800px!important; background-position: center!important;}
            img[class=RespoImage_OneTo50W],img[class=RespoImage_OneTo50] { width: 440px!important; height: 212px!important; }
            img[class=RespoImage_OneTo75W],img[class=RespoImage_OneTo75] { width: 440px!important; height: 335px!important; }
            img[class=RespoImage_OneToOneW],img[class=RespoImage_OneToOne] { width: 440px!important; height: 440px!important; }
            img[class=RespoImage_70ToOneW],img[class=RespoImage_70ToOne] { width: 440px!important; height: 628px!important; }
            }
            @media only screen and (max-width: 479px)
            {
            body{width:auto!important;}
            .BoxWrap { width:280px !important;}
            .RespoHideSmall { display:none !important; }
            .RespoCenterSmall { text-align:center !important; }
            img[class=RespoImage_OneTo50W],img[class=RespoImage_OneTo50] { width: 280px!important; height: 135px!important; }
            img[class=RespoImage_OneTo75W],img[class=RespoImage_OneTo75] { width: 280px!important; height: 213px!important; }
            img[class=RespoImage_OneToOneW],img[class=RespoImage_OneToOne] { width: 280px!important; height: 280px!important; }
            img[class=RespoImage_70ToOneW],img[class=RespoImage_70ToOne] { width: 280px!important; height: 400px!important; }
            }
            .Bg_Color
            {
             background-color: #fefefe;
            }
            .BgImageAltColor
            {
            background-color: #000000;
            }
            .Preheader_Color
            {
            background-color: #f3f3f3;
            }
            .Content_Color
            {
             /*@editable*/ background-color: #ffffff;
            }
            .Color01_B
            {
             /*@editable*/ background-color: #CE0000;
            }
            .Color01_D
            {
             /*@editable*/ background-color: #000000;
            }
            .Color02_B
            {
             /*@editable*/ background-color: #fff;
            } 
            </style>
            </head>
            <body style=""width: 100%;background-color: #ffffff;margin: 0;padding: 0;-webkit-font-smoothing: antialiased;mso-margin-top-alt: 0px;mso-margin-bottom-alt: 0px;mso-padding-alt: 0px 0px 0px 0px;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""0"" cellspacing=""0"" align=""center"">
            <tbody>
            <tr>
            <td valign=""top"" class=""Preheader_Color"" bgcolor=""#f3f3f3"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""191"" align=""center"" style=""-webkit-text-size-adjust: none;"">
            <a href=""#"" style=""border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""191"" height=""50"" src=" + dominio + @"Content/Pagina/logo.png" + "" + @" alt="""" border=""0"" style=""width: 191px;height: 50px;max-width: 191px;max-height: 50px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td class="""" bgcolor=""#f3f3f3"" style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" align=""center"" style=""clear:both;"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td valign=""top"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""100%"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: center;color: #8CBE3F;font-size: 22px;margin: 5px 0 5px 0;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px; font-style:italic;"">¡Gracias por su preferencia!</h3>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td width=""100%"" height=""1"" class="""" bgcolor=""#2B9EB6"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td width=""100%"" height=""10"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td bgcolor=""#f3f3f3"" style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Color02_B"" bgcolor=""#f3f3f3"" cellpadding=""5"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: center;color: #8CBE3F;font-size: 22px;margin: 5px 0 5px 0;font-weight: normal;line-height: 18px; font-style:italic;"">Registro Nacional de Turismo No. " + codigo + @"</h3>
            <p style=""text-align: center;color: #444;font-size: 17px;margin: 5px 0 5px 0;font-weight: normal;line-height: 18px; font-style:italic; font-family: Helvetica, Arial, sans-serif;"">Somos empresa 100 % mexicana ubicada en la capital del estado de Chiapas, Tuxtla Gutiérrez.  Nuestro  objetivo principal es:  la total  satisfacción de nuestros clientes, brindándoles servicios de calidad. En unidades en óptimas condiciones;  nuestro personal, operadores y guías están altamente calificados para hacer de su viaje una experiencia inolvidable. </p>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td valign=""top"" height=""40"" style=""-webkit-text-size-adjust: none;"">
            &nbsp; 
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td valign=""top"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 18px;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">DATOS</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""20"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Fecha y hora de llegada:</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + Convert.ToDateTime(datosGenerales.Rows[0]["fechaLlegada"].ToString()).ToShortDateString() + @"  " + datosGenerales.Rows[0]["horaLlegada"].ToString() + @"</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Fecha y hora de Salida:</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + Convert.ToDateTime(datosGenerales.Rows[0]["fechaSalida"].ToString()).ToShortDateString() + @"  " + datosGenerales.Rows[0]["horaSalida"].ToString() + @"</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Categoria de Hotel:</h3>
            </td> 
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 39px;margin: 10px 0px 0px 0px;color: #F7E82F;font-weight: 800;line-height: 0px;text-decoration: none;font-family: Helvetica, Arial, sans-serif; margin-top: 15px;"">" + numeroEstrellas + @"</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Numero de personas:</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + datosGenerales.Rows[0]["numPersonas"].ToString() + @"</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>

            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 18px;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">NÚMERO DE PERSONAS</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Adultos</h2>
            </td>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Niños 3-10</h2>
            </td>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Niños 0-2</h2>
            </td>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Camas</h2>
            </td>
            <td style=""-webkit-text-size-adjust: none; width:20%"">
            <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">Tipo de Habitación</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>";

            foreach (DataRow recamara in tablaRecamaras.Rows)
            {
                html = html + @"<tr>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
                <tbody>
                <tr>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + recamara["numAdultos"].ToString() + @"</h2>
                </td>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + recamara["NumNinioMenor11"].ToString() + @"</h2>
                </td>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + recamara["NumNiniosMenor4"].ToString() + @"</h2>
                </td>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + recamara["NumCamas"].ToString() + @"</h2>
                </td>
                <td style=""-webkit-text-size-adjust: none; width:18%"">
                <h2 style=""text-align: center;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + recamara["tipoHabitacion"].ToString() + @"</h2>
                </td>
                </tr>
                </tbody>
                </table>
                </td>
                </tr>
                <tr>
                <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
                </tr>";
            }

            if (Convert.ToSingle(datosGenerales.Rows[0]["precio"]) > 0.0)
            {
                html = html + @"<tr>
                <td style=""-webkit-text-size-adjust: none;"">
                <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #000;text-align: right;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Precio</h2>
                <h1 style=""font-size: 30px;margin: 20px 0 20px 0;font-family: Helvetica, Arial, sans-serif;font-weight: normal;font-style: normal;color: #151516;text-align: right;line-height: 40px;"">" + String.Format("{0:C}", Convert.ToSingle(datosGenerales.Rows[0]["precio"])) + @"</h1>
                </td>
                </tr>";
            }
            else
            {
                html = html + @"<tr>
                  <td style=""-webkit-text-size-adjust: none;"">
                      <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #000;text-align: right;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;""></h2>
                      <h1 style=""font-size: 22px;margin: 20px 0 20px 0;font-family: Helvetica, Arial, sans-serif;font-weight: normal;font-style: normal;color: #151516;text-align: right;line-height: 40px;"">En un maximo de 48 hrs. le haremos llegar la cotizaciòn</h1>   
                  </td>
                </tr>";
            }

            html = html + @"
            
            
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td valign=""top"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="" bgcolor=""#fff"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 10px;color: #000;font-weight: bold;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">La transportación que le brindamos es privada no se añade a ningún grupo y contamos con salidas diarias.</h2>
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 10px;color: #000;font-weight: bold;line-height: 18px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Para poder reservar con operadora turística Por Chiapas, se realiza un depósito o transferencia bancaria del " + Anticipo + @"% del monto total del servicio y el otro " + AnticipoResto + @"% se liquida al llegar a Tuxtla Gutiérrez. </h2>
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 14px;color: #000;font-weight: bold;line-height: 18px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">EN BREVE UN AGENTE DE VENTAS SE COMUNICARÁ CON USTED PARA EXPLICARLE CON MAYOR DETALLE NUESTROS SERVICIOS.</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""60"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td valign=""top"" class="""" bgcolor=""#2B9EB6"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""184"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class="""" bgcolor=""#2B9EB6"" width=""100%"" cellpadding=""14"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #c5c5c5;text-align: left;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Datos de contacto:</h2>
            <h3 style=""color: #ffffff;font-size: 12px;margin: 5px 0 5px 0;text-align: left;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Tel. " + redesSociales.Rows[0]["telefono"].ToString() + @"<br><a href=""#"" style=""-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">Email. " + redesSociales.Rows[0]["correo"].ToString() + @"</a></h3>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""RespoHideMedium"" width=""0"" align=""left"" cellpadding=""0"" cellspacing=""0"" style=""font-size: 0;line-height: 0;border-collapse: collapse;"">
            <tbody>
            <tr>
            <td width=""0"" height=""2"" style=""font-size: 0;line-height: 0;border-collapse: collapse;-webkit-text-size-adjust: none;"">
            <p style=""padding-left: 20px;-webkit-text-size-adjust: none;"">&nbsp;</p>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""BoxWrap"" width=""184"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class="""" bgcolor=""#2B9EB6"" width=""100%"" cellpadding=""14"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #c5c5c5;text-align: left;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Paquetes:</h2>
            <h3 style=""color: #ffffff;font-size: 12px;margin: 5px 0 5px 0;text-align: left;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;""><a href=""" + dominio + @"/paquetes/?id_seccion=AF43EC32-02B3-4B57-847D-E872C02217B9"" style=""-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">Chiapas</a><br><a href=""" + dominio + @"/paquetes/?id_seccion=D474D40B-8BFA-4AD0-AD27-CA5F4D92BC43"" style=""-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">Yucatan</a><br><a href=""" + dominio + @"/paquetes/?id_seccion=A0EDC619-01CC-499C-A4A3-8543300FD9B8"" style=""-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">QuintanaRoo</a></h3>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""RespoHideMedium"" width=""0"" align=""left"" cellpadding=""0"" cellspacing=""0"" style=""font-size: 0;line-height: 0;border-collapse: collapse;"">
            <tbody>
            <tr>
            <td width=""0"" height=""2"" style=""font-size: 0;line-height: 0;border-collapse: collapse;-webkit-text-size-adjust: none;"">
            <p style=""padding-left: 20px;-webkit-text-size-adjust: none;"">&nbsp;</p>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""BoxWrap"" width=""184"" align=""right"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class="""" bgcolor=""#2B9EB6"" width=""100%"" cellpadding=""14"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #c5c5c5;text-align: left;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Servicios:</h2>
            <h3 style=""color: #ffffff;font-size: 12px;margin: 5px 0 5px 0;text-align: left;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;""><a href=""" + dominio + @"/Tours/?id_seccion=AF43EC32-02B3-4B57-847D-E872C02217B9"" style=""-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">Tour</a><br><a href=""" + dominio + @"/Transportacion/?id_seccion=AF43EC32-02B3-4B57-847D-E872C02217B9"" style=""-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">Transportaciòn</a>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td style="" width=""100%"" height=""10""></td>
            </tr>
            <tr>
            <td>
            <h3 style=""text-align:center;color:#fff;font-size:18px;font-weight:normal;font-family:Helvetica, Arial, sans-serif;line-height:18px;"">
            <a style=""text-align:center;color:#fff;font-size:18px;font-weight:normal;font-family:Helvetica, Arial, sans-serif;line-height:18px;"" href=""" + dominio + @"/TerminosYCondiciones/"""">Términos y Condiciones de Servicio</a></h3>
            </td>
            </tr>
            <tr>
            <td style="" width=""100%"" height=""20""></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td valign=""top"" class=""Preheader_Color"" bgcolor=""#f3f3f3"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <img width=""600"" height=""200""  alt="""" border=""0"" style=""width: 600px;height: 200px;max-width: 600px;max-height: 200px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </td>
            </tr>
            <td class=""RespoHideSmall"" width=""150"" style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table cellpadding=""0"" cellspacing=""0"" align=""center"">
            <tbody>
            <tr>
            <td width=""50"" align=""center"" style=""-webkit-text-size-adjust: none;"">
            <a href=""" + _facebook + @""" style=""border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""40"" height=""40"" src=""" + dominio + @"/Content/Pagina/icon_s01.png"" alt="""" border=""0"" style=""width: 40px;height: 40px;max-width: 40px;max-height: 40px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            </td>
            <td width=""50"" align=""center"" style=""-webkit-text-size-adjust: none;"">
            <a href=""" + _twitter + @""" style=""border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""40"" height=""40"" src=""" + dominio + @"/Content/Pagina/icon_s02.png"" alt="""" border=""0"" style=""width: 40px;height: 40px;max-width: 40px;max-height: 40px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            </td>
            <td width=""50"" align=""center"" style=""-webkit-text-size-adjust: none;"">
            <a href=""" + _googleplus + @""" style=""border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""40"" height=""40"" src=""" + dominio + @"/Content/Pagina/icon_s03.png"" alt="""" border=""0"" style=""width: 40px;height: 40px;max-width: 40px;max-height: 40px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </body>
            </html>
            ";
            return html;
        }
        #endregion
        #region Html Transportacion
        public static string GenerarHtmlTransportacionCotizado(DataTable datosGenerales, DataTable redesSociales,DataTable TablaPaquetesPopulares,string nombrePersona, string nombreAuto,string enlace)
        {
            string _facebook = redesSociales.Rows[0]["facebook"].ToString();
            string _twitter = redesSociales.Rows[0]["twitter"].ToString();
            string _googleplus = redesSociales.Rows[0]["google"].ToString();
            string _instagram = redesSociales.Rows[0]["instagram"].ToString();
            string _youtube = redesSociales.Rows[0]["youtube"].ToString();
            string dominio = _dominio;
            string s = String.Format("{0:f2}", redesSociales.Rows[0]["porcentajeAnticipo"]);
            int i = s.IndexOf('.');
            string Anticipo = s.Substring(0, i);
            string m = String.Format("{0:f2}", (100.00 - Convert.ToSingle(redesSociales.Rows[0]["porcentajeAnticipo"])));
            int ii = m.IndexOf('.');
            string AnticipoResto = m.Substring(0, ii);

            string pass = (datosGenerales.Rows[0]["password"].ToString() != "") ? datosGenerales.Rows[0]["password"].ToString() : "*****";
            string html = @"<html>
            <head>
            <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" >
            <meta name=""viewport"" content=""width=device-width; initial-scale=1.0; maximum-scale=1.0;"" >
            <meta property=""og:title"" content=""*|MC:SUBJECT|*"" >
            <title></title>
            <style type=""text/css"">
            div, p, a, li, td { -webkit-text-size-adjust:none; }
            .ReadMsgBody
            {width: 100%; background-color: #ffffff;}
            .ExternalClass
            {width: 100%; background-color: #ffffff;}
            body
            {width: 100%; background-color: #ffffff; margin:0; padding:0; -webkit-font-smoothing: antialiased; mso-margin-top-alt:0px; mso-margin-bottom-alt:0px; mso-padding-alt: 0px 0px 0px 0px;}
            html
            {width: 100%; }
            img 
            {border:0px; outline:none; text-decoration:none; display:block; }
            a
            {text-decoration: none; text-transform: capitalize; line-height: 30px; color: #ffffff;}
            a span
            {text-decoration:none; color: #ffffff;}
            h1 
            {font-size: 30px; margin: 20px 0 20px 0; font-family: Helvetica, Arial, sans-serif; font-weight: normal; font-style: normal; color: #151516; text-align: left; line-height:40px;} 
            h2 
            {font-size: 18px; margin: 10px 0 10px 0; color: #000; text-align: left; font-weight: normal; font-family: Helvetica, Arial, sans-serif !important; line-height: 22px; text-decoration:none; text-transform:uppercase;}
            h3 
            {font-size: 12px; margin: 5px 0 5px 0; color: #000; text-align: left; font-weight: normal; font-family: Helvetica, Arial, sans-serif; line-height: 18px;}
            @media only screen and (max-width: 900px) 
            {td[class=headerBG] {width: 100%!important; background-repeat: no-repeat!important; background-size: 900px!important; background-position: center middle!important;}}
            @media only screen and (max-width: 640px)
            { body{ width:auto!important; }
            .BoxWrap { width:440px !important;}
            .RespoHideMedium { display:none !important; } 
            .RespoShowMedium { display:block !important; } 
            .RespoCenterMedium { text-align:center !important; }
            td[class=headerBG] {width: 100%!important;background-repeat: no-repeat!important; background-size: 800px!important; background-position: center!important;}
            img[class=RespoImage_OneTo50W],img[class=RespoImage_OneTo50] { width: 440px!important; height: 212px!important; }
            img[class=RespoImage_OneTo75W],img[class=RespoImage_OneTo75] { width: 440px!important; height: 335px!important; }
            img[class=RespoImage_OneToOneW],img[class=RespoImage_OneToOne] { width: 440px!important; height: 440px!important; }
            img[class=RespoImage_70ToOneW],img[class=RespoImage_70ToOne] { width: 440px!important; height: 628px!important; }
            }
            @media only screen and (max-width: 479px)
            {
            body{width:auto!important;}
            .BoxWrap { width:280px !important;}
            .RespoHideSmall { display:none !important; }
            .RespoCenterSmall { text-align:center !important; }
            img[class=RespoImage_OneTo50W],img[class=RespoImage_OneTo50] { width: 280px!important; height: 135px!important; }
            img[class=RespoImage_OneTo75W],img[class=RespoImage_OneTo75] { width: 280px!important; height: 213px!important; }
            img[class=RespoImage_OneToOneW],img[class=RespoImage_OneToOne] { width: 280px!important; height: 280px!important; }
            img[class=RespoImage_70ToOneW],img[class=RespoImage_70ToOne] { width: 280px!important; height: 400px!important; }
            }
            .Bg_Color
            {
             background-color: #fefefe;
            }
            .BgImageAltColor
            {
            background-color: #000000;
            }
            .Preheader_Color
            {
            background-color: #f3f3f3;
            }
            .Content_Color
            {
             /*@editable*/ background-color: #ffffff;
            }
            .Color01_B
            {
             /*@editable*/ background-color: #CE0000;
            }
            .Color01_D
            {
             /*@editable*/ background-color: #000000;
            }
            .Color02_B
            {
             /*@editable*/ background-color: #fff;
            } 
            </style>
            </head>
            <body style=""width: 100%;background-color: #ffffff;margin: 0;padding: 0;-webkit-font-smoothing: antialiased;mso-margin-top-alt: 0px;mso-margin-bottom-alt: 0px;mso-padding-alt: 0px 0px 0px 0px;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""0"" cellspacing=""0"" align=""center"">
            <tbody>
            <tr>
            <td valign=""top"" class=""Preheader_Color"" bgcolor=""#f3f3f3"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""191"" align=""center"" style=""-webkit-text-size-adjust: none;"">
            <a href=""#"" style=""border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""191"" height=""50"" src=" + dominio + @"Content/Pagina/logo.png" + "" + @"  alt="""" border=""0"" style=""width: 191px;height: 50px;max-width: 191px;max-height: 50px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td class="""" bgcolor=""#f3f3f3"" style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" align=""center"" style=""clear:both;"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td valign=""top"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""100%"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: center;color: #8CBE3F;font-size: 22px;margin: 5px 0 5px 0;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px; font-style:italic;"">¡Gracias por su preferencia!</h3>
            </td>
            </tr>
             <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: center;color: #8CBE3F;font-size: 22px;margin: 5px 0 5px 0;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px; font-style:italic;"">" + nombrePersona+ @"</h3>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td width=""100%"" height=""1"" class="""" bgcolor=""#2B9EB6"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td width=""100%"" height=""10"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td bgcolor=""#f3f3f3"" style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Color02_B"" bgcolor=""#f3f3f3"" cellpadding=""5"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td valign=""top"" height=""40"" style=""-webkit-text-size-adjust: none;"">
            &nbsp; 
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td valign=""top"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>

            
             <tr>
                <td style=""-webkit-text-size-adjust: none;"">
                    <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""0"" cellspacing=""0"">
                        <tbody>
                            <tr>
                                <td style=""-webkit-text-size-adjust: none;"">
                                <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 18px;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">PRESENTAMOS LA COTIZACIÓN SOLICITADA</h2>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            
            <tr>
                <td style=""-webkit-text-size-adjust: none;"">
                    <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""20"" cellspacing=""0"">
                        <tbody>
                            <tr>
                                <td style=""-webkit-text-size-adjust: none;"">

                                    <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
                                        <tbody>
                                            <tr>
                                                <td style=""-webkit-text-size-adjust: none;"">
                                                <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
                                                    <tbody>
                                                        <tr>
                                                            <td style=""-webkit-text-size-adjust: none;"">
                                                            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Nombre del servicio</h3>
                                                            </td>
                                                            <td style=""-webkit-text-size-adjust: none;"">
                                                            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" +nombreAuto+ @"</h2>
                                                             </td>
                                                        <tr>
                                                     </tbody>
                                                   </table>
                                                    </td>
                                               <tr>
                                                <tr>
                                            <td width=""100 % "" height=""2"" style=""""></td>
                                              </ tr >
                                      </tbody>
                                    </table>
                                
                                    <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
                                        <tbody>
                                            <tr>
                                                <td style=""-webkit-text-size-adjust: none;"">
                                                <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
                                                    <tbody>
                                                        <tr>
                                                            <td style=""-webkit-text-size-adjust: none;"">
                                                            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Duración del servicio</h3>
                                                            </td>
                                                            <td style=""-webkit-text-size-adjust: none;"">
                                                            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + datosGenerales.Rows[0]["numdias"].ToString() + " días y "+ datosGenerales.Rows[0]["numnoches"].ToString() +" noches"+ @"</h2>
                                                             </td>
                                                        <tr>
                                                     </tbody>
                                                   </table>
                                                    </td>
                                               <tr>
                                                 <tr>
                                            <td width=""100 % "" height=""2"" style=""""></td>
                                              </ tr >
                                     </tbody>
                                    </table>
                                
                                    <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
                                        <tbody>
                                            <tr>
                                                <td style=""-webkit-text-size-adjust: none;"">
                                                <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
                                                    <tbody>
                                                        <tr>
                                                            <td style=""-webkit-text-size-adjust: none;"">
                                                            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Más información</h3>
                                                            </td>
                                                            <td style=""-webkit-text-size-adjust: none;"">
                                                            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;""><a style=""color:red; font-weight:bold;"" href=" + dominio + "Transportacion/DetalleAuto/" + enlace + @">CLICK AQUÍ</a></h2>
                                                             </td>
                                                        <tr>
                                                     </tbody>
                                                   </table>
                                                    </td>
                                               <tr>
                                                 <tr>
                                            <td width=""100 % "" height=""2"" style=""""></td>
                                              </ tr >
                                     </tbody>
                                    </table>
                                </td>
                            </tr>

                        </tbody>
                    </table>
                </td>
            </tr>
        
      
            


            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 18px;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">DATOS</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""20"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Fecha y hora de llegada:</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + Convert.ToDateTime(datosGenerales.Rows[0]["fechaLlegada"].ToString()).ToShortDateString() + @"  " + datosGenerales.Rows[0]["horaLlegada"].ToString() + @"</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Fecha y hora de Salida:</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + Convert.ToDateTime(datosGenerales.Rows[0]["fechaSalida"].ToString()).ToShortDateString() + @"  " + datosGenerales.Rows[0]["horaSalida"].ToString() + @"</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: left;font-size: 12px;margin: 5px 0 5px 0;color: #000;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Numero de personas:</h3>
            </td>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: right;text-transform: capitalize;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + datosGenerales.Rows[0]["numPersonas"].ToString() + @"</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""2"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">";

            if (Convert.ToSingle(datosGenerales.Rows[0]["precio"]) > 0.0)
            {
                html = html + @"<tr>
                <td style=""-webkit-text-size-adjust: none;"">
                <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #000;text-align: right;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Precio</h2>
                <h1 style=""font-size: 30px;margin: 20px 0 20px 0;font-family: Helvetica, Arial, sans-serif;font-weight: normal;font-style: normal;color: #151516;text-align: right;line-height: 40px;"">" + String.Format("{0:C}", Convert.ToSingle(datosGenerales.Rows[0]["precio"])) + @"</h1>
                </td>
                </tr>";
            }
            else
            {
                html = html + @"<tr>
                  <td style=""-webkit-text-size-adjust: none;"">
	                <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #000;text-align: right;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;""></h2>
	                <h1 style=""font-size: 22px;margin: 20px 0 20px 0;font-family: Helvetica, Arial, sans-serif;font-weight: normal;font-style: normal;color: #151516;text-align: center;line-height: 40px;"">Su cotización no pudo ser generada automáticamente. Uno de nuestros ejecutivos lo contactará para proporcionarle la información solicitada.</h1>	
                  </td>
                </tr>";
            }

            html = html + @"
            <tr>
            <td valign=""top"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
";
            if (!string.IsNullOrEmpty(datosGenerales.Rows[0]["Comentarios"].ToString()))
            {
                html = html + @"<tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 18px;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">OBSERVACIONES</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
                <td style=""-webkit-text-size-adjust: none;"">
                    <table width=""100%"" class="""" bgcolor=""#2B9EB6"" cellpadding=""20"" cellspacing=""0"">
                        <tbody>
                            <tr>
                                <td style=""-webkit-text-size-adjust: none;"">
                                    <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
                                        <tbody>
                                            <tr>
                                               <td style=""-webkit-text-size-adjust: none;"">
                                                <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""15"" cellspacing=""0"">
                                                    <tbody>
                                                        <tr>
                                                            <td style=""-webkit-text-size-adjust: none;"">
                                                            <h2 style=""text-align: right;font-size: 18px;margin: 10px 0 10px 0;color: #000;font-weight: normal;line-height: 22px;text-decoration: none;font-family: Helvetica, Arial, sans-serif;"">" + datosGenerales.Rows[0]["Comentarios"].ToString() + @"</h2>
                                                            </td>
                                                        <tr>
                                                     </tbody>
                                                </table>
                                              </td>
                                           <tr>
                                       </tbody>
                                        <tr>
                                            <td style=""-webkit-text-size-adjust: none;"">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>";
            }

            html = html + @"
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="" bgcolor=""#fff"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""40"" style=""-webkit-text-size-adjust: none;""><h2 style=""text - align:center; margin: 20px 0 0 0; font - size:14px; color:#000; font-weight:bold; line-height:22px; text-decoration:none; text-transform:none; font-family:Helvetica,Arial,sans-serif"">Aceptamos pagos con tarjeta de crédito vía PayPal, depósito en efectivo o transferencia bancaria.En breve, uno de nuestros asesores se contactará con usted para explicarle a mayor detalle nuestros servicios.</h2></td>
            </tr>
            
            <tr>
            <td width=""100%"" height=""60"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            
            <tr>
            <td valign=""top"" class="""" bgcolor=""#2B9EB6"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""184"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class="""" bgcolor=""#2B9EB6"" width=""100%"" cellpadding=""14"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #c5c5c5;text-align: left;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Datos de contacto:</h2>
            <h3 style=""color: #ffffff;font-size: 12px;margin: 5px 0 5px 0;text-align: left;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Tel. " + redesSociales.Rows[0]["telefono"].ToString() + @"<br><a href=""#"" style=""-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">Email. " + redesSociales.Rows[0]["correo"].ToString() + @"</a></h3>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""RespoHideMedium"" width=""0"" align=""left"" cellpadding=""0"" cellspacing=""0"" style=""font-size: 0;line-height: 0;border-collapse: collapse;"">
            <tbody>
            <tr>
            <td width=""0"" height=""2"" style=""font-size: 0;line-height: 0;border-collapse: collapse;-webkit-text-size-adjust: none;"">
            <p style=""padding-left: 20px;-webkit-text-size-adjust: none;"">&nbsp;</p>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""BoxWrap"" width=""184"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class="""" bgcolor=""#2B9EB6"" width=""100%"" cellpadding=""14"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            
              <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #c5c5c5;text-align: left;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Paquetes Populares</h2>
            
            <h3 style=""color: #ffffff;font-size: 12px;margin: 5px 0 5px 0;text-align: left;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">
                 ";
            foreach (DataRow PaquetPulares in TablaPaquetesPopulares.Rows)
            {

                string id = PaquetPulares["nombre_pagina"].ToString();
                string nombreLugar = PaquetPulares["nombre"].ToString();
                html = html + @"
                        <a href = """ + dominio + @"Paquetes/DetallePaquete/" + id + @""" style = ""-webkit-text-size-adjust:none;text-decoration: none;text-transform: capitalize;line-height: 20px; color: #ffffff;"">" + nombreLugar + @"</a>
                            <br>";

            }
            html = html + @"</h3>

            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""RespoHideMedium"" width=""0"" align=""left"" cellpadding=""0"" cellspacing=""0"" style=""font-size: 0;line-height: 0;border-collapse: collapse;"">
            <tbody>
            <tr>
            <td width=""0"" height=""2"" style=""font-size: 0;line-height: 0;border-collapse: collapse;-webkit-text-size-adjust: none;"">
            <p style=""padding-left: 20px;-webkit-text-size-adjust: none;"">&nbsp;</p>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""BoxWrap"" width=""184"" align=""right"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class="""" bgcolor=""#2B9EB6"" width=""100%"" cellpadding=""14"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #c5c5c5;text-align: left;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Redes Sociales:</h2>
            
            <a href=""" + _facebook + @""" style="" float: left; border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://icon-icons.com/icons2/642/PNG/512/facebook_icon-icons.com_59205.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _twitter + @""" style="" float: left; border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://icon-icons.com/icons2/838/PNG/512/circle-twitter_icon-icons.com_66835.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _instagram + @""" style="" float: left; border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://images.vexels.com/media/users/3/137380/isolated/preview/1b2ca367caa7eff8b45c09ec09b44c16-instagram-icon-logo-by-vexels.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _youtube + @""" style=""float:left;border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""http://icons.iconarchive.com/icons/igh0zt/ios7-style-metro-ui/256/MetroUI-YouTube-Alt-icon.png"" alt ="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _googleplus + @""" style=""border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://icon-icons.com/icons2/838/PNG/512/circle-google-plus_icon-icons.com_66818.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>

            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td style="" width=""100%"" height=""10""></td>
            </tr>
            <tr>
            <td>
            <h3 style=""text-align:center;color:#fff;font-size:18px;font-weight:normal;font-family:Helvetica, Arial, sans-serif;line-height:18px;"">
            <a style=""text-align:center;color:#fff;font-size:18px;font-weight:normal;font-family:Helvetica, Arial, sans-serif;line-height:18px;"" href=""" + dominio + @"/TerminosYCondiciones/"""">Términos y Condiciones de Servicio</a></h3>
            </td>
            </tr>
            <tr>
            <td>
            <h3 style=""text-align: center;color: #8CBE3F;font-size: 22px;margin: 5px 0 5px 0;font-weight: normal;line-height: 18px; font-style:italic;"">Registro Nacional de Turismo No. " + codigo + @"</h3>
             </td>
            </tr>
           
            <tr>
            <td style="" width=""100%"" height=""20""></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
           
            <tr>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </body>
            </html>
            ";
            return html;

        }
        #endregion
        #region Html Tours Empresa
        public static string GenerarHtmlToursEmpresaCotizado(DataTable datosGenerales, DataTable redesSociales,DataTable TablaPaquetesPopulares)
        {
            string _facebook = redesSociales.Rows[0]["facebook"].ToString();
            string _twitter = redesSociales.Rows[0]["twitter"].ToString();
            string _googleplus = redesSociales.Rows[0]["google"].ToString();
            string _instagram = redesSociales.Rows[0]["instagram"].ToString();
            string _youtube = redesSociales.Rows[0]["youtube"].ToString();
            string dominio = _dominio;
            string s = String.Format("{0:f2}", redesSociales.Rows[0]["porcentajeAnticipo"]);
            int i = s.IndexOf('.');
            string Anticipo = s.Substring(0, i);
            string m = String.Format("{0:f2}", (100.00 - Convert.ToSingle(redesSociales.Rows[0]["porcentajeAnticipo"])));
            int ii = m.IndexOf('.');
            string AnticipoResto = m.Substring(0, ii);
            string pass = (datosGenerales.Rows[0]["password"].ToString() != "") ? datosGenerales.Rows[0]["password"].ToString() : "*****";
            string html = @"<html>
            <head>
            <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" >
            <meta name=""viewport"" content=""width=device-width; initial-scale=1.0; maximum-scale=1.0;"" >
            <meta property=""og:title"" content=""*|MC:SUBJECT|*"" >
            <title></title>
            <style type=""text/css"">
            div, p, a, li, td { -webkit-text-size-adjust:none; }
            .ReadMsgBody
            {width: 100%; background-color: #ffffff;}
            .ExternalClass
            {width: 100%; background-color: #ffffff;}
            body
            {width: 100%; background-color: #ffffff; margin:0; padding:0; -webkit-font-smoothing: antialiased; mso-margin-top-alt:0px; mso-margin-bottom-alt:0px; mso-padding-alt: 0px 0px 0px 0px;}
            html
            {width: 100%; }
            img 
            {border:0px; outline:none; text-decoration:none; display:block; }
            a
            {text-decoration: none; text-transform: capitalize; line-height: 30px; color: #ffffff;}
            a span
            {text-decoration:none; color: #ffffff;}
            h1 
            {font-size: 30px; margin: 20px 0 20px 0; font-family: Helvetica, Arial, sans-serif; font-weight: normal; font-style: normal; color: #151516; text-align: left; line-height:40px;} 
            h2 
            {font-size: 18px; margin: 10px 0 10px 0; color: #000; text-align: left; font-weight: normal; font-family: Helvetica, Arial, sans-serif !important; line-height: 22px; text-decoration:none; text-transform:uppercase;}
            h3 
            {font-size: 12px; margin: 5px 0 5px 0; color: #000; text-align: left; font-weight: normal; font-family: Helvetica, Arial, sans-serif; line-height: 18px;}
            @media only screen and (max-width: 900px) 
            {td[class=headerBG] {width: 100%!important; background-repeat: no-repeat!important; background-size: 900px!important; background-position: center middle!important;}}
            @media only screen and (max-width: 640px)
            { body{ width:auto!important; }
            .BoxWrap { width:440px !important;}
            .RespoHideMedium { display:none !important; } 
            .RespoShowMedium { display:block !important; } 
            .RespoCenterMedium { text-align:center !important; }
            td[class=headerBG] {width: 100%!important;background-repeat: no-repeat!important; background-size: 800px!important; background-position: center!important;}
            img[class=RespoImage_OneTo50W],img[class=RespoImage_OneTo50] { width: 440px!important; height: 212px!important; }
            img[class=RespoImage_OneTo75W],img[class=RespoImage_OneTo75] { width: 440px!important; height: 335px!important; }
            img[class=RespoImage_OneToOneW],img[class=RespoImage_OneToOne] { width: 440px!important; height: 440px!important; }
            img[class=RespoImage_70ToOneW],img[class=RespoImage_70ToOne] { width: 440px!important; height: 628px!important; }
            }
            @media only screen and (max-width: 479px)
            {
            body{width:auto!important;}
            .BoxWrap { width:280px !important;}
            .RespoHideSmall { display:none !important; }
            .RespoCenterSmall { text-align:center !important; }
            img[class=RespoImage_OneTo50W],img[class=RespoImage_OneTo50] { width: 280px!important; height: 135px!important; }
            img[class=RespoImage_OneTo75W],img[class=RespoImage_OneTo75] { width: 280px!important; height: 213px!important; }
            img[class=RespoImage_OneToOneW],img[class=RespoImage_OneToOne] { width: 280px!important; height: 280px!important; }
            img[class=RespoImage_70ToOneW],img[class=RespoImage_70ToOne] { width: 280px!important; height: 400px!important; }
            }
            .Bg_Color
            {
             background-color: #fefefe;
            }
            .BgImageAltColor
            {
            background-color: #000000;
            }
            .Preheader_Color
            {
            background-color: #f3f3f3;
            }
            .Content_Color
            {
             /*@editable*/ background-color: #ffffff;
            }
            .Color01_B
            {
             /*@editable*/ background-color: #CE0000;
            }
            .Color01_D
            {
             /*@editable*/ background-color: #000000;
            }
            .Color02_B
            {
             /*@editable*/ background-color: #fff;
            } 
            </style>
            </head>
            <body style=""width: 100%;background-color: #ffffff;margin: 0;padding: 0;-webkit-font-smoothing: antialiased;mso-margin-top-alt: 0px;mso-margin-bottom-alt: 0px;mso-padding-alt: 0px 0px 0px 0px;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""0"" cellspacing=""0"" align=""center"">
            <tbody>
            <tr>
            <td valign=""top"" class=""Preheader_Color"" bgcolor=""#f3f3f3"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""191"" align=""center"" style=""-webkit-text-size-adjust: none;"">
            <a href=""#"" style=""border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""191"" height=""50"" src=" + dominio + @"Content/Pagina/logo.png" + "" + @"  alt ="""" border=""0"" style=""width: 191px;height: 50px;max-width: 191px;max-height: 50px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td class="""" bgcolor=""#f3f3f3"" style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" align=""center"" style=""clear:both;"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td valign=""top"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
<tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""100%"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: center;color: #8CBE3F;font-size: 22px;margin: 5px 0 5px 0;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px; font-style:italic;"">¡Gracias por su preferencia!</h3>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td width=""100%"" height=""1"" class="""" bgcolor=""#2B9EB6"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td width=""100%"" height=""10"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td bgcolor=""#f3f3f3"" style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Color02_B"" bgcolor=""#f3f3f3"" cellpadding=""5"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
           </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td valign=""top"" height=""40"" style=""-webkit-text-size-adjust: none;"">
            &nbsp; 
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td valign=""top"" style=""-webkit-text-size-adjust: none;"">
            <table width=""600"" class=""BoxWrap"" align=""center"" cellpadding=""0"" cellspacing=""0"" border=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            </tbody>
            </table>
            <tr>
            <td valign=""top"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="" bgcolor=""#fff"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text - align:center; margin: 20px 0 0 0; font - size:14px; color:#000; font-weight:bold; line-height:22px; text-decoration:none; text-transform:none; font-family:Helvetica,Arial,sans-serif"">Aceptamos pagos con tarjeta de crédito vía PayPal, depósito en efectivo o transferencia bancaria. En breve, uno de nuestros asesores se contactará con usted para explicarle a mayor detalle nuestros servicios.</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <td width=""100%"" height=""60"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td valign=""top"" class="""" bgcolor=""#2B9EB6"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""184"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class="""" bgcolor=""#2B9EB6"" width=""100%"" cellpadding=""14"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #c5c5c5;text-align: left;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Datos de contacto:</h2>
            <h3 style=""color: #ffffff;font-size: 12px;margin: 5px 0 5px 0;text-align: left;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Tel. " + redesSociales.Rows[0]["telefono"].ToString() + @"<br><a href=""#"" style=""-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">Email. " + redesSociales.Rows[0]["correo"].ToString() + @"</a></h3>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""RespoHideMedium"" width=""0"" align=""left"" cellpadding=""0"" cellspacing=""0"" style=""font-size: 0;line-height: 0;border-collapse: collapse;"">
            <tbody>
            <tr>
            <td width=""0"" height=""2"" style=""font-size: 0;line-height: 0;border-collapse: collapse;-webkit-text-size-adjust: none;"">
            <p style=""padding-left: 20px;-webkit-text-size-adjust: none;"">&nbsp;</p>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""BoxWrap"" width=""184"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class="""" bgcolor=""#2B9EB6"" width=""100%"" cellpadding=""14"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            
            <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #c5c5c5;text-align: left;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Paquetes Populares</h2>
            
            <h3 style=""color: #ffffff;font-size: 12px;margin: 5px 0 5px 0;text-align: left;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">
                 ";
            foreach (DataRow PaquetPulares in TablaPaquetesPopulares.Rows)
            {

                string id = PaquetPulares["nombre_pagina"].ToString();
                string nombreLugar = PaquetPulares["nombre"].ToString();
                html = html + @"
                        <a href = """ + dominio + @"Paquetes/DetallePaquete/" + id + @""" style = ""-webkit-text-size-adjust:none;text-decoration: none;text-transform: capitalize;line-height: 20px; color: #ffffff;"">" + nombreLugar + @"</a>
                            <br>";

            }
            html = html + @"</h3>
             </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""RespoHideMedium"" width=""0"" align=""left"" cellpadding=""0"" cellspacing=""0"" style=""font-size: 0;line-height: 0;border-collapse: collapse;"">
            <tbody>
            <tr>
            <td width=""0"" height=""2"" style=""font-size: 0;line-height: 0;border-collapse: collapse;-webkit-text-size-adjust: none;"">
            <p style=""padding-left: 20px;-webkit-text-size-adjust: none;"">&nbsp;</p>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""BoxWrap"" width=""184"" align=""right"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class="""" bgcolor=""#2B9EB6"" width=""100%"" cellpadding=""14"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #c5c5c5;text-align: left;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Redes Sociales:</h2>
           
               <a href=""" + _facebook + @""" style="" float: left; border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://icon-icons.com/icons2/642/PNG/512/facebook_icon-icons.com_59205.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _twitter + @""" style="" float: left; border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://icon-icons.com/icons2/838/PNG/512/circle-twitter_icon-icons.com_66835.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _instagram + @""" style="" float: left; border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://images.vexels.com/media/users/3/137380/isolated/preview/1b2ca367caa7eff8b45c09ec09b44c16-instagram-icon-logo-by-vexels.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _youtube + @""" style=""float:left;border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""http://icons.iconarchive.com/icons/igh0zt/ios7-style-metro-ui/256/MetroUI-YouTube-Alt-icon.png"" alt ="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _googleplus + @""" style=""border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://icon-icons.com/icons2/838/PNG/512/circle-google-plus_icon-icons.com_66818.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td style="" width=""100%"" height=""10""></td>
            </tr>
            <tr>
            <td>
            <h3 style=""text-align:center;color:#fff;font-size:18px;font-weight:normal;font-family:Helvetica, Arial, sans-serif;line-height:18px;"">
            <a style=""text-align:center;color:#fff;font-size:18px;font-weight:normal;font-family:Helvetica, Arial, sans-serif;line-height:18px;"" href=""" + dominio + @"/TerminosYCondiciones/"""">Términos y Condiciones de Servicio</a></h3>
            </td>
            </tr>
            <tr>
            <td>
            <h3 style=""text-align: center;color: #8CBE3F;font-size: 22px;margin: 5px 0 5px 0;font-weight: normal;line-height: 18px; font-style:italic;"">Registro Nacional de Turismo No. " + codigo + @"</h3>
            </td>
            </tr>   
            <tr>
            <td style="" width=""100%"" height=""20""></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td valign=""top"" class=""Preheader_Color"" bgcolor=""#f3f3f3"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            
            <tr>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </body>
            </html>
            ";
            return html;
        }
        #endregion
        #region Html Transportacion Empresa
        public static string GenerarHtmlTransportacionCotizadoEmpresa(DataTable datosGenerales, DataTable redesSociales, DataTable TablaPaquetesPopulares,string nombreAuto)
        {
            string _facebook = redesSociales.Rows[0]["facebook"].ToString();
            string _twitter = redesSociales.Rows[0]["twitter"].ToString();
            string _googleplus = redesSociales.Rows[0]["google"].ToString();
            string _instagram = redesSociales.Rows[0]["instagram"].ToString();
            string _youtube = redesSociales.Rows[0]["youtube"].ToString();
            string dominio = _dominio;
            string s = String.Format("{0:f2}", redesSociales.Rows[0]["porcentajeAnticipo"]);
            int i = s.IndexOf('.');
            string Anticipo = s.Substring(0, i);
            string m = String.Format("{0:f2}", (100.00 - Convert.ToSingle(redesSociales.Rows[0]["porcentajeAnticipo"])));
            int ii = m.IndexOf('.');
            string AnticipoResto = m.Substring(0, ii);

            string pass = (datosGenerales.Rows[0]["password"].ToString() != "") ? datosGenerales.Rows[0]["password"].ToString() : "*****";
            string html = @"<html>
            <head>
            <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" >
            <meta name=""viewport"" content=""width=device-width; initial-scale=1.0; maximum-scale=1.0;"" >
            <meta property=""og:title"" content=""*|MC:SUBJECT|*"" >
            <title></title>
            <style type=""text/css"">
            div, p, a, li, td { -webkit-text-size-adjust:none; }
            .ReadMsgBody
            {width: 100%; background-color: #ffffff;}
            .ExternalClass
            {width: 100%; background-color: #ffffff;}
            body
            {width: 100%; background-color: #ffffff; margin:0; padding:0; -webkit-font-smoothing: antialiased; mso-margin-top-alt:0px; mso-margin-bottom-alt:0px; mso-padding-alt: 0px 0px 0px 0px;}
            html
            {width: 100%; }
            img 
            {border:0px; outline:none; text-decoration:none; display:block; }
            a
            {text-decoration: none; text-transform: capitalize; line-height: 30px; color: #ffffff;}
            a span
            {text-decoration:none; color: #ffffff;}
            h1 
            {font-size: 30px; margin: 20px 0 20px 0; font-family: Helvetica, Arial, sans-serif; font-weight: normal; font-style: normal; color: #151516; text-align: left; line-height:40px;} 
            h2 
            {font-size: 18px; margin: 10px 0 10px 0; color: #000; text-align: left; font-weight: normal; font-family: Helvetica, Arial, sans-serif !important; line-height: 22px; text-decoration:none; text-transform:uppercase;}
            h3 
            {font-size: 12px; margin: 5px 0 5px 0; color: #000; text-align: left; font-weight: normal; font-family: Helvetica, Arial, sans-serif; line-height: 18px;}
            @media only screen and (max-width: 900px) 
            {td[class=headerBG] {width: 100%!important; background-repeat: no-repeat!important; background-size: 900px!important; background-position: center middle!important;}}
            @media only screen and (max-width: 640px)
            { body{ width:auto!important; }
            .BoxWrap { width:440px !important;}
            .RespoHideMedium { display:none !important; } 
            .RespoShowMedium { display:block !important; } 
            .RespoCenterMedium { text-align:center !important; }
            td[class=headerBG] {width: 100%!important;background-repeat: no-repeat!important; background-size: 800px!important; background-position: center!important;}
            img[class=RespoImage_OneTo50W],img[class=RespoImage_OneTo50] { width: 440px!important; height: 212px!important; }
            img[class=RespoImage_OneTo75W],img[class=RespoImage_OneTo75] { width: 440px!important; height: 335px!important; }
            img[class=RespoImage_OneToOneW],img[class=RespoImage_OneToOne] { width: 440px!important; height: 440px!important; }
            img[class=RespoImage_70ToOneW],img[class=RespoImage_70ToOne] { width: 440px!important; height: 628px!important; }
            }
            @media only screen and (max-width: 479px)
            {
            body{width:auto!important;}
            .BoxWrap { width:280px !important;}
            .RespoHideSmall { display:none !important; }
            .RespoCenterSmall { text-align:center !important; }
            img[class=RespoImage_OneTo50W],img[class=RespoImage_OneTo50] { width: 280px!important; height: 135px!important; }
            img[class=RespoImage_OneTo75W],img[class=RespoImage_OneTo75] { width: 280px!important; height: 213px!important; }
            img[class=RespoImage_OneToOneW],img[class=RespoImage_OneToOne] { width: 280px!important; height: 280px!important; }
            img[class=RespoImage_70ToOneW],img[class=RespoImage_70ToOne] { width: 280px!important; height: 400px!important; }
            }
            .Bg_Color
            {
             background-color: #fefefe;
            }
            .BgImageAltColor
            {
            background-color: #000000;
            }
            .Preheader_Color
            {
            background-color: #f3f3f3;
            }
            .Content_Color
            {
             /*@editable*/ background-color: #ffffff;
            }
            .Color01_B
            {
             /*@editable*/ background-color: #CE0000;
            }
            .Color01_D
            {
             /*@editable*/ background-color: #000000;
            }
            .Color02_B
            {
             /*@editable*/ background-color: #fff;
            } 
            </style>
            </head>
            <body style=""width: 100%;background-color: #ffffff;margin: 0;padding: 0;-webkit-font-smoothing: antialiased;mso-margin-top-alt: 0px;mso-margin-bottom-alt: 0px;mso-padding-alt: 0px 0px 0px 0px;"">
            <table width=""100%"" class=""Bg_Color"" bgcolor=""#fefefe"" cellpadding=""0"" cellspacing=""0"" align=""center"">
            <tbody>
            <tr>
            <td valign=""top"" class=""Preheader_Color"" bgcolor=""#f3f3f3"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""191"" align=""center"" style=""-webkit-text-size-adjust: none;"">
            <a href=""#"" style=""border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""191"" height=""50"" src=" + dominio + @"Content/Pagina/logo.png" + "" + @"  alt="""" border=""0"" style=""width: 191px;height: 50px;max-width: 191px;max-height: 50px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td class="""" bgcolor=""#f3f3f3"" style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" border=""0"" cellpadding=""0"" cellspacing=""0"" align=""center"" style=""clear:both;"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td valign=""top"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""100%"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: center;color: #8CBE3F;font-size: 22px;margin: 5px 0 5px 0;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px; font-style:italic;"">¡Gracias por su preferencia!</h3>
            </td>
            </tr>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td width=""100%"" height=""1"" class="""" bgcolor=""#2B9EB6"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td width=""100%"" height=""10"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td bgcolor=""#f3f3f3"" style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class=""Color02_B"" bgcolor=""#f3f3f3"" cellpadding=""5"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h3 style=""text-align: center;color: #8CBE3F;font-size: 22px;margin: 5px 0 5px 0;font-weight: normal;line-height: 18px; font-style:italic;"">Registro Nacional de Turismo No. " + codigo + @"</h3>
            <p style=""text-align: center;color: #444;font-size: 17px;margin: 5px 0 5px 0;font-weight: normal;line-height: 18px; font-style:italic; font-family: Helvetica, Arial, sans-serif;"">Somos empresa 100 % mexicana ubicada en la capital del estado de Chiapas, Tuxtla Gutiérrez.  Nuestro  objetivo principal es:  la total  satisfacción de nuestros clientes, brindándoles servicios de calidad. En unidades en óptimas condiciones;  nuestro personal, operadores y guías están altamente calificados para hacer de su viaje una experiencia inolvidable. </p>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td valign=""top"" height=""40"" style=""-webkit-text-size-adjust: none;"">
            &nbsp; 
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td valign=""top"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td width=""100%"" height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table width=""100%"" class="" bgcolor=""#fff"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 10px;color: #000;font-weight: bold;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">La transportación que le brindamos es privada no se añade a ningún grupo y contamos con salidas diarias.</h2>
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 10px;color: #000;font-weight: bold;line-height: 18px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Para poder reservar con operadora turística Por Chiapas, se realiza un depósito o transferencia bancaria del " + Anticipo + @"% del monto total del servicio y el otro " + AnticipoResto + @"% se liquida al llegar a Tuxtla Gutiérrez. </h2>
            <h2 style=""text-align: center;margin: 20px 0 0 0;font-size: 14px;color: #000;font-weight: bold;line-height: 18px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">EN BREVE UN AGENTE DE VENTAS SE COMUNICARÁ CON USTED PARA EXPLICARLE CON MAYOR DETALLE NUESTROS SERVICIOS.</h2>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
              <tr>
            <td width=""100%"" height=""60"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            <tr>
            <td valign=""top"" class="""" bgcolor=""#2B9EB6"" style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""600"" align=""center"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class=""BoxWrap"" width=""184"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class="""" bgcolor=""#2B9EB6"" width=""100%"" cellpadding=""14"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #c5c5c5;text-align: left;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Datos de contacto:</h2>
            <h3 style=""color: #ffffff;font-size: 12px;margin: 5px 0 5px 0;text-align: left;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">Tel. " + redesSociales.Rows[0]["telefono"].ToString() + @"<br><a href=""#"" style=""-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">Email. " + redesSociales.Rows[0]["correo"].ToString() + @"</a></h3>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""RespoHideMedium"" width=""0"" align=""left"" cellpadding=""0"" cellspacing=""0"" style=""font-size: 0;line-height: 0;border-collapse: collapse;"">
            <tbody>
            <tr>
            <td width=""0"" height=""2"" style=""font-size: 0;line-height: 0;border-collapse: collapse;-webkit-text-size-adjust: none;"">
            <p style=""padding-left: 20px;-webkit-text-size-adjust: none;"">&nbsp;</p>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""BoxWrap"" width=""184"" align=""left"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class="""" bgcolor=""#2B9EB6"" width=""100%"" cellpadding=""14"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            
               <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #c5c5c5;text-align: left;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Paquetes Populares</h2>
            
            <h3 style=""color: #ffffff;font-size: 12px;margin: 5px 0 5px 0;text-align: left;font-weight: normal;font-family: Helvetica, Arial, sans-serif;line-height: 18px;"">
                 ";
            foreach (DataRow PaquetPulares in TablaPaquetesPopulares.Rows)
            {

                string id = PaquetPulares["nombre_pagina"].ToString();
                string nombreLugar = PaquetPulares["nombre"].ToString();
                html = html + @"
                        <a href = """ + dominio + @"Paquetes/DetallePaquete/" + id + @""" style = ""-webkit-text-size-adjust:none;text-decoration: none;text-transform: capitalize;line-height: 20px; color: #ffffff;"">" + nombreLugar + @"</a>
                            <br>";

            }
            html = html + @"</h3>

            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""RespoHideMedium"" width=""0"" align=""left"" cellpadding=""0"" cellspacing=""0"" style=""font-size: 0;line-height: 0;border-collapse: collapse;"">
            <tbody>
            <tr>
            <td width=""0"" height=""2"" style=""font-size: 0;line-height: 0;border-collapse: collapse;-webkit-text-size-adjust: none;"">
            <p style=""padding-left: 20px;-webkit-text-size-adjust: none;"">&nbsp;</p>
            </td>
            </tr>
            </tbody>
            </table>
            <table class=""BoxWrap"" width=""184"" align=""right"" cellpadding=""0"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <table class="""" bgcolor=""#2B9EB6"" width=""100%"" cellpadding=""14"" cellspacing=""0"">
            <tbody>
            <tr>
            <td style=""-webkit-text-size-adjust: none;"">
            <h2 style=""font-size: 18px;margin: 10px 0 10px 0;color: #c5c5c5;text-align: left;font-weight: normal;line-height: 22px;text-decoration: none;text-transform: uppercase;font-family: Helvetica, Arial, sans-serif;"">Redes Sociales:</h2>
            
               <a href=""" + _facebook + @""" style="" float: left; border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://icon-icons.com/icons2/642/PNG/512/facebook_icon-icons.com_59205.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _twitter + @""" style="" float: left; border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://icon-icons.com/icons2/838/PNG/512/circle-twitter_icon-icons.com_66835.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _instagram + @""" style="" float: left; border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://images.vexels.com/media/users/3/137380/isolated/preview/1b2ca367caa7eff8b45c09ec09b44c16-instagram-icon-logo-by-vexels.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _youtube + @""" style=""float:left;border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""http://icons.iconarchive.com/icons/igh0zt/ios7-style-metro-ui/256/MetroUI-YouTube-Alt-icon.png"" alt ="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
            <a href=""" + _googleplus + @""" style=""border: none;-webkit-text-size-adjust: none;text-decoration: none;text-transform: capitalize;line-height: 30px;color: #ffffff;"">
            <img width=""35"" height=""35"" src=""https://icon-icons.com/icons2/838/PNG/512/circle-google-plus_icon-icons.com_66818.png"" alt="""" border=""0"" style=""width: 35px;height: 35px;max-width: 35px;max-height: 35px;display: block;border: 0px;outline: none;text-decoration: none;"">
            </a>
                
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td style="" width=""100%"" height=""10""></td>
            </tr>
            <tr>
            <td>
            <h3 style=""text-align:center;color:#fff;font-size:18px;font-weight:normal;font-family:Helvetica, Arial, sans-serif;line-height:18px;"">
            <a style=""text-align:center;color:#fff;font-size:18px;font-weight:normal;font-family:Helvetica, Arial, sans-serif;line-height:18px;"" href=""" + dominio + @"/TerminosYCondiciones/"""">Términos y Condiciones de Servicio</a></h3>
            </td>
            </tr>
            <tr>
            <td style="" width=""100%"" height=""20""></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
           
            <tr>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
            <td height=""20"" style=""-webkit-text-size-adjust: none;""></td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            </tbody>
            </table>
            </body>
            </html>
            ";
            return html;

        }
        #endregion

        public static string RemoverSignosAcentos(string texto)
        {
            const string ConSignos = "áàäéèëíìïóòöúùuñÁÀÄÉÈËÍÌÏÓÒÖÚÙÜçÇ";
            const string SinSignos = "aaaeeeiiiooouuunAAAEEEIIIOOOUUUcC";
            string textoSinAcentos = string.Empty;

            foreach (var caracter in texto)
            {
                var indexConAcento = ConSignos.IndexOf(caracter);
                if (indexConAcento > -1)
                    textoSinAcentos = textoSinAcentos + (SinSignos.Substring(indexConAcento, 1));
                else
                    textoSinAcentos = textoSinAcentos + (caracter);
            }
            textoSinAcentos = textoSinAcentos.Replace(" ", "-");
            textoSinAcentos = textoSinAcentos.ToLower();
            return textoSinAcentos;
        }

        public static string RemoverAcentos(string texto)
        {
            const string ConSignos = "áàäéèëíìïóòöúùuñÁÀÄÉÈËÍÌÏÓÒÖÚÙÜçÇ";
            const string SinSignos = "aaaeeeiiiooouuunAAAEEEIIIOOOUUUcC";
            string textoSinAcentos = string.Empty;

            foreach (var caracter in texto)
            {
                var indexConAcento = ConSignos.IndexOf(caracter);
                if (indexConAcento > -1)
                    textoSinAcentos = textoSinAcentos + (SinSignos.Substring(indexConAcento, 1));
                else
                    textoSinAcentos = textoSinAcentos + (caracter);
            }
            textoSinAcentos = textoSinAcentos.ToLower();
            return textoSinAcentos;
        }
    }
}