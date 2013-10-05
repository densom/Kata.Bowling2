namespace Kata.Bowling2
{
    public interface IFrame
    {
        int? Score();
        bool IsStrike();
        bool IsSpare();
        void AddBonusBall(int pins);
        int FrameNumber { get; }
        bool IsComplete { get; }
        void RecordThrow(int pins);
    }
}