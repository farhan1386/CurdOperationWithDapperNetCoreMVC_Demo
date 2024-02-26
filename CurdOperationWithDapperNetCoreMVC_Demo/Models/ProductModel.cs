using System.ComponentModel.DataAnnotations;

namespace CurdOperationWithDapperNetCoreMVC_Demo.Models
{
    public class ProductModel
    {
        public Guid ProductId { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        [Display(Name = "Prodcut Description")]
        public string ProdcutDescription { get; set; }

        [Display(Name = "Create Date")]
        public DateTime? CreatedOn { get; set; }

        [Display(Name = "Update Date")]
        public DateTime? UpdateOn { get; set; }
    }
}
