using ExamDataWeek1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDataWeek1.Service
{
    internal class ThreatUtils
    {
        public static int EvaluateSeverity(ThreatModel threat) =>
            (threat.Volume * threat.Sophistication) + GetTargetValue(threat.Target);

        private static int GetTargetValue(string target)
        {
            return target switch
            {
                "Web Server" => 10,
                "Database" => 15,
                "User Credentials" => 20,
                _ => 5,
            };
        }
    }
}
