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

        /// <summary>
        /// Send simple message
        /// </summary>
        /// <param name="strMessage">Message content to be sent</param>
        /// <returns>bool. True if successful, false if not</returns>
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

        /// <summary>
        /// Send a message with a source such as a given application
        /// </summary>
        /// <param name="strMessage">Message content to be sent</param>
        /// <param name="strSource">Source of the message</param>
        /// <returns>bool. True if successful, false if not</returns>
        public bool sendMessage(string strMessage, string strSource) {
            try {
                string strFinalMessage = "Message from: " + strSource;
                strFinalMessage += Environment.NewLine + "Message as follows: " + strMessage;

                string url = String.Format("https://api.telegram.org/{0}/sendMessage?chat_id={1}&text={2}", this._bot, this._group, strFinalMessage);

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

        /// <summary>
        /// Send a message with source and severity level
        /// </summary>
        /// <param name="strMessage">Message content to be sent</param>
        /// <param name="strSource">Source of the message</param>
        /// <param name="severity">Severity of message</param>
        /// <returns>bool. True if successful, false if not</returns>
        public bool sendMessage(string strMessage, string strSource, Severity severity) {
            try {
                string strFinalMessage = "Message from: " + strSource;
                strFinalMessage += Environment.NewLine + "Severity: " + severity;
                strFinalMessage += Environment.NewLine + "Message as follows: " + strMessage;

                string url = String.Format("https://api.telegram.org/{0}/sendMessage?chat_id={1}&text={2}", this._bot, this._group, strFinalMessage);

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
        public enum Severity
        {
            Information = 0,
            Trace = 1,
            Error = 2
        }
    }
}