using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Component
{
    [ServiceContract(Namespace = "urn:DarthScottius")]
    interface ISeahawks
    {
        [OperationContract]
        string BeatTheNiners(int pointSpread);

        [OperationContract]
        string BeatTheBroncos(int pointSpread);

        [OperationContract]
        string WinSuperbowl();
    }

    

}
