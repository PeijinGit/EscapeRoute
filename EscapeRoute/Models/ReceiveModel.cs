using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class ReceiveModel
    {
        string UserIdentity { get; set; }
        List<List<MyVector3>> UserCoor { get; set; }
    }
}
