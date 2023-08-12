using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.UI.Selection;
using System.Collections;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.DB.Plumbing;
using System.Windows.Input;
using MEP_Tools.Hanger;
using System.Windows.Forms;
using Application = Autodesk.Revit.ApplicationServices.Application;
using System.ComponentModel.Design;

namespace MEP_Tools.Rebar
{
    [Transaction(TransactionMode.Manual)]
   
    public class Create_Rebar : WPFData, IExternalCommand
    {
        public ICommand OKCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public Create_Rebar() 
        {

        }
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            clsdata.cmData = commandData;
            SingleData.Singleton.Instance = new SingleData.Singleton();
            SingleData.Singleton.Instance.RevitData.UIApplication = commandData.Application;
            Get_Hooktype(commandData);
            Get_Linkcad(commandData);
            Get_RebarShape(commandData);
            Get_RebarType(commandData);
            if (cls_Reg.Login == "Login")
            {
              
                SingleData.Singleton.Instance.WFData.InputWindow_Rebar.ShowDialog();           
                
            }
            return Result.Succeeded;
        }
        public void Get_Hooktype(ExternalCommandData commandData)
        {
          
                try
                {
                    UIApplication uiapp = commandData.Application;
                    UIDocument uidoc = uiapp.ActiveUIDocument;
                    Application app = uiapp.Application;
                    Document doc = uidoc.Document;

                    FilteredElementCollector collector = new FilteredElementCollector(doc);
                    ICollection<Element> Hooktype = collector.OfClass(typeof(RebarHookType)).ToElements();

                    foreach (var item in Hooktype)
                    {
                        SingleData.Singleton.Instance.RevitData.Transaction.Start();
                        ClsData_Rebar.List_Hook.Add(item);
                        SingleData.Singleton.Instance.RevitData.Transaction.Commit();
                    }
                }
                catch (Exception ex)
                {

                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    SingleData.Singleton.Instance.RevitData.Transaction.RollBack();
                }
            
           

           
        }

        public void Get_RebarShape(ExternalCommandData commandData)
        {

            try
            {
                UIApplication uiapp = commandData.Application;
                UIDocument uidoc = uiapp.ActiveUIDocument;
                Application app = uiapp.Application;
                Document doc = uidoc.Document;

                FilteredElementCollector collector = new FilteredElementCollector(doc);
                ICollection<Element> Rebarshape = collector.OfClass(typeof(RebarShape)).ToElements();

                foreach (var item in Rebarshape)
                {
                    SingleData.Singleton.Instance.RevitData.Transaction.Start();
                    ClsData_Rebar.List_Rebarshape.Add(item);
                    SingleData.Singleton.Instance.RevitData.Transaction.Commit();
                }
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.ToString());
                SingleData.Singleton.Instance.RevitData.Transaction.RollBack();
            }




        }

        public void Get_RebarType(ExternalCommandData commandData)
        {

            try
            {
                UIApplication uiapp = commandData.Application;
                UIDocument uidoc = uiapp.ActiveUIDocument;
                Application app = uiapp.Application;
                Document doc = uidoc.Document;

                FilteredElementCollector collector = new FilteredElementCollector(doc);
                ICollection<Element> Rebartype = collector.OfClass(typeof(RebarBarType)).ToElements();

                foreach (var item in Rebartype)
                {
                    SingleData.Singleton.Instance.RevitData.Transaction.Start();
                    ClsData_Rebar.List_Rebartype.Add(item);
                    SingleData.Singleton.Instance.RevitData.Transaction.Commit();
                }
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.ToString());
                SingleData.Singleton.Instance.RevitData.Transaction.RollBack();
            }




        }

        public void Get_Linkcad(ExternalCommandData commandData)
        {
          
                try
                {
                    UIApplication uiapp = commandData.Application;
                    UIDocument uidoc = uiapp.ActiveUIDocument;
                    Application app = uiapp.Application;
                    Document doc = uidoc.Document;

                    FilteredElementCollector collector = new FilteredElementCollector(doc);
                    ICollection<Element> linkcad = collector.OfClass(typeof(ImportInstance)).ToElements();

                    foreach (var item in linkcad)
                    {
                        SingleData.Singleton.Instance.RevitData.Transaction.Start();
                        ClsData_Rebar.List_Linkcad.Add(item);
                        SingleData.Singleton.Instance.RevitData.Transaction.Commit();
                    }
                }
                catch (Exception ex)
                {

                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                    SingleData.Singleton.Instance.RevitData.Transaction.RollBack();
                }
              
           
        }
    }
}
