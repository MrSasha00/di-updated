using FluentAssertions;
using NSubstitute;
using TagCloud.WordsProcessing;
using TagCloud.WordsReader;

namespace TagCloudTests;

public class FileBoringWordsProviderTests : BaseTest<FIleBoringWordsProvider>
{
	[Test]
	public void GetWords_ShouldBeNotNullOrEmpty()
	{
		Mock<IWordsReader>()
			.Read(Arg.Any<string>())
			.Returns(["some", "word"]);

		var strings = Sut.GetWords();

		strings.Should().NotBeNullOrEmpty();
	}
}