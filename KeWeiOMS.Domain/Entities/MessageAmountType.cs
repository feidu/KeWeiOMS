﻿//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C)  , KeWei TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace KeWeiOMS.Domain
{

    /// <summary>
    /// MessageAmountType
    /// 邮件记事表
    /// 
    /// 修改纪录
    /// 
    ///  版本：1.0  创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name></name>
    /// <date></date>
    /// </author>
    /// </summary>
    public class MessageAmountType
    {
        /// <summary>
        /// 主键
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public virtual String OrderNo { get; set; }

        /// <summary>
        /// 平台订单号
        /// </summary>
        public virtual String OrderExNo { get; set; }

        /// <summary>
        /// 平台
        /// </summary>
        public virtual String Platform { get; set; }

        /// <summary>
        /// 账户
        /// </summary>
        public virtual String Account { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        public virtual DateTime GenerateOn { get; set; }

        /// <summary>
        /// 发货时间
        /// </summary>
        public virtual DateTime SendOn { get; set; }

        /// <summary>
        /// 金额
        /// </summary>
        public virtual double Amount { get; set; }

        /// <summary>
        /// 货币
        /// </summary>
        public virtual String CurrencyCode { get; set; }

        /// <summary>
        /// 商品SKU
        /// </summary>
        public virtual String SKU { get; set; }

        /// <summary>
        /// Qty
        /// </summary>
        public virtual int Qty { get; set; }

        /// <summary>
        /// 物流方式
        /// </summary>
        public virtual String LogisticsMode { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public virtual int Status { get; set; }

        /// <summary>
        /// 解决方式
        /// </summary>
        public virtual String Solution { get; set; }

        /// <summary>
        /// 退款金额
        /// </summary>
        public virtual double RefundAmount { get; set; }

        /// <summary>
        /// 添加人
        /// </summary>
        public virtual String CreateBy { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public virtual DateTime CreateOn { get; set; }

        /// <summary>
        /// 解决人
        /// </summary>
        public virtual String SolveBy { get; set; }

        /// <summary>
        /// 解决时间
        /// </summary>
        public virtual DateTime SloveOn { get; set; }

    }
}
