using Autofac;
using TagCloud;
using TagCloud.Settings;

namespace GuiClient.Forms;

public class ResultForm : Form
{
	private readonly ILifetimeScope _lifetimeScope;

	public ResultForm(ILifetimeScope lifetimeScope, Form mainForm)
	{
		_lifetimeScope = lifetimeScope;

		using var scope = _lifetimeScope.BeginLifetimeScope();
		var imageSettingsProvider = scope.Resolve<IImageSettingsProvider>();

		Text = "Результат";
		Size = new Size(imageSettingsProvider.ImageSettings.Width, imageSettingsProvider.ImageSettings.Height + 70);
		FormBorderStyle = FormBorderStyle.FixedDialog;
		MaximizeBox = false;
		MinimizeBox = false;
		StartPosition = FormStartPosition.CenterScreen;

		var regenerateButton = new Button { Text = "Сгенерировать заново", Dock = DockStyle.Bottom, };
		regenerateButton.Click += (_, _) =>
		{
			mainForm.Show();
			Close();
		};

		ShowCloudImage();
		Controls.Add(regenerateButton);
	}

	private void ShowCloudImage()
	{
		_lifetimeScope.Resolve<App>().Run();
		var appSettingsProvider = _lifetimeScope.Resolve<IAppSettingsProvider>();
		var picture = new PictureBox
		{
			SizeMode = PictureBoxSizeMode.AutoSize,
			ImageLocation = appSettingsProvider.AppSettings.SavePath,
			Dock = DockStyle.Top,
		};
		picture.Load();
		Controls.Add(picture);
	}
}