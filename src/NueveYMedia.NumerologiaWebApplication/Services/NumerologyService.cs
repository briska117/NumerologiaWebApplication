using Microsoft.Extensions.Options;
using NueveYMedia.NumerologiaWebApplication.Modules;

namespace NueveYMedia.NumerologiaWebApplication.Services
{
    public class NumerologyService : INumerologyService
    {
        private readonly PythagoreanConfiguration pythagoreanConfiguration;

        public NumerologyService(IConfiguration configuration)
        {
            this.pythagoreanConfiguration = configuration.GetSection("PythagoreanConfigurations").Get<PythagoreanConfiguration>();
        }
        public List<NameSection> GetNameSections(string FullName)
        {
            try
            {
                List<NameSection> sections = new List<NameSection>();
                sections = SeparateNames(FullName);
                sections = ProcessSectionName(sections);
                return sections;
            }
            catch (Exception ex)
            {

                throw new Exception("");
            }
        }

        private int GetValue(char character)
        {
            try
            {
                var x = this.pythagoreanConfiguration.PythagoreanLetters.FirstOrDefault(p => p.Letters.Contains(character));
                return x.Value;
            }
            catch (Exception ex)
            {

                throw new Exception("");
            }
        }

        private List<Reduction> GetReductions(int originalValue)
        {
            List<Reduction> reductions = new List<Reduction>();
            if (originalValue > 9)
            {
                reductions = ReductionProccess(originalValue);
            }
            else
            {
                reductions.Add(SetReduction(originalValue));  
            }
            return reductions;
        }

        private List<Reduction> ReductionProccess(int value)
        {
            List<Reduction> reductions = new List<Reduction>();
            bool ready = false;
            do {
                if (IsMasterNumber(value))
                {
                    reductions.Add(SetReduction(value));
                    ready = true;
                }
                else
                {
                    string numberToString = value.ToString();
                    int result = 0;
                    foreach(char c in numberToString)
                    {
                        result = result + int.Parse(c.ToString());   
                    }   
                    var reduction = SetReduction(value);
                    reduction.ReductionNum = result;
                    reductions.Add(reduction);
                    value = Convert.ToInt32(reduction.ReductionNum);
                    if (value < 10)
                    {
                        ready = true;   
                    }
                }
            } while (!ready);
            return reductions;
        }

        private bool IsMasterNumber(int value)
        {
            int[] masterNumbers = { 11, 22, 33, 44, 55 };
            return masterNumbers.Contains(value);
        }

        private Reduction SetReduction(int value)
        {

            Reduction reduction = new Reduction
            {
                InitialNum = value,
                ReductionNum = null
            };
            return reduction;
        }

        private List<NameSection> ProcessSectionName(List<NameSection> sections)
        {
            try
            {
                foreach(NameSection section in sections)
                {
                    section.Letters = GetLetters(section.NameString);
                    section.VocalReductions = GetReductions(section.TotalVocals);
                    section.ConsonantReductions = GetReductions(section.TotalConsonants);

                }    
                
                return sections;

            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }

        private List<Letter> GetLetters(string name)
        {
            try
            {
                List<Letter> letterList = new List<Letter>();
                foreach (char character in name)
                {
                    Letter letter = new Letter();
                    letter.Character = character;
                    letter.Value = GetValue(character);
                    letter.IsVocal = IsVocal(character);
                    letterList.Add(letter);

                }

                return letterList;

            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }

        private bool IsVocal(char cacharacter)
        {
            try
            {
                char[] vocals = {'A','E','I','O','U'};
                var isVocal =vocals.Contains(cacharacter); 
                return isVocal;
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }

        private List<NameSection> SeparateNames(string fullName)
        {
            try
            {
                List<NameSection> sections = new List<NameSection>();
                string[] separate = fullName.Split(' '); 
                foreach (string name in separate)
                {
                    NameSection nameSection = new NameSection();
                    nameSection.NameString = name;  
                    sections.Add(nameSection);
                }  
                return sections;

            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }

        public NumerologicalAnalysis GetNumerologicalAnalysis(List<NameSection> nameSections)
        {
            NumerologicalAnalysis numerologicalAnalysis = new NumerologicalAnalysis();
            numerologicalAnalysis.Names = nameSections;
            numerologicalAnalysis.EssenceReductions = GetReductions(numerologicalAnalysis.EssenceInitial);
            numerologicalAnalysis.ImageReductions = GetReductions(numerologicalAnalysis.ImageInitial);
            return numerologicalAnalysis;   
        }
    }
}
