using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Application.DTO.RequestDTO
{
    public class ProductUpdateDetailsRequestDTO
    {
        public int ProductId { get; set; }
        public IFormFile? Image { get; set; }
    }
}
