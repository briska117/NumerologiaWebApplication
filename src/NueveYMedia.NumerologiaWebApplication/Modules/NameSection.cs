namespace NueveYMedia.NumerologiaWebApplication.Modules
{
    public class NameSection
    {
        public string NameString { get; set; }
        public List<Letter> Letters { get; set; }

        public int TotalLeatters { get { return Letters.Count; } }
        public int TotalValue { get { 
                int total = 0;
                foreach (Letter letter in Letters) { 
                    total=total+ letter.Value;   
                }
                return total; 
            } }
        public bool Warning { get; set; }   
    }
}
