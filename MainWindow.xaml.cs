using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using httptool.Utils;

namespace httptool {
	public partial class MainWindow : Window {
		public MainWindow() {
			InitializeComponent();
			this.Loaded += OnLoaded;
		}

		void OnLoaded(object sender, RoutedEventArgs e) {
			this.DataContext = AppManager.Instance.DataContext;
		}

		private void SetNormalTextStyle(Control source) {
			source.FontStyle = FontStyles.Normal;
			source.Foreground = Brushes.Black;
		}

		private void Request(RequestType reqtype, string url, string body = null) {
			string data = string.Empty;
			try {
				if (reqtype == RequestType.Post) {
					data = ClientHelper.Post(url, body);
				} else if (reqtype == RequestType.Get) {
					data = ClientHelper.Get(url);
				} else if (reqtype == RequestType.Delete) {
					data = ClientHelper.Delete(url, "");
				} else if (reqtype == RequestType.Put) {
					data = ClientHelper.Put(url, "");
				}

				AppManager.Instance.SetRes(data);
			} catch (Exception ex) {
				AppManager.Instance.SetRes(ex.Message);
			}
		}

		private bool RequestURLValid(string source) {
			if (r.IsMatch(source)) {
				return true;
			} else {
				MessageBox.Show("输入字符无效");
				return false;
			}
		}

		private void Post_Click(object sender, RoutedEventArgs e) {
			var url = CBUrl.SelectedValue == null ? CBUrl.Text : CBUrl.SelectedValue.ToString();
			var body = TBBody.Text;
			if (RequestURLValid(url)) Request(RequestType.Post, url, body);
		}


		private void Put_Click(object sender, RoutedEventArgs e) {
			var url = CBUrl.SelectedValue == null ? CBUrl.Text : CBUrl.SelectedValue.ToString();
			if (RequestURLValid(url)) Request(RequestType.Put, url);
		}

		private void Del_Click(object sender, RoutedEventArgs e) {
			var url = CBUrl.SelectedValue == null ? CBUrl.Text : CBUrl.SelectedValue.ToString();
			if (RequestURLValid(url)) Request(RequestType.Delete, url);
		}

		private void Get_Click(object sender, RoutedEventArgs e) {
			var url = CBUrl.SelectedValue == null ? CBUrl.Text : CBUrl.SelectedValue.ToString();
			if (RequestURLValid(url)) Request(RequestType.Get, url);
		}

		private void TBUrl_GotFocus(object sender, RoutedEventArgs e) {
			SetNormalTextStyle(sender as Control);
			AppManager.Instance.ClearUrl();
		}

		private void TBBody_GotFocus(object sender, RoutedEventArgs e) {
			SetNormalTextStyle(sender as Control);
			AppManager.Instance.ClearBody();
		}

		private void CBUrl_GotFocus(object sender, RoutedEventArgs e) {
			SetNormalTextStyle(sender as Control);
			AppManager.Instance.ClearUrl();
		}

		private void AddUrl_Click(object sender, RoutedEventArgs e) {
			var url = CBUrl.Text;

			if (r.IsMatch(url)) {
				AppManager.Instance.AddExec(url);
			} else {
				MessageBox.Show("输入字符无效");
			}
		}

		private void DelUrl_Click(object sender, RoutedEventArgs e) {
			AppManager.Instance.ClearExec();
		}

		private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e) {
			Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
			e.Handled = true;
		}

		private enum RequestType {
			Put,
			Post,
			Get,
			Delete
		}

		private Regex r = new Regex(@"^(http)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&amp;%\$\-]+)*@)?((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.[a-zA-Z]{2,4})(\:[0-9]+)?(/[^/][a-zA-Z0-9\.\,\?\'\\/\+&amp;%\$#\=~_\-@]*)*$");
	}
}
