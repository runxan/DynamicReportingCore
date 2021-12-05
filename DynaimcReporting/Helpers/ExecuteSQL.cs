using DynaimcReporting.Context;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynaimcReporting.Helpers
{
    public class ExecuteSQL
    {
        //public static string Logging { get { return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; } }
        public static SelectList GetSelectList( string sqlQuery,string con)
        {
            DataTable dataTable = new DataTable();
        //    string connectionString =
        //ConfigurationSettings.AppSettings["ConnectionStrings"];
            using (SqlConnection connection =
                 new SqlConnection(con))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(
                    sqlQuery, connection);
                adapter.Fill(dataTable);
            }
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in dataTable.Rows)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    list.Add(new SelectListItem()
                    {
                        Text = row[i].ToString(),
                        Value = row[i].ToString()
                    });
                }

            }

            return new SelectList(list, "Value", "Text");
            //return dataTable;
        }

        public static DataTable GetDatatable(string sqlQuery, string con)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection =
                 new SqlConnection(con))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(
                    sqlQuery, connection);
                adapter.Fill(dataTable);
            }
            return dataTable;
        }
        public static string DataTableToJSONWithStringBuilder(DataTable table)
        {
            var JSONString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JSONString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JSONString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JSONString.Append("}");
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }
                JSONString.Append("]");
            }
            return JSONString.ToString();
        }
        public static string ConvertDataTableToHTML(DataTable dt)
        {
            string html = "<table id = 'grid' class='table table-striped table - bordered dt - responsive nowrap compact' width='100 % ' cellspacing='0'>";
            //add header row
            html += "<thead><tr>";
            for (int i = 0; i < dt.Columns.Count; i++)
                html += "<td>" + dt.Columns[i].ColumnName + "</td>";
            html += "</tr></thead><tbody>";
            //add rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                html += "<tr>";
                for (int j = 0; j < dt.Columns.Count; j++)
                    html += "<td>" + dt.Rows[i][j].ToString() + "</td>";
                html += "</tr>";
            }
            html += "</tbody></table>";
            return html;
        }
        public static string GetDataForChart(DataTable table)
        {
            var JSONString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JSONString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JSONString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JSONString.Append("}");
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }
                JSONString.Append("]");
            }
            return JSONString.ToString();
        }
    }
}
