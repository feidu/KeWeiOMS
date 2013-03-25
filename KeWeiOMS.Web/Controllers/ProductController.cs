﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using KeWeiOMS.Domain;
using KeWeiOMS.NhibernateHelper;
using NHibernate;

namespace KeWeiOMS.Web.Controllers
{
    public class ProductController : BaseController
    {
        public ViewResult Index()
        {
            return View();
        }

        public ActionResult ProductProfits()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult SKUCodeIndex()
        {
            return View();
        }

        public ActionResult ImportPic()
        {
            return View();
        }

        public ActionResult ImportProduct()
        {
            return View();
        }

        public ActionResult WarningPurchaseList()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WarningList(string order, string sort)
        {
            List<PurchaseData> list = new List<PurchaseData>();
            IList<WarehouseStockType> stocks = new List<WarehouseStockType>();
            IList<PurchasePlanType> plans = new List<PurchasePlanType>();
            IList<ProductType> products =
                NSession.CreateQuery(
                   @" From ProductType p where (
(round((SevenDay/7*0.5+Fifteen/15*0.3+ThirtyDay/30*0.2),0)*5)>(select SUM(Qty) from WarehouseStockType where SKU= p.SKU)
Or (select SUM(Qty) from WarehouseStockType where SKU= p.SKU)=0
Or SKU in(select SKU from OrderProductType where OId In(select Id from OrderType where IsOutOfStock=1 and  Status<>'作废订单'))
)and IsScan=1 and SKU not in('9613',
'9624',
'9625',
'9626',
'9627',
'9628',
'9636',
'9637',
'9640',
'9641',
'00PK9660',
'9665',
'00WE9660',
'9666',
'9671',
'9672',
'9673',
'9674',
'9675',
'9676',
'9689',
'9755',
'9775',
'00RD9787',
'00WE9787',
'00LU9787',
'00PK9787',
'00BK9788',
'00PK9788',
'00BK9789',
'00PK9789',
'00WE9789',
'00BK9790',
'00RE9790',
'9806',
'9716',
'9817',
'9818',
'9819',
'9820',
'9822',
'9828',
'00BK9842',
'00RD9842',
'9865',
'9878',
'9879',
'9886',
'9890',
'9891',
'9892',
'9893',
'9894',
'9895',
'9896',
'9897',
'9898',
'9990',
'9380',
'9532',
'9535',
'9599',
'9600',
'9601',
'9602',
'9610',
'9611',
'9612',
'8301',
'9570',
'9573',
'9576',
'9579',
'9598',
'8023',
'8027',
'8079',
'8204',
'00OE8220',
'8237',
'00WE8346',
'00BE8347',
'00WE8347',
'00RE8347',
'00PK8347',
'00GN8347',
'00YW8348',
'00PE8348',
'00WE8348',
'00BE8348',
'00CE8348',
'00GN8348',
'00BK8348',
'00PK8348',
'00RE8348',
'8356',
'8391',
'00YW8506',
'85BE5154',
'85BK5154',
'85GN5154',
'85PK5154',
'85YW5154',
'90BE5154',
'90BK5154',
'90PK5154',
'95BE5154',
'95BK5154',
'95PK5154',
'95YW5154',
'00WE5190',
'00BE5192',
'27BE5194',
'27YW5194',
'30YW5194',
'02CE5198',
'03BE5198',
'5199',
'48WE5208',
'52BE5208',
'52BK5208',
'54BK5208',
'54GY5208',
'54WE5208',
'04BK5210',
'3015215',
'3025215',
'3035215',
'3045215',
'3055215',
'3065215',
'3075215',
'3085215',
'3095215',
'3105215',
'3115215',
'3125215',
'4015215',
'4025215',
'4035215',
'4045215',
'4055215',
'4065215',
'4075215',
'4085215',
'4095215',
'4105215',
'4115215',
'4125215',
'5015215',
'5025215',
'5035215',
'5045215',
'5055215',
'5065215',
'5075215',
'5085215',
'5095215',
'5105215',
'5115215',
'5125215',
'32005221',
'35005221',
'02GY5223',
'02WE5223',
'03WE5223',
'04BK5223',
'04BN5223',
'06BN5223',
'06WE5223',
'1005227',
'3005227',
'02BE5229',
'02BK5229',
'02BN5229',
'02GN5229',
'02GY5229',
'02OE5229',
'02PE5229',
'02PK5229',
'02RD5229',
'02WE5229',
'02YW5229',
'03BE5229',
'03BK5229',
'03BN5229',
'03GN5229',
'03GY5229',
'03OE5229',
'03PE5229',
'03PK5229',
'03RD5229',
'03WE5229',
'03YW5229',
'04BE5229',
'04BK5229',
'04BN5229',
'04GN5229',
'04GY5229',
'04OE5229',
'04PE5229',
'04PK5229',
'04RD5229',
'04WE5229',
'04YW5229',
'05BE5229',
'05BK5229',
'05BN5229',
'05GN5229',
'05GY5229',
'05OE5229',
'05PE5229',
'05PK5229',
'05RD5229',
'05WE5229',
'05YW5229',
'00YW5231',
'00BK5292',
'00GY5292',
'5120',
'3005267',
'4005285',
'3005300',
'02RD8779',
'04RD8779',
'05RD8779',
'05BE8779',
'1008212',
'2008212',
'4008212',
'5008212',
'7008212',
'1008191',
'00BK3120',
'00BE9662',
'00BK9662',
'00PK9662',
'00WE9662',
'03GY5308',
'02BK5308',
'YSP0082',
'0A003127',
'0B003127',
'0C003127',
'0D003127',
'0E003127',
'0F003127',
'0H003127',
'7025',
'00CL7009',
'0A005000',
'0B005000',
'0C005000',
'0D005000',
'0E005000',
'5005',
'5006',
'5007',
'5008',
'5010',
'5022',
'5023',
'5025',
'5026',
'5027',
'5028',
'5030',
'x013',
'4011',
'4012',
'4015',
'4014',
'4018',
'4019',
'4022',
'4023',
'9664',
'x030')")
                    .List<ProductType>();
            string ids = "";
            foreach (var p in products)
            {
                ids += "'" + p.SKU + "',";
            }

            stocks =
                NSession.CreateQuery("from WarehouseStockType where SKU in(" + ids.Trim(',') + ")").List<WarehouseStockType>();
            plans = NSession.CreateQuery("from PurchasePlanType where Status not in('异常','已收到')  and SKU in(" + ids.Trim(',') + ")").List<PurchasePlanType>();

            IList<OrderProductType> orderProducts = NSession.CreateQuery("from OrderProductType where SKU in(" + ids.Trim(',') + ") and IsQue=1 and OId In(select Id from OrderType where IsOutOfStock=1 and Status<>'作废订单')").List<OrderProductType>();
            foreach (var p in products)
            {
                PurchaseData data = new PurchaseData();
                data.ItemName = p.ProductName;
                data.SKU = p.SKU;
                data.SPic = p.SPicUrl;
                data.SevenDay = p.SevenDay;
                data.FifteenDay = p.Fifteen;
                data.ThirtyDay = p.ThirtyDay;
                data.WarningQty =
                    Convert.ToInt32(Math.Round(((p.SevenDay / 7) * 0.5 + p.Fifteen / 15 * 0.3 + p.ThirtyDay / 30 * 0.2), 0) * 5);
                if (data.WarningQty < 1)
                {
                    data.WarningQty = 1;
                }
                data.IsImportant = 0;
                data.AvgQty = Math.Round(((p.SevenDay / 7) * 0.5 + p.Fifteen / 15 * 0.3 + p.ThirtyDay / 30 * 0.2), 2);
                data.NowQty = stocks.Where(x => x.SKU.Trim().ToUpper() == p.SKU.Trim().ToUpper()).Sum(x => x.Qty);
                if (Math.Round(((p.SevenDay / 7) * 0.5 + p.Fifteen / 15 * 0.3 + p.ThirtyDay / 30 * 0.2), 0) * 3 < data.NowQty)
                {
                    data.IsImportant = 1;
                }
                int buyQty = plans.Where(x => x.SKU.Trim().ToUpper() == p.SKU.Trim().ToUpper()).Sum(x => x.DaoQty);
                data.BuyQty = plans.Where(x => x.SKU.Trim().ToUpper() == p.SKU.Trim().ToUpper()).Sum(x => x.Qty) - buyQty;
                data.QueQty = orderProducts.Where(x => x.SKU.Trim().ToUpper() == p.SKU.Trim().ToUpper()).Sum(x => x.Qty);

                if ((data.NowQty + data.BuyQty - data.WarningQty - data.QueQty) < 0)
                {

                    data.NeedQty = Convert.ToInt32(data.AvgQty * 10) + data.QueQty - data.NowQty - data.BuyQty;
                    list.Add(data);
                }



            }
            Session["ToExcel"] = list;
            ;
            return Json(new { total = list.Count, rows = list.OrderByDescending(x => x.NeedQty).ToList() });
        }

