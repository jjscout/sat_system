using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace sat_system
{
    /*abstract class CyberFuncBaseAbstr
    {

    }
    class CyberFuncBase
    {

    }*/
    abstract class absResultSearch
    {
        public abstract string CyberFunc(CyberParams Params);
    }
    class ResultSearch: absResultSearch
    {
        //public LinkedList<string> text;
        public ResultSearch()
        {
            //text = new LinkedList<string>();
        }
        //public virtual void AddString(string txt)
        //{
        //    text.AddLast(txt);
        //}

        public override string CyberFunc(CyberParams Params)
        {
            return "";
        }

    }
    abstract class CyberFuncClass : ResultSearch
    {
        protected absResultSearch base_component = null;
        public override string CyberFunc(CyberParams Params)
        {
            if (base_component != null)
            {
                return base_component.CyberFunc(Params);
            }
            return "";
        }
        //public override void AddString(string txt)
        //{
        //    base.AddString(txt);
        //}
    }

    class CyberSearchFileDec: CyberFuncClass
    {
        
        public CyberSearchFileDec(absResultSearch basec)
        {
            this.base_component = basec;
        }
        public override string CyberFunc(CyberParams Params)
        {
            string cont = "No file";
            if (File.Exists(Params.Path))
            {
                string fileContent = File.ReadAllText(Params.Path);
                cont = Params.Name + " found at: " + fileContent.IndexOf(Params.Name).ToString();
                
            }
            
            return cont + "\n" + base_component.CyberFunc(Params);

        }
    }
    class CyberSearchURLDec : CyberFuncClass
    {
        public CyberSearchURLDec(absResultSearch basec)
        {
            this.base_component = basec;
        }
        public override string CyberFunc(CyberParams Params)
        {
            return "this url search"
                + "\n" + base_component.CyberFunc(Params);
        }
    }

    
}
