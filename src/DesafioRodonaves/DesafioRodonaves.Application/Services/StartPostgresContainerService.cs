using Docker.DotNet;
using Docker.DotNet.Models;


namespace DesafioRodonaves.Application.Services
{
    public static class StartPostgresContainerService
    {
        public static async Task StartPostgresContainer()
        {
            try
            {
                using (var client = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine")).CreateClient())
                {
                    // Lista os container ativos
                    var containers = await client.Containers.ListContainersAsync(new ContainersListParameters { All = true });

                    // Busca pelo container chamado DesafioRodanaves
                    var postgresContainer = containers.FirstOrDefault(c => c.Names.Contains("/DesafioRodanaves"));

                    // Verifica se o cointer existe se existe ele somente inicia o container se não ele cria um novo conateiner
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
                            Env = new[] { "POSTGRES_USER=postgres", "POSTGRES_PASSWORD=12345", "POSTGRES_DB=DesafioRodonaves" },
                            ExposedPorts = new Dictionary<string, EmptyStruct> { ["5434"] = new EmptyStruct() },
                            HostConfig = new HostConfig
                            {
                                PortBindings = new Dictionary<string, IList<PortBinding>> { ["5434"] = new List<PortBinding> { new PortBinding { HostPort = "5434" } } }
                            },
                            Volumes = new Dictionary<string, EmptyStruct> { ["/var/lib/postgresql/data"] = new EmptyStruct() }
                        });

                        // inicia o container criado
                        Console.WriteLine("Contêiner criado com sucesso. Iniciando...");
                        await client.Containers.StartContainerAsync(createdContainer.ID, new ContainerStartParameters());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao interagir com o Docker: {ex.Message}");
               
            }
        }
    }
}