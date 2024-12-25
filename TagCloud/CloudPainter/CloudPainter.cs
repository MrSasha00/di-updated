﻿using System.Drawing;
using TagCloud.Settings;
using TagCloud.WordCounter;

namespace TagCloud.CloudPainter;

public class CloudPainter(IImageSettingsProvider imageSettingsProvider, IAppSettingsProvider appSettingsProvider)
	: ICloudPainter
{
	public void Paint(Tag[] tags)
	{
		using var bitmap = new Bitmap(imageSettingsProvider.ImageSettings.Width,
			imageSettingsProvider.ImageSettings.Height);
		using var graphics = Graphics.FromImage(bitmap);
		graphics.Clear(Color.FromName(imageSettingsProvider.ImageSettings.BackgroundColor));
		var fontFamily = new FontFamily(imageSettingsProvider.ImageSettings.FontFamily);

		var random = new Random();
		foreach (var tag in tags)
		{
			var font = new Font(fontFamily, tag.Weight);
			var color = Color.FromArgb(random.Next(100, 256), random.Next(100, 256), random.Next(100, 256));
			using var brush = new SolidBrush(color);
			graphics.DrawString(tag.Word, font, brush, tag.Location);
		}

		bitmap.Save(appSettingsProvider.AppSettings.SavePath, System.Drawing.Imaging.ImageFormat.Png);
	}
}