using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using ProyectoExcel.Models.ViewModels;
using EFCore.BulkExtensions;
using ProyectoExcel.Entities;

namespace ProyectoExcel.Controllers
{
    public class RelacionAnexosController : Controller
    {
        private readonly DBPIAContext _dbContext;

        public RelacionAnexosController(DBPIAContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ShowRelacionAnexosData([FromForm] IFormFile ExcelFile)
        {
            Stream stream = ExcelFile.OpenReadStream();
            IWorkbook MyExcel = null;

            if (Path.GetExtension(ExcelFile.FileName) == ".xlsx")
            {
                MyExcel = new XSSFWorkbook(stream);
            }
            else
            {
                MyExcel = new HSSFWorkbook(stream);
            }

            ISheet ExcelSheet = MyExcel.GetSheetAt(0);

            int rows = ExcelSheet.LastRowNum;

            List<VMRelacionAnexos> list = new List<VMRelacionAnexos>();

            for (int i = 1; i <= rows; i++)
            {
                IRow row = ExcelSheet.GetRow(i);
                list.Add(new VMRelacionAnexos
                {
                    Seccion = row.GetCell(0).ToString(),
                });
            }

            return StatusCode(StatusCodes.Status200OK, list);
        }
    }
}
