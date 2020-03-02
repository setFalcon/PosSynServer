using System.IO;
using ExitGames.Logging;
using ExitGames.Logging.Log4Net;
using log4net;
using log4net.Config;
using Photon.SocketServer;
using LogManager = ExitGames.Logging.LogManager;

namespace PosSynServer {
    //Server端主类,服务器需要使用继承ApplicationBase类的主类进行逻辑编写
    //主类负责与客户端的连接
    public class PosSynServer : ApplicationBase {
        //Logger对象，用于输出日志
        private static readonly ILogger log = LogManager.GetCurrentClassLogger();

        //初始化
        protected override void Setup() {
            //日志初始化
            GlobalContext.Properties["Photon:ApplicationLogPath"] =
                Path.Combine(ApplicationRootPath, "bin_Win64", "log"); //设置属性{Photon:ApplicationLogPath}
            FileInfo configFileInfo = new FileInfo(Path.Combine(BinaryPath, "log4net.config"));
            if (configFileInfo.Exists) {
                LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance); //Log工厂设置插件
                XmlConfigurator.ConfigureAndWatch(configFileInfo); //读取xml配置文件
            }

            log.Info("Setup Complete");
        }

        //客户端与服务器创建连接
        protected override PeerBase CreatePeer(InitRequest initRequest) {
            log.Info("有客户端连接");
            return new MyClientPeer(initRequest);
        }

        //服务关闭
        protected override void TearDown() { }
    }
}