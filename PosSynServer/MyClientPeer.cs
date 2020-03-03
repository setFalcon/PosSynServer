using System.Collections.Generic;
using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;

namespace PosSynServer {
    //客户端连接后，使用ClientPeer代表客户端的一个链接
    public class MyClientPeer : ClientPeer {
        public MyClientPeer(InitRequest initRequest) : base(initRequest) { }

        //处理客户端请求
        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters) {
            byte opCode = operationRequest.OperationCode; //区分请求类型
            switch (opCode) {
                case 1:
                    PosSynServer.Log.Info("收到客户端请求");
                    //接受Parameters
                    Dictionary<byte, object> data = operationRequest.Parameters;
                    object intValue;
                    data.TryGetValue(1, out intValue);
                    object stringValue;
                    data.TryGetValue(2, out stringValue);
                    PosSynServer.Log.Info(intValue + " " + stringValue); //打印信息
                    //响应
                    OperationResponse resp = new OperationResponse();
                    resp.OperationCode = 1;
                    Dictionary<byte, object> dataResp = new Dictionary<byte, object>();
                    dataResp.Add(1, "Hello Client");
                    resp.SetParameters(dataResp);
                    SendOperationResponse(resp, sendParameters); //响应客户端的请求

                    EventData eventData = new EventData();
                    eventData.Code = 1;
                    eventData.SetParameters(dataResp);
                    SendEvent(eventData, sendParameters); //服务器发送事件
                    break;
                default: break;
            }
        }

        //断开连接
        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail) { }
    }
}