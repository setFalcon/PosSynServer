using Photon.SocketServer;

namespace PosSynServer {
    //Server端主类,服务器需要使用继承ApplicationBase类的主类进行逻辑编写
    //主类负责与客户端的连接
    public class PosSynServer : ApplicationBase {
        //初始化
        protected override void Setup() { }

        //客户端与服务器创建连接
        protected override PeerBase CreatePeer(InitRequest initRequest) {
            return new MyClientPeer(initRequest);
        }

        //服务关闭
        protected override void TearDown() { }
    }
}