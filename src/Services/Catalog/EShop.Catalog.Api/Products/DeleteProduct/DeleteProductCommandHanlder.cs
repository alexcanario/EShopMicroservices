namespace EShop.Catalog.Api.Products.DeleteProduct;

public sealed record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;
public sealed record DeleteProductResult(bool IsSuccess);

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{
	public DeleteProductCommandValidator()
	{
		RuleFor(x => x.Id).NotEmpty().WithMessage("Product Id is required.");
	}
}

internal class DeleteProductCommandHanlder(IDocumentSession Session) 
	: ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
	public async Task<DeleteProductResult> Handle(DeleteProductCommand Command, CancellationToken cancellationToken)
	{
		Session.Delete<Product>(Command.Id);
		await Session.SaveChangesAsync(cancellationToken);
		return new (true);
	}
}