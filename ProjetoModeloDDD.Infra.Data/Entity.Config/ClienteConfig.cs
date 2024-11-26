using ProjetoModeloDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.Infra.Data.Entity.Config
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(p => p.ClienteId);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(255);

            Property(c => c.Sobrenome)
                .IsRequired()
                .HasMaxLength(255);

            Property(c => c.Email)
               .IsRequired();
        }
    }
}
