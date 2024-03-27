
using Vadu.Lib;
using Newtonsoft.Json.Linq;
using System.Collections.ObjectModel;

namespace Vadu
{
    public partial class JetBrainsBlockerFrm : Form
    {
        public JetBrainsBlockerFrm()
        {
            InitializeComponent();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            if (blockedPaths_listBox.Items == null || blockedPaths_listBox.Items.Count == 0)
            {
                MessageBox.Show("Thêm ít nhất 1 file để chặn");
                return;
            }
            // loop all file in listbox
            // create variable to store result
            ObservableCollection<JetBrainsBlocker.BlockStatus> results = new ObservableCollection<JetBrainsBlocker.BlockStatus>();
            foreach (var item in blockedPaths_listBox.Items)
            {
                if (item == null)
                {
                    continue;
                }
                JetBrainsBlocker.BlockStatus result = JetBrainsBlocker.Block(item.ToString());
                // push to 
                results.Add(result);
            }
            // clean all rules that are not in list box
            int deleted = JetBrainsBlocker.Clean(blockedPaths_listBox.Items.Cast<string>().ToArray());
            // show result as message like "Create new 1 rule(s) and update 2 rule(s)"
            int newRules = results.Count(r => r == JetBrainsBlocker.BlockStatus.Success);
            int updatedRules = results.Count(r => r == JetBrainsBlocker.BlockStatus.AlreadyBlocked);
            string message = MessageProcessor.GetMessage(newRules, updatedRules, deleted);
            MessageBox.Show(message);
        }

        private void openFile_btn_Click(object sender, EventArgs e)
        {
            // open file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Executable Files|*.exe";
            openFileDialog.Title = "Chọn file exe cần chặn";
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // get full path of file
                var filePath = openFileDialog.FileName;
                // get config
                JArray? execPaths = Config.Get("execPaths") as JArray;
                execPaths ??= new JArray(); // cái này sẽ check null và gán giá trị mới nếu null
                // add file path to config
                execPaths.Add(filePath);
                // set config
                Config.Set("execPaths", execPaths);
                // reload listbox
                blockedPaths_listBox.Items.Add(filePath);
            }
        }

        private void JetBrainsBlockerFrm_Load(object sender, EventArgs e)
        {
            // load all blocked paths to listbox
            JArray? execPaths = Config.Get("execPaths") as JArray;
            if (execPaths == null) return;
            foreach (var path in execPaths)
            {
                blockedPaths_listBox.Items.Add(path.ToString());
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            // delete selected item from listbox
            blockedPaths_listBox.Items.Remove(blockedPaths_listBox.SelectedItem);
            // get all items from listbox
            JArray execPaths = new JArray();
            foreach (var item in blockedPaths_listBox.Items)
            {
                execPaths.Add(item);
            }
            // set config
            Config.Set("execPaths", execPaths);
        }
    }
}