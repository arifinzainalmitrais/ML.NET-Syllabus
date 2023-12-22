using Microsoft.ML.Data;

namespace matrix_factorization.ML.Objects
{
    public class MusicRating
    {
        [LoadColumn(0)]
        public float UserID { get; set; }

        [LoadColumn(1)]
        public float MusicID { get; set; }

        [LoadColumn(2)]
        public float Label { get; set; }
    }
}