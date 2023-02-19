using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingAppLibrary
{
    public class Time
    {
        public string getTime()
        {
            String greeting;
            int timeNow = int.Parse(DateTime.Now.ToString("HH"));
            if(timeNow >= 0 && timeNow < 12)
            {
                greeting = "Good Morning ";
                return greeting;
            }else if(timeNow >= 12 && timeNow < 18)
            {
                greeting = "Good Afternoon ";
                return greeting;
            }
            else
            {
                greeting = "Good Evening ";
                return greeting;
            }

        }
    }
}
