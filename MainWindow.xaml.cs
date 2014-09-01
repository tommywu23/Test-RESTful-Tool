using System;
using System.Collections.Generic;
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

		private void Post_Click(object sender, RoutedEventArgs e) {
			//MessageBox.Show(AppManager.Instance.DataContext.UrlContent);
		}

		private void Put_Click(object sender, RoutedEventArgs e) {

		}

		private void Del_Click(object sender, RoutedEventArgs e) {

		}

		private void Get_Click(object sender, RoutedEventArgs e) {
			try {
				var data = ClientHelper.Get(CBUrl.SelectedValue.ToString());
				AppManager.Instance.SetRes(data);
			} catch (Exception ex) {
				AppManager.Instance.SetRes(ex.Message);
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

		private void Button_Click(object sender, RoutedEventArgs e) {
			
		}

		private void AddUrl_Click(object sender, RoutedEventArgs e) {
			var url = TBUrl.Text;
			//Regex r = new Regex(@"\D");
		}
	}
}