        [HttpPost]
        public ActionResult ImportProduct(string fileName)
        {
            DataTable dt = OrderHelper.GetDataTable(fileName);
            IList<WarehouseType> list = NSession.CreateQuery(" from WarehouseType").List<WarehouseType>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ProductType p = new ProductType { CreateOn = DateTime.Now };
                p.SKU = dt.Rows[i]["SKU"].ToString();
                p.Status = ProductStatusEnum.销售中.ToString();
                p.ProductName = dt.Rows[i]["名称"].ToString();
                p.Category = dt.Rows[i]["分类"].ToString();
                p.Standard = dt.Rows[i]["规格"].ToString();
                p.Price = Convert.ToDouble(dt.Rows[i]["价格"]);
                p.Weight = Convert.ToInt16(dt.Rows[i]["重量"]);
                p.Long = Convert.ToInt16(dt.Rows[i]["长"]);
                p.Wide = Convert.ToInt16(dt.Rows[i]["宽"]);
                p.High = Convert.ToInt16(dt.Rows[i]["高"]);
                p.Location = dt.Rows[i]["库位"].ToString();
                p.OldSKU = dt.Rows[i]["旧SKU"].ToString();
                p.HasBattery = Convert.ToInt32(dt.Rows[i]["电池"].ToString());
                p.IsElectronic = Convert.ToInt32(dt.Rows[i]["电子"].ToString());
                p.IsLiquid = Convert.ToInt32(dt.Rows[i]["液体"].ToString());
                p.PackCoefficient = Convert.ToInt32(dt.Rows[i]["包装系数"].ToString());
                p.Manager = dt.Rows[i]["管理人"].ToString();
                NSession.SaveOrUpdate(p);
                //
                //在仓库中添加产品库存
                //
                foreach (var item in list)
                {
                    WarehouseStockType stock = new WarehouseStockType();
                    stock.Pic = p.SPicUrl;
                    stock.WId = item.Id;
                    stock.Warehouse = item.WName;
                    stock.PId = p.Id;
                    stock.SKU = p.SKU;
                    stock.Title = p.ProductName;
                    stock.Qty = 0;
                    stock.UpdateOn = DateTime.Now;
                    NSession.SaveOrUpdate(stock);
                    NSession.Flush();
                }

            }
            return View();
        }

