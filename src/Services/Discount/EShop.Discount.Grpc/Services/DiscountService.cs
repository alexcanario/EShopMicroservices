using Grpc.Core;

namespace EShop.Discount.Grpc.Services;

public class DiscountService : DiscountProtoService.DiscountProtoServiceBase
{
	public override Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
	{
		//TODO: Get discount from database
		return base.GetDiscount(request, context);
	}

	public override Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
	{
		//TODO: Persist discount in database
		return base.CreateDiscount(request, context);
	}

	public override Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
	{
		//TODO: Update discount in database
		return base.UpdateDiscount(request, context);
	}

	public override Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
	{
		//TODO: Delete discount from database
		return base.DeleteDiscount(request, context);
	}
}