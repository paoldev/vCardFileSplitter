using static System.Windows.Forms.ListViewItem;

namespace vCardFileSplitter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            comboBoxSplitOrMerge.SelectedIndex = 0; //Split
        }

        private async void OnButtonBrowse_Click(object sender, EventArgs e)
        {
            if (IsSplitMode())
            {
                openFileDialog1.FileName = "*.vcf;*.vcard";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBoxSourceVcf.Text = openFileDialog1.FileName;

                    await ProcessVcf();
                }
            }
            else
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBoxSourceVcf.Text = folderBrowserDialog1.SelectedPath;

                    await ProcessVcf();
                }
            }
        }

        private async void OnButtonRefresh_Click(object sender, EventArgs e)
        {
            await ProcessVcf();
        }

        private void OnButtonExport_Click(object sender, EventArgs e)
        {
            if (AllContacts.Count > 0)
            {
                if (IsSplitMode())
                {
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            var UniqueVcfToFileNames = GenerateUniqueFilenames(AllContacts);

                            foreach (var item in AllContacts)
                            {
                                var filename = Path.Combine(folderBrowserDialog1.SelectedPath, UniqueVcfToFileNames[item]) + ".vcf";

                                File.WriteAllLines(filename, item.RawLines);
                            }

                            MessageBox.Show("Export to " + folderBrowserDialog1.SelectedPath + " successfully completed.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error exporting to " + folderBrowserDialog1.SelectedPath + Environment.NewLine + ex.Message, "Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            var RawLines = new List<string>();

                            foreach (var concact in AllContacts)
                            {
                                RawLines.AddRange(concact.RawLines);
                            }

                            File.WriteAllLines(saveFileDialog1.FileName, RawLines);

                            MessageBox.Show("Export to " + saveFileDialog1.FileName + " successfully completed.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error exporting to " + saveFileDialog1.FileName + Environment.NewLine + ex.Message, "Export", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private async Task ProcessVcf()
        {
            UseWaitCursor = true;

            AllContacts.Clear();
            AllItems.Clear();

            if (!string.IsNullOrWhiteSpace(textBoxSourceVcf.Text))
            {
                try
                {
                    var files = IsSplitMode() ?
                             new string[] { textBoxSourceVcf.Text } :
                             Directory.EnumerateFiles(textBoxSourceVcf.Text);

                    AllContacts.AddRange(await VCardContact.LoadFromFiles(files));
                }
                catch { }
            }
            AllContacts.Sort((VCardContact x, VCardContact y) => x.DisplayName.CompareTo(y.DisplayName));

            RefreshListView();

            RefreshPreview();

            UseWaitCursor = false;
        }

        private void RefreshListView()
        {
            AllItems.Clear();
            listView1.BeginUpdate();
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Columns.Add("");
            listView1.Columns.Add("Version");
            listView1.Columns.Add("DisplayName");
            listView1.Columns.Add("Birthday");
            listView1.Columns.Add("Telephone");
            listView1.Columns.Add("Email");
            listView1.Columns.Add("Address");
            listView1.Columns.Add("Organization");
            //listView1.LargeImageList = new();
            listView1.SmallImageList = new();
            for (int i = 0; i < AllContacts.Count; i++)
            {
                var contact = AllContacts[i];
                var item = new ListViewItem
                {
                    Tag = contact,
                    Text = " " + (i + 1).ToString(),
                    ToolTipText = string.Join(Environment.NewLine, contact.RawLines)
                };
                if (contact.Photos?.Count > 0)
                {
                    if (listView1.SmallImageList.Images.Count == 0)
                    {
                        //listView1.LargeImageList.ImageSize = new Size(64, 64);
                        listView1.SmallImageList.ImageSize = new Size(64, 64);
                    }

                    //listView1.LargeImageList.Images.Add(contact.Photos[0]);
                    listView1.SmallImageList.Images.Add(contact.Photos[0]);
                    item.ImageIndex = listView1.SmallImageList.Images.Count - 1;
                }
                item.SubItems.Add(contact.Version);
                item.SubItems.Add(contact.DisplayName);
                item.SubItems.Add(contact.Birthday);
                item.SubItems.Add(string.Join('|', contact.Telephone));
                item.SubItems.Add(string.Join('|', contact.Email));
                item.SubItems.Add(string.Join('|', contact.Address));
                item.SubItems.Add(string.Join('|', contact.Organization));

                AllItems.Add(item);
            }
            RefreshListItems();
            if (listView1.Items.Count > 0)
            {
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                listView1.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            else
            {
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            listView1.EndUpdate();
        }

        private void RefreshListItems()
        {
            listView1.Items.Clear();
            if (string.IsNullOrEmpty(textBoxFilter.Text))
            {
                listView1.Items.AddRange(AllItems.ToArray());
            }
            else
            {
                listView1.Items.AddRange(AllItems.Where(x => x.SubItems.Cast<ListViewSubItem>().Any(t => t.Text.Contains(textBoxFilter.Text, StringComparison.InvariantCultureIgnoreCase))).ToArray());
            }
            labelItemsNumber.Text = (listView1.Items.Count == 1) ? "1 item" : $"{listView1.Items.Count} items";
        }

        private void RefreshPreview()
        {
            textBoxPreview.Text = string.Empty;
            var selectedItems = listView1.SelectedItems;
            if (selectedItems?.Count > 0)
            {
                foreach (ListViewItem item in selectedItems)
                {
                    if (item.Tag is VCardContact contact)
                    {
                        textBoxPreview.Text += string.Join(Environment.NewLine, contact.RawLines);
                        textBoxPreview.Text += Environment.NewLine;
                    }
                }
            }
        }

        private static Dictionary<VCardContact, string> GenerateUniqueFilenames(List<VCardContact> contacts)
        {
            var UniqueVcfToFileNames = new Dictionary<VCardContact, string>();
            var UniqueFileNames = new List<string>();
            var ConflictingItems = new List<VCardContact>();
            foreach (var item in contacts)
            {
                var ExpectedFileName = SanitizeFileName(item.DisplayName);
                if (!UniqueFileNames.Contains(ExpectedFileName, StringComparer.InvariantCultureIgnoreCase))
                {
                    UniqueFileNames.Add(ExpectedFileName);
                    UniqueVcfToFileNames.Add(item, ExpectedFileName);
                }
                else
                {
                    ConflictingItems.Add(item);
                }
            }

            foreach (var item in ConflictingItems)
            {
                int Count = 2;
                var ExpectedFileName = SanitizeFileName(item.DisplayName);
                while (UniqueFileNames.Contains(ExpectedFileName, StringComparer.InvariantCultureIgnoreCase))
                {
                    ExpectedFileName = SanitizeFileName(item.DisplayName + " (" + Count.ToString() + ")");
                    Count++;
                }

                UniqueFileNames.Add(ExpectedFileName);
                UniqueVcfToFileNames.Add(item, ExpectedFileName);
            }

            return UniqueVcfToFileNames;
        }

        private static string SanitizeFileName(string filename)
        {
            var reservedChars = Path.GetInvalidFileNameChars();
            string sanitized = string.Join("_", filename.Split(reservedChars)).Replace(".", "_");
            return sanitized;
        }

        private async void OnComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxSourceVcf.Text = string.Empty;
            textBoxPreview.Text = string.Empty;
            buttonBrowse.Text = IsSplitMode() ? "Select file" : "Select folder";

            await ProcessVcf();
        }

        private bool IsSplitMode()
        {
            return (comboBoxSplitOrMerge.Text == "Split");
        }

        private void OnListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            RefreshPreview();
        }

        private void OnTextBoxFilter_TextChanged(object sender, EventArgs e)
        {
            RefreshListItems();
        }

        private void OnButtonClearFilter_Click(object sender, EventArgs e)
        {
            textBoxFilter.Text = string.Empty;
        }

        private void OnAboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutBox = new AboutBox1
            {
                StartPosition = FormStartPosition.CenterParent
            };
            aboutBox.ShowDialog(this);
        }

        private void OnExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private readonly List<VCardContact> AllContacts = [];
        private readonly List<ListViewItem> AllItems = [];
    }
}