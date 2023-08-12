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
using Autodesk.Revit.DB.Structure;

namespace MEP_Tools.Rebar
{
    public class ClsData_Rebar
    {
        public static IList<Element> List_Hook = new List<Element>();
        public static IList<Element> List_Linkcad = new List<Element>();
        public static IList<Element> List_Rebarshape = new List<Element>();
        public static IList<Element> List_Rebartype = new List<Element>();
    }
}
