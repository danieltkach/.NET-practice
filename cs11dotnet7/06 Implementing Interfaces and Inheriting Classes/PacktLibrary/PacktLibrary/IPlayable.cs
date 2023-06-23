namespace Packt.Shared;

public interface IPlayable
{
    void Play();
    void Pause();
    // method with default implementation
    void Stop()
    {
        WriteLine("Default implementation of Stop()");
    }
}