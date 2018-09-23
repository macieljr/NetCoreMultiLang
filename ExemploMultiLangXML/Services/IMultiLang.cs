using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploMultiLangXML.Services
{
    public interface IMultiLang
    {
        void SetLang(string lang);
        string GetEntry(string entryID); 
    }
}
