using System.ComponentModel;

namespace StockServiceHttpClient.Models
{
    public class StockModel
    {
        [DisplayName("Current")]
        public double c { get; set; }
        [DisplayName("High")]

        public double h { get; set; }
        [DisplayName("Low")]

        public double l { get; set; }
        [DisplayName("Open")]

        public double o { get; set; }
        [DisplayName("Previous")]

        public double pc { get; set; }
    }
}
