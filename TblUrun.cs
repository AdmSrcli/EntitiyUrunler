//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityUrunler
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblUrun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblUrun()
        {
            this.TblSatis = new HashSet<TblSatis>();
        }
    
        public int UrunId { get; set; }
        public string UrunAd { get; set; }
        public string Marka { get; set; }
        public Nullable<int> Stok { get; set; }
        public Nullable<decimal> Fiyat { get; set; }
        public Nullable<bool> Durum { get; set; }
        public Nullable<int> KategoriId { get; set; }
    
        public virtual TblKategori TblKategori { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblSatis> TblSatis { get; set; }
    }
}