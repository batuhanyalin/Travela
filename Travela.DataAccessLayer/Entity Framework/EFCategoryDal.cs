using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travela.DataAccessLayer.Abstract;
using Travela.DataAccessLayer.Context;
using Travela.DataAccessLayer.Repositories;
using Travela.EntityLayer.Concrete;

namespace Travela.DataAccessLayer.Entity_Framework
{
    public class EFCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EFCategoryDal(TravelaContext context) : base(context) //GenericRepository içinde TravelaContext i new olarak değil field olarak çağırdığımız için burada yapıcı metot oluşturmamız gerekiyor. base(context) ibaresi ise: new yapılmadan context direkt olarak çağırılabiliyor.
        {
         
        }
    }
}
