using System;
using System.Collections.Generic;
using System.Data.SQLite;
using UBotPlugin;

namespace Advanced_SQLite
{
    class SqLiteGetDataTable : IUBotCommand
    {
        public SqLiteGetDataTable()
        {
            _returnValue = "";
            _parameters.Add(new UBotParameterDefinition("SQLite File Path", UBotType.String)
            {
                DefaultValue = SqLiteExchangeData.DatabaseFile
            });
            _parameters.Add(new UBotParameterDefinition("Query String", UBotType.String));
            _parameters.Add(new UBotParameterDefinition("Table Report", UBotType.UBotTable));
        }

        public void Execute(IUBotStudio ubotStudio, Dictionary<string, string> parameters)
        {
            var sqLiteFilePath = parameters["SQLite File Path"];
            var sqLiteQuery = parameters["Query String"];
            var sqLite = new SqLiteDatabase(sqLiteFilePath);
            var dataTable = sqLite.GetDataTable(sqLiteQuery);
            var dataArray = new string[dataTable.Rows.Count, dataTable.Columns.Count];
            for (var i = 0; i < dataTable.Rows.Count; i++)
            {
                for (var j = 0; j < dataTable.Columns.Count; j++)
                {
                    dataArray[i, j] = dataTable.Rows[i][j].ToString();
                }
            }
            ubotStudio.SetTable(parameters["Table Report"], dataArray);
            _returnValue = "Success";
        }

        public string Category
        {
            get { return "Database Commands"; }
        }

        public string CommandName
        {
            get { return "sqlite get data table"; }
        }

        public UBotType ReturnValueType
        {
            get { return UBotType.String; }
        }

        private string _returnValue; //List<string>();

        public object ReturnValue
        {
            get { return _returnValue; }
        }

        public bool IsContainer
        {
            get { return false; }
        }

        private readonly List<UBotParameterDefinition> _parameters = new List<UBotParameterDefinition>();

        public IEnumerable<UBotParameterDefinition> ParameterDefinitions
        {
            get { return _parameters; }
        }

        public UBotVersion UBotVersion
        {
            get { return UBotVersion.Standard; }
        }
    }
}