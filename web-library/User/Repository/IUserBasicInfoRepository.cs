namespace web_library.User.Repository;
using Entity;
using web_library.User.Entity;

public interface IUserBasicInfoRepository
{
    void Add(UserBasicInfo userBasicInfo);
    UserBasicInfo GetForUser(User user);
}