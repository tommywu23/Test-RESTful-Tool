using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using httptool.Utils;

namespace httptool {
	public class HttpReqModel {
		public RequestMethod Method { get; set; }

		public ContentType Type { get; set; }

		public string Action { get; set; }

		public string Content { get; set; }
	}

	public class HttpReqModelBuilder {
		public HttpReqModel Create(RequestMethod method, ContentType type, string action, string content) {
			var result = new HttpReqModel(){
				Action = action,
				Content = content,
				Method = method,
				Type = type
			};

			return result;
		}
	}

	public class HttpVO : DependencyObject, INotifyPropertyChanged {
		public event PropertyChangedEventHandler PropertyChanged;

		public ObservableCollection<string> UrlContent {
			get { return (ObservableCollection<string>)GetValue(UrlContentProperty); }
			set { 
				SetValue(UrlContentProperty, value);
			}
		}

		public string BodyContent {
			get { return (string)GetValue(BodyContentProperty); }
			set { SetValue(BodyContentProperty, value); }
		}

		public string ResponeContent {
			get { return (string)GetValue(ResponeContentProperty); }
			set { SetValue(ResponeContentProperty, value); }
		}

		public void NotifyPropertyChanged(string propertyName) {
			if (PropertyChanged != null) {
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		public static readonly DependencyProperty UrlContentProperty =
			DependencyProperty.Register("UrlContent", typeof(ObservableCollection<string>), typeof(HttpVO), new PropertyMetadata(null));

		public static readonly DependencyProperty BodyContentProperty =
			DependencyProperty.Register("BodyContent", typeof(string), typeof(HttpVO), new PropertyMetadata(""));

		public static readonly DependencyProperty ResponeContentProperty =
			DependencyProperty.Register("ResponeContent", typeof(string), typeof(HttpVO), new PropertyMetadata(""));
	}
}
