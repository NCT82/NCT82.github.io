using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Zalo_TestAPI.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Zalo_TestAPI.Controllers
{
    public class ZaloController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(new[] { "value1", "value2"});
        }
        [HttpPost]
        public IHttpActionResult Post([FromBody] Zalo zalo)
        {
            List<Zalo> z = new List<Zalo>();
            z.Add(zalo);
            string json = JsonConvert.SerializeObject(z.ToArray());
            if (json != null)
            {
                json = json.Substring(1, json.Length - 2);
                File.AppendAllText(System.Web.Hosting.HostingEnvironment.MapPath("~/Data/text.json"), json + Environment.NewLine);
            }
            return Ok(zalo);
        }

  
    }
}
