using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamDataWeek1.Models;
using ExamDataWeek1.Service.Trees;
using static ExamDataWeek1.Service.ThreatUtils;
using static ExamDataWeek1.Program;

namespace ExamDataWeek1.Service
{
    internal class DefenseUtils
    {
        public static void ExecuteDefense(DefenceStrategiesBST tree, ThreatModel threat)
        {
            Logger($"Evaluating severity level for threat: {threat.ThreatType} ...");
            int severity = EvaluateSeverity(threat);
            if (severity < tree.FindMinSeverity())
            {
                Console.WriteLine("Attack severity is below the threwshold. Attack is ignored.");
                return;
            }
            DefenseModel? defense = tree.SearchForDefense(threat);
            if (defense == null)
            {
                Console.WriteLine("No suitable defense was found! Brace for impact.");
                return;
            }
            List<string> defenseOptions = defense.Defenses;
            foreach (var item in defenseOptions)
            {
                Console.WriteLine(item);
                Task.Delay(2000).Wait();
            }
        }
    }
}
