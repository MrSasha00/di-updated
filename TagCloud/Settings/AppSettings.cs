namespace TagCloud.Settings;

public class AppSettings
{
	public string SourcePath { get; init; } = string.Empty;
	public string SavePath { get; init; } = "output.png";
	public string BoringWordsPath { get; init; } = string.Empty;
}