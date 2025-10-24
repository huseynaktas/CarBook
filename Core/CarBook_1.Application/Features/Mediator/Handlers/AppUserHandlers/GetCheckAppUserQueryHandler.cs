using CarBook.Domain.Entities;
using CarBook_1.Application.Features.Mediator.Queries.AppUserQueries;
using CarBook_1.Application.Features.Mediator.Results.AppUserResults;
using CarBook_1.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook_1.Application.Features.Mediator.Handlers.AppUserHandlers
{
    public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
    {
        private readonly IRepository<AppUser> _appUserRepository;
        private readonly IRepository<AppRole> _appRoleRepository;

        public GetCheckAppUserQueryHandler(IRepository<AppUser> appUserRepository, IRepository<AppRole> appRoleRepository)
        {
            _appUserRepository = appUserRepository;
            _appRoleRepository = appRoleRepository;
        }

        public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
        {
            var values = new GetCheckAppUserQueryResult();
            var user = await _appUserRepository.GetBayFilterAsync(x => x.UserName == request.UserName && x.Password == request.Password);
            if (user == null)
            {
                values.IsExist = false;
            }
            else
            {
                values.IsExist = true;
                values.UserName = user.UserName;
                values.Role = (await _appRoleRepository.GetBayFilterAsync(x => x.AppRoleId == user.AppRoleId)).AppRoleName;
                values.Id = user.AppUserId;
            }
            return values;
        }
    }
}
