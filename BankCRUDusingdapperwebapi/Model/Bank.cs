using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankCRUDusingdapperwebapi.Model
{
    [Table("tblBank")]
    public class Bank
    {
        [Key]
        public int bId { get; set; }
        public string bName { get; set; }
        public List<Customer> customerslist{ get; set; }
    }
}
