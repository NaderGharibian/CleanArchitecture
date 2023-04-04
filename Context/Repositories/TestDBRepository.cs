using Context.EntityFramework;
using Context.Interfaces;

namespace Context.Repositories;

public class TestDBRepository : ITestDBRepository
{
    private TestDBContext TestDBContext { get; }
    public TestDBRepository(TestDBContext testDBContext)
    {
        TestDBContext = testDBContext;
    }
    public async Task TestDBSaveChangeAsync()
    {
        if (TestDBContext.ChangeTracker.HasChanges())
            await TestDBContext.SaveChangesAsync();
    }
}