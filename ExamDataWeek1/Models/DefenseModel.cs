using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDataWeek1.Models
{
    internal class DefenseModel
    {

        public int MinSeverity { get; set; }
        public int MaxSeverity { get; set; }
        public List<string> Defenses { get; set; } = [];

        public static bool operator >(DefenseModel d1, DefenseModel d2)
        {
            if (d1 == null || d2 == null) { return false; }
            return d1.MinSeverity > d2.MinSeverity;
        }

        public static bool operator <(DefenseModel d1, DefenseModel d2)
        {
            if (d1 == null || d2 == null) { return false; }
            return d1.MinSeverity < d2.MinSeverity;
        }
        public static bool operator >=(DefenseModel d1, DefenseModel d2)
        {
            if (d1 == null || d2 == null) { return false; }
            return d1.MinSeverity >= d2.MinSeverity;
        }
        public static bool operator <=(DefenseModel d1, DefenseModel d2)
        {
            if (d1 == null || d2 == null) { return false; }
            return d1.MinSeverity <= d2.MinSeverity;
        }
    }
}
