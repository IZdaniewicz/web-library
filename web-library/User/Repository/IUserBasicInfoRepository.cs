using web_library.User.Entity;

namespace web_library.User.Repository;
using Entity;

public interface IUserBasicInfoRepository
{
    void Add(UserBasicInfo userBasicInfo);
    UserBasicInfo GetForUser(User user);
}