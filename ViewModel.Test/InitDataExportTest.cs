using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ViewModel.Test
{
    [TestClass]
    public class InitDataExportTest
    {
        [TestMethod]
        public void FilesShouldBeFound()
        {
            ViewModel view = new ViewModel();

            string[] files = view.InitFiles.Where(f => Path.GetExtension(f) == ".json").ToArray();

            Assert.IsNotNull(files);

        }

        [TestMethod]
        public void DatasShoudBe()
        {
            ViewModel view = new ViewModel();
            view.ExtractDatasFromInit();
            string json = view.Json;
            dynamic data = view.Datas;

            Assert.IsNotNull(data);
        }
    }
}
