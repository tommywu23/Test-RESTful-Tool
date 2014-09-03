using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace httptool.Utils {
	public class ClientHelper {
		public static ClientHelper Instance { get { return instance; } }

		public ClientHelper() {
			contentType = new Dictionary<string, string>();
			contentType.Add(ContentType.JSON.ToString(), "application/json; charset=utf-8");
			contentType.Add(ContentType.Form.ToString(), "application/x-www-form-urlencoded");
		}

		public string HttpReq(RequestMethod action, ContentType reqtype, string url, string data = null) {
			string result = string.Empty;

			try {
				using (var response = RawReq(action, reqtype, url, data)) {
					result = GetStream(response.GetResponseStream());
				}
			} catch (WebException ex) {
				throw ex;
			} catch (Exception ex) {
				throw ex;
			}

			return result;
		}

		public string GetData(HttpWebResponse resp) {
			string result = string.Empty;
			try {
				using (Stream stream = resp.GetResponseStream()) {
					using (StreamReader reader = new StreamReader(stream)) {
						result = reader.ReadToEnd();
					}
				}
			} catch (WebException ex) {
				throw ex;
			} catch (Exception ex) {
				throw ex;
			}

			return result;
		}

		// close response by client
		private HttpWebResponse RawGet(string url, Dictionary<string, string> options = null) {
			HttpWebResponse result = null;
			var request = HttpWebRequest.Create(url) as HttpWebRequest;
			request.Method = "GET";

			//request.Timeout = 500;
			try {
				result = request.GetResponse() as HttpWebResponse;
			} catch (WebException ex) {
				throw ex;
			} catch (Exception ex) {
				throw ex;
			}
			return result;
		}

		private HttpWebResponse RawReq(RequestMethod action, ContentType reqtype, string url, string data = null) {
			byte[] buffer = Encoding.UTF8.GetBytes(data);

			HttpWebResponse result = null;
			var request = HttpWebRequest.Create(url) as HttpWebRequest;
			request.Method = action.ToString();
			request.ContentType = contentType[reqtype.ToString()];
			request.ContentLength = buffer.Length;

			try {
				if (buffer.Length > 0) request.GetRequestStream().Write(buffer, 0, buffer.Length);
				result = request.GetResponse() as HttpWebResponse;
			} catch (WebException ex) {
				throw ex;
			} catch (Exception ex) {
				throw ex;
			}
			return result;
		}

		private string GetStream(Stream source) {
			string result = string.Empty;
			using (var stream = source) {
				using (var reader = new StreamReader(stream)) {
					result = reader.ReadToEnd();
				}
			}
			return result;
		}

		private static Dictionary<string, string> contentType;
		private static ClientHelper instance = new ClientHelper();
	}

	public enum RequestMethod {
		PUT,
		POST,
		GET,
		DELETE
	}

	public enum ContentType {
		JSON,
		Form
	}
}
