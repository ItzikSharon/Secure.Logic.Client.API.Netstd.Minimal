using System;
using System.Collections.Generic;
using System.Text;

namespace securelogic.prosigner.client.utils
{
    public class MiniLogger
    {
        private static MiniLogger mInstance = null;
        List<string> mStack = new List<string>();
        private uint MaxSize { get; set; } = 10 * 1024; // 10 MB
        private bool enabled { get; set; } = false;

        public void Enable(bool enable)
        {
            this.enabled = enable;
        }
        public bool IsEnabled()
        {
            return this.enabled;
        }

        public static MiniLogger Instance()
        {
            if(MiniLogger.mInstance == null)
            {
                MiniLogger.mInstance = new MiniLogger();
                MiniLogger.mInstance.Init();
            }
            return mInstance;
        }

        private void Init(){
        }

        public void Log(string message){
            if (enabled)
            {
                if (mStack.Count > MaxSize)
                {
                    this.mStack.RemoveAt(0);// rotation - remove the oldest element 
                }
                this.mStack.Add($"{DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt")}   {message}");
            }
        }
        public string Dump(bool clear = true){
            if (enabled)
            {
                StringBuilder sb = new StringBuilder($"Log Dump:  Size={this.mStack.Count}");

                foreach (string item in this.mStack)
                {
                    sb.Append(item);
                    sb.Append(Environment.NewLine);
                }

                if (clear)
                {
                    this.mStack.Clear();
                }
                return sb.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
