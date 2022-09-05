using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using RemoteBankServices.Context;
using RemoteBankServices.Models;
using RemoteBankServices.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace RemoteBankServices.Controllers
{
    public class BankServiceController : Controller
    {
        private List<BankService> servicesList;
        private CWNETContext _context;
        private readonly IStringLocalizer<BankServiceController> _localizer;

        public BankServiceController(IStringLocalizer<BankServiceController> localizer, CWNETContext context)
        {
            _localizer = localizer;
            _context = context;
            servicesList = new List<BankService>{
                                 new BankService{ code = "Deposit", Name = _localizer["Deposit"]},
                                 new BankService{ code = "HousingLoan", Name = _localizer["HousingLoan"]},
                                 new BankService{ code = "FlexFundOverdraft", Name = _localizer["FlexFundOverdraft"]},
                                 new BankService{ code = "InvestmentLoan", Name = _localizer["InvestmentLoan"]},
                                 new BankService{ code = "EmobilityLoan", Name = _localizer["EmobilityLoan"]},
                                 new BankService{ code = "SolarPowerPlantLoan", Name = _localizer["SolarPowerPlantLoan"] }};
        }

        public ActionResult Create(string id)
        {
            ViewBag.services = servicesList.Select(x => new SelectListItem
            {
                Value = x.code,
                Text = x.Name,
                Selected = id != null && id == x.code
            }).ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ServiceViewModel serviceViewModel, string id)
        {
            ViewBag.services = servicesList.Select(x => new SelectListItem
            {
                Value = x.code,
                Text = x.Name,
                Selected = id != null && id == x.code
            }).ToList();
            
            if (ModelState.IsValid)
            {
                try
                {

                    var a = _localizer.GetAllStrings();

                    //შენახვა CWNET-ში
                    

                    Body xmlModel = new Body
                    {
                        uuid = 0,
                        id = 0,
                        formtype = 0,
                        language_prefix = _localizer["Language"],
                        created_at = DateTime.Now,
                        email_short = serviceViewModel.Email.Trim().ToLower(),
                        first_name_short = serviceViewModel.FirstName.Trim(),
                        surname_short = serviceViewModel.LastName.Trim(),
                        geocheckbox = serviceViewModel.AgreeReceiveInfo?"on":"off",
                        phone_short = serviceViewModel.PhoneNumber.Trim(),
                        interest = serviceViewModel.service
                    };
                    


                    XmlSerializer xsSubmit = new XmlSerializer(typeof(Body));
                    var subReq = new Body();
                    var xml = string.Empty;

                    var emptyNamespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                    var settings = new XmlWriterSettings();
                    settings.Indent = true;
                    settings.OmitXmlDeclaration = true;

                    using (var sww = new StringWriter())
                    {
                        using (XmlWriter writer = XmlWriter.Create(sww,settings))
                        {

                            xsSubmit.Serialize(writer, xmlModel, emptyNamespaces);
                            xml = sww.ToString();
                        }
                    }

                    PotentialClient potentialClient = new PotentialClient
                    {
                        Xmldata = xml,
                        FirstName = serviceViewModel.FirstName.Trim(),
                        LastName = serviceViewModel.LastName.Trim(),
                        Email = serviceViewModel.Email,
                        PhoneFirst = serviceViewModel.PhoneNumber.Trim(),
                        PhoneSecond = serviceViewModel.FullPhoneNumber.Trim(),
                        Created = DateTime.Now,
                        CreatorId = 100
                    };


                    _context.PotentialClients.Add(potentialClient);
                    _context.SaveChanges();

                    //განაცხადის ნომერი უნდა ჩაიწეროს ბაზიდან რაც დაბრუნდება 123456 ნაცვლად 
                    ViewBag.Message = String.Format(_localizer["SuccessMessage"], serviceViewModel.FirstName, potentialClient.PotentialClientId);
                    return View(serviceViewModel);
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            return View(serviceViewModel);
        }

        [HttpGet]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

            return LocalRedirect(returnUrl);
        }
    }
}