        [HttpPost]
        public ActionResult Export(string o)
        {
            StringBuilder sb = new StringBuilder();
            string sql = "select  * from Products";
            DataSet ds = new DataSet();
            IDbCommand command = NSession.Connection.CreateCommand();
            command.CommandText = sql;
            SqlDataAdapter da = new SqlDataAdapter(command as SqlCommand);
            da.Fill(ds);
            // 设置编码和附件格式 
            Session["ExportDown"] = ExcelHelper.GetExcelXml(ds);
            return Json(new { IsSuccess = true });
        }

        [HttpPost]
        public JsonResult Create(ProductType obj)
        {
            try
            {
                string filePath = Server.MapPath("~");
                obj.CreateOn = DateTime.Now;
                string pic = obj.PicUrl;

                obj.PicUrl = Utilities.BPicPath + obj.SKU + ".jpg";
                obj.SPicUrl = Utilities.SPicPath + obj.SKU + ".png";

                Utilities.DrawImageRectRect(pic, filePath + obj.PicUrl, 310, 310);
                Utilities.DrawImageRectRect(pic, filePath + obj.SPicUrl, 64, 64);
                List<ProductComposeType> list1 = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProductComposeType>>(obj.rows);
                if (list1.Count > 0)
                    obj.IsZu = 1;
                NSession.SaveOrUpdate(obj);
                NSession.Flush();
                foreach (ProductComposeType productCompose in list1)
                {
                    productCompose.SKU = obj.SKU;
                    productCompose.PId = obj.Id;
                    NSession.Save(productCompose);
                    NSession.Flush();
                }

                IList<WarehouseType> list = NSession.CreateQuery(" from WarehouseType").List<WarehouseType>();

                //
                //在仓库中添加产品库存
                //
                foreach (var item in list)
                {
                    WarehouseStockType stock = new WarehouseStockType();
                    stock.Pic = obj.SPicUrl;
                    stock.WId = item.Id;
                    stock.Warehouse = item.WName;
                    stock.PId = obj.Id;
                    stock.SKU = obj.SKU;
                    stock.Title = obj.ProductName;
                    stock.Qty = 0;
                    stock.UpdateOn = DateTime.Now;
                    NSession.SaveOrUpdate(stock);
                    NSession.Flush();
                }
            }
            catch (Exception ee)
            {
                return Json(new { IsSuccess = false, ErrorMsg = "出错了" });
            }
            return Json(new { IsSuccess = true });
        }

