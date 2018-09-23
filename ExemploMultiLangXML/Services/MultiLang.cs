using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace ExemploMultiLangXML.Services
{
    public class MultiLang : IMultiLang
    {

        private readonly IConfiguration _config;

        protected string _folderPath { get; set; }

        protected string _invalidEntry { get; set; }

        protected string _lang { get; set; }

        protected List<MultiLangEntry> _entries;

        public MultiLang(IConfiguration config)
        {
            _config = config;
            _folderPath = config["MultiLang_folderPath"];
            _invalidEntry = config["MultiLang_invalidEntry"];
            SetLang(config["MultiLang_defaultLang"]);
        }

        public void SetLang(string lang)
        {
            _lang = lang;
            LoadLang();
        }

        public void LoadLang()
        {
            _entries = JsonConvert.DeserializeObject<List<MultiLangEntry>>(File.ReadAllText($@"{_folderPath}\{_lang}.json"));
        }

        public string GetEntry(string key)
        {
            MultiLangEntry entry = _entries.Find(e => e.key == key);
            return entry?.text ?? _invalidEntry;
        }

    }
}
