﻿using System.Linq;
using CatFactory.ObjectRelationalMapping;
using CatFactory.ObjectRelationalMapping.Programmability;

namespace CatFactory.EntityFrameworkCore
{
    public static class DbObjectExtensions
    {
        public static string GetFullColumnName(this ITable table, Column column)
            => string.Join(".", new string[] { table.Schema, table.Name, column.Name });

        public static bool HasSameNameEnclosingType(this Column column, ITable table)
            => column.Name == table.Name;

        public static bool HasSameNameEnclosingType(this Column column, IView view)
            => column.Name == view.Name;

        public static bool HasSameNameEnclosingType(this Column column, TableFunction tableFunction)
            => column.Name == tableFunction.Name;

        public static string ResolveDatabaseType(this Database database, Parameter parameter)
        {
            var databaseTypeMap = database.DatabaseTypeMaps.FirstOrDefault(item => item.DatabaseType == parameter.Type);

            if (databaseTypeMap == null || databaseTypeMap.GetClrType() == null)
                return "object";

            return databaseTypeMap.AllowClrNullable ? string.Format("{0}?", databaseTypeMap.GetClrType().Name) : databaseTypeMap.GetClrType().Name;
        }

        public static string GetFullName(this Database database, IDbObject dbObject)
            => database.NamingConvention.GetObjectName(dbObject.Schema, dbObject.Name);
    }
}
