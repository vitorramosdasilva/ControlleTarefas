using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarefasTemp.Models
{
    [Table("tarefaitem")]
    public partial class Tarefaitem
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("estacompleta")]
        public bool? Estacompleta { get; set; }
        [Column("nome", TypeName = "character varying")]
        public string Nome { get; set; }
        [Column("dataconclusao", TypeName = "date")]
        public DateTime? Dataconclusao { get; set; }
    }
}
