using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RevitAPICreatingRibbon
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalApplication

    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "New Revit API traning";//переменная в которой имя нашей вкладки, записываем создание в ленте вкладки и кнопки
            application.CreateRibbonTab(tabName);//обрашаемся к Application (приложение), которое позволяет нам добавлять ленту, вкладку создали

            string utilsFolderPath = @"C:\Program Files\RevitAPITrainig\";//путь к папке с нашим приложением
            

            var panel = application.CreateRibbonPanel(tabName, "Трубы"); //создаем панель на этой вкладке

            //добавляем кнопку
            var button = new PushButtonData("Система", "Смена системы труб", 
                Path.Combine(utilsFolderPath, "RevitAPICreatingWPFProject.dll"), 
                "RevitAPICreatingWPFProject.Main");

            Uri uriImage = new Uri(@"C:\Program Files\RevitAPITrainig\Images\RevitAPITrainingUI_32.png", UriKind.Absolute);
            BitmapImage largeImage = new BitmapImage(uriImage);
            button.LargeImage = largeImage;

            //добавляем на панель через метод AddItem нашу кнопку
            panel.AddItem(button);


            return Result.Succeeded; 
        }
    }
}
