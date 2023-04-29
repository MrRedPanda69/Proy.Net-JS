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
    public class ARecFinController : Controller
    {
        private readonly DBPIAContext _dbContext;

        public ARecFinController(DBPIAContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ShowPresupuestoData([FromForm] IFormFile ExcelFile)
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

            List<VMPresupuestoEgresos> list = new List<VMPresupuestoEgresos>();

            for (int i = 1; i <= rows; i++)
            {
                IRow row = ExcelSheet.GetRow(i);
                list.Add(new VMPresupuestoEgresos
                {
                    Secretaria = row.GetCell(0).ToString(),
                    Direccion = row.GetCell(1).ToString(),
                    I_PreEstim = row.GetCell(2).ToString(),
                    I_PreMod = row.GetCell(3).ToString(),
                    I_PreDev = row.GetCell(4).ToString(),
                    I_PreReca = row.GetCell(5).ToString(),
                    E_PreOrigApro = row.GetCell(6).ToString(),
                    E_1A_AmpPres = row.GetCell(7).ToString(),
                    E_2A_AmpPres = row.GetCell(8).ToString(),
                    E_3A_AmpPres = row.GetCell(9).ToString(),
                    E_Tot_Amp = row.GetCell(10).ToString(),
                    E_PreModif = row.GetCell(11).ToString(),
                    E_PreComp = row.GetCell(12).ToString(),
                    E_PreDev = row.GetCell(13).ToString(),
                    E_PreEjer = row.GetCell(14).ToString(),
                    E_PreErog = row.GetCell(15).ToString(),
                    E_PreCons = row.GetCell(16).ToString(),
                    E_PrePorEjer = row.GetCell(17).ToString(),
                    FechaCorte = row.GetCell(18).ToString(),
                });
            }

            return StatusCode(StatusCodes.Status200OK, list);
        }

        [HttpPost]
        public IActionResult SendPresupuestoData([FromForm] IFormFile ExcelFile)
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

            List<Presupuestoegreso> list = new List<Presupuestoegreso>();

            for (int i = 1; i <= rows; i++)
            {
                IRow row = ExcelSheet.GetRow(i);
                list.Add(new Presupuestoegreso
                {
                    Secretaria = row.GetCell(0).ToString(),
                    Direccion = row.GetCell(1).ToString(),
                    IPreEstim = row.GetCell(2).ToString(),
                    IPreMod = row.GetCell(3).ToString(),
                    IPreDev = row.GetCell(4).ToString(),
                    IPreReca = row.GetCell(5).ToString(),
                    EPreOrigApro = row.GetCell(6).ToString(),
                    E1aAmpPres = row.GetCell(7).ToString(),
                    E2aAmpPres = row.GetCell(8).ToString(),
                    E3aAmpPres = row.GetCell(9).ToString(),
                    ETotAmp = row.GetCell(10).ToString(),
                    EPreModif = row.GetCell(11).ToString(),
                    EPreComp = row.GetCell(12).ToString(),
                    EPreDev = row.GetCell(13).ToString(),
                    EPreEjer = row.GetCell(14).ToString(),
                    EPreErog = row.GetCell(15).ToString(),
                    EPreCons = row.GetCell(16).ToString(),
                    EPrePorEjer = row.GetCell(17).ToString(),
                    FechaCorte = row.GetCell(18).ToString(),
                });
            }

            _dbContext.BulkInsert(list);

            return StatusCode(StatusCodes.Status200OK, new { message = "Informacion almacenada en DB" });
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
