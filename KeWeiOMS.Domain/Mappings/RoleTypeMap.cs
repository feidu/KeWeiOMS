﻿//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C)  , KeWei TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using FluentNHibernate.Mapping;

namespace KeWeiOMS.Domain
{

    /// <summary>
    /// RoleTypeMap
    /// 系统角色表
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
    public class RoleTypeMap : ClassMap<RoleType> 
    {
        public RoleTypeMap()
        {
            Table("Roles");
            Id(x => x.Id);
            Map(x => x.OrganizeId);
            Map(x => x.Code);
            Map(x => x.Realname);
            Map(x => x.SortCode);
            Map(x => x.DeletionStateCode);
            Map(x => x.Description);
            Map(x => x.CreateOn);
            Map(x => x.CreateBy);
        }
    }
}
