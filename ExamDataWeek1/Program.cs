using ExamDataWeek1.Models;
using ExamDataWeek1.Service.Trees;
using static ExamDataWeek1.Service.JsonHandling;
using static ExamDataWeek1.Service.DefenseUtils;

namespace ExamDataWeek1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logger("Importing json file and inserting the items into a Binary search tree...");

            List<DefenseModel>? defenceStrategies = ReadFromJsonAsync<List<DefenseModel>>("../../../defenceStrategiesBalanced.json") ?? [];

            DefenceStrategiesBST defenceStrategiesBST = new DefenceStrategiesBST();

            //defenceStrategiesBST.Balance();

            Logger("Printing the BSTree...");

            foreach (var item in defenceStrategies)
            {
                defenceStrategiesBST.Insert(item);
            }
            defenceStrategiesBST.PrintPreOrder();

            Logger("Importing threats from a json file...");

            List<ThreatModel>? threats = ReadFromJsonAsync<List<ThreatModel>>("../../../threats.json") ?? [];

            Logger("Executing defenses for each possible threat...");

            threats.ForEach(threat => 
            {
                ExecuteDefense(defenceStrategiesBST, threat);
            });

            
        }

        public static void Logger(string message)
        {
            Console.WriteLine(message + "\n");
            Task.Delay(4000).Wait();
        }
    }
}
