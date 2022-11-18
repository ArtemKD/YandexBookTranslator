using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    internal class TranstationLog
    {
        #region Свойства
        #region Дата перевода - Date
        private DateTime _Date;
        public DateTime Date
        {
            get => _Date;
            set => _Date = value;
        }
        #endregion

        #region Список путей файлов для перевода - Files
        private List<string> _Files;
        public List<string> Files
        {
            get => _Files;
            set => _Files = value;
        }
        #endregion

        #region Путь сохранения переводов - SaveDir
        private string _SaveDir;
        public string SaveDir
        {
            get => _SaveDir;
            set => _SaveDir = value;
        }
        #endregion
        #endregion

        public TranstationLog(DateTime date, List<string> files, string saveDir)
        {
            _Date = date;
            _Files = files;
            _SaveDir = saveDir;
        }


    }
}
