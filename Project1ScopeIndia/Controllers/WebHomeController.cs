using Microsoft.AspNetCore.Mvc;
using Project1ScopeIndia.Data;
using Project1ScopeIndia.Models;
using System.Diagnostics;
using MimeKit;
using MailKit.Net.Smtp;
using System.Linq.Expressions;
using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
namespace Project1ScopeIndia.Controllers
{
    public class WebHomeController : Controller
    {
        //private readonly ILogger<WebHome> _logger;
        private readonly IRegScope _regScope;
        private readonly ICourse _courseScope;
        public WebHomeController(IRegScope regScope, ICourse courseScope)
        {
            _regScope = regScope;
            _courseScope = courseScope;
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(model.ContactEmail));
                email.To.Add(MailboxAddress.Parse("aiswaishhh@gmail.com"));
                email.Subject = $"Subject:{model.ContactSubject}";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
                {
                    Text = $"Name: {model.ContactName}" + "\n" + $"Email: {model.ContactEmail}" + "\n" + $"Subject: {model.ContactSubject}" + "\n" + $"Message: {model.ContactMessage}"
                };
                using (var smtp = new SmtpClient())
                {
                    smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    smtp.Authenticate("aiswaishhh@gmail.com", "dcay dfrr bphi jknt");
                    smtp.Send(email);
                    smtp.Disconnect(true);
                }
                ViewBag.Message = "Your email has been sent successfully!";
            }
            catch (Exception)
            {
                ViewBag.Message = "Unable to send your email right now.Please try again later.";
            }
            return View(model);
        }
           
    
        public IActionResult Registration()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(RegistrationModel regmodel)
        {

            if (!ModelState.IsValid)
            {
                return View(regmodel);
            }
            regmodel.RegHobbies=String.Join(",",regmodel.RegHobbiesList);
            regmodel.RegAvatarPath = Upload(regmodel.RegAvatar);

            _regScope.Insert(regmodel);

            RegistrationModel registeredUser = _regScope.GetByEmail(regmodel.RegEmailAddress);
            
            string url = $"https://localhost:7130/WebHome/EmailVerification/{registeredUser.Id}";
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("aiswaishhh@gmail.com"));
            email.To.Add(MailboxAddress.Parse(regmodel.RegEmailAddress));
            email.Subject = "Email Verification";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = $"Click on the url to confirm your email: {url}"
            };
            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate("aiswaishhh@gmail.com", "dcay dfrr bphi jknt");
                smtp.Send(email);
                smtp.Disconnect(true);
            }
            List<RegistrationModel> regScope = _regScope.GetAll();
            TempData["Message"]="A verification email has been sent to your inbox.Please verify to continue.";
            return RedirectToAction("Registration");
        }

        public string? Upload(IFormFile myfile)
        {
            Console.WriteLine(myfile.FileName);

            try
            {
                String file_name = myfile.FileName;
                ViewBag.MyFileName = file_name;
                file_name = Path.GetFileName(file_name);
                Console.WriteLine(file_name);
                string upload_folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                //Creating the upload folder if not available wwwroot//uploads
                if (!Directory.Exists(upload_folder))
                {
                    Directory.CreateDirectory(upload_folder);
                }
                //Upload path
                string upload_path = Path.Combine(upload_folder, file_name);
                //check if the uploading file already exists
                if (System.IO.File.Exists(upload_path))
                {
                    ViewBag.UploadStatus = file_name + "-Already Exists";
                    Random file_number = new Random();
                    file_name = file_number.Next().ToString() + file_name;
                    upload_path = Path.Combine(upload_folder, file_name);
                }
                else
                {
                    ViewBag.UploadStatus += myfile.FileName + " Uploaded successfully\n";
                }
                //File upload using FileStream
                var uploadstream = new FileStream(upload_path, FileMode.Create);
                myfile.CopyToAsync(uploadstream);
                return file_name;
            }
            catch (Exception ex)
            {
                ViewBag.UploadStatus += $"Unable to upload files{ex.Message}";
            }
            return "";
            
                
        }
        [Route("/WebHome/EmailVerification/{Id}")]

        public IActionResult EmailVerification(int Id) {
            RegistrationModel regmodel = _regScope.GetById(Id);
            if (regmodel == null)
            {
                return NotFound("Invalid Link");
            }
            regmodel.RegIsVerified = true;
            TempData["Message"]="YourEmail has been verified successfully.You can now log in!";
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            ViewBag.Message=TempData["Message"];
            return View();
        }


        public string GetOTP()
        {
            Random rnd = new Random();
            var OTP = (rnd.Next(1000,9999)).ToString();
            return OTP;
        }

        public IActionResult FirstTimeLogin()
        {  
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FirstTimeLogin(string emailaddress)
        {
          
            string OTP = GetOTP();
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("aiswaishhh@gmail.com"));
            email.To.Add(MailboxAddress.Parse(emailaddress));
            email.Subject = "Email Verification";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = $":Your otp is: {OTP}"
            };
            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate("aiswaishhh@gmail.com", "dcay dfrr bphi jknt");
                smtp.Send(email);
                smtp.Disconnect(true);
            }

            TempData["CheckOTP"]=OTP;
            TempData["CheckEmail"]=emailaddress;

            return View("OTPverification");
        }


        public IActionResult OTPverification()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OTPverification(string OTP)
        {
            string mailotp = OTP;
            string CheckOTP = TempData["CheckOTP"].ToString();
            try 
            {
                if (mailotp == CheckOTP)
                {
                    if (TempData.ContainsKey("CheckEmail"))
                        TempData["PasswordGeneration"] = TempData["CheckEmail"].ToString();
                    else 
                        return RedirectToAction("Login");

                    return RedirectToAction("ConfirmPassword");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            } 
            catch (Exception ex) 
            {
                ViewBag.OTPMismatch = $"Otp Entered doesn't match.Error is{ex}";
            }

            return View(); 
        }

       


        public IActionResult ForgotPassword()
        {
            return View();
        }

        public bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ForgotPassword(string emailaddress)
        {

            if (string.IsNullOrEmpty(emailaddress))
            {
                return BadRequest("Email address cannot be empty.");
            }

            string OTP = GetOTP();
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("aiswaishhh@gmail.com"));
            email.To.Add(MailboxAddress.Parse(emailaddress));
            email.Subject = "Email Verification";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Plain)
            {
                Text = $":Your otp is: {OTP}"
            };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate("aiswaishhh@gmail.com", "dcay dfrr bphi jknt");
                smtp.Send(email);
                smtp.Disconnect(true);
            }

            TempData["CheckOTP"] = OTP;
            TempData["CheckEmail"] = emailaddress;

            return View("OTPverification");
        }

        public IActionResult ConfirmPassword() 
        {
            if (!TempData.ContainsKey("PasswordGeneration")) 
            {
                return RedirectToAction("Login");
            }

            ViewBag.Email = TempData["PasswordGeneration"];
            
            return View(); 
        }

        public IActionResult RegSuccess()
        {
            List<RegistrationModel> regScope=_regScope.GetAll();
            return View(regScope);
        }

        public IActionResult Course()
        {
            List<CourseModel> courseScope = _courseScope.GetAll();
            return View(courseScope);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

