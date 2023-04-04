using Context.EntityFramework;
using Context.Tables;
using Core.Dto.Contracts;
using Core.Interfaces.Repositories;

namespace Infrastructure.Repositories
{
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly TestDBContext _TestDBContext;



        public CustomerRepository(TestDBContext testDBContext)
        {
            _TestDBContext = testDBContext;
        }

        public bool Create(CreateCustomerContract customer)
        {

            _TestDBContext.TCustomer.AddAsync(new TCustomer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                DateOfBirth = customer.DateOfBirth,
                Email = customer.Email,
                BankAccountNumber = customer.BankAccountNumber,
                PhoneNumber = customer.PhoneNumber,
            });
            return true;
        }

        public List<TCustomer> Read()
        =>
            _TestDBContext.TCustomer.ToList();


        public TCustomer findById(int id)
      =>
          _TestDBContext.TCustomer.FirstOrDefault(i => i.Id == id);

        public TCustomer findByUniqeField(string firstName, string lastName, string dateOfBirth)
=>
   _TestDBContext.TCustomer.FirstOrDefault(i => i.FirstName == firstName && i.LastName == lastName && i.DateOfBirth == dateOfBirth);

        public TCustomer findByEmail(string email)
=>
 _TestDBContext.TCustomer.FirstOrDefault(i => i.FirstName == email);


        public void Update(UpdateCustomerContract customer)
        {
            var result = findById(customer.Id.Value);
            if (result != null)
            {
                result.PhoneNumber = customer.PhoneNumber;
                result.Email = customer.Email;
                result.BankAccountNumber = customer.BankAccountNumber;
                result.DateOfBirth = customer.DateOfBirth;
                result.FirstName = customer.FirstName;
                result.LastName = customer.LastName;
            }
        }

        public bool Delete(int id)
        {
            var result = findById(id);
            if (result != null)
            {
                _TestDBContext.TCustomer.Remove(result);
                return true;
            }
            return false;

        }



    }
}
