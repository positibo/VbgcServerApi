using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using VbgcServerApi.Data;
using VbgcServerApi.Data.Entities;
using VbgcServerApi.Infrastructure.BusinessRules;
using VbgcServerApi.Infrastructure.Dto;

namespace VbgcServerApi.Services
{
	public class OrderService : IOrderService
	{
		private DataContext context;
		private readonly IMapper mapper;

		public OrderService(DataContext db, IMapper mapper)
		{
			this.context = db;
			this.mapper = mapper;
		}

		public IEnumerable<OrderDto> GetAll()
		{
			var orderDto = mapper.Map<IEnumerable<OrderDto>>(context.Orders);
			var orders = new List<OrderDto>();
			foreach (var order in orderDto)
			{
				var customer = context.Customers.Find(order.CustomerId);
				order.CustomerName = customer != null ? customer.CustomerName : string.Empty;

				var transactionStatus = context.TransactionStatus.Find(order.TransactionStatusId);
				order.TransactionStatusName = transactionStatus != null ? transactionStatus.TransactionStatusName : string.Empty;

				// TODO: add all item orders.
				var orderDetails = order.OrderDetails.ToList();
				if (orderDetails != null && orderDetails.Count() > 0)
				{
					orders.Add(new OrderDto
					{
						ReferenceNumber = order.ReferenceNumber,
						CustomerId = order.CustomerId,
						CustomerName = order.CustomerName,
						OrderId = order.OrderId,
						GameName = orderDetails[0].GameName,
						Quantity = orderDetails[0].Quantity,
						TransactionStatusId = order.TransactionStatusId,
						TransactionStatusName = order.TransactionStatusName,
						//TransactionStatus = order.TransactionStatus,
						FranchiseId = order.FranchiseId,
						OrderDetails = order.OrderDetails
					});
				}
			}

			return orders;
		}

		public OrderDto GetById(int id)
		{
			var entity = context.Orders.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}

			var order = mapper.Map<OrderDto>(entity);

			var customer = context.Customers.Find(order.CustomerId);
			order.CustomerName = customer != null ? customer.CustomerName : string.Empty;

			var transactionStatus = context.TransactionStatus.Find(order.TransactionStatusId);
			order.TransactionStatusName = transactionStatus != null ? transactionStatus.TransactionStatusName : string.Empty;

			// TODO: add all item orders.
			var orderDetails = order.OrderDetails.ToList();
			if (orderDetails != null && orderDetails.Count() > 0)
			{
				return new OrderDto
				{
					ReferenceNumber = order.ReferenceNumber,
					CustomerId = order.CustomerId,
					CustomerName = order.CustomerName,
					OrderId = order.OrderId,
					GameName = orderDetails[0].GameName,
					Quantity = orderDetails[0].Quantity,
					TransactionStatusId = order.TransactionStatusId,
					TransactionStatusName = order.TransactionStatusName,
					//TransactionStatus = order.TransactionStatus,
					FranchiseId = order.FranchiseId,
					OrderDetails = order.OrderDetails
				};
			}

			return order;
		}

		public object Create(OrderDto dto)
		{
			var entity = mapper.Map<Order>(dto);
			context.Add(entity);
			context.SaveChanges();
			return entity.OrderId;
		}

		public void Update(int id, OrderDto dto)
		{
			var entity = context.Orders.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}

			context.Update(mapper.Map(dto, entity));
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var entity = context.Orders.Find(id);
			if (entity == null)
			{
				throw new NotFoundException();
			}
			context.Remove(entity);
			context.SaveChanges();
		}
	}
}
