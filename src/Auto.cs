using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src
{
    class Auto
    {
        string mark= "";
        string model = "";
        decimal price = 0;

        public string Mark
        {
            get { return this.mark; }
            set { this.mark = value; }
        }

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public decimal Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

    }
}
