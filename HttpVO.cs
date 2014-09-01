using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace httptool {
	public class HttpVO : DependencyObject {
		public ObservableCollection<string> UrlContent {
			get { return (ObservableCollection<string>)GetValue(UrlContentProperty); }
			set { SetValue(UrlContentProperty, value); }
		}

		public string BodyContent {
			get { return (string)GetValue(BodyContentProperty); }
			set { SetValue(BodyContentProperty, value); }
		}

		public string ResponeContent {
			get { return (string)GetValue(ResponeContentProperty); }
			set { SetValue(ResponeContentProperty, value); }
		}

		public static readonly DependencyProperty UrlContentProperty =
			DependencyProperty.Register("UrlContent", typeof(ObservableCollection<string>), typeof(HttpVO), new PropertyMetadata(null));

		public static readonly DependencyProperty BodyContentProperty =
			DependencyProperty.Register("BodyContent", typeof(string), typeof(HttpVO), new PropertyMetadata(""));

		public static readonly DependencyProperty ResponeContentProperty =
			DependencyProperty.Register("ResponeContent", typeof(string), typeof(HttpVO), new PropertyMetadata(""));
	}
}
