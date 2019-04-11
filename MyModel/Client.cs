using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyModel
{
    public class Client
    {
        int id;
        string FirstName;
        string LastName;

        

        public int Id { get => id; set => id = value; }
        public string Firstname { get => FirstName; set => FirstName = value; }
        public string Lastname { get => LastName; set => LastName = value; }
        public override string ToString()
        {
            return Firstname + " " + LastName;
        }
    }
}
