using System.ComponentModel.DataAnnotations;

namespace Aplication_Programming_Interface_01.Entities
{
    public class Cuentas
    {
        [Key]
        public int CuentaId { get; set; }
        public int NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public int Estado { get; set; }
        public int ClienteId { get; set; }

        public Clientes? Cliente { get; set; }
    }
}
