using System;
using ConnectBridge;
using ConnectBridge.Util;
using Photon.SocketServer;

namespace PosSynServer.Handler {
    public class SyncPosHandler : BaseHandler {
        public SyncPosHandler() {
            OpCode = OperationCode.SyncPos;
        }

        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer clientPeer) {
            float positionX = (float) DictUtil.GetValue(operationRequest.Parameters, (byte) ParameterCode.PositionX);
            float positionY = (float) DictUtil.GetValue(operationRequest.Parameters, (byte) ParameterCode.PositionY);
            float positionZ = (float) DictUtil.GetValue(operationRequest.Parameters, (byte) ParameterCode.PositionZ);
            if (clientPeer is MyClientPeer peer) {
                peer.x = positionX;
                peer.y = positionY;
                peer.z = positionZ;
            }
        }
    }
}