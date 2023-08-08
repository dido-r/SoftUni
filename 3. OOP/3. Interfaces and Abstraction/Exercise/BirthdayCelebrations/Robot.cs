using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
    class Robot : IIdentifiable
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Model { get; set; }
        public string Id { get; set; }

        public void Validate(string n)
        {
            if (!Id.EndsWith(n))
            {
                Id = null;
            }
        }
    }
}
