using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace httptool {
	public class AppManager {
		public static AppManager Instance {
			get {
				return instance;
			}
		}

		public HttpVO DataContext {
			get {
				return content;
			}
		}

		AppManager() {
			content = new HttpVO{
				UrlContent = new ObservableCollection<string>(),
				BodyContent = @" e.g.[{""name"":""shidiao"",""type"":""camera"",""address"":""rtsp://192.168.16.141:8554/stream.smp?address=192.168.16.214""}]"
			};

			content.UrlContent.Add(@"e.g. http://127.0.0.1:3000/status");
		}

		internal void ClearUrl() {
			content.UrlContent[0] = "http://";
		}

		internal void ClearBody() {
			content.BodyContent = "";
		}

		internal void SetRes(string data) {
			content.ResponeContent = data;
		}

		private HttpVO content;
		private static AppManager instance = new AppManager();
	}
}
