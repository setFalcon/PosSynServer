using System.Threading;

namespace PosSynServer.Threads {
    public class SyncPosThread {
        private Thread t;

        public void Run() {
            t = new Thread(UpdatePosition);
            t.IsBackground = true;
            t.Start();
        }

        public void Stop() {
            t.Abort();
        }

        private void UpdatePosition() {
            Thread.Sleep(5000);
            while (true) {
                Thread.Sleep(20);
                
            }
        }
    }
}