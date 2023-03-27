namespace NueveYMedia.NumerologiaWebApplication.Modules
{
    public class PythagoreanConfiguration
    {
          public List<PythagoreanLetter> PythagoreanLetters { get; set; }  
    }
    public class PythagoreanLetter
    {
        public List<char> Letters { get; set; }
        public int Value { get; set; }
        public bool YIsVocal { get; set; }
    }
}
