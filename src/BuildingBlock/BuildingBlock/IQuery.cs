﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BuildingBlock
{
    public interface IQuery: IQuery<Unit>
    {

    }
    public interface IQuery<out TResponse> :IRequest<TResponse>
        where TResponse: notnull
    {
    }
}