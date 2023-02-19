﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Wrapper
{
    public class PagedResponse<T> : ServiceResponse<T>
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public PagedResponse(T value) : base(value)
        {

        }
        public PagedResponse(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}