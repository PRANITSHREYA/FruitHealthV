using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FruitHealth.Models
{
    public class FruitHealthPredictionResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Specifies that the database generates the value for this property
        public int Id { get; set; }
        public required string PredictedLabel { get; set; }
        public required string Score { get; set; }
        public required string ImageFilePath { get; set; }
        public required DateTime PredictedDateTime { get; set; }
    }
}
