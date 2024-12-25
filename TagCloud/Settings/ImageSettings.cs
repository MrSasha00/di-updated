namespace TagCloud.Settings;

public class ImageSettings
{
	public int Width { get; init; }
	public int Height { get; init; }
	public string BackgroundColor { get; init; } = string.Empty;
	public string FontFamily { get; init; } = string.Empty;
	public int FontSizeMax { get; init; }
	public int FontSizeMin { get; init; }
}