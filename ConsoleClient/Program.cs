using Autofac;
using ConsoleClient.Settings;
using TagCloud;
using TagCloud.Client;

namespace ConsoleClient;

class Program
{
	static void Main()
	{
		var builder = new ContainerBuilder();
		builder.RegisterModule(new TagCloudModule());
		builder.RegisterType<ConsoleClient>().As<IClient>();
		builder.RegisterType<ConsoleSettingsManager>().As<ISettingsManager>();
		var container = builder.Build();
		var app = container.Resolve<IClient>();

		app.Run();
	}
}