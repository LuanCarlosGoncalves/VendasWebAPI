using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendasWebAPI.Entidades
{
    public class Cliente
    {
        [Key] //chave primaria -> id unico na tabela
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //adiciona o id automaticamente 
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string Endereco { get; set; }
       
        public string Profissao { get; internal set; }
    }
}
