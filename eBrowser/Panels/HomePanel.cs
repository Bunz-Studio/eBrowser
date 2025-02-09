using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace eBrowser.Panels
{
    public partial class HomePanel : UserControl
    {
        [Category("Action")]
        public event EventHandler<SearchArgs> OnSearchQueried;

        [Category("Appearance")]
        [Browsable(true)]
        public bool IsSearchAllowed
        {
            get => searchButton.Enabled;
            set => searchButton.Enabled = value;
        }

        [Category("Appearance")]
        [Browsable(true)]
        public string SearchQuery
        {
            get => searchBox.Text;
            set => searchBox.Text = value;
        }

        public HomePanel()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            OnSearchQueried?.Invoke(this, new SearchArgs(SearchQuery));
        }

        private void searchBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                searchButton_Click(sender, e);
        }
    }
}
