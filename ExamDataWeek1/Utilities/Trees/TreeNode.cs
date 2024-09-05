using ExamDataWeek1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDataWeek1.Service.Trees
{
    internal class TreeNode
    {
        public DefenseModel? DefenseStrategy;
        public TreeNode? Right { get; set; }
        public TreeNode? Left { get; set; }
        public int Hight { get; set; }
    }
}
