using Context.Interfaces;

using Core.Dto.Contracts;
using Core.Dto.UseCases.Requests;
using Core.Dto.UseCases.Responses;
using Core.Interfaces;
using Core.Interfaces.Repositories;
using Core.UseCases.Requests;

using Moq;

using System.Threading.Tasks;

using Xunit;

namespace Core.UnitTest
{
    public class CreateCustomerRequestUseCaseUnitTest
    {
        [Fact]
        public async void CAN_CREATE()
        {

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockTestDBRepository = new Mock<ITestDBRepository>();


            mockCustomerRepository
                .Setup(repo => repo.Create(It.IsAny<CreateCustomerContract>()))
                .Returns(true);

            mockTestDBRepository
                .Setup(repo => repo.TestDBSaveChangeAsync()).Returns(()=> Task.FromResult(0));


            var useCase = new CreateCustomerRequestUseCase(mockCustomerRepository.Object, mockTestDBRepository.Object);

            var mockOutputPort = new Mock<IResponseUseCase<CreateCustomerResponseDtoUseCase>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<CreateCustomerResponseDtoUseCase>()));

            var customer = new CreateCustomerContract
            {
                FirstName = "test",
                LastName = "test",
                PhoneNumber = "09163307425",
                BankAccountNumber = "1234565678",
                DateOfBirth = "1990-01-01",
                Email = "info@hot.com"
            };
            // act
            var response = await useCase.Handle(new CreateCustomerRequestDtoUseCase(customer), mockOutputPort.Object);

