using System;

namespace shipbob.Models
{
    public class OrderItem
    {
        public OrderItem()
        {

        }

        public int ID
        {
            get;
            set;
        }

        public int UserID
        {
            get;
            set;
        }

        public string TrackingID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string StreetAddress
        {
            get;
            set;
        }

        public string City
        {
            get;
            set;
        }

        public string State
        {
            get;
            set;
        }

        public string ZipCode
        {
            get;
            set;
        }
    }
}
