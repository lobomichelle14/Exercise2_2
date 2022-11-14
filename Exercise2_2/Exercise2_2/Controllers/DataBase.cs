using Exercise2_2.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Exercise2_2.Controllers
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection db;
        public DataBase(String path)
        {
            db = new SQLiteAsyncConnection(path);
            db.CreateTableAsync<Firma>().Wait();
        }
        #region datos administrativos
        public Task<List<Firma>> GetListFirmas()
        {
            return db.Table<Firma>().ToListAsync();
        }

        public Task<Firma> GetFirmaporId(int id)
        {
            return db.Table<Firma>()
                .Where(i => i.id == id)
                .FirstOrDefaultAsync();
        }
        public Task<int> guardaFirma(Firma firma)
        {
            return firma.id != 0 ? db.UpdateAsync(firma) : db.InsertAsync(firma);
        }
        public Task<int> borrarFirma(Firma firma)
        {
            return db.DeleteAsync(firma);
        }
        #endregion
    }
}
