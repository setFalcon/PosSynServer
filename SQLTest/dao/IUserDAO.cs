using SQLTest.domain;

namespace SQLTest.dao {
    public interface IUserDAO {
        bool Register(Users users);
        bool Verify(Users users);
    }
}