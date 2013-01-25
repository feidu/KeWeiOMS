﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeWeiOMS.Web
{
    public enum OrderStatusEnum
    {
        待处理 = 0,
        已处理 = 1,
        待拣货 = 2,
        待出库 = 3,
        待包装 = 4,
        待发货 = 5,
        已发货 = 6,
        已完成 = 7
    }

    public enum PlatformEnum
    {
        SMT,
        Ebay,
        Amazon,
        B2C,
        Gmarket,
        LT
    }


}