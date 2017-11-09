using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace Hydra.Win.ExtensionScript.Data
{
    public class SQLiteClient: ISqlClient
    {
        public SQLiteConnection _Connection = null;

        public SQLiteClient(string connectionString)
        {
            _Connection = new SQLiteConnection(connectionString);
        }

        public void Open()
        {
            _Connection.Open();
        }
        
        /// <summary>
        /// Изпълнява select заявка
        /// </summary>
        /// <param name="linqQuery"></param>
        /// <returns></returns>
        public string ExecuteReader(LinqQueryModel linqQuery)
        {
            StringBuilder dataResult = new StringBuilder();
            using (SQLiteCommand command = new SQLiteCommand(_Connection))
            {
                command.CommandText = CreateSelectCommand(linqQuery);
                using( SQLiteDataReader dReader = command.ExecuteReader())
                {
                    string rowSeparate = "";
                    dataResult.Append("[");
                    while(dReader.Read())
                    {
                        dataResult.Append(rowSeparate + "{");
                        string cellSeparate = "";
                        for(int i = 0; i <  dReader.FieldCount; i++)
                        {
                            object cellValue = dReader.GetValue(i);
                            if( cellValue != null)
                            {
                                Type cellValueType = cellValue.GetType();
                                if (cellValueType == typeof(System.Int64))
                                {
                                    dataResult.AppendFormat("{0}\"{1}\":{2}", cellSeparate, dReader.GetName(i), cellValue);
                                }
                                else
                                {
                                    dataResult.AppendFormat("{0}\"{1}\":\"{2}\"", cellSeparate, dReader.GetName(i), cellValue);
                                }
                                cellSeparate = ",";
                            }                            
                        }
                        dataResult.Append("}");
                        rowSeparate = ",";
                    }
                    dataResult.Append("]");
                    dReader.Close();
                }
                
            }
            return dataResult.ToString();
        }

        /// <summary>
        /// Създава селекта в SQL формат
        /// </summary>
        /// <param name="linqQuery"></param>
        /// <returns></returns>
        private string CreateSelectCommand(LinqQueryModel linqQuery)
        {
            StringBuilder sbSql = new StringBuilder();
            // SELECT
            if (linqQuery.list.Count > 0)
            {
                sbSql.Append("SELECT ");
                LinqTableFieldModel field = linqQuery.list[0];
                sbSql.Append
                (
                    ((field.alias == null) ? "" : field.alias + ".") +
                    field.name +
                    ((field.text == null) ? "" : " AS " + field.text)
                );
                for (int i = 1; i < linqQuery.list.Count; i++)
                {
                    field = linqQuery.list[i];
                    sbSql.Append
                    (
                        ", " +
                        ((field.alias == null) ? "" : field.alias + ".") +
                        field.name +
                        ((field.text == null) ? "" : " AS " + field.text)
                    );
                }
            }
            // FROM
            if (linqQuery.from.Count > 0)
            {
                sbSql.Append(" FROM ");
                LinqTableModel table = linqQuery.from[0];
                sbSql.Append
                (
                    table.name +
                    ((table.alias == null) ? "" : " " + table.alias)
                );
                for (int i = 1; i < linqQuery.from.Count; i++)
                {
                    table = linqQuery.from[i];
                    sbSql.Append
                    (
                        ", " +
                        table.name +
                        ((table.alias == null) ? "" : " " + table.alias)
                    );
                }
            }
            // WHERE
            if (linqQuery.where.Count > 0)
            {
                sbSql.Append(" WHERE ");
                LinqConditionModel condition = linqQuery.where[0];
                sbSql.Append(CreateCondition(condition));
                for (int i = 1; i < linqQuery.where.Count; i++)
                {
                    condition = linqQuery.where[i];
                    sbSql.Append(" AND " + CreateCondition(condition));
                }
            }
            return sbSql.ToString();
        }

        /// <summary>
        /// Създава условието в SQL формат
        /// </summary>
        /// <param name="linqCondition"></param>
        /// <returns></returns>
        private string CreateCondition(LinqConditionModel linqCondition)
        {
            switch (linqCondition.condition)
            {
                case "=":
                    return
                        ((linqCondition.expr1.alias == null) ? "" : linqCondition.expr1.alias + ".") +
                        linqCondition.expr1.name +
                        " = " +
                        ((linqCondition.expr2.alias == null) ? "" : linqCondition.expr2.alias + ".") +
                        linqCondition.expr2.name;
                default:
                    return " 1 = 1 ";
            }
        }
    }
}
