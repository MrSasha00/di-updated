using TagCloud.WordCounter;

namespace TagCloud.CloudPainter;

public interface ICloudPainter
{
	void Paint(Tag[] tags);
}