using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Management
{
    internal class Clothes: DepoItem
    {
        private string Size;
        public Clothes(string Title, string itemType, ItemStatus Status, string Size) : base(itemType, Title, Size, Status)
        {
            this.Size = Size;
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"{Context()}" +
                $": {Size}"
                );
        }
    }
}
