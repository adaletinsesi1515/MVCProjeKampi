using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content
    {
        [Key]
        public int ContentID { get; set; }
        
        [StringLength(1000)]
        public string ContentValue { get; set; }
        public DateTime ContentDate { get; set; }

        
        //Başlık ile İçerik alanı ile ilişki yaptık
        public int HeadingID { get; set; }
        public virtual Heading Heading { get; set; }

        //İçerik ile Yazar alanını ilişki yaptık
        public int WriterID { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
