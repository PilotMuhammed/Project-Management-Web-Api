using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.DTO.TagDtos
{
    public class CreateTagDto
    {
        public string? Name { get; set; }
    }

    public class TagDto
    {
        public int TagId { get; set; }
        public string? Name { get; set; }
    }
}

