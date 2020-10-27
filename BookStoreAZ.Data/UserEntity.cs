//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookStoreAZ.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserEntity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserEntity()
        {
            this.Orders = new HashSet<OrderEntity>();
        }
    
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public int RoleID { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Nullable<bool> Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderEntity> Orders { get; set; }
        public virtual RoleEntity Role { get; set; }
    }
}