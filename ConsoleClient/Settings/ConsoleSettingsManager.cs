using TagCloud.Settings;

namespace ConsoleClient.Settings;

public class ConsoleSettingsManager(
	IImageSettingsProvider imageSettingsProvider,
	IAppSettingsProvider appSettingsProvider)
	: ISettingsManager
{
	public void Set(ConsoleSettings settings)
	{
		imageSettingsProvider.ImageSettings = new ImageSettings
		{
			Width = settings.Width,
			Height = settings.Height,
			BackgroundColor = settings.BackgroundColor,
			FontFamily = settings.FontFamily,
			FontSizeMax = settings.FontSizeMax,
			FontSizeMin = settings.FontSizeMin,
		};

		appSettingsProvider.AppSettings = new AppSettings
		{
			SourcePath = settings.SourcePath,
			SavePath = settings.SavePath,
			BoringWordsPath = settings.BoringWordsPath
		};
	}
}