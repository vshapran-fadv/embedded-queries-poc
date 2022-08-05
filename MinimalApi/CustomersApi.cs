using AutoMapper;
using DataLayer.Model;
using DataLayer.Repos;
using DataLayer.UnitOfWork;

namespace MinimalApi;

public static class CustomersApi
{
    public static async Task<IResult> GetAll(ICustomerRepo repo, CancellationToken ct)
    {
        var customers = await repo.LoadAll(ct);
        return Results.Ok(customers);
    }

    public static async Task<IResult> GetCustomer(string name, ICustomerRepo repo, CancellationToken ct)
    {
        var customer = await repo.LoadByName(name, ct);
        return customer is null
            ? Results.NotFound(new { Error = $"Customer \"{name}\" is not found" })
            : Results.Ok(customer);
    }

    public static async Task<IResult> AddNew(CustomerData data, ICustomerRepo repo, IUnitOfWork uof, IMapper mapper, CancellationToken ct)
    {
        var id = await repo.AddNew(data, ct);
        var customer = mapper.Map<Customer>(data, c => c.AfterMap((_, d) => d.Id = id));

        await uof.Complete(ct);

        return Results.Created($"customers/{id}", customer);
    }

    public static async Task<IResult> Delete(int id, ICustomerRepo repo, IUnitOfWork uof, CancellationToken ct)
    {
        await repo.Delete(id, ct);
        await uof.Complete(ct);

        return Results.NoContent();
    }
}