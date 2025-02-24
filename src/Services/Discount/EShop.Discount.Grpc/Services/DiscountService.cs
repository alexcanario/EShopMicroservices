using EShop.Discount.Grpc.Database;
using EShop.Discount.Grpc.Models;

using Grpc.Core;

using Mapster;

using Microsoft.EntityFrameworkCore;

namespace EShop.Discount.Grpc.Services;

public class DiscountService(DiscountContext Context, ILogger<DiscountService> Logger) 
	: DiscountProtoService.DiscountProtoServiceBase
{
	public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
	{
		//DONE: Get discount from database
		var coupoun = await Context.Coupouns.FirstOrDefaultAsync(c => c.ProductName == request.ProductName);

		if(coupoun == null)
			Logger.LogWarning($"Discount with ProductName={request.ProductName} is not found.");

		return coupoun is null
			? new CouponModel { Id = 0, ProductName = "No Discount", Amount = 0, Description = "No Discount Desc" }
			: coupoun.Adapt<CouponModel>();
	}

	public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
	{
		//DONE: Persist discount in database

		var coupoun = request.Coupon.Adapt<Coupoun>() 
			?? throw new RpcException(new Status(StatusCode.InvalidArgument, "Discount is not valid"));
		
		_ = await Context.Coupouns.AddAsync(coupoun);
		await Context.SaveChangesAsync();
		Logger.LogInformation($"Discount is successfully created. ProductName={coupoun.ProductName}");

		return coupoun.Adapt<CouponModel>();
	}

	public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
	{
		//DONE: Update discount in database
		var coupoun = request.Coupon.Adapt<Coupoun>() ?? throw new RpcException(new Status(StatusCode.InvalidArgument, "Discount is not valid"));
		
		Context.Coupouns.Update(coupoun);
		_ = await Context.SaveChangesAsync();

		Logger.LogInformation($"Discount is successfully updated. ProductName={coupoun.ProductName}");

		return coupoun.Adapt<CouponModel>();
	}

	public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
	{
		//DONE: Delete discount from database

		var coupoun = await Context.Coupouns.FirstOrDefaultAsync(c => c.ProductName == request.ProductName)
			?? throw new RpcException(new Status(StatusCode.NotFound, $"Discount with ProductName={request.ProductName} is not found"));

		Context.Coupouns.Remove(coupoun);
		_ = await Context.SaveChangesAsync();

		return new DeleteDiscountResponse { Success = true };
	}
}