namespace NueveYMedia.NumerologiaWebApplication.Modules
{
    public class Reduction
    {
        public int InitialNum { get; set; } 
        public int? ReductionNum { get; set; }   

        public string ReductionFormat { get
            {
                if(ReductionNum == null) { 
                    return $"{InitialNum}"; 
                } else
                {
                    return $"{InitialNum}  /  {ReductionNum}";
                }   
                
            } }
    }
}
