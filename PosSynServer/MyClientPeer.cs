using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;

namespace PosSynServer {
    //客户端连接后，使用ClientPeer代表客户端的一个链接
    public class MyClientPeer : ClientPeer {
        public MyClientPeer(InitRequest initRequest) : base(initRequest) { }

        //处理客户端请求
        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters) { }

        //断开连接
        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail) { }
    }
}