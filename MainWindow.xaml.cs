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
			var body = TBBody.Text.Contains("e.g.") ? "" : TBBody.Text;
			if (RequestURLValid(url)) {
				var req = new HttpReqModelBuilder().Create(RequestMethod.POST, currentContentType, url, body);
				AppManager.Instance.Request(req);
			}
		}

		private void Put_Click(object sender, RoutedEventArgs e) {
			var url = CBUrl.SelectedValue == null ? CBUrl.Text : CBUrl.SelectedValue.ToString();
			var body = TBBody.Text.Contains("e.g.") ? "" : TBBody.Text;
			if (RequestURLValid(url)){
				var req = new HttpReqModelBuilder().Create(RequestMethod.PUT, currentContentType, url, body);
				AppManager.Instance.Request(req);
			}
		}

		private void Del_Click(object sender, RoutedEventArgs e) {
			var url = CBUrl.SelectedValue == null ? CBUrl.Text : CBUrl.SelectedValue.ToString();
			var body = TBBody.Text.Contains("e.g.") ? "" : TBBody.Text;
			if (RequestURLValid(url)) {
				var req = new HttpReqModelBuilder().Create(RequestMethod.DELETE, currentContentType, url, body);
				AppManager.Instance.Request(req);
			}
		}

		private void Get_Click(object sender, RoutedEventArgs e) {
			var url = CBUrl.SelectedValue == null ? CBUrl.Text : CBUrl.SelectedValue.ToString();
			var body = TBBody.Text.Contains("e.g.") ? "" : TBBody.Text;
			if (RequestURLValid(url)) {
				var req = new HttpReqModelBuilder().Create(RequestMethod.GET, currentContentType, url, body);
				AppManager.Instance.Request(req);
			}
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

		private void ContentType_Checked(object sender, RoutedEventArgs e) {
			var element = (sender as RadioButton).Content;
			if(element == null) return;
			currentContentType = (element.ToString() == "JSON") ? ContentType.JSON : ContentType.Form;
		}

		private void Clear_Click(object sender, RoutedEventArgs e) {
			AppManager.Instance.ClearRes();
		}

		private Regex r = new Regex(@"^(http)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&amp;%\$\-]+)*@)?((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.[a-zA-Z]{2,4})(\:[0-9]+)?(/[^/][a-zA-Z0-9\.\,\?\'\\/\+&amp;%\$#\=~_\-@]*)*$");
		private ContentType currentContentType = ContentType.JSON;
	}
}
