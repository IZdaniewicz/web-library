using web_library.User.Entity;

namespace web_library.User.Repository;
using Entity;

public class UserBasicInfoRepository : IUserBasicInfoRepository
{
    private readonly DataContext _dbContext;

    public UserBasicInfoRepository(DataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(UserBasicInfo ubi)
    {
        _dbContext.UserBasicInfos.Add(ubi);
        _dbContext.SaveChanges();
    }

    public UserBasicInfo GetForUser(User user)
    {
        return user.UserBasicInfo!;
    }
}