using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.Entity.Config
{
    public class ProdutoConfig :EntityTypeConfiguration<Produto>
    {
          public ProdutoConfig() {
            HasKey(p => p.ProdutoId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(255);

            Property(c => c.Valor)
                .IsRequired();


            HasRequired(p => p.Cliente)
                .WithMany()
                .HasForeignKey(c => c.ClienteId);

        }
    }
}
