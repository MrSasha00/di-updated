using TagCloud.CloudPainter;
using TagCloud.TagPositioner;
using TagCloud.WordCounter;
using TagCloud.WordsProcessing;

namespace TagCloud;

public class App(
	IWordPreprocessor wordPreprocessor,
	ITagCreator tagCreator,
	ICloudPainter cloudPainter,
	ITagPositioner tagPositioner)
{
	public void Run()
	{
		var words = wordPreprocessor.Process().ToArray();
		var tags = tagCreator.CreateTags(words);
		tags = tagPositioner.Position(tags);
		cloudPainter.Paint(tags.ToArray());
	}
}