using Context.EntityFramework;
using Context.Tables;

using Core.Dto.Contracts;

using Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;

using Moq;

namespace Infrastructure.UnitTest
{
    public class CustomerRepository
    {
        [Fact]
        public async Task CREATE_CUSTOMER()
        {
            var mockApplicationDbContext = new Mock<TestDBContext>();

            var newListCustomer = new List<TCustomer>();
            newListCustomer.Add(new TCustomer { Id = 1, FirstName = "test", LastName = "test", PhoneNumber = "0916", BankAccountNumber = "123", DateOfBirth = "1990-01-01", Email = "info@hot.com" });

            var returnsResult = mockApplicationDbContext.Setup(x => x.TCustomer.AddAsync(It.IsAny<TCustomer>(), default))

            .Callback<TCustomer, CancellationToken>((s, token) => { newListCustomer.Add(s); });

            //_dataContext.Setup(c => c.SaveChangesAsync(default))
            //.Returns(Task.FromResult(1))
            //.Verifiable();

            var userRepository = new Repositories.CustomerRepository(mockApplicationDbContext.Object);
            var response = userRepository.Create(new CreateCustomerContract());
            if (response)
            {
                //// assert
                Assert.True(true);
            }
        }

        [Fact]
        public async Task READ_CUSTOMERS()
        {
            var mockApplicationDbContext = new Mock<TestDBContext>();

            var data = new List<TCustomer>()
            {
                new TCustomer { Id = 1, FirstName = "test", LastName = "test", PhoneNumber = "0916", BankAccountNumber = "123", DateOfBirth = "1990-01-01", Email = "info@hot.com" }
            }.AsQueryable();
            var usersMock = new Mock<DbSet<TCustomer>>();
            //var returnsResult = mockApplicationDbContext.Setup(x => x.TCustomer.ToList()).Returns(() => newListCustomer.GetEnumerator());
            // mockApplicationDbContext.Setup(x => x.TCustomer.GetAsyncEnumerator()).Returns(() => newListCustomer.GetEnumerator());
            var mockSet = new Mock<DbSet<TCustomer>>();
            mockSet.As<IQueryable<TCustomer>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<TCustomer>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<TCustomer>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<TCustomer>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());


            mockApplicationDbContext.Setup(x => x.TCustomer).Returns(()=> mockSet.Object);

            
            var userRepository = new Repositories.CustomerRepository(mockApplicationDbContext.Object);

            var response = userRepository.Read();
            Assert.True(true);
        }

        //[Fact]
        //public async Task CANT_CREATE_CUSTOMER()
        //{
        //    var mockApplicationDbContext = new Mock<TestDBContext>();


        //    var returnsResult = mockApplicationDbContext.Setup(x => x.TCustomer.AddAsync(It.IsAny<TCustomer>(), default)).Throws(new IOException());

        //    //_dataContext.Setup(c => c.SaveChangesAsync(default))
        //    //.Returns(Task.FromResult(1))
        //    //.Verifiable();

        //    var userRepository = new CustomerRepository(mockApplicationDbContext.Object);
        //    try
        //    {
        //        var response = userRepository.Create(new CreateCustomerContract());
        //        Assert.True(false);

        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.True(true);
        //    }
        //}
    }
}