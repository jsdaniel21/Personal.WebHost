using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLogic.Interfaces;
using BussinessLogic.BussinessLogic;
using Personal.Models;
using System.Web.Security;
using Personal.ViewModels;
using BussinessEntity;
using Personal.Interfaces;
using BussinessLogic;

namespace Personal.WebHost.Controllers
{
    public class ReportsController : Controller
    {
        private IRptPersonalRepository _IRptPersonalRepository;

        public ReportsController()
        {
            _IRptPersonalRepository = new personaBL();
        }
        public ActionResult _OptionsPrintDialog()
        {
            return PartialView("_OptionsPrintDialog");
        }
        public ActionResult rptPersonal(string typeFormat, int iCodigoTipoEmpleado = 0, int iCodigoTipoModalidad = 0, int iCodigoInstitucion = 0, string vCodigoGradoMilitar = "", int iCodigoSituacionMilitar = 0, int iCodigoInstancia = 0)
        {
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Value = _IRptPersonalRepository.rptListarPersonal(iCodigoTipoEmpleado, iCodigoTipoModalidad, iCodigoInstitucion, vCodigoGradoMilitar, iCodigoSituacionMilitar, iCodigoInstancia);
            reportDataSource.Name = "DataSet1";

            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Report/rptPersonal.rdlc");
            localReport.DataSources.Add(reportDataSource);
            localReport.SetParameters(new ReportParameter[] { new ReportParameter("tituloPersonal", "Todos los tribunales") });



            string reportType = typeFormat;
            string mimeType;
            string encoding;
            string fileNameExtension;
            string deviceInfo = "<DeviceInfo>" +
              "  <OutputFormat>emf</OutputFormat>" +
              "  <PageWidth>8.5in</PageWidth>" +
              "  <PageHeight>11in</PageHeight>" +
              "  <MarginTop>0.0in</MarginTop>" +
              "  <MarginLeft>0in</MarginLeft>" +
              "  <MarginRight>0in</MarginRight>" +
              "  <MarginBottom>0.5in</MarginBottom>" +
              "  <Orientation>Landscape</Orientation>" +
              "</DeviceInfo>";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = localReport.Render("pdf", deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            return File(renderedBytes, "application/pdf");
        }

        public ActionResult ViewPdf()
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Report/ViewPdf.rdlc");

            string reportType = "pdf";
            string mimeType;
            string encoding;
            string fileNameExtension;
            string deviceInfo = "<DeviceInfo>" +
              "  <OutputFormat>jpeg</OutputFormat>" +
              "  <PageWidth>8.5in</PageWidth>" +
              "  <PageHeight>11in</PageHeight>" +
              "  <MarginTop>0.5in</MarginTop>" +
              "  <MarginLeft>1in</MarginLeft>" +
              "  <MarginRight>1in</MarginRight>" +
              "  <MarginBottom>0.5in</MarginBottom>" +
              "</DeviceInfo>";
            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = localReport.Render(reportType, deviceInfo, out mimeType, out encoding, out fileNameExtension, out streams, out warnings);
            return File(renderedBytes, "application/pdf");
        }
    }
}