        /// <summary>
        /// 根据Id获取
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ProductType GetById(int Id)
        {
            ProductType obj = NSession.Get<ProductType>(Id);
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
            ProductType obj = GetById(id);
            return View(obj);
        }

        [HttpPost]
        [OutputCache(Location = OutputCacheLocation.None)]
        public ActionResult Edit(ProductType obj)
        {
            try
            {
                List<ProductComposeType> list1 = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ProductComposeType>>(obj.rows);
                NSession.Delete("from ProductComposeType where SKU='" + obj.SKU + "'");
                NSession.Flush();
                foreach (ProductComposeType productCompose in list1)
                {
                    productCompose.SKU = obj.SKU;
                    productCompose.PId = obj.Id;
                    NSession.Save(productCompose);
                    NSession.Flush();
                    obj.IsZu = 1;
                }
                NSession.Update(obj);
                NSession.Flush();
            }
            catch (Exception ee)
            {
                return Json(new { IsSuccess = false, ErrorMsg = "出错了" });
            }
            return Json(new { IsSuccess = true });

        }

        [HttpPost, ActionName("Delete")]
        public JsonResult DeleteConfirmed(int id)
        {
            try
            {
                ProductType obj = GetById(id);
                NSession.Delete(obj);
                NSession.Flush();
            }
            catch (Exception ee)
            {
                return Json(new { IsSuccess = false, ErrorMsg = "出错了" });
            }
            return Json(new { IsSuccess = true });
        }

        [HttpPost, ActionName("DeleteSKU")]
        public JsonResult DeleteConfirmed2(int id)
        {
            try
            {
                SKUCodeType obj = NSession.Get<SKUCodeType>(id);
                NSession.Delete(obj);
                NSession.Flush();
            }
            catch (Exception ee)
            {
                return Json(new { IsSuccess = false, ErrorMsg = "出错了" });
            }
            return Json(new { IsSuccess = true });
        }
        public JsonResult ListQ(string q)
        {
            IList<ProductType> objList = NSession.CreateQuery("from ProductType where SKU like '%" + q + "%'")
                .SetFirstResult(0)
                .SetMaxResults(20)
                .List<ProductType>();

            return Json(new { total = objList.Count, rows = objList });
        }


        public ActionResult SKUScan()
        {
            return View();
        }
        public ActionResult SKUScan2()
        {
            return View();
        }

        public JsonResult SKUCodeList(int page, int rows, string sort, string order, string search)
        {
            string where = "";
            string orderby = " order by Id desc ";
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
            IList<SKUCodeType> objList = NSession.CreateQuery("from SKUCodeType " + where + orderby)
                .SetFirstResult(rows * (page - 1))
                .SetMaxResults(rows)
                .List<SKUCodeType>();
            object count = NSession.CreateQuery("select count(Id) from SKUCodeType " + where).UniqueResult();
            return Json(new { total = count, rows = objList });
        }

        public JsonResult List(int page, int rows, string sort, string order, string search)
        {
            string where = "";
            string orderby = " order by Id desc ";
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
            IList<ProductType> objList = NSession.CreateQuery("from ProductType " + where + orderby)
                .SetFirstResult(rows * (page - 1))
                .SetMaxResults(rows)
                .List<ProductType>();
            object count = NSession.CreateQuery("select count(Id) from ProductType " + where).UniqueResult();
            return Json(new { total = count, rows = objList });
        }

        public JsonResult ZuList(String Id)
        {
            IList<ProductComposeType> objList = NSession.CreateQuery("from ProductComposeType where SKU='" + Id + "'").List<ProductComposeType>();
            return Json(new { total = objList.Count, rows = objList });
        }

        public JsonResult HasExist(string sku)
        {
            object count = NSession.CreateQuery("select count(Id) from ProductType where SKU='" + sku + "'").UniqueResult();
            if (Convert.ToInt32(count) > 0)
            {
                return Json(new { IsSuccess = false });
            }
            else
            {
                return Json(new { IsSuccess = true });
            }
        }

