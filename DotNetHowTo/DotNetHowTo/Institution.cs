namespace AzureSearch.SDKHowTo
{
    using System;
    using System.Text;
    using Microsoft.Azure.Search;
    using Microsoft.Azure.Search.Models;
    using Newtonsoft.Json;

    public partial class Institution
    {
        [System.ComponentModel.DataAnnotations.Key]
        [IsFilterable]
        public string InstitutionID { get; set; }

        [IsSearchable, IsSortable]
        public string Name { get; set; }

        [IsSearchable]
        [Analyzer(AnalyzerName.AsString.FrLucene)]
        [JsonProperty("NPINumber")]
        public string NPINumber { get; set; }

        [IsSearchable, IsFilterable, IsSortable, IsFacetable]
        public DateTime LastUpdated { get; set; }

        [IsSearchable, IsFilterable, IsFacetable]
        public bool Deleted { get; set; }

        [IsFilterable, IsSortable, IsFacetable]
        public string SpecificName { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();

            if(!string.IsNullOrEmpty(InstitutionID))
                builder.AppendFormat($"InstitutionId: {InstitutionID}\n");

            if(!string.IsNullOrEmpty(Name))
                builder.AppendFormat($"Name: {Name}\n");

            if(!string.IsNullOrEmpty(NPINumber))
                builder.AppendFormat($"NPI Number: {NPINumber}\n");

            if(!string.IsNullOrEmpty(SpecificName))
                builder.AppendFormat($"Specific Name: {SpecificName}\n");

            if(LastUpdated != DateTime.MinValue)
                builder.AppendFormat($"Last Updated: {LastUpdated}\n");

            if(Deleted)
                builder.AppendFormat($"Deleted: {Deleted}");

            return builder.ToString();
        }
    }
}
