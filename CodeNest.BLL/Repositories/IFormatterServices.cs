using CodeNest.DTO.Models;
using CodeNest.DTO.Models.XmlModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CodeNest.BLL.Repositories
{
     public interface IFormatterServices 
    {
        #region 
        Task<ValidationDto> JsonValidate(string jsonObject); 
        #endregion
        Task<XmlValidation> XmlValidate(string XmlObject);

        

    }
}
