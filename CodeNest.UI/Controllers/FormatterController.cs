using CodeNest.BLL.Repositories;
using CodeNest.DTO.Models.XmlModel;
using Microsoft.AspNetCore.Mvc;

namespace CodeNest.UI.Controllers
{
    public class FormatterController : Controller
    {
        private readonly IFormatterServices _formatterServices;
        public FormatterController(IFormatterServices formatterServices)
        {
            _formatterServices = formatterServices;
        }
        public IActionResult JsonFormatter() => View();

        public IActionResult Xml_formatter() => View();

        [HttpPost]
        public async Task<IActionResult> Validate(string JsonInput)
        {
            DTO.Models.ValidationDto result = await _formatterServices.JsonValidate(JsonInput);
            if (result.IsValid)
            {
                ViewBag.Success = result.Message;
                return View(result.JsonDto);
            }
            ViewBag.ErrorMessage = result.Message;
            return View(result.JsonDto);
        }

        [HttpPost]
        public async Task<IActionResult> FormatXml(XmlModel xmlModel)
        {
            XmlValidation result = await _formatterServices.XmlValidate(xmlModel.XmlInput);
            if (result.IsValid)
            {
                ViewBag.Success = result.Message;
                return View(result.XmlDto);
            }
            ViewBag.ErrorMessage = result.Message;
            return View(result.XmlDto);
        }
    }
}
