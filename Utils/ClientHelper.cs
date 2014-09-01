using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace httptool.Utils {
	public class ClientHelper {
		static public string GetData(HttpWebResponse resp) {
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

		static public string Get(string url, Dictionary<string, string> options = null) {
			string result = string.Empty;
			try {
				using (var response = RawGet(url, options)) {
					using (var stream = response.GetResponseStream()) {
						using (var reader = new StreamReader(stream)) {
							result = reader.ReadToEnd();
						}
					}
				}
			} catch (WebException ex) {
				throw ex;
			} catch (Exception ex) {
				throw ex;
			}
			return result;
		}

		static public string Post(string url, string data, Dictionary<string, string> options = null) {
			string result = string.Empty;
			try {
				using (var response = RawPost(url, data, options)) {
					using (var stream = response.GetResponseStream()) {
						using (var reader = new StreamReader(stream)) {
							result = reader.ReadToEnd();
						}
					}
				}
			} catch (WebException ex) {
				throw ex;
			} catch (Exception ex) {
				throw ex;
			}
			return result;
		}

		static public string Put(string url, string data, Dictionary<string, string> options = null) {
			string result = string.Empty;
			try {
				using (var response = RawPut(url, data, options)) {
					using (var stream = response.GetResponseStream()) {
						using (var reader = new StreamReader(stream)) {
							result = reader.ReadToEnd();
						}
					}
				}
			} catch (WebException ex) {
				throw ex;
			} catch (Exception ex) {
				throw ex;
			}
			return result;
		}

		static public string Delete(string url,string data, Dictionary<string, string> options = null) {
			string result = string.Empty;
			try {
				using (var response = RawDELETE(url, data, options)) {
					using (var stream = response.GetResponseStream()) {
						using (var reader = new StreamReader(stream)) {
							result = reader.ReadToEnd();
						}
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
		static private HttpWebResponse RawGet(string url, Dictionary<string, string> options = null) {
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

		// close response by client
		static private HttpWebResponse RawPost(string url, string data, Dictionary<string, string> options = null) {
			byte[] buffer = Encoding.UTF8.GetBytes(data);

			HttpWebResponse result = null;
			var request = HttpWebRequest.Create(url) as HttpWebRequest;
			request.Method = "POST";
			// request.Timeout = 500;
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = buffer.Length;
			try {
				request.GetRequestStream().Write(buffer, 0, buffer.Length);
				result = request.GetResponse() as HttpWebResponse;
			} catch (WebException ex) {
				throw ex;
			} catch (Exception ex) {
				throw ex;
			}
			return result;
		}

		static private HttpWebResponse RawPut(string url, string data, Dictionary<string, string> options) {
			byte[] buffer = Encoding.UTF8.GetBytes(data);

			HttpWebResponse result = null;
			var request = HttpWebRequest.Create(url) as HttpWebRequest;
			request.Method = "PUT";
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = buffer.Length;
			try {
				request.GetRequestStream().Write(buffer, 0, buffer.Length);
				result = request.GetResponse() as HttpWebResponse;
			} catch (WebException ex) {
				throw ex;
			} catch (Exception ex) {
				throw ex;
			}
			return result;
		}

		static private HttpWebResponse RawDELETE(string url, string data, Dictionary<string, string> options) {
			byte[] buffer = Encoding.UTF8.GetBytes(data);

			HttpWebResponse result = null;
			var request = HttpWebRequest.Create(url) as HttpWebRequest;
			request.Method = "DELETE";
			request.ContentType = "application/x-www-form-urlencoded";
			request.ContentLength = buffer.Length;
			try {
				request.GetRequestStream().Write(buffer, 0, buffer.Length);
				result = request.GetResponse() as HttpWebResponse;
			} catch (WebException ex) {
				throw ex;
			} catch (Exception ex) {
				throw ex;
			}
			return result;
		}

		static public HttpWebResponse RawPostByJson(string url, string data, Dictionary<string, string> options = null) {
			byte[] buffer = Encoding.UTF8.GetBytes(data);

			HttpWebResponse result = null;
			var request = HttpWebRequest.Create(url) as HttpWebRequest;
			request.Method = "POST";
			// request.Timeout = 500;
			request.ContentType = "application/json; charset=utf-8";
			request.ContentLength = buffer.Length;

			try {
				request.GetRequestStream().Write(buffer, 0, buffer.Length);
				result = request.GetResponse() as HttpWebResponse;
			} catch (WebException ex) {
				throw ex;
			} catch (Exception ex) {
				throw ex;
			}
			return result;
		}
	}
}
