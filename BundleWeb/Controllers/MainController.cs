
using Common.Models;
using Services.Bundle;
using Services.Product;
using System;
using System.Web.Mvc;

namespace BundleWeb.Controllers
{
    public class MainController : Controller
    {
        //TODO: DI, Logging, Validation
        private readonly BundleService _bundleService;
        private readonly ProductService _productService;

        public MainController()
        {
            _bundleService = new BundleService();
            _productService = new ProductService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetBundle(AnswerModel answer)
        {
            try
            {
                var result = _bundleService.GetRecommendedBundle(answer);

                if (result.Success)
                {
                    return Json(new
                    {
                        Status = true,
                        Bundle = result
                    }, JsonRequestBehavior.AllowGet);
                }

                return Json(new
                {
                    Status = false,
                    Message = string.Join("\n", result.Errors)
                }, JsonRequestBehavior.AllowGet);

            }
            catch(Exception e)
            {
                //TODO: log e

                return Json(new
                {
                    Status = false,
                    Message = "System error occurred"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetProducts(AnswerModel answer)
        {
            try
            {
                var result = _productService.GetProducts(answer);

                if (result.Success)
                {
                    return Json(new
                    {
                        Status = true,
                        Products = result.Products
                    }, JsonRequestBehavior.AllowGet);
                }

                return Json(new
                {
                    Status = false,
                    Message = string.Join("\n", result.Errors)
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Status = false,
                    Message = "System error occurred"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult DeleteProduct(AnswerModel answer, int bundleId, int productId)
        {
            try
            {
                var result = _bundleService.DeleteProduct(answer, bundleId, productId);

                if (result.Success)
                {
                    return Json(new
                    {
                        Status = true,
                        Bundle = result
                    }, JsonRequestBehavior.AllowGet);
                }

                return Json(new
                {
                    Status = false,
                    Message = string.Join("\n", result.Errors)
                }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new
                {
                    Status = false,
                    Message = "System error occurred"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult AddProduct(AnswerModel answer, int bundleId, int productId)
        {
            try
            {
                var result = _bundleService.AddProduct(answer, bundleId, productId);

                if (result.Success)
                {
                    return Json(new
                    {
                        Status = true,
                        Bundle = result
                    }, JsonRequestBehavior.AllowGet);
                }

                return Json(new
                {
                    Status = false,
                    Message = string.Join("\n", result.Errors)
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new
                {
                    Status = false,
                    Message = "System error occurred"
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}