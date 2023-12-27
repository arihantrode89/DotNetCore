
namespace Service
{
    public class ProductServiceImpl : IProduct
    {
        public List<string> Products()
        {
            
            var list = new List<string>()
            {
                "Nagpur","Pune","mumbai","Blr"
            };
            return list;
        }
    }
}
