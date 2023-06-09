﻿using NueveYMedia.NumerologiaWebApplication.Modules;

namespace NueveYMedia.NumerologiaWebApplication.Services
{
    public interface INumerologyService
    {
        public List<NameSection> GetNameSections(string name);

        public NumerologicalAnalysis GetNumerologicalAnalysis(List<NameSection> nameSections);
    }
}
