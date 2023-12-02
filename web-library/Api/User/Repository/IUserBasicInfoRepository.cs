namespace web_library.Api.User.Repository;
using Entity;
using web_library.Api.User.Entity;

public interface IUserBasicInfoRepository
{
    void Add(UserBasicInfo userBasicInfo);
    UserBasicInfo GetForUser(User user);
}