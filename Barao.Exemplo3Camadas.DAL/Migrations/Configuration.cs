namespace Barao.Exemplo3Camadas.DAL.Migrations
{
    using Barao.Exemplo3Camadas.DTO;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Barao.Exemplo3Camadas.DAL.Context.BaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Barao.Exemplo3Camadas.DAL.Context.BaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Clientes.AddOrUpdate(
              p => p.Nome,  //definie quando deve ocorrer insert ou update
              new ClienteDTO { Nome = "Administrador", SobreNome = "Modafoca", DataCadastro = DateTime.Now }, //registro
              new ClienteDTO { Nome = "Enéas", SobreNome = "Carneiro", DataCadastro = DateTime.Now } //registro
            );

        }
    }
}
