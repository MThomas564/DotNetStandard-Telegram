using System;
using System.Net.Http;

namespace DotNetStandard_Telegram {
    public class Telegram {
        private string _bot;
        private string _group;
        private HttpClient _http = new HttpClient();
        public Telegram(string strBot, string strGroup) {
            this._bot = strBot;
            this._group = strGroup;
        }

        public bool SendMessage(string strMessage) {
            try {
                string url = String.Format("https://api.telegram.org/{0}/sendMessage?chat_id={1}&text={2}", this._bot, this._group, strMessage);

                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var result = this._http.SendAsync(request).Result;
                if (result.IsSuccessStatusCode) {
                    return true;
                } else {
                    return false;
                }
            } catch (Exception ex) {
                throw ex;
            }

        }
    }
}