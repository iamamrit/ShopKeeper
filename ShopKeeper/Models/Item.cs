using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShopKeeper.Models
{
    public class Item
    {
        [Display(Name ="S.No:")]
        public int ItemId{ get; set; }        
       
        [Required]
        [Display(Name ="Name:")]        
        public string ItemName { get; set; }

        [Display(Name ="Total Items:")]
        public int TotalItem { get; set; }

        [Display(Name ="Price Per Item:")]
        public int PricePerItem { get; set; }




    }
}
