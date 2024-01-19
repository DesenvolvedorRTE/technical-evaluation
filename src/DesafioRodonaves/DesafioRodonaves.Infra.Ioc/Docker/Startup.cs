using Docker.DotNet;
using Docker.DotNet.Models;

namespace DesafioRodonaves.Infra.Ioc.Docker
{
    internal static class Startup
    {
        internal static async Task StartPostgresContainer()
        {
            try
            {
                using (var client = new DockerClientConfiguration(new Uri("unix:///var/run/docker.sock")).CreateClient())
                {
                    var containers = await client.Containers.ListContainersAsync(new ContainersListParameters { All = true });
                    var postgresContainer = containers.FirstOrDefault(c => c.Names.Contains("/DesafioRodanaves"));

                    if (postgresContainer != null)
                    {
                        Console.WriteLine("O contêiner já existe. Iniciando...");
                        await client.Containers.StartContainerAsync(postgresContainer.ID, new ContainerStartParameters());
                    }
                    else
                    {
                        Console.WriteLine("O contêiner não existe. Criando e iniciando...");
                        var createdContainer = await client.Containers.CreateContainerAsync(new CreateContainerParameters
                        {
                            Name = "DesafioRodanaves",
                            Image = "postgres:latest",
                            Env = new[] { "POSTGRES_USER=usuario", "POSTGRES_PASSWORD=senha", "POSTGRES_DB=nomedobanco" },
                            ExposedPorts = new Dictionary<string, EmptyStruct> { ["5432"] = new EmptyStruct() },
                            HostConfig = new HostConfig
                            {
                                PortBindings = new Dictionary<string, IList<PortBinding>> { ["5432"] = new List<PortBinding> { new PortBinding { HostPort = "5434" } } }
                            },
                            Volumes = new Dictionary<string, EmptyStruct> { ["/var/lib/postgresql/data"] = new EmptyStruct() }
                        });

                        Console.WriteLine("Contêiner criado com sucesso. Iniciando...");
                        await client.Containers.StartContainerAsync(createdContainer.ID, new ContainerStartParameters());
                    }

                    // Aguardar a inicialização completa do PostgreSQL se necessário
                    //await WaitForPostgresToBeReady(client);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao interagir com o Docker: {ex.Message}");
                // Adicione lógica adicional para tratamento de exceções se necessário
            }
        }
    }
}