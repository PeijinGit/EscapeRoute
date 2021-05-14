using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{

    public class ReceiveModel
    {
        public string Uuid { get; set; }
        public string Scene { get; set; }
        public SendData[] SendData { get; set; }
    }

    public class SendData
    {
        public int seq { get; set; }
        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
    }
}
