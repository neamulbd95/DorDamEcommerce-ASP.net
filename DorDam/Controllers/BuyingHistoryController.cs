﻿using DorDam_ENTITY;
using DorDam_SERVICE;
using DorDam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DorDam.Controllers
{
    public class BuyingHistoryController : Controller
    {
        //
        // GET: /BuyingHistory/
        iBuying_History_Service buyHistory = Service_Center.GetBuying_History_Service();

        iProduct_Service product = Service_Center.GetProduct_Service();

        public ActionResult Index()
        {
            ViewBag.userName = Session["userName"];
            ViewBag.logged = Session["LoggedIN"];

            IEnumerable<Buying_History> History = buyHistory.GetAllValues(Session["userName"].ToString());
            List<BuyingHisotyDetails> historyDetailsList = new List<BuyingHisotyDetails>();

            foreach(Buying_History h in History)
            {
                BuyingHisotyDetails historyDetails = new BuyingHisotyDetails();

                historyDetails.productID = h.Product_ID;
                historyDetails.productName = product.Get(h.Product_ID).Product_Name;
                historyDetails.productPrice = product.Get(h.Product_ID).Product_Price;
                historyDetails.prductPicture = product.Get(h.Product_ID).Product_Picture;
                historyDetails.buyingQuantity = h.Buying_Quantity;
                historyDetails.buyingDate = h.Buying_Date;
                historyDetails.userName = h.User_Name;

                historyDetailsList.Add(historyDetails);
            }

            return View(historyDetailsList);
        }

    }
}
