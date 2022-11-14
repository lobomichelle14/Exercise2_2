using System;
using System.Collections.Generic;
using SQLite;
using System.Text;

namespace Exercise2_2.Models
{
    public class Firma
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String imageencripted { get; set; }
        [MaxLength(45)]
        public String nombre { get; set; }
        [MaxLength(100)]
        public String desc{ get; set; }
        public byte[] img2
        {
            get { return Convert.FromBase64String(imageencripted); }//CONVERTIR IMPLICITAMENTE DESDE EL MODELO DE FIRMA A BYTE
        }
        public override string ToString()//sobreescribe el tostring para mostrarlo
        {
            return base.ToString();
        }
        public string nombreToString { get { return $"Nombre: {nombre}"; } }
        public string DescripToString { get { return $"Descripcion: {desc}"; } }
    }
}
