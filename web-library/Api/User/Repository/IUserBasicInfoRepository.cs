namespace web_library.Api.User.Repository;
using Entity;
public interface IUserBasicInfoRepository
{
    void Add(UserBasicInfo userBasicInfo);
    UserBasicInfo GetForUser(User user);
}