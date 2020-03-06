using ConnectBridge;
using Photon.SocketServer;

namespace PosSynServer.Handler {
    public class LoginHandler :BaseHandler {
        public LoginHandler() {
            OpCode = OperationCode.Login;
        }

        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer clientPeer) {
            
        }
    }
}