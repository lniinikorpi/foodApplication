//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FoodApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FoodOfaDay
    {
        public int DayFoodID { get; set; }
        public int FoodID { get; set; }
        public System.DateTime Date { get; set; }
        public int MenuID { get; set; }
    
        public virtual WeekMenus WeekMenus { get; set; }
        public virtual Foods Foods { get; set; }
    }
}
