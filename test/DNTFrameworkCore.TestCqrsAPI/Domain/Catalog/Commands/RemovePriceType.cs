using DNTFrameworkCore.Cqrs.Commands;

namespace DNTFrameworkCore.TestCqrsAPI.Domain.Catalog.Commands
{
    public sealed class RemovePriceType : ICommand
    {
        public int Id { get; }

        public RemovePriceType(int id) => Id = id;
    }
}