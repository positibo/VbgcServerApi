using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using VbgcServerApi.Data;
using VbgcServerApi.Infrastructure.Dto;

namespace VbgcServerApi.Services
{
    public class SaleService : ISaleService
    {
        private DataContext context;
        private readonly IMapper mapper;

        public SaleService(DataContext db, IMapper mapper)
        {
            this.context = db;
            this.mapper = mapper;
        }

        public IEnumerable<SaleDto> GetAll()
        {
            var franchises = context.Franchises.ToList();
            var sales = new List<SaleDto>();

            if (franchises == null)
                return null;

            foreach (var franchise in franchises)
                sales.Add(GetSale(franchise.FranchiseId));

            return sales;
        }

        public SaleDto GetByFranchiseId(int franchiseId)
        {
            return GetSale(franchiseId);
        }

        private SaleDto GetSale(int franchiseId)
        {
            //var dailySales = GetDailySales(franchiseId);
            //var monthlySales = GetMonthlySales(dailySales);
            //var quarterlySales = GetQuarterlySales(monthlySales);

            //return new SaleDto
            //{
            //    FranchiseName = context.Franchises.Find(franchiseId)?.FranchiseName,
            //    DailySales = dailySales,
            //    MonthlySales = monthlySales,
            //    QuarterlySales = quarterlySales
            //};

            return null;
        }

        public List<QuarterlySaleDto> GetQuarterlySales(/*List<MonthlySaleDto> monthlySales*/)
        {
            var monthlySales = GetMonthlySales();

            var quarterlySales = new List<QuarterlySaleDto>();
            var quarter = 1;
            decimal total = 0M;
            for (int m = 1; m <= 12; m++)
            {
                var sales = monthlySales.Where(ms => ms.Month == CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(m)).ToList();
                total = total + sales.Select(d => d.TotalSale).Sum();

                if (m % 3 == 0)
                {
                    quarterlySales.Add(new QuarterlySaleDto
                    {
                        Quarter = quarter++,
                        TotalSale = total
                    });
                    total = 0M;
                }
            }

            return quarterlySales;
        }

        public List<MonthlySaleDto> GetMonthlySales(/*List<DailySaleDto> dailySales*/)
        {
            var dailySales = GetDailySales(1);
            var monthlySales = new List<MonthlySaleDto>();
            for (int m = 1; m <= 12; m++)
            {
                var sales = dailySales.Where(d => d.IssueDate.Month == m).ToList();
                monthlySales.Add(new MonthlySaleDto
                {
                    Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(m),
                    //Sales = sales,
                    TotalSale = sales.Select(d => d.TotalSale).Sum()
                });
            }

            return monthlySales;
        }

        private List<DailySaleDto> GetDailySales(int franchiseId)
        {
            var dailySales = new List<DailySaleDto>();
            var orders = context.Orders.Where(o => o.FranchiseId == franchiseId).ToList();
            foreach (var order in orders)
            {
                foreach (var detail in order.OrderDetails)
                {
                    var totalprice = detail.Game.Price * detail.Quantity;
                    dailySales.Add(new DailySaleDto { TotalSale = totalprice, IssueDate = order.IssueDate });
                }
            }

            return dailySales;
        }
    }
}
