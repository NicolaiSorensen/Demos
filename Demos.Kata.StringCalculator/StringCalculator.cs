namespace Demos.Katas
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            return int.TryParse(numbers, out var result) ? result : 0;
        }
    }
}
