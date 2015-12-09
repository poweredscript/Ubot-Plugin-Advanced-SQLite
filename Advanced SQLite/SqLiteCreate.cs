using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using UBotPlugin;

namespace Advanced_SQLite
{
    class SqLiteCreate : IUBotCommand
    {
        public SqLiteCreate()
        {
            _parameters.Add(new UBotParameterDefinition("SQLite File Path", UBotType.String)
            {
                DefaultValue = SqLiteExchangeData.DatabaseFile
            });
            _parameters.Add(new UBotParameterDefinition("Query String", UBotType.String));
        }

        public void Execute(IUBotStudio ubotStudio, Dictionary<string, string> parameters)
        {
            
                var sqLiteFilePath = parameters["SQLite File Path"];
                var sqLiteQuery = parameters["Query String"];
                SqLiteExchangeData.DatabaseFile = sqLiteFilePath;
                if (!File.Exists(sqLiteFilePath))
                {
                    SQLiteConnection.CreateFile(sqLiteFilePath);
                }
                if (!String.IsNullOrEmpty(sqLiteQuery))
                {
                    var sqLite = new SqLiteDatabase(sqLiteFilePath);
                    SqLiteExchangeData.Debug = sqLite.ExecuteNonQuery(sqLiteQuery)
                        .ToString(CultureInfo.InvariantCulture);
                }
                SqLiteExchangeData.DatabaseFile = parameters["SQLite File Path"];
        }

        public string Category
        {
            get { return "Database Commands"; }
        }

        public string CommandName
        {
            get { return "sqlite create/query"; }
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