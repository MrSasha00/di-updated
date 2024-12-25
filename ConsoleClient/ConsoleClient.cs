using CommandLine;
using ConsoleClient.Settings;
using TagCloud;
using TagCloud.Client;

namespace ConsoleClient;

public class ConsoleClient(App app, ISettingsManager settingsManager) : IClient
{
	public void Run()
	{
		Parser.Default.ParseArguments<ConsoleSettings>(Environment.GetCommandLineArgs())
			.WithParsed(settingsManager.Set);
		app.Run();
	}
}