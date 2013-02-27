﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using KeWeiOMS.Domain;
using KeWeiOMS.NhibernateHelper;
using NHibernate;

namespace KeWeiOMS.Web.Controllers
{
    public class AccountController : BaseController
    {
        public ViewResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Platform(string Id)
        {
            List<object> list = new List<object>();
            if (Id == "1")
            {

                list.Add(new { id = "ALL", text = "ALL" });
            }

            foreach (string item in Enum.GetNames(typeof(PlatformEnum)))
            {
                list.Add(new { id = item, text = item });
            }
            return Json(list);
        }

        [HttpPost]
        public ActionResult AccountList(string id)
        {
            IList<AccountType> list1 = NSession.CreateQuery(" from AccountType where Platform=:p").SetString("p", id).List<AccountType>();
            List<object> list = new List<object>();
            list.Add(new { id = "ALL", text = "ALL" });
            foreach (var item in list1)
            {
                list.Add(new { id = item.Id, text = item.AccountName });
            }
            return Json(list);
        }

        [HttpPost]
        public JsonResult Create(AccountType obj)
        {
            try
            {
                NSession.SaveOrUpdate(obj);
                NSession.Flush();
            }
            catch (Exception ee)
            {
                return Json(new { errorMsg = "出错了" });
            }
            return Json(new { IsSuccess = "true" });
        }

        /// <summary>
        /// 根据Id获取
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public AccountType GetById(int Id)
        {
            AccountType obj = NSession.Get<AccountType>(Id);
            if (obj == null)
            {
                throw new Exception("返回实体为空");
            }
            else
            {
                return obj;
            }
        }

        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Edit(int id)
        {
            AccountType obj = GetById(id);
            return View(obj);
        }

        [HttpPost]
        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Edit(AccountType obj)
        {

            try
            {
                NSession.Update(obj);
                NSession.Flush();
            }
            catch (Exception ee)
            {
                return Json(new { errorMsg = "出错了" });
            }
            return Json(new { IsSuccess = "true" });

        }

        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(int id)
        {

            try
            {
                AccountType obj = GetById(id);
                NSession.Delete(obj);
                NSession.Flush();
            }
            catch (Exception ee)
            {
                return Json(new { errorMsg = "出错了" });
            }
            return Json(new { IsSuccess = "true" });
        }

        public JsonResult List(int page, int rows, string sort, string order, string search)
        {
            string orderby = " order by Id desc ";
            string where = "";
            if (!string.IsNullOrEmpty(sort) && !string.IsNullOrEmpty(order))
            {
                orderby = " order by " + sort + " " + order;
            }
            if (!string.IsNullOrEmpty(search))
            {
                where = Utilities.Resolve(search);
                if (where.Length > 0)
                {
                    where = " where " + where;
                }
            }
            IList<AccountType> objList = NSession.CreateQuery("from AccountType" + where + orderby)
                .SetFirstResult(rows * (page - 1))
                .SetMaxResults(rows * page)
                .List<AccountType>();
            object count = NSession.CreateQuery("select count(Id) from AccountType" + where).UniqueResult();
            return Json(new { total = count, rows = objList });
        }

        public JsonResult SelectList(int Id)
        {
            IList<AccountType> objList = NSession.CreateQuery("from AccountType").List<AccountType>();
            //获得这个类型的菜单权限
            List<PermissionScopeType> scopeList = NSession.CreateQuery("from PermissionScopeType where ResourceCategory=:p1 and ResourceId=:p2 and TargetCategory =:p3").SetString("p1", ResourceCategoryEnum.User.ToString()).SetInt32("p2", Id).SetString("p3", TargetCategoryEnum.Account.ToString()).List<PermissionScopeType>().ToList<PermissionScopeType>();
            List<SystemTree> tree = new List<SystemTree>(); ;
            SystemTree root = new SystemTree { id = "0", text = "所有账户" };
            foreach (string item in Enum.GetNames(typeof(PlatformEnum)))
            {
                List<AccountType> fooList = objList.Where(p => p.Platform == item).OrderByDescending(p => p.AccountName).ToList();
                List<SystemTree> tree2 = ConvertToTree(fooList, scopeList);

                if (scopeList.FindIndex(p => p.TargetId == Convert.ToInt32((PlatformEnum)Enum.Parse(typeof(PlatformEnum), item))) >= 0)
                {

                    root.children.Add(new SystemTree { id = Convert.ToInt32((PlatformEnum)Enum.Parse(typeof(PlatformEnum), item)).ToString(), text = item, children = tree2, @checked = true });
                }
                else
                {
                    root.children.Add(new SystemTree { id = Convert.ToInt32((PlatformEnum)Enum.Parse(typeof(PlatformEnum), item)).ToString(), text = item, children = tree2 });
                }
            }

            tree.Add(root);
            return Json(tree);
        }

        public List<SystemTree> ConvertToTree(List<AccountType> fooList, List<PermissionScopeType> scopeList = null)
        {
            List<SystemTree> tree = new List<SystemTree>();
            foreach (AccountType item in fooList)
            {
                if (scopeList == null)
                    tree.Add(new SystemTree { id = item.Id.ToString(), text = item.AccountName });
                else
                {
                    if (scopeList.FindIndex(p => p.TargetId == item.Id) >= 0)
                    {
                        tree.Add(new SystemTree { id = item.Id.ToString(), text = item.AccountName, @checked = true });
                    }
                    else
                    {
                        tree.Add(new SystemTree { id = item.Id.ToString(), text = item.AccountName });
                    }
                }
            }
            return tree;
        }
    }
}

