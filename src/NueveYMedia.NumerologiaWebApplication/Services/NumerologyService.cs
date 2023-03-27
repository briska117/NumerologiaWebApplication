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

        private List<NameSection> ProcessSectionName(List<NameSection> sections)
        {
            try
            {
                foreach(NameSection section in sections)
                {
                    section.Letters = GetLetters(section.NameString);
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
                    letterList.Add(letter);
                }

                return letterList;

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
    }
}
