using System.Data;
using System.Collections.Generic;

namespace GetAllBooksAPI
{
       public static class DataSetHelper
        {
            public static DataSet ConvertToDataSet(List<Bookowner> bookOwners)
            {
                DataTable table = new DataTable("BookOwners");
                table.Columns.Add("Id", typeof(int));
                table.Columns.Add("OwnerName", typeof(string));
                table.Columns.Add("BookName", typeof(string));

                foreach (var owner in bookOwners)
                {
                    table.Rows.Add(owner.Id, owner.OwnerName, owner.BookName);
                }

                DataSet dataSet = new DataSet();
                dataSet.Tables.Add(table);
                return dataSet;
            }
        }
  



}
