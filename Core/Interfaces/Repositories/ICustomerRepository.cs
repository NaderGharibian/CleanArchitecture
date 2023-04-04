using Context.Tables;
using Core.Dto.Contracts;

namespace Core.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        bool Create(CreateCustomerContract customer);
        List<TCustomer> Read();
        TCustomer findById(int id);
        TCustomer findByUniqeField(string firstName, string lastName, string dateOfBirth);
        TCustomer findByEmail(string email);
        void Update(UpdateCustomerContract customer);
        bool Delete(int id);



    }
}
