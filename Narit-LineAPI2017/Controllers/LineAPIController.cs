using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Narit_LineAPI2017.Controllers
{
    public class LineAPIController : ApiController
    {
        [HttpPost]
        public IHttpActionResult POST()
        {
            string ChannelAccessToken = "vvkngfbF+YIRDwWaETufj9Ay+wxNI/d80v8Ks+2CVNv7utvXkrcz06rWV5ylcYr6j1J0zKpgpsSxMXSDu0UVP0cCp7enOpmM+g36ki7Iane+C+M4786W+0kNhaPPSARCqoAjku0uR5NrH06wx/4+KAdB04t89/1O/w1cDnyilFU=";

            try
            {
                //取得 http Post RawData(should be JSON)
                string postData = Request.Content.ReadAsStringAsync().Result;
                //剖析JSON
                var ReceivedMessage = isRock.LineBot.Utility.Parsing(postData);
                //回覆訊息
                string Message;
                Message = "HELLO NA JA:" + ReceivedMessage.events[0].message.text;
                //回覆用戶
                isRock.LineBot.Utility.ReplyMessage(ReceivedMessage.events[0].replyToken, Message, ChannelAccessToken);
                //回覆API OK
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok();
            }
        }
    }
}
