﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Application.Features.CQRS.Commands.BrandCommands
{
    public class UpdateBrandCommand
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
    }
}
