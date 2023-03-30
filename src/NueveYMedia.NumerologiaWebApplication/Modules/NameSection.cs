namespace NueveYMedia.NumerologiaWebApplication.Modules
{
    public class NameSection
    {
        public string NameString { get; set; }
        public List<Letter> Letters { get; set; }

        public int TotalLeatters { get { return Letters.Count; } }
        public int TotalConsonants
        { get { 
                int total = 0;
                foreach (Letter letter in Letters.Where(l=>l.IsVocal==false).ToList()) { 
                    total=total+ letter.Value;   
                }
                return total; 
            } }

        public int TotalVocals
        {
            get
            {
                int total = 0;
                foreach (Letter letter in Letters.Where(l => l.IsVocal).ToList())
                {
                    total = total + letter.Value;
                }
                return total;
            }
        } 
        public List<Reduction> VocalReductions { get; set; }
        public List<Reduction> ConsonantReductions { get; set; }
        public bool Warning { get; set; }   
    }
}