        public ActionResult SetSKUCode(int code, string sku)
        {
            object count = NSession.CreateQuery("select count(Id) from ProductType where SKU='" + sku + "'").UniqueResult();

            sku = sku.Trim();
            SqlConnection conn = new SqlConnection("server=122.227.207.204;database=Feidu;uid=sa;pwd=`1q2w3e4r");
            string sql = "select top 1 SKU from SkuCode where Code={0}or Code={1} ";
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(string.Format(sql, code, (code + 1000000)), conn);
            object objSKU = sqlCommand.ExecuteScalar();
            conn.Close();
            if (objSKU != null)
            {
                if (objSKU.ToString().Trim().ToUpper() != sku.Trim().ToUpper())
                {
                    return Json(new { IsSuccess = false, Result = "这个条码对应是的" + objSKU + ",不是现在的：" + sku + "！" });
                }
            }

            if (Convert.ToInt32(count) > 0)
            {
                object count1 =
                    NSession.CreateQuery("select count(Id) from SKUCodeType where Code=:p").SetInt32("p", code).
                        UniqueResult();
                if (Convert.ToInt32(count1) == 0)
                {
                    SKUCodeType skuCode = new SKUCodeType { Code = code, SKU = sku, IsNew = 0, IsOut = 0 };
                    NSession.Save(skuCode);
                    NSession.Flush();
                    Utilities.StockIn(1, sku, 1, 0, "条码清点入库", CurrentUser.Realname, "");
                    return Json(new { IsSuccess = true, Result = "添加成功！" });
                }
                else
                {
                    return Json(new { IsSuccess = false, Result = "这个条码已经添加！" });
                }
            }
            else
            {
                return Json(new { IsSuccess = false, Result = "没有这个产品！" });
            }
        }

        public ActionResult SetSKUCode2(int code)
        {
            IList<SKUCodeType> list =
                 NSession.CreateQuery("from SKUCodeType where Code=:p").SetInt32("p", code).SetMaxResults(1).List
                     <SKUCodeType>();
            if (list.Count > 0)
            {
                SKUCodeType sku = list[0];
                if (sku.IsOut == 1 || sku.IsSend == 1)
                {
                    return Json(new { IsSuccess = false, Result = "条码：" + code + " 已经配过货,SKU:" + sku.SKU + " 出库时间：" + sku.PeiOn + ",出库订单:" + sku.OrderNo + " ,请将此产品单独挑出来！" });
                }
                if (sku.IsScan == 1)
                {
                    return Json(new { IsSuccess = false, Result = "条码：" + code + " 已经清点扫描了,SKU:" + sku.SKU + " 刚刚已经扫描过了。你查看下是条码重复扫描了，还是有贴重复的了！" });
                }
                sku.IsScan = 1;
                NSession.Save(sku);
                NSession.Flush();
                object obj =
                    NSession.CreateQuery("select count(Id) from SKUCodeType where SKU=:p and IsScan=1 and IsOut=0").SetString("p", sku.SKU).
                        UniqueResult();
                return Json(new { IsSuccess = true, Result = "条码：" + code + " 的信息.SKU：" + sku.SKU + " 此条码未出库。条码正确！！！", ccc = sku.SKU + "已经扫描了" + obj + "个" });
            }
            else
            {
                return Json(new { IsSuccess = false, Result = "条码：" + code + " 无法找到 ,请查看扫描是否正确！" });
            }
        }


        public ActionResult GetSKUByCode(string code)
        {
            IList<SKUCodeType> list =
                 NSession.CreateQuery("from SKUCodeType where Code=:p").SetString("p", code).SetMaxResults(1).List
                     <SKUCodeType>();
            if (list.Count > 0)
            {
                SKUCodeType sku = list[0];
                if (sku.IsOut == 0)
                {
                    return Json(new { IsSuccess = true, Result = sku.SKU.Trim() });
                }
                else
                {
                    return Json(new { IsSuccess = false, Result = "当前产品已经出库过了！" });
                }
            }
            return Json(new { IsSuccess = false, Result = "没有找到这个产品！" });

        }

