namespace NueveYMedia.NumerologiaWebApplication.Modules
{
    public class NumerologicalAnalysis
    {
        public List<NameSection> Names { get; set; }

        public int EssenceInitial { get { 
                int result = 0;
                foreach (var section in Names)
                {
                    Reduction reduction = section.VocalReductions.LastOrDefault();
                    if(reduction.ReductionNum == null)
                    {
                        result = result + reduction.InitialNum;
                    }
                    else
                    {
                        result = result + reduction.ReductionNum.Value;
                    }
                    
                }  
                return result;  
            } 
        }
        public int ImageInitial {
            get
            {
                int result = 0;
                foreach (var section in Names)
                {
                    Reduction reduction = section.ConsonantReductions.LastOrDefault();
                    if (reduction.ReductionNum == null)
                    {
                        result = result + reduction.InitialNum;
                    }
                    else
                    {
                        result = result + reduction.ReductionNum.Value;
                    }
                }
                return result;
            }
        }

        public List<Reduction> EssenceReductions { get; set; }
        public List<Reduction> ImageReductions { get; set; }

        public string EssenceReductionString { get {
                string result = EssenceInitial.ToString();
                foreach(var reduction in EssenceReductions)
                {
                    if (reduction.ReductionNum == null)
                    {
                        result = $"{result}  /  {reduction.InitialNum}";
                    }
                    else
                    {
                        result = $"{result}  /  {reduction.ReductionNum.Value}";
                    }
                }
                return result;
            } }
        public string ImageReductionString {
            get
            {
                string result = ImageInitial.ToString();
                foreach (var reduction in ImageReductions)
                {
                    if (reduction.ReductionNum == null)
                    {
                        result = result + " / " + reduction.InitialNum;
                    }
                    else
                    {
                        result = result + " / " + reduction.ReductionNum.Value;
                    }
                }
                return result;
            }
        }
    }
}
