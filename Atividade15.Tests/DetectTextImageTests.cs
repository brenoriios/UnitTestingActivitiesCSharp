using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using NSubstitute;

namespace Atividade15.Tests;

public class DetectTextImageTests
{
    private IRekognitionClientWrapper _rekognitionClient = Substitute.For<IRekognitionClientWrapper>();

    [Fact]
    public async void DetectTextLabelAsync_WithRekognitionClient_ShouldReturnDetectedText()
    {
        // Arrange
        var sourceImage = "data/img-example-for-aws-task.jpg";
        var resultFilePath = "data/detected_text_results.txt";
        var _sut = new DetectTextImage(sourceImage, _rekognitionClient);

        var textDetections = new List<TextDetection> {
            new TextDetection {
                DetectedText = "Sample text",
                Confidence = 99.0f,
                Id = 1,
                ParentId = 0,
                Type = TextTypes.LINE
            }
        };

        _rekognitionClient.DetectTextAsync(Arg.Any<DetectTextRequest>()).ReturnsForAnyArgs(new DetectTextResponse()
        {
            TextDetections = textDetections
        });

        // Act
        await _sut.DetectTextLabelAsync(resultFilePath);
        await _rekognitionClient.Received(1).DetectTextAsync(Arg.Any<DetectTextRequest>());
        var result = await File.ReadAllTextAsync(resultFilePath);

        // Assert
        Assert.Contains("Sample text", result);
        Assert.Contains("Confidence: 99", result);
        Assert.Contains("Id: 1", result);
        Assert.Contains("ParentId: 0", result);
        Assert.Contains("Type: LINE", result);
    }

    [Fact]
    public void SaveResultToTextFile_ShouldSaveResultToTextFile()
    {
        // Arrange
        var sourceImage = "data/img-example-for-aws-task.jpg";
        var resultFilePath = "data/detected_text_results.txt";
        var _sut = new DetectTextImage(sourceImage, _rekognitionClient);
        var textDetections = new List<TextDetection> {
            new TextDetection {
                DetectedText = "Sample text",
                Confidence = 99.0f,
                Id = 1,
                ParentId = 0,
                Type = TextTypes.LINE
            }
        };

        try
        {
            _sut.SaveResultToTextFile(textDetections, resultFilePath);
        }
        catch (Exception ex)
        {
            Assert.Fail("Expected no exception, but got: " + ex.Message);
        }
    }
}
