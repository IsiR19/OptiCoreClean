using MediatR;
using OptiCore.Application.Models.Common;
using OptiCore.Application.Models.Companies;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptiCore.Application.Features.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommand : CompanyDto ,IRequest<UpdateCompanyCommand>
    {
        public int Id { get; set; }
    }
}
