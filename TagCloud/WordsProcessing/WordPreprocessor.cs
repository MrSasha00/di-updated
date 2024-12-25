using TagCloud.Settings;
using TagCloud.WordsReader;

namespace TagCloud.WordsProcessing;

public class WordPreprocessor(
	IBoringWordsProvider boringWordsProvider,
	IWordsReader wordsReader,
	IAppSettingsProvider appSettingsProvider)
	: IWordPreprocessor
{
	public string[] Process()
	{
		var boringWords = boringWordsProvider.GetWords();
		return wordsReader.Read(appSettingsProvider.AppSettings.SourcePath)
			.Select(x => x.ToLower())
			.Where(x => !boringWords.Contains(x))
			.ToArray();
	}
}