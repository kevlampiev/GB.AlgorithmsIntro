namespace GeekbrainsAlgorithmsIntro;

public interface ILesson
{
    int LessonNumber { get; set;  }
    string Descriptopn { get; set;  }
    void Run();

}