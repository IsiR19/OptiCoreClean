﻿using MediatR;
using OptiCore.Application.Models.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommand : CompanyDto, IRequest<CreateCompanyCommand>
    {
    }
}
