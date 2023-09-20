using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    public class BcenModel
    {
        public string clientCandidateId { get; set; }
        public string? examAuthorization { get; set; }
        public string? regId { get; set; }
        public string? series { get; set; }
        public string? examForm { get; set; }
        public string? examDate { get; set; }
        public string? rawScore { get; set; }
        public string? scaledScore { get; set; }
        public string? pfa { get; set; }
        public string? passingScore { get; set; }
        public string? correct { get; set; }
        public string? incorrect { get; set; }
        public string? skipped { get; set; }
        public string? unscored { get; set; }
        public string? sectionName { get; set; }
        public string? sectionTitle { get; set; }
        public string? ordinal { get; set; }
        public string? sectionScore { get; set; }
        public string? sectionCorrect { get; set; }
        public string? sectionIncorrect { get; set; }
        public string? possibleScore { get; set; }
        public string? maxScore { get; set; }
    }
}
