using System.Collections.Generic;
using ConnectBridge;
using ConnectBridge.Util;
using Photon.SocketServer;
using PosSynServer.DAO;
using PosSynServer.DAO.impl;
using PosSynServer.Mapper;

namespace PosSynServer.Handler {
    public class LoginHandler : BaseHandler {
        public LoginHandler() {
            OpCode = OperationCode.Login;
        }

        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters,
            ClientPeer clientPeer) {
            Dictionary<byte, object> data = operationRequest.Parameters;
            string username = DictUtil.GetValue(data, (byte) ParameterCode.Username) as string;
            string password = DictUtil.GetValue(data, (byte) ParameterCode.Password) as string;
            IUserDAO dao = new IUserDAOImpl();
            Users u = new Users(username, password);
            OperationResponse resp = new OperationResponse(operationRequest.OperationCode);
            resp.ReturnCode = (short) (dao.Verify(u) ? ReturnCode.LoginSuccess : ReturnCode.LoginFailed);
            if (resp.ReturnCode == (short) ReturnCode.LoginSuccess) {
                MyClientPeer peer = clientPeer as MyClientPeer;
                if (peer != null) peer.username = username;
            }

            clientPeer.SendOperationResponse(resp, sendParameters);
        }
    }
}