        public JsonResult SearchSKU(string id)
        {
            IList<ProductType> obj = NSession.CreateQuery("from ProductType where SKU='" + id + "'").List<ProductType>();
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Freight(decimal price, decimal weight, int qty, decimal onlineprice, string Currency, string LogisticMode, int Country)
        {
            decimal freight = decimal.Parse((GetFreight(weight * qty, LogisticMode, Country)).ToString("f6"));
            if (freight == -1)
                return Json(new { IsSuccess = false, ErrorMsg = "cz" }, JsonRequestBehavior.AllowGet);
            decimal currency = decimal.Parse(Math.Round(GetCurrency(Currency), 2).ToString());
            decimal profit = (onlineprice * currency - price) * qty - freight;
            return Json(new { IsSuccess = true, profit = profit, freight = freight }, JsonRequestBehavior.AllowGet);
        }
        private decimal GetFreight(decimal weight, string logisticMode, int country)
        {
            decimal discount = 0;
            decimal ReturnFreight = 0;
            IList<LogisticsModeType> logmode = NSession.CreateQuery("from LogisticsModeType where LogisticsCode='" + logisticMode + "'").List<LogisticsModeType>();
            foreach (var item in logmode)
            {
                discount = decimal.Parse(item.Discount.ToString());
                IList<LogisticsAreaType> area = NSession.CreateQuery("from LogisticsAreaType where LId='" + item.ParentID + "'").List<LogisticsAreaType>();
                foreach (var it in area)
                {
                    object obj = NSession.CreateQuery("select count(Id) from LogisticsAreaCountryType where CountryCode='" + country + "' and AreaCode='" + it.Id + "'").UniqueResult();
                    if (Convert.ToInt32(obj) > 0)
                    {
                        IList<LogisticsFreightType> list = NSession.CreateQuery("from LogisticsFreightType where AReaCode='" + it.Id + "'").List<LogisticsFreightType>();
                        foreach (var fre in list)
                        {
                            if (weight <= decimal.Parse(fre.EndWeight.ToString()))
                            {
                                if (fre.EveryFee != 0)
                                {
                                    ReturnFreight = weight * decimal.Parse(fre.EveryFee.ToString()) + decimal.Parse(fre.ProcessingFee.ToString()) * decimal.Parse(discount.ToString());
                                }
                                else
                                {
                                    ReturnFreight = decimal.Parse(fre.FristFreight.ToString()) + decimal.Parse(fre.ProcessingFee.ToString()) + (weight - decimal.Parse(fre.FristWeight.ToString())) / decimal.Parse(fre.IncrementWeight.ToString()) * decimal.Parse(fre.IncrementFreight.ToString());
                                }
                            }
                            else
                            {
                                return -1;
                            }
                        }
                    }
                }
            }

            return ReturnFreight;
        }
        public double GetCurrency(string code)
        {
            double curr = 0;
            IList<CurrencyType> list = NSession.CreateQuery("from CurrencyType where CurrencyCode='" + code + "'").List<CurrencyType>();
            foreach (var s in list)
            {
                curr = s.CurrencyValue;
            }
            return curr;
        }

        public JsonResult ToExcel()
        {
            try
            {
                IList<PurchaseData> signout = Session["ToExcel"] as List<PurchaseData>;
                DataSet ds = ConvertToDataSet<PurchaseData>(signout);
                Session["ExportDown"] = ExcelHelper.GetExcelXml(ds);
            }
            catch (Exception ee)
            {
                return Json(new { Msg = "出错了" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Msg = "导出成功" }, JsonRequestBehavior.AllowGet);
        }
        //IList转DataSet
        public static DataSet ConvertToDataSet<T>(IList<T> list)
        {
            if (list == null || list.Count <= 0)
            {
                return null;
            }

            DataSet ds = new DataSet();
            DataTable dt = new DataTable(typeof(T).Name);
            DataColumn column;
            DataRow row;

            System.Reflection.PropertyInfo[] myPropertyInfo = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            foreach (T t in list)
            {
                if (t == null)
                {
                    continue;
                }

                row = dt.NewRow();

                for (int i = 0, j = myPropertyInfo.Length; i < j; i++)
                {
                    System.Reflection.PropertyInfo pi = myPropertyInfo[i];

                    string name = pi.Name;

                    if (dt.Columns[name] == null)
                    {
                        column = new DataColumn(name, pi.PropertyType);
                        dt.Columns.Add(column);
                    }

                    row[name] = pi.GetValue(t, null);
                }

                dt.Rows.Add(row);
            }

            ds.Tables.Add(dt);

            return ds;
        }
    }
}

