﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Application.Features.CQRS.Commands.ContactCommands
{
    public class RemoveContactCommand
    {
        public int Id { get; set; }

        public RemoveContactCommand(int id)
        {
            Id = id;
        }
    }
}
