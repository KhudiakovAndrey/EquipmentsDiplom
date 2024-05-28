using Avalonia.Controls;
using System.Buffers.Text;
using WebViewCore.Enums;
using WebViewCore.Events;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Equipments.AvaloniaUI.Views
{
    public partial class ReportsView : Window
    {
        public ReportsView()
        {
            InitializeComponent();
            PART_WebView.WebViewNewWindowRequested += PART_WebView_WebViewNewWindowRequested;
        }

        private void PART_WebView_WebViewNewWindowRequested(object? sender, WebViewNewWindowEventArgs e)
        {
            e.UrlLoadingStrategy = UrlRequestStrategy.OpenInWebView;
        }
    }
}
