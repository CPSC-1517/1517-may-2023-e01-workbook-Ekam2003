using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public enum SupervisoryLevel
    {
       // enum names are strings representing an interger value
       // by default the interger values start at 0 and increment by 1 

       //one could assign their own values to each of the enum names

        Entry,              //0
        TeamMember,         //1
        TeamLeader,         //2
        Supervisor,         //3
        DepartmentHead,     //4
        Owner               //5
    }
}
