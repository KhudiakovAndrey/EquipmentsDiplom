using Equipments.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Equipments.WebAPI.Controllers
{
    public class DownloadController : Controller
    {
        public IActionResult Index()
        {
            XDocument xdoc = XDocument.Load("wwwroot/installers/installers.xml");

            var installers = from installer in xdoc.Descendants("installer")
                             select new Installer
                             {
                                 Version = installer.Element("version").Value.ToString(),
                                 Filename = installer.Element("filename").Value.ToString(),
                                 ReleaseDate = Convert.ToDateTime(installer.Element("releasedate").Value)
                             };

            return View(installers);
        }

        public IActionResult Download(string filename)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "installers", filename);

            if (System.IO.File.Exists(path))
            {
                return PhysicalFile(path, "application/octet-stream", filename);
            }
            else
            {
                return NotFound();
            }

        }
    }
}
