using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zalo_TestAPI.Models
{
    public class Sender
    {
        public string id { get; set; }
    }

    public class Recipient
    {
        public string id { get; set; }
    }

    public class Coordinates
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
    }

    public class Payload
    {
        public Coordinates coordinates { get; set; }
        public string id { get; set; }
        public string thumbnail { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string size { get; set; }
        public string name { get; set; }
        public string checksum { get; set; }
        public string type { get; set; }
    }

    public class Attachment
    {
        public Payload payload { get; set; }
        public string type { get; set; }
    }

    public class Message
    {
        public string msg_id { get; set; }
        public List<string> msg_ids { get; set; }
        public string text { get; set; }
        public List<Attachment> attachments { get; set; }
    }
    public class Follower
    {
        public string id { get; set; }
    }
    public class Customer
    {
        public string id { get; set; }
    }
    public class Zalo
    {
        public string app_id { get; set; }
        public string oa_id { get; set; }
        public string user_id_by_app { get; set; }
        public string event_name { get; set; }
        public string timestamp { get; set; }
        public Sender sender { get; set; }
        public Recipient recipient { get; set; }
        public Message message { get; set; }
        public string source { get; set; }
        public Follower follower { get; set; }
        public Customer customer { get; set; }
    }


}