            // assert
            Assert.True(response);
        }

        [Fact]
        public async void PHONE_NUMBER_NOT_VALIDE_CANT_CREATE()
        {

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockTestDBRepository = new Mock<ITestDBRepository>();


            mockCustomerRepository
                .Setup(repo => repo.Create(It.IsAny<CreateCustomerContract>()))
                .Returns(true);

            mockTestDBRepository
                .Setup(repo => repo.TestDBSaveChangeAsync()).Returns(() => Task.FromResult(0));


            var useCase = new CreateCustomerRequestUseCase(mockCustomerRepository.Object, mockTestDBRepository.Object);

            var mockOutputPort = new Mock<IResponseUseCase<CreateCustomerResponseDtoUseCase>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<CreateCustomerResponseDtoUseCase>()));

            var customer = new CreateCustomerContract
            {
                FirstName = "test",
                LastName = "test",
                PhoneNumber = "0916333+",
                BankAccountNumber = "1234565678",
                DateOfBirth = "1990-01-01",
                Email = "info@hot.com"
            };
            // act
            var response = await useCase.Handle(new CreateCustomerRequestDtoUseCase(customer), mockOutputPort.Object);

            // assert
            Assert.False(response);
        }
        [Fact]
        public async void EMAIL_NOT_VALIDE_CANT_CREATE()
        {

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockTestDBRepository = new Mock<ITestDBRepository>();


            mockCustomerRepository
                .Setup(repo => repo.Create(It.IsAny<CreateCustomerContract>()))
                .Returns(true);

            mockTestDBRepository
                .Setup(repo => repo.TestDBSaveChangeAsync()).Returns(() => Task.FromResult(0));


            var useCase = new CreateCustomerRequestUseCase(mockCustomerRepository.Object, mockTestDBRepository.Object);

            var mockOutputPort = new Mock<IResponseUseCase<CreateCustomerResponseDtoUseCase>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<CreateCustomerResponseDtoUseCase>()));

            var customer = new CreateCustomerContract
            {
                FirstName = "test",
                LastName = "test",
                PhoneNumber = "09163307425",
                BankAccountNumber = "1234565678",
                DateOfBirth = "1990-01-01",
                Email = "info.SDSD.com"
            };
            // act
            var response = await useCase.Handle(new CreateCustomerRequestDtoUseCase(customer), mockOutputPort.Object);

            // assert
            Assert.False(response);
        }
        [Fact]
        public async void FIRST_NAME_EMPTY_CANT_CREATE()
        {

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockTestDBRepository = new Mock<ITestDBRepository>();


            mockCustomerRepository
                .Setup(repo => repo.Create(It.IsAny<CreateCustomerContract>()))
                .Returns(true);

            mockTestDBRepository
                .Setup(repo => repo.TestDBSaveChangeAsync()).Returns(() => Task.FromResult(0));


            var useCase = new CreateCustomerRequestUseCase(mockCustomerRepository.Object, mockTestDBRepository.Object);

            var mockOutputPort = new Mock<IResponseUseCase<CreateCustomerResponseDtoUseCase>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<CreateCustomerResponseDtoUseCase>()));

            var customer = new CreateCustomerContract
            {
                FirstName = null,
                LastName = "test",
                PhoneNumber = "09163307425",
                BankAccountNumber = "1234565678",
                DateOfBirth = "1990-01-01",
                Email = "info@gmail.com"
            };
            // act
            var response = await useCase.Handle(new CreateCustomerRequestDtoUseCase(customer), mockOutputPort.Object);

            // assert
            Assert.False(response);
        }
        [Fact]
        public async void LAST_NAME_EMPTY_CANT_CREATE()
        {

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockTestDBRepository = new Mock<ITestDBRepository>();


            mockCustomerRepository
                .Setup(repo => repo.Create(It.IsAny<CreateCustomerContract>()))
                .Returns(true);

            mockTestDBRepository
                .Setup(repo => repo.TestDBSaveChangeAsync()).Returns(() => Task.FromResult(0));


            var useCase = new CreateCustomerRequestUseCase(mockCustomerRepository.Object, mockTestDBRepository.Object);

            var mockOutputPort = new Mock<IResponseUseCase<CreateCustomerResponseDtoUseCase>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<CreateCustomerResponseDtoUseCase>()));

            var customer = new CreateCustomerContract
            {
                FirstName = "test",
                LastName = null,
                PhoneNumber = "09163307425",
                BankAccountNumber = "1234565678",
                DateOfBirth = "1990-01-01",
                Email = "info@gmail.com"
            };
            // act
            var response = await useCase.Handle(new CreateCustomerRequestDtoUseCase(customer), mockOutputPort.Object);

            // assert
            Assert.False(response);
        }
        [Fact]
        public async void BANK_ACCOUNT_EMPTY_CANT_CREATE()
        {

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockTestDBRepository = new Mock<ITestDBRepository>();


            mockCustomerRepository
                .Setup(repo => repo.Create(It.IsAny<CreateCustomerContract>()))
                .Returns(true);

            mockTestDBRepository
                .Setup(repo => repo.TestDBSaveChangeAsync()).Returns(() => Task.FromResult(0));


            var useCase = new CreateCustomerRequestUseCase(mockCustomerRepository.Object, mockTestDBRepository.Object);

            var mockOutputPort = new Mock<IResponseUseCase<CreateCustomerResponseDtoUseCase>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<CreateCustomerResponseDtoUseCase>()));

            var customer = new CreateCustomerContract
            {
                FirstName = "test",
                LastName = "test",
                PhoneNumber = "09163307425",
                BankAccountNumber = null,
                DateOfBirth = "1990-01-01",
                Email = "info@gmail.com"
            };
            // act
            var response = await useCase.Handle(new CreateCustomerRequestDtoUseCase(customer), mockOutputPort.Object);

            // assert
            Assert.False(response);
        }
        [Fact]
        public async void DATE_OF_BIRTHDAY_EMPTY_CANT_CREATE()
        {

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockTestDBRepository = new Mock<ITestDBRepository>();


            mockCustomerRepository
                .Setup(repo => repo.Create(It.IsAny<CreateCustomerContract>()))
                .Returns(true);

            mockTestDBRepository
                .Setup(repo => repo.TestDBSaveChangeAsync()).Returns(() => Task.FromResult(0));


            var useCase = new CreateCustomerRequestUseCase(mockCustomerRepository.Object, mockTestDBRepository.Object);

            var mockOutputPort = new Mock<IResponseUseCase<CreateCustomerResponseDtoUseCase>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<CreateCustomerResponseDtoUseCase>()));

            var customer = new CreateCustomerContract
            {
                FirstName = "test",
                LastName = "test",
                PhoneNumber = "09163307425",
                BankAccountNumber = "123456",
                DateOfBirth = null,
                Email = "info@gmail.com"
            };
            // act
            var response = await useCase.Handle(new CreateCustomerRequestDtoUseCase(customer), mockOutputPort.Object);

            // assert
            Assert.False(response);
        }

        [Fact]
        public async void DATE_OF_BIRTHDAY_VALID_CAN_CREATE()
        {

            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockTestDBRepository = new Mock<ITestDBRepository>();


            mockCustomerRepository
                .Setup(repo => repo.Create(It.IsAny<CreateCustomerContract>()))
                .Returns(true);

            mockTestDBRepository
                .Setup(repo => repo.TestDBSaveChangeAsync()).Returns(() => Task.FromResult(0));


            var useCase = new CreateCustomerRequestUseCase(mockCustomerRepository.Object, mockTestDBRepository.Object);

            var mockOutputPort = new Mock<IResponseUseCase<CreateCustomerResponseDtoUseCase>>();
            mockOutputPort.Setup(outputPort => outputPort.Handle(It.IsAny<CreateCustomerResponseDtoUseCase>()));

            var customer = new CreateCustomerContract
            {
                FirstName = "test",
                LastName = "test",
                PhoneNumber = "09163307425",
                BankAccountNumber = "123456",
                DateOfBirth = "10-12-1990",
                Email = "info@gmail.com"
            };
            // act
            var response = await useCase.Handle(new CreateCustomerRequestDtoUseCase(customer), mockOutputPort.Object);

            // assert
            Assert.True(response);
        }
    }
}