using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovingEstimator
{
    interface IMoveDescription
    {
        string LegalName();
        string Title();
        string Email();
        string Phone();
        DateTime MoveDate();
        DateTime FlexibleDate();
        string StartingAddress();
        string DestinationAddress();

        List<IProduct> Products { get; set; }

    }
}
