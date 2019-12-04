using System;

namespace ORM
{
    public class SqlColumnAttribute : Attribute
    {
        public SqlColumnAttribute(string columnName, string dbType)
        {
            ColumnName = columnName;
            ColumnDbType = dbType;
            IsPrimaryKey = false;
            IsForeignKey = false;
        }

        public string ColumnName { get; set; }
        public string ColumnDbType { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsForeignKey { get; set; }
        public bool IsAutoIncrement { get; set; }
    }
}