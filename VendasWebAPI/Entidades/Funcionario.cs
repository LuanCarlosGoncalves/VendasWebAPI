using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VendasWebAPI.Entidades
{
    public class Funcionario
    {
        [Key] //chave primaria -> id unico na tabela
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //adiciona o id automaticamente 
        public int Id { get; set; }  

        public string Nome { get; set; }

        public string Profissao { get; set; }   


    }
}
