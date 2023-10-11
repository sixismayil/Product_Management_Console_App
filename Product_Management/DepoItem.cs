using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product_Management
{
    enum ItemStatus { Available, CheckedOut }

    internal class DepoItem: Display
    {
        public string Title;
        public string Model;
        public string Size;
        public ItemStatus Status;

        public DepoItem(string title, ItemStatus status)
        {
            Title = title;
            Status = status;
        }

        public DepoItem(string Title, string Model, string Size, ItemStatus Status)
        {
            this.Title = Title;
            this.Model = Model;
            this.Size = Size;
            this.Status = Status;
        }

        public string Context()
        {
            return $"Model: {Model},\n" +
            $"Title: {Title},\n" +
            $"Size: {Size},\n" +
            $"Status: {Status},\n";
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine(Context());
        }

    }
}
