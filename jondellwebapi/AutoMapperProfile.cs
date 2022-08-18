using AutoMapper;
using jondellwebapi.Dtos.Balance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.Models;

namespace webapi
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Balance, GetBalanceDto>();
            CreateMap<AddBalanceDto, Balance>();

        }
    }
}
