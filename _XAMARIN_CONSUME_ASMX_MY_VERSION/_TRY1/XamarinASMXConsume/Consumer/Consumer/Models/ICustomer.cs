using System;
using System.Collections.Generic;
using System.Text;

namespace Consumer.Models
{
    public interface ICustomer
    {
        string Name { get; set; }
        string Id { get; set; }
    }
}
