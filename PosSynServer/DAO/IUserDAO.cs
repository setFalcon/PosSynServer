using PosSynServer.Mapper;

namespace PosSynServer.DAO {
    public interface IUserDAO {
        bool Register(Users users);
        bool Verify(Users users);
    }
}